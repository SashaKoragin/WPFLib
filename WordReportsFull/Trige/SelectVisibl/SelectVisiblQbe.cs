using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WordReportsFull.Trige.SelectVisibl
{
    class SelectVisiblQbe : INotifyPropertyChanged
    {
        public ObservableCollection<SelectVisiblQbe> Path { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
       private void OnPropertyChanged(String propertyName)
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }

        public String Nametemplate;
        public String I;
        public String NameTemplate
        {
            get { return Nametemplate; }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                Nametemplate = value;
                OnPropertyChanged("NameTemplate");
            }
        }

        public String Ii
        {
            get { return I; }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                I = value;
                OnPropertyChanged("Ii");
            }
        }
    }
}
