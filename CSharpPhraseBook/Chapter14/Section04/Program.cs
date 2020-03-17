using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace Section04 {
    class Program {
        static void Main(string[] args) {
            SampleCodeRunner.Run();
        }
    }

    [SampleCode("Chapter 14")]
    class SampleCode  {

		[ListNo("List 14-15")]
        public void DownloadString() {
            var wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            var html = wc.DownloadString("https://www.visualstudio.com/");

            // 最初の3000文字だけ出力
            Console.WriteLine(html.Substring(0,3000));
        }

        // これは該当するURLが実在しないので、実行できません。

		[ListNo("List 14-16")]
        private void DownloadFile() {
            var wc = new WebClient();
            var url = "http://localhost/example.zip";
            var filename = @"D:\temp\example.zip";
            wc.DownloadFile(url, filename);
            Console.ReadLine();
        }

        // このメソッドは、環境を整えないと実行できません。
        // 指定したURLが存在しないため、例外が発生します。
        // そのため、当コンソールアプリを起動しても、呼び出さないようにしています。
		[ListNo("List 14-17")]
        private void DownloadFileAsync() {
            var wc = new WebClient();
            var url = new Uri("http://localhost/example.zip");
            var filename = @"D:\temp\example.zip";
            wc.DownloadProgressChanged += wc_DownloadProgressChanged;
            wc.DownloadFileCompleted += wc_DownloadFileCompleted;
            wc.DownloadFileAsync(url, filename);
        }

        static void wc_DownloadProgressChanged(object sender,
                            DownloadProgressChangedEventArgs e) {
            Console.WriteLine("{0}% {0}/{1}", e.ProgressPercentage,
                              e.BytesReceived, e.TotalBytesToReceive);
        }

        static void wc_DownloadFileCompleted(object sender,
                            System.ComponentModel.AsyncCompletedEventArgs e) {
            Console.WriteLine("ダウンロード完了");
        }

        

		[ListNo("List 14-18")]
        public void OpenReadSample() {
            var wc = new WebClient();
            using (var stream = wc.OpenRead(@"http://gihyo.jp/book/list"))
            using (var sr = new StreamReader(stream, Encoding.UTF8)) {
                string html = sr.ReadToEnd();
                // 最初の2000文字だけ出力
                Console.WriteLine(html.Substring(0, 2000));
            }
        }


        [ListNo("List 14-19")]
        public void YahooWeather() {
            var results = GetWeatherReportFromYahoo(4610);
            foreach (var s in results)
                Console.WriteLine(s);
        }

        private static IEnumerable<string> GetWeatherReportFromYahoo(int cityCode) {
            using (var wc = new WebClient()) {
                wc.Headers.Add("Content-type", "charset=UTF-8");
                var uriString = string.Format(
                    @"http://rss.weather.yahoo.co.jp/rss/days/{0}.xml", cityCode);
                var url = new Uri(uriString);
                var stream = wc.OpenRead(url);

                XDocument xdoc = XDocument.Load(stream);
                var nodes = xdoc.Root.Descendants("title");
                foreach (var node in nodes) {
                    string s = Regex.Replace(node.Value,"【|】", "");
                    yield return node.Value;
                }
            }
        }


        [ListNo("List 14-20")]
        public void GetWikipediaData() {
            var keyword = "算用記";
            var content = GetFromWikipedia(keyword);
            Console.WriteLine(content ?? "見つかりませんでした");
        }

        private static string GetFromWikipedia(string keyword) {
            var wc = new WebClient();
            wc.QueryString = new NameValueCollection() {
                ["action"] = "query",
                ["prop"] = "revisions",
                ["rvprop"] = "content",
                ["format"] = "xml",
                ["titles"] = HttpUtility.UrlEncode(keyword, Encoding.UTF8),
            };
            wc.Headers.Add("Content-type", "charset=UTF-8");
            var result = wc.DownloadString("http://ja.wikipedia.org/w/api.php");
            var xmldoc = XDocument.Parse(result);
            var rev = xmldoc.Root.Descendants("rev").FirstOrDefault();
            // 書籍では、HttpUtilityクラスを使っていましたが、このサンプルコードでは、
            // .NET Framework4 で追加された WebUtility を利用しています。
            // .NET Framework3.5がターゲットの場合は、HttpUtilityクラスを利用してください。
            return WebUtility.HtmlDecode(rev?.Value);
        }

    }
}
