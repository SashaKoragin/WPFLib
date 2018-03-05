using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DBFtoSQL2008Enterprise.Aplication.ViewModelElement.ViewModel
{
   public class ModelProgressBar : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public string Nametable;
        public int Procentobr;

        public string NameTable
        {
            get { return Nametable; }
            set
            {
                Nametable = value;
                OnPropertyChanged("NameTable");
            }
        }

        public int ProcentObr
        {
            get { return Procentobr; }
            set
            {
                Procentobr = value;
                OnPropertyChanged("ProcentObr");
            }
        }
    }
}
