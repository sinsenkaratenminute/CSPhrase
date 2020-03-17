using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch0406 {
    class Program {
        static void Main(string[] args) {
            SampleCodeRunner.Run();
        }
    }

    [SampleCode("Chapter 4")]
    class SampleCode  {

        [ListNo("List 4-36")]
        public void Sample01() {
            var median1 = Median(1.0, 2.0, 3.0);
            var median2 = Median(1.0, 2.0, 3.0, 4.0, 5.0);
            Console.WriteLine(median1);
            Console.WriteLine(median2);

        }

        // List 4-36
        // 中央値を求めるメソッド 
        private double Median(params double[] args) {
            var sorted = args.OrderBy(n => n).ToArray();
            int index = sorted.Length / 2;
            if (sorted.Length % 2 == 0)
                return (sorted[index] + sorted[index - 1]) / 2;
            else
                return sorted[index];
        }

        [ListNo("List 4-37")]
        public void Sample02() {
            var time = DateTime.Now;
            var user = "idei";
            var message = "テストです";             
            WriteLog("Time:{0:f} User:{1} Message:{2}", time, user, message);
        }
        // List 4-37
        private void WriteLog(string format, params object[] args) {
            var s = String.Format(format, args);   
            // ログファイルへ出力する   
            WriteLine(s);
        }

        private void WriteLine(string line) {
            // 仮のコード。
            Console.WriteLine(line);
        }

        [ListNo("List 4-38")]
        public void Sample03() {
            DoSomething(100);
            DoSomething(100, "エラーです");
            DoSomething(100, "エラーです", 5);

        }

        // List 4-38
        private void DoSomething(int num, string message = "失敗しました", int retryCount = 3) {
            // 仮のコード。
            Console.WriteLine("{0} {1} {2}",num, message, retryCount);
        }

    }
}
