using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section06 {
    class Program {
        static void Main(string[] args) {
            SampleCodeRunner.Run();

        }
    }

    [SampleCode("Chapter 9")]
    class SampleCode  {

        [ListNo("List 9-59")]
        public void GetTempFileName() {
            var tempFileName = Path.GetTempFileName();
            Console.WriteLine(tempFileName);
        }

        [ListNo("List 9-60")]
        public void GetTempPath() {
            var tempPath = Path.GetTempPath();
            Console.WriteLine(tempPath);
        }

        [ListNo("List 9-61")]
        public void SpecialFolders() {  
            // デスクトップフォルダの取得
            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Console.WriteLine(desktopPath);
            // マイドキュメントフォルダの取得
            var myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Console.WriteLine(myDocumentsPath);
            // プログラムファイルフォルダの取得
            var programFilesPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            Console.WriteLine(programFilesPath);
            // Windowsフォルダの取得
            var windowsPath = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
            Console.WriteLine(windowsPath);
            // システムフォルダの取得
            var systemPath = Environment.GetFolderPath(Environment.SpecialFolder.System);
            Console.WriteLine(systemPath);
        }

    }
}
