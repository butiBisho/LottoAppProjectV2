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
    public sealed partial class AddLinePowerball : Page
    {
        DisplayMessage display = new DisplayMessage();

        public AddLinePowerball()
        {
            this.InitializeComponent();
            if (this.BottomAppBar != null)
            {
                this.BottomAppBar.IsSticky = true;
                this.BottomAppBar.IsOpen = true;
            }
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddLinePowerball));
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
            try
            {
                Lotto insert = new Lotto();
                bool txtBox = display.checkTextboxesPowerball(txtP1.Text, txtP2.Text, txtP3.Text, txtP4.Text, txtP5.Text);
                bool final = display.checkForCharactersPowerball(txtP1.Text, txtP2.Text, txtP3.Text, txtP4.Text, txtP5.Text);
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
                    bool blnValid = display.checkIntegerPowerball(txtP1.Text, txtP2.Text, txtP3.Text, txtP4.Text, txtP5.Text);
                    if (blnValid == true && final == true)
                    {
                        insert.savePowerballGeneratedNumbers(Convert.ToInt32(txtP1.Text), Convert.ToInt32(txtP2.Text), Convert.ToInt32(txtP3.Text), Convert.ToInt32(txtP4.Text), Convert.ToInt32(txtP5.Text));
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
