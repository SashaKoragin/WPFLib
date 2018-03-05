using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;

namespace SeathZip.SeathZipF.DataTrigrer
{
   public class Contents : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Contents> File { get; set; }

        private void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public Icon Fileicon;
        public string Namefile;
        

        public string NameFile
        {
            get { return Namefile; }
            set
            {
                Namefile = value;
                OnPropertyChanged("NameFile");
            }
        }

        public Icon FileIcon
        {
            get { return Fileicon; }
            set
            {
                Fileicon = value;
                OnPropertyChanged("NameArx");
            }
        }

        public string SeathZn { get; set; }
        public string SeathZnFull { get; set; }

    }
}
