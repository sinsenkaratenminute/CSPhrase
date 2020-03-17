using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

// p.406「コラム：デッドロックを回避する」のコード
// button1_Click、button2_Clickは、デッドロックします。
// デッドロックしたプログラムを終了させるには、
// デバッグ実行の場合: [デバッグ]-[デバッグの停止]で終了
// 直接実行: タスクマネージャで該当プログラムを終了


namespace AsyncDeadLock {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }


        // Resultプロパティを使い、同期処理をする -> デッドロックする。
        private void button1_Click(object sender, EventArgs e) {
            var result = DoSomethingAsync().Result;
            label1.Text = result.ToString();
        }

        private async Task<long> DoSomethingAsync() {
            var result = await Task.Run(() => {
                long sum = 0;
                for (int i = 1; i <= 10000000; i++) {
                    sum += i;
                }
                return sum;
            });
            return result;
        }


        // 非同期メソッドをWaitメソッドで同期処理する -> デッドロックする。
        private void button2_Click(object sender, EventArgs e) {
            RunAsync().Wait();
        }

        public async Task RunAsync() {
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

        // 完全に同期処理で統一
        private void button3_Click(object sender, EventArgs e) {
            var result = DoSomething();
            label1.Text = result.ToString();
        }

        private long DoSomething() {
            long sum = 0;
            for (int i = 1; i <= 10000000; i++) {
                sum += i;
            }
            return sum;
        }

        // 非同期メソッドで統一
        private async void button4_Click(object sender, EventArgs e) {
            var result = await DoSomethingAsync();
            label1.Text = result.ToString();
        }

        // 非同期メソッドで統一
        private void button5_Click(object sender, EventArgs e) {
            var currentContext = TaskScheduler.FromCurrentSynchronizationContext();
            Task.Run(() => {
                return DoSomethingAsync().Result;
            })
            .ContinueWith(task => {
                label1.Text = task.Result.ToString();
            }, currentContext);
        }

        private void button6_Click(object sender, EventArgs e) {
            label1.Text = "";
        }
    }
}
