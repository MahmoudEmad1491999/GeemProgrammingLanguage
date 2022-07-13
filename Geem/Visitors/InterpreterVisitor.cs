
using Geem.Parser;
using Geem.Utilities;
using static Geem.Parser.GeemParser;
using Geem.Infrastructure;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System.Text;
using System.Numerics;
namespace Geem.Visitors
{
    public class InterpreterVisitor : GeemBaseVisitor<object>
    {
        public StackMemory stackMemory = new StackMemory(100);
        public Stack<Object> function_return_values = new Stack<object>();
        public Boolean do_break = false;
        public Boolean do_continue = false;
        public Boolean do_terminate = false;
        public Dictionary<string, Dictionary<string, int>> func_op_variable_indices = new Dictionary<string, Dictionary<string, int>>();
        public Dictionary<string, int> gvar_indices = new Dictionary<string, int>();

        public override object Visit(IParseTree tree)
        {
            if (tree is ProgramContext) return VisitProgram((ProgramContext)tree);
            if (tree is FunctionDeclContext) return VisitFunctionDecl((FunctionDeclContext)tree);
            if (tree is OperationDeclContext) return VisitOperationDecl((OperationDeclContext)tree);
            if (tree is GlobalVarDeclContext) return VisitGlobalVarDecl((GlobalVarDeclContext)tree);
            if (tree is Var_Decl_StatContext) return VisitVar_Decl_Stat((Var_Decl_StatContext)tree);
            if (tree is Assignment_StatContext) return VisitAssignment_Stat((Assignment_StatContext)tree);
            if (tree is Operation_StatContext) return VisitOperation_Stat((Operation_StatContext)tree);
            if (tree is Result_StatContext) return VisitResult_Stat((Result_StatContext)tree);
            if (tree is Return_StatContext) return VisitReturn_Stat((Return_StatContext)tree);
            if (tree is Continue_StatContext) return VisitContinue_Stat((Continue_StatContext)tree);
            if (tree is Break_StatContext) return VisitBreak_Stat((Break_StatContext)tree);
            if (tree is If_StatContext) return VisitIf_Stat((If_StatContext)tree);
            if (tree is While_StatContext) return VisitWhile_Stat((While_StatContext)tree);
            if (tree is Command_StatContext) return VisitCommand_Stat((Command_StatContext)tree);

            if (tree is Int_literal_exprContext) return VisitInt_literal_expr((Int_literal_exprContext)tree);
            if (tree is Variable_exprContext) return VisitVariable_expr((Variable_exprContext)tree);
            if (tree is Add_exprContext) return VisitAdd_expr((Add_exprContext)tree);
            if (tree is Subtraction_exprContext) return VisitSubtraction_expr((Subtraction_exprContext)tree);
            if (tree is Multiply_exprContext) return VisitMultiply_expr((Multiply_exprContext)tree);
            if (tree is Divide_exprContext) return VisitDivide_expr((Divide_exprContext)tree);
            if (tree is Land_exprContext) return VisitLand_expr((Land_exprContext)tree);
            if (tree is Lor_exprContext) return VisitLor_expr((Lor_exprContext)tree);
            if (tree is Comparison_exprContext) return VisitComparison_expr((Comparison_exprContext)tree);
            if (tree is Equality_exprContext) return VisitEquality_expr((Equality_exprContext)tree);
            if (tree is Parenthesis_exprContext) return VisitParenthesis_expr((Parenthesis_exprContext)tree);
            if (tree is Minus_exprContext) return VisitMinus_expr((Minus_exprContext)tree);
            if (tree is Lnot_exprContext) return VisitLnot_expr((Lnot_exprContext)tree);
            if (tree is Fun_call_exprContext) return VisitFun_call_expr((Fun_call_exprContext)tree);
            if (tree is ArgumentContext) return Visit(((ArgumentContext)tree).expression());
            if (tree is Boolean_literal_exprContext) return VisitBoolean_literal_expr((Boolean_literal_exprContext)tree);

            return null;
        }

        public override object VisitProgram([NotNull] GeemParser.ProgramContext context)
        {
            var entry_operation = Array.Find(context.operationDecl(), (OperationDeclContext op) => op.ID().GetText() == "المدخل");
            if (entry_operation is null)
            {
                throw new Exception("file does not contain an entry point");
            }

            foreach (var gvar_decl in context.globalVarDecl())
            {
                Object initial_value = Visit(gvar_decl.inititalization().expression());

                stackMemory.mem[stackMemory.next_aval++] = initial_value;
                stackMemory.frame_index++;

                this.gvar_indices[gvar_decl.ID().GetText()] = this.stackMemory.next_aval - 1;
            }

            foreach (var func_decl in context.functionDecl())
            {
                string function_name = func_decl.ID().GetText();
                int index = -1;
                this.func_op_variable_indices[function_name] = new Dictionary<string, int>();
                foreach (var parameter in func_decl.paramList().parameter())
                {
                    this.func_op_variable_indices[function_name][parameter.ID().GetText()] = ++index;
                }

                foreach (var var_decl in func_decl.statementList().statement())
                {
                    if (var_decl is Var_Decl_StatContext)
                    {
                        this.func_op_variable_indices[function_name][((Var_Decl_StatContext)var_decl).varDecl().ID().GetText()] = ++index;
                    }
                }
            }
            foreach (var op_decl in context.operationDecl())
            {
                string op_name = op_decl.ID().GetText();
                int index = -1;
                this.func_op_variable_indices[op_name] = new Dictionary<string, int>();
                foreach (var parameter in op_decl.paramList().parameter())
                {
                    this.func_op_variable_indices[op_name][parameter.ID().GetText()] = ++index;
                }

                foreach (var var_decl in op_decl.statementList().statement())
                {
                    if (var_decl is Var_Decl_StatContext)
                    {
                        this.func_op_variable_indices[op_name][((Var_Decl_StatContext)var_decl).varDecl().ID().GetText()] = ++index;
                    }
                }
            }


            Visit(entry_operation);
            return null;
        }

        public override object VisitOperationDecl([NotNull] OperationDeclContext context)
        {
            string operation_name = context.ID().GetText();

            int operation_frame_size = this.func_op_variable_indices[operation_name].Count();
            // store old frame pointer.
            stackMemory.mem[stackMemory.next_aval] = stackMemory.frame_index;
            // set the new frame pointer to the next location.
            stackMemory.frame_index = stackMemory.next_aval;
            // increment the stack head by frame size + 1 "old frame is also stored.
            stackMemory.next_aval = stackMemory.next_aval + operation_frame_size + 1;


            foreach (var statement in context.statementList().statement())
            {
                // visiting statement result in a boolean value deciding whether to terminate or not.
                Visit(statement);
                if (do_terminate)
                {
                    this.do_terminate = false;
                    // restore the old frame pointer.
                    stackMemory.frame_index = (int)stackMemory.mem[stackMemory.frame_index];
                    // decrement the stack.
                    stackMemory.next_aval = stackMemory.next_aval - operation_frame_size - 1;
                };
            }

            return null;
        }
        public override object VisitFunctionDecl([NotNull] FunctionDeclContext context)
        {
            string function_name = context.ID().GetText();

            int function_frame_size = this.func_op_variable_indices[function_name].Count();
            // store old frame pointer.
            stackMemory.mem[stackMemory.next_aval] = stackMemory.frame_index;
            // set the new frame pointer to the next location.
            stackMemory.frame_index = stackMemory.next_aval;
            // increment the stack head by frame size + 1 "old frame is also stored.
            stackMemory.next_aval = stackMemory.next_aval + function_frame_size + 1;


            foreach (var statement in context.statementList().statement())
            {
                Visit(statement);
                // visiting statement result in a boolean value deciding whether to terminate or not.
                if (do_terminate)
                {
                    this.do_terminate = false;
                    // restore the old frame pointer.
                    stackMemory.frame_index = (int)stackMemory.mem[stackMemory.frame_index];
                    // decrement the stack.
                    stackMemory.next_aval = stackMemory.next_aval - function_frame_size - 1;
                };
            }

            return null;
        }
        public override object VisitVar_Decl_Stat([NotNull] Var_Decl_StatContext context)
        {
            var containing_func_or_op = context.Parent;

            while (containing_func_or_op != null && !(containing_func_or_op is FunctionDeclContext || containing_func_or_op is OperationDeclContext))
            {
                containing_func_or_op = containing_func_or_op.Parent;
            }

            string rhs_name = context.varDecl().ID().GetText();
            object expr_value = Visit(context.varDecl().inititalization().expression());

            if (containing_func_or_op is FunctionDeclContext)
            {
                var containing_func = (FunctionDeclContext)containing_func_or_op;

                int temp = stackMemory.frame_index + this.func_op_variable_indices[containing_func.ID().GetText()][rhs_name] + 1;

                stackMemory.mem[temp] = expr_value;
            }

            else if (containing_func_or_op is OperationDeclContext)
            {
                var containing_op = (OperationDeclContext)containing_func_or_op;

                int temp = stackMemory.frame_index + this.func_op_variable_indices[containing_op.ID().GetText()][rhs_name] + 1;

                stackMemory.mem[temp] = expr_value;
            }
            else throw new Exception("container should be function or operation.");
            return null;
        }

        public override object VisitAssignment_Stat([NotNull] Assignment_StatContext context)
        {
            var containing_func_or_op = context.Parent;

            while (containing_func_or_op != null && !(containing_func_or_op is FunctionDeclContext || containing_func_or_op is OperationDeclContext))
            {
                containing_func_or_op = containing_func_or_op.Parent;
            }

            string rhs_name = context.assignmentStat().ID().GetText();
            object expr_value = Visit(context.assignmentStat().expression());

            if (containing_func_or_op is FunctionDeclContext)
            {
                var containing_func = (FunctionDeclContext)containing_func_or_op;

                int temp = stackMemory.frame_index + this.func_op_variable_indices[containing_func.ID().GetText()][rhs_name] + 1;

                stackMemory.mem[temp] = expr_value;

            }
            else if (containing_func_or_op is OperationDeclContext)
            {
                var containing_op = (OperationDeclContext)containing_func_or_op;

                int temp = stackMemory.frame_index + this.func_op_variable_indices[containing_op.ID().GetText()][rhs_name] + 1;

                stackMemory.mem[temp] = expr_value;
            }
            else throw new Exception("container should be function or operation.");
            return false;
        }

        public override object VisitOperation_Stat([NotNull] Operation_StatContext context)
        {
            string operatoin_name = context.operationStat().ID().GetText();
            List<object> arguments_values = new List<object>();
            var args = context.operationStat().argumentList().argument();
            for (int index = 0; index < args.Length; index++)
            {
                // we added one because the first value is for the frame pointer.
                stackMemory.mem[stackMemory.next_aval + index + 1] = Visit(args[index]);
            }

            var program = context.Parent;
            while (program is not null && program is not ProgramContext)
            {
                program = program.Parent;
            }

            ProgramContext p = (ProgramContext)program;
            OperationDeclContext op = Array.Find(p.operationDecl(), (OperationDeclContext op) => op.ID().GetText() == operatoin_name);

            Visit(op);
            this.do_terminate = false;
            return false;
        }

        public override object VisitReturn_Stat([NotNull] Return_StatContext context)
        {
            this.do_terminate = true;
            return null;
        }
        public override object VisitResult_Stat([NotNull] Result_StatContext context)
        {
            function_return_values.Push(Visit(context.resultStat().expression()));
            this.do_terminate = true;
            return null;
        }

        public override object VisitIf_Stat([NotNull] If_StatContext context)
        {
            Visit(context.ifStat().expression());
            var condition = (bool)Visit(context.ifStat().expression());
            var statements = context.ifStat().statementList().statement();
            if (condition)
            {
                for (int index = 0; index < statements.Length; index++)
                {
                    Visit(statements[index]);
                    if (do_terminate)
                    {
                        break;
                    }
                }
            }
            return null;
        }
        public override object VisitBreak_Stat([NotNull] Break_StatContext context)
        {
            this.do_break = true;
            return null;
        }
        public override object VisitContinue_Stat([NotNull] Continue_StatContext context)
        {
            this.do_continue = true;
            return null;
        }
        public override object VisitWhile_Stat([NotNull] While_StatContext context)
        {
            var statements = context.whileStat().statementList().statement();
            var condition_expression = context.whileStat().expression();

            bool condition = (Boolean)Visit(condition_expression);

            while (condition)
            {
                foreach (var statement in statements)
                {
                    Visit(statement);
                    if (do_break)
                    {
                        this.do_break = false;
                        return null;
                    }
                    if (do_continue)
                    {
                        this.do_continue = false;
                        condition = (Boolean)Visit(condition_expression);
                        if (condition) break;
                        return null;
                    }
                    if (do_terminate)
                    {
                        return null;
                    }

                }
                condition = (Boolean)Visit(condition_expression);
            }

            return null;
        }
        public override object VisitCommand_Stat([NotNull] Command_StatContext context)
        {
            var expression = context.commandStat().command().expression();
            string expression_datatype = context.commandStat().command().expression().expression_datatype;
            object value = Visit(expression);
            if (expression_datatype == "ص_١")
            {
                sbyte val = (sbyte)value;
                Console.WriteLine(val);
            }
            else if (expression_datatype == "ص_٢")
            {
                Int16 val = (Int16)value;
                Console.WriteLine(val);
            }
            else if (expression_datatype == "ص_٤")
            {
                Int32 val = (Int32)value;
                Console.WriteLine(val);
            }
            else if (expression_datatype == "ص_٨")
            {
                Int64 val = (Int64)value;
                Console.WriteLine(val);
            }
            else if (expression_datatype == "ط_١")
            {
                byte val = (byte)value;
                Console.WriteLine(val);
            }
            else if (expression_datatype == "ط_٢")
            {
                UInt16 val = (UInt16)value;
                Console.WriteLine(val);
            }
            else if (expression_datatype == "ط_٤")
            {
                UInt32 val = (UInt32)value;
                Console.WriteLine(val);
            }
            else if (expression_datatype == "ط_٨")
            {
                UInt64 val = (UInt64)value;
                Console.WriteLine(val);
            }
            else if (expression_datatype == "منطقي")
            {
                Boolean val = (Boolean)value;
                Console.WriteLine(val);
            }
            else throw new Exception("Undefined datatype");
            return null;
        }
        public override object VisitComparison_expr([NotNull] Comparison_exprContext context)
        {
            var op1 = Visit(context.expression(0));
            int op1_dt = datatype_to_int(context.expression(0).expression_datatype);
            var op2 = Visit(context.expression(1));
            int op2_dt = datatype_to_int(context.expression(1).expression_datatype);

            var com_op = context.comparison_op().GetText();
            BigInteger b1;
            BigInteger b2;
            if (op1_dt == 1)
            {
                Byte operand_one = (Byte)op1;
                b1 = new BigInteger(operand_one);
            }
            else if (op1_dt == 2)
            {
                UInt16 operand_one = (UInt16)op1;
                b1 = new BigInteger(operand_one);

            }
            else if (op1_dt == 4)
            {
                UInt32 operand_one = (UInt32)op1;
                b1 = new BigInteger(operand_one);

            }
            else if (op1_dt == 8)
            {
                UInt64 operand_one = (UInt64)op1;
                b1 = new BigInteger(operand_one);
            }
            else if (op1_dt == -1)
            {
                SByte operand_one = (SByte)op1;
                b1 = new BigInteger(operand_one);
            }
            else if (op1_dt == -2)
            {
                Int16 operand_one = (Int16)op1;
                b1 = new BigInteger(operand_one);
            }
            else if (op1_dt == -4)
            {
                Int32 operand_one = (Int32)op1;
                b1 = new BigInteger(operand_one);
            }
            else if (op1_dt == -8)
            {
                Int64 operand_one = (Int64)op1;
                b1 = new BigInteger(operand_one);
            }
            else
            {
                b1 = new BigInteger();
            }
            try
            {
                if (op1_dt == 1)
                {
                    Byte operand_two = (Byte)op2;
                    b2 = new BigInteger(operand_two);
                }
                else if (op1_dt == 2)
                {
                    UInt16 operand_two = (UInt16)op2;
                    b2 = new BigInteger(operand_two);
                }
                else if (op1_dt == 4)
                {
                    UInt32 operand_two = (UInt32)op2;
                    b2 = new BigInteger(operand_two);
                }
                else if (op1_dt == 8)
                {
                    UInt64 operand_two = (UInt64)op2;
                    b2 = new BigInteger(operand_two);
                }
                else if (op1_dt == -1)
                {
                    SByte operand_two = (SByte)op2;
                    b2 = new BigInteger(operand_two);
                }
                else if (op1_dt == -2)
                {
                    Int16 operand_two = (Int16)op2;
                    b2 = new BigInteger(operand_two);
                }
                else if (op1_dt == -4)
                {
                    Int32 operand_two = (Int32)op2;
                    b2 = new BigInteger(operand_two);
                }
                else if (op1_dt == -8)
                {
                    Int64 operand_two = (Int64)op2;
                    b2 = new BigInteger(operand_two);
                }
                else
                {
                    b2 = new BigInteger();
                }

                if (com_op == "<")
                {
                    return b1 > b2;
                }
                else if (com_op == ">")
                {
                    return b1 < b2;
                }
                else if (com_op == "<=")
                {
                    return b1 >= b2;
                }
                else if (com_op == ">=")
                {
                    return b1 <= b2;
                }
                else if (com_op == "==")
                {
                    return b1 == b2;
                }
                else if (com_op == "!=")
                {
                    return b1 != b2;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.StackTrace}, LN: {context.Start.Line}.");
            }

            throw
            new Exception();
        }
        public override object VisitEquality_expr([NotNull] Equality_exprContext context)
        {
            var op1 = Visit(context.expression(0));
            int op1_dt = datatype_to_int(context.expression(0).expression_datatype);
            var op2 = Visit(context.expression(1));
            int op2_dt = datatype_to_int(context.expression(1).expression_datatype);

            var com_op = context.equality_op().GetText();
            BigInteger b1;
            BigInteger b2;
            if (op1_dt == 1)
            {
                Byte operand_one = (Byte)op1;
                b1 = new BigInteger(operand_one);
            }
            else if (op1_dt == 2)
            {
                UInt16 operand_one = (UInt16)op1;
                b1 = new BigInteger(operand_one);

            }
            else if (op1_dt == 4)
            {
                UInt32 operand_one = (UInt32)op1;
                b1 = new BigInteger(operand_one);

            }
            else if (op1_dt == 8)
            {
                UInt64 operand_one = (UInt64)op1;
                b1 = new BigInteger(operand_one);
            }
            else if (op1_dt == -1)
            {
                SByte operand_one = (SByte)op1;
                b1 = new BigInteger(operand_one);
            }
            else if (op1_dt == -2)
            {
                Int16 operand_one = (Int16)op1;
                b1 = new BigInteger(operand_one);
            }
            else if (op1_dt == -4)
            {
                Int32 operand_one = (Int32)op1;
                b1 = new BigInteger(operand_one);
            }
            else if (op1_dt == -8)
            {
                Int64 operand_one = (Int64)op1;
                b1 = new BigInteger(operand_one);
            }
            else
            {
                b1 = new BigInteger();
            }
            try
            {
                if (op1_dt == 1)
                {
                    Byte operand_two = (Byte)op2;
                    b2 = new BigInteger(operand_two);
                }
                else if (op1_dt == 2)
                {
                    UInt16 operand_two = (UInt16)op2;
                    b2 = new BigInteger(operand_two);
                }
                else if (op1_dt == 4)
                {
                    UInt32 operand_two = (UInt32)op2;
                    b2 = new BigInteger(operand_two);
                }
                else if (op1_dt == 8)
                {
                    UInt64 operand_two = (UInt64)op2;
                    b2 = new BigInteger(operand_two);
                }
                else if (op1_dt == -1)
                {
                    SByte operand_two = (SByte)op2;
                    b2 = new BigInteger(operand_two);
                }
                else if (op1_dt == -2)
                {
                    Int16 operand_two = (Int16)op2;
                    b2 = new BigInteger(operand_two);
                }
                else if (op1_dt == -4)
                {
                    Int32 operand_two = (Int32)op2;
                    b2 = new BigInteger(operand_two);
                }
                else if (op1_dt == -8)
                {
                    Int64 operand_two = (Int64)op2;
                    b2 = new BigInteger(operand_two);
                }
                else
                {
                    b2 = new BigInteger();
                }

                if (com_op == "==")
                {
                    return b1 == b2;
                }
                else if (com_op == "!=")
                {
                    return b1 != b2;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.StackTrace}, LN: {context.Start.Line}.");
            }

            throw
            new Exception();
        }
        public override object VisitVariable_expr([NotNull] Variable_exprContext context)
        {
            string variable_name = context.ID().GetText();

            var containing_func_or_op = context.Parent;
            while (containing_func_or_op != null && containing_func_or_op is not FunctionDeclContext && containing_func_or_op is not OperationDeclContext)
            {
                containing_func_or_op = containing_func_or_op.Parent;
            }

            if (containing_func_or_op is FunctionDeclContext)
            {
                var containing_func = (FunctionDeclContext)containing_func_or_op;
                var containing_func_name = containing_func.ID().GetText();

                if (this.func_op_variable_indices[containing_func_name].ContainsKey(variable_name))
                {
                    int address = this.stackMemory.frame_index + this.func_op_variable_indices[containing_func_name][variable_name] + 1;
                    return this.stackMemory.mem[address];
                }
                else
                {
                    return this.stackMemory.mem[this.gvar_indices[variable_name]];
                }

            }

            else if (containing_func_or_op is OperationDeclContext)
            {
                var containing_op = (OperationDeclContext)containing_func_or_op;
                var containing_op_name = containing_op.ID().GetText();

                if (this.func_op_variable_indices[containing_op_name].ContainsKey(variable_name))
                {
                    int address = this.stackMemory.frame_index + this.func_op_variable_indices[containing_op_name][variable_name] + 1;
                    return this.stackMemory.mem[address];
                }
                else
                {
                    return this.stackMemory.mem[this.gvar_indices[variable_name]];
                }

            }
            throw new Exception();
        }

        public override object VisitInt_literal_expr([NotNull] Int_literal_exprContext context)
        {

            return convert_arint_to_Int(context);
        }
        public override object VisitAdd_expr([NotNull] Add_exprContext context)
        {
            var val1 = Visit(context.expression(0));
            var val2 = Visit(context.expression(1));

            var dt1 = context.expression(0).expression_datatype;
            var dt2 = context.expression(1).expression_datatype;

            if (context.expression_datatype == "ص_١")
            {
                return (SByte)(Convert.ToSByte(val1) + Convert.ToSByte(val2));
            }
            else if (context.expression_datatype == "ص_٢")
            {
                return (Int16)(Convert.ToInt16(val1) + Convert.ToInt16(val2));
            }
            else if (context.expression_datatype == "ص_٤")
            {
                return (Int32)(Convert.ToInt32(val1) + Convert.ToInt32(val2));
            }
            else if (context.expression_datatype == "ص_٨")
            {
                return (Int64)(Convert.ToInt64(val1) + Convert.ToInt64(val2));
            }
            else if (context.expression_datatype == "ط_١")
            {
                return (Byte)(Convert.ToByte(val1) + Convert.ToByte(val2));
            }
            else if (context.expression_datatype == "ط_٢")
            {
                return (UInt16)(Convert.ToUInt16(val1) + Convert.ToUInt16(val2));
            }
            else if (context.expression_datatype == "ط_٤")
            {
                return (UInt32)(Convert.ToUInt32(val1) + Convert.ToUInt32(val2));

            }
            else if (context.expression_datatype == "ط_٨")
            {
                return (UInt64)(Convert.ToUInt64(val1) + Convert.ToUInt64(val2));
            }
            else
            {
                throw new Exception();
            }
        }
        public override object VisitSubtraction_expr([NotNull] Subtraction_exprContext context)
        {
            var val1 = Visit(context.expression(0));
            var val2 = Visit(context.expression(1));

            if (context.expression_datatype == "ص_١")
            {
                return (SByte)(Convert.ToSByte(val1) + Convert.ToSByte(val2));
            }
            else if (context.expression_datatype == "ص_٢")
            {
                return (Int16)(Convert.ToInt16(val1) - Convert.ToInt16(val2));
            }
            else if (context.expression_datatype == "ص_٤")
            {
                return (Int32)(Convert.ToInt32(val1) - Convert.ToInt32(val2));
            }
            else if (context.expression_datatype == "ص_٨")
            {
                return (Int64)(Convert.ToInt64(val1) - Convert.ToInt64(val2));
            }
            else if (context.expression_datatype == "ط_١")
            {
                return (Byte)(Convert.ToByte(val1) - Convert.ToByte(val2));
            }
            else if (context.expression_datatype == "ط_٢")
            {
                return (UInt16)(Convert.ToUInt16(val1) - Convert.ToUInt16(val2));
            }
            else if (context.expression_datatype == "ط_٤")
            {
                return (UInt32)(Convert.ToUInt32(val1) - Convert.ToUInt32(val2));

            }
            else if (context.expression_datatype == "ط_٨")
            {
                return (UInt64)(Convert.ToUInt64(val1) - Convert.ToUInt64(val2));
            }
            else
            {
                throw new Exception();
            }
        }

        public override object VisitMultiply_expr([NotNull] Multiply_exprContext context)
        {
            var val1 = Visit(context.expression(0));
            var val2 = Visit(context.expression(1));

            if (context.expression_datatype == "ص_١")
            {
                return (SByte)(Convert.ToSByte(val1) + Convert.ToSByte(val2));
            }
            else if (context.expression_datatype == "ص_٢")
            {
                return (Int16)(Convert.ToInt16(val1) * Convert.ToInt16(val2));
            }
            else if (context.expression_datatype == "ص_٤")
            {
                return (Int32)(Convert.ToInt32(val1) * Convert.ToInt32(val2));
            }
            else if (context.expression_datatype == "ص_٨")
            {
                return (Int64)(Convert.ToInt64(val1) * Convert.ToInt64(val2));
            }
            else if (context.expression_datatype == "ط_١")
            {
                return (Byte)(Convert.ToByte(val1) * Convert.ToByte(val2));
            }
            else if (context.expression_datatype == "ط_٢")
            {
                return (UInt16)(Convert.ToUInt16(val1) * Convert.ToUInt16(val2));
            }
            else if (context.expression_datatype == "ط_٤")
            {
                return (UInt32)(Convert.ToUInt32(val1) * Convert.ToUInt32(val2));

            }
            else if (context.expression_datatype == "ط_٨")
            {
                return (UInt64)(Convert.ToUInt64(val1) * Convert.ToUInt64(val2));
            }
            else
            {
                throw new Exception();
            }
        }
        public override object VisitDivide_expr([NotNull] Divide_exprContext context)
        {
            var val1 = Visit(context.expression(0));
            var val2 = Visit(context.expression(1));

           if (context.expression_datatype == "ص_١")
            {
                return (SByte)(Convert.ToSByte(val1) / Convert.ToSByte(val2));
            }
            else if (context.expression_datatype == "ص_٢")
            {
                return (Int16)(Convert.ToInt16(val1) / Convert.ToInt16(val2));
            }
            else if (context.expression_datatype == "ص_٤")
            {
                return (Int32)(Convert.ToInt32(val1) / Convert.ToInt32(val2));
            }
            else if (context.expression_datatype == "ص_٨")
            {
                return (Int64)(Convert.ToInt64(val1) / Convert.ToInt64(val2));
            }
            else if (context.expression_datatype == "ط_١")
            {
                return (Byte)(Convert.ToByte(val1) / Convert.ToByte(val2));
            }
            else if (context.expression_datatype == "ط_٢")
            {
                return (UInt16)(Convert.ToUInt16(val1) / Convert.ToUInt16(val2));
            }
            else if (context.expression_datatype == "ط_٤")
            {
                return (UInt32)(Convert.ToUInt32(val1) / Convert.ToUInt32(val2));

            }
            else if (context.expression_datatype == "ط_٨")
            {
                return (UInt64)(Convert.ToUInt64(val1) / Convert.ToUInt64(val2));
            }
            else
            {
                throw new Exception();
            }
        }

        public override object VisitLand_expr([NotNull] Land_exprContext context)
        {
            var val1 = Visit(context.expression(0));
            var val2 = Visit(context.expression(1));

            return (Boolean)((Boolean)val1 && (Boolean)val2);
        }

        public override object VisitLor_expr([NotNull] Lor_exprContext context)
        {
            var val1 = Visit(context.expression(0));
            var val2 = Visit(context.expression(1));

            return (Boolean)((Boolean)val1 || (Boolean)val2);
        }

        public override object VisitLnot_expr([NotNull] Lnot_exprContext context)
        {
            var val = Visit(context.expression());


            return (Boolean)(!(Boolean)val);
        }

        public override object VisitMinus_expr([NotNull] Minus_exprContext context)
        {
            var val = Visit(context);
            string expression_datatype = context.expression_datatype;

            if (expression_datatype == "ص_١")
            {
                return (SByte)(-1 * (SByte)(val));
            }
            else if (expression_datatype == "ط_١")
            {
                Byte value = (Byte)val;
                return (SByte)(-1 * value);
            }
            else if (expression_datatype == "ص_٢")
            {
                return (Int16)(-1 * (Int16)val);
            }
            else if (expression_datatype == "ط_٢")
            {
                UInt16 value = (UInt16)val;
                return (Int16)(-1 * value);
            }
            else if (expression_datatype == "ص_٤")
            {
                return (Int32)(-1 * (Int32)val);
            }
            else if (expression_datatype == "ط_٤")
            {
                UInt32 value = (UInt32)val;
                return (Int32)(-1 * value);
            }
            else if (expression_datatype == "ص_٨")
            {
                return (Int64)(-1 * (Int64)val);
            }
            else if (expression_datatype == "ط_٨")
            {
                UInt64 value = (UInt64)val;
                return (Int64)((Int64)(-1) * (Int64)value);
            }

            throw new Exception();
        }

        public override object VisitFun_call_expr([NotNull] Fun_call_exprContext context)
        {
            string function_name = context.ID().GetText();
            List<object> arguments_values = new List<object>();
            var args = context.argumentList().argument();
            for (int index = 0; index < args.Length; index++)
            {
                // we added one because the first value is for the frame pointer.
                stackMemory.mem[stackMemory.next_aval + index + 1] = Visit(args[index]);
            }

            var program = context.Parent;
            while (program is not null && program is not ProgramContext)
            {
                program = program.Parent;
            }

            ProgramContext p = (ProgramContext)program;
            FunctionDeclContext func = Array.Find(p.functionDecl(), (FunctionDeclContext op) => op.ID().GetText() == function_name);

            Visit(func);
            this.do_terminate = false;
            return this.function_return_values.Pop();
        }
        public override object VisitBoolean_literal_expr([NotNull] Boolean_literal_exprContext context)
        {
            if (context.Boolean_literal().GetText() == "صواب")
            {
                return true;
            }
            else if (context.Boolean_literal().GetText() == "خطأ" || context.Boolean_literal().GetText() == "خطا")
            {
                return false;
            }
            return null;
        }
        private Object convert_arint_to_Int(Int_literal_exprContext int_literal_expr)
        {
            string input = int_literal_expr.Int_literal().ToString();
            StringBuilder str_builder = new StringBuilder();
            bool is_neg = false;


            for (int index = 0; index < input.Length; index++)
            {
                if (input[index] == '-') is_neg = true;
                else if (input[index] == '٠') str_builder.Insert(0, '0');
                else if (input[index] == '١') str_builder.Insert(0, '1');
                else if (input[index] == '٢') str_builder.Insert(0, '2');
                else if (input[index] == '٣') str_builder.Insert(0, '3');
                else if (input[index] == '٤') str_builder.Insert(0, '4');
                else if (input[index] == '٥') str_builder.Insert(0, '5');
                else if (input[index] == '٦') str_builder.Insert(0, '6');
                else if (input[index] == '٧') str_builder.Insert(0, '7');
                else if (input[index] == '٨') str_builder.Insert(0, '8');
                else if (input[index] == '٩') str_builder.Insert(0, '9');
                else if (input[index] == ':') break;
                else { throw new Exception($"unknown character."); }
            }

            if (input.EndsWith(":١") || input.EndsWith(":+١"))
            {
                if (is_neg) throw new Exception($"Unsigned integer cannot be initialized with negative values. Ln: {int_literal_expr.Start.Line}");
                return Byte.Parse(str_builder.ToString());
            }
            else if (input.EndsWith(":٢") || input.EndsWith(":+٢"))
            {
                if (is_neg) throw new Exception($"Unsigned integer cannot be initialized with negative values. Ln: {int_literal_expr.Start.Line}");
                return UInt16.Parse(str_builder.ToString());
            }
            else if (input.EndsWith(":٤") || input.EndsWith(":+٤"))
            {
                if (is_neg) throw new Exception($"Unsigned integer cannot be initialized with negative values. Ln: {int_literal_expr.Start.Line}");
                return UInt32.Parse(str_builder.ToString());
            }
            else if (input.EndsWith(":٨") || input.EndsWith(":+٨"))
            {
                if (is_neg) throw new Exception($"Unsigned integer cannot be initialized with negative values. Ln: {int_literal_expr.Start.Line}");
                return UInt64.Parse(str_builder.ToString());
            }
            else if (input.EndsWith(":-١"))
            {
                if (is_neg) return SByte.Parse(str_builder.Insert(0, '-').ToString());
                return SByte.Parse(str_builder.ToString());
            }
            else if (input.EndsWith(":-٢"))
            {
                if (is_neg) return Int16.Parse(str_builder.Insert(0, '-').ToString());
                return Int16.Parse(str_builder.ToString());
            }
            else if (input.EndsWith(":-٤"))
            {
                if (is_neg) return Int32.Parse(str_builder.Insert(0, '-').ToString());
                return Int32.Parse(str_builder.ToString());
            }
            else if (input.EndsWith(":-٨"))
            {
                if (is_neg) return Int64.Parse(str_builder.Insert(0, '-').ToString());
                return Int64.Parse(str_builder.ToString());
            }
            else
            {
                if (is_neg) return Int32.Parse(str_builder.Insert(0, '-').ToString());
                return Int32.Parse(str_builder.ToString());
            }
        }

        private int datatype_to_int(string dt)
        {
            if (dt == "ط_١") return 1;
            if (dt == "ط_٢") return 2;
            if (dt == "ط_٤") return 4;
            if (dt == "ط_٨") return 8;
            if (dt == "ص_١") return -1;
            if (dt == "ص_٢") return -2;
            if (dt == "ص_٤") return -4;
            if (dt == "ص_٨") return -8;
            throw new Exception();
        }


    }
}