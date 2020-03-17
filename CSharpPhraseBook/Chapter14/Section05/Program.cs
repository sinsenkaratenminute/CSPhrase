using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section05 {
    class Program {
        // 当サンプルコードは、コードで指定したファイルとフォルダが無いと実行できません。
        // ご自身で環境を作成してください。
        static void Main(string[] args) {
            // 連続実行させる場合に対応するため、不要なファイルを削除
            if (Directory.Exists(@"C:\Temp\zip"))
                Directory.Delete(@"C:\Temp\zip", recursive: true);
            if (File.Exists(@"c:\Archives\newArchive.zip"))
                File.Delete(@"c:\Archives\newArchive.zip");
            SampleCodeRunner.Run();
        }
    }

    [SampleCode("Chapter 14")]
    class SampleCode  {

		[ListNo("List 14-21")]
        public void ExtractToDirectory() {
            var archiveFile = @"c:\Archives\example.zip";
            var destinationFolder = @"c:\Temp\zip";
            if (!Directory.Exists(destinationFolder)) {
                ZipFile.ExtractToDirectory(archiveFile, destinationFolder);
            }
        }

		[ListNo("List 14-22")]
        public void GetEntries() {
            var archiveFile = @"c:\Archives\example.zip";
            using (ZipArchive zip = ZipFile.OpenRead(archiveFile)) {
                var entries = zip.Entries;
                foreach (var entry in entries) {
                    Console.WriteLine(entry.FullName);
                }
            }
        }

		[ListNo("List 14-23")]
        public void ExtractToFile() {
            var name = "sample.txt";
            var archiveFile = @"c:\Archives\example.zip";
            using (var zip = ZipFile.OpenRead(archiveFile)) {
                // 最初に見つかったファイルを抽出
                var entry = zip.Entries.FirstOrDefault(x => x.Name == name);
                if (entry != null) {
                    var destPath = Path.Combine(@"c:\Temp\", entry.FullName);
                    Directory.CreateDirectory(Path.GetDirectoryName(destPath));
                    entry.ExtractToFile(destPath, overwrite: true);
                }
            }
        }

        // メソッドの連続実行を可能にするために、フォルダ名は書籍のコードから変更してあります。
        [ListNo("List 14-24")]
		public void CreateFromDirectory() {
            var sourceFolder = @"c:\Temp\zip";
            var archiveFile = @"c:\Archives\newArchive.zip";
            ZipFile.CreateFromDirectory(sourceFolder, archiveFile, CompressionLevel.Fastest, includeBaseDirectory: false);
	    }

    }
}
