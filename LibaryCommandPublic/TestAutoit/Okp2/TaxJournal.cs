using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using EfDatabaseAutomation.Automation.BaseLogica.AddObjectDb;
using GalaSoft.MvvmLight.Threading;
using LibraryAIS3Windows.ButtonsClikcs;
using ViewModelLib.ModelTestAutoit.ModelFormirovanie.DonloadPrintDb;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using ViewModelLib.ModelTestAutoit.PublicModel.ModelDatePickerAdd;

namespace LibraryCommandPublic.TestAutoit.Okp2
{
   public class TaxJournal
    {
        /// <summary>
        /// Автоматизация ветки Налоговое администрирование\Контрольная работа (налоговые проверки)\
        /// 129. Налоговые правонарушения\
        /// 2. Журнал налоговых правонарушений
        /// </summary>
        /// <param name="statusButton">Кнопка запустить задание</param>
        /// <param name="pathJournalOk">Путь к журналу</param>
        /// <param name="pathPdfTemp">Путь к Temp</param>
        /// <param name="datePicker">Дата вызова плательщика</param>
        public void StartTaxJournal(StatusButtonMethod statusButton, string pathJournalOk, string pathPdfTemp, DatePickerAdd datePicker)
        {
            DispatcherHelper.Initialize();
            Task.Run(delegate
            {
                try
                {
                    DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                    KclicerButton clickerButton = new KclicerButton();
                    LibraryAIS3Windows.Window.WindowsAis3 ais3 = new LibraryAIS3Windows.Window.WindowsAis3();
                    if (ais3.WinexistsAis3() == 1)
                    {
                        clickerButton.Click27(statusButton,pathJournalOk,pathPdfTemp, datePicker);
                        DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                    }
                    else
                    {
                        MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            });
        }

        /// <summary>
        /// Запуск пользовательского задания на утверждение налоговых обязанностей
        /// </summary>
        /// <param name="statusButton"></param>
        public void StartTaxApprove(StatusButtonMethod statusButton)
        {
            DispatcherHelper.Initialize();
            Task.Run(delegate
            {
                try
                {
                    DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                    KclicerButton clickerButton = new KclicerButton();
                    LibraryAIS3Windows.Window.WindowsAis3 ais3 = new LibraryAIS3Windows.Window.WindowsAis3();
                    if (ais3.WinexistsAis3() == 1)
                    {
                        clickerButton.Click37(statusButton);
                        DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                    }
                    else
                    {
                        MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            });
        }

        /// <summary>
        /// Загрузка файлов из БД
        /// </summary>
        /// <param name="path">Путь к выгрузке документов</param>
        /// <param name="downloadPrintDb">Модель документов</param>
        public async void DownloadDbFile(string path, DownloadPrintDb downloadPrintDb)
        {
            DispatcherHelper.Initialize();
            await Task.Run(delegate
            {
                var db = new AddObjectDb();
                downloadPrintDb.FileCollection.Clear();
                var listDoc = db.DownloadFileNotPrint();
                DispatcherHelper.CheckBeginInvokeOnUI(delegate { downloadPrintDb.ProgressMaxDownload(listDoc.Count); });
                foreach (var listFile in listDoc)
                {
                    var nameFile = $"{listFile.TypeDocument}-{listFile.IdDelo}-{listFile.Inn}{listFile.Extensions}";
                    var fullPathPdf = Path.Combine(path, nameFile);
                    using (FileStream file = new FileStream(fullPathPdf, FileMode.Create))
                    {
                        for (int i = 0; i < listFile.Document.Length; i++)
                        {
                            file.WriteByte(listFile.Document[i]);
                        }
                        file.Seek(0, SeekOrigin.Begin);
                    }
                    downloadPrintDb.DownloadFileDb(fullPathPdf, nameFile, listFile.Id);
                    DispatcherHelper.CheckBeginInvokeOnUI(delegate { downloadPrintDb.ProgressDownloadFile(nameFile); });
                }
                DispatcherHelper.CheckBeginInvokeOnUI(downloadPrintDb.ProgressDownloadFileDefault);
                DispatcherHelper.CheckBeginInvokeOnUI(delegate { downloadPrintDb.CountFile(downloadPrintDb.FileCollection.Count); });
            });
        }
        /// <summary>
        /// Печать файлов
        /// </summary>
        /// <param name="downloadPrintDb">Модель документов</param>
        public async void PrintFiles(DownloadPrintDb downloadPrintDb)
        {
            DispatcherHelper.Initialize();
            if (downloadPrintDb.IsValidationWork())
            {
                await Task.Run(delegate
                {
                    var db = new AddObjectDb();
                    DispatcherHelper.CheckBeginInvokeOnUI(delegate { downloadPrintDb.ProgressMaxPrint(downloadPrintDb.FileCollection.Count); });
                    foreach(var file in downloadPrintDb.FileCollection)
                    {
                        downloadPrintDb.Print(file.Path, file.Name);
                        db.UpdatePrintDoc(file.IdDoc);
                        DispatcherHelper.CheckBeginInvokeOnUI(delegate { downloadPrintDb.ProgressPrintFile(file.Name); });
                        File.Delete(file.Path);
                    }
                    DispatcherHelper.CheckBeginInvokeOnUI(downloadPrintDb.ProgressPrintFileDefault);
                    downloadPrintDb.FileCollection.Clear();
                    DispatcherHelper.CheckBeginInvokeOnUI(delegate { downloadPrintDb.CountFile(downloadPrintDb.FileCollection.Count); });
                });
            }
        }


    }
}
