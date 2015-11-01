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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

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

        private void btnRegistration_Click(object sender, RoutedEventArgs e)
        {
            if (txtRegistrationEmail.Text.Length == 0 && txtRegistrationPassword.Text.Length == 0)
            {
                display.msgBox("TextBox fields cannot be left empty!");              
            }
            else if(txtRegistrationEmail.Text.Length == 0)
            {
                display.msgBox("Enter an Email");
            }
            else if (!Regex.IsMatch(txtRegistrationEmail.Text,@"^[a-zA-Z][\w\.-]*[a-zAZ0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                display.msgBox("Enter a valid email.");
                txtRegistrationEmail.Select(0,txtRegistrationEmail.Text.Length);
                txtRegistrationEmail.Text = "";

            }
            else
            {
                if(txtRegistrationPassword.Text.Length == 0)
                {
                    display.msgBox("Enter password");                    
                }
                else if(txtConfirmPassword.Text.Length == 0)
                {
                    display.msgBox("Enter Confirm password");                    
                }
                else if(txtRegistrationPassword.Text != txtConfirmPassword.Text)
                {
                    display.msgBox("Confirm password must be same as password.");
                    txtRegistrationPassword.Text ="";
                }
                else
                {
                    insert.InsertAdminDetails(txtName.Text.Trim(),txtSurname.Text.Trim(),txtRegistrationEmail.Text.Trim(), txtRegistrationPassword.Text.Trim());
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
            txtName.Text = "";
            txtSurname.Text = "";
            txtRegistrationEmail.Text = "";
            txtRegistrationPassword.Text = "";
            txtConfirmPassword.Text = "";
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            if (txtLogInEmail.Text.Length == 0 && txtLogInPassword.Text.Length == 0)
            {
                display.msgBox("TextBox fields cannot be left empty!");                
            }
            else if(txtLogInEmail.Text.Length == 0)
            {
                display.msgBox("Enter an email");
            }
            else if(txtLogInPassword.Text.Length == 0)
            {
                display.msgBox("Enter password");
            }
            else if(!Regex.IsMatch(txtLogInEmail.Text,@"^[a-zA-Z][\w\.-]*[a-zAZ0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                display.msgBox("Enter a valid email.");
                txtLogInEmail.Select(0, txtLogInEmail.Text.Length);
            }
            else
            {
                var data = search.LogIn(txtLogInEmail.Text,txtLogInPassword.Text);
                if(data != null)
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

    }
}
