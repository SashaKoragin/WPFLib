using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Data;
using PdfiumViewer;
using Prism.Mvvm;

namespace ViewModelLib.ModelTestAutoit.ModelFormirovanie.DonloadPrintDb
{
    public class FileDb
    {
        private int _idDoc;
        private string _name;
        private string _path;

        public int IdDoc
        {
            get { return _idDoc; }
            set { _idDoc = value; }
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


    public class DownloadPrintDb : BindableBase, IDataErrorInfo
    {
        public ObservableCollection<FileDb> FileCollection { get; } = new ObservableCollection<FileDb>();

        private int _countFileAll;

        public int CountFileAll
        {
            get { return _countFileAll; }
            set
            {
                _countFileAll = value;
                RaisePropertyChanged();
            }
        }

        public void CountFile(int count)
        {
            CountFileAll = count;
        }


        private int _progressDownloadMaximum = 1;
        private int _progressDownload;
        private string _downloadFile = "Файлы не подгружены.";
        private int _progressPrint;
        private int _progressPrintMaximum = 1;
        private string _statusPrint = "Простой принтера.";


        public int ProgressDownloadMaximum
        {
            get { return _progressDownloadMaximum; }
            set
            {
                _progressDownloadMaximum = value;
                RaisePropertyChanged();
            }
        }

        public int ProgressDownload
        {
            get { return _progressDownload; }
            set
            {
                _progressDownload = value;
                RaisePropertyChanged();
            }
        }

        public string DownloadFile
        {
            get { return _downloadFile; }
            set
            {
                _downloadFile = value;
                RaisePropertyChanged();
            }
        }
        public int ProgressPrintMaximum
        {
            get { return _progressPrintMaximum; }
            set
            {
                _progressPrintMaximum = value;
                RaisePropertyChanged();
            }
        }

        public int ProgressPrint
        {
            get { return _progressPrint; }
            set
            {
                _progressPrint = value;
                RaisePropertyChanged();
            }
        }

        public string StatusPrint
        {
            get { return _statusPrint; }
            set
            {
                _statusPrint = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Подгруздка файла из БД
        /// </summary>
        public bool IsLoadFileDb { get; set; } = true;
        /// <summary>
        /// Печать файла
        /// </summary>
        public bool IsPrintFile { get; set; } = true;

        /// <summary>
        /// Объект блокировки
        /// </summary>
        public object Lock = new object();
        /// <summary>
        /// Запретить обновление из потока Pattern MvVM
        /// </summary>
        public void UpdateOff(ObservableCollection<FileDb> modelPrint)
        {
            BindingOperations.DisableCollectionSynchronization(modelPrint);
        }
        /// <summary>
        /// Метод разрешить обновление из потока Pattern MvVM
        /// </summary>
        public void UpdateOn(ObservableCollection<FileDb> modelPrint)
        {
            BindingOperations.EnableCollectionSynchronization(modelPrint, Lock);
        }
        private bool IsValid { get; set; } = true;
        public string Error { get; set; }

        public string this[string columnName]
        {
            get { return ValidateErrs(columnName); }
        }


        public void ProgressMaxPrint(int count)
        {
            ProgressPrintMaximum = count;
        }

        public void ProgressPrintFile(string nameFile)
        {
            StatusPrint = "Распечатываем: " + nameFile;
            ProgressPrint++;
        }
        public void ProgressPrintFileDefault()
        {
            ProgressPrint = 0;
        }

        public void ProgressMaxDownload(int count)
        {
            ProgressDownloadMaximum = count;
        }

        public void ProgressDownloadFile(string nameFile)
        {
            DownloadFile = "Подгружаем: " + nameFile;
            ProgressDownload++;
        }
        public void ProgressDownloadFileDefault()
        {
            ProgressDownload = 0;
        }

        public bool IsValidationWork()
        {
            IsValid = false;
            RaisePropertyChanged($"CountFileAll");
            return IsValid;
        }

        public string ValidateErrs(string columnName)
        {
            Error = null;
            if (!IsValid)
                switch (columnName)
                {
                    case "CountFileAll":
                        if (FileCollection.Count != 0)
                        { IsValid = true; break; }
                    { Error = "Печать не возможна нет файлов для печати!!!"; break; }
                }
            return Error;
        }

        /// <summary>
        /// Заполнение файла выгрузки из БД
        /// </summary>
        /// <param name="fullPath">Полный путь</param>
        /// <param name="nameFile">Имя файла</param>
        /// <param name="idDoc">Ун документа в БД</param>
        public void DownloadFileDb(string fullPath, string nameFile, int idDoc)
        {
            if (File.Exists(fullPath))
            {
                            FileCollection.Add(new FileDb
                            {
                                Name = nameFile,
                                Path = fullPath,
                                IdDoc = idDoc
                            });
            }
        }

        private bool _isEndPrint;
        /// <summary>
        /// Печать документа
        /// </summary>
        /// <param name="path">Путь </param>
        /// <param name="fileName">Имя файла</param>
        public void Print(string path, string fileName)
        {
            _isEndPrint = true;
            using (var document = PdfDocument.Load(path))
            {
                using (var printDocument = document.CreatePrintDocument())
                {
                    printDocument.EndPrint += EndPrintEvent;
                    printDocument.DocumentName = fileName;
                    printDocument.PrintController = new StandardPrintController();
                    printDocument.Print();
                    while (_isEndPrint) { }
                    printDocument.EndPrint -= EndPrintEvent;
                }
            }
        }
        /// <summary>
        /// Окончание печати
        /// </summary>
        private void EndPrintEvent(object s,PrintEventArgs e)
        {
            _isEndPrint = false;
        }
    }
}
