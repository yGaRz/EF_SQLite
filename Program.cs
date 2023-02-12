using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace EF_SQLite 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Используем для удаления БД.
            using (var db = new ApplicationContext())
            {
                db.Database.EnsureDeleted();
            }
            //Скрипт для инициализации
            UserRepository.AddUser(new User { Name = "Кирилл", Email = "k@ya.ru", Role = "User" });
            UserRepository.AddUser(new User { Name = "Михаил", Email = "m@ya.ru", Role = "Manager" });
            UserRepository.AddUser(new User { Name = "Андрей", Email = "a@ya.ru", Role = "User" });
            PrintAllUser();
            //Обновление пользователя
            UserRepository.ChangeNameUser(2, "Илья");
            PrintAllUser();
            Console.WriteLine("--------------------------------");
            BookRepository.ClearBooks();
            BookRepository.AddBook(new Book { Year = 1984, Title = "1984", Autor = "Оурэлл", Genre = "Фантастика" });
            BookRepository.AddBook(new Book { Year = 1995, Title = "Стихи", Autor = "Пушкин", Genre="Стихи" });
            BookRepository.AddBook(new Book { Year = 2000, Title = "Му-му", Autor = "Тургенев", Genre="Проза" });
            BookRepository.AddBook(new Book { Year = 2005, Title = "Рыцари 40 островов", Autor = "Лукъяненко",Genre="Фантастика" });
            PrintAllBooks();

            User? user1 = UserRepository.GetUser(1);
            Book? book1 = BookRepository.GetBook(2);
            UserRepository.UserGetBook(user1, book1);
        }

        public static void PrintAllUser()
        {
            List<User>? users = UserRepository.GetUsers();
            if (users != null)
            {
                foreach (User user in users)
                {
                    Console.WriteLine($"{user.Id} | {user.Name} | {user.Email} | {user.Role}");
                }
            }
            else
                Console.WriteLine("Connection fail.");
        }

        public static void PrintAllBooks()
        {
            List<Book>? books = BookRepository.GetBooks();
            if (books != null)
            {
                foreach (Book book in books)
                {
                    Console.WriteLine($"{book.Id} | {book.Autor} | {book.Title}| {book.Genre} | {book.Year}");
                }
            }
            else
                Console.WriteLine("Connection fail.");
        }
    }
}

//TODO: Задание 25.4.3*
//Пришло время расширить проект и добавить в него некоторые новые части.
//Реализуйте с помощью одной из связей возможность получения книги «на руки» пользователем
//(для этого придется удалить таблицы из БД, либо воспользоваться EnsureDeleted).
//А также придумайте, как можно добавить в книгу автора и жанр книги.