using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace LottoAppProject.Model_Class
{
    [Table("LottoSaved")]
    public class LottoSaved
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int num1 { get; set; }
        public int num2 { get; set; }
        public int num3 { get; set; }
        public int num4 { get; set; }
        public int num5 { get; set; }
        public int num6 { get; set; }
    }
}
