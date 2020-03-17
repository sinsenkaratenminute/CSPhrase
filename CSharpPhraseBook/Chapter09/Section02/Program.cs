using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section02 {
    class Program {
        static void Main(string[] args) {
            if (!Directory.Exists(@"C:\Example")) {
                Console.WriteLine("実行するには、C:\\Example フォルダが存在している必要があります。");
                return;
            }
            SampleCodeRunner.Run();
        }
    }


    [SampleCode("Chapter 9")]
    class SampleCode  {

        [ListNo("List 9-12")]
        public void WriteTextFile() {
            var filePath = @"C:\Example\いろは歌.txt";
            using (var writer = new StreamWriter(filePath)) {
                writer.WriteLine("色はにほへど　散りぬるを");
                writer.WriteLine("我が世たれぞ　常ならむ");
                writer.WriteLine("有為の奥山　今日越えて");
                writer.WriteLine("浅き夢見じ　酔ひもせず");
            }
            DisplayLines(@"C:\Example\いろは歌.txt");
        }

        [ListNo("List 9-13")]
        public void AppendTextFile() {
            var lines = new[] { "====", "京の夢", "大坂の夢", };
            var filePath = @"C:\Example\いろは歌.txt";
            using (var writer = new StreamWriter(filePath, append: true)) {
                foreach (var line in lines)
                    writer.WriteLine(line);
            }
            DisplayLines(@"C:\Example\いろは歌.txt");
        }

        [ListNo("List 9-14")]
        public void WriteAllLinesSample() {
            var lines = new[] { "Tokyo", "New Delhi", "Bangkok", "London", "Paris", };
            var filePath = @"C:\Example\Cities.txt";
            File.WriteAllLines(filePath, lines);

            DisplayLines(filePath);
        }

        [ListNo("List 9-15")]
        public void WriteResultOFQuerySample() {
            var names = new List<string> {
                "Tokyo", "New Delhi", "Bangkok", "London", "Paris", "Berlin", "Canberra", "Hong Kong",
            };
            var filePath = @"C:\Example\Cities.txt";
            File.WriteAllLines(filePath, names.Where(s => s.Length > 5));

            DisplayLines(filePath);
        }


        [ListNo("List 9-16")]
        public void InsertLines() {
            var originalFilePath = @"C:\Example\いろは歌.txt";
            var filePath = @"C:\Example\いろは歌2.txt";
            File.Copy(originalFilePath, filePath, overwrite: true);

            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None)) {
                using (var reader = new StreamReader(stream))
                using (var writer = new StreamWriter(stream)) {
                    string texts = reader.ReadToEnd();
                    stream.Position = 0;
                    writer.WriteLine("挿入する新しい行1");
                    writer.WriteLine("挿入する新しい行2");
                    writer.Write(texts);
                }
            }
            DisplayLines(filePath);
        }

        [ListNo("List 9-17")]
        public void InsertLines2() {
            var originalFilePath = @"C:\Example\いろは歌.txt";
            var filePath = @"C:\Example\いろは歌2.txt";
            File.Copy(originalFilePath, filePath, overwrite: true);

            string texts = "";
            // ファイルをすべて読み込む
            using (var reader = new StreamReader(filePath)) {
                texts = reader.ReadToEnd();
            }
            // 一旦クローズ

            // 再度ファイルを開き出力処理をする
            using (var writer = new StreamWriter(filePath)) {
                writer.WriteLine("挿入する新しい行1");
                writer.WriteLine("挿入する新しい行2");
                writer.Write(texts);
            }
            DisplayLines(filePath);
        }

        private static void DisplayLines(string filePath) {
            var xlines = File.ReadAllLines(filePath, Encoding.UTF8);
            foreach (var line in xlines) {
                Console.WriteLine(line);
            }
            Console.WriteLine();
        }


    }
}
