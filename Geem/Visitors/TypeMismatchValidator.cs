namespace Geem.Visitors;

using Antlr4.Runtime.Misc;
using Geem.Parser;
using static Geem.Parser.GeemParser;
using System.Text;
using Geem.Infrastructure;
using Antlr4.Runtime.Tree;

public class TypeMismatchValidator : GeemBaseVisitor<string>

{
    public override string Visit(IParseTree tree)
    {
        if (tree is ProgramContext) VisitProgram((ProgramContext)tree);
        if (tree is FunctionDeclContext) VisitFunctionDecl((FunctionDeclContext)tree);
        if (tree is OperationDeclContext) VisitOperationDecl((OperationDeclContext)tree);
        if (tree is GlobalVarDeclContext) VisitGlobalVarDecl((GlobalVarDeclContext)tree);
        if (tree is Var_Decl_StatContext) VisitVar_Decl_Stat((Var_Decl_StatContext)tree);
        if (tree is Assignment_StatContext) VisitAssignment_Stat((Assignment_StatContext)tree);
        if (tree is Operation_StatContext) VisitOperation_Stat((Operation_StatContext)tree);
        if (tree is Result_StatContext) VisitResult_Stat((Result_StatContext)tree);
        if (tree is Return_StatContext) VisitReturn_Stat((Return_StatContext)tree);
        if (tree is If_StatContext) VisitIf_Stat((If_StatContext)tree);
        if (tree is While_StatContext) VisitWhile_Stat((While_StatContext)tree);
        if (tree is Command_StatContext) VisitCommand_Stat((Command_StatContext)tree);

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
        if (tree is Boolean_literal_exprContext) return VisitBoolean_literal_expr((Boolean_literal_exprContext) tree);

        return null;
    }

    public override string VisitProgram([NotNull] ProgramContext context)
    {
        foreach (var child in context.children)
        {
            Visit(child);
        }
        return null;
    }
    public override string VisitFunctionDecl([NotNull] FunctionDeclContext context)
    {
        foreach (var statement in context.statementList().statement())
        {
            Visit(statement);
        }
        return null;
    }
    public override string VisitOperationDecl([NotNull] OperationDeclContext context)
    {
        foreach (var statement in context.statementList().statement())
        {
            Visit(statement);
        }
        return null;
    }
    public override string VisitGlobalVarDecl([NotNull] GlobalVarDeclContext context)
    {
        string expr_datatype = Visit(context.inititalization().expression());
        string variable_datatype = context.datatype().GetText();

        if (expr_datatype != variable_datatype)
        {
            throw new Exception($"Type mismatch between initialization and variable datatype: {expr_datatype}, {variable_datatype} Ln: {context.Start.Line}");
        }

        return null;
    }
    public override string VisitVar_Decl_Stat([NotNull] Var_Decl_StatContext context)
    {
        string expr_datatype = Visit(context.varDecl().inititalization().expression());
        string variable_datatype = context.varDecl().datatype().GetText();

        if (expr_datatype != variable_datatype)
        {
            throw new Exception($"Type mismatch between initialization and variable datatype: {expr_datatype}, {variable_datatype} Ln: {context.Start.Line}");
        }
        return null;
    }
    public override string VisitAssignment_Stat([NotNull] Assignment_StatContext context)
    {
        var lhs_id = context.assignmentStat().ID().GetText();
        var ssinfo = context.st.getSymbolInfo(lhs_id);
        string lhs_datatype = null;
        if (ssinfo is VarInfo)
        {
            lhs_datatype = ((VarInfo)ssinfo).datatype;
        }
        else
        {
            throw new Exception($"{lhs_id} is not a variable.");
        }
        var rhs_expr_datatype = Visit(context.assignmentStat().expression());

        if (rhs_expr_datatype != lhs_datatype)
        {
            throw new Exception($"initial value and variable datatype mismatch: {lhs_datatype}, {rhs_expr_datatype}, Ln: {context.Start.Line}");
        }
        return null;
    }

    public override string VisitOperation_Stat([NotNull] Operation_StatContext context)
    {
        var operation_info = context.st.getSymbolInfo(context.operationStat().ID().GetText());
        var operation_sub_info = operation_info;

        string[] parameter_datatypes = ((OperationInfo)operation_sub_info).parameter_datatypes;

        var arguments = context.operationStat().argumentList().argument();

        if (parameter_datatypes.Length != context.operationStat().argumentList().argument().Length)
        {
            throw new Exception($"Number of parameters does not match number of arguments., Ln: {context.Start.Line}");
        }

        for (int index = 0; index < parameter_datatypes.Length; index++)
        {
            string arg_datatype = Visit(arguments[index].expression());
            if (parameter_datatypes[index] != arg_datatype)
            {
                throw new Exception($"argument datatype does not match parameter datatype.{parameter_datatypes[index]}, {arg_datatype}, Ln: {context.Start.Line}");
            }
        }
        return null;
    }

    public override string VisitResult_Stat([NotNull] Result_StatContext context)
    {
        var result_stat_contaier = context.Parent;
        while (result_stat_contaier != null && result_stat_contaier is not FunctionDeclContext)
        {
            result_stat_contaier = result_stat_contaier.Parent;
        }
        string return_type = ((FunctionDeclContext)result_stat_contaier).datatype().GetText();
        string function_name = ((FunctionDeclContext)result_stat_contaier).ID().GetText();
        string expr_datatype = Visit(context.resultStat().expression());

        if (return_type != expr_datatype)
        {
            throw new Exception($"Ln: {context.Start.Line}, type mismatch return type : {return_type}, expr_type: {expr_datatype}");
        }

        return null;
    }
    public override string VisitInt_literal_expr([NotNull] Int_literal_exprContext context)
    {
        var int_literal_ = context.Int_literal().GetText();

        if (int_literal_.EndsWith(":١") || int_literal_.EndsWith(":+١"))
        {
            context.expression_datatype = "ط_١";
            return context.expression_datatype;
        }
        else if (int_literal_.EndsWith(":٢") || int_literal_.EndsWith(":+٢"))
        {
            context.expression_datatype = "ط_٢";
            return context.expression_datatype;
        }
        else if (int_literal_.EndsWith(":٤") || int_literal_.EndsWith(":+٤"))
        {
            context.expression_datatype = "ط_٤";
            return context.expression_datatype;
        }
        else if (int_literal_.EndsWith(":٨") || int_literal_.EndsWith(":+٨"))
        {
            context.expression_datatype = "ط_٨";
            return context.expression_datatype;
        }
        else if (int_literal_.EndsWith(":-١"))
        {
            context.expression_datatype = "ص_١";
            return context.expression_datatype;
        }
        else if (int_literal_.EndsWith(":-٢"))

        {
            context.expression_datatype = "ص_٢";
            return context.expression_datatype;
        }
        else if (int_literal_.EndsWith(":-٤"))

        {
            context.expression_datatype = "ص_٤";
            return context.expression_datatype;
        }
        else if (int_literal_.EndsWith(":-٨"))
        {
            context.expression_datatype = "ص_٨";
            return context.expression_datatype;
        }
        else
        {
            context.expression_datatype = "ص_٤";
            return context.expression_datatype;
        }

    }
    
    public override string VisitBoolean_literal_expr([NotNull] Boolean_literal_exprContext context)
    {
        context.expression_datatype = "منطقي";
        return context.expression_datatype;
    }
    
    public override string VisitVariable_expr([NotNull] Variable_exprContext context)
    {
        var variable_info = context.st.getSymbolInfo(context.ID().GetText());
        context.expression_datatype = ((VarInfo)variable_info).datatype;
        return context.expression_datatype;
    }

    public override string VisitAdd_expr([NotNull] Add_exprContext context)
    {
        string operand_one_datatype = Visit(context.expression(0));
        string operand_two_datatype = Visit(context.expression(1));

        if (!is_numeric_datatype(operand_one_datatype) || !is_numeric_datatype(operand_two_datatype))
        {
            throw new Exception($"cannot add or subtract non numeric datatypes: Ln: {context.Start.Line}");
        }
        else
        {
            int dt1 = datatype_to_int(operand_one_datatype);
            int dt2 = datatype_to_int(operand_two_datatype);

            if (Math.Abs(dt1) >= Math.Abs(dt2))
            {
                if (dt1 * dt2 > 0)
                {
                    context.expression_datatype = int_to_datatype(dt1);
                    return context.expression_datatype;
                }
                else
                {
                    context.expression_datatype = int_to_datatype(-1 * Math.Abs(dt1));
                    return context.expression_datatype;
                }

            }
            else
            {
                if (dt1 * dt2 > 0)
                {
                    context.expression_datatype = int_to_datatype(dt2);
                    return context.expression_datatype;
                }
                else
                {
                    context.expression_datatype = int_to_datatype(-1 * Math.Abs(dt2));
                    return context.expression_datatype;
                }

            }

        }
    }

    public override string VisitSubtraction_expr([NotNull] Subtraction_exprContext context)
    {
        string operand_one_datatype = Visit(context.expression(0));
        string operand_two_datatype = Visit(context.expression(1));

        if (!is_numeric_datatype(operand_one_datatype) || !is_numeric_datatype(operand_two_datatype))
        {
            throw new Exception($"cannot add or subtract non numeric datatypes: Ln: {context.Start.Line}");
        }
        else
        {
            int dt1 = datatype_to_int(operand_one_datatype);
            int dt2 = datatype_to_int(operand_two_datatype);

            if (Math.Abs(dt1) >= Math.Abs(dt2))
            {
                if (dt1 * dt2 > 0)
                {
                    context.expression_datatype = int_to_datatype(dt1);
                    return context.expression_datatype;
                }
                else
                {
                    context.expression_datatype = int_to_datatype(-1 * Math.Abs(dt1));
                    return context.expression_datatype;
                }

            }
            else
            {
                if (dt1 * dt2 > 0)
                {
                    context.expression_datatype = int_to_datatype(dt2);
                    return context.expression_datatype;
                }
                else
                {
                    context.expression_datatype = int_to_datatype(-1 * Math.Abs(dt2));
                    return context.expression_datatype;
                }

            }

        }

    }

    public override string VisitMultiply_expr([NotNull] Multiply_exprContext context)
    {
        string operand_one_datatype = Visit(context.expression(0));
        string operand_two_datatype = Visit(context.expression(1));

        if (!is_numeric_datatype(operand_one_datatype) || !is_numeric_datatype(operand_two_datatype))
        {
            throw new Exception($"cannot add or subtract non numeric datatypes: Ln: {context.Start.Line}");
        }
        else
        {
            int dt1 = datatype_to_int(operand_one_datatype);
            int dt2 = datatype_to_int(operand_two_datatype);

            if (Math.Abs(dt1) >= Math.Abs(dt2))
            {
                if (dt1 * dt2 > 0)
                {
                    context.expression_datatype = int_to_datatype(dt1);
                    return context.expression_datatype;
                }
                else
                {
                    context.expression_datatype = int_to_datatype(-1 * Math.Abs(dt1));
                    return context.expression_datatype;
                }

            }
            else
            {
                if (dt1 * dt2 > 0)
                {
                    context.expression_datatype = int_to_datatype(dt2);
                    return context.expression_datatype;
                }
                else
                {
                    context.expression_datatype = int_to_datatype(-1 * Math.Abs(dt2));
                    return context.expression_datatype;
                }

            }

        }
    }

    public override string VisitDivide_expr([NotNull] Divide_exprContext context)
    {
        string operand_one_datatype = Visit(context.expression(0));
        string operand_two_datatype = Visit(context.expression(1));

        if (!is_numeric_datatype(operand_one_datatype) || !is_numeric_datatype(operand_two_datatype))
        {
            throw new Exception($"cannot add or subtract non numeric datatypes: Ln: {context.Start.Line}");
        }
        else
        {
            int dt1 = datatype_to_int(operand_one_datatype);
            int dt2 = datatype_to_int(operand_two_datatype);

            if (Math.Abs(dt1) >= Math.Abs(dt2))
            {
                if (dt1 * dt2 > 0)
                {
                    context.expression_datatype = int_to_datatype(dt1);
                    return context.expression_datatype;
                }
                else
                {
                    context.expression_datatype = int_to_datatype(-1 * Math.Abs(dt1));
                    return context.expression_datatype;
                }
            }
            else
            {
                if (dt1 * dt2 > 0)
                {
                    context.expression_datatype = int_to_datatype(dt2);
                    return context.expression_datatype;
                }
                else
                {
                    context.expression_datatype = int_to_datatype(-1 * Math.Abs(dt2));
                    return context.expression_datatype;
                }
            }

        }
    }
    public override string VisitLand_expr([NotNull] Land_exprContext context)
    {
        string operand_one_datatype = Visit(context.expression(0));
        string operand_two_datatype = Visit(context.expression(0));
        if (!is_boolean_datatype(operand_one_datatype) || !is_boolean_datatype(operand_two_datatype))
        {
            throw new Exception($"logical and works only with logical operands, Ln: {context.Start.Line}");
        }

        context.expression_datatype = "منطقي";
        return context.expression_datatype;
    }

    public override string VisitLor_expr([NotNull] Lor_exprContext context)
    {
        string operand_one_datatype = Visit(context.expression(0));
        string operand_two_datatype = Visit(context.expression(0));
        if (!is_boolean_datatype(operand_one_datatype) || !is_boolean_datatype(operand_two_datatype))
        {
            throw new Exception($"logical and works only with logical operands, Ln: {context.Start.Line}");
        }
        context.expression_datatype = "منطقي";
        return context.expression_datatype;
    }

    public override string VisitComparison_expr([NotNull] Comparison_exprContext context)
    {
        string operand_one_datatype = Visit(context.expression(0));
        string operand_two_datatype = Visit(context.expression(1));

        if (!is_numeric_datatype(operand_one_datatype) || !is_numeric_datatype(operand_two_datatype))
        {
            throw new Exception($"cannot compare non numeric datatypes: Ln: {context.Start.Line}");
        }

        else
        {
            context.expression_datatype = "منطقي";
            return context.expression_datatype;
        }
    }

    public override string VisitEquality_expr([NotNull] Equality_exprContext context)
    {
        string operand_one_datatype = Visit(context.expression(0));
        string operand_two_datatype = Visit(context.expression(1));

        if (!is_numeric_datatype(operand_one_datatype) || !is_numeric_datatype(operand_two_datatype))
        {
            throw new Exception($"cannot add or subtract non numeric datatypes: Ln: {context.Start.Line}");
        }
        else
        {
            context.expression_datatype = "منطقي";
            return context.expression_datatype;
        }
    }

    public override string VisitParenthesis_expr([NotNull] Parenthesis_exprContext context)
    {
        context.expression_datatype = Visit(context.expression());
        return context.expression_datatype;
    }

    public override string VisitMinus_expr([NotNull] Minus_exprContext context)
    {
        int dt = datatype_to_int(Visit(context.expression()));

        if (dt > 0)
        {
            context.expression_datatype = int_to_datatype(-1 * dt);
            return context.expression_datatype;
        }
        else
        {
            context.expression_datatype = int_to_datatype(dt);
            return context.expression_datatype;
        }
    }

    public override string VisitLnot_expr([NotNull] Lnot_exprContext context)
    {
        string sub_expression_datatype = Visit(context.expression());
        if (sub_expression_datatype != "منطقي")
        {
            throw new Exception($"Logical Not accept only boolean datatypes, Ln: {context.Start.Line}");
        }
        context.expression_datatype = "منطقي";
        return context.expression_datatype;
    }


    public override string VisitFun_call_expr([NotNull] Fun_call_exprContext context)
    {
        var function_info = context.st.getSymbolInfo(context.ID().GetText());
        var function_sub_info = function_info;

        string[] parameter_datatypes = ((FunctionInfo)function_sub_info).parameter_datatypes;

        var arguments = context.argumentList().argument();

        if (parameter_datatypes.Length != arguments.Length)
        {
            throw new Exception($"Number of parameters does not match number of arguments, Ln: {context.Start.Line}");
        }

        for (int index = 0; index < parameter_datatypes.Length; index++)
        {
            string arg_datatype = Visit(arguments[index].expression());

            if (parameter_datatypes[index] != arg_datatype)
            {
                throw new Exception($"argument datatype does not match parameter datatype.{parameter_datatypes[index]}, {arg_datatype}, Ln: {context.Start.Line}");
            }
        }
        context.expression_datatype = ((FunctionInfo)function_sub_info).return_type;
        return context.expression_datatype;
    }
    public override string VisitIf_Stat([NotNull] If_StatContext context)
    {
        Visit(context.ifStat().expression());
        foreach (var statement in context.ifStat().statementList().statement())
        {
            Visit(statement);
        }

        return null;
    }
    public override string VisitWhile_Stat([NotNull] While_StatContext context)
    {
        Visit(context.whileStat().expression());
        foreach (var statement in context.whileStat().statementList().statement())
        {
            Visit(statement);
        }

        return null;
    }

    public override string VisitCommand_Stat([NotNull] Command_StatContext context)
    {
        Visit(context.commandStat().command().expression());
        return null;
    }
    // private string convert_ar_int_to_en_int(string input)
    // {
    //     StringBuilder str_builder = new StringBuilder();

    //     foreach (char c in input)
    //     {
    //         if (c == '٠') str_builder.Append('0');
    //         else if (c == '١') str_builder.Append('1');
    //         else if (c == '٢') str_builder.Append('2');
    //         else if (c == '٣') str_builder.Append('3');
    //         else if (c == '٤') str_builder.Append('4');
    //         else if (c == '٥') str_builder.Append('5');
    //         else if (c == '٦') str_builder.Append('6');
    //         else if (c == '٧') str_builder.Append('7');
    //         else if (c == '٨') str_builder.Append('8');
    //         else if (c == '٩') str_builder.Append('9');
    //         else { throw new Exception($"unknown character. {c}"); }
    //     }

    //     return str_builder.ToString().Reverse().ToString();
    // }
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

    public string int_to_datatype(int dt)
    {
        if (dt == 1) return "ط_١";
        if (dt == 2) return "ط_٢";
        if (dt == 4) return "ط_٤";
        if (dt == 8) return "ط_٨";
        if (dt == -1) return "ص_١";
        if (dt == -2) return "ص_٢";
        if (dt == -4) return "ص_٤";
        if (dt == -8) return "ص_٨";
        throw new Exception();
    }
    // private DATATYPE get_result_datatype(DATATYPE dt1, DATATYPE dt2, string op)
    // {
    //     if (op is "add")
    //     {
    //         if (
    //             is_both_unsigned(dt1, dt2)
    //         )
    //         {
    //             return (dt1 > dt2 ? dt1 : dt2);
    //         }
    //         else
    //         {

    //         }
    //     }
    //     throw new Exception();
    // }
    // private bool is_both_unsigned(DATATYPE dt1, DATATYPE dt2)
    // {
    //     return dt1 != DATATYPE.INT32 && dt2 != DATATYPE.INT32 && dt1 != DATATYPE.INT64 && dt2 != DATATYPE.INT64;
    // }
    private bool is_numeric_datatype(string dt)
    {
        if (dt == "ص_١"
        || dt == "ص_٢"
        || dt == "ص_٤"
        || dt == "ص_٨"
        || dt == "ط_١"
        || dt == "ط_٢"
        || dt == "ط_٤"
        || dt == "ط_٨")
        {
            return true;
        }
        return false;
    }

    private bool is_boolean_datatype(string dt)
    {
        if (dt == "منطقي" || dt == "منطقى")
        {
            return true;
        }
        return false;
    }
}