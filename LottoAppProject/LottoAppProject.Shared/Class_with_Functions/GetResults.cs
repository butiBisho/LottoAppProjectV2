using System;
using System.Collections.Generic;
using System.Text;

namespace LottoAppProject.Class_with_Functions
{
    public class GetResults
    {
        public int checkComboSelected { get; set; }
        public string nums { get; set; }
        public int[] results = new int[7];
        public int[] resultsN = new int[6];
        public int[] resultsLP = new int[7];

        public void store(string combo, string num1, string num2, string num3, string num4, string num5, string num6, string bonus)
        {
            results[0] = Convert.ToInt32(num1);
            results[1] = Convert.ToInt32(num2);
            results[2] = Convert.ToInt32(num3);
            results[3] = Convert.ToInt32(num4);
            results[4] = Convert.ToInt32(num5);
            results[5] = Convert.ToInt32(num6);
            results[6] = Convert.ToInt32(bonus);
        }

        public void storeLottoPlus(string combo, string num1, string num2, string num3, string num4, string num5, string num6, string bonus)
        {
            resultsLP[0] = Convert.ToInt32(num1);
            resultsLP[1] = Convert.ToInt32(num2);
            resultsLP[2] = Convert.ToInt32(num3);
            resultsLP[3] = Convert.ToInt32(num4);
            resultsLP[4] = Convert.ToInt32(num5);
            resultsLP[5] = Convert.ToInt32(num6);
            resultsLP[6] = Convert.ToInt32(bonus);
        }

        public void storePowerBall(string num1, string num2, string num3, string num4, string num5, string bonus)
        {
            resultsN[0] = Convert.ToInt32(num1);
            resultsN[1] = Convert.ToInt32(num2);
            resultsN[2] = Convert.ToInt32(num3);
            resultsN[3] = Convert.ToInt32(num4);
            resultsN[4] = Convert.ToInt32(num5);
            resultsN[5] = Convert.ToInt32(bonus);
        }

        public string display(int check)
        {
            for (int i = 0; i < 6; i++)
            {
                if (check == 1)
                {
                    nums += "Lotto-" + results[i].ToString() + "-";
                }
                else if (check == 2)
                {
                    nums += "LottoPlus-" + results[i].ToString() + "-";
                }
                else if (check == 3)
                {
                    nums += "PowerBall-" + results[i].ToString() + "-";
                }
            }
            return nums;
        }

        public int getNumbers(int id)
        {
            return results[id];
        }

        public int getPowerBallNumbers(int id)
        {
            return resultsN[id];
        }

        public int getLottoPlus(int d)
        {
            return resultsLP[d];
        }

    }
}
