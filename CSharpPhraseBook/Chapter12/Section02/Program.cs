using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Section02 {
    class Program {
        static void Main(string[] args) {
            SampleCodeRunner.Run();
        }
    }

    [SampleCode("Chapter 12")]
    class SampleCode  {


        [ListNo("List 12-6")]
        public void SerializeToFile() {
            var novel = new Novel {
                Author = "ジェイムズ・P・ホーガン",
                Title = "星を継ぐもの",
                Published = 1977,
            };
            using (var writer = XmlWriter.Create("novel.xml")) {
                var serializer = new XmlSerializer(novel.GetType());
                serializer.Serialize(writer, novel);
            }

            Display("novel.xml");

        }

        public void SerializeToString() {
            var novel = new Novel {
                Author = "ジェイムズ・P・ホーガン",
                Title = "星を継ぐもの",
                Published = 1977,
            };
            var sb = new StringBuilder();
            using (var writer = XmlWriter.Create(sb)) {
                var serializer = new XmlSerializer(novel.GetType());
                serializer.Serialize(writer, novel);
            }
            var xmlText = sb.ToString();
            Console.WriteLine(xmlText);
        }

        public void SerializeToStream() {
            var novel = new Novel {
                Author = "ジェイムズ・P・ホーガン",
                Title = "星を継ぐもの",
                Published = 1977,
            };
            var stream = new MemoryStream();
            using (var writer = XmlWriter.Create(stream)) {
                var serializer = new XmlSerializer(novel.GetType());
                serializer.Serialize(writer, novel);
            }
            // バッファにあるデータをすべてストリームに書き出す
            stream.Flush();
            
            // Positionを0 にしてリワインドする。
            stream.Position = 0;
            // StreamReaderを使って、MemoryStreamの内容を読み取る
            var reader = new StreamReader(stream);
            while (!reader.EndOfStream) {
                var line = reader.ReadLine();
                Console.WriteLine(line);
            }
        }


        [ListNo("List 12-7")]
        public void Deserialize() {
            using (var reader = XmlReader.Create("novel.xml")) {
                var serializer = new XmlSerializer(typeof(Novel));
                var novel = serializer.Deserialize(reader) as Novel;
                // 以下、内容を確認するコード
                Console.WriteLine(novel);
            }
        }

        public void DeserializeFromString() {
            string xmlText = GetXmlString();

            using (var reader = XmlReader.Create(new StringReader(xmlText))) {
                var serializer = new XmlSerializer(typeof(Novel));
                var novel = serializer.Deserialize(reader) as Novel;
                Console.WriteLine(novel);
            }
        }


        private static string GetXmlString() {
            var novel = new Novel {
                Author = "ジェイムズ・P・ホーガン",
                Title = "星を継ぐもの",
                Published = 1977,
            };
            var sb = new StringBuilder();
            using (var writer = XmlWriter.Create(sb)) {
                var serializer = new XmlSerializer(typeof(Novel));
                serializer.Serialize(writer, novel);
            }
            var xmlText = sb.ToString();
            return xmlText;
        }

        // リスト 12.12 のクラス定義に対して、シリアライズする。
        [ListNo("List 12-11")]
        public void SerializeCollection() {
            var novels = new Novel[] {
               new Novel {
                  Author = "ジェイムズ・P・ホーガン",
                  Title = "星を継ぐもの",
                  Published = 1977,
               },
               new Novel {
                  Author = "H・G・ウェルズ",
                  Title = "タイム・マシン",
                  Published = 1895,
               },
            };
            var novelCollection = new NovelCollection {
                Novels = novels
            };

            using (var writer = XmlWriter.Create("novels.xml")) {
                var serializer = new XmlSerializer(novelCollection.GetType());
                serializer.Serialize(writer, novelCollection);
            }

            Display("novels.xml");


            // 以下は、p.310下部のコード。
            // このコードを実行し、本の説明と同じ結果にするには、Novelistクラス(Novelist.cs)に付加した
            // 4つすべての属性をコメントアウトして単独で実行してください。
            //
            //var novelist = new Novelist {
            //    Name = "アーサー・C・クラーク",
            //    Masterpieces = new string[] {
            //        "2001年宇宙の旅",
            //        "幼年期の終り",
            //    }
            //};
            //using (var writer = XmlWriter.Create("novelist.xml")) {
            //    var serializer = new XmlSerializer(novelist.GetType());
            //    serializer.Serialize(writer, novelist);
            //}
            //
            //Display("novelist.xml");
        }


        [ListNo("List 12-13")]
        public void SerializeArrayMember() {
            using (var reader = XmlReader.Create("novels.xml")) {
                var serializer = new XmlSerializer(typeof(NovelCollection));
                var novels = serializer.Deserialize(reader) as NovelCollection;
                foreach (var novel in novels.Novels) {
                    Console.WriteLine(novel);
                }
            }


            Display("novels.xml");

        }

        private void Display(string filename) {
            var lines = File.ReadLines(filename);
            foreach (var line in lines)
                Console.WriteLine(line);

        }

    }
}
