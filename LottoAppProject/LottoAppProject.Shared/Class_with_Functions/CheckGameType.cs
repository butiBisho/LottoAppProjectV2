using System;
using System.Collections.Generic;
using System.Text;

namespace LottoAppProject.Class_with_Functions
{
    public class CheckGameType
    {
        public int gameType(string gt)
        {
            int num = 0;
            if (gt == "Lotto")
            {
                num = 1;
            }
            else if (gt == "LottoPlus")
            {
                num = 2;
            }
            else if (gt == "PowerBall")
            {
                num = 3;
            }
            return num;
        }
    }
}
