using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// p.132「コラム：前置++と後置++の違い」のコード

namespace IncrementOperator {

    class Program {
        static void Main(string[] args) {
            int num = 5;
            Console.WriteLine(num++);
            num = 5;
            Console.WriteLine(++num);

            Console.ReadLine();
        }
    }
}
