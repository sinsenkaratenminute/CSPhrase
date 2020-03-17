using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section04 {
    class Program {
        static void Main(string[] args) {
            // ここでは、メソッドの連続実行は行わない
            // メソッドを実行するには、それぞれ事前にディレクトリ・ファイルの環境を整える必要がある。
        }
    }

    [SampleCode("Chapter 9")]
    class SampleCode {

        [ListNo("List 9-34")]
        public void ExistsDirectory() {
            if (Directory.Exists(@"C:\Example")) {
                Console.WriteLine("存在しています");
            } else {
                Console.WriteLine("存在していません");
            }
        }

        [ListNo("List 9-35")]
        public void CreateDirectory() {
            DirectoryInfo di = Directory.CreateDirectory(@"C:\Example");
        }

        [ListNo("List 9-36")]
        public void CreateDirectory2() {
            DirectoryInfo di = Directory.CreateDirectory(@"C:\Example\temp");
        }

        [ListNo("List 9-37")]
        public void CreateDirectory3() {
            var di = new DirectoryInfo(@"C:\Example");
            di.Create();
        }

        public void CreateDirectory4() {
            DirectoryInfo di = Directory.CreateDirectory(@"C:\Example");
            // DirectoryInfoオブジェクトdiは生成済み
            DirectoryInfo sdi = di.CreateSubdirectory("temp");
        }

        [ListNo("List 9-38")]
        public void DeleteDirectory() {
            Directory.Delete(@"C:\Example\temp");
        }



        [ListNo("List 9-39")]
        public void DeleteDirectoryRecursive() {
            Directory.Delete(@"C:\Example\temp", recursive: true);
        }


        [ListNo("List 9-40")]
        public void DeleteDirectoryRecursive2() {
            var di = new DirectoryInfo(@"C:\Example\temp");
            // DirectoryInfoオブジェクトdiは生成済み
            di.Delete(recursive: true);
        }

        [ListNo("List 9-41")]
        public void MoveDirectory() {
            Directory.Move(@"C:\Example\temp", @"C:\MyWork");
        }

        [ListNo("List 9-42")]
        public void MoveDirectory2() {
            var di = new DirectoryInfo(@"C:\Example\temp");
            // DirectoryInfoオブジェクトdiは生成済み
            di.MoveTo(@"C:\MyWork");
        }

        [ListNo("List 9-43")]
        public void RenameDirectory() {
            Directory.Move(@"C:\Example\temp", @"C:\Example\save");
        }

        [ListNo("List 9-44")]
        public void RenameDirectory2() {
            var di = new DirectoryInfo(@"C:\Example\temp");
            // DirectoryInfoオブジェクトdiは生成済み
            di.MoveTo(@"C:\Example\save");
        }


        [ListNo("List 9-45")]
        public void GetDirectories() {
            var di = new DirectoryInfo(@"C:\Example");
            DirectoryInfo[] directories = di.GetDirectories();
            foreach (var dinfo in directories) {
                Console.WriteLine(dinfo.FullName);
            }
        }

        [ListNo("List 9-46")]
        public void GetDirectoriesWithWildCard() {
            var di = new DirectoryInfo(@"C:\");
            DirectoryInfo[] directories = di.GetDirectories("P*");
            foreach (var dinfo in directories) {
                Console.WriteLine(dinfo.FullName);
            }
        }

        [ListNo("List 9-47")]
        public void GetAllDirectories() {
            var di = new DirectoryInfo(@"C:\Example");
            DirectoryInfo[] directories = di.GetDirectories("*", SearchOption.AllDirectories);
            foreach (var item in directories) {
                Console.WriteLine(item.FullName);
            }
        }



        [ListNo("List 9-48")]
        public void EnumDirectories() {
            var di = new DirectoryInfo(@"C:\Example");
            var directories = di.EnumerateDirectories()
                                .Where(d => d.Name.Length >= 10);
            foreach (var item in directories) {
                Console.WriteLine("{0} {1}", item.FullName, item.CreationTime);
            }
        }

        [ListNo("List 9-49")]
        public void GetFiles() {
            var di = new DirectoryInfo(@"C:\Windows");
            FileInfo[] files = di.GetFiles();
            foreach (var item in files) {
                Console.WriteLine("{0} {1}", item.Name, item.CreationTime);
            }
        }

        [ListNo("List 9-50")]
        public void EnumFiles() {
            var di = new DirectoryInfo(@"C:\Example");
            var files = di.EnumerateFiles("*.txt", SearchOption.AllDirectories)
                          .Take(20);
            foreach (var item in files) {
                Console.WriteLine("{0} {1}", item.Name, item.CreationTime);
            }
        }


        [ListNo("List 9-51")]
        public void GetFilesAndDirectories() {
            var di = new DirectoryInfo(@"C:\Example");
            FileSystemInfo[] fileSystems = di.GetFileSystemInfos();
            foreach (var item in fileSystems) {
                if ((item.Attributes & FileAttributes.Directory) == FileAttributes.Directory)

                    Console.WriteLine("ディレクトリ:{0} {1}", item.Name, item.CreationTime);
                else
                    Console.WriteLine("ファイル:{0} {1}", item.Name, item.CreationTime);
            }
        }


        [ListNo("List 9-52")]
        public void EnumFilesAndDirectories() {
            var di = new DirectoryInfo(@"C:\Example");
            var fileSystems = di.EnumerateFileSystemInfos();
            foreach (var item in fileSystems) {
                if ((item.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
                    Console.WriteLine("ディレクトリ:{0} {1}", item.Name, item.CreationTime);
                else
                    Console.WriteLine("ファイル:{0} {1}", item.Name, item.CreationTime);
            }
        }

        [ListNo("List 9-53")]
        public void ChangeLastWriteTime() {
            var di = new DirectoryInfo(@"C:\Example");
            FileSystemInfo[] fileSystems = di.GetFileSystemInfos();
            foreach (var item in fileSystems) {
                item.LastWriteTime = new DateTime(2016, 6, 4, 10, 10, 10);
            }
        }

        [ListNo("List 9-memo")]

        public void CurrentDirectorySample() {
            // カレントディレクトリを取得
            var workdir = Directory.GetCurrentDirectory();
            Console.WriteLine(workdir);

            // カレントディレクトリを変更
            Directory.SetCurrentDirectory(@"C:\\Example");

            // 再度カレントディレクトリを取得し、コンソールに出力して確認
            var newWorkdir = Directory.GetCurrentDirectory();
            Console.WriteLine(newWorkdir);
        }

        [ListNo("List 9-memo")]
        public void FileAttributesSample() {
            var fi = new FileInfo(@"C:\\Example\\Greeting.txt");
            if ((fi.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly) {
                Console.WriteLine("ReadOnlyファイルです");
            }
            if ((fi.Attributes & FileAttributes.System) == FileAttributes.System) {
                Console.WriteLine("Systemファイルです");
            }
        }
    }
}
