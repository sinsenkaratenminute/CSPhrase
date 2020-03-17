using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch0402 {
    class Program {
        static void Main(string[] args) {
            SampleCodeRunner.Run();
        }

    }

    [SampleCode("Chapter 4")]
    class SampleCode  {

        [ListNo("List 4-10")]
        public void Idiom01() { 
            var age = 10;
            if (age <= 10) {
                Console.WriteLine("10歳以下です");
            }
        }

        [ListNo("List 4-11, 4-12")]
        public void Idiom02() { 
            var num = 55;
            if (50 <= num && num <= 100) {
                Console.WriteLine("範囲内です");
            }

            // List 4-12
            if (num >= 50 && num <= 100) {
                Console.WriteLine("範囲内です");
            }

        }

        [ListNo("List 4-13")]
        public void Idiom03() {
            Console.Write("数値を入力してください =>");
            var line = Console.ReadLine();
            int num = int.Parse(line);
            if (num > 80) {
                Console.WriteLine("Aランクです");
            } else if (num > 60) {
                Console.WriteLine("Bランクです");
            } else if (num > 40) {
                Console.WriteLine("Cランクです");
            } else {
                Console.WriteLine("Dランクです");
            }

            // List 4-14 
            //if (num > 80) 
            //    Console.WriteLine("Aランクです");
            //else 
            //    if (num > 60) 
            //        Console.WriteLine("Bランクです");
            //    else 
            //        if (num > 40) 
            //            Console.WriteLine("Cランクです");
            //        else 
            //            Console.WriteLine("Dランクです");
            

        }

        [ListNo("List 4-16")]
        public void Idiom04() {
            int? num = 10;
            if (num.HasValue)
                Console.WriteLine("値を持っています");
        }

        [ListNo("List 4-17")]
        public void Idiom05() {
            var b = ReturnBoolSample();
            Console.WriteLine(b);
        }
        
        private bool ReturnBoolSample() {
            Console.Write("Hello と入力してください =>");
            var line = Console.ReadLine();
            // List 4-17
            return line == "Hello";
        }
    }
}
