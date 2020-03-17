using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch0405 {
    class Program {
        static void Main(string[] args) {
            // このプロジェクトでは、書籍に掲載されているコードを示していますが、
            // 実行できる完成されたコードはありません。
        }
    }

    class SampleCode {
        // List 4-31
        public int MinimumLength { get; set; } = 6;


        // List 4-32
        public string DefaultUrl { get; set; } = GetDefaultUrl();


        private static string GetDefaultUrl() {
            return "http://www.msn.com/ja-jp/news/";
        }

    }

}
