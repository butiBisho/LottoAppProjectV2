using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace LottoAppProject.Class_with_Functions
{
    public class DisplayMessage
    {
        public async void msgBox(string msg)
        {
            var msgDisplay = new MessageDialog(msg);
            await msgDisplay.ShowAsync();
        }

        public string success(bool check)
        {
            string message = "";
            if (check == true)
            {
                message = "Successful";
            }
            else
            {
                message = "Not Successful";
            }
            return message;
        }

        public bool checkInteger(string one, string two, string three, string four, string five, string six)
        {
            bool value = false;
            int on = Convert.ToInt32(one);
            int tw = Convert.ToInt32(two);
            int thr = Convert.ToInt32(three);
            int fou = Convert.ToInt32(four);
            int fiv = Convert.ToInt32(five);
            int si = Convert.ToInt32(six);

            if ((on > 0 && on < 50) && (tw > 0 && tw < 50) && (thr > 0 && thr < 50) && (fou > 0 && fou < 50) && (fiv > 0 && fiv < 50) && (si > 0 && si < 50))
            {
                value = true;
            }
            return value;
        }

        public bool checkIntegerLottoResults(string first, string second, string third, string fourth, string fifth, string sixth, string bonus)
        {
            bool value = false;
            int on = Convert.ToInt32(first);
            int tw = Convert.ToInt32(second);
            int thr = Convert.ToInt32(third);
            int fou = Convert.ToInt32(fourth);
            int fiv = Convert.ToInt32(fifth);
            int si = Convert.ToInt32(sixth);
            int bon = Convert.ToInt32(bonus);
            if ((on > 0 && on < 50) && (tw > 0 && tw < 50) && (thr > 0 && thr < 50) && (fou > 0 && fou < 50) && (fiv > 0 && fiv < 50) && (si > 0 && si < 50) && (bon > 0 && bon < 50))
            {
                value = true;
            }
            return value;
        }

        public bool checkTextboxes(string txt1, string txt2, string txt3, string txt4, string txt5, string txt6)
        {
            bool blnCheck = false;
            if (string.IsNullOrEmpty(txt1) || string.IsNullOrEmpty(txt2) || string.IsNullOrEmpty(txt3) || string.IsNullOrEmpty(txt4) || string.IsNullOrEmpty(txt5) || string.IsNullOrEmpty(txt6))
            {
                blnCheck = true;
            }
            return blnCheck;
        }

        public bool checkNullTextboxes(string txt1, string txt2, string txt3, string txt4, string txt5, string txt6, string txtbonus)
        {
            bool blnCheck = false;
            if (string.IsNullOrEmpty(txt1) || string.IsNullOrEmpty(txt2) || string.IsNullOrEmpty(txt3) || string.IsNullOrEmpty(txt4) || string.IsNullOrEmpty(txt5) || string.IsNullOrEmpty(txt6) || string.IsNullOrEmpty(txtbonus))
            {
                blnCheck = true;
            }
            return blnCheck;
        }

        public bool checkForCharacters(string txtOne, string txttwo, string txtThree, string txtFour, string txtFive, string txtSix)
        {
            bool final = true;//if character is not found.
            int num;
            //must be false bcs tryparse returns false if character is found.
            bool valueTxt1 = Int32.TryParse(txtOne, out num);
            bool valueTxt2 = Int32.TryParse(txttwo, out num);
            bool valueTxt3 = Int32.TryParse(txtThree, out num);
            bool valueTxt4 = Int32.TryParse(txtFour, out num);
            bool valueTxt5 = Int32.TryParse(txtFive, out num);
            bool valueTxt6 = Int32.TryParse(txtSix, out num);
            if (valueTxt1 == false || valueTxt2 == false || valueTxt3 == false || valueTxt4 == false || valueTxt5 == false || valueTxt6 == false)
            {
                final = false;
            }
            return final;
        }

        public bool checkForChar(string txtOne, string txttwo, string txtThree, string txtFour, string txtFive, string txtSix, string txtbonus)
        {
            bool final = true;//if character is not found.
            int num;
            //must be false bcs tryparse returns false if character is found.
            bool valueTxt1 = Int32.TryParse(txtOne, out num);
            bool valueTxt2 = Int32.TryParse(txttwo, out num);
            bool valueTxt3 = Int32.TryParse(txtThree, out num);
            bool valueTxt4 = Int32.TryParse(txtFour, out num);
            bool valueTxt5 = Int32.TryParse(txtFive, out num);
            bool valueTxt6 = Int32.TryParse(txtSix, out num);
            bool valueTxt7 = Int32.TryParse(txtbonus, out num);
            if (valueTxt1 == false || valueTxt2 == false || valueTxt3 == false || valueTxt4 == false || valueTxt5 == false || valueTxt6 == false || valueTxt7 == false)
            {
                final = false;
            }
            return final;
        }

        public bool checkIntegerPowerball(string a, string b, string c, string d, string e)
        {
            bool value = false;
            int aa = Convert.ToInt32(a);
            int bb = Convert.ToInt32(b);
            int cc = Convert.ToInt32(c);
            int dd = Convert.ToInt32(d);
            int ee = Convert.ToInt32(e);
            if ((aa > 0 && aa < 50) && (bb > 0 && bb < 50) && (cc > 0 && cc < 50) && (dd > 0 && dd < 50) && (ee > 0 && ee < 50))
            {
                value = true;
            }
            return value;
        }

        public bool checkTextboxesPowerball(string txtFirst, string txtSecond, string txtThird, string txtFourth, string txtFirth)
        {
            bool blnCheck = false;
            if (string.IsNullOrEmpty(txtFirst) || string.IsNullOrEmpty(txtSecond) || string.IsNullOrEmpty(txtThird) || string.IsNullOrEmpty(txtFourth) || string.IsNullOrEmpty(txtFirth))
            {
                blnCheck = true;
            }
            return blnCheck;
        }

        public bool checkForCharactersPowerball(string txtOne, string txttwo, string txtThree, string txtFour, string txtFive)
        {
            bool final = true;//if character is not found.
            int num;
            //must be false bcs tryparse returns false if character is found.
            bool valueTxt1 = Int32.TryParse(txtOne, out num);
            bool valueTxt2 = Int32.TryParse(txtOne, out num);
            bool valueTxt3 = Int32.TryParse(txtOne, out num);
            bool valueTxt4 = Int32.TryParse(txtOne, out num);
            bool valueTxt5 = Int32.TryParse(txtOne, out num);
            if (valueTxt1 == false || valueTxt2 == false || valueTxt3 == false || valueTxt4 == false || valueTxt5 == false)
            {
                final = false;
            }
            return final;
        }

        public void clearTextbox(ref TextBox one, ref TextBox two, ref TextBox three, ref TextBox four, ref TextBox five)
        {
            one.Text = string.Empty;
            two.Text = string.Empty;
            three.Text = string.Empty;
            four.Text = string.Empty;
            five.Text = string.Empty;
        }

        public void clearTextboxPowerball(ref TextBox one1, ref TextBox two2, ref TextBox three3, ref TextBox four4, ref TextBox five5, ref TextBox six6)
        {
            one1.Text = string.Empty;
            two2.Text = string.Empty;
            three3.Text = string.Empty;
            four4.Text = string.Empty;
            five5.Text = string.Empty;
            six6.Text = string.Empty;
        }

    }
}
