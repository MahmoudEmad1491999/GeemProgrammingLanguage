namespace Geem.Traversers;
using Geem.Environment;
using static Geem.Parser.GeemParser;
using Antlr4.Runtime.Tree;
using Geem.utilties;
public class GenerateSymbolTableTraverser {
    public static SymbolTable? GenerateSymbolTable(IParseTree node, SymbolTable? parent){
        if(node is ProgramContext){
            var program_node = (ProgramContext) node;
            SymbolTable result = new ProgramSymbolTable(null, "program");
            
            for(int index = 0; index < program_node.ChildCount; index++)
            {
                SymbolTableEntry? entry = GetSymbolTableEntry(program_node.children[index], result);
                result.add_symbol(entry);
            }

            for(int index = 0; index < program_node.ChildCount; index++)
            {
                result.add_sub_table(GenerateSymbolTable(program_node.GetChild(index),result));
            }
            return result;
        }
        else if(node is FunctionDeclContext){
            var functiondecl_node = (FunctionDeclContext) node;

            SymbolTable result = new FunctionSymbolTable(parent, functiondecl_node.ID().GetText());

            var parameters = functiondecl_node.paramList().parameter();

            var statements = functiondecl_node.statementList().statement();

            for(int index = 0; index < parameters.Length; index++)
            {
                SymbolTableEntry? entry = GetSymbolTableEntry(parameters[index], result);
                result.add_symbol(entry);
            }
            for(int index = 0; index < statements.Length; index++)
            {
                SymbolTableEntry? entry = GetSymbolTableEntry(statements[index], result);
                result.add_symbol(entry);
            }
        }
        else if(node is OperationDeclContext){
            var operationdecl_node = (OperationDeclContext) node;

            SymbolTable result = new OperationSymbolTable(parent, operationdecl_node.ID().GetText());

            var parameters = operationdecl_node.paramList().parameter();

            var statements = operationdecl_node.statementList().statement();

            for(int index = 0; index < parameters.Length; index++)
            {
                SymbolTableEntry? entry = GetSymbolTableEntry(parameters[index], result);
                result.add_symbol(entry);
            }
            for(int index = 0; index < statements.Length; index++)
            {
                SymbolTableEntry? entry = GetSymbolTableEntry(statements[index], result);
                result.add_symbol(entry);
            }
        }
        
        return null;
    }
    
    public static SymbolTableEntry? GetSymbolTableEntry(IParseTree node, SymbolTable parent){
        if(node is FunctionDeclContext)
        {
            var functiondecl_node = (FunctionDeclContext) node;
            
            string function_name = functiondecl_node.ID().GetText();
            string return_type = functiondecl_node.dataType().GetText();

            List<string> parameters_datatypes = new List<string>();
            foreach(var parameter in functiondecl_node.paramList().parameter()){
                parameters_datatypes.Add(parameter.dataType().GetText());
            }

            if(parent.is_identifier_reserved(function_name))
            {
                throw new Exception("Identifier reserved: " + function_name);
            }

            return new FunctionSymbolTableEntry(function_name, return_type, parameters_datatypes);

        }
        else if(node is OperationDeclContext) {
            var operationdecl_node = (OperationDeclContext) node;

            string operation_name = operationdecl_node.ID().GetText();
            
            if(parent.is_identifier_reserved(operation_name))
            {
                throw new Exception("Identifier reserved: " + operation_name);
            }

            List<string> parameters_datatypes = new List<string>();
            foreach(var parameter in operationdecl_node.paramList().parameter()){
                parameters_datatypes.Add(parameter.dataType().GetText());
            }

            return new OperationSymbolTableEntry(operationdecl_node.ID().GetText(), parameters_datatypes);
        }
        else if(node is GlobalVarDeclContext){
            var globalvardecl_node = (GlobalVarDeclContext) node;

            string variable_name = globalvardecl_node.ID().GetText();
            string datatype = globalvardecl_node.dataType().GetText();

            string initial_val_datatype = Expression.get_expr_type(globalvardecl_node.inititalization().expression(), parent);

            if(parent.is_identifier_reserved(variable_name)){
                throw new Exception("Identifier reserved: " + variable_name);
            }
            
            if(initial_val_datatype != datatype) 
            {
                throw new Exception($"Type mismatch between variable and initial value: [{datatype}, {initial_val_datatype}]");
            }
            
            return new GlobalVarSymbolTableEntry(globalvardecl_node.ID().GetText(), globalvardecl_node.dataType().GetText(), new object());
        }
        else if(node is Var_Decl_StatContext)
        {
            var vardecl = ((Var_Decl_StatContext) node).varDecl();

            string variable_name = vardecl.ID().GetText();
            string variable_datatype = vardecl.dataType().GetText();

            string initial_val_datatype = Expression.get_expr_type(vardecl.inititalization().expression(), parent);
            
            if(parent.is_identifier_reserved(variable_name)){
                throw new Exception("Identifier reserved: " + variable_name);
            }
            
            if(initial_val_datatype != variable_datatype) 
            {
                throw new Exception($"Type mismatch between variable and initial value: [{variable_datatype}, {initial_val_datatype}]");
            }

            return new GlobalVarSymbolTableEntry(vardecl.ID().GetText(), vardecl.dataType().GetText(), new object());
        }
        else if(node is Assignment_StatContext)
        {
            var assignment_stat = ((Assignment_StatContext) node).assignmentStat();

            string variable_name = assignment_stat.ID().GetText();

            var symbol_table_entry_for_the_variable = parent.get_symbol_by_id(variable_name);
        
            var symbol_type = symbol_table_entry_for_the_variable.symbol_type;
            var initial_val_datatype = Expression.get_expr_type(assignment_stat.expression(), parent);
            string rhs_datatype = "";

            if(symbol_type ==  SymbolType.GLOBALVAR)
            {
                var gvar = (GlobalVarSymbolTableEntry) symbol_table_entry_for_the_variable;
                rhs_datatype = gvar.datatype;
            }
            else if(symbol_type == SymbolType.LOCALVAR)
            {
                var lvar = (LocalVarSymbolTableEntry) symbol_table_entry_for_the_variable;
                rhs_datatype = lvar.datatype;

            }
            else if(symbol_type == SymbolType.PARAMETER)
            {
                var pvar = (ParameterSymbolTableEntry) symbol_table_entry_for_the_variable;
                rhs_datatype = pvar.datatype;

            }
            else {
                throw new ArgumentException("The RHS is not a variable");
            }
            if(rhs_datatype != initial_val_datatype)
            {
                throw new Exception($"Type mismatch between variable and initial value: [{rhs_datatype}, {initial_val_datatype}]");

            }
            return null;
        }
        else if(node is Operation_StatContext)
        {
            var operation_stat = ((Operation_StatContext) node).operationStat();

            string operation_name = operation_stat.ID().GetText();

            var operation_symbol = parent.get_symbol_by_id(operation_name);

            if(operation_symbol.symbol_type != SymbolType.OPERATION)
            {
                throw new Exception("This is not an operation name");
            }
            var operation_parameters_datatypes = ((OperationSymbolTableEntry) operation_symbol).parameter_datatypes;

            var operation_arguments_datatypes = operation_stat.argumentList().argument();

            if(operation_arguments_datatypes.Length != operation_parameters_datatypes.Count)
            {
                throw new Exception("The number of arguments doesnot match the number of parameters.");
            }
            else 
            {
                for(int index = 0; index < operation_arguments_datatypes.Length; index++)
                {
                    var argument_datatype =  Expression.get_expr_type(operation_arguments_datatypes[index], parent);
                    var parameter_datatype = operation_parameters_datatypes[index];
                    if(operation_parameters_datatypes[index] != argument_datatype)
                    {
                        throw new Exception($"argument parameter typemismatch: {argument_datatype}, {parameter_datatype}");
                    }
                }
            }           
            return null;
        }
        else if(node is Result_StatContext)
        {
            var result_stat = ((Result_StatContext) node).resultStat();

            var expression_datatype = Expression.get_expr_type(result_stat.expression(), parent);
            
            if(parent is not null)
            {
                if(parent.parent is not null)
                {
                    var symbol = parent.parent.get_symbol_by_id(parent.identifier);
                    if(symbol.symbol_type != SymbolType.FUNCTION)
                    {
                        throw new Exception("result statements should occur inside function declarations");
                    }else {
                        var function_symbol = (FunctionSymbolTableEntry) symbol;
                        if(function_symbol.return_type != expression_datatype)
                        {
                            throw new Exception($"Type mismatch between the return type and the return expression type: {expression_datatype}, {function_symbol.return_type}");
                        }
                    }
                }
                else {
                    throw new Exception("result statements should occur inside function declarations");
                }
            }
            else {
                throw new Exception("result statements should occur inside function declarations");
            }
            
            
            
            return null;
        }
        else if(node is Return_StatContext)
        {
            var return_stat = ((Return_StatContext) node).returnStat();

            if(parent is not null)
            {
                if(parent.parent is not null)
                {
                    var symbol = parent.parent.get_symbol_by_id(parent.identifier);
                    if(symbol.symbol_type != SymbolType.OPERATION)
                    {
                        throw new Exception("result statements should occur inside operation declarations");
                    }
                }
                else {
                    throw new Exception("result statements should occur inside operation declarations");
                }
            }
            else {
                throw new Exception("result statements should occur inside operation declarations");
            }
            
            
            
            return null;
        }
        else if(node is If_StatContext)
        {
            var if_stat = ((If_StatContext) node).ifStat();
            
            var statements = if_stat.statementList().statement();

            for(int index = 0; index < statements.Length; index++)
            {
                if(statements[index] is Var_Decl_StatContext){
                    throw new Exception("cannot declare variable inside if statement block");
                }
                GetSymbolTableEntry(statements[index], parent);
            }

            return null;
        }
        else if(node is While_StatContext)
        {
            var while_stat = ((While_StatContext) node).whileStat();
            
            var statements = while_stat.statementList().statement();

            for(int index = 0; index < statements.Length; index++)
            {
                if(statements[index] is Var_Decl_StatContext){
                    throw new Exception("cannot declare variable inside while statement block");
                }
                GetSymbolTableEntry(statements[index], parent);
            }

            return null;
        }
        else if(node is ParameterContext)
        {
            var parameter = (ParameterContext) node;

            return new ParameterSymbolTableEntry(parameter.ID().GetText(), parameter.dataType().GetText(), new object());
        }
        else {
            return null;
        }
    }
}