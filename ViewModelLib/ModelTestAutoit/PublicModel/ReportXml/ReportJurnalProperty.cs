using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using PublicLogicaFull.FileLogica.FileInfoLogica;
using System.Windows.Documents;
using Prism.Mvvm;


namespace ViewModelLib.ModelTestAutoit.PublicModel.ReportXml
{
    /// <summary>
    /// Свойства Журнала и файлов для отработки XML
    /// </summary>
   public class ReportJurnalProperty
    {
        /// <summary>
        /// Коллекция журналов xml
        /// </summary>
        public ObservableCollection<ReportJurnalProperty> XmlReportJurnal{ get; } = new ObservableCollection<ReportJurnalProperty>();
        /// <summary>
        /// Коллекция файлов xml 
        /// </summary>
        public ObservableCollection<ReportJurnalProperty> XmlFileZnach { get; } = new ObservableCollection<ReportJurnalProperty>();
        /// <summary>
        /// Иконка файла
        /// </summary>
        private Icon _icon;
        /// <summary>
        /// Имя файла
        /// </summary>
        private string _name;
        /// <summary>
        /// Полный путь к файлу
        /// </summary>
        private string _path;

        private ReportJurnalProperty _xmlfile;

        /// <summary>
        /// Выбор файла xml MVVM
        /// </summary>
        public ReportJurnalProperty XmlFile
        {
            get { return _xmlfile; }
            set { _xmlfile = value; }
        }
        /// <summary>
        /// Иконка файла
        /// </summary>
        public Icon Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }
        /// <summary>
        /// Имя файла
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// Путь к файлу
        /// </summary>
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }
          /// <summary>
          /// Открытие документа xml на форме XAML MVVM
          /// </summary>
        public FlowDocument Document
        {
            get { return PublicLogicaFull.DocumentLogica.FlowDocuments.OpenDocument.DocumentJurnal(Path); }
        }
    }
    /// <summary>
    /// Класс методов для класса ReportJurnalProperty 
    /// </summary>
    public class ReportJurnalMethod : ReportJurnalProperty
    {
        /// <summary>
        /// Конструктор класса для манипуляциии колекциями
        /// </summary>
        /// <param name="pathJurnalXml">Путь к Журналам с ошибками</param>
        /// <param name="pathfileXml">Путь к файлам XML для отработки</param>
        public ReportJurnalMethod(string pathJurnalXml, string pathfileXml)
        {
            AddFileXml(pathfileXml);
            AddJurnal(pathJurnalXml);
        }
        /// <summary>
        /// Метод добавляющий журналы!!!
        /// </summary>
        /// <param name="pathJurnalXml">Путь к Журналам с ошибками</param>
        public void AddJurnal(string pathJurnalXml)
        {
            
            if (Directory.Exists(pathJurnalXml))
            {
                XmlReportJurnal.Clear();
                foreach (var file in FileLogica.FileinfoMass(pathJurnalXml))
                {
                    XmlReportJurnal.Add(new ReportJurnalProperty() { Icon = FileLogica.Extracticonfile(file.FullName), Name = file.Name, Path = file.FullName });
                }
            }
        }
        /// <summary>
        /// Метод добавляющий файлы!!!
        /// </summary>
        /// <param name="pathfileXml"></param>
        public void AddFileXml(string pathfileXml)
        {
            if (Directory.Exists(pathfileXml))
            {
                XmlFileZnach.Clear();
                foreach (var file in FileLogica.FileinfoMass(pathfileXml))
                {
                   XmlFileZnach.Add(new ReportJurnalProperty() {Icon = FileLogica.Extracticonfile(file.FullName), Name = file.Name, Path = file.FullName});
                }
            }
        }



        public void OpenFile(string fullpath)
        {
            PublicLogicaFull.FileLogica.OpenFile.OpenFile.Openxls(fullpath);
        }
    }
}
