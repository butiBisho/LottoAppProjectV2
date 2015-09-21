using LottoAppProject.Class_with_Functions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class PResults : Page
    {
        DisplayMessage msg = new DisplayMessage();
        DisplayResults winnings = new DisplayResults();
        CheckGameType GT = new CheckGameType();
        //display numbers in circles
        List<int> numbers = new List<int>();
        public Shared Shared = new Shared();
        //display saved numbers
        buti buti = null;
        ObservableCollection<DisplayResults> DisplayResults = null;
        ObservableCollection<Lotto> Maximum = null;
        List<int> arrayID = new List<int>();

        List<int> arrayDelete = new List<int>();

        public PResults()
        {
            this.InitializeComponent();
            cmbGameType.SelectedIndex = 2;
            if (this.BottomAppBar != null)
            {
                this.BottomAppBar.IsSticky = true;
                this.BottomAppBar.IsOpen = true;
            }

            numbers.Clear();
            int id = MaxValue();
            var data = winnings.RetrieveMaxValuePowerball(id);
            if (data != null)
            {
                numbers.Add(data.numA);
                numbers.Add(data.numB);
                numbers.Add(data.numC);
                numbers.Add(data.numD);
                numbers.Add(data.numE);
                numbers.Add(data.bonusP);                
                Shared.DrawBonus(ref bonus, ref numbers);
                Shared.DrawTesting(ref testing, ref numbers);
            }

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string line = dpDate.Date.ToString().Substring(0, 11).Trim();//get date from datepicker
                string combo = ((ComboBoxItem)cmbGameType.SelectedItem).Content.ToString();
                int selectedGameType = GT.gameType(combo);
                numbers.Clear();
                //LstResults.Items.Clear();

                if (selectedGameType == 1)
                {
                    var data = winnings.lottoWinnings(line);
                    if (data != null)
                    {
                        string details = data.num1.ToString() + " " + data.num2.ToString() + " " + data.num3.ToString() + " " + data.num4.ToString() + " " + data.num5.ToString() + " " + data.num6.ToString() + " BONUS " + data.bonus.ToString();
                        //store in a List
                        numbers.Add(data.num1);
                        numbers.Add(data.num2);
                        numbers.Add(data.num3);
                        numbers.Add(data.num4);
                        numbers.Add(data.num5);
                        numbers.Add(data.num6);
                        numbers.Add(data.bonus);
                        Shared.DrawBonus(ref bonus, ref numbers);
                        Shared.DrawTesting(ref testing, ref numbers);
                        //LstResults.Items.Add(details);
                    }
                    else
                    {
                        msg.msgBox("NO DATA FOUND");
                    }
                }
                else if (selectedGameType == 2)
                {
                    var data = winnings.lottoPlusWinnings(line);
                    if (data != null)
                    {
                        string details = data.num1.ToString() + " " + data.num2.ToString() + " " + data.num3.ToString() + " " + data.num4.ToString() + " " + data.num5.ToString() + " " + data.num6.ToString() + " BONUS " + data.bonus.ToString();
                        numbers.Add(data.num1);
                        numbers.Add(data.num2);
                        numbers.Add(data.num3);
                        numbers.Add(data.num4);
                        numbers.Add(data.num5);
                        numbers.Add(data.num6);
                        numbers.Add(data.bonus);
                        Shared.DrawBonus(ref bonus, ref numbers);
                        Shared.DrawTesting(ref testing, ref numbers);
                        //LstResults.Items.Add(details);
                    }
                    else
                    {
                        msg.msgBox("NO DATA FOUND");

                    }
                }
                else if (selectedGameType == 3)
                {
                    var data = winnings.powerballWinnings(line);
                    if (data != null)
                    {
                        string details = data.numA.ToString() + " " + data.numB.ToString() + " " + data.numC.ToString() + " " + data.numD.ToString() + " " + data.numE.ToString() + " BONUS " + data.bonusP.ToString();
                        numbers.Add(data.numA);
                        numbers.Add(data.numB);
                        numbers.Add(data.numC);
                        numbers.Add(data.numD);
                        numbers.Add(data.numE);
                        numbers.Add(data.bonusP);
                        Shared.DrawBonus(ref bonus, ref numbers);
                        Shared.DrawTesting(ref testing, ref numbers);
                        //LstResults.Items.Add(details);
                    }
                    else
                    {
                        msg.msgBox("NO DATA FOUND");
                    }
                }
            }
            catch (Exception ex)
            {
                msg.msgBox(ex.ToString());
            }
        }

        private void btnSaved_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                arrayDelete.Clear();
                int count = 1;
                lstDisplaySaved.Items.Clear();
                string combo = ((ComboBoxItem)cmbGameType.SelectedItem).Content.ToString();
                int selectedGameType = GT.gameType(combo);
                if (selectedGameType == 1 || selectedGameType == 2)
                {
                    buti = new buti();
                    DisplayResults = buti.getRows();
                    if (DisplayResults != null)
                    {
                        foreach (var r in DisplayResults)
                        {
                            lstDisplaySaved.Items.Add("Row number " + count.ToString() + " : " + r.Num1 + " " + r.Num2 + " " + r.Num3 + " " + r.Num4 + " " + r.Num5 + " " + r.Num6);
                            arrayDelete.Add(r.Id);
                            count++;
                        }
                    }
                    else
                    {
                        lstDisplaySaved.Items.Add("NO DATA FOUND");
                    }
                }
                else
                {
                    buti = new buti();
                    DisplayResults = buti.getPowerballRows();
                    if (DisplayResults != null)
                    {
                        foreach (var r in DisplayResults)
                        {
                            lstDisplaySaved.Items.Add("Row number " + count.ToString() + " : " + r.Num1 + " " + r.Num2 + " " + r.Num3 + " " + r.Num4 + " " + r.Num5);
                            arrayDelete.Add(r.Id);
                            count++;
                        }
                    }
                    else
                    {
                        lstDisplaySaved.Items.Add("NO DATA FOUND");
                    }
                }
            }
            catch (Exception ex)
            {
                msg.msgBox(ex.ToString());
            }
        }

        public void check(ref List<int> j)
        {
            try
            {
                int last = j.Count - 1;
                msg.msgBox(j[last].ToString());
            }
            catch (Exception ex)
            {
                msg.msgBox(ex.ToString());
            }
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void AppBarButton_Click_2(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PResults));
        }

        private LottoAppProject.App app = (Application.Current as App);

        private void AppBarButton_Click_3(object sender, RoutedEventArgs e)
        {
            //if i have the id i can delete row from the table. so therefore i need a function that will delete passing this id
            //msg.msgBox(arrayDelete[lstDisplaySaved.SelectedIndex].ToString());
            try
            {
                string combo = ((ComboBoxItem)cmbGameType.SelectedItem).Content.ToString();
                int selectedGameType = GT.gameType(combo);
                if (selectedGameType == 1 || selectedGameType == 2)
                {
                    deleteRowOnLottoSaved(arrayDelete[lstDisplaySaved.SelectedIndex]);
                    msg.msgBox("the line selected is successfully deleted.");
                }
                else
                {
                    deleteRowOnPowerballSaved(arrayDelete[lstDisplaySaved.SelectedIndex]);
                    msg.msgBox("the line selected is successfully deleted.");
                }
            }
            catch (Exception ex)
            {
                msg.msgBox(ex.Message);
            }
        }

        public int MaxValue()
        {
            buti = new buti();
            Maximum = buti.getKeyValues();
            if (Maximum != null)
            {
                foreach (var r in Maximum)
                {
                    //lstTest.Items.Add(r.IdNumber);
                    arrayID.Add(r.IdNumber);
                }
            }
            int count = arrayID.Count;
            return arrayID[count - 1];
        }

        public void deleteRowOnLottoSaved(int id)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                db.Execute("Delete from LottoSaved where Id = ?", id);
            }
        }

        public void deleteRowOnPowerballSaved(int id)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                db.Execute("Delete from PowerBallSaved where Id = ?", id);
            }
        }


    }
}
