using System;
using System.IO;
using System.Linq;

namespace Zeppelin {
    class Program {
        static void Main(string[] args) {
            var source = File.ReadAllText("program.zep");
            var parser = new Parsers.Parser();
            var result = parser.Parse(source);
            Console.WriteLine(result.PrettyPrint());
        }
    }
}
