namespace Geem.Visitors;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Geem.Infrastructure;
using Geem.Parser;
using static Geem.Parser.GeemParser;

public class ConstructSymbolTableVisitor : GeemBaseVisitor<Object>
{
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
        context.st = new SymbolTable(null, SymbolTableType.SymbolTableOfFile, "program");
        
        
        foreach (var operation_declaration in context.operationDecl())
        {
            string operationName = operation_declaration.ID().GetText();
            List<string> operation_parameter_datatypes = new List<string>();
            foreach (var parameter in operation_declaration.paramList().parameter())
            {
                operation_parameter_datatypes.Add(parameter.ID().GetText());
            }
            context.st.addSymbol(operationName, new SymbolInfo(SymbolType.SymbolOfOperation, new OperationInfo(operation_parameter_datatypes.ToArray(), operation_declaration)));
        }

        foreach (var function_declaration in context.functionDecl())
        {
            string function_name = function_declaration.ID().GetText();
            string return_type = function_declaration.datatype().GetText();
            List<string> function_parameter_datatypes = new List<string>();
            foreach (var parameter in function_declaration.paramList().parameter())
            {
                function_parameter_datatypes.Add(parameter.datatype().GetText());
            }
            context.st.addSymbol(function_name, new SymbolInfo(SymbolType.SymbolOfFunction, new FunctionInfo(return_type, function_parameter_datatypes.ToArray(), function_declaration)));
        }

        foreach (var global_variable_declartion in context.globalVarDecl())
        {
            string variable_datatype = global_variable_declartion.datatype().GetText();
            string variable_name = global_variable_declartion.ID().GetText();

            context.st.addSymbol(variable_name, new SymbolInfo(SymbolType.SymbolOfGlobalVariable, new VarInfo(variable_datatype)));
        }
        foreach (var function_decl in context.functionDecl())
        {
            Visit(function_decl);
        }

        foreach(var opeartion_declaration in context.operationDecl())
        {
            Visit(opeartion_declaration);
        }
        return null;
    }
    public override object VisitFunctionDecl([NotNull] GeemParser.FunctionDeclContext context)
    {
        var function_name = context.ID().GetText();
        var return_type = context.datatype().GetText();

        context.st = new SymbolTable(((GeemParser.ProgramContext)context.Parent).st, SymbolTableType.SymbolTableOfFunction, function_name);

        foreach (var parameter in context.paramList().parameter())
        {
            parameter.st = context.st;
            Visit(parameter);

        }

        foreach (var statement in context.statementList().statement())
        {
            statement.st = context.st;
            Visit(statement);
        }

        return null;
    }

    public override object VisitOperationDecl([NotNull] GeemParser.OperationDeclContext context)
    {
        var operation_name = context.ID().GetText();

        context.st = new SymbolTable(((GeemParser.ProgramContext)context.Parent).st, SymbolTableType.SymbolTableOfFunction, operation_name);

        foreach (var parameter in context.paramList().parameter())
        {
            parameter.st = context.st;
            Visit(parameter);

        }

        foreach (var statement in context.statementList().statement())
        {
            statement.st = context.st;
            Visit(statement);
        }

        return null;
    }
    public override object VisitParameter([NotNull] GeemParser.ParameterContext context)
    {
        string parameter_datatype = context.datatype().GetText();
        string parameter_name = context.ID().GetText();
        if (context.st.SymbolExist(parameter_name)) throw new Exception($"parameter_name already used: {parameter_name}");
        if (context.st.SymbolExistInParent(parameter_name))
        {
            var info = context.st.getSymbolInfo(parameter_name);
            if (info.type == SymbolType.SymbolOfGlobalVariable)
            {
                context.st[parameter_name] = new SymbolInfo(SymbolType.SymbolOfParameter, new VarInfo(parameter_datatype));
            }
            else
            {
                throw new Exception($"parameter_name already used: {parameter_name}");
            }
        }
        else
        {
            context.st[parameter_name] = new SymbolInfo(SymbolType.SymbolOfParameter, new VarInfo(parameter_datatype));
        }
        return null;
    }

    public override object VisitVar_Decl_Stat([NotNull] GeemParser.Var_Decl_StatContext context)
    {
        string variable_name = context.varDecl().ID().GetText();
        string variable_datatype = context.varDecl().datatype().GetText();
        
        context.varDecl().inititalization().expression().st = context.st;

        if (context.st.SymbolExist(variable_name))
        {
            throw new Exception($"Identifier already used: {variable_name}");
        }
        
        if (context.st.SymbolExistInParent(variable_name))
        {
            var info = context.st.getSymbolInfo(variable_name);
            if (info.type == SymbolType.SymbolOfGlobalVariable)
            {
                context.st[variable_name] = new SymbolInfo(SymbolType.SymbolOfLocalVariable, new VarInfo(variable_datatype));
            }
            else
            {
                throw new Exception("Identifier already used: {variable_name}");
            }
        }
        else
        {
            context.st[variable_name] = new SymbolInfo(SymbolType.SymbolOfLocalVariable, new VarInfo(variable_datatype));
        }

        return null;
    }

    public override object VisitIf_Stat([NotNull] GeemParser.If_StatContext context)
    {
        foreach(var statement in context.ifStat().statementList().statement())
        {
            statement.st = context.st;
        }
        context.ifStat().expression().st = context.st;
        return null;
    }
    public override object VisitWhile_Stat([NotNull] GeemParser.While_StatContext context)
    {
        foreach(var statement in context.whileStat().statementList().statement())
        {
            statement.st = context.st;
        }
        context.whileStat().expression().st = context.st;
        return null;
    }
    public override object VisitResult_Stat([NotNull] GeemParser.Result_StatContext context)
    {
        context.resultStat().expression().st = context.st;
        return  null;
    }
    public override object VisitOperation_Stat([NotNull] GeemParser.Operation_StatContext context)
    {
        foreach(var argument in context.operationStat().argumentList().argument())
        {
            argument.st = context.st;
        }
        return null;
    }

    public override object VisitAssignment_Stat([NotNull] GeemParser.Assignment_StatContext context)
    {
        context.assignmentStat().expression().st = context.st;
        return null;
    }

    public override object VisitCommand_Stat([NotNull] GeemParser.Command_StatContext context)
    {
        context.commandStat().command().expression().st = context.st;
        return base.VisitCommand_Stat(context);
    }
}