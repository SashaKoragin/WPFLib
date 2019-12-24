
using System.Threading.Tasks;
using System.Windows.Forms;
using GalaSoft.MvvmLight.Threading;
using LibaryAIS3Windows.ButtonsClikcs;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace LibaryCommandPublic.TestAutoit.Uregulirovanie.DebtRelief
{
   public class DeptRelief
    {
        /// <summary>
        /// Подписание решения 05.08.10.01.0X.02 Подписание решения.
        /// </summary>
        /// <param name="statusButton">Кнопка </param>
        /// <param name="pathjurnalok">Путь к журналу отработанных записей</param>
        public void SendeReshenia(StatusButtonMethod statusButton, string pathjurnalok)
        {
                DispatcherHelper.Initialize();
                Task.Run(delegate
                {
                    DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                    KclicerButton clickerButton = new KclicerButton();
                    LibaryAIS3Windows.Window.WindowsAis3 ais3 = new LibaryAIS3Windows.Window.WindowsAis3();
                    if (ais3.WinexistsAis3() == 1)
                    {
                        clickerButton.Click19(pathjurnalok, statusButton);
                        DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                    }
                    else
                    {
                        MessageBox.Show(LibaryAIS3Windows.Status.StatusAis.Status1);
                    }
                });
        }
        /// <summary>
        /// Подписание справки 05.08.10.01.0X.02 Подписание справок.
        /// </summary>
        /// <param name="statusButton">Кнопка </param>
        /// <param name="pathjurnalok">Путь к журналу отработанных записей</param>
        public void SenderSpravk(StatusButtonMethod statusButton, string pathjurnalok)
        {
            DispatcherHelper.Initialize();
            Task.Run(delegate
            {
                DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                KclicerButton clickerButton = new KclicerButton();
                LibaryAIS3Windows.Window.WindowsAis3 ais3 = new LibaryAIS3Windows.Window.WindowsAis3();
                if (ais3.WinexistsAis3() == 1)
                {
                    clickerButton.Click20(pathjurnalok, statusButton);
                    DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                }
                else
                {
                    MessageBox.Show(LibaryAIS3Windows.Status.StatusAis.Status1);
                }
            });
        }
    }
}
