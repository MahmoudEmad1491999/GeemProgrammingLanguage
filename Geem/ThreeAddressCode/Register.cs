namespace Geem.ThreeAddressCode;

public enum RegisterType
{
    ZERO,
    RETURN_ADDRESS,
    STACK_POINTER,
    GLOBAL_POINTER,
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
}


