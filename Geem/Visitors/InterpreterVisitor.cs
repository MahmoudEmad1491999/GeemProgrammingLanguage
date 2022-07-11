
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
            if (tree is Return_StatContext) return VisitReturn_Stat((Return_StatContext) tree);
            if (tree is Result_StatContext) return VisitResult_Stat((Result_StatContext)tree);
            if (tree is If_StatContext) return VisitIf_Stat((If_StatContext)tree);
            if (tree is While_StatContext) return VisitWhile_Stat((While_StatContext)tree);
            if (tree is Command_StatContext) return VisitCommand_Stat((Command_StatContext)tree);
            if (tree is Variable_exprContext) return VisitVariable_expr((Variable_exprContext)tree);
            if (tree is Add_exprContext) return VisitAdd_expr((Add_exprContext)tree);
            if (tree is Subtraction_exprContext) return VisitSubtraction_expr((Subtraction_exprContext)tree);
            if (tree is Multiply_exprContext) return VisitMultiply_expr((Multiply_exprContext)tree);
            if (tree is Divide_exprContext) return VisitDivide_expr((Divide_exprContext)tree);
            if (tree is Land_exprContext) return VisitLand_expr((Land_exprContext)tree);
            if (tree is Lor_exprContext) return VisitLor_expr((Lor_exprContext)tree);
            if (tree is Lnot_exprContext) return VisitLnot_expr((Lnot_exprContext)tree);
            if (tree is Comparison_exprContext) return VisitComparison_expr((Comparison_exprContext)tree);
            if (tree is Equality_exprContext) return VisitEquality_expr((Equality_exprContext)tree);
            if (tree is Parenthesis_exprContext) return VisitParenthesis_expr((Parenthesis_exprContext)tree);
            if (tree is Minus_exprContext) return VisitMinus_expr((Minus_exprContext)tree);
            if (tree is Fun_call_exprContext) return VisitFun_call_expr((Fun_call_exprContext)tree);
            if (tree is Int_literal_exprContext) return VisitInt_literal_expr((Int_literal_exprContext)tree);
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
                var terminate = (Boolean)Visit(statement);
                // visiting statement result in a boolean value deciding whether to terminate or not.
                if (terminate)
                {
                    // restore the old frame pointer.
                    stackMemory.frame_index = (int)stackMemory.mem[stackMemory.frame_index];
                    // decrement the stack.
                    stackMemory.next_aval = stackMemory.next_aval - operation_frame_size - 1;
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
            return false;
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
            for(int index = 0 ; index < args.Length; index++)
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
            return false;
        }
        public override object VisitReturn_Stat([NotNull] Return_StatContext context)
        {
            return true;
        }

        public override object VisitIf_Stat([NotNull] If_StatContext context)
        {
            var condition = (Boolean) Visit(context.ifStat().expression());
            var statements = context.ifStat().statementList().statement();
            if(condition) 
            {
                for(int index = 0; index < statements.Length; index++)
                {
                    Boolean terminate = (Boolean) Visit(statements[index]);
                    if(terminate) return true;
                }
            }
            return false;
        }

        public override object VisitComparison_expr([NotNull] Comparison_exprContext context)
        {
            var op1 = (Int64) Visit(context.expression(0));
            var op2 = (Int64) Visit(context.expression(1));
            var com_op = context.comparison_op();


            return false;
        }
        public override object VisitInt_literal_expr([NotNull] Int_literal_exprContext context)
        {

            return convert_arint_to_Int(context);
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


    }
}