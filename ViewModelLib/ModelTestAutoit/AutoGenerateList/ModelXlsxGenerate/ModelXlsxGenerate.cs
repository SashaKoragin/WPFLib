using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using ClosedXML.Excel;
using Prism.Mvvm;
using PublicLogicaFull.FileLogica.FileInfoLogica;

namespace ViewModelLib.ModelTestAutoit.AutoGenerateList.ModelXlsxGenerate
{
   public class ModelXlsxGenerate : BindableBase, IDataErrorInfo
    {

        /// <summary>
        /// Файлы Xlsx для формирования списков
        /// </summary>
        private ObservableCollection<ModelXlsxGenerate> SchemesAllXlsx = new ObservableCollection<ModelXlsxGenerate>();

        /// <summary>
        /// Получение коллекции
        /// </summary>
        public ObservableCollection<ModelXlsxGenerate> SchemesXlsx
        { get { return SchemesAllXlsx; } }

        private ModelXlsxGenerate _selectItem;
        private Icon _icon;
        private string _nameFile;
        private string _fullPathFile;
        private List<string> _collectionSheet;
        private int _numberMemoRow = 0;
        private string _selectionSheet;
        private string _errorXml;
        


        /// <summary>
        /// Выбрать элемент
        /// </summary>
        public ModelXlsxGenerate SelectItem
        {
            get { return _selectItem; }
            set
            {
                _selectItem = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Иконка файла Xlsx
        /// </summary>
        public Icon Icon
        {
            get { return _icon; }
            set
            {
                _icon = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// Имя файла
        /// </summary>
        public string NameFile
        {
            get { return _nameFile; }
            set
            {
                _nameFile = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// Полный путь к файлу
        /// </summary>
        public string FullPathFile
        {
            get { return _fullPathFile; }
            set
            {
                _fullPathFile = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Коллекция листов в xlsx
        /// </summary>
        public List<string>  CollectionSheet
        {
            get { return _collectionSheet; }
            set
            {
                _collectionSheet = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Номер строки для назначения заголовка
        /// </summary>
        public int NumberMemoRow
        {
            get { return _numberMemoRow; }
            set
            {
                _numberMemoRow = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// Выбранный лист!
        /// </summary>
        public string SelectionSheet
        {
            get { return _selectionSheet; }
            set
            {
                _selectionSheet = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// Ошибка формирования списка
        /// </summary>
        public string ErrorXml
        {
            get { return _errorXml; }
            set
            {
                _errorXml = value;
                RaisePropertyChanged();
            }
        }


        public string Error { get; set; }
        private bool IsValid { get; set; } = true;
        public string this[string columnName]
        {
            get { return ValidateErrs(columnName); }
        }
        /// <summary>
        /// Проверка Validation
        /// </summary>
        /// <returns></returns>
        public bool IsValidationXlsx()
        {
            IsValid = false;
            RaisePropertyChanged("SchemesXlsx");
            RaisePropertyChanged("SelectionSheet");
            return IsValid;
        }

        /// <summary>
        /// Проверка выбрана ли схема
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        private string ValidateErrs(string columnName)
        {
            Error = null;
            if (!IsValid)
                switch (columnName)
                {
                    case "SchemesXlsx":
                        if (SchemesXlsx.Count() != 0)
                        { IsValid = true; break; }
                    { Error = "Не добавлен не один из элементов!!!"; break;}
                    case "SelectionSheet":
                        if (SelectionSheet != null)
                        { IsValid = true; break; }
                    { Error = "Не выбран лист в XLSX!!!"; break; }
                }
            return Error;
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
            BindingOperations.DisableCollectionSynchronization(SchemesXlsx);
        }
        /// <summary>
        /// Метод разрешить обновление из потока паттерн MVVM
        /// </summary>
        public void UpdateOn()
        {
            BindingOperations.EnableCollectionSynchronization(SchemesXlsx, Lock);
        }
    }

   public class MethodModelXlsx : ModelXlsxGenerate
   {


        /// <summary>
        /// Конструктор класса
        /// </summary>
       public MethodModelXlsx()
       {

       }
        /// <summary>
        /// Метод добавление файлов
        /// </summary>
        /// <param name="arrayStringNameFile">Массив имен файлов</param>
        public void AddFiles(string[] arrayStringNameFile)
        {

            var fileLogic = new FileLogica();
            foreach (var nameFile in arrayStringNameFile)
            {
                FileInfo fileInfo = new FileInfo(nameFile);
                if (fileInfo.Exists && fileInfo.Extension ==".xlsx")
                {
                    var workBook = new XLWorkbook(nameFile);
                    SchemesXlsx.Add(new ModelXlsxGenerate()
                    {
                        Icon = fileLogic.Extracticonfile(fileInfo.FullName),
                        NameFile = fileInfo.Name,
                        FullPathFile = nameFile,
                        CollectionSheet = workBook.Worksheets.ToArray().Select(x => x.Name).ToList(),
                        ErrorXml = null
                    });
                    workBook.Dispose();
                }
            }
        }
        /// <summary>
        /// Удаление из модели xlsx
        /// </summary>
        public void DeleteXlsx()
        {
            SchemesXlsx.Remove(SelectItem);
        }

   }
}
