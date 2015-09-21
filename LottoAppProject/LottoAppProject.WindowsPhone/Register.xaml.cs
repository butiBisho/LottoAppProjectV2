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
    public sealed partial class Register : Page
    {
        DisplayMessage message = new DisplayMessage();
        public Register()
        {
            this.InitializeComponent();
            if (this.BottomAppBar != null)
            {
                this.BottomAppBar.IsSticky = true;
                this.BottomAppBar.IsOpen = true;
            }

            txtblockFirstNameError.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            txtBlockSurnameError.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                txtblockFirstNameError.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                txtBlockSurnameError.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                if (textBoxFirstName.Text == "" && textBoxLastName.Text == "")
                {
                    txtblockFirstNameError.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    txtBlockSurnameError.Visibility = Windows.UI.Xaml.Visibility.Visible;
                }
                else if (textBoxLastName.Text == "")
                {
                    txtBlockSurnameError.Visibility = Windows.UI.Xaml.Visibility.Visible;
                }
                else if (textBoxFirstName.Text == "")
                {
                    txtblockFirstNameError.Visibility = Windows.UI.Xaml.Visibility.Visible;
                }
                else
                {
                    //User addDetails = new User()
                    //{
                    //    name = textBoxFirstName.Text,
                    //    Surname = textBoxLastName.Text
                    //};
                    //SQLiteAsyncConnection conn = new SQLiteAsyncConnection("newProject.db");
                    //await conn.InsertAsync(addDetails);
                    Lotto insert = new Lotto();
                    insert.InsertUserDetails(textBoxFirstName.Text, textBoxLastName.Text);
                    message.msgBox("Successfully added into the database.");
                }
            }
            catch (Exception ex)
            {
                message.msgBox(ex.Message);
            }
        }

        private void appbarAddLatestResults_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SaveResults));
        }

        private void appbarAddLatestPowerballResults_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SaveResultsPowerball));
        }

        private void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void AppBarButton_Click_2(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Register));
        }


    }
}
