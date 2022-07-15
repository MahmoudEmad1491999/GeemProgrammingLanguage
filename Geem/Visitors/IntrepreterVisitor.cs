
using Geem.Parser;
using static Geem.Utilities.Utils;
using Geem.Utilities;

using static Geem.Parser.GeemParser;
using Geem.Infrastructure;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System.Text;
using System.Numerics;
namespace Geem.Visitors;


public class InterpreterVisitor : GeemBaseVisitor<Object>
{
    public Machine machine = new Machine(2500);

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
        if (tree is ParameterContext) return VisitParameter((ParameterContext)tree);
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
        if (tree is Parenthesis_exprContext) return VisitParenthesis_expr((Parenthesis_exprContext)tree);
        if (tree is Minus_exprContext) return VisitMinus_expr((Minus_exprContext)tree);
        if (tree is Lnot_exprContext) return VisitLnot_expr((Lnot_exprContext)tree);
        if (tree is Fun_call_exprContext) return VisitFun_call_expr((Fun_call_exprContext)tree);
        if (tree is Boolean_literal_exprContext) return VisitBoolean_literal_expr((Boolean_literal_exprContext)tree);


        return null;
    }

    public override object VisitProgram([NotNull] GeemParser.ProgramContext context)
    {


        foreach (var gvar_decl in context.globalVarDecl())
        {
            Object initial_value = Visit(gvar_decl.inititalization().expression());
            machine.mem[machine.next_aval] = initial_value;
            machine.frame_index++;
            machine.next_aval++;
            machine.gvar_indices[gvar_decl.ID().GetText()] = machine.next_aval - 1;
        }
        foreach (var func_decl in context.functionDecl())
        {
            string function_name = func_decl.ID().GetText();
            machine.local_variables_indices[function_name] = new Dictionary<string, int>();
            int index = 1; // started from one because zero is for the frame pointer of the previous function.
            foreach (var parameter in func_decl.paramList().parameter())
            {
                machine.local_variables_indices[function_name][parameter.ID().GetText()] = index;
                index++;
            }
            foreach (var statement in func_decl.statementList().statement())
            {
                if (statement is Var_Decl_StatContext)
                {
                    machine.local_variables_indices[function_name][((Var_Decl_StatContext)statement).varDecl().ID().GetText()] = index;
                    index++;

                }
            }
            // foreach (Var_Decl_StatContext var_decl in func_decl.statementList().statement().Where((StatementContext st) => st is Var_Decl_StatContext))
            // {
            //     machine.local_variables_indices[function_name][var_decl.varDecl().ID().GetText()] = index;
            //     index++;
            // }
        }
        foreach (var op_decl in context.operationDecl())
        {
            string op_name = op_decl.ID().GetText();
            int index = 1; // started from one because zero is for the frame pointer of the previous function.
            machine.local_variables_indices[op_name] = new Dictionary<string, int>();
            foreach (var parameter in op_decl.paramList().parameter())
            {
                machine.local_variables_indices[op_name][parameter.ID().GetText()] = index;
                index++;
            }
            foreach (var statement in op_decl.statementList().statement())
            {
                if (statement is Var_Decl_StatContext)
                {
                    machine.local_variables_indices[op_name][((Var_Decl_StatContext)statement).varDecl().ID().GetText()] = index;
                    index++;

                }
            }

            // foreach (var statement in op_decl.statementList().statement())
            // {
            //     if (statement is Var_Decl_StatContext)
            //     {
            //         machine.local_variables_indices[op_name][((Var_Decl_StatContext)statement).varDecl().ID().GetText()] = index;
            //         index++;

            //     }
            // }
            // foreach (Var_Decl_StatContext var_decl in op_decl.statementList().statement().Where((StatementContext st) => st is Var_Decl_StatContext))
            // {


            //     machine.local_variables_indices[op_name][var_decl.varDecl().ID().GetText()] = index;

            //     index++;
            // }
        }

        OperationDeclContext entry_point = context.operationDecl().First((OperationDeclContext op) => op.ID().GetText() == "المدخل");

        Visit(entry_point);
        return null;
    }

    public override object VisitOperationDecl([NotNull] OperationDeclContext context)
    {
        string operation_name = context.ID().GetText();

        int operation_frame_size = machine.local_variables_indices[operation_name].Count() + 1; // + 1 for the frame pointer.
                                                                                                // store old frame pointer.
        machine.mem[machine.next_aval] = machine.frame_index;
        // set the new frame pointer to the next location.
        machine.frame_index = machine.next_aval;
        // increment the stack head by frame size.
        machine.next_aval = machine.next_aval + operation_frame_size;


        foreach (var statement in context.statementList().statement())
        {
            // visiting statement result in a boolean value deciding whether to terminate or not.
            Visit(statement);
            if (machine.do_terminate)
            {
                machine.do_terminate = false;
                // restore the old frame pointer.
                machine.frame_index = (int)machine.mem[machine.frame_index];
                // decrement the stack.
                machine.next_aval = machine.next_aval - operation_frame_size;
                break;
            };
        }

        return null;
    }
    public override object VisitFunctionDecl([NotNull] FunctionDeclContext context)
    {
        string function_name = context.ID().GetText();

        int function_frame_size = machine.local_variables_indices[function_name].Count() + 1; // +1 for the fram pointer.
                                                                                              // store old frame pointer.
        machine.mem[machine.next_aval] = machine.frame_index;
        // set the new frame pointer to the next location.
        machine.frame_index = machine.next_aval;
        // increment the stack head by frame size.
        machine.next_aval = machine.next_aval + function_frame_size;


        foreach (var statement in context.statementList().statement())
        {
            Visit(statement);
            // visiting statement result in a boolean value deciding whether to terminate or not.
            if (machine.do_terminate)
            {
                machine.do_terminate = false;
                // restore the old frame pointer.
                machine.frame_index = (int)machine.mem[machine.frame_index];
                // decrement the stack.
                machine.next_aval = machine.next_aval - function_frame_size;
                break;
            };
        }

        return null;
    }

    public override object VisitVar_Decl_Stat([NotNull] Var_Decl_StatContext context)
    {
        var parent_func_or_op = GetParentFunctionOrOperation(context);

        string rhs_name = context.varDecl().ID().GetText();
        object expr_value = Visit(context.varDecl().inititalization().expression());

        if (parent_func_or_op is FunctionDeclContext)
        {
            var parent_func = (FunctionDeclContext)parent_func_or_op;

            int address = machine.frame_index + machine.local_variables_indices[parent_func.ID().GetText()][rhs_name];

            machine.mem[address] = expr_value;
        }
        else
        {
            var parent_oper = (OperationDeclContext)parent_func_or_op;

            int address = machine.frame_index + machine.local_variables_indices[parent_oper.ID().GetText()][rhs_name];

            machine.mem[address] = expr_value;
        }

        return null;
    }
    public override object VisitAssignment_Stat([NotNull] Assignment_StatContext context)
    {
        var containing_func_or_op = GetParentFunctionOrOperation(context);

        string rhs_name = context.assignmentStat().ID().GetText();
        object expr_value = Visit(context.assignmentStat().expression());

        if (containing_func_or_op is FunctionDeclContext)
        {
            var containing_func = (FunctionDeclContext)containing_func_or_op;

            int address = machine.frame_index + machine.local_variables_indices[containing_func.ID().GetText()][rhs_name];

            machine.mem[address] = expr_value;

        }
        else
        {
            var containing_op = (OperationDeclContext)containing_func_or_op;

            int address = machine.frame_index + machine.local_variables_indices[containing_op.ID().GetText()][rhs_name];

            machine.mem[address] = expr_value;
        }
        return null;
    }
    public override object VisitOperation_Stat([NotNull] Operation_StatContext context)
    {
        string operatoin_name = context.operationStat().ID().GetText();

        var program = GetProgramRoot(context);
        OperationDeclContext op = program.operationDecl().First((OperationDeclContext op) => op.ID().GetText() == operatoin_name);

        var args = context.operationStat().argumentList().argument();

        for (int index = 0; index < args.Length; index++)
        {
            // we added one because the first value is for the frame pointer.
            machine.mem[machine.next_aval + index + 1] = Visit(args[index]);
        }

        Visit(op);

        return null;
    }
    public override object VisitReturn_Stat([NotNull] Return_StatContext context)
    {
        machine.do_terminate = true;
        return null;
    }
    public override object VisitResult_Stat([NotNull] Result_StatContext context)
    {
        machine.function_return_values.Push(Visit(context.resultStat().expression()));
        machine.do_terminate = true;
        return null;
    }

    public override object VisitBreak_Stat([NotNull] Break_StatContext context)
    {
        machine.do_break = true;
        return null;
    }
    public override object VisitContinue_Stat([NotNull] Continue_StatContext context)
    {
        machine.do_continue = true;
        return null;
    }

    public override object VisitIf_Stat([NotNull] If_StatContext context)
    {
        var condition = (bool)Visit(context.ifStat().expression());
        var statements = context.ifStat().statementList().statement();

        if (condition)
        {
            foreach (var statement in statements)
            {
                Visit(statement);
                if (machine.do_terminate || machine.do_break || machine.do_continue)
                {
                    return null;
                }
            }
        }
        return null;
    }
    public override object VisitWhile_Stat([NotNull] While_StatContext context)
    {
        var condition = (bool)Visit(context.whileStat().expression());
        var statements = context.whileStat().statementList().statement();

        while (condition)
        {
            foreach (var statement in statements)
            {
                Visit(statement);
                if (machine.do_terminate)
                {
                    return null;
                }
                if (machine.do_break)
                {
                    machine.do_break = false;
                    return null;
                }
                if (machine.do_continue)
                {
                    machine.do_continue = false;
                    break;
                }
            }
            condition = (bool)Visit(context.whileStat().expression());
        }

        return null;
    }

    public override object VisitCommand_Stat([NotNull] Command_StatContext context)
    {
        var expression = context.commandStat().command().expression();
        string expr_datatype = context.commandStat().command().expression().expression_datatype;
        object expr_value = Visit(expression);

        if (expr_value is BigInteger)
        {
            Console.WriteLine((BigInteger)expr_value);
        }
        else
        {
            print_expression(expr_datatype, expr_value);
        }

        return null;
    }
    public override object VisitComparison_expr([NotNull] Comparison_exprContext context)
    {
        var val1 = Visit(context.expression(0));
        var val2 = Visit(context.expression(1));
        string dt1 = context.expression(0).expression_datatype;
        string dt2 = context.expression(1).expression_datatype;

        var com_op = context.comparison_op().GetText();

        BigInteger b1 = val1 is not BigInteger ? get_big_integer(val1, dt1) : (BigInteger)val1;
        BigInteger b2 = val2 is not BigInteger ? get_big_integer(val2, dt2) : (BigInteger)val2;

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
            throw new Exception($"Undefinede comparison operator: {com_op}");
        }
    }


    public override object VisitVariable_expr([NotNull] Variable_exprContext context)
    {
        string variable_name = context.ID().GetText();

        var parent_func_or_op = GetParentFunctionOrOperation(context);

        if (parent_func_or_op is FunctionDeclContext)
        {
            var parent_func = (FunctionDeclContext)parent_func_or_op;
            var func_name = parent_func.ID().GetText();

            if (machine.local_variables_indices[func_name].ContainsKey(variable_name))
            {
                int address = machine.frame_index + machine.local_variables_indices[func_name][variable_name];
                return machine.mem[address];
            }
            else
            {
                return machine.mem[machine.gvar_indices[variable_name]];
            }

        }
        else
        {
            var parent_operation = (OperationDeclContext)parent_func_or_op;
            var operation_name = parent_operation.ID().GetText();

            if (machine.local_variables_indices[operation_name].ContainsKey(variable_name))
            {
                int address = machine.frame_index + machine.local_variables_indices[operation_name][variable_name];
                return machine.mem[address];
            }
            else
            {
                return machine.mem[machine.gvar_indices[variable_name]];
            }

        }
    }
    public override object VisitInt_literal_expr([NotNull] Int_literal_exprContext context)
    {

        return get_big_integer(context.int_literal().value, context.expression_datatype);
    }
    public override object VisitAdd_expr([NotNull] Add_exprContext context)
    {
        var val1 = Visit(context.expression(0));
        var val2 = Visit(context.expression(1));

        var dt1 = context.expression(0).expression_datatype;
        var dt2 = context.expression(1).expression_datatype;

        BigInteger b1 = val1 is not BigInteger ? get_big_integer(val1, dt1) : (BigInteger)val1;
        BigInteger b2 = val2 is not BigInteger ? get_big_integer(val2, dt2) : (BigInteger)val2;

        return b1 + b2;
    }
    public override object VisitSubtraction_expr([NotNull] Subtraction_exprContext context)
    {
        var val1 = Visit(context.expression(0));
        var val2 = Visit(context.expression(1));

        var dt1 = context.expression(0).expression_datatype;
        var dt2 = context.expression(1).expression_datatype;

        BigInteger b1 = val1 is not BigInteger ? get_big_integer(val1, dt1) : (BigInteger)val1;
        BigInteger b2 = val2 is not BigInteger ? get_big_integer(val2, dt2) : (BigInteger)val2;

        return b1 - b2;
    }
    public override object VisitMultiply_expr([NotNull] Multiply_exprContext context)
    {
        var val1 = Visit(context.expression(0));
        var val2 = Visit(context.expression(1));

        var dt1 = context.expression(0).expression_datatype;
        var dt2 = context.expression(1).expression_datatype;

        BigInteger b1 = val1 is not BigInteger ? get_big_integer(val1, dt1) : (BigInteger)val1;
        BigInteger b2 = val2 is not BigInteger ? get_big_integer(val2, dt2) : (BigInteger)val2;

        return b1 * b2;
    }


    public override object VisitDivide_expr([NotNull] Divide_exprContext context)
    {
        var val1 = Visit(context.expression(0));
        var val2 = Visit(context.expression(1));

        var dt1 = context.expression(0).expression_datatype;
        var dt2 = context.expression(1).expression_datatype;

        BigInteger b1 = val1 is not BigInteger ? get_big_integer(val1, dt1) : (BigInteger)val1;
        BigInteger b2 = val2 is not BigInteger ? get_big_integer(val2, dt2) : (BigInteger)val2;

        return b1 / b2;
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
        var value = Visit(context.expression());
        string datatype = context.expression().expression_datatype;

        BigInteger b = get_big_integer(value, datatype);

        return b * new BigInteger(-1);
    }


    public override object VisitFun_call_expr([NotNull] Fun_call_exprContext context)
    {
        string function_name = context.ID().GetText();

        var args = context.argumentList().argument();
        for (int index = 0; index < args.Length; index++)
        {
            int address = machine.next_aval + index + 1;
            // we added one because the first value is for the frame pointer.
            machine.mem[address] = Visit(args[index].expression());
        }

        var program = GetProgramRoot(context);


        FunctionDeclContext func = program.functionDecl().First((FunctionDeclContext func_decl) => func_decl.ID().GetText() == function_name);

        Visit(func);

        return machine.function_return_values.Pop();
    }

    public override object VisitBoolean_literal_expr([NotNull] Boolean_literal_exprContext context)
    {
        return (bool)context.boolean_literal().value;
    }
}