using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// p.97「コラム：クエリ構文」のコード

namespace QuerySyntax {
    class Program {
        static void Main(string[] args) {
            string[] names = {
                 "Tokyo", "New Delhi", "Bangkok", "London", "Paris", "Berlin", "Canberra",  };

            Query01(names);
            Console.WriteLine();

            Query02(names);
            Console.ReadLine();
        }

        private static void Query02(string[] names) {
            var query = names.Where(s => s.Length >= 5)
                             .Select(s => s.ToUpper());
            foreach (string s in query)
                Console.WriteLine(s);
        }

        private static void Query01(string[] names) {
            var query = from s in names
                        where s.Length >= 5
                        select s.ToUpper();
            foreach (string s in query)
                Console.WriteLine(s);
        }
    }
}
