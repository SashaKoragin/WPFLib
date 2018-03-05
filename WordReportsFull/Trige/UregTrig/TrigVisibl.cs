using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordReportsFull.Trige.UregTrig

{
    //Тригеры на метку 1 Ошибка 0 Нет ошибки задается при изменениии свойства.
    public class TrigVisibl : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public Boolean Innvisibl;
        public Boolean Kbkvisibl;
        public Boolean Godvisibl;

        public Boolean InnVisibl
        {
            get { return Innvisibl; }
            set
            {
                Innvisibl = value;
                OnPropertyChanged("InnVisibl");
            }
        }

        public Boolean KbkVisibl
        {
            get { return Kbkvisibl; }
            set
            {
                Kbkvisibl = value;
                OnPropertyChanged("KbkVisibl");
            }
        }

        public Boolean GodVisibl
        {
            get { return Godvisibl; }
            set
            {
                Godvisibl = value;
                OnPropertyChanged("GodVisibl");
            }
        }
    }
}

