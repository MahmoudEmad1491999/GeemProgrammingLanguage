namespace Geem.ThreeAddressCode;

public abstract class Instruction {

}

public class Add:Instruction {
    public Register src1;
    public Register src2;

    public Register dest;

    public Add(Register src1, Register src2, Register dest)
    {
        if(src1 == null)
        {
            throw new ArgumentNullException();
        }
        this.src1 = src1;
        if(src2 == null)
        {
            throw new ArgumentNullException();
        }
        this.src2 = src2;
        if(dest == null)
        {
            throw new ArgumentNullException();
        }
        this.dest = dest;
    }

    public override string ToString()
    {
        return $"add {dest.ToString()}, {src1.ToString()},{src2.ToString()};";
    }
}

public class AddI : Instruction {
    public Register src1;
    public Register dest;
    public int immed;

    public AddI(Register src1, Register dest, int immed)
    {
        if(src1 == null)
        {
            throw new ArgumentNullException();
        }
        this.src1 = src1;
        if(dest == null)
        {
            throw new ArgumentNullException();
        }
        this.dest = dest;
        this.immed = immed;
    }

    public override string ToString()
    {
        return $"addi {dest.ToString()}, {src1.ToString()},{immed};";
    }
}

public class Subtract:Instruction {
    public Register src1;
    public Register src2;

    public Register dest;

    public Subtract(Register src1, Register src2, Register dest)
    {
        if(src1 == null)
        {
            throw new ArgumentNullException();
        }
        this.src1 = src1;
        if(src2 == null)
        {
            throw new ArgumentNullException();
        }
        this.src2 = src2;
        if(dest == null)
        {
            throw new ArgumentNullException();
        }
        this.dest = dest;
    }

    public override string ToString()
    {
        return $"sub {dest.ToString()}, {src1.ToString()},{src2.ToString()};";
    }
}

public class Multiply:Instruction {
    public Register src1;
    public Register src2;

    public Register dest;

    public Multiply(Register src1, Register src2, Register dest)
    {
        if(src1 == null)
        {
            throw new ArgumentNullException();
        }
        this.src1 = src1;
        if(src2 == null)
        {
            throw new ArgumentNullException();
        }
        this.src2 = src2;
        if(dest == null)
        {
            throw new ArgumentNullException();
        }
        this.dest = dest;
    }

    public override string ToString()
    {
        return $"mul {dest.ToString()}, {src1.ToString()},{src2.ToString()};";
    }
}

public class Divide:Instruction {
    public Register src1;
    public Register src2;

    public Register dest;

    public Divide(Register src1, Register src2, Register dest)
    {
        if(src1 == null)
        {
            throw new ArgumentNullException();
        }
        this.src1 = src1;
        if(src2 == null)
        {
            throw new ArgumentNullException();
        }
        this.src2 = src2;
        if(dest == null)
        {
            throw new ArgumentNullException();
        }
        this.dest = dest;
    }
    public override string ToString()
    {
        return $"div {dest.ToString()}, {src1.ToString()},{src2.ToString()};";
    }
}

public class Load: Instruction {
    public Register loaded_register;
    public Register base_address;
    public int offset;
    public Load(Register loaded_register, Register base_address, int offset)
    {
        if(loaded_register == null) 
        {
            throw new ArgumentNullException();
        }
        this.loaded_register = loaded_register;
        if(base_address == null)
        {
            throw new ArgumentNullException();
        }
        this.base_address = base_address;
        this.offset = offset;
    }
    public override string ToString()
    {
        return $"read {base_address.ToString()}({offset}) -> {loaded_register.ToString()};";
    }
}

public class Store: Instruction {
    public Register stored_register;
    public Register base_address;
    public int offset;
    public Store(Register stored_register, Register base_address, int offset)
    {
        if(stored_register == null) 
        {
            throw new ArgumentNullException();
        }
        this.stored_register = stored_register;
        if(base_address == null)
        {
            throw new ArgumentNullException();
        }
        this.base_address = base_address;
        this.offset = offset;
    }
    public override string ToString()
    {
        return $"write {stored_register.ToString()} -> {base_address.ToString()}({offset});";
    }
}

public class Jump: Instruction 
{
    public int address;
    public Jump(int address)
    {
        this.address = address;
    }
}
public class Jump_Relative : Instruction 
{
    public int offset;
    public Jump_Relative(int offset)
    {
        this.offset = offset;
    }
}

public class Jump_Link: Instruction {
    public int address;
    
    public Jump_Link(int address)
    {
        this.address = address;
    }

}

public class Return:Instruction {
    public Return()
    {

    }
    public override string ToString()
    {
        return "return ;";
    }
}
public class Branch_Equal: Instruction {
    public int offset;

    public Register src1;
    public Register src2;

    public Branch_Equal(Register src1, Register src2, int offset)
    {
        if(src1 == null)
        {
            throw new ArgumentNullException();
        }
        this.src1 = src1;
        if(src2 == null){
            throw new ArgumentNullException();
        }
        this.src2 = src2;
        this.offset = offset;
    }
}

public class Branch_Not_Equal : Instruction 
{
    public int offset;
    public Register src1;
    public Register src2;

    public Branch_Not_Equal(Register src1, Register src2, int offset)
    {
        if(src1 == null)
        {
            throw new ArgumentNullException();
        }
        this.src1 = src1;
        if(src2 == null){
            throw new ArgumentNullException();
        }
        this.src2 = src2;
        this.offset = offset;
    }
}

public class Branch_Greater_Than : Instruction 
{
    public int offset;
    public Register src1;
    public Register src2;

    public Branch_Greater_Than(Register src1, Register src2, int offset)
    {
        if(src1 == null)
        {
            throw new ArgumentNullException();
        }
        this.src1 = src1;
        if(src2 == null){
            throw new ArgumentNullException();
        }
        this.src2 = src2;
        this.offset = offset;
    }
}

public class Branch_Greater_Than_Equal : Instruction 
{
    public int offset;
    public Register src1;
    public Register src2;

    public Branch_Greater_Than_Equal(Register src1, Register src2, int offset)
    {
        if(src1 == null)
        {
            throw new ArgumentNullException();
        }
        this.src1 = src1;
        if(src2 == null){
            throw new ArgumentNullException();
        }
        this.src2 = src2;
        this.offset = offset;
    }
}

public class Branch_Less_Than : Instruction 
{
    public int offset;
    public Register src1;
    public Register src2;

    public Branch_Less_Than(Register src1, Register src2, int offset)
    {
        if(src1 == null)
        {
            throw new ArgumentNullException();
        }
        this.src1 = src1;
        if(src2 == null){
            throw new ArgumentNullException();
        }
        this.src2 = src2;
        this.offset = offset;
    }
}

public class Branch_Less_Than_Equal : Instruction 
{
    public int offset;
    public Register src1;
    public Register src2;

    public Branch_Less_Than_Equal(Register src1, Register src2, int offset)
    {
        if(src1 == null)
        {
            throw new ArgumentNullException();
        }
        this.src1 = src1;
        if(src2 == null){
            throw new ArgumentNullException();
        }
        this.src2 = src2;
        this.offset = offset;
    }
}
