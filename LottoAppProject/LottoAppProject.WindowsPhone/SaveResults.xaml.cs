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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace LottoAppProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SaveResults : Page
    {
        DisplayMessage message = new DisplayMessage();
        GetResults winnings = new GetResults();
        Lotto storeValues = new Lotto();

        public SaveResults()
        {
            this.InitializeComponent();
            cmbType.SelectedIndex = 0;
            if (this.BottomAppBar != null)
            {
                this.BottomAppBar.IsSticky = true;
                this.BottomAppBar.IsOpen = true;
            }
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void appbarSaveResults_Click(object sender, RoutedEventArgs e)
        {
            DisplayMessage display = new DisplayMessage();
            try
            {
                Lotto insert = new Lotto();
                int storeValue = 0;
                bool txtBox = display.checkNullTextboxes(txtOne.Text, txtTwo.Text, txtThree.Text, txtFour.Text, txtFive.Text, txtSix.Text, txtBonus.Text);
                bool final = display.checkForChar(txtOne.Text, txtTwo.Text, txtThree.Text, txtFour.Text, txtFive.Text, txtSix.Text, txtBonus.Text);
                if (txtBox == true)
                {
                    display.msgBox("textbox must not be left empty!!");
                }
                else if (final == false)
                {
                    display.msgBox("You must enter number/s and not character/s.");
                }
                else
                {
                    bool blnValid = display.checkIntegerLottoResults(txtOne.Text, txtTwo.Text, txtThree.Text, txtFour.Text, txtFive.Text, txtSix.Text, txtBonus.Text);
                    if (blnValid == true && final == true)
                    {
                        storeValue = 1;
                    }
                    else if (blnValid == false)
                    {
                        display.msgBox("number must be within the 1-49 range.");
                    }
                }

                if (storeValue == 1)
                {
                    int check = 0;
                    string line = dpDate.Date.ToString().Substring(0, 11).Trim();//date from datepicker
                    string but = ((ComboBoxItem)cmbType.SelectedItem).Content.ToString();
                    if (but == "Lotto")
                    {
                        winnings.store(but, txtOne.Text, txtTwo.Text, txtThree.Text, txtFour.Text, txtFive.Text, txtSix.Text, txtBonus.Text);
                        check = 1;
                    }
                    else if (but == "LottoPlus")
                    {
                        winnings.storeLottoPlus(but, txtOne.Text, txtTwo.Text, txtThree.Text, txtFour.Text, txtFive.Text, txtSix.Text, txtBonus.Text);
                        check = 2;
                    }
                    /////////////FROM HERE STORE NUMBERS INTO THE DATABASE///////////
                    if (check == 1)
                    {
                        storeValues.setStoreLottoLiveResults(winnings.getNumbers(0), winnings.getNumbers(1), winnings.getNumbers(2), winnings.getNumbers(3), winnings.getNumbers(4), winnings.getNumbers(5), winnings.getNumbers(6), line);
                        display.msgBox("all is good. refresh the page");
                    }
                    else if (check == 2)
                    {
                        storeValues.setStoreLottoPlusResults(winnings.getLottoPlus(0), winnings.getLottoPlus(1), winnings.getLottoPlus(2), winnings.getLottoPlus(3), winnings.getLottoPlus(4), winnings.getLottoPlus(5), winnings.getLottoPlus(6), line);
                        display.msgBox("all is good. refresh the page");
                    }
                    ////////////FROM HERE STORE NUMBERS INTO THE DATABASE////////////
                }
            }
            catch (Exception ex)
            {
                display.msgBox(ex.Message);
            }
        }

        private void appbarAddLatestPowerballResults_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SaveResultsPowerball));
        }

        private void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void AppBarButton_Click_3(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SaveResults));
        }

    }
}
