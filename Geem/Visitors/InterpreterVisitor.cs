
// using Geem.Parser;
// using static Geem.Parser.GeemParser;
// using Geem.Infrastructure;
// using Antlr4.Runtime.Misc;

// namespace Geem.Visitors
// {
//     public enum Datatype {
//         INT8,
//         INT16,
//         INT32,
//         INT64,
//         UINT8,
//         UINT16,
//         UINT32,
//         UINT64,
        
//     }
//     public class InterpreterVisitor: GeemBaseVisitor<Object> 
//     {
//         public Stack<Object> stack;
//         public override object VisitProgram([NotNull] GeemParser.ProgramContext context)
//         {
//             this.stack = new Stack<object>();
//             var operationDecl = Array.Find(context.operationDecl(), (OperationDeclContext op) => op.ID().GetText() == "المدخل");
//             if(operationDecl is null)
//             {
//                 throw new Exception("file does not contain an entry point");
//             }else {
//                 Visit(operationDecl);
//             }
//             return null;
//         }

//         public override object VisitOperationDecl([NotNull] OperationDeclContext context)
//         {
//             string operation_name = context.ID().GetText();
//             SymbolTable operation_symbol_table = context.st ?? throw new ArgumentNullException();
//             if(operation_name == "المدخل")
//             {
//                 foreach(var statement in context.statementList().statement())
//                 {
//                     Visit(statement);
//                 }
//                 return null ;
//             }
//             else {
//                 throw new Exception();
//             }
//         }

//         public override object VisitVar_Decl_Stat([NotNull] Var_Decl_StatContext context)
//         {
//             string variable_name = context.varDecl().ID().GetText();
//             SymbolInfo symbolInfo = context.st.getSymbolInfo(variable_name);

//             var expr = context.varDecl().inititalization().expression();
//             object expr_value = Visit(expr);
//             ((VarInfo)symbolInfo.specificInfo).cvalue = expr_value;
            
//             return null;
//         }
//         public override object VisitAssignment_Stat([NotNull] Assignment_StatContext context)
//         {
//             string rhs_name = context.assignmentStat().ID().GetText();
//             object expr_value = Visit(context.assignmentStat().expression());

//             ((VarInfo)(context.st.getSymbolInfo(rhs_name).specificInfo)).cvalue = expr_value;
//             return null;
//         }
//         public override object VisitOperation_Stat([NotNull] Operation_StatContext context)
//         {
//             string operation_name = context.operationStat().ID().GetText();
//             OperationInfo operation_info = (OperationInfo) context.st.getSymbolInfo(operation_name).specificInfo;
//             List<object> arguments = new List<object>();

//             foreach(var argument in context.operationStat().argumentList().argument()){
//                 arguments.Add(Visit(argument.expression()));
//             }
            
//             Visit(operation_info.node);
//             return null;
//         }
//         private Datatype strtoDatatype(string str)
//         {
//             if(str.ToLower() == "ص_١") return Datatype.INT8;
//             else if(str.ToLower() == "ص_٢") return Datatype.INT16;
//             else if(str.ToLower() == "ص_٤") return Datatype.INT32;
//             else if(str.ToLower() == "ص_٨") return Datatype.INT64;
//             else if(str.ToLower() == "ط_١") return Datatype.UINT8;
//             else if(str.ToLower() == "ط_٢") return Datatype.UINT16;
//             else if(str.ToLower() == "ط_٤") return Datatype.UINT32;
//             else if(str.ToLower() == "ط_٨") return Datatype.UINT64;

//             throw new Exception();

            
//         }
//     }
// }