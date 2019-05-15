using System;

namespace Zeppelin {

    class Evaluator {

        public object Evaluate(SyntaxNode node) {
            switch (node) {
                case NumberNode n: return n.Value;
                case OutputNode o: return Output(o);
                case BlockNode b: return Block(b);
                case AdditionNode a: return Addition(a);
                case ProductNode p: return Product(p);
            }
            throw (new Exception($"Unrecognised node type {node.GetType()}"));
        }

        private object Product(ProductNode p) {
            var lhs = Evaluate(p.Lhs);
            var rhs = Evaluate(p.Rhs);
            if (lhs is decimal && rhs is decimal) {
                return (decimal)lhs * (decimal)rhs;
            }
            throw (new Exception($"I can't multiply {lhs.GetType()} and {rhs.GetType()}"));
        }

        public object Addition(AdditionNode a) {
            var lhs = Evaluate(a.Lhs);
            var rhs = Evaluate(a.Rhs);
            if (lhs is decimal && rhs is decimal) {
                return (decimal)lhs + (decimal)rhs;
            }
            throw (new Exception($"I can't add {lhs.GetType()} and {rhs.GetType()}"));

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
