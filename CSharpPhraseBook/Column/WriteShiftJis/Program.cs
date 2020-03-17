using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// p.232「コラム「文字エンコーディングを指定したファイル出力」のコード
//
// C:\Example フォルダを用意してから実行してください。

namespace WriteShiftJis {
    class Program {
        static void Main(string[] args) {
            var filePath = @"C:\Example\Greeting.txt";
            var sjis = Encoding.GetEncoding("shift_jis");
            using (var writer = new StreamWriter(filePath, append: false, encoding: sjis)) {
                writer.WriteLine("色はにほへど　散りぬるを");
                writer.WriteLine("我が世たれぞ　常ならむ");
                writer.WriteLine("有為の奥山　今日越えて");
                writer.WriteLine("浅き夢見じ　酔ひもせず");
            }
        }
    }
}
