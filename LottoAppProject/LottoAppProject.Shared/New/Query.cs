using LottoAppProject.Class_with_Functions;
using LottoAppProject.Model_Class;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Windows.UI.Xaml;

namespace LottoAppProject.New
{
    public class Query : ViewModelBase
    {
        private ObservableCollection<Variables> latest;

        public ObservableCollection<Variables> Latest
        {
            get { return latest; }
            set { latest = value; RaisePropertyChanged("Latest"); }
        }

        private LottoAppProject.App app = (Application.Current as App);

        public ObservableCollection<Variables> getRows()
        {
            latest = new ObservableCollection<Variables>();
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var query = db.Query<LottoSaved>("select * from LottoSaved");
                foreach (var _results in query)
                {
                    var res = new Variables()
                    {
                        Id = _results.Id,
                        First = _results.num1,
                        Second = _results.num2,
                        Third = _results.num3,
                        Fourth = _results.num4,
                        Five = _results.num5,
                        Six = _results.num6
                    };
                    latest.Add(res);
                }
            }
            return latest;
        }

    }
}
