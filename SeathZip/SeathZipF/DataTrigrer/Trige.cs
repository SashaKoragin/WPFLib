using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeathZip.SeathZipF.DataTrigrer
{
    public class Trige : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public String Error = @"error"; //Красный символизирует ошибку что путь не выбран

        public String ElementError
        {
            get { return Error; }
            set
            {
                Error = value;
                OnPropertyChanged("ElementError");
            }
        }


    }
}
