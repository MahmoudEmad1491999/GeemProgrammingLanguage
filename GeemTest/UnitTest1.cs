using Xunit;

namespace GeemTest;
using Geem;
using Geem.Parser;
using Geem.Visitors;
using Geem.Utilities;
using static Geem.Parser.GeemParser;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System.Text;

using System.IO;


public class UnitTest1
{
    [Fact]
    public void simple_main_operation()
    {
        string test_file_path = "/home/mahmoud/geem_files/simple_main_operation.geem";
        string file_content = File.ReadAllText(test_file_path);

        ICharStream char_stream = CharStreams.fromString(file_content);
        ITokenSource token_source = new GeemLexer(char_stream);
        ITokenStream token_stream = new CommonTokenStream(token_source);
        GeemParser geem_parser = new GeemParser(token_stream);

        IParseTree root = geem_parser.program();

        ProgramContext root_t = (ProgramContext)root;

        ConstructSymbolTableVisitor v1 = new ConstructSymbolTableVisitor();
        v1.Visit(root);

        TypeMismatchValidator v2 = new TypeMismatchValidator();
        v2.Visit(root);


        // UsedBeforeDeclaration v3 = new UsedBeforeDeclaration();
        // v3.Visit(root);


        InterpreterVisitor v4 = new InterpreterVisitor();
        v4.Visit(root);


        string dot_graph = GraphGeneratorTraverser.GenerateGraph(root);

        File.WriteAllBytes("/home/mahmoud/geem_files/simple_main_operation.dot", UnicodeEncoding.UTF8.GetBytes(dot_graph));
    }
    [Fact]
    public void simple_main_operation_with_arithmetic_operations()
    {
        string test_file_path = "/home/mahmoud/geem_files/simple_main_operation_with_arithmetic_operations.geem";
        string file_content = File.ReadAllText(test_file_path);

        ICharStream char_stream = CharStreams.fromString(file_content);
        ITokenSource token_source = new GeemLexer(char_stream);
        ITokenStream token_stream = new CommonTokenStream(token_source);
        GeemParser geem_parser = new GeemParser(token_stream);

        IParseTree root = geem_parser.program();

        ProgramContext root_t = (ProgramContext)root;

        ConstructSymbolTableVisitor v1 = new ConstructSymbolTableVisitor();
        v1.Visit(root);

        TypeMismatchValidator v2 = new TypeMismatchValidator();
        v2.Visit(root);


        // UsedBeforeDeclaration v3 = new UsedBeforeDeclaration();
        // v3.Visit(root);


        InterpreterVisitor v4 = new InterpreterVisitor();
        v4.Visit(root);


        string dot_graph = GraphGeneratorTraverser.GenerateGraph(root);

        File.WriteAllBytes("/home/mahmoud/geem_files/simple_main_operation_with_arithmetic_operations.dot", UnicodeEncoding.UTF8.GetBytes(dot_graph));
    }
    [Fact]
    public void function_call_in_print_commands()
    {
        string test_file_path = "/home/mahmoud/geem_files/function_call_in_print_commands.geem";
        string file_content = File.ReadAllText(test_file_path);

        ICharStream char_stream = CharStreams.fromString(file_content);
        ITokenSource token_source = new GeemLexer(char_stream);
        ITokenStream token_stream = new CommonTokenStream(token_source);
        GeemParser geem_parser = new GeemParser(token_stream);

        IParseTree root = geem_parser.program();

        ProgramContext root_t = (ProgramContext)root;

        ConstructSymbolTableVisitor v1 = new ConstructSymbolTableVisitor();
        v1.Visit(root);

        TypeMismatchValidator v2 = new TypeMismatchValidator();
        v2.Visit(root);


        // UsedBeforeDeclaration v3 = new UsedBeforeDeclaration();
        // v3.Visit(root);


        InterpreterVisitor v4 = new InterpreterVisitor();
        v4.Visit(root);


        string dot_graph = GraphGeneratorTraverser.GenerateGraph(root);

        File.WriteAllBytes("/home/mahmoud/geem_files/function_call_in_print_commands.dot", UnicodeEncoding.UTF8.GetBytes(dot_graph));
    }
    [Fact]
    public void multiple_function_calls_in_expression_evaluation()
    {
        string test_file_path = "/home/mahmoud/geem_files/multiple_function_calls_in_expression_evaluation.geem";
        string file_content = File.ReadAllText(test_file_path);

        ICharStream char_stream = CharStreams.fromString(file_content);
        ITokenSource token_source = new GeemLexer(char_stream);
        ITokenStream token_stream = new CommonTokenStream(token_source);
        GeemParser geem_parser = new GeemParser(token_stream);

        IParseTree root = geem_parser.program();

        ProgramContext root_t = (ProgramContext)root;

        ConstructSymbolTableVisitor v1 = new ConstructSymbolTableVisitor();
        v1.Visit(root);

        TypeMismatchValidator v2 = new TypeMismatchValidator();
        v2.Visit(root);


        // UsedBeforeDeclaration v3 = new UsedBeforeDeclaration();
        // v3.Visit(root);


        InterpreterVisitor v4 = new InterpreterVisitor();
        v4.Visit(root);


        string dot_graph = GraphGeneratorTraverser.GenerateGraph(root);

        File.WriteAllBytes("/home/mahmoud/geem_files/function_call_in_print_command.dot", UnicodeEncoding.UTF8.GetBytes(dot_graph));
    }

    [Fact]
    public void function_with_parameter()
    {
        string test_file_path = "/home/mahmoud/geem_files/functions_with_parameter.geem";
        string file_content = File.ReadAllText(test_file_path);

        ICharStream char_stream = CharStreams.fromString(file_content);
        ITokenSource token_source = new GeemLexer(char_stream);
        ITokenStream token_stream = new CommonTokenStream(token_source);
        GeemParser geem_parser = new GeemParser(token_stream);

        IParseTree root = geem_parser.program();

        ProgramContext root_t = (ProgramContext)root;

        ConstructSymbolTableVisitor v1 = new ConstructSymbolTableVisitor();
        v1.Visit(root);

        TypeMismatchValidator v2 = new TypeMismatchValidator();
        v2.Visit(root);


        // UsedBeforeDeclaration v3 = new UsedBeforeDeclaration();
        // v3.Visit(root);


        InterpreterVisitor v4 = new InterpreterVisitor();
        v4.Visit(root);


        string dot_graph = GraphGeneratorTraverser.GenerateGraph(root);

        File.WriteAllBytes("/home/mahmoud/geem_files/functions_with_parameter.dot", UnicodeEncoding.UTF8.GetBytes(dot_graph));
    }
    [Fact]
    public void function_with_multiple_parameters()
    {
        string test_file_path = "/home/mahmoud/geem_files/function_with_multiple_parameters.geem";
        string file_content = File.ReadAllText(test_file_path);

        ICharStream char_stream = CharStreams.fromString(file_content);
        ITokenSource token_source = new GeemLexer(char_stream);
        ITokenStream token_stream = new CommonTokenStream(token_source);
        GeemParser geem_parser = new GeemParser(token_stream);

        IParseTree root = geem_parser.program();

        ProgramContext root_t = (ProgramContext)root;

        ConstructSymbolTableVisitor v1 = new ConstructSymbolTableVisitor();
        v1.Visit(root);

        TypeMismatchValidator v2 = new TypeMismatchValidator();
        v2.Visit(root);


        // UsedBeforeDeclaration v3 = new UsedBeforeDeclaration();
        // v3.Visit(root);


        InterpreterVisitor v4 = new InterpreterVisitor();
        v4.Visit(root);


        string dot_graph = GraphGeneratorTraverser.GenerateGraph(root);

        File.WriteAllBytes("/home/mahmoud/geem_files/function_with_multiple_parameters.dot", UnicodeEncoding.UTF8.GetBytes(dot_graph));
    }
    [Fact]
    public void function_with_conditionals()
    {
        string test_file_path = "/home/mahmoud/geem_files/function_with_conditionals.geem";
        string file_content = File.ReadAllText(test_file_path);

        ICharStream char_stream = CharStreams.fromString(file_content);
        ITokenSource token_source = new GeemLexer(char_stream);
        ITokenStream token_stream = new CommonTokenStream(token_source);
        GeemParser geem_parser = new GeemParser(token_stream);

        IParseTree root = geem_parser.program();

        ProgramContext root_t = (ProgramContext)root;

        ConstructSymbolTableVisitor v1 = new ConstructSymbolTableVisitor();
        v1.Visit(root);

        TypeMismatchValidator v2 = new TypeMismatchValidator();
        v2.Visit(root);


        // UsedBeforeDeclaration v3 = new UsedBeforeDeclaration();
        // v3.Visit(root);


        InterpreterVisitor v4 = new InterpreterVisitor();
        v4.Visit(root);


        string dot_graph = GraphGeneratorTraverser.GenerateGraph(root);

        File.WriteAllBytes("/home/mahmoud/geem_files/function_with_conditionals.dot", UnicodeEncoding.UTF8.GetBytes(dot_graph));
    }
    [Fact]
    public void function_with_iterations()
    {
        string test_file_path = "/home/mahmoud/geem_files/function_with_iterations.geem";
        string file_content = File.ReadAllText(test_file_path);

        ICharStream char_stream = CharStreams.fromString(file_content);
        ITokenSource token_source = new GeemLexer(char_stream);
        ITokenStream token_stream = new CommonTokenStream(token_source);
        GeemParser geem_parser = new GeemParser(token_stream);

        IParseTree root = geem_parser.program();

        ProgramContext root_t = (ProgramContext)root;

        ConstructSymbolTableVisitor v1 = new ConstructSymbolTableVisitor();
        v1.Visit(root);

        TypeMismatchValidator v2 = new TypeMismatchValidator();
        v2.Visit(root);


        // UsedBeforeDeclaration v3 = new UsedBeforeDeclaration();
        // v3.Visit(root);


        InterpreterVisitor v4 = new InterpreterVisitor();
        v4.Visit(root);


        string dot_graph = GraphGeneratorTraverser.GenerateGraph(root);

        File.WriteAllBytes("/home/mahmoud/geem_files/function_with_iterations.dot", UnicodeEncoding.UTF8.GetBytes(dot_graph));
    }

    [Fact]
    public void nesting_conditionals_inside_iterations()
    {
        string test_file_path = "/home/mahmoud/geem_files/nesting_conditionals_inside_iterations.geem";
        string file_content = File.ReadAllText(test_file_path);

        ICharStream char_stream = CharStreams.fromString(file_content);
        ITokenSource token_source = new GeemLexer(char_stream);
        ITokenStream token_stream = new CommonTokenStream(token_source);
        GeemParser geem_parser = new GeemParser(token_stream);

        IParseTree root = geem_parser.program();

        ProgramContext root_t = (ProgramContext)root;

        ConstructSymbolTableVisitor v1 = new ConstructSymbolTableVisitor();
        v1.Visit(root);

        TypeMismatchValidator v2 = new TypeMismatchValidator();
        v2.Visit(root);


        // UsedBeforeDeclaration v3 = new UsedBeforeDeclaration();
        // v3.Visit(root);


        InterpreterVisitor v4 = new InterpreterVisitor();
        v4.Visit(root);


        string dot_graph = GraphGeneratorTraverser.GenerateGraph(root);

        File.WriteAllBytes("/home/mahmoud/geem_files/nesting_conditionals_inside_iterations.dot", UnicodeEncoding.UTF8.GetBytes(dot_graph));
    }
    [Fact]
    public void testing_break_and_continue_statements()
    {
        string test_file_path = "/home/mahmoud/geem_files/testing_break_and_continue_statements.geem";
        string file_content = File.ReadAllText(test_file_path);

        ICharStream char_stream = CharStreams.fromString(file_content);
        ITokenSource token_source = new GeemLexer(char_stream);
        ITokenStream token_stream = new CommonTokenStream(token_source);
        GeemParser geem_parser = new GeemParser(token_stream);

        IParseTree root = geem_parser.program();

        ProgramContext root_t = (ProgramContext)root;

        ConstructSymbolTableVisitor v1 = new ConstructSymbolTableVisitor();
        v1.Visit(root);

        TypeMismatchValidator v2 = new TypeMismatchValidator();
        v2.Visit(root);


        // UsedBeforeDeclaration v3 = new UsedBeforeDeclaration();
        // v3.Visit(root);


        InterpreterVisitor v4 = new InterpreterVisitor();
        v4.Visit(root);


        string dot_graph = GraphGeneratorTraverser.GenerateGraph(root);

        File.WriteAllBytes("/home/mahmoud/geem_files/testing_break_and_continue_statements.dot", UnicodeEncoding.UTF8.GetBytes(dot_graph));
    }

    [Fact]
    public void testing_recursive_functions()
    {
        string test_file_path = "/home/mahmoud/geem_files/testing_recursive_functions.geem";
        string file_content = File.ReadAllText(test_file_path);

        ICharStream char_stream = CharStreams.fromString(file_content);
        ITokenSource token_source = new GeemLexer(char_stream);
        ITokenStream token_stream = new CommonTokenStream(token_source);
        GeemParser geem_parser = new GeemParser(token_stream);

        IParseTree root = geem_parser.program();

        ProgramContext root_t = (ProgramContext)root;

        ConstructSymbolTableVisitor v1 = new ConstructSymbolTableVisitor();
        v1.Visit(root);

        TypeMismatchValidator v2 = new TypeMismatchValidator();
        v2.Visit(root);


        // UsedBeforeDeclaration v3 = new UsedBeforeDeclaration();
        // v3.Visit(root);


        InterpreterVisitor v4 = new InterpreterVisitor();
        v4.Visit(root);


        string dot_graph = GraphGeneratorTraverser.GenerateGraph(root);

        File.WriteAllBytes("/home/mahmoud/geem_files/testing_recursive_functions.dot", UnicodeEncoding.UTF8.GetBytes(dot_graph));
    }

}