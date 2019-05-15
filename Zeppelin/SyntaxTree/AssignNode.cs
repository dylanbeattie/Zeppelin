public class AssignNode : SyntaxNode {
    public VariableNode Variable { get; }
    public SyntaxNode Expression { get; }
    public AssignNode(VariableNode v, SyntaxNode e) {
        this.Variable = v;
        this.Expression = e;
    }
}
