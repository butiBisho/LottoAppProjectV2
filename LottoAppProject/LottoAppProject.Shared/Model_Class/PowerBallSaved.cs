using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LottoAppProject.Model_Class
{
    [Table("PowerBallSaved")]
    public class PowerBallSaved
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int num1 { get; set; }
        public int num2 { get; set; }
        public int num3 { get; set; }
        public int num4 { get; set; }
        public int num5 { get; set; } 
    }
}
