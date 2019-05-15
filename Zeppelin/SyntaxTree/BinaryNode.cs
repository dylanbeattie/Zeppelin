public class BinaryNode : SyntaxNode {

    public Operator Operator { get; }

    public SyntaxNode Lhs { get; }
    public SyntaxNode Rhs { get; }
    public BinaryNode(Operator op, SyntaxNode lhs, SyntaxNode rhs) {
        this.Operator = op;
        this.Lhs = lhs;
        this.Rhs = rhs;
    }

    public override string ToString() {
        return (this.Operator.ToString().ToLowerInvariant() + ":");
    }
}