using System;
using System.IO;
using System.Linq;

namespace Zeppelin {
    class Program {
        static void Main(string[] args) {
            try {
                var source = File.ReadAllText("program.zep");
                var parser = new Parsers.Parser();
                var syntax = parser.Parse(source);
                Console.WriteLine("==== SYNTAX ====");
                Console.WriteLine(syntax.PrettyPrint());
                Console.WriteLine("==== OUTPUT ====");
                var evaluator = new Evaluator();
                evaluator.Evaluate(syntax);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
