using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section06 {

    [SampleCode("Chapter 16")]
    class Section0602  {

        [ListNo("List 16-21 の非並列版")]
        public void RunSync() {
            var sw = Stopwatch.StartNew();
            var prime1 = GetPrimeAt5000();
            var prime2 = GetPrimeAt6000();
            sw.Stop();
            Console.WriteLine(prime1);
            Console.WriteLine(prime2);
            Console.WriteLine($"実行時間: {sw.ElapsedMilliseconds}ミリ秒");
        }


        // List 16-20

        // 5000番目の素数を求める
        private static int GetPrimeAt5000() {
            return GetPrimes().Skip(4999).First();
        }

        // 6000番目の素数を求める
        private static int GetPrimeAt6000() {
            return GetPrimes().Skip(5999).First();
        }

        // 上記2つのメソッドから呼び出される下位メソッド
        // あえて効率の悪いアルゴリズムで記述しています。
        static IEnumerable<int> GetPrimes() {
            for (int i = 2; i < int.MaxValue; i++) {
                bool isPrime = true;
                for (int j = 2; j < i; j++) {
                    if (i % j == 0) {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                    yield return i;
            }
        }

        [ListNo("List 16-21")]
        public void Run21() {
            // Wait()を呼び出しても、コンソールアプリケーションはデッドロックは発生しない
            // WindowsForms、ASP.NET MVCなどではデッドロックが発生する危険があるので注意。
            RunAsync().Wait();
        }



        // List 16-21
        private async Task RunAsync() {
            var sw = Stopwatch.StartNew();
            var task1 = Task.Run(() => GetPrimeAt5000());
            var task2 = Task.Run(() => GetPrimeAt6000());
            var prime1 = await task1;
            var prime2 = await task2;
            sw.Stop();
            Console.WriteLine(prime1);
            Console.WriteLine(prime2);
            Console.WriteLine($"実行時間: {sw.ElapsedMilliseconds}ミリ秒");
        }

        [ListNo("List 16-22")]
        public void Run22() {
            // Wait()を呼び出しても、コンソールアプリケーションはデッドロックは発生しない
            // WindowsForms、ASP.NET MVCなどではデッドロックが発生するの注意。
            WhenAll().Wait();
        }

        // List 16-22
        public async Task WhenAll() {
            var sw = Stopwatch.StartNew();
            var tasks = new Task<int>[] {
                Task.Run(() => GetPrimeAt5000()),
                Task.Run(() => GetPrimeAt6000()),
            };
            var results = await Task.WhenAll(tasks);
            foreach (var prime in results)
                Console.WriteLine(prime);
            Console.WriteLine($"実行時間: {sw.ElapsedMilliseconds}ミリ秒");
        }


    }
}
