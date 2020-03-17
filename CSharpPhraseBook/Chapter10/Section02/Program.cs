using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Section02 {
    class Program {
        static void Main(string[] args) {
            SampleCodeRunner.Run();
        }
    }

    [SampleCode("Chapter 10")]
    class SampleCode  {

        [ListNo("List 10-1")]
        public void IsMatch01() {
            var text = "private List<string> results = new List<string>();";
            bool isMatch = Regex.IsMatch(text, @"List<\w+>");
            if (isMatch)
                Console.WriteLine("見つかりました");
            else
                Console.WriteLine("見つかりません");
        }

        [ListNo("List 10-2")]
        public void IsMatch02() {
            var text = "private List<string> results = new List<string>();";
            var regex = new Regex(@"List<\w+>");
            bool isMatch = regex.IsMatch(text);
            if (isMatch)
                Console.WriteLine("見つかりました");
            else
                Console.WriteLine("見つかりません");
        }

        [ListNo("List 10-3")]
        public void StartWith() {
            var text = "using System.Text.RegularExpressions;";
            bool isMatch = Regex.IsMatch(text, @"^using");
            if (isMatch)
                Console.WriteLine("'using'で始まっています");
            else
                Console.WriteLine("'using'で始まっていません");
        }

        [ListNo("List 10-4")]
        public void EndWith() {
            var text = "Regexクラスを使った文字列操作について説明します。";
            bool isMatch = Regex.IsMatch(text, @"ます。$");
            if (isMatch)
                Console.WriteLine("'ます。'で終わっています");
            else
                Console.WriteLine("'ます。'で終わっていません");
        }


        [ListNo("List 10-5")]
        public void PerfectMatch() {
            var strings = new[] { "Microsoft Windows", "Windows Server", "Windows", };
            var regex = new Regex(@"^(W|w)indows$");
            var count = strings.Count(s => regex.IsMatch(s));
            Console.WriteLine("{0}行と一致", count);
        }

        [ListNo("List 10-6")]
        public void BadPerfectMatch() {
            var strings = new[] { "Microsoft Windows", "Windows Server", "Windows", };
            var regex = new Regex(@"(W|w)indows");
            var count = strings.Count(s => regex.IsMatch(s));
            Console.WriteLine("{0}行と一致", count);
        }

        [ListNo("List 10-7")]
        public void PerfectMatch02() {
            var strings = new[] { "13000", "-50.6", "0.123",  "+180.00",
                "10.2.5", "320-0851", " 123", "$1200", "500円", };
            var regex = new Regex(@"^[-+]?(\d+)(\.\d+)?$");
            foreach (var s in strings) {
                var isMatch = regex.IsMatch(s);
                if (isMatch)
                    Console.WriteLine(s);
            }
        }
    }
}
