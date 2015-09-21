using LottoAppProject.Model_Class;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;
using System.Linq;

namespace LottoAppProject.Class_with_Functions
{
    public class DisplayResults: ViewModelBase
    {
        #region Properties
        private int id = 0;
        public int Id
        {
            get
            { return id; }

            set
            {
                if (id == value)
                { return; }

                id = value;
                RaisePropertyChanged("Id");
            }
        }
        private int num1 = 0;
        public int Num1
        {
            get
            { return num1; }

            set
            {
                if (num1 == value)
                { return; }

                num1 = value;
                RaisePropertyChanged("num1");
            }
        }
        private int num2 = 0;
        public int Num2
        {
            get
            { return num2; }

            set
            {
                if (num2 == value)
                { return; }

                num2 = value;
                RaisePropertyChanged("num2");
            }
        }
        private int num3 = 0;
        public int Num3
        {
            get
            { return num3; }

            set
            {
                if (num3 == value)
                { return; }

                num3 = value;
                RaisePropertyChanged("num3");
            }
        }
        private int num4 = 0;
        public int Num4
        {
            get
            { return num4; }

            set
            {
                if (num4 == value)
                { return; }

                num4 = value;
                RaisePropertyChanged("num4");
            }
        }
        private int num5 = 0;
        public int Num5
        {
            get
            { return num5; }

            set
            {
                if (num5 == value)
                { return; }

                num5 = value;
                RaisePropertyChanged("num5");
            }
        }
        private int num6 = 0;
        public int Num6
        {
            get
            { return num6; }

            set
            {
                if (num6 == value)
                { return; }

                num6 = value;
                RaisePropertyChanged("num6");
            }
        }

        #endregion "Properties"

        private LottoAppProject.App app = (Application.Current as App);

        public LottoLiveResults lottoWinnings(string date)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var query = db.Query<LottoLiveResults>("select * from LottoLiveResults where date = '" + date + "'").FirstOrDefault();
                return query;
            }
        }

        public LottoPlusResults lottoPlusWinnings(string date)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var query = db.Query<LottoPlusResults>("select * from LottoPlusResults where date = '" + date + "'").FirstOrDefault();
                return query;
            }
        }

        public PowerBallResults powerballWinnings(string date)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var query = db.Query<PowerBallResults>("select * from PowerBallResults where dateP = '" + date + "'").FirstOrDefault();
                return query;
            }
        }

        public LottoSaved displayLottoSaved(int id)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var query = db.Query<LottoSaved>("select * from LottoSaved where id = '" + id + "'").FirstOrDefault();
                return query;
            }
        }

        public LottoSaved buti(int one, int two)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var query = db.Query<LottoSaved>("select Id from LottoSaved where num1 = '" + one + "' and num2 = '" + two + "'").FirstOrDefault();
                return query;
            }
        }

        public PowerBallSaved displayPowerballSaved(int idNum)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var query = db.Query<PowerBallSaved>("select * from PowerBallSaved where id = '" + idNum + "'").FirstOrDefault();
                return query;
            }
        }

        public PowerBallSaved khosi(int first, int second)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var query = db.Query<PowerBallSaved>("select Id from PowerBallSaved where num1 = '" + first + "' and num2 = '" + second + "'").FirstOrDefault();
                return query;
            }
        }

        public void deleteRowOnLottoSaved(int id)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                db.Execute("Delete from LottoSaved where Id = ?", id);
            }
        }

        public void deletePowerballSaved(int gg)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                db.Execute("Delete from PowerBallSaved where Id = ?", gg);
            }
        }

        public LottoLiveResults RetrievingUsingMaxValue(int id)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var query = db.Query<LottoLiveResults>("select * from LottoLiveResults where id = '" + id + "'").FirstOrDefault();
                return query;
            }
        }


        public LottoPlusResults RetrieveMaxValueLP(int id)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var query = db.Query<LottoPlusResults>("select * from LottoPlusResults where id = '" + id + "'").FirstOrDefault();
                return query;
            }
        }

        public PowerBallResults RetrieveMaxValuePowerball(int id)
        {
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var query = db.Query<PowerBallResults>("select * from PowerBallResults where id = '" + id + "'").FirstOrDefault();
                return query;
            }
        }

    }
}
