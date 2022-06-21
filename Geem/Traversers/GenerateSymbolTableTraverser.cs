namespace Geem.Traversers;

using System.Text;
using Geem.Environment;
using Antlr4.Runtime.Tree;
using static Geem.Parser.GeemParser;

public class GenerateSymbolTableTraverser
{
    private class Expression
    {
        // public static string int_expr_datatype(IParseTree int_literal_expr_context)
        // {
        //     var int_literal = ((Int_literal_exprContext)int_literal_expr_context).Int_literal().GetText();
        //     string int_size = int_literal.children[int_literal.ChildCount - 1].GetText();
        //     if (int_literal.PLUS() != null)
        //     {
        //         if (int_size == "١")
        //         {
        //             return "طبيعي_١";
        //         }
        //         else if (int_size == "٢")
        //         {
        //             return "طبيعي_٢";
        //         }
        //         else if (int_size == "٤")
        //         {
        //             return "طبيعي_٤";
        //         }
        //         else if (int_size == "٨")
        //         {
        //             return "طبيعي_٨";
        //         }
        //         else
        //         {
        //             throw new Exception("This path Should be un-reachable");
        //         }
        //     }
        //     else
        //     {
        //         if (int_size == "١")
        //         {
        //             return "صحيح_١";
        //         }
        //         else if (int_size == "٢")
        //         {
        //             return "صحيح_٢";
        //         }
        //         else if (int_size == "٤")
        //         {
        //             return "صحيح_٤";
        //         }
        //         else if (int_size == "٨")
        //         {
        //             return "صحيح_٨";
        //         }
        //         else
        //         {
        //             throw new Exception("This path Should be un-reachable");
        //         }
        //     }
        // }
        public static string get_expr_type(IParseTree expr, SymbolTable symtab)
        {
            if (expr is Int_literal_exprContext)
            {
                var int_literal_expr = (Int_literal_exprContext)expr;
                // var datatype = Expression.int_expr_datatype(int_literal_expr);
                return "صحيح";
            }
            else if (expr is Variable_exprContext)
            {
                var variable_expr = (Variable_exprContext)expr;
                string identifier = variable_expr.ID().GetText();
                if (symtab.is_identifier_reserved(identifier))
                {
                    var entry = symtab.get_symbol_by_id(identifier);

                    if (entry.symbol_type == SymbolType.LOCALVAR)
                    {
                        var variable_entry = (LocalVarSymbolTableEntry)entry;
                        var var_datatype = variable_entry.datatype;

                        return var_datatype;
                    }
                    else if (entry.symbol_type == SymbolType.GLOBALVAR)
                    {
                        var variable_entry = (GlobalVarSymbolTableEntry)entry;
                        var var_datatype = variable_entry.datatype;

                        return var_datatype;
                    }
                    else if (entry.symbol_type == SymbolType.PARAMETER)
                    {
                        var p_var_entry = (ParameterSymbolTableEntry)entry;
                        var var_datatype = p_var_entry.datatype;
                        return var_datatype;
                    }
                    else
                    {
                        throw new Exception("Symbol is not a variable!");
                    }
                }
                else
                {
                    throw new Exception("undeclared variable!");
                }
            }
            else if (expr is Add_exprContext)
            {
                var add_expr = (Add_exprContext)expr;
                var operand1_dt = get_expr_type(add_expr.expression()[0], symtab);
                var operand2_dt = get_expr_type(add_expr.expression()[1], symtab);
                if (operand1_dt != operand2_dt) throw new Exception($"Cannot add two expressions of different types. {operand1_dt} and {operand2_dt}");
                return operand1_dt;
            }
            else if (expr is Subtraction_exprContext)
            {
                var subtraction_expr = (Subtraction_exprContext)expr;
                var operand1_dt = get_expr_type(subtraction_expr.expression()[0], symtab);
                var operand2_dt = get_expr_type(subtraction_expr.expression()[1], symtab);
                if (operand1_dt != operand2_dt) throw new Exception($"Cannot subtract two expressions of different types. {operand1_dt} and {operand2_dt}");

                return operand1_dt;
            }
            else if (expr is Multiply_exprContext)
            {
                var multiply_expr = (Multiply_exprContext)expr;
                var operand1_dt = get_expr_type(multiply_expr.expression()[0], symtab);
                var operand2_dt = get_expr_type(multiply_expr.expression()[1], symtab);
                if (operand1_dt != operand2_dt) throw new Exception($"Cannot multiply two expressions of different types. {operand1_dt} and {operand2_dt}");

                return operand1_dt;
            }
            else if (expr is Divide_exprContext)
            {
                var division_expr = (Divide_exprContext)expr;
                var operand1_dt = get_expr_type(division_expr.expression()[0], symtab);
                var operand2_dt = get_expr_type(division_expr.expression()[1], symtab);
                if (operand1_dt != operand2_dt) throw new Exception($"Cannot divide two expressions of different types. {operand1_dt} and {operand2_dt}");

                return operand1_dt;
            }
            else if (expr is Parenthesis_exprContext)
            {
                return get_expr_type(((Parenthesis_exprContext)expr).expression(), symtab);
            }
            else if (expr is Minus_exprContext)
            {
                var datatype = get_expr_type(((Minus_exprContext)expr).expression(), symtab);

                // if (datatype == "طبيعي_١")
                // {
                //     return "صحيح_١";
                // }
                // else if (datatype == "طبيعي_٢")
                // {
                //     return "صحيح_٢";
                // }
                // else if (datatype == "طبيعي_٤")
                // {
                //     return "صحيح_٤";
                // }
                // else if (datatype == "طبيعي_٨")
                // {
                //     return "صحيح_٨";
                // }
                // else { return datatype; }
                if (datatype == "طبيعي")
                {
                    return "صحيح";
                }
                else if (datatype == "صحيح")
                {
                    return "صحيح";
                }
                else
                {
                    throw new Exception("Cannot negate expression of type: " + datatype);
                }

            }
            else if (expr is Fun_call_exprContext)
            {
                var func_call_expr = (Fun_call_exprContext)expr;

                var function_name = func_call_expr.ID().GetText();
                var function_entry_in_symtable = (FunctionSymbolTableEntry)symtab.get_symbol_by_id(function_name);

                if (function_entry_in_symtable.symbol_type != SymbolType.FUNCTION)
                {
                    throw new Exception("The symbol is not a function");
                }
                else
                {
                    var arguments = func_call_expr.argumentList().argument();

                    if (arguments.Length != function_entry_in_symtable.parameters_datatypes.Count) throw new Exception("the number of arguments does not match the number or parameters");

                    for (int index = 0; index < function_entry_in_symtable.parameters_datatypes.Count; index++)
                    {

                        var argument_dt = Expression.get_expr_type(arguments[index].expression(), symtab);
                        var parameter_dt = function_entry_in_symtable.parameters_datatypes[index];
                        if (argument_dt != parameter_dt)
                        {
                            throw new Exception($"Arugment type mismatches the equivalent paremeter type, {argument_dt}, {parameter_dt}");
                        }
                    }

                    return ((FunctionSymbolTableEntry)function_entry_in_symtable).return_type;
                }
            }
            else if (expr is Lnot_exprContext || expr is Lor_exprContext || expr is Land_exprContext)
            {
                var Lnot_expr = (Lnot_exprContext)expr;
                get_expr_type(Lnot_expr.expression(), symtab);
                return "طبيعي";
            }
            else if (expr is Comparison_exprContext)
            {
                var comparison_expr = (Comparison_exprContext)expr;

                var operand1_dt = get_expr_type(comparison_expr.expression()[0], symtab);
                var operand2_dt = get_expr_type(comparison_expr.expression()[1], symtab);

                if (operand1_dt != operand2_dt) throw new Exception($"Cannot compare two expressions of different types. {operand1_dt} and {operand2_dt}");

                return "طبيعي";
            }
            else if (expr is Equality_exprContext)
            {
                var equality_expr = (Comparison_exprContext)expr;

                var operand1_dt = get_expr_type(equality_expr.expression()[0], symtab);
                var operand2_dt = get_expr_type(equality_expr.expression()[1], symtab);

                if (operand1_dt != operand2_dt) throw new Exception($"Cannot compare two expressions of different types. {operand1_dt} and {operand2_dt}");

                return "طبيعي";
            }
            else if (expr is ArgumentContext)
            {
                var argument = (ArgumentContext)expr;
                return get_expr_type(argument.expression(), symtab);
            }
            else
            {
                throw new Exception($"Couldn't recognize integer expression data type: {expr.GetType().Name}");

            }
        }
        public static string convert_arabic_to_english_literal(string input)
        {
            StringBuilder result = new StringBuilder();
            for (int index = input.Length - 1; index >= 0; index--)
            {
                if (input[index] == '٠')
                {
                    result.Append('0');
                }
                else if (input[index] == '١')
                {
                    result.Append('1');
                }
                else if (input[index] == '٢')
                {
                    result.Append('2');

                }
                else if (input[index] == '٣')
                {
                    result.Append('3');

                }
                else if (input[index] == '٤')
                {
                    result.Append('4');

                }
                else if (input[index] == '٥')
                {
                    result.Append('5');

                }
                else if (input[index] == '٦')
                {
                    result.Append('6');

                }
                else if (input[index] == '٧')
                {
                    result.Append('7');

                }
                else if (input[index] == '٨')
                {
                    result.Append('8');

                }
                else if (input[index] == '٩')
                {
                    result.Append('9');

                }
                else
                {
                    throw new Exception();
                }


            }
            return result.ToString();
        }
    }
    // this class is used to : 
    // 1. generate the symbol table.
    // 2. validate the parse three and making sure the semantics rules hold.


    // this is the function is used to generate the symbol table for the blocks, 
    // and the scopes.


    // on the parameters: eacht symbol table has a parent except the program symbol table equal null.
    public static SymbolTable GenerateSymbolTable(IParseTree node, SymbolTable parent)
    {
        if (node is ProgramContext)
        {
            var program_node = (ProgramContext)node;

            SymbolTable result = new ProgramSymbolTable(null, "program");

            // traverse the program node children to add the symbol tables to the result table.
            foreach (var child in program_node.children)
            {
                result.add_symbol(GetSymbolTableEntry(child, result));
            }

            // traverse the program node children constructing a symbol table for each node if possible.
            for (int index = 0; index < program_node.ChildCount; index++)
            {
                result.add_sub_table(GenerateSymbolTable(program_node.GetChild(index), result));
            }

            return result;
        }
        else if (node is FunctionDeclContext)
        {
            var functiondecl_node = (FunctionDeclContext)node;

            SymbolTable function_symbol_table = new FunctionSymbolTable(parent, functiondecl_node.ID().GetText());

            // traverse the parameters to reserve their symbols in the table.
            foreach (var parameter in functiondecl_node.paramList().parameter())
            {
                function_symbol_table.add_symbol(GetSymbolTableEntry(parameter, function_symbol_table));
            }
            // traverse the statements to reserve their symbols in the table.
            foreach (var statement in functiondecl_node.statementList().statement())
            {
                function_symbol_table.add_symbol(GetSymbolTableEntry(statement, function_symbol_table));
            }

            return function_symbol_table;
        }
        else if (node is OperationDeclContext)
        {
            var operationdecl_node = (OperationDeclContext)node;

            SymbolTable operation_symbol_table = new OperationSymbolTable(parent, operationdecl_node.ID().GetText());

            // traverse the parameters to reserve their symbols in the table.
            foreach (var parameter in operationdecl_node.paramList().parameter())
            {
                operation_symbol_table.add_symbol(GetSymbolTableEntry(parameter, operation_symbol_table));
            }

            // traverse the statements to reserve their symbols in the table.
            foreach (var statement in operationdecl_node.statementList().statement())
            {
                operation_symbol_table.add_symbol(GetSymbolTableEntry(statement, operation_symbol_table));
            }

            return operation_symbol_table;
        }
        return null;
    }

    // this function is responsible for:
    // 1. Generating every possilbe symbol table entry for each node in the ast.
    // 2. Validate the nodes that require semantic validation.
    public static SymbolTableEntry GetSymbolTableEntry(IParseTree node, SymbolTable parent)
    {

        if (node is FunctionDeclContext)
        {
            // required validation for function symbol table entry: 
            // 1. the function name is not already used.

            var functiondecl_node = (FunctionDeclContext)node;
            // record function name and return type.
            string function_name = functiondecl_node.ID().GetText();
            string return_type = functiondecl_node.dataType().GetText();

            // record funnction parameters datatypes.
            List<string> parameters_datatypes = new List<string>();
            foreach (var parameter in functiondecl_node.paramList().parameter())
            {
                parameters_datatypes.Add(parameter.dataType().GetText());
            }

            // check if the function name is reserved.
            if (parent.is_identifier_reserved(function_name))
            {
                throw new Exception("Function Identifier Reserved: " + function_name);
            }
            // return the function symtab entry recording the function signature: return type, name, parameters datatypes.
            return new FunctionSymbolTableEntry(function_name, return_type, parameters_datatypes);

        }
        else if (node is OperationDeclContext)
        {
            // required validation for operation symbol table entry.
            var operationdecl_node = (OperationDeclContext)node;

            // record operation name.
            string operation_name = operationdecl_node.ID().GetText();

            // record the operation parameters datatypes.
            List<string> parameters_datatypes = new List<string>();
            foreach (var parameter in operationdecl_node.paramList().parameter())
            {
                parameters_datatypes.Add(parameter.dataType().GetText());
            }

            // check of the operation name is not reserved in the parent symbol.
            if (parent.is_identifier_reserved(operation_name))
            {
                throw new Exception("Operation Identifier Reserved: " + operation_name);
            }

            // return operation symtab entry recording the operation signature: name, parameters datatypes.
            return new OperationSymbolTableEntry(operationdecl_node.ID().GetText(), parameters_datatypes);
        }
        else if (node is GlobalVarDeclContext)
        {
            // required validation for global variable definition:
            // 1. name is not reserved in the symbol table.
            // 2. initialization datatype match the variable type.
            var globalvardecl_node = (GlobalVarDeclContext)node;

            // record the variable name and datatype.
            string variable_name = globalvardecl_node.ID().GetText();
            string datatype = globalvardecl_node.dataType().GetText();

            // get the initialization data type using Expression static help function.
            string initial_val_datatype = Expression.get_expr_type(globalvardecl_node.inititalization().expression(), parent);


            // check if the variable name is reserved or not.
            if (parent.is_identifier_reserved(variable_name))
            {
                throw new Exception("Identifier Reserved: " + variable_name);
            }


            // check of the initialization datatype match the variable datatype.
            if (initial_val_datatype != datatype)
            {
                throw new Exception($"Type Mismatch Between Variable and Initialization Value: [{datatype}, {initial_val_datatype}]");
            }

            // return the global variable symbol table entry recording the datatype and 
            return new GlobalVarSymbolTableEntry(globalvardecl_node.ID().GetText(), globalvardecl_node.dataType().GetText(), new object());
        }
        else if (node is Var_Decl_StatContext)
        {
            // required validation for local variable declartion:
            // 1. name is not reserved in the symbol table.
            // 2. initialization datatype match the variable type.

            var vardecl = ((Var_Decl_StatContext)node).varDecl();

            // record the variable name and datatype.
            string variable_name = vardecl.ID().GetText();
            string variable_datatype = vardecl.dataType().GetText();

            // get the initial expression datatype, using the Expression Class static function.
            string initial_val_datatype = Expression.get_expr_type(vardecl.inititalization().expression(), parent);

            // check that the name is not reserved in the symbol table.
            if (parent.is_identifier_reserved(variable_name))
            {
                throw new Exception("Identifier reserved: " + variable_name);
            }

            // check that the initialization datatype match the variable datatype.
            if (initial_val_datatype != variable_datatype)
            {
                throw new Exception($"Type mismatch between variable and initial value: [{variable_datatype}, {initial_val_datatype}]");
            }
            // return the local variable symtab entry recording the variable datatype and variable.
            return new LocalVarSymbolTableEntry(vardecl.ID().GetText(), vardecl.dataType().GetText(), new object());
        }
        else if (node is Assignment_StatContext)
        {
            // required validation for assignment statement:
            // 1. lhs exist and correspond to a variable or parameter.
            // 2. the rhs datatype match the datatype of the lhs.
            var assignment_stat = ((Assignment_StatContext)node).assignmentStat();
            // get the lhs identifier.
            string lhs_id = assignment_stat.ID().GetText();
            // get the corresponding symbol table.
            var symbol_table_entry_for_lhs_id = parent.get_symbol_by_id(lhs_id);

            // get the symbol type.
            var symbol_type = symbol_table_entry_for_lhs_id.symbol_type;


            // get the rhs_datatype using the expression class static helper function.
            var rhs_datatype = Expression.get_expr_type(assignment_stat.expression(), parent);

            string lhs_datatype = "";
            if (symbol_type == SymbolType.GLOBALVAR)
            {
                var gvar = (GlobalVarSymbolTableEntry)symbol_table_entry_for_lhs_id;
                lhs_datatype = gvar.datatype;
            }
            else if (symbol_type == SymbolType.LOCALVAR)
            {
                var lvar = (LocalVarSymbolTableEntry)symbol_table_entry_for_lhs_id;
                lhs_datatype = lvar.datatype;

            }
            else if (symbol_type == SymbolType.PARAMETER)
            {
                var pvar = (ParameterSymbolTableEntry)symbol_table_entry_for_lhs_id;
                lhs_datatype = pvar.datatype;

            }
            else
            {
                throw new ArgumentException("The RHS is not a variable");
            }
            if (lhs_datatype != rhs_datatype)
            {
                throw new Exception($"Type mismatch between lhs and rhs of an assignment: [{rhs_datatype}, {lhs_datatype}]");

            }

            // assignment statement does not correspond to symbol table entries so return null.
            return null;
        }
        else if (node is Operation_StatContext)
        {
            // required validation for operation call statement:
            // 1. the operation exist in the current symbol table.
            // 2. the number and datatype of arguments passed to the operation match it's signature.
            var operation_stat = ((Operation_StatContext)node).operationStat();

            // Get Operation Name
            string called_id = operation_stat.ID().GetText();
            // Get the called_id Symbol from the symbol table.
            var called_id_symbol_table_entry = parent.get_symbol_by_id(called_id);

            // check if the called id correspond to operation symbol table entry.
            if (called_id_symbol_table_entry.symbol_type != SymbolType.OPERATION)
            {
                throw new Exception("This is not an operation name");
            }

            var operation_symtabentry = (OperationSymbolTableEntry)called_id_symbol_table_entry;

            // get the datatypes of the operation parameters.
            var operation_parameters_datatypes = operation_symtabentry.parameter_datatypes;


            var passed_arguments = operation_stat.argumentList().argument();

            if (passed_arguments.Length != operation_parameters_datatypes.Count)
            {
                throw new Exception($"The number of arguments doesnot match the number of parameters for {called_id}.");
            }
            else
            {
                // compare each argument datatype and the corresponding parameter datatype of the operation signature.
                for (int index = 0; index < passed_arguments.Length; index++)
                {
                    var argument_datatype = Expression.get_expr_type(passed_arguments[index], parent);
                    var parameter_datatype = operation_parameters_datatypes[index];
                    if (operation_parameters_datatypes[index] != argument_datatype)
                    {
                        throw new Exception($"argument parameter typemismatch: {argument_datatype}, {parameter_datatype}");
                    }
                }
            }
            // operation call does not correspond to a symbol table entry, so return null. 
            return null;
        }
        else if (node is Result_StatContext)
        {
            // result statement required validation:
            // 1. the datatype of the result expression match the datatype of the functions.
            // 2. the result statement happened inside a function not an operation.
            var result_stat = ((Result_StatContext)node).resultStat();

            // get the result expression datatype from Expression Class static helper function.
            var result_expr_datatype = Expression.get_expr_type(result_stat.expression(), parent);

            // validate that the parent symbol table correspond to a function symbol table.
            if (parent is not FunctionSymbolTable)
            {
                throw new Exception($"result statements should occur inside function declarations but happend in: {parent.GetType().Name}");
            }
            // if(parent is not null)
            // {
            //     if(parent.parent is not null)
            //     {
            //         var symbol = parent.parent.get_symbol_by_id(parent.identifier);
            //         if(symbol.symbol_type != SymbolType.FUNCTION)
            //         {
            //             throw new Exception("result statements should occur inside function declarations");
            //         }else {
            //             var function_symbol = (FunctionSymbolTableEntry) symbol;
            //             if(function_symbol.return_type != result_expr_datatype)
            //             {
            //                 throw new Exception($"Type mismatch between the return type and the return expression type: {result_expr_datatype}, {function_symbol.return_type}");
            //             }
            //         }
            //     }
            //     else {
            //         throw new Exception("result statements should occur inside function declarations");
            //     }
            // }
            // else {
            //     throw new Exception("result statements should occur inside function declarations");
            // }

            // result statement does not correspond to symbol table entries, so return null.
            return null;
        }
        else if (node is Return_StatContext)
        {
            // required validation for the return statement:
            // 1. return statements only happens inside operation symbol table.
            var return_stat = ((Return_StatContext)node).returnStat();


            if (parent is not OperationSymbolTable)
            {
                throw new Exception($"Result statements should happen only in operation Symbol tables, but happened in: {parent.GetType().Name}");
            }
            // if(parent is not null)
            // {
            //     if(parent.parent is not null)
            //     {
            //         var symbol = parent.parent.get_symbol_by_id(parent.identifier);
            //         if(symbol.symbol_type != SymbolType.OPERATION)
            //         {
            //             throw new Exception("result statements should occur inside operation declarations");
            //         }
            //     }
            //     else {
            //         throw new Exception("result statements should occur inside operation declarations");
            //     }
            // }
            // else {
            //     throw new Exception("result statements should occur inside operation declarations");
            // }



            return null;
        }
        else if (node is If_StatContext)
        {
            // validation required for if statements:
            // 1. the if statement block does not contain any variable declartions.
            // 2. each statement in the block is a valid statemen.

            var if_stat = ((If_StatContext)node).ifStat();
            // get the if statement block statements array.
            var statements = if_stat.statementList().statement();

            foreach (var statement in statements)
            {
                if (statement is Var_Decl_StatContext)
                {
                    throw new Exception("Cannot Declare Variable Inside If Statement Block");
                }
            }
            // for(int index = 0; index < statements.Length; index++)
            // {
            //     if(statements[index] is Var_Decl_StatContext){
            //         throw new Exception("cannot declare variable inside if statement block");
            //     }
            //     GetSymbolTableEntry(statements[index], parent);
            // }

            return null;
        }
        else if (node is While_StatContext)
        {
            // required validation for while statement:
            // 1. the while statement block doesnot contain variable declaration.
            // 2. each statement in the block is a valid statemen.

            var while_stat = ((While_StatContext)node).whileStat();


            // Get all the statements inside the block.
            var statements = while_stat.statementList().statement();

            foreach (var statement in statements)
            {
                if (statement is Var_Decl_StatContext)
                {
                    throw new Exception("cannot declare variable inside while statement block");
                }
                GetSymbolTableEntry(statement, parent);
            }

            // for(int index = 0; index < statements.Length; index++)
            // {
            //     if(statements[index] is Var_Decl_StatContext){
            //         throw new Exception("cannot declare variable inside while statement block");
            //     }
            //     GetSymbolTableEntry(statements[index], parent);
            // }
            return null;
        }
        else if (node is ParameterContext)
        {
            // validation required by each parameters in function or operation declaration:
            // 1. the parameter id is not reserved in the function symbol table or by another function or operation.
            var parameter = (ParameterContext)node;

            if (parent.is_identifier_reserved(parameter.ID().GetText()))
            {
                throw new Exception("Parameter identifier is already used.");
            }
            return new ParameterSymbolTableEntry(parameter.ID().GetText(), parameter.dataType().GetText(), new object());
        }
        else
        {
            return null;
        }
    }

}