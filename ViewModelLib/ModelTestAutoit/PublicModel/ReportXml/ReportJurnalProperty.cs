using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using PublicLogicaFull.FileLogica.FileInfoLogica;
using System.Windows.Documents;
using AisPoco.ModelServiceDataBase;


namespace ViewModelLib.ModelTestAutoit.PublicModel.ReportXml
{
    /// <summary>
    /// Свойства Журнала и файлов для отработки XML
    /// </summary>
   public class ReportJournalProperty
    {
        /// <summary>
        /// Коллекция журналов xml
        /// </summary>
        public ObservableCollection<ReportJournalProperty> XmlReportJournal{ get; } = new ObservableCollection<ReportJournalProperty>();
        /// <summary>
        /// Коллекция файлов xml 
        /// </summary>
        public ObservableCollection<ReportJournalProperty> XmlFileZnach { get; } = new ObservableCollection<ReportJournalProperty>();
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

        /// <summary>
        /// Информация по файлу
        /// </summary>
        private string _infoFile;

        private ReportJournalProperty _xmlfile;

        /// <summary>
        /// Выбор файла xml MVVM
        /// </summary>
        public ReportJournalProperty XmlFile
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
        /// Информация по файлу отправки
        /// </summary>
        public string InfoFile
        {
            get { return _infoFile; }
            set { _infoFile = value; }
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
    /// Класс методов для класса ReportJournalProperty 
    /// </summary>
    public class ReportJournalMethod : ReportJournalProperty
    {
        private List<ModelServiceDataBase> ModelInfoFile { get; set; }
        /// <summary>
        /// Работа с журналом выполненных и отработанных
        /// </summary>
        /// <param name="pathJournalXml"></param>
        /// <param name="modelServer">Модель с описаниями файлов</param>
        public ReportJournalMethod(string pathJournalXml, List<ModelServiceDataBase> modelServer)
        {
            ModelInfoFile = modelServer;
            AddJournal(pathJournalXml);
        }

        /// <summary>
        /// Конструктор класса для манипуляции коллекциями
        /// </summary>
        /// <param name="pathJournalXml">Путь к Журналам с ошибками</param>
        /// <param name="pathFileXml">Путь к файлам XML для отработки</param>
        /// <param name="modelServer">Модель с описаниями файлов</param>
        public ReportJournalMethod(string pathJournalXml, string pathFileXml, List<ModelServiceDataBase> modelServer)
        {
            ModelInfoFile = modelServer;
            AddFileXml(pathFileXml);
            AddJournal(pathJournalXml);
        }
        /// <summary>
        /// Метод добавляющий журналы!!!
        /// </summary>
        /// <param name="pathJournalXml">Путь к Журналам с ошибками</param>
        public void AddJournal(string pathJournalXml)
        {
            if (Directory.Exists(pathJournalXml))
            {
                var fileLogic = new FileLogica();
                XmlReportJournal.Clear();
                foreach (var file in FileLogica.FileinfoMass(pathJournalXml))
                {
                    XmlReportJournal.Add(new ReportJournalProperty() { Icon = fileLogic.Extracticonfile(file.FullName), Name = file.Name, Path = file.FullName, InfoFile = ModelInfoFile?.FirstOrDefault(x => x.ModelNameFileXml == file.Name)?.FileInfoFile});
                }
            }
        }
        /// <summary>
        /// Метод добавляющий файлы!!!
        /// </summary>
        /// <param name="pathFileXml"></param>
        public void AddFileXml(string pathFileXml)
        {
            if (Directory.Exists(pathFileXml))
            {
                var fileLogic = new FileLogica();
                XmlFileZnach.Clear();
                foreach (var file in FileLogica.FileinfoMass(pathFileXml))
                {
                   XmlFileZnach.Add(new ReportJournalProperty() {Icon = fileLogic.Extracticonfile(file.FullName), Name = file.Name, Path = file.FullName});
                }
            }
        }

        public void OpenFile(string fullpath)
        {
            PublicLogicaFull.FileLogica.OpenFile.OpenFile.Openxls(fullpath);
        }

        public void DeleteXmlReportJournal()
        {
            File.Delete(XmlFile.Path);
            XmlReportJournal.Remove(XmlReportJournal.Single(fullPath => fullPath.Path == XmlFile.Path));
        }
    }
}
