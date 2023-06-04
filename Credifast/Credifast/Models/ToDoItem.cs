using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Credifast.Models
{
    public class ToDoItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string User { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Edad { get; set; }

    }
}