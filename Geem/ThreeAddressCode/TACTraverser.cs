// namespace Geem.ThreeAddressCode;
// using static Geem.Parser.GeemParser;
// using Antlr4.Runtime.Tree;
// using System.Text;
// public class OperationData
// {
//     public Dictionary<string, int> parameters_data;
//     public Dictionary<string, int> variables_data;

//     public OperationData()
//     {
//         this.parameters_data = new Dictionary<string, int>();
//         this.variables_data = new Dictionary<string, int>();
//     }
// }

// public class FunctionData
// {
//     public Dictionary<string, int> parameters_data;
//     public Dictionary<string, int> variables_data;
//     public FunctionData()
//     {
//         this.parameters_data = new Dictionary<string, int>();
//         this.variables_data = new Dictionary<string, int>();
//     }
// }
// public class TACTraverse
// {
//     public static Dictionary<string, OperationData> operations_data = new Dictionary<string, OperationData>();

//     public static Dictionary<string, FunctionData> functions_data = new Dictionary<string, FunctionData>();

//     public static Dictionary<string, Tuple<int, int>> labels = new Dictionary<string, Tuple<int, int>>();

//     public int last_used_temp = -1;
//     public static int instruction_segment_size = 0;
//     public static int next_inst_index = 0;
//     public static List<Instruction> instructions = new List<Instruction>();

//     public void Traverse(IParseTree node)
//     {
//         if (node is ProgramContext)
//         {
//             var programContext = (ProgramContext)node;

//             foreach (var sub_node in programContext.children)
//             {
//                 Traverse(sub_node);
//             }
//         }
//         else if (node is OperationDeclContext)
//         {
//             var operationDecl = (OperationDeclContext)node;
//             labels[operationDecl.ID().GetText()] = new Tuple<int, int>(next_inst_index, -1);
//             operations_data[operationDecl.ID().GetText()] = new OperationData();
//             // reserve space on the stack for 
//             // 1. last frame pointer.
//             // 2. parameters of the operation.
//             // 3. variables of the operations.
//             var parameters = operationDecl.paramList().parameter();
//             var variables_decl = operationDecl.statementList().statement().OfType<Var_Decl_StatContext>();

//             // calculating the required stack frame size.
//             int frame_size = 1 + parameters.Count() + variables_decl.Count();


//             // reserving space for the stack frame.

//             instructions.Add(
//                 new AddI(
//                     new Register(RegisterType.STACK_POINTER, 0),
//                     new Register(RegisterType.STACK_POINTER, 0),
//                         frame_size
//                     )
//             );

//             // storing the last frame pointer.
//             instructions.Add(
//                 new Store(
//                     new Register(RegisterType.FRAME_POINTER, 0),
//                     new Register(RegisterType.STACK_POINTER, 0),
//                     -1 * frame_size
//                 )
//             );
//             // setting the new frame pointer.
//             instructions.Add(
//                 new AddI(
//                     new Register(RegisterType.STACK_POINTER, 0),
//                     new Register(RegisterType.FRAME_POINTER, 0),
//                     -1 * frame_size
//                 )
//             );
//             instruction_segment_size += 3;
//             int index = 1;
//             foreach (var parameter in parameters)
//             {
//                 // set the index of the parameter in the operation data structure.
//                 operations_data[operationDecl.ID().GetText()].parameters_data[parameter.ID().GetText()] = index++;

//             }

//             foreach (var variable_decl in variables_decl)
//             {
//                 // set the index of the variable in the operation data structure.
//                 operations_data[operationDecl.ID().GetText()].variables_data[variable_decl.varDecl().ID().GetText()] = index++;

//                 // initialize the variables on the stack.
//                 initialze_variables_on_the_stack(variable_decl, index - 1);
//             }

//             foreach (var statement in operationDecl.statementList().statement())
//             {
//                 if (statement is not Var_Decl_StatContext)
//                 {
//                     Traverse(statement);
//                 }
//             }
//             // resetting the frame pointer to the old one.
//             instructions.Add(
//                 new Load(
//                     new Register(RegisterType.FRAME_POINTER, 0),
//                     new Register(RegisterType.STACK_POINTER, 0),
//                     -1 * frame_size
//                 )
//             );

//             // deleting the stack frame.
//             instructions.Add(
//                 new AddI(
//                     new Register(RegisterType.STACK_POINTER, 0),
//                     new Register(RegisterType.STACK_POINTER, 0),
//                     -1 * frame_size
//                 )
//             );

//             instructions.Add(
//                 new Return()
//             );

//             instruction_segment_size += 3;


//             next_inst_index += instruction_segment_size;
//             instruction_segment_size = 0;
//             // the end address of the operation.
//             labels[operationDecl.ID().GetText()] = new Tuple<int, int>(labels[operationDecl.ID().GetText()].Item1, next_inst_index);

//         }
//         else if (node is FunctionDeclContext)
//         {

//             var functionDecl = (FunctionDeclContext)node;
//             labels[functionDecl.ID().GetText()] = new Tuple<int, int>(next_inst_index, -1);
//             functions_data[functionDecl.ID().GetText()] = new FunctionData();
//             // reserve space on the stack for 
//             // 1. last frame pointer.
//             // 2. parameters of the operation.
//             // 3. variables of the operations.
//             var parameters = functionDecl.paramList().parameter();
//             var variables_decl = functionDecl.statementList().statement().OfType<Var_Decl_StatContext>();

//             // calculating the required stack frame size.
//             int frame_size = 1 + parameters.Count() + variables_decl.Count();


//             // reserving space for the stack frame.

//             instructions.Add(
//                 new AddI(
//                     new Register(RegisterType.STACK_POINTER, 0),
//                     new Register(RegisterType.STACK_POINTER, 0),
//                         frame_size
//                     )
//             );

//             // storing the last frame pointer.
//             instructions.Add(
//                 new Store(
//                     new Register(RegisterType.FRAME_POINTER, 0),
//                     new Register(RegisterType.STACK_POINTER, 0),
//                     -1 * frame_size
//                 )
//             );
//             // setting the new frame pointer.
//             instructions.Add(
//                 new AddI(
//                     new Register(RegisterType.STACK_POINTER, 0),
//                     new Register(RegisterType.FRAME_POINTER, 0),
//                     -1 * frame_size
//                 )
//             );
//             instruction_segment_size += 3;

//             int index = 1;
//             foreach (var parameter in parameters)
//             {
//                 // set the index of the parameter in the operation data structure.
//                 functions_data[functionDecl.ID().GetText()].parameters_data[parameter.ID().GetText()] = index++;
//             }

//             foreach (var variable_decl in variables_decl)
//             {
//                 // set the index of the variable in the operation data structure.
//                 functions_data[functionDecl.ID().GetText()].variables_data[variable_decl.varDecl().ID().GetText()] = index++;

//                 // initializing the variables on the stack.
//                 initialze_variables_on_the_stack(variable_decl, index - 1);

//             }

//             foreach (var statement in functionDecl.statementList().statement())
//             {
//                 if (statement is not Var_Decl_StatContext)
//                 {
//                     Traverse(statement);
//                 }
//             }
//             // resetting the frame pointer to the old one.
//             instructions.Add(
//                 new Load(
//                     new Register(RegisterType.FRAME_POINTER, 0),
//                     new Register(RegisterType.STACK_POINTER, 0),
//                     -1 * frame_size
//                 )
//             );

//             // deleting the stack frame.
//             instructions.Add(
//                 new AddI(
//                     new Register(RegisterType.STACK_POINTER, 0),
//                     new Register(RegisterType.STACK_POINTER, 0),
//                     -1 * frame_size
//                 )
//             );

//             instructions.Add(new Return());

//             instruction_segment_size += 3;

//             next_inst_index += instruction_segment_size;
//             instruction_segment_size = 0;
//             // setting the end address of the function.
//             labels[functionDecl.ID().GetText()] = new Tuple<int, int>(labels[functionDecl.ID().GetText()].Item1, next_inst_index);


//         }
//         else if (node is Assignment_StatContext)
//         {
//             var assign_stat = ((Assignment_StatContext)node).assignmentStat();

//             var lhs = assign_stat.ID().GetText();
//             var parent_scope = get_parent_operation_or_function(node);
//             if (parent_scope is FunctionDeclContext)
//             {
//                 var func_scope = (FunctionDeclContext)parent_scope;

//                 var function_name = func_scope.ID().GetText();

//                 var function_data = functions_data[function_name];
//                 int lhs_index = -1;
//                 if (function_data.parameters_data.ContainsKey(lhs))
//                 {
//                     lhs_index = function_data.parameters_data[lhs];
//                 }
//                 else if (function_data.variables_data.ContainsKey(lhs))
//                 {
//                     lhs_index = function_data.variables_data[lhs];
//                 }
//                 else
//                 {
//                     throw new Exception();
//                 }



//                 Traverse(assign_stat.expression());

//                 instructions.Add(
//                     new Store(
//                         new Register(RegisterType.TEMP_REG, last_used_temp), 
//                         new Register(RegisterType.FRAME_POINTER, 0),
//                         lhs_index)
//             );
//             }
//             else if (parent_scope is OperationDeclContext)
//             {
//                 var opera_scope = (OperationDeclContext)parent_scope;


//                 var operation_name = opera_scope.ID().GetText();

//                 var operation_data = operations_data[operation_name];
//                 int lhs_index = -1;
//                 if (operation_data.parameters_data.ContainsKey(lhs))
//                 {
//                     lhs_index = operation_data.parameters_data[lhs];
//                 }
//                 else if (operation_data.variables_data.ContainsKey(lhs))
//                 {
//                     lhs_index = operation_data.variables_data[lhs];
//                 }
//                 else
//                 {
//                     throw new Exception();
//                 }

//                 Traverse(assign_stat.expression());

//                 instructions.Add(
//                     new Store(
//                         new Register(RegisterType.TEMP_REG, last_used_temp), 
//                         new Register(RegisterType.FRAME_POINTER, 0), 
//                         lhs_index)
//                 );
//                 instruction_segment_size += 1;
//             }
//             else
//             {
//                 throw new Exception();
//             }


//         }
//         else if (node is Int_literal_exprContext)
//         {
//             var Int_literal = (Int_literal_exprContext)node;

//             var int_literal = ((Int_literal_exprContext)node).Int_literal().GetText();
//             // var arbic_int_literal = int_literal.GetText().Substring(0, int_literal.GetText().Length -2 );

//             Int32 int_value = Int32.Parse(convert_arabic_to_english_literal(int_literal));

//             instructions.Add(
//                 new AddI(
//                     new Register(RegisterType.ZERO, 0), 
//                     new Register(RegisterType.TEMP_REG, ++last_used_temp), 
//                     int_value)
//             );
//             instruction_segment_size += 1;
//         }
//         else if (node is Add_exprContext)
//         {
//             var add_expr = (Add_exprContext)node;

//             var expr1 = add_expr.expression(0);
//             var expr2 = add_expr.expression(1);

//             Traverse(expr1);
//             Traverse(expr2);

//             instructions.Add(
//                 new Add(
//                     new Register(RegisterType.TEMP_REG, last_used_temp),
//                     new Register(RegisterType.TEMP_REG, last_used_temp - 1),
//                     new Register(RegisterType.TEMP_REG, ++last_used_temp)
//                 )
//             );
//             instruction_segment_size += 1;
//         }
//         else if (node is Subtraction_exprContext)
//         {
//             var sub_expr = (Subtraction_exprContext) node;

//             var expr1 = sub_expr.expression(0);
//             var expr2 = sub_expr.expression(1);

//             Traverse(expr1);
//             Traverse(expr2);

//             instructions.Add(
//                 new Subtract(
//                     new Register(RegisterType.TEMP_REG, last_used_temp - 1),
//                     new Register(RegisterType.TEMP_REG, last_used_temp),
//                     new Register(RegisterType.TEMP_REG, ++last_used_temp)
//                 )
//             );
//             instruction_segment_size += 1;

//         }
//         else if (node is Multiply_exprContext)
//         {
//             var multiply_expr = (Multiply_exprContext) node;

//             var expr1 = multiply_expr.expression(0);
//             var expr2 = multiply_expr.expression(1);

//             Traverse(expr1);
//             Traverse(expr2);

//             instructions.Add(
//                 new Multiply(
//                     new Register(RegisterType.TEMP_REG, last_used_temp - 1),
//                     new Register(RegisterType.TEMP_REG, last_used_temp),
//                     new Register(RegisterType.TEMP_REG, ++last_used_temp)
//                 )
//             );
//         }
//         else if (node is Divide_exprContext)
//         {
//             var divide_expr = (Divide_exprContext) node;

//             var expr1 = divide_expr.expression(0);
//             var expr2 = divide_expr.expression(1);

//             Traverse(expr1);
//             Traverse(expr2);

//             instructions.Add(
//                 new Divide(
//                     new Register(RegisterType.TEMP_REG, last_used_temp - 1),
//                     new Register(RegisterType.TEMP_REG, last_used_temp),
//                     new Register(RegisterType.TEMP_REG, ++last_used_temp) 
//                 )
//             );

//             instruction_segment_size += 1;
//         }
//         else if (node is Parenthesis_exprContext) 
//         {
//             var expression = ((Parenthesis_exprContext) node).expression();
//             Traverse(expression);
//         }
//         else if (node is Minus_exprContext) 
//         {
//             var expression = ((Minus_exprContext) node).expression();

//             Traverse(expression);

//             instructions.Add(
//                 new AddI(
//                     new Register(RegisterType.ZERO, 0), 
//                     new Register(RegisterType.TEMP_REG, ++last_used_temp),
//                     -1
//                 )
//             );

//             instructions.Add(
//                 new Multiply(
//                     new Register(RegisterType.TEMP_REG, last_used_temp),
//                     new Register(RegisterType.TEMP_REG, last_used_temp - 1 ),
//                     new Register(RegisterType.TEMP_REG, ++last_used_temp)
//                 )
//             );

//             instruction_segment_size += 2;
//         }
//         else if (node is Variable_exprContext)
//         {
//             var variable_expr = (Variable_exprContext) node;

//             var varible_identifier = variable_expr.ID().GetText();

//             var parent_scope = get_parent_operation_or_function(variable_expr);

//             if(parent_scope is FunctionDeclContext)
//             {
//                 var function_scope = (FunctionDeclContext) parent_scope;
                
//             }
//             else if(parent_scope is OperationDeclContext)
//             {

//             }
//         }
//     }

//     private void initialze_variables_on_the_stack(IParseTree var_decl_stat, int index)
//     {
//         var varDeclStat = (Var_Decl_StatContext)var_decl_stat;

//         var initialization_expression = varDeclStat.varDecl().inititalization().expression();

//         if (initialization_expression is Int_literal_exprContext)
//         {
//             var int_literal = ((Int_literal_exprContext)initialization_expression).Int_literal().GetText();
//             // var arbic_int_literal = int_literal.GetText().Substring(0, int_literal.GetText().Length -2 );

//             Int64 int_value = Int64.Parse(convert_arabic_to_english_literal(int_literal));
//             instructions.Add(new AddI(new Register(RegisterType.ZERO, 0), new Register(RegisterType.TEMP_REG, ++last_used_temp), (int)int_value));
//             instructions.Add(new Store(new Register(RegisterType.TEMP_REG, last_used_temp), new Register(RegisterType.FRAME_POINTER, 0), index));

//             instruction_segment_size += 2;
//         }
//     }
//     public static string convert_arabic_to_english_literal(string input)
//     {
//         StringBuilder result = new StringBuilder();
//         for (int index = input.Length - 1; index >= 0; index--)
//         {
//             if (input[index] == '٠')
//             {
//                 result.Append('0');
//             }
//             else if (input[index] == '١')
//             {
//                 result.Append('1');
//             }
//             else if (input[index] == '٢')
//             {
//                 result.Append('2');

//             }
//             else if (input[index] == '٣')
//             {
//                 result.Append('3');

//             }
//             else if (input[index] == '٤')
//             {
//                 result.Append('4');

//             }
//             else if (input[index] == '٥')
//             {
//                 result.Append('5');

//             }
//             else if (input[index] == '٦')
//             {
//                 result.Append('6');

//             }
//             else if (input[index] == '٧')
//             {
//                 result.Append('7');

//             }
//             else if (input[index] == '٨')
//             {
//                 result.Append('8');

//             }
//             else if (input[index] == '٩')
//             {
//                 result.Append('9');

//             }
//             else
//             {
//                 throw new Exception();
//             }


//         }
//         return result.ToString();
//     }


//     public IParseTree get_parent_operation_or_function(
//         IParseTree node
//     )
//     {
//         if (node == null)
//         {
//             throw new ArgumentNullException();
//         }
//         IParseTree parent = node.Parent;
//         while (parent is not FunctionDeclContext && parent is not OperationDeclContext)
//         {
//             if (parent != null)
//             {
//                 parent = parent.Parent;
//             }
//             else
//             {
//                 throw new ArgumentNullException();
//             }
//         }
//         return parent;
//     }
// }