using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LottoAppProject.Model_Class
{
    [Table("User")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Surname { get; set; }
        public string name { get; set; }
    }
}
