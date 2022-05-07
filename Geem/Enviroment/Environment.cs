namespace Geem.Environment;

public enum SymbolType
{
    FUNCTION,
    OPERATION,
    GLOBALVAR,
    PARAMETER,
    LOCALVAR,
}

public abstract class SymbolTableEntry
{
    public string identifier{get;}
    public SymbolType symbol_type{get;}

    public SymbolTableEntry(string _identifier, SymbolType _symbol_type)
    {
        if (_identifier == null)
        {
            throw new ArgumentNullException("symbol identifier cannot be null");
        }
        if (_identifier.Length == 0)
        {
            throw new ArgumentNullException("symbol identifier cannot be empty");
        }
        this.identifier = _identifier;

        this.symbol_type = _symbol_type;
    }
    public override bool Equals(object? obj)
    {
        if (obj is SymbolTableEntry)
        {
            var _obj = (SymbolTableEntry)obj;
            return _obj.identifier == this.identifier;
        }
        return false;
    }

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }
}

public class FunctionSymbolTableEntry : SymbolTableEntry
{
    public string return_type {get;}
    public List<string> parameters_datatypes{get;}
    public FunctionSymbolTableEntry(string _identifier, string _return_type, List<string> _parameters_datatypes) : base(_identifier, SymbolType.FUNCTION)
    {
        if(_return_type == null)
        {
            throw new ArgumentNullException("return_type string cannot be null");

        }else if(_return_type.Length == 0)
        {
            throw new ArgumentException("return_type length cannot be zero");
        }
        else {
            this.return_type = _return_type;
        }

        if(_parameters_datatypes == null)
        {
            throw new ArgumentNullException("parameter_datatype list cannot be null");
        }
        this.parameters_datatypes = _parameters_datatypes;
    }
}
public class OperationSymbolTableEntry : SymbolTableEntry
{
    public List<string> parameter_datatypes;
    public OperationSymbolTableEntry(string _identifier, List<string> _parameter_datatypes) : base(_identifier, SymbolType.OPERATION)
    { 
        if(_parameter_datatypes != null)
        {
            this.parameter_datatypes = _parameter_datatypes;
        }else {
            throw new ArgumentNullException("parameter_datatype list cannot be null");
        }
    }
}

public class ParameterSymbolTableEntry : SymbolTableEntry
{
    public string datatype{get;}
    public Object value{get;}
    public ParameterSymbolTableEntry(string _identifier, string _datatype, Object _value) : base(_identifier, SymbolType.PARAMETER)
    {
        if(_datatype == null)
        {
            throw new ArgumentNullException("parameter datatype cannot be null");

        }else if(_datatype.Length == 0)
        {
            throw new ArgumentException("parameter datatype length cannot be zero");
        }else {
            this.datatype = _datatype;
        }

        if(_value == null)
        {
            throw new ArgumentNullException("_value of a parameter cannot be null");
        }else {
            this.value = _value;
        }
    }
}
public class GlobalVarSymbolTableEntry : SymbolTableEntry
{
    public string datatype{get;}
    public Object value {get; set;}
    public GlobalVarSymbolTableEntry(string _identifier, string _datatype, Object _value) : base(_identifier, SymbolType.GLOBALVAR)
    {
        if(_datatype == null)
        {
            throw new ArgumentNullException("parameter datatype cannot be null");

        }else if(_datatype.Length == 0)
        {
            throw new ArgumentException("parameter datatype length cannot be zero");
        }else {
            this.datatype = _datatype;
        }
        if(_value == null)
        {
            throw new ArgumentNullException("_value of a parameter cannot be null");
        }else {
            this.value = _value;
        }
    }
}
public class LocalVarSymbolTableEntry : SymbolTableEntry
{
    public string datatype{get;}
    public Object value {get; set;}
    public LocalVarSymbolTableEntry(string _identifier, string _datatype, Object _value) : base(_identifier, SymbolType.LOCALVAR)
    {
        if(_datatype == null)
        {
            throw new ArgumentNullException("parameter datatype cannot be null");

        }else if(_datatype.Length == 0)
        {
            throw new ArgumentException("parameter datatype length cannot be zero");
        }else {
            this.datatype = _datatype;
        }
        if(_value == null)
        {
            throw new ArgumentNullException("_value of a parameter cannot be null");
        }else {
            this.value = _value;
        }
    }
}

public abstract class SymbolTable
{
    public List<SymbolTableEntry> symbols;
    public List<SymbolTable> sub_tables;
    public SymbolTable? parent;
    public string identifier;
    public SymbolTable(SymbolTable? parent, string identifier)
    {

        this.symbols = new List<SymbolTableEntry>();
        if (parent != null)
        {
            this.parent = parent;
        }
        if(identifier != null)
        {
            this.identifier = identifier;
        }
        else { 
            throw new Exception("symbol table identifiers cannot be null");
        }   
        this.sub_tables = new List<SymbolTable>();
    }
    public void add_symbol(SymbolTableEntry? symbol_table_entry)
    {
        if (symbol_table_entry != null)
        {
            if (this.is_identifier_reserved(symbol_table_entry.identifier))
            {
                throw new Exception("Identifier is reserved: " + symbol_table_entry.identifier);
            }
            else
            {
                this.symbols.Add(symbol_table_entry);
            }

        }

    }
    public bool is_identifier_reserved(string identifier)
    {
        if(!symbols.Exists((SymbolTableEntry entry) => identifier == entry.identifier))
        {
            if(parent != null)
            {
                if(!parent.is_identifier_reserved(identifier))
                {
                    return false;
                }
                else {
                    return true;
                }
            }else {
                return false;
            }
            
        }else {
            return true;
        }
    }
    public SymbolTableEntry get_symbol_by_id(string identifier)
    {
        var symbol_table_entry = symbols.Find((SymbolTableEntry entry) => identifier == entry.identifier);
        if(symbol_table_entry != null)
        {
            return symbol_table_entry;
        }else {
            if(parent != null)
            {
                symbol_table_entry = parent.get_symbol_by_id(identifier);
                if(symbol_table_entry != null)
                {
                    return symbol_table_entry;
                }
                else{
                    throw new Exception($"There is not symbol with the identifier: {identifier}");
                }
            }else {
                throw new Exception($"There is not symbol with the identifier: {identifier}");
            }
        }
    }
    public void add_sub_table(SymbolTable? sub_table)
    {
        if(sub_table != null)
        {
            this.sub_tables.Add(sub_table);
        }
    }
}

public class FunctionSymbolTable : SymbolTable
{
    public FunctionSymbolTable(SymbolTable? parent, string identifier) : base(parent, identifier)
    {
    }
}
public class OperationSymbolTable : SymbolTable
{
    public OperationSymbolTable(SymbolTable? parent, string identifier) : base(parent, identifier)
    {
    }
}

public class ProgramSymbolTable : SymbolTable
{
    public ProgramSymbolTable(SymbolTable? parent, string identifier) : base(parent, identifier)
    {
    }
}


