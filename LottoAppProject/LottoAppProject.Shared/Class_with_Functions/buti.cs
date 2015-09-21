using LottoAppProject.Model_Class;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Windows.UI.Xaml;

namespace LottoAppProject.Class_with_Functions
{
    public class buti: ViewModelBase
    {
        private ObservableCollection<DisplayResults> results;

        public ObservableCollection<DisplayResults> Results
        {
            get { return results; }
            set { results = value; RaisePropertyChanged("Results"); }
        }

        private LottoAppProject.App app = (Application.Current as App);

        public ObservableCollection<DisplayResults> getRows()
        {
            results = new ObservableCollection<DisplayResults>();
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var query = db.Query<LottoSaved>("select * from LottoSaved");
                foreach (var _results in query)
                {
                    var res = new DisplayResults()
                    {
                        Id = _results.Id,
                        Num1 = _results.num1,
                        Num2 = _results.num2,
                        Num3 = _results.num3,
                        Num4 = _results.num4,
                        Num5 = _results.num5,
                        Num6 = _results.num6
                    };
                    results.Add(res);
                }
            }
            return results;
        }

        private ObservableCollection<DisplayResults> powerballResults;

        public ObservableCollection<DisplayResults> PowerballResults
        {
            get { return powerballResults; }
            set { powerballResults = value; RaisePropertyChanged("PowerballResults"); }
        }

        public ObservableCollection<DisplayResults> getPowerballRows()
        {
            powerballResults = new ObservableCollection<DisplayResults>();
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var query = db.Query<PowerBallSaved>("select * from PowerBallSaved");
                foreach (var _res in query)
                {
                    var res = new DisplayResults()
                    {
                        Id = _res.Id,
                        Num1 = _res.num1,
                        Num2 = _res.num2,
                        Num3 = _res.num3,
                        Num4 = _res.num4,
                        Num5 = _res.num5
                    };
                    powerballResults.Add(res);
                }
            }
            return powerballResults;
        }

        private ObservableCollection<Lotto> maximum;

        public ObservableCollection<Lotto> Maximum
        {
            get { return maximum; }
            set { maximum = value; RaisePropertyChanged("Maximum"); }
        }

        public ObservableCollection<Lotto> getIdValues()
        {
            maximum = new ObservableCollection<Lotto>();
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var query = db.Query<LottoLiveResults>("select id from LottoLiveResults");
                foreach (var collect in query)
                {
                    var _collect = new Lotto()
                    {
                        IdNumber = collect.Id
                    };
                    maximum.Add(_collect);
                }
            }
            return maximum;
        }

        private ObservableCollection<Lotto> highest;
        public ObservableCollection<Lotto> Highest
        {
            get { return highest; }
            set { highest = value; RaisePropertyChanged("Highest"); }
        }
        public ObservableCollection<Lotto> getKeyValues()
        {
            highest = new ObservableCollection<Lotto>();
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var query = db.Query<PowerBallResults>("select id from PowerBallResults");
                foreach (var _call in query)
                {
                    var call = new Lotto()
                    {
                        IdNumber = _call.Id
                    };
                    highest.Add(call);
                }
            }
            return highest;
        }

    }
}
