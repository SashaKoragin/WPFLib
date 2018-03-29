﻿using System.Collections.ObjectModel;
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
        public ObservableCollection<ListViewModelXmlFileGenerateProperty> _xmlfile= new ObservableCollection<ListViewModelXmlFileGenerateProperty>();

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
        public object _lock = new object();
        /// <summary>
        /// Запретить обновление из потока Патерн MVVM
        /// </summary>
        public void UpdateOff()
        {
            BindingOperations.DisableCollectionSynchronization(XmlFiles);
        }
        /// <summary>
        /// Метод разрешить обновление из потока патерн MVVM
        /// </summary>
        public void UpdateOn()
        {
            BindingOperations.EnableCollectionSynchronization(XmlFiles, _lock);
        }

        /// <summary>
        /// Метод добавление в Модель Объектов!!!
        /// </summary>
        /// <param name="path">Путь к файлам</param>
        public void AddXmlFile(string path)
        {
            XmlFiles.Clear();
            lock (_lock)
            {
                if (Directory.Exists(path))
                {
                    foreach (var file in FileLogica.FileinfoMass(path))
                    {
                       XmlFiles.Add(new ListViewModelXmlFileGenerateProperty { Icon = FileLogica.Extracticonfile(file.FullName), Name = file.Name, Path = file.FullName });
                    }
                }
            }
        }
        /// <summary>
        /// Метод переноса файла списка xml на отработку после формирования
        /// </summary>
        /// <param name="pathnew"></param>
        public void MoveFile(string pathnew)
        {
            if (System.IO.File.Exists(File.Path))
            {
                System.IO.File.Delete(pathnew);
            }
            System.IO.File.Move(File.Path, pathnew);
            XmlFiles.Remove(XmlFiles.Single(name => name.Path == File.Path));
        }
    }
}