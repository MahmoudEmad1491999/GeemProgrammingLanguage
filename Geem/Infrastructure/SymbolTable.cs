namespace Geem.Infrastructure;

using System.Collections.Generic;

public enum SymbolType {
    SymbolOfFunction,
    SymbolOfOperation,
    SymbolOfGlobalVariable,
    SymbolOfLocalVariable,
    SymbolOfParameter,
}
public enum SymbolTableType {
    SymbolTableOfFunction,
    SymbolTableOfFile,
    SymbolTableOfOperation,
}
public class SymbolInfo 
{
    public SymbolType type {get; set;}
    public SymbolSpecificInfo specificInfo {get; set;}
    public SymbolInfo(SymbolType type, SymbolSpecificInfo specificInfo)
    {
        this.type = type;
        this.specificInfo = specificInfo;
    }
    

}
public abstract class SymbolSpecificInfo {

}

public class VarInfo: SymbolSpecificInfo 
{
    public string datatype {get; set;}
    public Object cvalue {get; set;}

    public VarInfo(string datatype, Object cvalue)
    {
        this.datatype = datatype;
        this.cvalue = cvalue;
    }

}


public class FunctionInfo: SymbolSpecificInfo 
{
    public string[] parameter_datatypes {get; set;}
    public string return_type {get; set;}

    public FunctionInfo(string[] parameter_datatypes, string return_type)
    {
        this.parameter_datatypes = parameter_datatypes;
        this.return_type = return_type;
    }    
}

public class OperationInfo: SymbolSpecificInfo 
{
    public string[] parameter_datatypes {get; set;}

    public OperationInfo(string[] parameter_datatypes)
    {
        this.parameter_datatypes = parameter_datatypes;
    }    
}
public class SymbolTable : Dictionary<string, SymbolInfo>
{
    public SymbolTable parent {get; set;}
    public SymbolTableType table_type {get; set;}
    public string symbol_table_name {get; set;}
    
    public SymbolTable(SymbolTable parent, SymbolTableType table_type, string symbol_table_name) {
        this.table_type = table_type;
        this.symbol_table_name = symbol_table_name;
        this.parent = parent;
    }
    public Boolean SymbolExist(string symbol_identifier)
    {
        if(this.ContainsKey(symbol_identifier)) return true;
        if(this.parent is not null) if(this.parent.ContainsKey(symbol_identifier)) return true;
        return false;
    }
    public Boolean SymbolExistInParent(string symbol_identifier)
    {
        if(this.parent is not null) if(this.parent.ContainsKey(symbol_identifier)) return true;
        return false;
    }
    public SymbolInfo getSymbolInfo(string symbol_identifier)
    {
        if(SymbolExist(symbol_identifier)) return this[symbol_identifier];
        if(SymbolExistInParent(symbol_identifier)) return this.parent[symbol_identifier];
        throw new Exception("Symbol Not Found!");
    }

    public void addSymbol(string symbol_name, SymbolInfo symbolInfo)
    {
        if(SymbolExist(symbol_name))
        {
            throw new Exception("Symbol Table already contain this Symbol");
        } 
        else {
            if(SymbolExistInParent(symbol_name))
            {
                if(this.parent is not null ) {
                    if(this.parent[symbol_name].type == SymbolType.SymbolOfGlobalVariable)
                    {
                        this[symbol_name] = symbolInfo;
                    }
                
                }
                throw new Exception("Symbol Table already contain this Symbol");
            }
            else {
                this[symbol_name] = symbolInfo;
            }
        }
        
    }

}