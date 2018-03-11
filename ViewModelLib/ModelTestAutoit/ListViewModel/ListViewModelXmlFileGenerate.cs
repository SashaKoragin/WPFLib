using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Data;
using Prism.Mvvm;

namespace ViewModelLib.ModelTestAutoit.ListViewModel
{
   public class ListViewModelXmlFileGenerate : BindableBase
    {
      public ObservableCollection<ListViewModelXmlFileGenerate> _xmlfile= new ObservableCollection<ListViewModelXmlFileGenerate>();

        public ObservableCollection<ListViewModelXmlFileGenerate> XmlFiles
        {
            get { return _xmlfile; }
        }

        private ListViewModelXmlFileGenerate _file;
        private Icon _icon;
        private string _name;
        private string _path;

        public ListViewModelXmlFileGenerate File
        {
            get { return _file; }
            set { _file = value; }
        }

        public Icon Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }
    }
}