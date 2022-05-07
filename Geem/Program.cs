[assembly: CLSCompliant(false)]

namespace Geem;
using Antlr4.Runtime.Tree;
using Antlr4.Runtime;
using Geem.Parser;
using Geem.Traversers;
using System.IO;
using System.Text;
using System.Text.Encodings;
public class Program {
    public static void Main(String[] args)
    {
        string test_file_path = "/home/mahmoud/test.arac";
        string file_content = File.ReadAllText(test_file_path);

        ICharStream char_stream = CharStreams.fromstring(file_content);
        ITokenSource token_source = new GeemLexer(char_stream);
        ITokenStream token_stream = new CommonTokenStream(token_source);
        GeemParser geem_parser = new GeemParser(token_stream);

        IParseTree root = geem_parser.program();
        
        // task 1 implement the graph generator.        
        var graph_file = File.CreateText("/home/mahmoud/test.dot");
        graph_file.WriteLine( " digraph test {\n" + GraphGeneratorTraverser.GenerateGraph(root, 0) + "\n}");
        
        graph_file.Close();
        
        // task 2 implement the symbol table and validate code.
        
        var symbol_table = GenerateSymbolTableTraverser.GenerateSymbolTable(root, null);
        
        // if(symbol_table != null)
        // {
        //     foreach(var symbol in symbol_table.symbols) 
        //     {
        //         Console.WriteLine(symbol.identifier);
        //     }
        
        // }
        
        InterpreterTraverser.run(root, symbol_table);

    }
}