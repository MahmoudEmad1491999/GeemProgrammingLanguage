using Antlr4.Runtime.Tree;
using static Geem.Parser.GeemParser;
using Geem.Environment;
using System.Text;
namespace Geem.utilties;

public class Expression
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
                else if(entry.symbol_type == SymbolType.PARAMETER)
                {
                    var p_var_entry = (ParameterSymbolTableEntry) entry;
                    var var_datatype = p_var_entry.datatype;
                    return var_datatype;
                }
                else {
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
            if(operand1_dt != operand2_dt) throw new Exception($"Cannot add two expressions of different types. {operand1_dt} and {operand2_dt}");
            return operand1_dt;
        }
        else if (expr is Subtraction_exprContext)
        {
            var subtraction_expr = (Subtraction_exprContext)expr;
            var operand1_dt = get_expr_type(subtraction_expr.expression()[0], symtab);
            var operand2_dt = get_expr_type(subtraction_expr.expression()[1], symtab);
            if(operand1_dt != operand2_dt) throw new Exception($"Cannot subtract two expressions of different types. {operand1_dt} and {operand2_dt}");

            return operand1_dt;
        }
        else if (expr is Multiply_exprContext)
        {
            var multiply_expr = (Multiply_exprContext)expr;
            var operand1_dt = get_expr_type(multiply_expr.expression()[0], symtab);
            var operand2_dt = get_expr_type(multiply_expr.expression()[1], symtab);
            if(operand1_dt != operand2_dt) throw new Exception($"Cannot multiply two expressions of different types. {operand1_dt} and {operand2_dt}");

            return operand1_dt;
        }
        else if (expr is Divide_exprContext)
        {
            var division_expr = (Divide_exprContext)expr;
            var operand1_dt = get_expr_type(division_expr.expression()[0], symtab);
            var operand2_dt = get_expr_type(division_expr.expression()[1], symtab);
            if(operand1_dt != operand2_dt) throw new Exception($"Cannot divide two expressions of different types. {operand1_dt} and {operand2_dt}");

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
            if(datatype == "طبيعي")
            {
                return "صحيح";
            }
            else if(datatype == "صحيح") {
                return "صحيح";
            }
            else {
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
            var Lnot_expr = (Lnot_exprContext) expr;
            get_expr_type(Lnot_expr.expression(), symtab);
            return "طبيعي";
        }
        else if (expr is Comparison_exprContext)
        {
            var comparison_expr = (Comparison_exprContext) expr;

            var operand1_dt = get_expr_type(comparison_expr.expression()[0], symtab);
            var operand2_dt = get_expr_type(comparison_expr.expression()[1], symtab);
            
            if(operand1_dt != operand2_dt) throw new Exception($"Cannot compare two expressions of different types. {operand1_dt} and {operand2_dt}");
            
            return "طبيعي";
        }
        else if (expr is Equality_exprContext)
        {
            var equality_expr = (Comparison_exprContext) expr;

            var operand1_dt = get_expr_type(equality_expr.expression()[0], symtab);
            var operand2_dt = get_expr_type(equality_expr.expression()[1], symtab);
            
            if(operand1_dt != operand2_dt) throw new Exception($"Cannot compare two expressions of different types. {operand1_dt} and {operand2_dt}");
            
            return "طبيعي";
        }
        else if (expr is ArgumentContext)
        {
            var argument = (ArgumentContext) expr;
            return get_expr_type(argument.expression(), symtab);
        }
        else {
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