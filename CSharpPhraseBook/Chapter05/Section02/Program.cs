using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section02 {
    class Program {
        static void Main(string[] args) {
            SampleCodeRunner.Run();
        }
    }

    [SampleCode("Chapter 5")]
    class SampleCode  {
        [ListNo("List 5-7 ～ List 5-10")]
        public void IsNullOrEmpty() {
            var str = "";
            if (String.IsNullOrEmpty(str))
                Console.WriteLine("null あるいは 空文字列です");

            // nullか空文字列かを調べる悪い例
            if (str == null || str == "")
                Console.WriteLine("null あるいは 空文字列です");

            // nullか空文字列かを調べる悪い例
            if (str == null || str.Length == 0)
                Console.WriteLine("null あるいは 空文字列です");


            if (str == String.Empty)
                Console.WriteLine("空文字列です");

            if (String.IsNullOrWhiteSpace(str))
                Console.WriteLine("null あるいは 空文字列 あるいは 空白文字例です");
        }

        [ListNo("List 5-11 ～ List 5-13")]
        public void StartsWith() {
            var str = "Visual Studio";

            if (str.StartsWith("Visual")) {
                Console.WriteLine("Visual で始まっています");
            }

            if (str.IndexOf("Visual") == 0) {
                Console.WriteLine("Visual で始まっています");
            }

            str = "InvalidException";
            if (str.EndsWith("Exception")) {
                Console.WriteLine("Exception で終わっています");
            }

        }

        [ListNo("List 5-14 ～ List 5-17")]
        public void Contains() {
            var str = "C# Program";

            if (str.Contains("Program")) {
                Console.WriteLine("Program が含まれています");
            }

            // 部分文字列が含まれているかを調べる悪い例
            if (str.IndexOf("Program") >= 0) {
                Console.WriteLine("Program が含まれています");
            }

            var target = "The quick brown fox jumps over the lazy dog.";
            var contains = target.Contains('b');
            Console.WriteLine(contains);

            // 文字列の中に指定した文字があるかを調べる悪い例
            var contains2 = target.IndexOf('b') >= 0;
            Console.WriteLine(contains);
        }

        [ListNo("List 5-18 ～ List 5-19")]
        public void Any() {
            var target = "C# Programming";
            {
                var isExists = target.Any(c => Char.IsLower(c));
                Console.WriteLine(isExists);
            }
            {
                bool isExists = false;
                foreach (char c in target) {
                    if (Char.IsLower(c)) {
                        isExists = true;
                        break;
                    }
                }
                Console.WriteLine(isExists);
            }
        }

        [ListNo("List 5-20 ～ List 5-21")]
        public void All() {
            {
                var target = "141421356";
                var isAllDigits = target.All(c => Char.IsDigit(c));
                Console.WriteLine(isAllDigits);
            }
            {
                string target = "141421356";
                bool isAllDigits = true;
                foreach (char c in target) {
                    if (!Char.IsDigit(c)) {
                        isAllDigits = false;
                        break;
                    }
                }
                Console.WriteLine(isAllDigits);
            }
        }
    }
}
