using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Data;
using Prism.Mvvm;
using PublicLogicaFull.FileLogica.FileInfoLogica;

namespace ViewModelLib.ModelTestAutoit.ModelFormirovanie.ListViewModelXml
{
    /// <summary>
    /// 
    /// </summary>
   public class ListViewModelXmlFileGenerateProperty : BindableBase
    {
        private ObservableCollection<ListViewModelXmlFileGenerateProperty> _xmlfile = new ObservableCollection<ListViewModelXmlFileGenerateProperty>();

        public ObservableCollection<ListViewModelXmlFileGenerateProperty> XmlFiles
        {
            get { return _xmlfile; }
        }

        private ListViewModelXmlFileGenerateProperty _file;
        private Icon _icon;
        private string _name;
        private string _path;

        public ListViewModelXmlFileGenerateProperty File
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
    /// <summary>
    /// Методы ListViewModelXmlFileGenerateProperty для манипуляции
    /// </summary>
    public class ListViewModelXmlFileGenerateMethod : ListViewModelXmlFileGenerateProperty
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="path">Путь к файлам xml на выходе после конвертации из Excel</param>
        public ListViewModelXmlFileGenerateMethod(string path)
        {
            AddXmlFile(path);
        }

        /// <summary>
        /// Объект блокировки
        /// </summary>
        public object Lock = new object();
        /// <summary>
        /// Запретить обновление из потока Патерн MVVM
        /// </summary>
        public void UpdateOff()
        {
            BindingOperations.DisableCollectionSynchronization(XmlFiles);
        }
        /// <summary>
        /// Метод разрешить обновление из потока паттерн MVVM
        /// </summary>
        public void UpdateOn()
        {
            BindingOperations.EnableCollectionSynchronization(XmlFiles, Lock);
        }

        /// <summary>
        /// Метод добавление в Модель Объектов!!!
        /// </summary>
        /// <param name="path">Путь к файлам</param>
        public void AddXmlFile(string path)
        {
            XmlFiles.Clear();
            lock (Lock)
            {
                var fileLogic = new FileLogica();
                Directory.CreateDirectory(path);
                    foreach (var file in FileLogica.FileinfoMass(path))
                    {
                       XmlFiles.Add(new ListViewModelXmlFileGenerateProperty { Icon = fileLogic.Extracticonfile(file.FullName), Name = file.Name, Path = file.FullName });
                    }
            }
        }
        /// <summary>
        /// Метод переноса файла списка xml на отработку после формирования
        /// </summary>
        /// <param name="pathNew">Путь к сформированным спискам</param>
        public void MoveFile(string pathNew)
        {
            if (System.IO.File.Exists(File.Path))
            {
                System.IO.File.Delete(pathNew + File.Name);
            }
            System.IO.File.Move(File.Path, pathNew + File.Name);
            XmlFiles.Remove(XmlFiles.Single(name => name.Path == File.Path));
        }
    }
}