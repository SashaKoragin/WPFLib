﻿using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Threading;
using LibraryAIS3Windows.ButtonsClikcs;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace LibraryCommandPublic.TestAutoit.Okp3.UsnSend
{
   public class CommandUsn
    {
        /// <summary>
        /// Запуск пользовательского задания 
        /// </summary>
        /// <param name="statusButton">Кнопка</param>
        /// <param name="pathJournalError">Путь к журналу к ошибкам</param>
        /// <param name="pathJournalOk">Путь к журналу готовых</param>
        public void UsnStart(StatusButtonMethod statusButton, string pathJournalError, string pathJournalOk)
        {
            DispatcherHelper.Initialize();
            Task.Run(delegate
            {
                DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                KclicerButton clickerButton = new KclicerButton();
                LibraryAIS3Windows.Window.WindowsAis3 ais3 = new LibraryAIS3Windows.Window.WindowsAis3();
                if (ais3.WinexistsAis3() == 1)
                {
                    while (statusButton.Iswork)
                    {
                        var status = clickerButton.Click14(statusButton.IsChekcs, pathJournalError, pathJournalOk);
                        if (status.Equals(LibraryAIS3Windows.Status.StatusAis.Status6))
                        {
                            DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                        }
                    }
                }
                else
                {
                    MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                }
            });
        }
    }
}
