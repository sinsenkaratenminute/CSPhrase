using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
//Backreference
namespace Section05 {
    class Program {
        static void Main(string[] args) {
            SampleCodeRunner.Run();
        }
    }

    [SampleCode("Chapter 10")]
    class SampleCode  {
        [ListNo("List 10-21")]
        public void Quantifier01() {
            var text = "a123456 b123 Z12345 AX98765";
            var pattern = @"\b[a-zA-Z][0-9]{5,}\b";
            var matches = Regex.Matches(text, pattern);
            foreach (Match m in matches)
                Console.WriteLine("'{0}'", m.Value);
        }

        [ListNo("List 10-22")]
        public void Quantifier02() {
            var text = "シーズン、ゴールド、シーソー、ゴールデンなどと一致します。スウェーデンやノートなどとは一致しません。";
            var pattern = @"(\b|[^\p{IsKatakana}])(\p{IsKatakana}ー\p{IsKatakana}{2,3})(\b|[^\p{IsKatakana}])";
            var matches = Regex.Matches(text, pattern);
            foreach (Match m in matches)
                Console.WriteLine("'{0}'", m.Groups[2]);
        }

        [ListNo("List 10-23")]
        public void GreedyMatching() {
            var text = "<person><name>栗原利伸</name><age>22</age></person>";
            var pattern = @"<.+>";
            var matches = Regex.Matches(text, pattern);
            foreach (Match m in matches)
                Console.WriteLine("'{0}'", m.Value);
        }

        [ListNo("List 10-24")]
        public void LazyMatching() {
            var text = "<person><name>栗原利伸</name><age>22</age></person>";
            var pattern = @"<(\w[^>]+)>";
            var matches = Regex.Matches(text, pattern);
            foreach (Match m in matches)
                Console.WriteLine("'{0}'", m.Groups[1].Value);
        }


        [ListNo("List 10-25")]
        public void LazyMatchingWithQuantifier01() {
            var text = "<person><name>栗原利伸</name><age>22</age></person>";
            var pattern = @"<(\w+?)>";
            var matches = Regex.Matches(text, pattern);
            foreach (Match m in matches)
                Console.WriteLine("'{0}'", m.Groups[1].Value);
        }

        [ListNo("List 10-26")]
        public void LazyMatchingWithQuantifier02() {
            var text = "<p>あいうえお</p><p>かきくけこ</p>";
            var pattern = @"<p>(.*?)</p>";
            var matches = Regex.Matches(text, pattern);
            foreach (Match m in matches)
                Console.WriteLine("'{0}'", m.Groups[1].Value);
        }

        [ListNo("List 10-27")]
        public void Backreference01() {
            var text = "僕はパンのミミをちぎり、ペットのももに分け与えた";
            var pattern = @"(\w)\1";
            var matches = Regex.Matches(text, pattern);
            foreach (Match m in matches)
                Console.WriteLine("'{0}'", m.Value);
        }
        [ListNo("List 10-28")]
        public void Backreference02() {
            var text = "しるし こもじ しんぶんし きもの トマト pops push pop";
            var pattern = @"\b(\w)\w\1\b";
            var matches = Regex.Matches(text, pattern);
            foreach (Match m in matches)
                Console.WriteLine("'{0}'", m.Value);
        }

    }
}
