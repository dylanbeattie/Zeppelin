using System;
using System.IO;
using System.Linq;

namespace Zeppelin {
    class Program {
        static void Main(string[] args) {
            var source = File.ReadAllText("program.zep");
            var parser = new Parsers.Parser();
            var syntax = parser.Parse(source);
            Console.WriteLine("==== SYNTAX ====");
            Console.WriteLine(syntax.PrettyPrint());
            Console.WriteLine("==== OUTPUT ====");
            var evaluator = new Evaluator();
            evaluator.Evaluate(syntax);
        }
    }
}
