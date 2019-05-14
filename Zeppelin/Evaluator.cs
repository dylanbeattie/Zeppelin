using System;

namespace Zeppelin {

    class Evaluator {

        public object Evaluate(SyntaxNode node) {
            switch (node) {
                case NumberNode n: return n.Value;
                case OutputNode o: return Output(o);
                case BlockNode b: return Block(b);
            }
            throw (new Exception($"Unrecognised node type {node.GetType()}"));
        }

        public object Block(BlockNode b) {
            object result = null;
            foreach (var s in b.Statements) result = Evaluate(s);
            return result;
        }

        public object Output(OutputNode o) {
            var result = Evaluate(o.Number);
            Console.WriteLine(result);
            return result;
        }
    }
}
