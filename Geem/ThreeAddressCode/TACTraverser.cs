namespace Geem.ThreeAddressCode;
using static Geem.Parser.GeemParser;
using Antlr4.Runtime.Tree;

public class TACTraverse {
    private static List<Instruction> text_segment = new List<Instruction>();
    public void Traverse(IParseTree node)
    {
        if(node is ProgramContext)
        {
            var programContext = (ProgramContext) node;

            for(int index = 0; index < programContext.ChildCount; index++)
            {
                Traverse(programContext.children[index]);
            }
        }
        else if(node is FunctionDeclContext)
        {
            
        }
    }
}