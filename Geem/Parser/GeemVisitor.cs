//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.9.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from /home/mahmoud/Documents/GeemProgrammingLanguage/Geem/Parser/Geem.g4 by ANTLR 4.9.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace Geem.Parser {

 using Geem.Infrastructure;	

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="GeemParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.9.2")]
[System.CLSCompliant(false)]
public interface IGeemVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="GeemParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitProgram([NotNull] GeemParser.ProgramContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GeemParser.globalVarDecl"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitGlobalVarDecl([NotNull] GeemParser.GlobalVarDeclContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GeemParser.inititalization"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInititalization([NotNull] GeemParser.InititalizationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GeemParser.functionDecl"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionDecl([NotNull] GeemParser.FunctionDeclContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GeemParser.operationDecl"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOperationDecl([NotNull] GeemParser.OperationDeclContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GeemParser.parameter"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParameter([NotNull] GeemParser.ParameterContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GeemParser.paramList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParamList([NotNull] GeemParser.ParamListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GeemParser.argument"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArgument([NotNull] GeemParser.ArgumentContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GeemParser.argumentList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArgumentList([NotNull] GeemParser.ArgumentListContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>lor_expr</c>
	/// labeled alternative in <see cref="GeemParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLor_expr([NotNull] GeemParser.Lor_exprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>add_expr</c>
	/// labeled alternative in <see cref="GeemParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAdd_expr([NotNull] GeemParser.Add_exprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>land_expr</c>
	/// labeled alternative in <see cref="GeemParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLand_expr([NotNull] GeemParser.Land_exprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>boolean_literal_expr</c>
	/// labeled alternative in <see cref="GeemParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBoolean_literal_expr([NotNull] GeemParser.Boolean_literal_exprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>comparison_expr</c>
	/// labeled alternative in <see cref="GeemParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitComparison_expr([NotNull] GeemParser.Comparison_exprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>multiply_expr</c>
	/// labeled alternative in <see cref="GeemParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMultiply_expr([NotNull] GeemParser.Multiply_exprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>variable_expr</c>
	/// labeled alternative in <see cref="GeemParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVariable_expr([NotNull] GeemParser.Variable_exprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>parenthesis_expr</c>
	/// labeled alternative in <see cref="GeemParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParenthesis_expr([NotNull] GeemParser.Parenthesis_exprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>int_literal_expr</c>
	/// labeled alternative in <see cref="GeemParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInt_literal_expr([NotNull] GeemParser.Int_literal_exprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>subtraction_expr</c>
	/// labeled alternative in <see cref="GeemParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSubtraction_expr([NotNull] GeemParser.Subtraction_exprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>divide_expr</c>
	/// labeled alternative in <see cref="GeemParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDivide_expr([NotNull] GeemParser.Divide_exprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>fun_call_expr</c>
	/// labeled alternative in <see cref="GeemParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFun_call_expr([NotNull] GeemParser.Fun_call_exprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>minus_expr</c>
	/// labeled alternative in <see cref="GeemParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMinus_expr([NotNull] GeemParser.Minus_exprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>lnot_expr</c>
	/// labeled alternative in <see cref="GeemParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLnot_expr([NotNull] GeemParser.Lnot_exprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GeemParser.boolean_literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBoolean_literal([NotNull] GeemParser.Boolean_literalContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GeemParser.comparison_op"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitComparison_op([NotNull] GeemParser.Comparison_opContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>assignment_Stat</c>
	/// labeled alternative in <see cref="GeemParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssignment_Stat([NotNull] GeemParser.Assignment_StatContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>return_Stat</c>
	/// labeled alternative in <see cref="GeemParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitReturn_Stat([NotNull] GeemParser.Return_StatContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>result_Stat</c>
	/// labeled alternative in <see cref="GeemParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitResult_Stat([NotNull] GeemParser.Result_StatContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>break_Stat</c>
	/// labeled alternative in <see cref="GeemParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBreak_Stat([NotNull] GeemParser.Break_StatContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>continue_Stat</c>
	/// labeled alternative in <see cref="GeemParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitContinue_Stat([NotNull] GeemParser.Continue_StatContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>if_Stat</c>
	/// labeled alternative in <see cref="GeemParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIf_Stat([NotNull] GeemParser.If_StatContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>while_Stat</c>
	/// labeled alternative in <see cref="GeemParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWhile_Stat([NotNull] GeemParser.While_StatContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>var_Decl_Stat</c>
	/// labeled alternative in <see cref="GeemParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVar_Decl_Stat([NotNull] GeemParser.Var_Decl_StatContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>operation_Stat</c>
	/// labeled alternative in <see cref="GeemParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOperation_Stat([NotNull] GeemParser.Operation_StatContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>command_Stat</c>
	/// labeled alternative in <see cref="GeemParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCommand_Stat([NotNull] GeemParser.Command_StatContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GeemParser.statementList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStatementList([NotNull] GeemParser.StatementListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GeemParser.operationStat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOperationStat([NotNull] GeemParser.OperationStatContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GeemParser.assignmentStat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssignmentStat([NotNull] GeemParser.AssignmentStatContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GeemParser.ifStat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIfStat([NotNull] GeemParser.IfStatContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GeemParser.whileStat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWhileStat([NotNull] GeemParser.WhileStatContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GeemParser.returnStat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitReturnStat([NotNull] GeemParser.ReturnStatContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GeemParser.resultStat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitResultStat([NotNull] GeemParser.ResultStatContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GeemParser.breakStat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBreakStat([NotNull] GeemParser.BreakStatContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GeemParser.continueStat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitContinueStat([NotNull] GeemParser.ContinueStatContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GeemParser.varDecl"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVarDecl([NotNull] GeemParser.VarDeclContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GeemParser.commandStat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCommandStat([NotNull] GeemParser.CommandStatContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GeemParser.command"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCommand([NotNull] GeemParser.CommandContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GeemParser.datatype"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDatatype([NotNull] GeemParser.DatatypeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GeemParser.int_literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInt_literal([NotNull] GeemParser.Int_literalContext context);
}
} // namespace Geem.Parser
