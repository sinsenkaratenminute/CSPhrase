using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Section04 {
    class Program {
        static void Main(string[] args) {
            SampleCodeRunner.Run();
        }
    }

    [SampleCode("Chapter 10")]
    class SampleCode  {
        [ListNo("List 10-15")]
        public void Replace01() {
            var text = "C#の学習をすこしずつ進めていこう。";
            var pattern = @"少しづつ|すこしづつ|すこしずつ";
            var replaced = Regex.Replace(text, pattern, "少しずつ");
            Console.WriteLine(replaced);
        }


        [ListNo("List 10-16")]
        public void Replace02() {
            var text = "Word, Excel ,PowerPoint , Outlook,OneNote";
            var pattern = @"\s*,\s*";
            var replaced = Regex.Replace(text, pattern, ", ");
            Console.WriteLine(replaced);
        }

        [ListNo("List 10-17")]
        public void Replace03() {
            var text = "foo.htm bar.html baz.htm";
            var pattern = @"\.(htm)\b";
            var replaced = Regex.Replace(text, pattern, ".html");
            Console.WriteLine(replaced);
        }

        [ListNo("List 10-18")]
        public void ReplaceWithGroup01() {
            var text = "1024バイト、8バイト文字、バイト、キロバイト";
            var pattern = @"(\d+)バイト";
            var replaced = Regex.Replace(text, pattern, "$1byte");
            Console.WriteLine(replaced);
        }


        [ListNo("List 10-19")]
        public void ReplaceWithGroup02() {
            var text = "1234567890123456";
            var pattern = @"(\d{4})(\d{4})(\d{4})(\d{4})";
            var replaced = Regex.Replace(text, pattern, "$1-$2-$3-$4");
            Console.WriteLine(replaced);
        }

        [ListNo("List 10-20")]
        public void Split() {
            var text = "Word, Excel ,PowerPoint , Outlook,OneNote";
            var pattern = @"\s*,\s*";

            string[] substrings = Regex.Split(text, pattern);
            foreach (var match in substrings) {
                Console.WriteLine("'{0}'", match);
            }
        }

    }
}
