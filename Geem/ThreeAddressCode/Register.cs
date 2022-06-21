namespace Geem.ThreeAddressCode;

public enum RegisterType
{
    ZERO,
    RETURN_ADDRESS,
    STACK_POINTER,
    GLOBAL_POINTER,
    FRAME_POINTER,
    // THREAD_POINTER,
    TEMP_REG,
    ARG_REG,
    RETURN_VALUE,
    SAVED_REG
}

public class Register 
{
    public RegisterType reg_type;
    public int number;
    public Register(RegisterType reg_type, int number)
    {
        this.reg_type = reg_type;
        this.number = number;
    }

    public override string ToString()
    {
        if(reg_type == RegisterType.ZERO)
        {
            return "$zero";
        }
        else if(reg_type == RegisterType.FRAME_POINTER)
        {
            return "$fp";
        }
        else if(reg_type == RegisterType.STACK_POINTER)
        {
            return "$sp";
        }
        else if(reg_type == RegisterType.GLOBAL_POINTER)
        {
            return "$gp";
        }
        else if(reg_type == RegisterType.RETURN_VALUE)
        {
            return $"$rv_{number}";
        }
        else if(reg_type == RegisterType.SAVED_REG)
        {
            return $"$sr_{number}";
        }
        else if(reg_type == RegisterType.RETURN_ADDRESS)
        {
            return $"ra";
        }
        else if(reg_type == RegisterType.TEMP_REG)
        {
            return $"t_{number}";
        }
        else {
            throw new Exception();
        }
    }
}


