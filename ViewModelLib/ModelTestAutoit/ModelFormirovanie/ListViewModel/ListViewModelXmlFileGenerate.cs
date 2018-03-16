using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Windows.Data;
using Prism.Mvvm;

namespace ViewModelLib.ModelTestAutoit.ModelFormirovanie.ListViewModel
{
   public class ListViewModelXmlFileGenerate : BindableBase
    {
        public object _lock = new object();

        public void UpdateOff()
        {
            BindingOperations.DisableCollectionSynchronization(XmlFiles);
        }

        public void UpdateOn()
        {
            BindingOperations.EnableCollectionSynchronization(XmlFiles, _lock);
        }

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

        public void AddXmlFile( string path)
        {
            File.XmlFiles.Clear();
            lock (File._lock)
            {
                if (Directory.Exists(path))
                {
                    //foreach (var file in Fileinfo(path))
                    //{
                    //    File.XmlFiles.Add(new ListViewModelXmlFileGenerate() { Icon = PublicAdd.IconsFile.Extracticonfile(file.FullName), Name = file.Name, Path = file.FullName });
                    //}
                }
            }
            
        }
    }
}