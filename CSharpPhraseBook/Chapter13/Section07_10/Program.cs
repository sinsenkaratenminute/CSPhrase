using SampleEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleEntityFramework {
    class Program {
        static void Main(string[] args) {
            AddBooks();
            DisplayAllBooks();
            Console.Write("テスト用データを追加しました。List 13-11を実行します。Enterキーを押してください。");
            Console.ReadLine();
            UpdateBook();
            DisplayAllBooks();
            Console.WriteLine();

            Console.Write("List 13-12を実行します。Enterキーを押してください。");
            Console.ReadLine();
            DeleteBook();
            DisplayAllBooks();
            Console.WriteLine();

            Console.Write("サンプルクエリを実行します。Enterキーを押してください。");
            Console.ReadLine();

            QuerySample01();
            Console.WriteLine("----");
            QuerySample02();
            Console.WriteLine("----");
            QuerySample03();
            Console.WriteLine("----");
            QuerySample04();
            Console.WriteLine("----");


            Console.Write("List 13-14を実行します。Enterキーを押してください。");
            Console.ReadLine();
            foreach (var book in GetBooks()) {
                Console.WriteLine($"{book.Title} {book.Author.Name}");
            }

            Console.ReadLine();
        }

        // id=10 の書籍を作るために書籍を追加する
        // テスト用コード
        private static void AddBooks() {
            using (var db = new BooksDbContext()) {
                var author = db.Authors.Single(a => a.Name == "太宰治");
                var books = new Book[] {
                    new Book { Author = author, PublishedYear=1936, Title = "晩年" },
                    new Book { Author = author, PublishedYear=1939, Title = "女生徒" },
                    new Book { Author = author, PublishedYear=1941, Title = "新ハムレット" },
                    new Book { Author = author, PublishedYear=1945, Title = "惜別" },
                    new Book { Author = author, PublishedYear=1945, Title = "お伽草紙" },
                    new Book { Author = author, PublishedYear=1946, Title = "パンドラの匣" },
                    new Book { Author = author, PublishedYear=1947, Title = "ヴィヨンの妻" },
                    new Book { Author = author, PublishedYear=1948, Title = "桜桃" },
                };
                foreach (var book in books) {
                    db.Books.Add(book);
                }
                db.SaveChanges();
            }
        }


        // List 13-11
        private static void UpdateBook() {
            using (var db = new BooksDbContext()) {
                var book = db.Books.Single(x => x.Title == "銀河鉄道の夜");
                book.PublishedYear = 2016;
                db.SaveChanges();
            }
        }

        // List 13-12
        private static void DeleteBook() {
            using (var db = new BooksDbContext()) {
                var book = db.Books.SingleOrDefault(x => x.Id == 10);
                if (book != null) {
                    db.Books.Remove(book);
                    db.SaveChanges();
                }
            }
        }

         // 13.10 高度なクエリ のサンプルコード
        private static void QuerySample01() {
            using (var db = new BooksDbContext()) {
                var authors = db.Authors
                .Where(a => a.Books.Count() >= 2);
                foreach (var author in authors) {
                    Console.WriteLine($"{author.Name} {author.Gender} {author.Birthday}");
                }
            }
        }

        private static void QuerySample02() {
            using (var db = new BooksDbContext()) {
                var books = db.Books
                              .OrderBy(b => b.PublishedYear)
                              .ThenBy(b => b.Author.Name);
                foreach (var book in books) {
                    Console.WriteLine($"{book.Title} {book.PublishedYear} {book.Author.Name}");
                }
            }
        }


        private static void QuerySample03() {
            using (var db = new BooksDbContext()) {
                var groups = db.Books
                               .GroupBy(b => b.PublishedYear)
                               .Select(g => new {
                                   Year = g.Key,
                                   Count = g.Count()
                               });
                foreach (var g in groups) {
                    Console.WriteLine($"{g.Year} {g.Count}");
                }
            }
        }

        private static void QuerySample04() {
            using (var db = new BooksDbContext()) {
                var author = db.Authors
                               .Where(a => a.Books.Count() ==
                                      db.Authors.Max(x => x.Books.Count()))
                               .First();
                Console.WriteLine($"{author.Name} {author.Gender} {author.Birthday}");
            }
        }

        // List 13-14
        static IEnumerable<Book> GetBooks() {
            using (var db = new BooksDbContext()) {
                return db.Books
                         .Where(b => b.PublishedYear > 1900)
                         .Include(nameof(Author))
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
                Console.WriteLine($"{book.Id} {book.Title} {book.PublishedYear}");
            }
        }
    }
}
