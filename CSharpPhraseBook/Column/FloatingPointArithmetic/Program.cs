using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//  p.459「コラム：浮動小数点型の比較」のコード

namespace FloatingPointArithmetic { 

    class Program {
        static void Main(string[] args) {
            FloatingPointTest();

            DecimalTest();

            Console.ReadLine();

        }
        private static void FloatingPointTest() {
            double sum = 0.0;
            for (int i = 0; i < 10; i++)
                sum += 0.1;
            if (sum == 1.0)
                Console.WriteLine("sum == 1.0");
            else
                Console.WriteLine("sum != 1.0");

            if (Math.Abs(sum - 1.0) < 0.000001) {
                Console.WriteLine("1.0だと見なす");

            }
        }

        private static void DecimalTest() {
            decimal sum = 0m;
            // 1/3 を3回加える
            for (int i = 0; i < 3; i++) {
                sum += GetDecimal();  
            }
            Console.WriteLine(sum == 1m);
        }


        static decimal GetDecimal() {
            return 1m / 3m;
        }

    }

}