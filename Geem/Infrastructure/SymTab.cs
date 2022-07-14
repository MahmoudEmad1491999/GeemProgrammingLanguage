// namespace Geem.Infrastructure;

// using System.Collections.Generic;
// using System.Text;
// using static Geem.Parser.GeemParser;
// public enum SymbolType {
//     SymbolOfFunction,
//     SymbolOfOperation,
//     SymbolOfGlobalVariable,
//     SymbolOfLocalVariable,
//     SymbolOfParameter,
// }
// public enum SymbolTableType {
//     SymbolTableOfFunction,
//     SymbolTableOfFile,
//     SymbolTableOfOperation,
// }
// public abstract class SymbolInfo 
// {
//     public SymbolType type {get; set;}
//     public SymbolInfo(SymbolType type)
//     {
//         this.type = type;
//     }

//     public override string ToString()
//     {
//         return $"type: {type.ToString()}";
//     }
// }

// public class VarInfo: SymbolInfo 
// {
//     public string datatype {get; set;}

//     public VarInfo(string datatype, SymbolType type): base(type)
//     {
//         this.datatype = datatype;
        
//     }
//     public override string ToString()
//     {
//         return $"datatype: {datatype}";
//     }
// }


// public class FunctionInfo: SymbolInfo 
// {
//     public string[] parameter_datatypes {get; set;}
//     public string return_type {get; set;}
//     public FunctionDeclContext node {get; set;}
//     public FunctionInfo(string return_type, string[] parameter_datatypes, FunctionDeclContext node):base(SymbolType.SymbolOfFunction)
//     {
//         this.parameter_datatypes = parameter_datatypes;
//         this.return_type = return_type;
//         this.node = node;
//     }
//     public override string ToString()
//     {
//         StringBuilder result = new StringBuilder();
//         for(int x = 0; x< parameter_datatypes.Length; x++)
//         {
//             result.Append(parameter_datatypes[x]);
//         }
//         return $"return type: {return_type}, parameter datatypes: {result.ToString()}";
//     }
// }

// public class OperationInfo: SymbolInfo 
// {
//     public string[] parameter_datatypes {get; set;}
//     public OperationDeclContext node {get; set;}
//     public OperationInfo(string[] parameter_datatypes, OperationDeclContext node):base(SymbolType.SymbolOfOperation)
//     {
//         this.parameter_datatypes = parameter_datatypes;
//         this.node = node;
//     }
//     public override string ToString()
//     {
//         StringBuilder result = new StringBuilder();
//         for(int x = 0; x< parameter_datatypes.Length; x++)
//         {
//             result.Append(parameter_datatypes[x]);
//         }
//         return $"parameter datatypes: {result.ToString()}";
//     }
// }
// public class SymbolTable : Dictionary<string, SymbolInfo>
// {
//     public SymbolTable parent {get; set;}
//     public SymbolTableType table_type {get; set;}
//     public string symbol_table_name {get; set;}
    
//     public SymbolTable(SymbolTable parent, SymbolTableType table_type, string symbol_table_name) {
//         this.table_type = table_type;
//         this.symbol_table_name = symbol_table_name;
//         this.parent = parent;
//     }
//     public Boolean SymbolExist(string symbol_identifier)
//     {
//         return this.ContainsKey(symbol_identifier);
        
//     }
//     public Boolean SymbolExistInParent(string symbol_identifier)
//     {
//         if(this.parent is not null) 
//         {
//             if(this.parent.ContainsKey(symbol_identifier)) 
//             {
//                 return true;
//             }
//         }
//         return false;
//     }
//     public SymbolInfo getSymbolInfo(string symbol_name)
//     {
//         if(SymbolExist(symbol_name)) return this[symbol_name];
//         if(SymbolExistInParent(symbol_name)) return this.parent[symbol_name];
//         throw new Exception($"Symbol Not Found!: {symbol_name}");
//     }
//     public void setSymbolInfo(string symbol_name, SymbolInfo symbolInfo){
//         if(SymbolExist(symbol_name)) this[symbol_name] = symbolInfo;
//         if(SymbolExistInParent(symbol_name)) this.parent[symbol_name] = symbolInfo;
//         throw new Exception($"Symbol Not Found!: {symbol_name}");
//     }
//     public void addSymbol(string symbol_name, SymbolInfo symbolInfo)
//     {
//         if(SymbolExist(symbol_name))
//         {
//             throw new Exception($"Symbol Table already contain this Symbol: \"{symbol_name}\" " + getSymbolInfo(symbol_name));
//         } 
//         else {
//             if(SymbolExistInParent(symbol_name))
//             {
//                 if(this.parent is not null ) {
//                     if(this.parent[symbol_name].type == SymbolType.SymbolOfGlobalVariable)
//                     {
//                         this[symbol_name] = symbolInfo;
//                     }
                
//                 }
//                 throw new Exception($"Symbol Table already contain this Symbol: {symbol_name}");
//             }
//             else {
//                 this[symbol_name] = symbolInfo;
//             }
//         }
        
//     }

// }