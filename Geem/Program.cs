[assembly: CLSCompliant(false)]

namespace Geem;
using Antlr4.Runtime.Tree;
using Antlr4.Runtime;
using Geem.Parser;
using Geem.Traversers;
using System.IO;
using ThreeAddressCode;
using static Geem.Parser.GeemParser;
public class Program {
    public static void Main(String[] args)
    {
        string test_file_path = "/home/mahmoud/test.geem";
        string file_content = File.ReadAllText(test_file_path);

        ICharStream char_stream = CharStreams.fromstring(file_content);
        ITokenSource token_source = new GeemLexer(char_stream);
        ITokenStream token_stream = new CommonTokenStream(token_source);
        GeemParser geem_parser = new GeemParser(token_stream);

        IParseTree root = geem_parser.program(new Infrastructure.SymbolTable(null, Infrastructure.SymbolTableType.SymbolTableOfFile, "program"));
        
        ProgramContext root_t = (ProgramContext) root;
        
        // Console.WriteLine(root_t.st.Count());
        
        // Console.WriteLine(root_t.st.parent == null);
        // foreach(var item in root_t.st)
        // {
        //     Console.WriteLine(item.Key + item.Value.type);
        // }
        // task 1 implement the graph generator.        
        var graph_file = File.CreateText("/home/mahmoud/test.dot");
        graph_file.WriteLine( " digraph test {\n" + GraphGeneratorTraverser.GenerateGraph(root, 0) + "\n}");
        
        graph_file.Close();
        
        // task 2 implement the symbol table and validate code.
        
        // var symbol_table = GenerateSymbolTableTraverser.GenerateSymbolTable(root, null);
        
        // if(symbol_table != null)
        // {
        //     foreach(var symbol in symbol_table.symbols) 
        //     {
        //         Console.WriteLine(symbol.identifier);
        //     }
        
        // }
        
        // InterpreterTraverser.run(root, symbol_table);
        // var temp = new FakeISAGenerator();

        // var state = temp.traverse(root, null); 
        // int i = 0;
        // foreach(var item in state.initialized_data)
        // {
        //     Console.WriteLine("address: " + i++ + " : " + item);
        // }

        // var tac_traverser = new TACTraverse();

        // tac_traverser.Traverse(root);
        // foreach(var label in TACTraverse.labels)
        // {
        //     Console.WriteLine($"{label.Key}:");
        //     Console.WriteLine(label.Value.Item1 + " " + label.Value.Item2);
        //     for(int index = label.Value.Item1; index < label.Value.Item2; index++)
        //     {
        //         Console.WriteLine($"\t{TACTraverse.instructions[index]}");
        //     }
        // }
        
        Console.WriteLine("Hello There");
    }
}