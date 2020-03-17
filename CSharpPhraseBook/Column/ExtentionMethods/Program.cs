using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpPhrase.Extensions;

// p.98の「コラム：拡張メソッド」のコード
// StringExtensions.cs が該当ソースファイル

namespace ExtensionMethods {
    class Program {
        static void Main(string[] args) {
            var word = "gateman";
            var result = word.Reverse();
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
