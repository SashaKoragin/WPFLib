using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Xml.Schema;

namespace WordReportsFull.ValidationControl
{
   public class ContentZn : INotifyPropertyChanged
    {
        public ObservableCollection<ContentZn> PathTemplate { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Inn { get; set; }
        public string God { get; set; }

        public String Nametemplate;
        public Icon Icontemplate;
        public object[] Sqlt;
        public String Fullname;
        public XmlSchemaSet Xmlcol;
        public object[] Qbeselect;

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
        public Icon IconTemplate
        {
            get { return Icontemplate; }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                Icontemplate = value;
                OnPropertyChanged("IconTemplate");
            }
        }
        public object[] SqlT
        {
            get { return Sqlt; }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                Sqlt = value;
                OnPropertyChanged("NameTemplate");
            }
        }

        public String FullName
        {
            get { return Fullname;}
            set
            {
                if (value==null) throw new ArgumentNullException(nameof(value));
                Fullname = value;
                OnPropertyChanged("FullName");
            }
        }

        public XmlSchemaSet XmlCol
        {
            get { return Xmlcol; }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                Xmlcol = value;
                OnPropertyChanged("XmlCol");
            }
        }

        public object[] QbeSelect
        {
            get { return Qbeselect; }
            set
            {
                Qbeselect = value;
                OnPropertyChanged("QbeSelect");
            } 
        }

    }
}
