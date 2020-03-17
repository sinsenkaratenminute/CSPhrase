using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Section04 {
    class Program {
        static void Main(string[] args) {
            SampleCodeRunner.Run();
        }

    }

    [SampleCode("Chapter 11")]
    class SampleCode  {
        [ListNo("List 11-15")]
        public void AddElement() {
            var element = new XElement("novelist",
                new XElement("name", "菊池 寛", new XAttribute("kana", "きくち かん")),
                new XElement("birth", "1888-12-26"),
                new XElement("death", "1948-03-06"),
                new XElement("masterpieces",
                  new XElement("title", "恩讐の彼方に"),
                  new XElement("title", "真珠夫人")
                )
              );
            var xdoc = XDocument.Load("novelists.xml");
            xdoc.Root.Add(element);

            // これ以降は確認用のコード 
            foreach (var xnovelist in xdoc.Root.Elements()) {
                var xname = xnovelist.Element("name");
                var birth = (DateTime)xnovelist.Element("birth");
                Console.WriteLine("{0} {1}", xname.Value, birth.ToShortDateString());
            } 
            //Display(xdoc);
        }

        [ListNo("List 11-16")]
        public void RemoveElement() {
            var xdoc = XDocument.Load("novelists.xml");
            var elements = xdoc.Root.Elements()
                               .Where(x => x.Element("name").Value == "太宰 治");
            elements.Remove();
            Display(xdoc);
        }

        [ListNo("List 11-17")]
        public void ReplaceElement1() {
            var xdoc = XDocument.Load("novelists.xml");
            var element = xdoc.Root.Elements()
                                   .Single(x => x.Element("name").Value == "宮沢 賢治");
            string elmstring =
              @"<novelist>
                <name kana=""みやざわ けんじ"">宮澤 賢治</name>
                <birth>1896-08-27</birth>
                <death>1933-09-21</death>
                <masterpieces>
                  <title>銀河鉄道の夜</title>
                  <title>注文の多い料理店</title>
                </masterpieces>
              </novelist>";
            var newElement = XElement.Parse(elmstring);
            element.ReplaceWith(newElement);
            Display(xdoc);
        }

        [ListNo("List 11-18")]
        public void ReplaceElement2() {
            var xdoc = XDocument.Load("novelists.xml");
            Display(xdoc);
            var element = xdoc.Root.Elements()
                              .Single(x => x.Element("name").Value == "宮沢 賢治")
                              .Element("masterpieces");
            var newElement = new XElement("masterpieces",
                new XElement("title", "銀河鉄道の夜"),
                new XElement("title", "注文の多い料理店")
            );
            element.ReplaceWith(newElement);
            Display(xdoc);
        }

        [ListNo("List 11-19")]
        public void ReplaceElement3() {
            var xdoc = XDocument.Load("novelists.xml");
            var element = xdoc.Root.Elements()
                              .Select(x => x.Element("name"))
                              .Single(x => x.Value == "宮沢 賢治");
            element.Value = "宮澤 賢治";
            Display(xdoc);
        }

        // 書籍では、ロードしたXMLをそのまま保存するコードを示しているが、
        // ここでは、要素を変更後保存している。
        [ListNo("List 11-20")]
        public void SaveXMLDocument() {
            var xdoc = XDocument.Load("novelists.xml");
            var element = xdoc.Root.Elements()
                              .Select(x => x.Element("name"))
                              .Single(x => x.Value == "宮沢 賢治");
            element.Value = "宮澤 賢治";
            xdoc.Save("newNovelists.xml", SaveOptions.DisableFormatting);

            var xnewdoc = XDocument.Load("newNovelists.xml");
            Display(xnewdoc);
        }

        private void Display(XDocument xdoc) {
            // これ以降は確認用のコード
            foreach (var xnovelist in xdoc.Root.Elements()) {
                var xname = xnovelist.Element("name");
                var xkana = xname.Attribute("kana");
                var birth = (DateTime)xnovelist.Element("birth");
                var masterpieces = xnovelist.Element("masterpieces").Elements().Select(x => x.Value);
                
                Console.WriteLine("{0}({1}) {2} - {3}", xname.Value, xkana.Value, birth.ToShortDateString(),
                    string.Join(", ", masterpieces));
            }
            Console.WriteLine();
        }
    }
}
