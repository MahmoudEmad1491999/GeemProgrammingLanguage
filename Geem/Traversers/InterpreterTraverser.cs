namespace Geem.Traversers;
using Geem.Environment;
using static Geem.Parser.GeemParser;
using Antlr4.Runtime.Tree;

using System.Text;

public class InterpreterTraverser {
    public static ProgramSymbolTable program_symbol_table = null;
    public static ProgramContext root = null;
    public static Stack<Int64> function_call_results = new Stack<long>();
    public static bool run(IParseTree node, SymbolTable parent)
    {
        if(node is ProgramContext)
        {
            InterpreterTraverser.program_symbol_table = (ProgramSymbolTable) parent;
            InterpreterTraverser.root = (ProgramContext)node;
            var program = (ProgramContext) node;
            // var program_symbol_table = new ProgramSymbolTable(null, "program");
            for(int index = 0; index < program.ChildCount; index++)
            {
                run(program.children[index], parent);   
            }
            return true;

        }
        else if(node is GlobalVarDeclContext)
        {
            var global_var = (GlobalVarDeclContext) node;
            var gvar_symbol = (GlobalVarSymbolTableEntry) parent.get_symbol_by_id(global_var.ID().GetText());
            var initial_value = InterpreterTraverser.evalExpression(global_var.inititalization().expression(), parent);
            gvar_symbol.value = initial_value;
            return true;
        }
        else if(node is CommandStatContext)
        {
            // checking the type of command is unnecessary.

            var command_node_expression = ((CommandStatContext) node).command().expression();

            Int64 integer = (Int64) evalExpression(command_node_expression, parent);

            Console.WriteLine(integer.ToString());
            return true;
        }
        else if(node is FunctionDeclContext)
        {
            var function_decl = (FunctionDeclContext) node;
            var function_name = function_decl.ID().GetText();
            if(function_name == "المدخل") {
                var statements = function_decl.statementList().statement();
                var symbol_table_for_function = parent.get_sub_table_by_id(function_name);
                for(int index = 0; index < statements.Length; index ++)
                {
                    run(statements[index], symbol_table_for_function);
                }
            }
            return true;
        }
        else if(node is Var_Decl_StatContext){
            var l_var_decl = ((Var_Decl_StatContext) node).varDecl();

            var init_value = evalExpression(l_var_decl.inititalization().expression(), parent);
            var symbol = parent.get_symbol_by_id(l_var_decl.ID().GetText());
            var l_var_symbol = (LocalVarSymbolTableEntry) symbol;

            l_var_symbol.value = init_value;
            return true;
        }
        else if(node is Assignment_StatContext)
        {
            var assignment_stat = ((Assignment_StatContext) node).assignmentStat();

            var value = evalExpression(assignment_stat.expression(), parent);

            var variable_name = assignment_stat.ID().GetText();

            var symbol = parent.get_symbol_by_id(variable_name);

            if(symbol is LocalVarSymbolTableEntry)
            {
                var l_var_symbol = (LocalVarSymbolTableEntry) symbol;

                l_var_symbol.value = value;
            }
            else if(symbol is GlobalVarSymbolTableEntry)
            {
                var g_var_symbol = (GlobalVarSymbolTableEntry) symbol;

                g_var_symbol.value = value;
            }
            return true;
        }
        else if(node is Result_StatContext)
        {
            Int64 value = (Int64) evalExpression(((Result_StatContext) node).resultStat().expression(), parent);
            
            function_call_results.Push(value);
            return false;
        }
        else if(node is Result_StatContext) {
            return false;
        }
        else if(node is If_StatContext) {
            var if_stat = ((If_StatContext) node).ifStat();

            Int64 condition_value = (Int64) evalExpression(if_stat.expression(), parent);
            if(condition_value != 0) { // condition evaluate to true
                var statements = if_stat.statementList().statement();
                bool contine_running = true;
                for(int index = 0; index < statements.Length; index++) {
                    contine_running = run(statements[index], parent);
                    if(!contine_running)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        else if(node is While_StatContext) 
        {
            var while_stat = ((While_StatContext) node).whileStat();

            Int64 condition_value = (Int64) evalExpression(while_stat.expression(), parent);
            var statements = while_stat.statementList().statement();
            bool continue_running = true;;
            while(condition_value != 0)
            {
                for(int index = 0; index < statements.Length; index++) 
                {
                    continue_running = run(statements[index], parent);
                    if(!continue_running) 
                    {
                        return false;
                    }
                }
                condition_value = (Int64) evalExpression(while_stat.expression(), parent);
            }
            return true;
        }
        else if(node is Operation_StatContext)
        {
            var operation_call = ((Operation_StatContext) node).operationStat();
            // get the arguments of the operation call.
            var arguments = operation_call.argumentList().argument();
            var arguments_values = new List<Int64>();
            // evaluate each argument expression.
            for(int index = 0; index < arguments.Length; index ++) 
            {
                arguments_values.Add((Int64)evalExpression(arguments[index], parent));
            }
            // get the operation symbol table.
            OperationSymbolTable operationSymbolTable = (OperationSymbolTable) program_symbol_table.sub_tables.Find(
                (SymbolTable table) => table.identifier == operation_call.ID().GetText()
            );

            // initialize the parameters with the corresponding argument expressin value.
            var parameter_arr = operationSymbolTable.get_parameters_entries();
            for(int index = 0; index < parameter_arr.Length; index++) 
            {
                parameter_arr[index].value = arguments_values[index];
            }
            // get the operation node.
            var operation_nodes = root.GetRuleContexts<OperationDeclContext>();
            OperationDeclContext operation_node = null;
            for(int index = 0; index < operation_nodes.Length; index++) 
            {
                if(operation_nodes[index].ID().GetText() == operation_call.ID().GetText()) {
                    operation_node = operation_nodes[index];
                }
            }
            // get the statetment list of the operation.
            var statements = operation_node.statementList().statement();
            
            // run each statements.
            for(int index = 0; index < statements.Length; index++) 
            {
                if(statements[index] is Return_StatContext){
                    break;
                }
                run(statements[index], operationSymbolTable);
            }
            return true;
        }
        else if(node is Command_StatContext)
        {
            // the only command supported command is print so no checking needed.
            var command_stat = ((Command_StatContext) node).commandStat().command();

            Int64 expression_value = (Int64)evalExpression(command_stat.expression(), parent);
            Console.WriteLine(expression_value.ToString());
            return true;
        }
        return true;
    }

    public static object evalExpression(IParseTree expr,SymbolTable parent)
    {
        if(expr is Variable_exprContext)
        {
            var variable_expr = (Variable_exprContext) expr;
            
            var variable_symbol =  parent.get_symbol_by_id(variable_expr.ID().GetText());
            if(variable_symbol is GlobalVarSymbolTableEntry){
                var g_variable_symbol = (GlobalVarSymbolTableEntry) variable_symbol;
                return g_variable_symbol.value;
            }
            else if(variable_symbol is LocalVarSymbolTableEntry)
            {
                var l_variable_symbol = (LocalVarSymbolTableEntry) variable_symbol;
                return l_variable_symbol.value;
            }
            else if(variable_symbol is ParameterSymbolTableEntry)
            {
                var p_varaiable_symbol = (ParameterSymbolTableEntry) variable_symbol;
                return p_varaiable_symbol.value;
            }
            else {
                return new object();
            }
            
        }
        else if(expr is Int_literal_exprContext)
        {
            var int_literal = ((Int_literal_exprContext) expr).Int_literal().GetText();
            // var arbic_int_literal = int_literal.GetText().Substring(0, int_literal.GetText().Length -2 );

            Int64 int_value = Int64.Parse(convert_arabic_to_english_literal(int_literal));
            return int_value;
        }
        else if(expr is Add_exprContext)
        {
            var operand1 = ((Add_exprContext) expr).expression(0);
            var operand2 = ((Add_exprContext) expr).expression(1);

            var operand1_value = (Int64) evalExpression(operand1, parent);
            var operand2_value = (Int64) evalExpression(operand2, parent);

            return operand1_value + operand2_value;

        }
        else if(expr is Subtraction_exprContext)
        {
            var operand1 = ((Subtraction_exprContext) expr).expression(0);
            var operand2 = ((Subtraction_exprContext) expr).expression(1);

            var operand1_value = (Int64) evalExpression(operand1, parent);
            var operand2_value = (Int64) evalExpression(operand2, parent);

            return operand1_value - operand2_value;

        }
        else if(expr is Multiply_exprContext)
        {
            var operand1 = ((Multiply_exprContext) expr).expression(0);
            var operand2 = ((Multiply_exprContext) expr).expression(1);

            var operand1_value = (Int64) evalExpression(operand1, parent);
            var operand2_value = (Int64) evalExpression(operand2, parent);

            return operand1_value * operand2_value;

        }
        else if(expr is Divide_exprContext)
        {
            var operand1 = ((Divide_exprContext) expr).expression(0);
            var operand2 = ((Divide_exprContext) expr).expression(1);

            var operand1_value = (Int64) evalExpression(operand1, parent);
            var operand2_value = (Int64) evalExpression(operand2, parent);

            return operand1_value / operand2_value;

        }
        else if(expr is Parenthesis_exprContext) 
        {
            return evalExpression(((Parenthesis_exprContext) expr).expression(), parent);
        }
        else if(expr is Minus_exprContext)
        {
            return -1 * (Int64) evalExpression(((Minus_exprContext) expr).expression(), parent);
        }
        else if(expr is Lnot_exprContext)
        {
            var logical_expr = (Lnot_exprContext) expr;
            Int64 logical_expr_value = (Int64) evalExpression(logical_expr.expression(), parent);
            if(logical_expr_value != 0){
                return 0;
            }else {
                return Int64.MaxValue;
            }
        }
        else if(expr is Comparison_exprContext)
        {
            var comp_expr = ((Comparison_exprContext) expr);
            var operand1 = (Int64) evalExpression(comp_expr.expression(0), parent);
            var operand2 = (Int64) evalExpression(comp_expr.expression(1), parent);

            if(comp_expr.comparison_op().GetText() == "<")
            {
                return (operand1 > operand2) ? Int64.MaxValue: 0;
            }
            else if(comp_expr.comparison_op().GetText() == ">")
            {
                return (operand1 < operand2) ? Int64.MaxValue: 0;
            }
            else if(comp_expr.comparison_op().GetText() == "<=")
            {
                return (operand1 >= operand2) ? Int64.MaxValue: 0;
            }
            else if(comp_expr.comparison_op().GetText() == ">=")
            {
                return (operand1 <= operand2) ? Int64.MaxValue: 0;
            }
            return 0;
        }
        else if(expr is Equality_exprContext)
        {
            var equality_expr = ((Equality_exprContext) expr);
            var operand1 = (Int64) evalExpression(equality_expr.expression(0), parent);
            var operand2 = (Int64) evalExpression(equality_expr.expression(1), parent);

            if(equality_expr.equality_op().GetText() == "==")
            {
                return operand1 == operand2 ? Int64.MaxValue: 0;
            }
            else if(equality_expr.equality_op().GetText() == "!="){
                return operand1 == operand2 ? 0: Int64.MaxValue;
            }
            else {
                return 0;
            }
        }
        else if(expr is Land_exprContext)
        {
            var land_expr = (Land_exprContext) expr;
            
            var operand1 = (Int64) evalExpression(land_expr.expression(0), parent);
            var operand2 = (Int64) evalExpression(land_expr.expression(1), parent);

            return (operand1 * operand2 != 0)? Int64.MaxValue: 0;
        }
        else if(expr is Lor_exprContext) {
            var lor_expr = (Lor_exprContext) expr;

            var operand1 = (Int64) evalExpression(lor_expr.expression(0), parent);
            var operand2 = (Int64) evalExpression(lor_expr.expression(1), parent);

            if(operand1 == Int64.MaxValue || operand2 == Int64.MaxValue) {
                return Int64.MaxValue;
            }
            
            else {
                return 0;
            }
        }
        else if(expr is Fun_call_exprContext) {
            var func_call_expr = (Fun_call_exprContext) expr;

            string function_name = func_call_expr.ID().GetText();

            var arguments = func_call_expr.argumentList().argument();

            var arguments_values = new List<Int64>();

            for(int index = 0;index < arguments.Length; index++) 
            {
                arguments_values.Add((Int64)evalExpression(arguments[index].expression(), parent));
            }

            FunctionSymbolTable function_symbol_table = (FunctionSymbolTable) program_symbol_table.sub_tables.Find(
                (SymbolTable table) => table.identifier == func_call_expr.ID().GetText()
            );

            var parameter_arr = function_symbol_table.get_parameters_entries();
            for(int index = 0; index < parameter_arr.Length; index++) 
            {
                parameter_arr[index].value = arguments_values[index];
            }

            var function_nodes = root.GetRuleContexts<FunctionDeclContext>();
            FunctionDeclContext function_node = null;
            for(int index = 0; index < function_nodes.Length; index++) 
            {
                if(function_nodes[index].ID().GetText() == func_call_expr.ID().GetText()) {
                    function_node = function_nodes[index];
                }
            }
             var statements = function_node.statementList().statement();
            
            // run each statements.
            for(int index = 0; index < statements.Length; index++) 
            {
                if(statements[index] is Return_StatContext)
                {
                    run(statements[index], function_symbol_table);
                    break;
                }else {
                    run(statements[index], function_symbol_table);
                }
            }
            return function_call_results.Pop();
        }
        else if(expr is ArgumentContext)
        {
            var arguement = (ArgumentContext) expr;
            return evalExpression(arguement.expression(), parent);
        }
        throw new Exception("cannot evaluate expression of type: " + expr.GetType().Name);
    }
    
    public static string convert_arabic_to_english_literal(string input){
        StringBuilder result = new StringBuilder();
        for(int index =input.Length - 1;index >=0; index--)
        {
            if(input[index] == '٠')
            {
                result.Append('0');
            }
            else if(input[index] == '١')
            {
                result.Append('1');
            }
            else if(input[index] == '٢')
            {
                result.Append('2');

            }
            else if(input[index] == '٣')
            {
                result.Append('3');

            }
            else if(input[index] == '٤')
            {
                result.Append('4');

            }
            else if(input[index] == '٥')
            {
                result.Append('5');

            }
            else if(input[index] == '٦')
            {
                result.Append('6');

            }
            else if(input[index] == '٧')
            {
                result.Append('7');

            }
            else if(input[index] == '٨')
            {
                result.Append('8');

            }
            else if(input[index] == '٩')
            {
                result.Append('9');

            }else {
                throw new Exception();
            }
            
            
        }
        return result.ToString();  
    }
    
}