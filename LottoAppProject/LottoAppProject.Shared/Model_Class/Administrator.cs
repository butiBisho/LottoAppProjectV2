using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace LottoAppProject.Model_Class
{
    [Table("Administrator")]
    public class Administrator
    {
        [PrimaryKey, AutoIncrement]
        public int idNum { get; set; }
        public string firstName { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
