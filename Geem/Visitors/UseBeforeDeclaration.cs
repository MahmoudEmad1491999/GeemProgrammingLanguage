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

    public Dictionary<string, List<string>> func_or_op_defined_lvar = new Dictionary<string, List<string>>();
    public override object Visit(IParseTree tree)
    {
        if(tree is ProgramContext)                  VisitProgram((ProgramContext)tree);
        if(tree is FunctionDeclContext)             VisitFunctionDecl((FunctionDeclContext)tree);
        if(tree is OperationDeclContext)            VisitOperationDecl((OperationDeclContext)tree);
        if(tree is GlobalVarDeclContext)            VisitGlobalVarDecl((GlobalVarDeclContext) tree);
        if(tree is Var_Decl_StatContext)            VisitVar_Decl_Stat((Var_Decl_StatContext)tree);
        if(tree is Assignment_StatContext)          VisitAssignment_Stat((Assignment_StatContext)tree);
        if(tree is Operation_StatContext)           VisitOperation_Stat((Operation_StatContext)tree);
        if(tree is Result_StatContext)              VisitResult_Stat((Result_StatContext)tree);
        if(tree is If_StatContext)                  VisitIf_Stat((If_StatContext) tree);
        if(tree is While_StatContext)               VisitWhile_Stat((While_StatContext) tree);
        if(tree is Command_StatContext)             VisitCommand_Stat((Command_StatContext) tree);
        if(tree is Variable_exprContext)            VisitVariable_expr((Variable_exprContext)tree);
        if(tree is Add_exprContext)                 VisitAdd_expr((Add_exprContext)tree);
        if(tree is Subtraction_exprContext)         VisitSubtraction_expr((Subtraction_exprContext)tree);
        if(tree is Multiply_exprContext)            VisitMultiply_expr((Multiply_exprContext)tree);
        if(tree is Divide_exprContext)              VisitDivide_expr((Divide_exprContext)tree);
        if(tree is Land_exprContext)                VisitLand_expr((Land_exprContext)tree);
        if(tree is Lor_exprContext)                 VisitLor_expr((Lor_exprContext)tree);
        if(tree is Lnot_exprContext)                VisitLnot_expr((Lnot_exprContext) tree);
        if(tree is Comparison_exprContext)          VisitComparison_expr((Comparison_exprContext)tree);
        if(tree is Equality_exprContext)            VisitEquality_expr((Equality_exprContext)tree);
        if(tree is Parenthesis_exprContext)         VisitParenthesis_expr((Parenthesis_exprContext)tree);
        if(tree is Minus_exprContext)               VisitMinus_expr((Minus_exprContext)tree);
        if(tree is Fun_call_exprContext)            VisitFun_call_expr((Fun_call_exprContext)tree);
        if (tree is Boolean_literal_exprContext) return VisitBoolean_literal_expr((Boolean_literal_exprContext) tree);

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
        Visit(context.inititalization().expression());
        return null;
    }

    public override object VisitFunctionDecl([NotNull] FunctionDeclContext context)
    {
        this.defined_functions.Add(context.ID().GetText());
        foreach(var parameter in context.paramList().parameter())
        {
            try {
                this.func_or_op_defined_lvar[context.ID().GetText()].Add(parameter.ID().GetText());
            }
            catch(KeyNotFoundException)
            {
                this.func_or_op_defined_lvar[context.ID().GetText()] = new List<string>();
                this.func_or_op_defined_lvar[context.ID().GetText()].Add(parameter.ID().GetText());

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
                this.func_or_op_defined_lvar[context.ID().GetText()].Add(parameter.ID().GetText());
            }
            catch(KeyNotFoundException)
            {
                this.func_or_op_defined_lvar[context.ID().GetText()] = new List<string>();
                this.func_or_op_defined_lvar[context.ID().GetText()].Add(parameter.ID().GetText());

            }
        }
        foreach(var statement in context.statementList().statement())
        {
            Visit(statement);
        }
        
        return null;
    }

    public override object VisitCommandStat([NotNull] CommandStatContext context)
    {
        Visit(context.command().expression());
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
            this.func_or_op_defined_lvar[((FunctionDeclContext) container_fun_or_op).ID().GetText()].Add(context.varDecl().ID().GetText());
        }
        else if(container_fun_or_op is OperationDeclContext) 
        {
            this.func_or_op_defined_lvar[((OperationDeclContext) container_fun_or_op).ID().GetText()].Add(context.varDecl().ID().GetText());
        }
        Visit(context.varDecl().inititalization().expression());
        return null;
    }

    public override object VisitAssignment_Stat([NotNull] Assignment_StatContext context)
    {
        var container_fun_or_op = context.Parent;
        var id = context.assignmentStat().ID().GetText();

        while(container_fun_or_op != null && 
            (container_fun_or_op is FunctionDeclContext || container_fun_or_op is OperationDeclContext)
        )
        {
            container_fun_or_op = container_fun_or_op.Parent;
        }
        
        if(container_fun_or_op is FunctionDeclContext)
        {
            if(!func_or_op_defined_lvar[((FunctionDeclContext) container_fun_or_op).ID().GetText()]
            .Contains(id)) {
                throw new Exception($"lhs is not defined already. Ln: {context.Start.Line}");
            }
        }
        else if(container_fun_or_op is OperationDeclContext){
            if(!func_or_op_defined_lvar[((OperationDeclContext) container_fun_or_op).ID().GetText()]
            .Contains(id)) {
                throw new Exception($"lhs is not defined already. Ln: {context.Start.Line}");
            }
        }
        Visit(context.assignmentStat().expression());
        return null;
    }

    public override object VisitIf_Stat([NotNull] If_StatContext context){
        Visit(context.ifStat().expression());

        foreach(var statement in context.ifStat().statementList().statement())
        {
            Visit(statement);
        }
        return null;
    }
    public override object VisitWhile_Stat([NotNull] While_StatContext context){
        Visit(context.whileStat().expression());

        foreach(var statement in context.whileStat().statementList().statement())
        {
            Visit(statement);
        }
        return null;
    }
    
    public override object VisitResult_Stat([NotNull] Result_StatContext context)
    {
        Visit(context.resultStat().expression());
        return null;
    }

    public override object VisitCommand_Stat([NotNull] Command_StatContext context)
    {
        Visit(context.commandStat().command().expression());
        return null;
    }

    public override object VisitOperation_Stat([NotNull] Operation_StatContext context)
    {
        string operation_name = context.operationStat().ID().GetText();

        var container_func_or_op = context.Parent;

        while(container_func_or_op != null && (container_func_or_op is not FunctionDeclContext || container_func_or_op is not OperationDeclContext))
        {
            container_func_or_op = container_func_or_op.Parent;
        }

        if(container_func_or_op is FunctionDeclContext)
        {
            if(!func_or_op_defined_lvar[((FunctionDeclContext) container_func_or_op).ID().GetText()]
            .Contains(operation_name)) {
                throw new Exception($"this op is not defined already. Ln: {context.Start.Line}");
            }
        }
        else if(container_func_or_op is OperationDeclContext){
            if(!func_or_op_defined_lvar[((OperationDeclContext) container_func_or_op).ID().GetText()]
            .Contains(operation_name)) {
                throw new Exception($"this op not defined already. Ln: {context.Start.Line}");
            }
        }

        foreach(var argument in context.operationStat().argumentList().argument())
        {
            Visit(argument);
        }


        return null;
    }

    public override object VisitAdd_expr([NotNull] Add_exprContext context)
    {
        Visit(context.expression(0));
        Visit(context.expression(1));
        return null;
    }

    public override object VisitSubtraction_expr([NotNull] Subtraction_exprContext context)
    {
        Visit(context.expression(0));
        Visit(context.expression(1));
        return null;
    }

    public override object VisitMultiply_expr([NotNull] Multiply_exprContext context)
    {
        Visit(context.expression(0));
        Visit(context.expression(1));
        return null;
    }

    public override object VisitDivide_expr([NotNull] Divide_exprContext context)
    {
        Visit(context.expression(0));
        Visit(context.expression(1));
        return null;
    }
    public override object VisitComparison_expr([NotNull] Comparison_exprContext context)
    {
        Visit(context.expression(0));
        Visit(context.expression(1));
        return null;
    }
    public override object VisitEquality_expr([NotNull] Equality_exprContext context)
    {
        Visit(context.expression(0));
        Visit(context.expression(1));
        return null;
    }

    public override object VisitLand_expr([NotNull] Land_exprContext context)
    {
        Visit(context.expression(0));
        Visit(context.expression(1));
        return null;
    }

    public override object VisitLor_expr([NotNull] Lor_exprContext context)
    {
        Visit(context.expression(0));
        Visit(context.expression(1));
        return null;
    }
    public override object VisitLnot_expr([NotNull] Lnot_exprContext context)
    {
        Visit(context.expression());
        return null;
    }

    public override object VisitMinus_expr([NotNull] Minus_exprContext context)
    {
        Visit(context.expression());
        return null;
    }
    public override object VisitParenthesis_expr([NotNull] Parenthesis_exprContext context)
    {
        Visit(context.expression());
        return null;
    }
    public override object VisitFun_call_expr([NotNull] Fun_call_exprContext context)
    {
        string function_name = context.ID().GetText();

        if(!defined_functions.Contains(function_name))
        {
            throw new Exception("This function is not already defined");
        }
        foreach(var argument in context.argumentList().argument())
        {
            Visit(argument.expression());
        }
        return null;
    }

    public override object VisitVariable_expr([NotNull] Variable_exprContext context)
    {
        var container_function_or_operation = context.Parent;
        while(container_function_or_operation != null && (container_function_or_operation is not FunctionDeclContext || container_function_or_operation is not OperationDeclContext) )
        {
            container_function_or_operation = container_function_or_operation.Parent;
        }
        
        if(container_function_or_operation is FunctionDeclContext)
        {
            var containing_function = (FunctionDeclContext) container_function_or_operation;
            var containing_function_name = containing_function.ID().GetText();
            if(!this.func_or_op_defined_lvar[containing_function_name].Contains(context.ID().GetText()))
            {
                if(!this.defined_gvars.Contains(context.ID().GetText())) {
                    throw new Exception($"Undefined variable {context.ID().GetText()}, Ln:{context.Start.Line}");
                }
            }
        }

        if(container_function_or_operation is OperationDeclContext)
        {
            var containing_operation = (OperationDeclContext) container_function_or_operation;
            var containing_operation_name = containing_operation.ID().GetText();
            if(!this.func_or_op_defined_lvar[containing_operation_name].Contains(context.ID().GetText()))
            {
                if(!this.defined_gvars.Contains(context.ID().GetText())) {
                    throw new Exception($"Undefined variable {context.ID().GetText()}, Ln:{context.Start.Line}");
                }
            }
        }

        
        return null;
    }
}