using System;

namespace Zeppelin {
    class Evaluator {
        public object Evaluate(SyntaxNode node) {
            switch (node) {
                case NumberNode n: return n.Value;
                case OutputNode o: return Output(o);
            }
            throw (new Exception($"Unrecognised node type {node.GetType()}"));
        }

        public object Output(OutputNode o) {
            var result = Evaluate(o.Number);
            Console.WriteLine(result);
            return result;
        }

    }
}
