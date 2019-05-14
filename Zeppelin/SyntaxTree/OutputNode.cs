public class OutputNode : SyntaxNode {

    public SyntaxNode Expression { get; }

    public OutputNode(SyntaxNode expr) {
        this.Expression = expr;
    }
}
