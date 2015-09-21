using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Register));
        }

        private async void btnResults_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog msgDialog = new MessageDialog("Game Type", "Please select game type");
            UICommand lottoBtn = new UICommand("Lotto");
            lottoBtn.Invoked = lottoBtnClick;
            msgDialog.Commands.Add(lottoBtn);

            UICommand lottoPlusBtn = new UICommand("Lotto Plus");
            lottoPlusBtn.Invoked = lottoPlusBtnClick;
            msgDialog.Commands.Add(lottoPlusBtn);

            UICommand powerballBtn = new UICommand("Powerball");
            powerballBtn.Invoked = powerballBtnClick;
            msgDialog.Commands.Add(powerballBtn);

            //UICommand cancelBtn = new UICommand("Cancel");
            //cancelBtn.Invoked = cancelBtnClick;
            //msgDialog.Commands.Add(cancelBtn);

            await msgDialog.ShowAsync();
        }

        private void lottoBtnClick(IUICommand command)
        {
            //go to lotto page
            this.Frame.Navigate(typeof(Results));
        }

        private void lottoPlusBtnClick(IUICommand command)
        {
            //go to lotto plus page
            this.Frame.Navigate(typeof(LPResults));
        }

        private void powerballBtnClick(IUICommand command)
        {
            //go to powerball page
            this.Frame.Navigate(typeof(PResults));
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ResultNotification));
        }

        private async void btnGenerate_Click(object sender, RoutedEventArgs e)
        {

            MessageDialog msgDialog = new MessageDialog("Game Type", "Please select game type");
            UICommand sixBtn = new UICommand("Lotto Or Lotto Plus");
            sixBtn.Invoked = sixBtnClick;
            msgDialog.Commands.Add(sixBtn);

            UICommand powerBtn = new UICommand("Powerball");
            powerBtn.Invoked = powerBtnClick;
            msgDialog.Commands.Add(powerBtn);

            await msgDialog.ShowAsync();
        }

        private void sixBtnClick(IUICommand command)
        {
            this.Frame.Navigate(typeof(NumberGenerator));
        }

        private void powerBtnClick(IUICommand command)
        {
            this.Frame.Navigate(typeof(NumberGeneratorPowerball));
        }

    }
}
