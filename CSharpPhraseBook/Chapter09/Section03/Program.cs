using Gushwell.CsBook;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section03 {
    class Program {
        static void Main(string[] args) {
            SampleCodeRunner.Run();
        }
    }
    [SampleCode("Chapter 9")]
    class SampleCode  {
        // このクラスのメソッドを連続実行するために、最初に動かしておくメソッド。
        // 繰り返し実行する際も、例外が発生しないようにする。
        public void Start() {
            Directory.CreateDirectory(@"C:\Example\src");
            Directory.CreateDirectory(@"C:\Example\dest");            

            if (!File.Exists(@"C:\Example\Greeting.txt")) {
                File.WriteAllText(@"C:\Example\Greeting.txt", "Sample Sample Sample");
            }
            if (!File.Exists(@"C:\Example\src\Greeting.txt")) {
                File.WriteAllText(@"C:\Example\src\Greeting.txt", "Sample Sample Sample");
            }
            if (!File.Exists(@"C:\Example\src\Greeting2.txt")) {
                var fi = File.Create(@"C:\Example\src\Greeting2.txt");
                fi.Close();
            }
            if (!File.Exists(@"C:\Example\src\oldfile.txt")) {
                var fi = File.Create(@"C:\Example\src\oldfile.txt");
                fi.Close();
            }
            if (!File.Exists(@"C:\Example\src\oldfile2.txt")) {
                var fi = File.Create(@"C:\Example\src\oldfile2.txt");
                fi.Close();
            }
            if (!File.Exists(@"C:\Example\source.txt")) {
                var fi = File.Create(@"C:\Example\source.txt");
                fi.Close();
            }

            File.Delete(@"C:\Example\src\newfile.txt");
            File.Delete(@"C:\Example\src\newfile2.txt");
            File.Delete(@"C:\Example\dest\Greeting.txt");
            File.Delete(@"C:\Example\dest\Greeting2.txt");
        }

        [ListNo("List 9-18")]
        public void ExistsFile() {
            if (File.Exists(@"C:\Example\Greeting.txt")) {
                Console.WriteLine("すでに存在しています。");
            }
        }

        [ListNo("List 9-19")]
        public void ExistsFile2() {
            var fi = new FileInfo(@"C:\Example\Greeting.txt");
            if (fi.Exists)
                Console.WriteLine("すでに存在しています。");
        }


        [ListNo("List 9-20")]
        public void DeleteFile() {
            File.Delete(@"C:\Example\Greeting.txt");
        }

        [ListNo("List 9-21")]
        public void DeleteFile2() {
            var fi = new FileInfo(@"C:\Example\Greeting.txt");
            fi.Delete();
        }


        [ListNo("List 9-22")]
        public void CopyFile() {
            // サンプルメソッドの連続実行可能にするため。
            File.Delete(@"C:\Example\target.txt");

            // ここからが実際のコード
            File.Copy(@"C:\Example\source.txt", @"C:\Example\target.txt");
        }


        [ListNo("List 9-23")]
        public void CopyFile2() {
            var fi = new FileInfo(@"C:\Example\source.txt");
            FileInfo dup = fi.CopyTo(@"C:\Example\target.txt", overwrite: true);
        }


        [ListNo("List 9-24")]
        public void MoveFile() {
            File.Move(@"C:\Example\src\Greeting.txt", @"C:\Example\dest\Greeting.txt");
        }

        [ListNo("List 9-25")]
        public void MoveFile2() {
            var fi = new FileInfo(@"C:\Example\src\Greeting2.txt");
            fi.MoveTo(@"C:\Example\dest\Greeting2.txt");
            
        }

        [ListNo("List 9-26")]
        public void RenameFile() {
            File.Move(@"C:\Example\src\oldfile.txt", @"C:\Example\src\newfile.txt");
        }

        [ListNo("List 9-27")]
        public void RenameFile2() {
            var fi = new FileInfo(@"C:\Example\src\oldfile2.txt");
            fi.MoveTo(@"C:\Example\src\newfile2.txt");
        }

        [ListNo("List 9-28")]
        public void GetLastWriteTime() {
            // サンプルメソッドの連続実行可能にするため。
            File.Move(@"C:\Example\dest\Greeting.txt", @"C:\Example\Greeting.txt");

            // ここからが実際のコード
            var lastWriteTime = File.GetLastWriteTime(@"C:\Example\Greeting.txt");
            Console.WriteLine(lastWriteTime);
        }

        [ListNo("List 9-29")]
        public void SetLastWriteTime() {
            File.SetLastWriteTime(@"C:\Example\Greeting.txt", DateTime.Now);

            var lastWriteTime = File.GetLastWriteTime(@"C:\Example\Greeting.txt");
            Console.WriteLine(lastWriteTime);
        }


        [ListNo("List 9-30")]
        public void GetLastWriteTime2() {
            var fi = new FileInfo(@"C:\Example\Greeting.txt");
            DateTime lastWriteTime = fi.LastWriteTime;
            Console.WriteLine(lastWriteTime);
        }

        [ListNo("List 9-31")]
        public void SetLastWriteTime2() {
            var fi = new FileInfo(@"C:\Example\Greeting.txt");
            fi.LastWriteTime = DateTime.Now;

            var lastWriteTime = File.GetLastWriteTime(@"C:\Example\Greeting.txt");
            Console.WriteLine(lastWriteTime);
        }

        [ListNo("List 9-32")]
        public void GetCreationTime() {
            var finfo = new FileInfo(@"C:\Example\Greeting.txt");
            DateTime lastCreationTime = finfo.CreationTime;
            Console.WriteLine(lastCreationTime);
        }

        [ListNo("List 9-33")]
        public void GetFileSize() {
            var fi = new FileInfo(@"C:\Example\Greeting.txt");
            long size = fi.Length;
            Console.WriteLine(size);
        }



    }
}
