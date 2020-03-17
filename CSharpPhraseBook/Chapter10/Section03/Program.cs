using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Section03 {
    class Program {
        static void Main(string[] args) {
            SampleCodeRunner.Run();
        }

    }

    [SampleCode("Chapter 10")]
    class SampleCode  {
        [ListNo("List 10-8")]
        public void NormalSearch() {
            var text = "RegexクラスのMatchメソッドを使います";
            Match match = Regex.Match(text, @"\p{IsKatakana}+");
            if (match.Success)
                Console.WriteLine("{0} {1}", match.Index, match.Value);
        }

        [ListNo("List 10-9")]
        public void SearchAll() {
            var text = "private List<string> results = new List<string>();";
            var matches = Regex.Matches(text, @"List<\w+>");
            foreach (Match match in matches) {
                Console.WriteLine("Index={0}, Length={1}, Value={2}",
                        match.Index, match.Length, match.Value);
            }
        }

        [ListNo("List 10-10")]
        public void SearchAllWithNextMatch() {
            var text = "private List<string> results = new List<string>();";
            Match match = Regex.Match(text, @"List<\w+>");
            while (match.Success) {
                Console.WriteLine("Index={0}, Length={1}, Value={2}",
                                  match.Index, match.Length, match.Value);
                match = match.NextMatch();
            }
        }

        [ListNo("List 10-11")]
        public void SearchAndLinq() {
            var text = "private List<string> results = new List<string>();";
            var matches = Regex.Matches(text, @"\b[a-z]+\b")
                               .Cast<Match>()
                               .OrderBy(x => x.Length);
            foreach (Match match in matches) {
                Console.WriteLine("Index={0}, Length={1}, Value={2}",
                                  match.Index, match.Length, match.Value);
            }
        }
        [ListNo("List 10-12")]
        public void CapturingGroup() {
            var text = "C#には、《値型》と《参照型》の2つの型が存在します";
            var matches = Regex.Matches(text, @"《([^《》]+)》");
            foreach (Match match in matches) {
                Console.WriteLine("<{0}>", match.Groups[1]);
            }
        }

    }
}
