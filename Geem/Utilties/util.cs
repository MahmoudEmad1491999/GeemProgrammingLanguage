namespace Geem.Utilities;
using System.Text;
using System.Numerics;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using static Geem.Parser.GeemParser;
public class Utils {
    public static string convert_ar_int_to_en_int(string ar_int)
    {
        StringBuilder result_builder = new StringBuilder();
        int index = 0;
        if(ar_int.StartsWith('-')) index = 1;
        while(index < ar_int.Length)
        {
            if(ar_int[index] == ':') break;
            result_builder.Insert(0, ar_digit_to_en_digit(ar_int[index]));
            index++;
        }
        if(ar_int.StartsWith('-')) result_builder.Insert(0, '-');
        return result_builder.ToString();
    }
    public static int datatype_to_int(string dt)
    {
        if (dt == "ط_١") return 1;
        if (dt == "ط_٢") return 2;
        if (dt == "ط_٤") return 4;
        if (dt == "ط_٨") return 8;
        if (dt == "ص_١") return -1;
        if (dt == "ص_٢") return -2;
        if (dt == "ص_٤") return -4;
        if (dt == "ص_٨") return -8;
        throw new Exception();
    }
    public static string int_to_datatype(int dt)
    {
        if (dt == 1) return "ط_١";
        if (dt == 2) return "ط_٢";
        if (dt == 4) return "ط_٤";
        if (dt == 8) return "ط_٨";
        if (dt == -1) return "ص_١";
        if (dt == -2) return "ص_٢";
        if (dt == -4) return "ص_٤";
        if (dt == -8) return "ص_٨";
        throw new Exception();
    }
    public static bool is_numeric_datatype(string dt)
    {
        if (dt == "ص_١"
        || dt == "ص_٢"
        || dt == "ص_٤"
        || dt == "ص_٨"
        || dt == "ط_١"
        || dt == "ط_٢"
        || dt == "ط_٤"
        || dt == "ط_٨")
        {
            return true;
        }
        return false;
    }
    public static char ar_digit_to_en_digit(char ar_digit){
        if(ar_digit == '٠'){
            return '0';
        }else if(ar_digit == '١'){
            return '1';
        }else if(ar_digit == '٢'){
            return '2';
        }else if(ar_digit == '٣'){
            return '3';
        }else if(ar_digit == '٤'){
            return '4';
        }else if(ar_digit == '٥'){
            return '5';
        }else if(ar_digit == '٦'){
            return '6';
        }else if(ar_digit == '٧'){
            return '7';
        }else if(ar_digit == '٨'){
            return '8';
        }else if(ar_digit == '٩'){
            return '9';
        }
        else {
            throw new Exception();
        }

    }
    public static bool is_boolean_datatype(string dt)
    {
        if (dt == "منطقي" || dt == "منطقى")
        {
            return true;
        }
        return false;
    }
    public static IParseTree GetParentFunctionOrOperation(IParseTree node)
    {
        IParseTree result = node;
        while(result != null && result is not FunctionDeclContext && result is not OperationDeclContext)
        {
            result = result.Parent;
        }
        if(result is null) throw new Exception($"couldnot find parent function or operation.");
        return result;
    }
    
    public static ProgramContext GetProgramRoot(IParseTree node)   
    {
        var result = node;
        while(result != null && result is not ProgramContext)
        {
            result = result.Parent;
        }
        if(result is null) throw new Exception($"could not locate the program node.");
        return (ProgramContext)result;
    }


    public static void print_expression(string expr_datatype, object expr_value)
    {
        if (expr_datatype == "ص_١")
            {
                sbyte val = (sbyte)expr_value;
                Console.WriteLine(val);
            }
            else if (expr_datatype == "ص_٢")
            {
                Int16 val = (Int16)expr_value;
                Console.WriteLine(val);
            }
            else if (expr_datatype == "ص_٤")
            {
                Int32 val = (Int32)expr_value;
                Console.WriteLine(val);
            }
            else if (expr_datatype == "ص_٨")
            {
                Int64 val = (Int64)expr_value;
                Console.WriteLine(val);
            }
            else if (expr_datatype == "ط_١")
            {
                byte val = (byte)expr_value;
                Console.WriteLine(val);
            }
            else if (expr_datatype == "ط_٢")
            {
                UInt16 val = (UInt16)expr_value;
                Console.WriteLine(val);
            }
            else if (expr_datatype == "ط_٤")
            {
                UInt32 val = (UInt32)expr_value;
                Console.WriteLine(val);
            }
            else if (expr_datatype == "ط_٨")
            {
                UInt64 val = (UInt64)expr_value;
                Console.WriteLine(val);
            }
            else if (expr_datatype == "منطقي")
            {
                Boolean val = (Boolean)expr_value;
                Console.WriteLine(val);
            }
            else {
                Console.WriteLine($"Undefinede datatype: {expr_datatype}.");
            }
    }

    public static BigInteger get_big_integer(Object value, string datatype)
    {
        if(datatype == "ط_١")
        {
            return new BigInteger((Byte)(value));
        }
        else if( datatype == "ط_٢")
        {
            return new BigInteger((UInt16)(value));

        }
        else if( datatype == "ط_٤")
        {
            return new BigInteger((UInt32)(value));
            
        }
        else if( datatype == "ط_٨")
        {
            return new BigInteger((UInt64)(value));
            
        }
        else if(datatype == "ص_١")
        {
            return new BigInteger((SByte)(value));

        }
        else if( datatype == "ص_٢")
        {
            return new BigInteger((Int16)(value));

        }
        else if( datatype == "ص_٤")
        {
            return new BigInteger((Int32)(value));
            
        }
        else if( datatype == "ص_٨")
        {
            return new BigInteger((Int64)(value));
            
        }
        else {
            throw new Exception($"Undefined datatype for number. {datatype}");
        }
    }
}