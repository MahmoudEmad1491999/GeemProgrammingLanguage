namespace Geem.Visitors;

using Antlr4.Runtime.Misc;
using Geem.Parser;
using static Geem.Utilities.Utils;
using static Geem.Parser.GeemParser;
using Geem.Infrastructure;
using Antlr4.Runtime.Tree;

public class TypeMismatchValidator : GeemBaseVisitor<string>
{
    // visiting expression returns the expression datatype.
    public override string Visit(IParseTree tree)
    {
        if (tree is ProgramContext) return  VisitProgram((ProgramContext)tree);
        if (tree is FunctionDeclContext) return  VisitFunctionDecl((FunctionDeclContext)tree);
        if (tree is OperationDeclContext) return  VisitOperationDecl((OperationDeclContext)tree);
        if (tree is GlobalVarDeclContext) return  VisitGlobalVarDecl((GlobalVarDeclContext)tree);
        if (tree is Var_Decl_StatContext) return  VisitVar_Decl_Stat((Var_Decl_StatContext)tree);
        if (tree is Assignment_StatContext) return  VisitAssignment_Stat((Assignment_StatContext)tree);
        if (tree is Operation_StatContext) return  VisitOperation_Stat((Operation_StatContext)tree);
        if (tree is Result_StatContext) return  VisitResult_Stat((Result_StatContext)tree);
        if (tree is Return_StatContext) return  VisitReturn_Stat((Return_StatContext)tree);
        if (tree is If_StatContext) return  VisitIf_Stat((If_StatContext)tree);
        if (tree is While_StatContext) return  VisitWhile_Stat((While_StatContext)tree);
        if (tree is Command_StatContext) return  VisitCommand_Stat((Command_StatContext)tree);

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
        var id = context.assignmentStat().ID().GetText();
        var symbolInfo = context.st.getSymbolInfo(id);
        string lhs_datatype = null;
        if (symbolInfo is VarInfo)
        {
            lhs_datatype = ((VarInfo)symbolInfo).datatype;
        }
        else
        {
            throw new Exception($"{id} is not a variable. Ln: {context.Start.Line}");
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

        string[] parameter_datatypes = ((OperationInfo)operation_info).parameter_datatypes;

        var arguments = context.operationStat().argumentList().argument();

        if (parameter_datatypes.Length != context.operationStat().argumentList().argument().Length)
        {
            throw new Exception($"Number of arguments does not match number of parameters., Ln: {context.Start.Line}");
        }

        for (int index = 0; index < parameter_datatypes.Length; index++)
        {
            string arg_datatype = Visit(arguments[index].expression());
            if (parameter_datatypes[index] != arg_datatype)
            {
                throw new Exception($"argument datatype does not match parameter datatype.\npt:{parameter_datatypes[index]}, at:{arg_datatype}.\nLn: {context.Start.Line}");
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
        string expr_datatype = Visit(context.resultStat().expression());

        if (return_type != expr_datatype)
        {
            throw new Exception($"Returned expr datatype does not match the return type of the function.\n rt: {return_type}, et: {expr_datatype}.\nLn: {context.Start.Line}.");
        }

        return null;
    }
    public override string VisitIf_Stat([NotNull] If_StatContext context)
    {
        string condition_datatype = Visit(context.ifStat().expression());
        if(condition_datatype != "منطقي" && condition_datatype != "منطقى")
        {
            throw new Exception($"condition datatype must be boolean, cd:{condition_datatype}\nLn: {context.ifStat().expression().Start.Line}");
        }

        foreach (var statement in context.ifStat().statementList().statement())
        {
            Visit(statement);
        }

        return null;
    }
    public override string VisitWhile_Stat([NotNull] While_StatContext context)
    {
        string condition_datatype = Visit(context.whileStat().expression());
        if(condition_datatype != "منطقي" && condition_datatype != "منطقى")
        {
            throw new Exception($"condition datatype must be boolean, cd:{condition_datatype}\nLn: {context.whileStat().expression().Start.Line}");
        }

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
    
    public override string VisitInt_literal_expr([NotNull] Int_literal_exprContext context)
    {
        var int_literal = context.int_literal().GetText();

        if (int_literal.EndsWith(":١") || int_literal.EndsWith(":+١"))
        {
            context.int_literal().value = Byte.Parse(Utilities.Utils.convert_ar_int_to_en_int(int_literal));
            context.expression_datatype = "ط_١";
            return context.expression_datatype;
        }
        else if (int_literal.EndsWith(":٢") || int_literal.EndsWith(":+٢"))
        {
            context.int_literal().value = UInt16.Parse(Utilities.Utils.convert_ar_int_to_en_int(int_literal));
            context.expression_datatype = "ط_٢";
            return context.expression_datatype;
        }
        else if (int_literal.EndsWith(":٤") || int_literal.EndsWith(":+٤"))
        {
            context.int_literal().value = UInt32.Parse(Utilities.Utils.convert_ar_int_to_en_int(int_literal));
            context.expression_datatype = "ط_٤";
            return context.expression_datatype;
        }
        else if (int_literal.EndsWith(":٨") || int_literal.EndsWith(":+٨"))
        {
            context.int_literal().value = UInt64.Parse(Utilities.Utils.convert_ar_int_to_en_int(int_literal));
            context.expression_datatype = "ط_٨";
            return context.expression_datatype;
        }
        else if (int_literal.EndsWith(":-١"))
        {
            context.int_literal().value = SByte.Parse(Utilities.Utils.convert_ar_int_to_en_int(int_literal));
            context.expression_datatype = "ص_١";
            return context.expression_datatype;
        }
        else if (int_literal.EndsWith(":-٢"))
        {
            context.int_literal().value = Int16.Parse(Utilities.Utils.convert_ar_int_to_en_int(int_literal));

            context.expression_datatype = "ص_٢";
            return context.expression_datatype;
        }
        else if (int_literal.EndsWith(":-٤"))
        {
            context.int_literal().value = Int32.Parse(Utilities.Utils.convert_ar_int_to_en_int(int_literal));
            context.expression_datatype = "ص_٤";
            return context.expression_datatype;
        }
        else if (int_literal.EndsWith(":-٨"))
        {
            context.int_literal().value = Int64.Parse(Utilities.Utils.convert_ar_int_to_en_int(int_literal));
            context.expression_datatype = "ص_٨";
            return context.expression_datatype;
        }
        else
        {
            context.int_literal().value = Int32.Parse(Utilities.Utils.convert_ar_int_to_en_int(int_literal));
            context.expression_datatype = "ص_٤";
            return context.expression_datatype;
        }

    }

    public override string VisitBoolean_literal_expr([NotNull] Boolean_literal_exprContext context)
    {
        var boolean_literal = context.boolean_literal();
        
        if(boolean_literal.GetText() == "صواب") boolean_literal.value = true;
        else {boolean_literal.value = false;}

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

        if (is_numeric_datatype(operand_one_datatype) && is_numeric_datatype(operand_two_datatype))
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
        else
        {
            throw new Exception($"cannot add or subtract non numeric datatypes: Ln: {context.Start.Line}");
        }
    }

    public override string VisitSubtraction_expr([NotNull] Subtraction_exprContext context)
    {
        string operand_one_datatype = Visit(context.expression(0));
        string operand_two_datatype = Visit(context.expression(1));

        if (is_numeric_datatype(operand_one_datatype) && is_numeric_datatype(operand_two_datatype))
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
        else
        {
            throw new Exception($"cannot add or subtract non numeric datatypes: Ln: {context.Start.Line}");
        }

    }

    public override string VisitMultiply_expr([NotNull] Multiply_exprContext context)
    {
        string operand_one_datatype = Visit(context.expression(0));
        string operand_two_datatype = Visit(context.expression(1));

        if (is_numeric_datatype(operand_one_datatype) && is_numeric_datatype(operand_two_datatype))
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
        else
        {
            throw new Exception($"cannot add or subtract non numeric datatypes: Ln: {context.Start.Line}");
        }
    }

    public override string VisitDivide_expr([NotNull] Divide_exprContext context)
    {
        string operand_one_datatype = Visit(context.expression(0));
        string operand_two_datatype = Visit(context.expression(1));

        if (is_numeric_datatype(operand_one_datatype) && is_numeric_datatype(operand_two_datatype))
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
        else
        {
            throw new Exception($"cannot add or subtract non numeric datatypes: Ln: {context.Start.Line}");
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

    public override string VisitFun_call_expr([NotNull] Fun_call_exprContext context)
    {
        var function_info = context.st.getSymbolInfo(context.ID().GetText());

        string[] parameter_datatypes = ((FunctionInfo)function_info).parameter_datatypes;

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
                throw new Exception($"argument datatype does not match parameter datatype.\npt:{parameter_datatypes[index]}, at:{arg_datatype}.\nLn: {context.Start.Line}");
            }
        }
        context.expression_datatype = ((FunctionInfo)function_info).return_type;
        return context.expression_datatype;
    }
      
}