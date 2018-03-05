using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Drawing;


namespace SeathZip.SeathZipF.SeathPath
{
    [Serializable()]
    class PathStart : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<PathStart> Path { get; set; }
        public ObservableCollection<PathStart> PathNew { get; set; }
        //public ObservableCollection<PathStart> PathFull { get; set; }

        private void OnPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public String Namepath;
        public Icon Iconpath;

        public String Pathnow;
        public Icon Iconpathnow;

        public String Fullpath;
        public Icon Fullicon;

        public String NamePath
        {
            get { return Namepath; }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                Namepath = value;
                OnPropertyChanged("NamePath");
            }
        }
        public Icon IconPath
        {
            get { return Iconpath; }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                IconPath = value;
                OnPropertyChanged("IconPath");
            }
        }


        public String PathNow
        {
            get { return Pathnow; }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                Pathnow = value;
                OnPropertyChanged("PathNow");
            }
        }
        public Icon IconPathNow
        {
            get { return Iconpathnow; }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                IconPathNow = value;
               OnPropertyChanged("IconPathNow");
            }
        }

        public String FullPath
        {
            get { return Fullpath; }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                Fullpath = value;
                OnPropertyChanged("FullPath");
            }
        }

        public Icon FullIcon
        {
            get { return Fullicon; }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                Fullicon = value;
                OnPropertyChanged("FullIcon");
            }
        }
    }
}
