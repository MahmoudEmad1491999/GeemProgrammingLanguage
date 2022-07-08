namespace Geem.Visitors;

using Geem.Parser;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

using System;
using System.IO;
using System.Collections.Generic;
using Antlr4.Runtime.Misc;
using static Geem.Parser.GeemParser;
public class UsedBeforeDeclaration : GeemBaseVisitor<object>
{
    public List<string> defined_gvars = new List<string>();
    public List<string> defined_functions = new List<string>();
    public List<string> defined_operations = new List<string>();

    public Dictionary<string, List<string>> fun_op_defined_lvar = new Dictionary<string, List<string>>();
    public override object Visit(IParseTree tree)
    {
        if(tree is ProgramContext)                  VisitProgram((ProgramContext)tree);
        if(tree is FunctionDeclContext)             VisitFunctionDecl((FunctionDeclContext)tree);
        if(tree is OperationDeclContext)            VisitOperationDecl((OperationDeclContext)tree);
        if(tree is Var_Decl_StatContext)            VisitVar_Decl_Stat((Var_Decl_StatContext)tree);
        if(tree is Assignment_StatContext)          VisitAssignment_Stat((Assignment_StatContext)tree);
        if(tree is Operation_StatContext)           VisitOperation_Stat((Operation_StatContext)tree);
        if(tree is Result_StatContext)              VisitResult_Stat((Result_StatContext)tree);
        if(tree is Int_literal_exprContext)         VisitInt_literal_expr((Int_literal_exprContext)tree);
        if(tree is Variable_exprContext)            VisitVariable_expr((Variable_exprContext)tree);
        if(tree is Add_exprContext)                 VisitAdd_expr((Add_exprContext)tree);
        if(tree is Subtraction_exprContext)         VisitSubtraction_expr((Subtraction_exprContext)tree);
        if(tree is Multiply_exprContext)            VisitMultiply_expr((Multiply_exprContext)tree);
        if(tree is Divide_exprContext)              VisitDivide_expr((Divide_exprContext)tree);
        if(tree is Land_exprContext)                VisitLand_expr((Land_exprContext)tree);
        if(tree is Lor_exprContext)                 VisitLor_expr((Lor_exprContext)tree);
        if(tree is Comparison_exprContext)          VisitComparison_expr((Comparison_exprContext)tree);
        if(tree is Equality_exprContext)            VisitEquality_expr((Equality_exprContext)tree);
        if(tree is Parenthesis_exprContext)         VisitParenthesis_expr((Parenthesis_exprContext)tree);
        if(tree is Minus_exprContext)               VisitMinus_expr((Minus_exprContext)tree);
        if(tree is Lnot_exprContext)                VisitLnot_expr((Lnot_exprContext)tree);
        if(tree is Fun_call_exprContext)            VisitFun_call_expr((Fun_call_exprContext)tree);

        return null;
    }
    public override object VisitProgram([NotNull] GeemParser.ProgramContext context)
    {
        foreach(var child in context.children)
        {
            Visit(child);
        }
        return null;
    }

    public override object VisitGlobalVarDecl([NotNull] GlobalVarDeclContext context)
    {
        this.defined_gvars.Add(context.ID().GetText());

        return null;
    }

    public override object VisitFunctionDecl([NotNull] FunctionDeclContext context)
    {
        this.defined_functions.Add(context.ID().GetText());
        foreach(var parameter in context.paramList().parameter())
        {
            try {
                this.fun_op_defined_lvar[context.ID().GetText()].Add(parameter.ID().GetText());
            }
            catch(KeyNotFoundException)
            {
                this.fun_op_defined_lvar[context.ID().GetText()] = new List<string>();
                this.fun_op_defined_lvar[context.ID().GetText()].Add(parameter.ID().GetText());

            }
        }
        foreach(var statement in context.statementList().statement())
        {
            Visit(statement);
        }
        return null;
    }

    public override object VisitOperationDecl([NotNull] OperationDeclContext context)
    {
        this.defined_operations.Add(context.ID().GetText());

        foreach(var parameter in context.paramList().parameter())
        {
            try {
                this.fun_op_defined_lvar[context.ID().GetText()].Add(parameter.ID().GetText());
            }
            catch(KeyNotFoundException)
            {
                this.fun_op_defined_lvar[context.ID().GetText()] = new List<string>();
                this.fun_op_defined_lvar[context.ID().GetText()].Add(parameter.ID().GetText());

            }
        }
        foreach(var statement in context.statementList().statement())
        {
            Visit(statement);
        }
        
        return null;
    }

    public override object VisitVar_Decl_Stat([NotNull] Var_Decl_StatContext context)
    {
        var container_fun_or_op = context.Parent;

        while(container_fun_or_op != null && 
            (container_fun_or_op is FunctionDeclContext || container_fun_or_op is OperationDeclContext)
        )
        {
            container_fun_or_op = container_fun_or_op.Parent;
        }

        if(container_fun_or_op is FunctionDeclContext)
        {
            this.fun_op_defined_lvar[((FunctionDeclContext) container_fun_or_op).ID().GetText()].Add(context.varDecl().ID().GetText());
        }
        else if(container_fun_or_op is OperationDeclContext) 
        {
            this.fun_op_defined_lvar[((OperationDeclContext) container_fun_or_op).ID().GetText()].Add(context.varDecl().ID().GetText());
        }
        Visit(context.varDecl().inititalization().expression());
        return null;
    }

    public override object VisitAssignment_Stat([NotNull] Assignment_StatContext context)
    {
        var container_fun_or_op = context.Parent;

        while(container_fun_or_op != null && 
            (container_fun_or_op is FunctionDeclContext || container_fun_or_op is OperationDeclContext)
        )
        {
            container_fun_or_op = container_fun_or_op.Parent;
        }
        if(container_fun_or_op is FunctionDeclContext)
        {
            this.fun_op_defined_lvar[((FunctionDeclContext) container_fun_or_op).ID().GetText()].Add(context.assignmentStat().ID().GetText());
        }
        else if(container_fun_or_op is OperationDeclContext) 
        {
            this.fun_op_defined_lvar[((OperationDeclContext) container_fun_or_op).ID().GetText()].Add(context.assignmentStat().ID().GetText());
        }
        return null;
    }

    
}