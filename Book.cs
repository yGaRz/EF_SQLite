using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_SQLite
{
    internal class Book
    {
        public int Id { get; set; }
        public string? Autor { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }  
        public int Year { get; set; }

        public List<User> Users { get; set; } = new List<User>();
    }
}
