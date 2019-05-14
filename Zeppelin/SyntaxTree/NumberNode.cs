public class NumberNode : SyntaxNode {
    public decimal Value { get; }
    public NumberNode(decimal value) {
        this.Value = value;
    }

    public override string ToString() {
        return ($"number: {Value}");
    }
}
