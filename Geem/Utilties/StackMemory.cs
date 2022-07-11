namespace Geem.Utilities;

public class StackMemory
{
    public int next_aval;
    public int frame_index;

    public Object[] mem;

    public StackMemory(int size)
    {
        mem = new Object[size];
        this.next_aval = 0;
        this.frame_index = 0;
    }

}