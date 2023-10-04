using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GalaSoft.MvvmLight.Threading;
using LibraryAIS3Windows.ButtonsClikcs;
using LibraryAIS3Windows.Window;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace LibraryCommandPublic.TestAutoit.RaschBydj.Krsb
{
   public class StartKrsb
    {
        /// <summary>
        /// Закрытие КРСБ по списку
        /// </summary>
        /// <param name="statusButton">Кнопка старт автомат</param>
        public void ClosedKrsb(StatusButtonMethod statusButton)
        {
            DispatcherHelper.Initialize();
            Task.Run(delegate
                {
                    DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                    KclicerButton clickerButton = new KclicerButton();
                    WindowsAis3 ais3 = new WindowsAis3();
                    if (ais3.WinexistsAis3() == 1)
                    {
                        clickerButton.Click42(statusButton);
                        DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusYellow);
                    }
                    else
                    {
                        MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                        DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusGrin);
                    }
                });
        }

        /// <summary>
        /// Автомат на ветку Налоговое администрирование\Расчеты с бюджетом\Журнал неналоговых доходов\Раздел II. Доходы, начисления по которым отсутствуют в базе данных налоговых органов
        /// </summary>
        /// <param name="statusButton">Кнопка старт</param>
        /// <param name="pathListStatement">Полный путь к списку с начислениями</param>
        public void IncomeJournalStart(StatusButtonMethod statusButton, string pathListStatement)
        {
            DispatcherHelper.Initialize();
            if (File.Exists(pathListStatement))
            {
                Task.Run(delegate
                {
                    try
                    {
                        DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                        KclicerButton clickerButton = new KclicerButton();
                        WindowsAis3 ais3 = new WindowsAis3();
                        if (ais3.WinexistsAis3() == 1)
                        {
                            clickerButton.Click56(statusButton, pathListStatement);
                            DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                        }
                        else
                        {
                            MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                });
            }
        }

    }
}
