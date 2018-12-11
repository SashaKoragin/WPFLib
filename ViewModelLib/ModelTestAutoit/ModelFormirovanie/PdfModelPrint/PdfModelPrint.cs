using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Data;
using Prism.Mvvm;
using PublicLogicaFull.FileLogica.FileInfoLogica;
using GalaSoft.MvvmLight.Threading;
using PdfiumViewer;

namespace ViewModelLib.ModelTestAutoit.ModelFormirovanie.PdfModelPrint
{
   public class PdfModelPrint: ICloneable
    {
        private Icon _icon;
        private string _name;
        private string _path;
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
        /// <summary>
        /// Клонирование колекции
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return MemberwiseClone();
        }
    }

    public class PdfListFile : BindableBase, IDataErrorInfo
    {
        /// <summary>
        /// Объект блокировки
        /// </summary>
        public object Lock = new object();
        /// <summary>
        /// Запретить обновление из потока Патерн MVVM
        /// </summary>
        public void UpdateOff(ObservableCollection<PdfModelPrint> modelPrint )
        {
            BindingOperations.DisableCollectionSynchronization(modelPrint);
        }
        /// <summary>
        /// Метод разрешить обновление из потока патерн MVVM
        /// </summary>
        public void UpdateOn(ObservableCollection<PdfModelPrint> modelPrint)
        {
            BindingOperations.EnableCollectionSynchronization(modelPrint, Lock);
        }

        private bool _isdisableprint = true;
        private int _maxprintdoc = 100;
        private int _statvalue;
        private int _statvaluemax = 1;
        private string _statusPrint = "Простой принтера";


        private void CountBaground(int count)
        {
            StatValueMax = count;
            IsDisablePrint = false;
        }

        private void Progress(string namefile)
        {
            StatusPrint = "Печатаем: " + namefile;
            StatValue++;
        }
        private void Default()
        {
            StatusPrint = "Простой принтера";
            StatValue = 0;
            StatValueMax = 1;
            IsDisablePrint = true;
        }
        public int MaxPrintDoc
        {
            get { return _maxprintdoc; }
            set
            {
                _maxprintdoc = value;
                RaisePropertyChanged();
            }
        }

        public bool IsDisablePrint
        {
            get { return _isdisableprint; }
            set
            {
                _isdisableprint = value;
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
        public int StatValue
        {
            get { return _statvalue; }
            set
            {
                _statvalue = value;
                RaisePropertyChanged();
            }
        }
        public int StatValueMax
        {
            get { return _statvaluemax; }
            set
            {
                _statvaluemax = value;
                RaisePropertyChanged();
            }
        }
        private bool IsValid { get; set; } = true;
        public string Error { get; set; }
        private ObservableCollection<PdfModelPrint> _pdffiletemp = new ObservableCollection<PdfModelPrint>();

        public ObservableCollection<PdfModelPrint> PdfFileTemp
        {
            get { return _pdffiletemp; }
        }
        private ObservableCollection<PdfModelPrint> _pdffilework = new ObservableCollection<PdfModelPrint>();

        public ObservableCollection<PdfModelPrint> PdfFileWork
        {
            get { return _pdffilework; }
        }

        public string this[string columnName]
        {
            get { return ValidateErrs(columnName); }
        }

        public string ValidateErrs(string columnName)
        {
            Error = null;
            if (!IsValid)
                switch (columnName)
                {
                    case "PdfFileTemp":
                        if (PdfFileTemp.Count!=0)
                        { IsValid = true; break; }
                        { Error = "Нет элементов для переноса!!!"; break; }
                    case "PdfFileWork":
                      if (PdfFileWork.Count != 0)
                        { IsValid = true; break; }
                        { Error = "Нет файлов на печать!!!"; break; }
                    case "MaxPrintDoc":
                      if (MaxPrintDoc != 0)
                        { if (MaxPrintDoc > 400)
                            { Error = "Не может превышать 400 документов!!!"; break; }
                            {IsValid = true; break;  }}
                        { Error = "Не выбрано количество документов!!!"; break; }
                }
            return Error;
        }

        /// <summary>
        /// Проверка Validation
        /// </summary>
        /// <returns></returns>
        public bool IsValidationTemp()
        {
            IsValid = false;
            RaisePropertyChanged("PdfFileTemp");
            return IsValid;
        }

        public bool IsValidationWork()
        {
            IsValid = false;
            RaisePropertyChanged("PdfFileWork");
            IsValid = false;
            RaisePropertyChanged("MaxPrintDoc");
            return IsValid;
        }

        /// <summary>
        /// Путь для анализа папки на PDF Temp
        /// </summary>
        /// <param name="path"></param>
        public async void CountPdfTemp(string path)
        {
            try
            {
              if (Directory.Exists(path))
               {
                PdfFileTemp.Clear();
                UpdateOn(PdfFileTemp);
                var filelogica = new FileLogica();
               await Task.Run(delegate
                {
                    lock (Lock)
                    {
                        var file = FileLogica.FileinfoMass("*.pdf", path);
                        foreach (var fileInfo in file)
                        {
                            PdfFileTemp.Add(new PdfModelPrint
                            {
                                Icon = filelogica.Extracticonfile(fileInfo.FullName),
                                Name = fileInfo.Name,
                                Path = fileInfo.FullName
                            });
                        }
                    }
                    UpdateOff(PdfFileTemp);
                });
            }
            }
            catch (Exception e)
            {
              Console.Write(e);
            }

        }

        /// <summary>
        /// Для исключения дублей в колекции
        /// Путь для анализа папки на PDF Work
        /// </summary>
        /// <param name="path"></param>
        public async void CountPdfWork(string path)
        {
          if (Directory.Exists(path))
          {
           PdfFileWork.Clear();
           UpdateOn(PdfFileWork);
           await Task.Run(delegate
            {
                var filelogica = new FileLogica();
                lock (Lock)
                {
                    var file = FileLogica.FileinfoMass("*.pdf", path);
                    foreach (var fileInfo in file)
                    {
                        PdfFileWork.Add(new PdfModelPrint
                        {
                            Icon = filelogica.Extracticonfile(fileInfo.FullName),
                            Name = fileInfo.Name,
                            Path = fileInfo.FullName
                        });
                    }
                    UpdateOff(PdfFileWork);
                }
            });
            }
        }

        /// <summary>
        /// Метод переноса из Temp в Work
        /// </summary>
        /// <param name="pathwork">Путь к рабочей папке</param>
        public async void MoveWork(string pathwork)
        {
            UpdateOn(PdfFileWork);
            UpdateOn(PdfFileTemp);
            if (!Directory.Exists(pathwork))
            {
                Directory.CreateDirectory(pathwork);
            }
            if (IsValidationTemp())
            {
                await Task.Run(delegate
                {
                    PdfFileWork.Clear();
                    var filelogica = new FileLogica();
                    var clonedList = PdfFileTemp.Select(objEntity => (PdfModelPrint)objEntity.Clone()).ToList();
                    foreach (var list in clonedList)
                    {
                        File.Copy(list.Path, Path.GetFullPath(pathwork) + list.Name, true);
                        PdfFileWork.Add(new PdfModelPrint
                        {
                            Icon = filelogica.Extracticonfile(list.Path),
                            Name = list.Name,
                            Path = list.Path
                        });
                    }
                    PdfFileTemp.Clear();
                    UpdateOff(PdfFileWork);
                    UpdateOff(PdfFileTemp);
                });
            }
        }

        /// <summary>
        /// Удаление сформированых файлов в Temp
        /// </summary>
        public async void DeleteTemp()
        {
            UpdateOn(PdfFileTemp);
            if (IsValidationTemp())
            {
                await Task.Run(delegate
                {
                    foreach (var print in PdfFileTemp)
                    {
                        File.Delete(print.Path);
                    }
                    PdfFileTemp.Clear();
                    UpdateOff(PdfFileTemp);
            });
        }
    }

        /// <summary>
        /// Печать документов файлов
        /// </summary>
        public async void PrintAllFile(string pathwork)
        {
            if (IsValidationWork())
            {
                DispatcherHelper.Initialize();
                CountBaground(PdfFileWork.Count);
                await Task.Run(delegate
                {
                    foreach (var file in PdfFileWork)
                    {
                        DispatcherHelper.UIDispatcher.Invoke(delegate { Progress(file.Name); });
                        using (var document = PdfDocument.Load(file.Path))
                        {
                            using (var printDocument = document.CreatePrintDocument())
                            {
                                printDocument.DocumentName = file.Name;
                                printDocument.PrintController = new StandardPrintController();
                                printDocument.Print();
                            }
                        }
                        File.Delete(file.Path);
                        if (StatValue == MaxPrintDoc)
                        {
                            break;
                        }
                    }
                    DispatcherHelper.UIDispatcher.Invoke(delegate { Default(); });
                    DispatcherHelper.UIDispatcher.Invoke(delegate { CountPdfWork(pathwork); });
                });    
            }
        }
    }
}

