using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// p.157の「コラム：オブジェクトどうしの比較」のコード

namespace ComparingObjects {

    class Program {
        static void Main(string[] args) {
            Compare01();
            Compare02();
            Compare03();
            Console.ReadLine();
        }

        private static void Compare01() {
            int a = GetCurrentValue();
            int b = GetNextValue();
            if (a == b) {
                // a と b は等しい 
                Console.WriteLine("aとbは等しい(1)");
            }
            DateTime d1 = GetMyBirthday();
            DateTime d2 = GetYourBirthday();
            if (d1 == d2) {
                // d1 と d2 は同じ日付 
                Console.WriteLine("aとbは等しい(2)");
            }
        }

        private static DateTime GetYourBirthday() {
            return new DateTime(1995,8,5);
        }

        private static DateTime GetMyBirthday() {
            return new DateTime(1995, 8, 5);
        }

        private static int GetNextValue() {
            return 12345;
        }

        private static int GetCurrentValue() {
            return 12345;
        }

        private static void Compare02() {
            {
                Sample a = new Sample { Num = 1, Str = "C#" };
                Sample b = new Sample { Num = 1, Str = "C#" };
                if (a == b) {
                    // a と b は、メモリ上に別々に確保されたオブジェクトであるため、   
                    // ここに書かれたステートメントは実行されない 
                    Console.WriteLine("aとbは等しい(3)");
                }
            }
            {
                Sample a = new Sample { Num = 1, Str = "C#" };
                Sample b = a;
                if (a == b) {
                    // a と b は、メモリ上の同じオブジェクトを参照しているため、
                    // ここに書かれたステートメントが実行される
                    Console.WriteLine("aとbは等しい(4)");
                }
            }
        }


        private static void Compare03() {
            var str1 = GetCurrentWord();
            // "Hello"が返る 
            var str2 = GetNextWord();
            // 別の領域に確保された"Hello"が返る 
            if (str1 == str2) {
                // 参照型の比較ではなく、値の比較が行われるので、別々の"Hello"であっても   
                // ここに書かれたステートメントが実行される 
                Console.WriteLine("str1とstr2は等しい");
            }
        }

        private static string GetNextWord() {
            return "Hello";
        }

        private static string GetCurrentWord() {
            return new string(new char[] { 'H', 'e', 'l', 'l', 'o' });
        }


    }


    class Sample {
        public int Num { get; set; }

        public string Str { get; set; }

    }
}
