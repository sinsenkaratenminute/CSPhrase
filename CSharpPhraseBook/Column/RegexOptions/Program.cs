using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

// p.264 「コラム：大文字/小文字を区別せずマッチさせる」のコード
// p.265 「コラム：行頭、行末の意味を変更し、複数行モードにする」のコード

namespace RegexOptionsSample {
    class Program {
        static void Main(string[] args) {
            IgnoreCase();
            Multiline();
            Console.ReadLine();
        }

        // List 10-13
        private static void IgnoreCase() {
            var text = "jpn, JPN, Jpn";
            var mc = Regex.Matches(text, @"\bjpn\b", RegexOptions.IgnoreCase);
            foreach (Match m in mc) {
                Console.WriteLine(m.Value);
            }
        }

        // List 10-14
        private static void Multiline() {
            var text = "Word\nExcel\nPowerPoint\nOutlook\nOneNote\n";
            var pattern = @"^[a-zA-Z]{5,7}$";
            var matches = Regex.Matches(text, pattern, RegexOptions.Multiline);
            foreach (Match m in matches) {
                Console.WriteLine("{0} {1}", m.Index, m.Value);
            }
        }

    }
}
