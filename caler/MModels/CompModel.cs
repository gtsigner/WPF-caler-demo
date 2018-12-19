using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace caler.MModels
{
    class NotificationObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    class CompModel : NotificationObject
    {
        public Decimal pfm = 0;

        public static readonly Decimal P2M = 1000 / 1.5M;



        public Decimal qsj = 0;
        public Decimal mmdDj = 0;
        public Decimal lmdj = 0;
        public Decimal mpfmdj = 0;
        public Decimal dqzddj = 0;
        public Decimal rjl = 1;//容积率
        public string yjhp = "000";
        public string date = DateTime.Now.ToString();



        public Decimal Pfm
        {
            get
            {
                return Math.Round(this.pfm, 1);
            }
            set
            {
                pfm = value;
            }
        }
        public Decimal M
        {
            get
            {
                return Math.Round(this.pfm / P2M, 3);
            }
            set
            {
                this.pfm = value * P2M;
            }
        }

        public decimal Qsj
        {
            get => qsj; set
            {
                qsj = value;
                this.RaisePropertyChanged("Qsj");
            }
        }
        public decimal MmdDj
        {
            get => Math.Round(mmdDj, 1);
            set
            {
                mmdDj = value;
                this.RaisePropertyChanged("MmdDj");
            }
        }
        public decimal Lmdj
        {
            get => Math.Round(lmdj, 1);
            set
            {
                lmdj = value; this.RaisePropertyChanged("Lmdj");
            }
        }
        public decimal Mpfmdj
        {
            get => Math.Round(mpfmdj, 1);
            set
            {
                mpfmdj = value;
                this.RaisePropertyChanged("Mpfmdj");
            }
        }
        public decimal Dqzddj
        {
            get => Math.Round(dqzddj, 1); set
            {
                dqzddj = value;
                this.RaisePropertyChanged("Dqzddj");
            }
        }

        public decimal Rjl
        {
            get => Math.Round(rjl, 1);
            set
            {
                rjl = value;
                this.RaisePropertyChanged("Rjl");
            }
        }

        public string Yjhp
        {
            get => yjhp; set
            {
                yjhp = value;
                this.RaisePropertyChanged("Yjhp");
            }
        }

        public string Date
        {
            get => date;
            set
            {
                date = value;
                this.RaisePropertyChanged("Date");
            }

        }
    }
}
