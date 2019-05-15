public class ProductNode : SyntaxNode {

    public SyntaxNode Lhs { get; }
    public SyntaxNode Rhs { get; }
    public ProductNode(SyntaxNode lhs, SyntaxNode rhs) {
        this.Lhs = lhs;
        this.Rhs = rhs;
    }
}