using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class SyntaxNode {

    // Code to render syntax trees as ASCII trees
    public override string ToString() {
        return (this.GetType().Name.Replace("Node", "").ToLowerInvariant() + ":");
    }

    public string PrettyPrint() {
        var sb = new StringBuilder();
        this.Render(sb);
        return (sb.ToString());
    }

    public virtual void Render(StringBuilder sb, string padding = "") {
        sb.Append(padding).AppendLine(this.ToString());
        var listProperties = GetType().GetProperties()
            .Where(p => typeof(IList<SyntaxNode>).IsAssignableFrom(p.PropertyType));
        foreach (var prop in listProperties) {
            var list = (IList<SyntaxNode>)prop.GetValue(this);
            foreach (var item in list) item.Render(sb, padding + "  ");
        }
        var nodeProperties = GetType().GetProperties().Where(p => typeof(SyntaxNode).IsAssignableFrom(p.PropertyType));
        foreach (var prop in nodeProperties) ((SyntaxNode)prop.GetValue(this)).Render(sb, padding + "  ");
    }
}
