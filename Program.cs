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
            //Скрипт для инициализации с нуля, ID будут сдвигаться по мере перезапуска/удалении
            //UserRepository.ClearUsers();
            //UserRepository.AddUser(new User { Name = "Кирилл", Email = "k@ya.ru", Role = "User" });
            //UserRepository.AddUser(new User { Name = "Михаил", Email = "m@ya.ru", Role = "Manager" });
            //UserRepository.AddUser(new User { Name = "Андрей", Email = "a@ya.ru", Role = "User" });
            //PrintAllUser();
            //UserRepository.ChangeNameUser(8, "Илья");
            PrintAllUser();


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
    }
}

//TODO:Задание 25.3.5*
//Для каждой из моделей в приложении создайте собственный класс-репозиторий (например, UserRepository и BookRepository),
//в которых опишите следующие действия:
//выбор объекта из БД по его идентификатору,
//выбор всех объектов, добавление объекта в БД и его удаление из БД.
//А также специфичные методы: обновление имени пользователя (по Id) и обновление года выпуска книги (по Id).

//TODO: Задание 25.4.3*
//Пришло время расширить проект и добавить в него некоторые новые части.
//Реализуйте с помощью одной из связей возможность получения книги «на руки» пользователем
//(для этого придется удалить таблицы из БД, либо воспользоваться EnsureDeleted).
//А также придумайте, как можно добавить в книгу автора и жанр книги.