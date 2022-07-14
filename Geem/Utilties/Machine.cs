namespace Geem.Utilities;

public class Machine
{
    public Boolean do_break = false;
    public Boolean do_continue = false;
    public Boolean do_terminate = false;
    public Dictionary<string, Dictionary<string, int>> local_variables_indices = new Dictionary<string, Dictionary<string, int>>();
    public Dictionary<string, int> gvar_indices = new Dictionary<string, int>();

    public Object[] mem;
    public int next_aval;
    public int frame_index;
    public Stack<Object> function_return_values = new Stack<object>();

    public Machine(int mem_size)
    {
        mem = new Object[mem_size];
    }
}