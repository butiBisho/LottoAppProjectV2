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
    public sealed partial class ResultNotification : Page
    {
        public ResultNotification()
        {
            this.InitializeComponent();
            this.tbtnLotto.IsChecked = null;
            this.tbtnPowerball.IsChecked = null;
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
                
        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void AppBarButton_Click_2(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ResultNotification));
        }

        private void NotifyStatus()
        {
            switch (this.tbtnLotto.IsChecked)
            {
                case null:
                    this.txtbTest.Text = "null";
                    break;
                case true:
                    this.txtbTest.Text = "On";

                    break;
                case false:
                    this.txtbTest.Text = "Off";
                    break;
            }
        }

        private void tbtnLotto_Changed(object sender, RoutedEventArgs e)
        {
            this.NotifyStatus();
            DisplayMessage msg = new DisplayMessage();
            if (txtbTest.Text != "null")
            {
                string toastTemplate = txtbTest.Text;
                string alarmName = "";

                if (toastTemplate.Contains("On"))
                {
                    alarmName = "Alarm is set on";
                }
                else if (toastTemplate.Contains("Off"))
                {
                    alarmName = "Alarm is set off";
                }

                string toastXmlString =
                    "<toast duration=\"long\">\n" +
                        "<visual>\n" +
                            "<binding template=\"ToastText02\">\n" +
                                "<text id=\"1\">Lotto and LottoPlus Notifications</text>\n" +
                                "<text id=\"2\">" + alarmName + "</text>\n" +
                            "</binding>\n" +
                        "</visual>\n" +
                        "<commands scenario=\"alarm\">\n" +
                            "<command id=\"snooze\"/>\n" +
                            "<command id=\"dismiss\"/>\n" +
                        "</commands>\n" +
                        "<audio src=\"ms-winsoundevent:Notification.Looping.Alarm2\" loop=\"true\" />\n" +
                    "</toast>\n";
                var toastDOM = new Windows.Data.Xml.Dom.XmlDocument();
                toastDOM.LoadXml(toastXmlString);

                var toastNotifier = Windows.UI.Notifications.ToastNotificationManager.CreateToastNotifier();

                if (toastTemplate.Contains("On"))
                {
                    int customSnoozeSeconds = 5 * 60;
                    TimeSpan snoozeInterval = TimeSpan.FromSeconds(customSnoozeSeconds);
                    var customAlarmScheduledToast = new Windows.UI.Notifications.ScheduledToastNotification(toastDOM, DateTime.Now.AddSeconds(5), snoozeInterval, 0);
                    toastNotifier.AddToSchedule(customAlarmScheduledToast);
                }
                else
                {
                    var customAlarmScheduledToast = new Windows.UI.Notifications.ScheduledToastNotification(toastDOM, DateTime.Now.AddSeconds(5));
                    toastNotifier.AddToSchedule(customAlarmScheduledToast);
                }
            }

        }

        private void tbtnPowerball_Changed(object sender, RoutedEventArgs e)
        {
            this.powerballNotifySatus();

            if (txtbPower.Text != "null")
            {
                string toastTemplate = txtbPower.Text;
                string alarmName = "";

                if (toastTemplate.Contains("On"))
                {
                    alarmName = "Alarm is set on";
                }
                else if (toastTemplate.Contains("Off"))
                {
                    alarmName = "Alarm is set off";
                }

                string toastXmlString =
                    "<toast duration=\"long\">\n" +
                        "<visual>\n" +
                            "<binding template=\"ToastText02\">\n" +
                                "<text id=\"1\">Powerball Notifications</text>\n" +
                                "<text id=\"2\">" + alarmName + "</text>\n" +
                            "</binding>\n" +
                        "</visual>\n" +
                        "<commands scenario=\"alarm\">\n" +
                            "<command id=\"snooze\"/>\n" +
                            "<command id=\"dismiss\"/>\n" +
                        "</commands>\n" +
                        "<audio src=\"ms-winsoundevent:Notification.Looping.Alarm2\" loop=\"true\" />\n" +
                    "</toast>\n";
                var toastDOM = new Windows.Data.Xml.Dom.XmlDocument();
                toastDOM.LoadXml(toastXmlString);

                var toastNotifier = Windows.UI.Notifications.ToastNotificationManager.CreateToastNotifier();

                if (toastTemplate.Contains("On"))
                {
                    int customSnoozeSeconds = 5 * 60;
                    TimeSpan snoozeInterval = TimeSpan.FromSeconds(customSnoozeSeconds);
                    var customAlarmScheduledToast = new Windows.UI.Notifications.ScheduledToastNotification(toastDOM, DateTime.Now.AddSeconds(5), snoozeInterval, 0);
                    toastNotifier.AddToSchedule(customAlarmScheduledToast);
                }
                else
                {
                    var customAlarmScheduledToast = new Windows.UI.Notifications.ScheduledToastNotification(toastDOM, DateTime.Now.AddSeconds(5));
                    toastNotifier.AddToSchedule(customAlarmScheduledToast);
                }
            }

        }

        private void powerballNotifySatus()
        {
            switch (this.tbtnPowerball.IsChecked)
            {
                case null:
                    this.txtbPower.Text = "null";
                    break;
                case true:
                    this.txtbPower.Text = "On";

                    break;
                case false:
                    this.txtbPower.Text = "Off";
                    break;
            }
        }

    }
}
