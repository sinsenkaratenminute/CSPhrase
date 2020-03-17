using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// p.382「コラム：Zipメソッドの使い方」のコード
// p.383「コラム：LINQの集合演算子」のコード

namespace LINQ {
    class Program {
        static void Main(string[] args) { 
            ZipSample();
            Console.WriteLine();

            UnionSample();
            IntersectSample();
            ExceptSample();

            Console.ReadLine();
        }

        static void ZipSample() {
            var jWeeks = new List<string> {
               "月", "火", "水", "木", "金", "土", "日"
            };
                        var eWeeks = new List<string> {
               "MON", "TUE", "WED", "THU", "FRI", "SAT", "SUN"
            };
            var weeks = jWeeks.Zip(eWeeks,
                                       (s1, s2) => string.Format("{0}({1})", s1, s2));
            weeks.ToList().ForEach(Console.WriteLine);
        }

        static void UnionSample() {
            var animals1 = new[] { "キリン", "ライオン", "ゾウ", "シロクマ", "パンダ", };
            var animals2 = new[] { "ライオン", "コアラ", "キリン", "ゴリラ", };
            var union = animals1.Union(animals2);
            foreach (var name in union)
                Console.Write($"{name} ");
            Console.WriteLine();
        }

        static void IntersectSample() {
            var animals1 = new[] { "キリン", "ライオン", "ゾウ", "シロクマ", "パンダ", };
            var animals2 = new[] { "ライオン", "コアラ", "キリン", "ゴリラ", };
            var intersect = animals1.Intersect(animals2);
            foreach (var name in intersect)
                Console.Write($"{name} ");
            Console.WriteLine();
        }

        static void ExceptSample() {
            var animals1 = new[] { "キリン", "ライオン", "ゾウ", "シロクマ", "パンダ", };
            var animals2 = new[] { "ライオン", "コアラ", "キリン", "ゴリラ", };
            var expect = animals1.Except(animals2);
            foreach (var name in expect)
                Console.Write($"{name} ");
            Console.WriteLine();
        }



    }
}
