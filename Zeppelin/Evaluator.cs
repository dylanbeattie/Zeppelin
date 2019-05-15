using System;
using System.Collections.Generic;

namespace Zeppelin {

    class Evaluator {

        private Dictionary<string, object> variables = new Dictionary<string, object>();

        public object Evaluate(SyntaxNode node) {
            switch (node) {
                case NumberNode n: return n.Value;
                case OutputNode o: return Output(o);
                case BlockNode b: return Block(b);
                case BinaryNode b: return Binary(b);
                case AssignNode a: return Assign(a);
                case LookupNode n: return Lookup(n);
            }
            throw (new Exception($"Unrecognised node type {node.GetType()}"));
        }

        private object Lookup(LookupNode n) {
            var name = n.Variable.Name;
            object result;
            if (variables.TryGetValue(name, out result)) return result;
            throw (new Exception($"Undefined variable {name}"));
        }

        private object Assign(AssignNode a) {
            var name = a.Variable.Name;
            var value = Evaluate(a.Expression);
            variables[name] = value;
            return value;
        }

        private object Binary(BinaryNode b) {
            var lhs = Evaluate(b.Lhs);
            var rhs = Evaluate(b.Rhs);
            if (lhs is decimal && rhs is decimal) {
                switch (b.Operator) {
                    case Operator.Add:
                        return (decimal)lhs + (decimal)rhs;
                    case Operator.Multiply:
                        return (decimal)lhs * (decimal)rhs;
                }
            }
            throw (new Exception($"I can't multiply {lhs.GetType()} and {rhs.GetType()}"));
        }

        public object Block(BlockNode b) {
            object result = null;
            foreach (var s in b.Statements) result = Evaluate(s);
            return result;
        }

        public object Output(OutputNode o) {
            var result = Evaluate(o.Expression);
            Console.WriteLine(result);
            return result;
        }
    }
}
