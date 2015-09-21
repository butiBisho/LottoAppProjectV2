using LottoAppProject.Model_Class;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=234227

namespace LottoAppProject
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public sealed partial class App : Application
    {
        public string dbPath { get; set; }
#if WINDOWS_PHONE_APP
        private TransitionCollection transitions;
#endif
        public static SQLiteAsyncConnection conn = new SQLiteAsyncConnection("LottoAppProject.db");
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += this.OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used when the application is launched to open a specific file, to display
        /// search results, and so forth.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif

            this.dbPath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "LottoAppProject.db");
            using (var dbase = new SQLite.SQLiteConnection(dbPath))
            {


                dbase.CreateTable<User>();

                dbase.CreateTable<LottoLiveResults>();
                dbase.CreateTable<LottoPlusResults>();
                dbase.CreateTable<PowerBallResults>();
                ////SAVED NUMBERS/////////
                dbase.CreateTable<LottoSaved>();
                dbase.CreateTable<PowerBallSaved>();
            }

            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                // TODO: change this value to a cache size that is appropriate for your application
                rootFrame.CacheSize = 1;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    // TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
#if WINDOWS_PHONE_APP
                // Removes the turnstile navigation for startup.
                if (rootFrame.ContentTransitions != null)
                {
                    this.transitions = new TransitionCollection();
                    foreach (var c in rootFrame.ContentTransitions)
                    {
                        this.transitions.Add(c);
                    }
                }

                rootFrame.ContentTransitions = null;
                rootFrame.Navigated += this.RootFrame_FirstNavigated;
#endif

                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                if (!rootFrame.Navigate(typeof(MainPage), e.Arguments))
                {
                    throw new Exception("Failed to create initial page");
                }
            }

            // Ensure the current window is active
            Window.Current.Activate();
        }

#if WINDOWS_PHONE_APP
        /// <summary>
        /// Restores the content transitions after the app has launched.
        /// </summary>
        /// <param name="sender">The object where the handler is attached.</param>
        /// <param name="e">Details about the navigation event.</param>
        private void RootFrame_FirstNavigated(object sender, NavigationEventArgs e)
        {
            var rootFrame = sender as Frame;
            rootFrame.ContentTransitions = this.transitions ?? new TransitionCollection() { new NavigationThemeTransition() };
            rootFrame.Navigated -= this.RootFrame_FirstNavigated;
        }
#endif

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();

            // TODO: Save application state and stop any background activity
            deferral.Complete();
        }

        private async Task<bool> CheckDbAsync(string dbName)
        {
            bool dbExist = true;

            try
            {
                StorageFile sf = await ApplicationData.Current.LocalFolder.GetFileAsync(dbName);
            }
            catch (Exception)
            {
                dbExist = false;
            }
            return dbExist;
        }

        private async Task AddUsersAsync()
        {
            var userList = new List<User>()
            {
                new User()
                {
                    Surname = "Bisho",
                    name = "Samuel"                    
                },             
            };
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection("LottoAppProject.db");
            await conn.InsertAllAsync(userList);
        }

        private async Task LottoLiveResultsAsync()
        {
            var result = new List<LottoLiveResults>()
            {
                new LottoLiveResults()
                {                  
                    date = "2015-08-20",
                    num1 = 10,
                    num2 = 30,
                    num3 = 20,
                    num4 = 40,
                    num5 = 44,
                    num6 = 5,
                    bonus = 3
                },               
            };
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection("LottoAppProject.db");
            await conn.InsertAllAsync(result);
        }

        private async Task LottoPlusResultsAsync()
        {
            var res = new List<LottoPlusResults>()
            {
                new LottoPlusResults()
                {                  
                    date = "2015-08-20",
                    num1 = 0,
                    num2 = 0,
                    num3 = 0,
                    num4 = 0,
                    num5 = 0,
                    num6 = 0,
                    bonus = 0
                },               
            };
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection("LottoAppProject.db");
            await conn.InsertAllAsync(res);
        }

        private async Task PowerBallResultsAsync()
        {
            var winnings = new List<PowerBallResults>()
            {
                new PowerBallResults()
                {                  
                     dateP = "2015-08-20",
                     numA = 10,
                     numB = 20,
                     numC = 30,
                     numD = 40,
                     numE = 44,
                     bonusP = 33
                },               
            };
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection("LottoAppProject.db");
            await conn.InsertAllAsync(winnings);
        }

        private async Task LottoSavedAsync()
        {
            var saved = new List<LottoSaved>()
            {
                new LottoSaved()
                {
                     num1 = 2,
                     num2 = 1,
                     num3 = 34,
                     num4 = 3,
                     num5 = 23,
                     num6 = 9
                },              
            };
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection("LottoAppProject.db");
            await conn.InsertAllAsync(saved);
        }

        private async Task PowerBallSavedAsync()
        {
            var store = new List<PowerBallSaved>()
            {
                new PowerBallSaved()
                {
                    num1 = 2,
                    num2 = 4,
                    num3 = 34,
                    num4 = 1,
                    num5 = 33
                },
            };
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection("LottoSA.db");
            await conn.InsertAllAsync(store);
        }

    }
}