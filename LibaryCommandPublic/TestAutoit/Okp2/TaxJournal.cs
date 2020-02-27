using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Threading;
using LibaryAIS3Windows.ButtonsClikcs;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace LibaryCommandPublic.TestAutoit.Okp2
{
   public class TaxJournal
    {
        /// <summary>
        /// Автоматизация ветки Налоговое администрирование\Контрольная работа (налоговые проверки)\
        /// 129. Налоговые правонарушения\
        /// 2. Журнал налоговых правонарушений
        /// </summary>
        /// <param name="statusButton">Кнопка запустить задание</param>
        public void StartTaxJournal(StatusButtonMethod statusButton, string pathJournalOk, string pathPdfTemp,int countDay)
        {
            DispatcherHelper.Initialize();
            Task.Run(delegate
            {
                try
                {
                    DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                    KclicerButton clickerButton = new KclicerButton();
                    LibaryAIS3Windows.Window.WindowsAis3 ais3 = new LibaryAIS3Windows.Window.WindowsAis3();
                    if (ais3.WinexistsAis3() == 1)
                    {
                        while (statusButton.Iswork)
                        {
                            clickerButton.Click27(statusButton,pathJournalOk,pathPdfTemp, countDay);
                            DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                        }
                    }
                    else
                    {
                        MessageBox.Show(LibaryAIS3Windows.Status.StatusAis.Status1);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            });

        }
    }
}
