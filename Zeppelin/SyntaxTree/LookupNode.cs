public class LookupNode : SyntaxNode {
    public VariableNode Variable { get; }
    public LookupNode(VariableNode v) {
        this.Variable = v;
    }
}