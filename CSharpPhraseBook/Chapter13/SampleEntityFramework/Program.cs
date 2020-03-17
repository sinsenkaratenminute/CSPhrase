using SampleEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleEntityFramework {

    // 当プログラムは、繰り返し実行することは想定していません。
    // 繰り返し実行する際は、p.331にある「コラム：データベースを再作成する場合の操作手順」に従って、
    // データベースをいったん削除してから、実行してください。
    
    class Program {
        static void Main(string[] args) {
            InsertBooks();
            Console.Write("データを挿入しました。続けるにはEnterキーを押してください。");
            Console.ReadLine();
            Console.WriteLine();

            DisplayAllBooks();
            Console.Write("すべての書籍を表示しました。続けるにはEnterキーを押してください。");
            Console.ReadLine();
            Console.WriteLine();

            AddAuthors();
            Console.Write("著者を追加しました。続けるにはEnterキーを押してください。");
            Console.ReadLine();
            Console.WriteLine();

            AddBooks();
            Console.WriteLine("書籍を追加しました。");
            DisplayAllBooks();
            Console.Write("すべての書籍を表示しました。Enterキーを押してください。");
            Console.ReadLine();
        }


        // List 13-5
        static void InsertBooks() {
            using (var db = new BooksDbContext()) {
                var book1 = new Book {
                    Title = "坊ちゃん",
                    PublishedYear = 2003,
                    Author = new Author {
                        Birthday = new DateTime(1867, 2, 9),
                        Gender = "M",
                        Name = "夏目漱石",
                    }
                };
                db.Books.Add(book1);
                var book2 = new Book {
                    Title = "人間失格",
                    PublishedYear = 1990,
                    Author = new Author {
                        Birthday = new DateTime(1909, 6, 19),
                        Gender = "M",
                        Name = "太宰治",
                    }
                };
                db.Books.Add(book2);
                db.SaveChanges();
            }
        }

        // List 13-7
        static IEnumerable<Book> GetBooks() {
            using (var db = new BooksDbContext()) {
                return db.Books
                         .Where(book => book.Author.Name.StartsWith("夏目"))
                         .ToList();
            }
        }

        
        static IEnumerable<Book> GetAllBooks() {
            using (var db = new BooksDbContext()) {
                return db.Books.ToList();
            }
        }

        // List 13-8
        static void DisplayAllBooks() {
            var books = GetAllBooks();
            foreach (var book in books) {
                Console.WriteLine($"{book.Title} {book.PublishedYear}");
            }
        }

        // List 13-9
        private static void AddAuthors() {
            using (var db = new BooksDbContext()) {
                var author1 = new Author {
                    Birthday = new DateTime(1878, 12, 7),
                    Gender = "F",
                    Name = "与謝野晶子"
                };
                db.Authors.Add(author1);
                var author2 = new Author {
                    Birthday = new DateTime(1896, 8, 27),
                    Gender = "M",
                    Name = "宮沢賢治"
                };
                db.Authors.Add(author2);
                db.SaveChanges();
            }
        }

        // List 13-10
        private static void AddBooks() {
            using (var db = new BooksDbContext()) {
                var author1 = db.Authors.Single(a => a.Name == "与謝野晶子");
                var book1 = new Book {
                    Title = "みだれ髪",
                    PublishedYear = 2000,
                    Author = author1,
                };
                db.Books.Add(book1);
                var author2 = db.Authors.Single(a => a.Name == "宮沢賢治");
                var book2 = new Book {
                    Title = "銀河鉄道の夜",
                    PublishedYear = 1989,
                    Author = author2,
                };
                db.Books.Add(book2);
                db.SaveChanges();
            }
        }

    }
}
