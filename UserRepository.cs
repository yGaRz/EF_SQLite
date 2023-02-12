using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EF_SQLite
{
    internal class UserRepository
    {

        //Получение пользователя по ID
        public static User? GetUser(int Id)
        {
            using (var db = new ApplicationContext())
            {
                db.Users.Load();
                List<User> users = db.Users.ToList();
                return users.Where(user => user.Id == Id).FirstOrDefault();

            }
        }

        //Смена имени пользователя
        public static void ChangeNameUser(int Id, string Name)
        {
            using (var db = new ApplicationContext())
            {

                db.Users.Load();
                List<User> users = db.Users.ToList();
                User? user = users.FirstOrDefault(user => user.Id == Id);
                if (user != null)
                {
                    user.Name = Name;
                    db.SaveChanges();
                    Console.WriteLine("User updated.");
                }

            }
        }

        //Добавлние пользователя
        public static void AddUser(User user)
        {
            using (var db = new ApplicationContext())
            {

                db.Users.Add(user);
                db.SaveChanges();
            }

        }

        //Получение списка пользователей.
        public static List<User>? GetUsers()
        {
            using (var db = new ApplicationContext())
            {
                db.Users.Load();
                List<User> users = db.Users.ToList();
                return users;
            }
        }

        public static void ClearUsers()
        {
            using (var db = new ApplicationContext())
            {
                var users = db.Users.ToList();
                db.Users.RemoveRange(users);
                db.SaveChanges();
            }
        }

        public static void UserGetBook(User? user,Book? book)
        {
            if(book != null && user!=null)
            {
                using (var db = new ApplicationContext())
                {
                    user.Books.Add(book);
                    db.Users.Update(user);
                    db.SaveChanges();
                }
            }
        }

    }
}