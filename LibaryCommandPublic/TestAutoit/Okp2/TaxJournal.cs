﻿using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using AisPoco.Ifns51.ToAis;
using EfDatabaseAutomation.Automation.BaseLogica.AddObjectDb;
using GalaSoft.MvvmLight.Threading;
using LibraryAIS3Windows.ButtonsClikcs;
using ViewModelLib.ModelTestAutoit.ModelFormirovanie.DonloadPrintDb;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using ViewModelLib.ModelTestAutoit.PublicModel.ModelDatePickerAdd;
using ViewModelLib.ModelTestAutoit.PublicModel.PublicModelCollectionSelect;

namespace LibraryCommandPublic.TestAutoit.Okp2
{
   public class TaxJournal
    {
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
