using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LottoAppProject.Model_Class
{
    [Table("PowerBallResults")]
    public class PowerBallResults
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string dateP { get; set; }
        public int numA { get; set; }
        public int numB { get; set; }
        public int numC { get; set; }
        public int numD { get; set; }
        public int numE { get; set; }
        public int bonusP { get; set; }
    }
}
