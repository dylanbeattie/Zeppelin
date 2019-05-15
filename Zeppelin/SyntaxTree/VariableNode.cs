public class VariableNode : SyntaxNode {
    public string Name { get; }
    public VariableNode(string name) {
        this.Name = name;
    }
    public override string ToString() {
        return ("variable: " + this.Name);
    }
}