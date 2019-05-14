public class OutputNode : SyntaxNode {
    public NumberNode Number { get; }
    public OutputNode(NumberNode number) {
        this.Number = number;
    }
}
