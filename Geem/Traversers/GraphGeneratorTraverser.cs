namespace Geem.Traversers;
using Antlr4.Runtime.Tree;
using System.Text;

public class GraphGeneratorTraverser
{
    public static Dictionary<string, int> node_index_map = new Dictionary<string, int>() {
        {"ProgramContext",0},
        {"GlobalVarDeclContext",0},
        {"InititalizationContext",0},
        {"FunctionDeclContext",0},
        {"OperationDeclContext",0},
        {"ParameterContext",0},
        {"ParamListContext",0},
        {"ArgumentContext",0},
        {"ArgumentListContext",0},
        {"Lor_exprContext",0},
        {"Add_exprContext",0},
        {"Land_exprContext",0},
        {"Comparison_exprContext",0},
        {"Multiply_exprContext",0},
        {"Variable_exprContext",0},
        {"Parenthesis_exprContext",0},
        {"Int_literal_exprContext",0},
        {"Subtraction_exprContext",0},
        {"Divide_exprContext",0},
        {"Fun_call_exprContext",0},
        {"Minus_exprContext",0},
        {"Lnot_exprContext",0},
        {"Equality_exprContext",0},
        {"Int_literalContext",0},
        {"Comparison_opContext",0},
        {"Equality_opContext",0},
        {"If_StatContext",0},
        {"Var_Decl_StatContext",0},
        {"Return_StatContext",0},
        {"While_StatContext",0},
        {"Result_StatContext",0},
        {"Operation_StatContext",0},
        {"Assignment_StatContext",0},
        {"StatementContext",0},
        {"StatementListContext",0},
        {"OperationStatContext",0},
        {"AssignmentStatContext",0},
        {"IfStatContext",0},
        {"WhileStatContext",0},
        {"ReturnStatContext",0},
        {"ResultStatContext",0},
        {"VarDeclContext",0},
        {"DataTypeContext",0},
        {"CommandStatContext", 0},
        {"CommandContext", 0},
        {"Command_StatContext", 0},
        {"TerminalNodeImpl", 0}
    };

    public static string GenerateGraph(IParseTree node, int node_index)
    {
        if (node != null)
        {
            string node_type_name = node.GetType().Name;
            // int node_index = node_index_map[node_type_name]++;

            StringBuilder string_builder = new StringBuilder();
            string_builder.AppendLine($"{node_type_name}_{node_index} [label=\"{node_type_name}\"];");
            for (int index = 0; index < node.ChildCount; index++)
            {

                if (node.GetChild(index) is TerminalNodeImpl)
                {
                    int child_node_index = node_index_map[node.GetChild(index).GetType().Name]++;

                    string_builder.AppendLine($"{node.GetChild(index).GetType().Name}_{child_node_index} [label=\"{node.GetChild(index).GetText()}\"];");
                    string_builder.AppendLine($"{node.GetType().Name}_{node_index} -> {node.GetChild(index).GetType().Name}_{child_node_index};");
                }
                else
                {
                    int child_node_index = node_index_map[node.GetChild(index).GetType().Name]++;

                    string_builder.AppendLine($"{node.GetChild(index).GetType().Name}_{child_node_index} [label=\"{node.GetChild(index).GetType().Name}\"];");
                    string_builder.AppendLine($"{node.GetType().Name}_{node_index} -> {node.GetChild(index).GetType().Name}_{child_node_index};");
                    string_builder.Append(GenerateGraph(node.GetChild(index), child_node_index));
                }


            }

            return string_builder.ToString();
        }
        return "";

    }
}
