using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using DBFtoSQL2008Enterprise.Aplication.ResourceDBFtoSQL;

namespace DBFtoSQL2008Enterprise.Aplication.ViewModelElement.ViewModel
{
   
  [Serializable]
   public class Dbf : INotifyPropertyChanged
    {
        
        public ObservableCollection<Dbf> Shemes { get; set; }

        public ObservableCollection<ShemeClass> Sheme { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Nametable;
        public string Fullname;

        public string NameTable
        {
            get { return Nametable; }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                Nametable = value;
                OnPropertyChanged("NameTemplate");
            }
        }

        public string FullName
        {
            get { return Fullname; }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                Fullname = value;
                OnPropertyChanged("FullName");
            }
        }
        
        public class ShemeClass
        {
            public ObservableCollection<ShemeClass> Sheme { get; set; }

            public string Namecolums;
            public int Indexcolums;
            public DbType Typecolums;
            public int IndexColums
            {
                get { return Indexcolums; }
                set { Indexcolums = value; }
            }
            public string NameColums
            {
                get { return Namecolums; }
                set { Namecolums = value; }
            }

            public DbType TypeColums
            {
                get { return Typecolums; }
                set { Typecolums = value; }
            }
        }
        }
}
