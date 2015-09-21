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
    public sealed partial class NumberGeneratorPowerball : Page
    {
        List<int> numbers = new List<int>();
        DisplayMessage msg = new DisplayMessage();

        public NumberGeneratorPowerball()
        {
            this.InitializeComponent();
            if (this.BottomAppBar != null)
            {
                this.BottomAppBar.IsSticky = true;
                this.BottomAppBar.IsOpen = true;
            }
        }

        public Shared Shared = new Shared();

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            //lstShow.Items.Clear();
            int Min = 1;
            int Max = 49;
            int number = 0;
            string line = "";
            //bool valid = true

            Random ran = new Random();
            numbers.Clear();
            for (int i = 0; i < 5; i++)
            {
                do
                {
                    number = ran.Next(Min, Max);
                    //buti[i] = number;
                }
                while (numbers.Contains(number));

                numbers.Add(number);
                //buti[i] = number;

                if (number == Min)
                    Min++;
                if (number == Max - 1)
                    Max--;
            }
            //display on listbox and clear list
            for (int i = 0; i < 5; i++)
                line = line + numbers[i] + " ";

            //lstShow.Items.Add(line);
            //display new style
            Shared.DrawTesting(ref Display, ref numbers);
            msg.msgBox("Below on the app bar, you may opt to save the generated numbers");
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void appbarRefresh_Click_2(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(NumberGeneratorPowerball));
        }

        private void appbarAddLineLotto_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddLine));
        }

        private void appbarAddLinePowerball_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddLinePowerball));
        }

        private void appbarGenerateLottoAndLottoPlus_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(NumberGenerator));
        }

        private void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void appbarSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Lotto lottery = new Lotto();
                int aa, bb, cc, dd, ee;
                aa = numbers[0];
                bb = numbers[1];
                cc = numbers[2];
                dd = numbers[3];
                ee = numbers[4];
                lottery.savePowerballGeneratedNumbers(aa, bb, cc, dd, ee);
                msg.msgBox("Successfully Saved. You will can view your numbers on the results page and compare with the latest Lotto and Lotto Plus results");
            }
            catch (Exception ex)
            {
                msg.msgBox("Error Message: " + ex.Message);
            }
        }

    }
}
