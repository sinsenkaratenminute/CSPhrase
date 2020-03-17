using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch0401 {
    class Program {
        static void Main(string[] args) {
            SampleCodeRunner.Run();
        }
    }

    [SampleCode("Chapter 4")]
    class SampleCode  {

        [ListNo("List 4-1")]
        public void Idiom01() {
            var age = 25;
            Console.WriteLine(age);
        }

        [ListNo("List 4-2")]
        public void Idiom02() {
            int age;
            age = 25;
            Console.WriteLine(age);
        }

        [ListNo("List 4-3")]
        public void Idiom03() {
            var langs = new string[] { "C#", "VB", "C++", };
            var nums = new List<int> { 10, 20, 30, 40, };

            foreach (var lang in langs)
                Console.WriteLine(lang);

            foreach (var n in nums)
                Console.WriteLine(n);
        }

        [ListNo("List 4-4")]
        public void Idiom04() {
            string[] langs = new string[3];
            langs[0] = "C#";
            langs[1] = "VB";
            langs[2] = "C++";
            List<int> nums = new List<int>();
            nums.Add(10);
            nums.Add(20);
            nums.Add(30);
            nums.Add(40);

            foreach (var lang in langs)
                Console.WriteLine(lang);

            foreach (var n in nums)
                Console.WriteLine(n);

        }

        [ListNo("List 4-5")]
        public void Idiom05() {
            var dict = new Dictionary<string, string>() {
                { "ja", "日本語" },
                { "en", "英語" },
                { "es", "スペイン語" },
                { "de", "ドイツ語" },
            };

            foreach (var item in dict)
                Console.WriteLine($"{item.Key} {item.Value}");
        }


        [ListNo("List 4-6")]
        public void Idiom06() {
            var dict = new Dictionary<string, string>() {
                ["ja"] = "日本語",
                ["en"] = "英語",
                ["es"] = "スペイン語",
                ["de"] = "ドイツ語",
            };

            foreach (var item in dict)
                Console.WriteLine($"{item.Key} {item.Value}");
        }

        [ListNo("List 4-7")]
        public void Idiom07() {
            var dict = new Dictionary<string, string>();
            dict["ja"] = "日本語";
            dict["en"] = "英語";
            dict["es"] = "スペイン語";
            dict["de"] = "ドイツ語";

            foreach (var item in dict)
                Console.WriteLine($"{item.Key} {item.Value}");
        }

        [ListNo("List 4-8")]
        public void Idiom08() {
            var person = new Person {
                Name = "新井遥菜",
                Birthday = new DateTime(1995, 11, 23),
                PhoneNumber = "012-3456-7890",
            };

            Console.WriteLine($"{person.Name} {person.Birthday} {person.PhoneNumber}");
        }

        [ListNo("List 4-9")]
        public void Idiom09() {
            Person person = new Person();
            person.Name = "新井遥菜";
            person.Birthday = new DateTime(1995, 11, 23);
            person.PhoneNumber = "012-3456-7890";

            Console.WriteLine($"{person.Name} {person.Birthday} {person.PhoneNumber}");
        }

    }

}
