[assembly: CLSCompliant(false)]

namespace Geem;
using Antlr4.Runtime.Tree;
using Antlr4.Runtime;
using Geem.Parser;
using Geem.Utilities;
using System.Text;
using System.Text.Encodings;
using System.IO;

using static Geem.Parser.GeemParser;
using Geem.Visitors;
public class Program {
    public static void Main(String[] args)
    {
        string test_file_path = "/home/mahmoud/geem_files/test5.geem";
        string file_content = File.ReadAllText(test_file_path);

        ICharStream char_stream = CharStreams.fromString(file_content);
        ITokenSource token_source = new GeemLexer(char_stream);
        ITokenStream token_stream = new CommonTokenStream(token_source);
        GeemParser geem_parser = new GeemParser(token_stream);
        
        IParseTree root = geem_parser.program();
        
        ProgramContext root_t = (ProgramContext) root;
        
        ConstructSymbolTableVisitor v1 = new ConstructSymbolTableVisitor();
        v1.Visit(root);
        
        TypeMismatchValidator v2 = new TypeMismatchValidator();
        v2.Visit(root);


        // UsedBeforeDeclaration v3 = new UsedBeforeDeclaration();
        // v3.Visit(root);


        InterpreterVisitor v4 = new InterpreterVisitor();
        v4.Visit(root);
        
        
        string dot_graph = GraphGeneratorTraverser.GenerateGraph(root);
       
        File.WriteAllBytes("/home/mahmoud/geem_files/test5.dot", UnicodeEncoding.UTF8.GetBytes(dot_graph));
        
    }
}
