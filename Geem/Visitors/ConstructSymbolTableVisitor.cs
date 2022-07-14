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
        context.st = new SymbolTable(null, SymbolTableType.SymbolTableOfFile, "program");


        foreach (var operation_declaration in context.operationDecl())
        {
            string operationName = operation_declaration.ID().GetText();
            List<string> operation_parameter_datatypes = new List<string>();
            foreach (var parameter in operation_declaration.paramList().parameter())
            {
                operation_parameter_datatypes.Add(parameter.datatype().GetText());
            }
            context.st.addSymbol(operationName, new OperationInfo(operation_parameter_datatypes.ToArray(), operation_declaration));
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
            context.st.addSymbol(function_name, new FunctionInfo(return_type, function_parameter_datatypes.ToArray(), function_declaration));
        }

        foreach (var global_variable_declartion in context.globalVarDecl())
        {
            string variable_datatype = global_variable_declartion.datatype().GetText();
            string variable_name = global_variable_declartion.ID().GetText();
            var expr = global_variable_declartion.inititalization().expression();
            if (expr is not Int_literal_exprContext && expr is not Boolean_literal_exprContext)
            {
                throw new Exception($"global variable must be initialized with int literals or boolean literals, Ln:{global_variable_declartion.Start.Line}");
            }
            context.st.addSymbol(variable_name, new VarInfo(variable_datatype, SymbolType.SymbolOfGlobalVariable));
        }
        foreach (var function_decl in context.functionDecl())
        {
            Visit(function_decl);
        }

        foreach (var opeartion_declaration in context.operationDecl())
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
            context.st.addSymbol(parameter.ID().GetText(), new VarInfo(parameter.datatype().GetText(), SymbolType.SymbolOfParameter));
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
            context.st.addSymbol(parameter.ID().GetText(), new VarInfo(parameter.datatype().GetText(), SymbolType.SymbolOfParameter));
        }

        foreach (var statement in context.statementList().statement())
        {
            statement.st = context.st;
            Visit(statement);
        }

        return null;
    }

    public override object VisitVar_Decl_Stat([NotNull] GeemParser.Var_Decl_StatContext context)
    {
        string variable_name = context.varDecl().ID().GetText();
        string variable_datatype = context.varDecl().datatype().GetText();

        context.st.addSymbol(variable_name, new VarInfo(variable_datatype, SymbolType.SymbolOfLocalVariable));

        context.varDecl().inititalization().expression().st = context.st;
        Visit(context.varDecl().inititalization().expression());
        return null;
    }

    public override object VisitIf_Stat([NotNull] GeemParser.If_StatContext context)
    {
        foreach (var statement in context.ifStat().statementList().statement())
        {
            if (statement is Var_Decl_StatContext)
            {
                throw new Exception($"If blocks can not contain vairable declarations for now, Ln:{statement.Start.Line}.");
            }
            statement.st = context.st;
            Visit(statement);
        }

        context.ifStat().expression().st = context.st;
        Visit(context.ifStat().expression());
        return null;
    }

    public override object VisitWhile_Stat([NotNull] GeemParser.While_StatContext context)
    {
        foreach (var statement in context.whileStat().statementList().statement())
        {
            if (statement is Var_Decl_StatContext)
            {
                throw new Exception($"While blocks can not contain vairable declarations for now, Ln:{statement.Start.Line}.");
            }
            statement.st = context.st;
            Visit(statement);
        }

        context.whileStat().expression().st = context.st;
        Visit(context.whileStat().expression());
        return null;
    }

    public override object VisitResult_Stat([NotNull] GeemParser.Result_StatContext context)
    {
        var container = context.Parent;

        while (container is not null && container is not FunctionDeclContext)
        {
            container = container.Parent;
        }

        if (container is not FunctionDeclContext)
        {
            throw new Exception($"Result statements should happen only inside functions.\nLn: {context.Start.Line}.");
        }

        context.resultStat().expression().st = context.st;
        Visit(context.resultStat().expression());
        return null;
    }
    public override object VisitReturn_Stat([NotNull] Return_StatContext context)
    {
        var container = context.Parent;

        while (container is not null && container is not OperationDeclContext)
        {
            container = container.Parent;
        }

        if (container is not OperationDeclContext)
        {
            throw new Exception($"Result statements should happen only inside operations.\nLn: {context.Start.Line}.");
        }
        return null;
    }
    public override object VisitOperation_Stat([NotNull] GeemParser.Operation_StatContext context)
    {
        string operation_name = context.operationStat().ID().GetText();
        if (!context.st.SymbolExistInParent(operation_name))
        {
            throw new Exception($"Undefined operation \"{operation_name}\", Ln: {context.Start.Line}");
        }
        foreach (var argument in context.operationStat().argumentList().argument())
        {
            argument.st = context.st;
            argument.expression().st = context.st;
            Visit(argument.expression());
        }
        return null;
    }

    public override object VisitAssignment_Stat([NotNull] GeemParser.Assignment_StatContext context)
    {
        string id = context.assignmentStat().ID().GetText();
        if (!context.st.SymbolExist(id))
        {
            if (!context.st.SymbolExistInParent(id))
            {
                throw new Exception($"identifier does not exist in the current block, Ln: {context.Start.Line}.");
            }
        }
        context.assignmentStat().expression().st = context.st;
        Visit(context.assignmentStat().expression());
        return null;
    }
    public override object VisitBreak_Stat([NotNull] Break_StatContext context)
    {
        var container = context.Parent;

        while (container != null && container is not While_StatContext)
        {
            container = container.Parent;
        }
        if (container is not While_StatContext)
        {
            throw new Exception($"Break Statement should only happen in while block, Ln: {context.Start.Line}");
        }
        return null;
    }
    public override object VisitContinue_Stat([NotNull] Continue_StatContext context)
    {
        var container = context.Parent;

        while (container != null && container is not While_StatContext)
        {
            container = container.Parent;
        }
        if (container is not While_StatContext)
        {
            throw new Exception($"Continue Statement should only happen in while block, Ln: {context.Start.Line}");
        }
        return null;
    }
    public override object VisitCommand_Stat([NotNull] GeemParser.Command_StatContext context)
    {
        context.commandStat().command().expression().st = context.st;
        Visit(context.commandStat().command().expression());
        return null;
    }

    public override object VisitAdd_expr([NotNull] GeemParser.Add_exprContext context)
    {
        context.expression(0).st = context.st;
        Visit(context.expression(0));
        context.expression(1).st = context.st;
        Visit(context.expression(1));
        return null; ;
    }
    public override object VisitSubtraction_expr([NotNull] Subtraction_exprContext context)
    {
        context.expression(0).st = context.st;
        Visit(context.expression(0));
        context.expression(1).st = context.st;
        Visit(context.expression(1));
        return null;
    }

    public override object VisitMultiply_expr([NotNull] Multiply_exprContext context)
    {
        context.expression(0).st = context.st;
        Visit(context.expression(0));
        context.expression(1).st = context.st;
        Visit(context.expression(1));
        return null;
    }

    public override object VisitDivide_expr([NotNull] Divide_exprContext context)
    {
        context.expression(0).st = context.st;
        Visit(context.expression(0));
        context.expression(1).st = context.st;
        Visit(context.expression(1));
        return null;
    }

    public override object VisitLand_expr([NotNull] Land_exprContext context)
    {
        context.expression(0).st = context.st;
        Visit(context.expression(0));
        context.expression(1).st = context.st;
        Visit(context.expression(1));
        return null;
    }

    public override object VisitLor_expr([NotNull] Lor_exprContext context)
    {
        context.expression(0).st = context.st;
        Visit(context.expression(0));
        context.expression(1).st = context.st;
        Visit(context.expression(1));
        return null;
    }

    public override object VisitComparison_expr([NotNull] Comparison_exprContext context)
    {
        context.expression(0).st = context.st;
        Visit(context.expression(0));
        context.expression(1).st = context.st;
        Visit(context.expression(1));

        return null;
    }
    public override object VisitLnot_expr([NotNull] Lnot_exprContext context)
    {
        context.expression().st = context.st;
        Visit(context.expression());
        return null;
    }

    public override object VisitMinus_expr([NotNull] Minus_exprContext context)
    {
        context.expression().st = context.st;
        Visit(context.expression());
        return null;
    }
    public override object VisitParenthesis_expr([NotNull] Parenthesis_exprContext context)
    {
        context.expression().st = context.st;
        Visit(context.expression());
        return null;
    }
    public override object VisitFun_call_expr([NotNull] Fun_call_exprContext context)
    {
        string function_name = context.ID().GetText();
        if (!context.st.SymbolExistInParent(function_name))
        {
            throw new Exception($"Undefined function \"{function_name}\", Ln:{context.Start.Line}");
        }
        foreach (var argument in context.argumentList().argument())
        {
            argument.st = context.st;
            argument.expression().st = context.st;
            Visit(argument.expression());
        }
        return null;
    }
    public override object VisitVariable_expr([NotNull] Variable_exprContext context)
    {
        string variable_name = context.ID().GetText();
        if (!context.st.SymbolExist(variable_name))
        {
            if (!context.st.SymbolExistInParent(variable_name))
            {
                throw new Exception($"undefined identifer {variable_name}, Ln:{context.Start.Line}");
            }
        }
        return null;
    }
}