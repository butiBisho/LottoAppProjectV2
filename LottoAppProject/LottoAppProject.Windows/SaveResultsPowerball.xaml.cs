using LottoAppProject.Class_with_Functions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace LottoAppProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SaveResultsPowerball : Page
    {
        DisplayMessage message = new DisplayMessage();
        GetResults winnings = new GetResults();
        Lotto storeValues = new Lotto();

        public SaveResultsPowerball()
        {
            this.InitializeComponent();
            cmbType.SelectedIndex = 0;
            if (this.BottomAppBar != null)
            {
                this.BottomAppBar.IsSticky = true;
                this.BottomAppBar.IsOpen = true;
            }
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SaveResultsPowerball));
        }

        private void appbarAddLatestResults_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SaveResults));
        }

        private void appbarSaveResults_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Lotto insert = new Lotto();
                int storeValue = 0;
                bool txtBox = message.checkTextboxes(txtOne.Text, txtTwo.Text, txtThree.Text, txtFour.Text, txtFive.Text, txtBonus.Text);
                bool final = message.checkForCharacters(txtOne.Text, txtTwo.Text, txtThree.Text, txtFour.Text, txtFive.Text, txtBonus.Text);
                if (txtBox == true)
                {
                    message.msgBox("textbox must not be left empty!!");
                }
                else if (final == false)
                {
                    message.msgBox("You must enter number/s and not character/s.");
                }
                else
                {
                    bool blnValid = message.checkInteger(txtOne.Text, txtTwo.Text, txtThree.Text, txtFour.Text, txtFive.Text, txtBonus.Text);
                    if (blnValid == true && final == true)
                    {
                        storeValue = 1;
                    }
                    else if (blnValid == false)
                    {
                        message.msgBox("number must be within the 1-49 range.");
                    }
                }

                if (storeValue == 1)
                {
                    string line = dpDate.Date.ToString().Substring(0, 11);//date from datepicker
                    winnings.storePowerBall(txtOne.Text, txtTwo.Text, txtThree.Text, txtFour.Text, txtFive.Text, txtBonus.Text);
                    /////////////FROM HERE STORE NUMBERS INTO THE DATABASE///////////
                    storeValues.setStorePowerBallResults(winnings.getPowerBallNumbers(0), winnings.getPowerBallNumbers(1), winnings.getPowerBallNumbers(2), winnings.getPowerBallNumbers(3), winnings.getPowerBallNumbers(4), winnings.getPowerBallNumbers(5), line);
                    message.msgBox("all is good. refresh the page");
                    ////////////FROM HERE STORE NUMBERS INTO THE DATABASE////////////
                }
            }
            catch (Exception ex)
            {
                message.msgBox(ex.Message);
            }
        }

        private LottoAppProject.App app = (Application.Current as App);

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            test(1);
        }

        private void test(int id)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                db.Execute("Delete from PowerBallResults where Id = ?", id);
            }
        }



    }
}
