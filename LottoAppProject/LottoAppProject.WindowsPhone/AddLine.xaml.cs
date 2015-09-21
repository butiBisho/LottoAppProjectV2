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
    public sealed partial class AddLine : Page
    {
        DisplayMessage display = new DisplayMessage();
        public AddLine()
        {
            this.InitializeComponent();
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

        private void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void AppBarButton_Click_2(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddLine));
        }

        private void AppBarButton_Click_3(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddLinePowerball));
        }

        private void AppBarButton_Click_4(object sender, RoutedEventArgs e)
        {
            try
            {
                Lotto insert = new Lotto();

                bool txtBox = display.checkTextboxes(txtOne.Text, txtTwo.Text, txtThree.Text, txtFour.Text, txtFive.Text, txtSix.Text);
                bool final = display.checkForCharacters(txtOne.Text, txtTwo.Text, txtThree.Text, txtFour.Text, txtFive.Text, txtSix.Text);
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
                    bool blnValid = display.checkInteger(txtOne.Text, txtTwo.Text, txtThree.Text, txtFour.Text, txtFive.Text, txtSix.Text);
                    if (blnValid == true && final == true)
                    {
                        insert.setUserSavedNumbers(Convert.ToInt32(txtOne.Text), Convert.ToInt32(txtTwo.Text), Convert.ToInt32(txtThree.Text), Convert.ToInt32(txtFour.Text), Convert.ToInt32(txtFive.Text), Convert.ToInt32(txtSix.Text));
                        display.msgBox("Successfully added to the database.");
                    }
                    else if (blnValid == false)
                    {
                        display.msgBox("number must be within the 1-49 range.");
                    }
                }
            }
            catch (Exception ex)
            {
                display.msgBox(ex.Message);
            }
        }


    }
}
