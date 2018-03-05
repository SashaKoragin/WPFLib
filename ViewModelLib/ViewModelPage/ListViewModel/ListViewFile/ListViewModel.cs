using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Data;
using Prism.Mvvm;

namespace ViewModelLib.ViewModelPage.ListViewModel.ListViewFile
{
    /// <summary>
    /// Модель для ListVeiv класическая содержит
    /// Блокировку для работы с потоком 
    /// Иконку файла
    /// Имя файла
    /// Коллекцию файлов
    /// Путь к файлу
    /// </summary>
    public class ListViewModel : BindableBase
    {
        public object _lock = new object();

        public void UpdateOff()
        {
            BindingOperations.DisableCollectionSynchronization(ShemesFiles);
        }

        public void UpdateOn()
        {
            BindingOperations.EnableCollectionSynchronization(ShemesFiles, _lock);
        }

        private ObservableCollection<ListViewModel> _shemesfiles = new ObservableCollection<ListViewModel>();

        public ObservableCollection<ListViewModel> ShemesFiles
        {
            get { return _shemesfiles; }
        }

        private ListViewModel _filedbf;
        private Icon _icon;
        private string _name;
        private string _path;

        public ListViewModel FileDbf
        {
            get { return _filedbf; }
            set { _filedbf = value; }
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