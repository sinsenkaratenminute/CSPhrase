using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section04 {
    class Program {
        static void Main(string[] args) {
            // Todayはstaticプロパティ
            DateTime today = DateTime.Today;

            // Consoleはstaticクラス、WriteLineは、staticメソッド
            Console.WriteLine("今日は{0}月{1}日です", today.Month, today.Day);

        }
    }
}
