﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LottoAppProject.Model_Class
{
    [Table("LottoLiveResults")]
    public class LottoLiveResults
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string date { get; set; }
        public int num1 { get; set; }
        public int num2 { get; set; }
        public int num3 { get; set; }
        public int num4 { get; set; }
        public int num5 { get; set; }
        public int num6 { get; set; }
        public int bonus { get; set; }
    }
}
