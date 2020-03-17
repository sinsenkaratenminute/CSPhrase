using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Section04 {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private HttpClient _httpClient = new HttpClient();

        // List 16-10
        private async void button_Click(object sender, RoutedEventArgs e) {
            textBlock.Text = "";
            var text = await GetPageAsync(@"http://www.bing.com/");
            textBlock.Text = text;
        }


        private async Task<string> GetPageAsync(string urlstr) {
            var str = await _httpClient.GetStringAsync(urlstr);
            return str;
        }


        // List 16-11
        private async void button1_Click(object sender, RoutedEventArgs e) {
            textBlock.Text = "";
            var text = await GetFromWikipediaAsync("クリーンルーム設計");
            textBlock.Text = text;
        }

        private async Task<string> GetFromWikipediaAsync(string keyword) {
            // UriBuilderとFormUrlEncodedContentを使い、パラメータ付きのURLを組み立てる
            var builder = new UriBuilder("https://ja.wikipedia.org/w/api.php");
            var content = new FormUrlEncodedContent(new Dictionary<string, string>() {
                ["action"] = "query",
                ["prop"] = "revisions",
                ["rvprop"] = "content",
                ["format"] = "xml",
                ["titles"] = keyword,
            });
            builder.Query = await content.ReadAsStringAsync();

            // HttpClientを使い、wikipediaのデータを取得する。
            var str = await _httpClient.GetStringAsync(builder.Uri);

            // 取得したXML文字列から、LINQ to XMLを使い必要な情報を取り出す。
            var xmldoc = XDocument.Parse(str);
            var rev = xmldoc.Root.Descendants("rev").FirstOrDefault();
            return WebUtility.HtmlDecode(rev?.Value);
        }
    }
}
