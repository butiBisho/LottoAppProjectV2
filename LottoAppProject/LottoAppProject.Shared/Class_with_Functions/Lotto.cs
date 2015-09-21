using LottoAppProject.Model_Class;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Windows.UI.Xaml;

namespace LottoAppProject.Class_with_Functions
{
    public class Lotto: ViewModelBase
    {
        #region Properties
        private int idNumber = 0;
        public int IdNumber
        {
            get { return idNumber; }
            set 
            {
                if (idNumber == value) { return; }
                idNumber = value;
                RaisePropertyChanged("IdNumber");
            }
        }

        #endregion "Properties"

        private LottoAppProject.App app = (Application.Current as App);

        public User getData(int value)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var query = db.Query<User>("select * from User where Id = " + value).FirstOrDefault();
                return query;
            }
        }

        public void setUserSavedNumbers(int a, int b, int c, int d, int e, int f)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var query = db.Insert(new LottoSaved()
                {
                    Id = 0,
                    num1 = a,
                    num2 = b,
                    num3 = c,
                    num4 = d,
                    num5 = e,
                    num6 = f
                });
            }
        }

        public void savePowerballGeneratedNumbers(int first, int second, int third, int fourth, int fifth)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var query = db.Insert(new PowerBallSaved()
                {
                    Id = 0,
                    num1 = first,
                    num2 = second,
                    num3 = third,
                    num4 = fourth,
                    num5 = fifth
                });
            }
        }

        public void setStoreLottoLiveResults(int one, int two, int three, int four, int five, int six, int bonus, string date)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var query = db.Insert(new LottoLiveResults()
                {
                    Id = 0,
                    date = date,
                    num1 = one,
                    num2 = two,
                    num3 = three,
                    num4 = four,
                    num5 = five,
                    num6 = six,
                    bonus = bonus
                });
            }
        }
        public void setStoreLottoPlusResults(int o, int t, int th, int f, int fi, int s, int b, string da)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var query = db.Insert(new LottoPlusResults()
                {
                    Id = 0,
                    date = da,
                    num1 = o,
                    num2 = t,
                    num3 = th,
                    num4 = f,
                    num5 = fi,
                    num6 = s,
                    bonus = b
                });
            }
        }
        public void setStorePowerBallResults(int on, int tw, int thr, int fo, int fiv, int bon, string dat)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var query = db.Insert(new PowerBallResults()
                {
                    Id = 0,
                    dateP = dat,
                    numA = on,
                    numB = tw,
                    numC = thr,
                    numD = fo,
                    numE = fiv,
                    bonusP = bon
                });
            }
        }

        public void InsertUserDetails(string name, string surname)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var query = db.Insert(new User()
                {
                    Id = 0,
                    name = name,
                    Surname = surname
                });
            }
        }

        public void DeleteSavedNumbers()
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                //var query = db.Delete<LottoSaved>(@"Delete from LottoSaved where Id=?")

            }
        }

    }
}
