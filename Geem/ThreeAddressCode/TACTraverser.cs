namespace Geem.ThreeAddressCode;
using static Geem.Parser.GeemParser;
using Antlr4.Runtime.Tree;

public class OperationData 
{
    public Dictionary<string, int>parameters_data;
    public Dictionary<string, int>variables_data;

    public OperationData() {
        this.parameters_data = new Dictionary<string, int>();
        this.variables_data = new Dictionary<string, int>();
    }
}

public class FunctionData 
{
    public Dictionary<string, int>parameters_data;
    public Dictionary<string, int>variables_data;
    public FunctionData() {
        this.parameters_data = new Dictionary<string, int>();
        this.variables_data = new Dictionary<string, int>();
    }
}
public class TACTraverse {
    public static Dictionary<string, OperationData> operations_data = new Dictionary<string, OperationData>();

    public static Dictionary<string, FunctionData> functions_data = new Dictionary<string, FunctionData>();
    
    public static Dictionary<string, int> labels = new Dictionary<string, int>();

    public static int next_inst_index = 0;
    public static List<Instruction> instructions = new List<Instruction>();
    
    public void Traverse(IParseTree node)
    {
        if(node is ProgramContext)
        {
            var programContext = (ProgramContext) node;
            
            foreach(var sub_node in programContext.children) 
            {
                Traverse(sub_node);
            }
        }
        else if(node is OperationDeclContext)
        {
            var operationDecl = (OperationDeclContext) node;
            labels[operationDecl.ID().GetText()] = next_inst_index++;
            operations_data[operationDecl.ID().GetText()] = new OperationData();
            // reserve space on the stack for 
            // 1. last frame pointer.
            // 2. parameters of the operation.
            // 3. variables of the operations.
            var parameters = operationDecl.paramList().parameter();
            var variables_decl = operationDecl.statementList().statement().OfType<Var_Decl_StatContext>();

            // calculating the required stack frame size.
            int frame_size = 1 + parameters.Count() + variables_decl.Count();


            // reserving space for the stack frame.

            instructions.Add(
                new AddI(
                    new Register(RegisterType.STACK_POINTER, 0),
                    new Register(RegisterType.STACK_POINTER, 0),
                        frame_size
                    )
            );

            // storing the last frame pointer.
            instructions.Add(
                new Store(
                    new Register(RegisterType.FRAME_POINTER, 0),
                    new Register(RegisterType.STACK_POINTER, 0),
                    -1 * frame_size + 1
                )
            );          
            // setting the new frame pointer.
            instructions.Add(
                new AddI(
                    new Register(RegisterType.STACK_POINTER, 0),
                    new Register(RegisterType.FRAME_POINTER, 0),
                    -1 * frame_size
                )
            );

            int index = 1;
            foreach(var parameter in parameters) 
            {
                // set the index of the parameter in the operation data structure.
                operations_data[operationDecl.ID().GetText()].parameters_data[parameter.ID().GetText()] = index++;

            }

            foreach(var variable_decl in variables_decl)
            {
                // set the index of the variable in the operation data structure.
                operations_data[operationDecl.ID().GetText()].variables_data[variable_decl.varDecl().ID().GetText()] = index++;
            }

            foreach(var statement in operationDecl.statementList().statement())
            {
                if(statement is not Var_Decl_StatContext)
                {
                    Traverse(statement);
                }
            }
            // resetting the frame pointer to the old one.
            instructions.Add(
                new Load(
                    new Register(RegisterType.FRAME_POINTER, 0),
                    new Register(RegisterType.STACK_POINTER, 0),
                    -1 * frame_size + 1
                )
            );

            // deleting the frame pointer.
            instructions.Add(
                new AddI(
                    new Register(RegisterType.STACK_POINTER, 0),
                    new Register(RegisterType.STACK_POINTER, 0),
                    -1 * frame_size
                )
            );
        }
        else if(node is FunctionDeclContext)
        {
            
            var functionDecl = (FunctionDeclContext) node;
            labels[functionDecl.ID().GetText()] = next_inst_index++;
            functions_data[functionDecl.ID().GetText()] = new FunctionData();
            // reserve space on the stack for 
            // 1. last frame pointer.
            // 2. parameters of the operation.
            // 3. variables of the operations.
            var parameters = functionDecl.paramList().parameter();
            var variables_decl = functionDecl.statementList().statement().OfType<Var_Decl_StatContext>();

            // calculating the required stack frame size.
            int frame_size = 1 + parameters.Count() + variables_decl.Count();


            // reserving space for the stack frame.

            instructions.Add(
                new AddI(
                    new Register(RegisterType.STACK_POINTER, 0),
                    new Register(RegisterType.STACK_POINTER, 0),
                        frame_size
                    )
            );

            // storing the last frame pointer.
            instructions.Add(
                new Store(
                    new Register(RegisterType.FRAME_POINTER, 0),
                    new Register(RegisterType.STACK_POINTER, 0),
                    -1 * frame_size + 1
                )
            );          
            // setting the new frame pointer.
            instructions.Add(
                new AddI(
                    new Register(RegisterType.STACK_POINTER, 0),
                    new Register(RegisterType.FRAME_POINTER, 0),
                    -1 * frame_size
                )
            );

            int index = 1;
            foreach(var parameter in parameters) 
            {
                // set the index of the parameter in the operation data structure.
                functions_data[functionDecl.ID().GetText()].parameters_data[parameter.ID().GetText()] = index++;

            }

            foreach(var variable_decl in variables_decl)
            {
                // set the index of the variable in the operation data structure.
                functions_data[functionDecl.ID().GetText()].variables_data[variable_decl.varDecl().ID().GetText()] = index++;
            }

            foreach(var statement in functionDecl.statementList().statement())
            {
                if(statement is not Var_Decl_StatContext)
                {
                    Traverse(statement);
                }
            }
            // resetting the frame pointer to the old one.
            instructions.Add(
                new Load(
                    new Register(RegisterType.FRAME_POINTER, 0),
                    new Register(RegisterType.STACK_POINTER, 0),
                    -1 * frame_size + 1
                )
            );

            // deleting the frame pointer.
            instructions.Add(
                new AddI(
                    new Register(RegisterType.STACK_POINTER, 0),
                    new Register(RegisterType.STACK_POINTER, 0),
                    -1 * frame_size
                )
            );
        }
    }
}