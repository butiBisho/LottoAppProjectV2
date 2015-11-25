using LottoAppProject.Class_with_Functions;
using System;
using System.Collections.Generic;
using System.Text;

namespace LottoAppProject.New
{
    public class Variables : ViewModelBase
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

        private int first = 0;
        public int First
        {
            get
            { return first; }

            set
            {
                if (first == value)
                { return; }

                first = value;
                RaisePropertyChanged("num1");
            }
        }

        private int second = 0;
        public int Second
        {
            get
            { return second; }

            set
            {
                if (second == value)
                { return; }

                second = value;
                RaisePropertyChanged("num2");
            }
        }

        private int third = 0;
        public int Third
        {
            get
            { return third; }

            set
            {
                if (third == value)
                { return; }

                third = value;
                RaisePropertyChanged("num3");
            }
        }

        private int fourth = 0;
        public int Fourth
        {
            get
            { return fourth; }

            set
            {
                if (fourth == value)
                { return; }

                fourth = value;
                RaisePropertyChanged("num4");
            }
        }

        private int five = 0;
        public int Five
        {
            get
            { return five; }

            set
            {
                if (five == value)
                { return; }

                five = value;
                RaisePropertyChanged("num5");
            }
        }

        private int six = 0;
        public int Six
        {
            get
            { return six; }

            set
            {
                if (six == value)
                { return; }

                six = value;
                RaisePropertyChanged("num6");
            }
        }

        #endregion "Properties"
    }
}
