namespace Geem.Traversers;
using Geem.Environment;
using static Geem.Parser.GeemParser;
using Antlr4.Runtime.Tree;

using System.Text;

public class InterpreterTraverser {
    public static void run(IParseTree node, SymbolTable parent)
    {
        if(node is ProgramContext)
        {
            var program = (ProgramContext) node;
            // var program_symbol_table = new ProgramSymbolTable(null, "program");
            for(int index = 0; index < program.ChildCount; index++)
            {
                run(program.children[index], parent);   
            }
        }
        else if(node is GlobalVarDeclContext)
        {
            var global_var = (GlobalVarDeclContext) node;
            var gvar_symbol = (GlobalVarSymbolTableEntry) parent.get_symbol_by_id(global_var.ID().GetText());
            var initial_value = InterpreterTraverser.evalExpression(global_var.inititalization().expression(), parent);
            gvar_symbol.value = initial_value;
        }
        else if(node is CommandStatContext)
        {
            // checking the type of command is unnecessary.

            var command_node_expression = ((CommandStatContext) node).command().expression();

            Int64 integer = (Int64) evalExpression(command_node_expression, parent);

            Console.WriteLine(integer.ToString());
            
        }
        else if(node is FunctionDeclContext)
        {
            var function_decl = (FunctionDeclContext) node;
            var function_name = function_decl.ID().GetText();
            if(function_name == "المدخل") {
                var statements = function_decl.statementList().statement();
                var symbol_table_for_function = parent.sub_tables.Find((SymbolTable table) => table.identifier == function_name);
                for(int index = 0; index < statements.Length; index ++)
                {
                    run(statements[index], symbol_table_for_function);
                }
            }
        }
        else if(node is Var_Decl_StatContext){
            var l_var_decl = ((Var_Decl_StatContext) node).varDecl();

            var init_value = evalExpression(l_var_decl.inititalization().expression(), parent);

            var l_var_symbol = (LocalVarSymbolTableEntry) parent.get_symbol_by_id(l_var_decl.ID().GetText());

            l_var_symbol.value = init_value;
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
        }
        else if(node is Return_StatContext)
        {

        }else if(node is Result_StatContext) {

        }
        else if(node is If_StatContext) {
            var if_stat = ((If_StatContext) node).ifStat();

            Int64 condition_value = (Int64) evalExpression(if_stat.expression(), parent);
            if(condition_value != 0) { // condition evaluate to true
                var statements = if_stat.statementList().statement();
                for(int index = 0; index < statements.Length; index++) {
                    run(statements[index], parent);
                }
            }
        }
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
            }else if(variable_symbol is LocalVarSymbolTableEntry)
            {
                var l_variable_symbol = (LocalVarSymbolTableEntry) variable_symbol;
                return l_variable_symbol.value;
            }else {
                return new object();
            }
            
        }
        else if(expr is Int_literal_exprContext)
        {
            var int_literal = ((Int_literal_exprContext) expr).int_literal();
            var arbic_int_literal = int_literal.GetText().Substring(0, int_literal.GetText().Length -2 );

            Int64 int_value = Int64.Parse(convert_arabic_to_english_literal(arbic_int_literal));
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
        
        return new object();
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