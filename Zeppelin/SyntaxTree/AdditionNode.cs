public class AdditionNode : SyntaxNode {

    public SyntaxNode Lhs { get; }
    public SyntaxNode Rhs { get; }
    public AdditionNode(SyntaxNode lhs, SyntaxNode rhs) {
        this.Lhs = lhs;
        this.Rhs = rhs;
    }
}