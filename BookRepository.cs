using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EF_SQLite
{
    internal class BookRepository
    {
        public static Book? GetBook(int Id)
        {
            using (var db = new ApplicationContext())
            {

                db.Books.Load();
                List<Book> books = db.Books.ToList();
                return books.Where(book => book.Id == Id).FirstOrDefault();

            }
        }

        public static void ChangeBookYear(int Id, int year)
        {
            using (var db = new ApplicationContext())
            {

                db.Books.Load();
                List<Book> books = db.Books.ToList();
                Book? book = books.FirstOrDefault(book => book.Id == Id);
                if (book != null)
                {
                    book.Year = year;
                    db.SaveChanges();
                    Console.WriteLine("Book updated.");
                }

            }
        }

        //Добавлние книги
        public static void AddBook(Book book)
        {
            using (var db = new ApplicationContext())
            {

                db.Books.Add(book);
                db.SaveChanges();

            }
        }


        //Получение списка книг.
        public static List<Book>? GetBooks()
        {
            using (var db = new ApplicationContext())
            {
                db.Books.Load();
                List<Book> books = db.Books.ToList();
                return books;
            }
        }
        //Очистка списка книг.
        public static void ClearBooks()
        {
            using (var db = new ApplicationContext())
            {
                var books = db.Books.ToList();
                db.Books.RemoveRange(books);
                db.SaveChanges();

            }
        }

    }
}
