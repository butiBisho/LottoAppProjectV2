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
    public sealed partial class ResultNotification : Page
    {
        public ResultNotification()
        {
            this.InitializeComponent();
            if (this.BottomAppBar != null)
            {
                this.BottomAppBar.IsSticky = true;
                this.BottomAppBar.IsOpen = true;
            }
        }

        private void btnSetLottoOn_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            if (b != null)
            {
                string toastTemplate = b.Name;
                string alarmName = "";

                if (toastTemplate.Contains("On"))
                {
                    alarmName = "Alarm is set on";
                }
                else
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
            this.Frame.Navigate(typeof(ResultNotification));
        }

        private void btnSetLottoPlusOff_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            if (b != null)
            {
                string toastTemplate = b.Name;
                string alarmName = "";

                if (toastTemplate.Contains("On"))
                {
                    alarmName = "Alarm is set on";
                }
                else
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

        private void btnSetLottoPlusOn_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            if (b != null)
            {
                string toastTemplate = b.Name;
                string alarmName = "";

                if (toastTemplate.Contains("On"))
                {
                    alarmName = "Alarm is set on";
                }
                else
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

    }
}
