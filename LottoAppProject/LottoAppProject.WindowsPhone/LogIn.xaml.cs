using LottoAppProject.Class_with_Functions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
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
    public sealed partial class LogIn : Page
    {
        Lotto insert = new Lotto();
        DisplayMessage display = new DisplayMessage();
        DisplayResults search = new DisplayResults();
        public LogIn()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            if (txtLogInEmail_Copy.Text.Length == 0 && txtLogInPassword_Copy.Text.Length == 0)
            {
                display.msgBox("TextBox fields cannot be left empty!");
            }
            else if (txtLogInEmail_Copy.Text.Length == 0)
            {
                display.msgBox("Enter an email");
            }
            else if (txtLogInPassword_Copy.Text.Length == 0)
            {
                display.msgBox("Enter password");
            }
            else if (!Regex.IsMatch(txtLogInEmail_Copy.Text, @"^[a-zA-Z][\w\.-]*[a-zAZ0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                display.msgBox("Enter a valid email.");
                txtLogInEmail_Copy.Select(0, txtLogInEmail_Copy.Text.Length);
            }
            else
            {
                var data = search.LogIn(txtLogInEmail_Copy.Text, txtLogInPassword_Copy.Text);
                if (data != null)
                {
                    string name = data.firstName;
                    display.msgBox("Successful Log In");
                    this.Frame.Navigate(typeof(SaveResults));
                }
                else
                {
                    display.msgBox("Sorry! Please enter existing email address/password.");
                }
            }
        }

        private void btnRegistration_Click(object sender, RoutedEventArgs e)
        {
            if (txtRegistrationEmail_Copy.Text.Length == 0 && txtRegistrationPassword_Copy.Text.Length == 0)
            {
                display.msgBox("TextBox fields cannot be left empty!");
            }
            else if (txtRegistrationEmail_Copy.Text.Length == 0)
            {
                display.msgBox("Enter an Email");
            }
            else if (!Regex.IsMatch(txtRegistrationEmail_Copy.Text, @"^[a-zA-Z][\w\.-]*[a-zAZ0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                display.msgBox("Enter a valid email.");
                txtRegistrationEmail_Copy.Select(0, txtRegistrationEmail_Copy.Text.Length);
                txtRegistrationEmail_Copy.Text = "";

            }
            else
            {
                if (txtRegistrationPassword_Copy.Text.Length == 0)
                {
                    display.msgBox("Enter password");
                }
                else if (txtConfirmPassword_Copy.Text.Length == 0)
                {
                    display.msgBox("Enter Confirm password");
                }
                else if (txtRegistrationPassword_Copy.Text != txtConfirmPassword_Copy.Text)
                {
                    display.msgBox("Confirm password must be same as password.");
                    txtRegistrationPassword_Copy.Text = "";
                }
                else
                {
                    insert.InsertAdminDetails(txtName_Copy.Text.Trim(), txtSurname_Copy.Text.Trim(), txtRegistrationEmail_Copy.Text.Trim(), txtRegistrationPassword_Copy.Text.Trim());
                    display.msgBox("You have Registered successfully");
                    Reset();
                }
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        public void Reset()
        {
            txtName_Copy.Text = "";
            txtSurname_Copy.Text = "";
            txtRegistrationEmail_Copy.Text = "";
            txtRegistrationPassword_Copy.Text = "";
            txtConfirmPassword_Copy.Text = "";
        }
    }
}
