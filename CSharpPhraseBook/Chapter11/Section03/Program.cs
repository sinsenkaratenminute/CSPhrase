using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Section03 {
    class Program {
        static void Main(string[] args) {
            SampleCodeRunner.Run();
        }
    }

    [SampleCode("Chapter 11")]
    class SampleCode  {
        [ListNo("List 11-11")]
        public void CreateXDocumentFromString() {
            string xmlstring =
                  @"<?xml version=""1.0"" encoding=""utf-8"" ?>
                    <novelists>
                      <novelist>
                        <name kana=""だざい おさむ"">太宰 治</name>
                        <birth>1909-06-19</birth>
                        <death>1948-06-13</death>
                        <masterpieces>
                          <title>斜陽</title>
                          <title>人間失格</title>
                        </masterpieces>
                      </novelist>
                    </novelists>";
            var xdoc = XDocument.Parse(xmlstring);

            // 内容を確認する
            Display(xdoc);

        }

        [ListNo("List 11-12")]
        public void CreateXElementFromString() {
            string elmstring =
              @"<novelist>
                  <name kana=""きくち かん"">菊池 寛</name>
                  <birth>1888-12-26</birth>
                  <death>1948-03-06</death>
                  <masterpieces>
                    <title>恩讐の彼方に</title>
                    <title>真珠夫人</title>
                  </masterpieces>
                </novelist>";
            XElement element = XElement.Parse(elmstring);

            var xdoc = XDocument.Load("novelists.xml");
            xdoc.Root.Add(element);

            // 内容を確認する
            Display(xdoc);
        }


        [ListNo("List 11-13")]
        public void CreateXDocumentManually() {
            var novelists = new XElement("novelists",
              new XElement("novelist",
                new XElement("name", "夏目 漱石", new XAttribute("kana", "なつめ そうせき")),
                new XElement("birth", "1867-02-09"),
                new XElement("death", "1916-12-09"),
                new XElement("masterpieces",
                    new XElement("title", "吾輩は猫である"),
                    new XElement("title", "坊っちゃん"),
                    new XElement("title", "こゝろ")
                )
              ),
              new XElement("novelist",
                  new XElement("name", "川端 康成", new XAttribute("kana", "かわばた やすなり")),
                  new XElement("birth", "1899-06-14"),
                  new XElement("death", "1972-04-16"),
                  new XElement("masterpieces",
                     new XElement("title", "雪国"),
                     new XElement("title", "伊豆の踊子")
                  )
              )
            );
            var xdoc = new XDocument(novelists);

            // 内容を確認する  ToString()でXML形式の文字列を取得できる。
            Console.WriteLine(xdoc.ToString());
        }

        [ListNo("List 11-14")]
        public void CreateXDocumentFromCollection() {
            // Novelistのリストを用意
            var novelists = new List<Novelist> {
              new Novelist {
                Name = "夏目 漱石",
                KanaName = "なつめ そうせき",
                Birth = DateTime.Parse("1867-02-09"),
                Death = DateTime.Parse("1916-12-09"),
                Masterpieces = new string[] { "吾輩は猫である", "坊っちゃん", },
              },
              new Novelist {
                  Name = "川端 康成",
                  KanaName = "かわばた やすなり",
                  Birth = DateTime.Parse("1899-06-14"),
                  Death = DateTime.Parse("1972-04-16"),
                  Masterpieces = new string[] { "雪国", "伊豆の踊子", },
              },

            };

            // Linq to Objectsを使い、リストの内容をXElementnのシーケンスに変換
            var elements = novelists.Select(x =>
              new XElement("novelist",
                new XElement("name", x.Name, new XAttribute("kana", x.KanaName)),
                new XElement("birth", x.Birth),
                new XElement("death", x.Death),
                new XElement("masterpieces", x.Masterpieces.Select(t => new XElement("title", t)))
              )
            );

            // 最上位のnovelists要素を作成
            var root = new XElement("novelists", elements);

            // root要素を指定し、XDocumentオブジェクトを生成
            var xdoc = new XDocument(root);

            // 内容を確認する
            Display(xdoc);

        }

        private void Display(XDocument xdoc) {
            // これ以降は確認用のコード
            foreach (var xnovelist in xdoc.Root.Elements()) {
                var xname = xnovelist.Element("name");
                var birth = (DateTime)xnovelist.Element("birth");
                var death = (DateTime)xnovelist.Element("death");
                var masterpieces = xnovelist.Element("masterpieces").Elements().Select(x => x.Value);

                Console.WriteLine("{0}({1}-{2}) - {3}", xname.Value, birth.ToShortDateString(), death.ToShortDateString(),
                    string.Join(", ", masterpieces));
            }
            Console.WriteLine();
        }

    }


}
