using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Threading;
using LibraryAIS3Windows.ButtonsClikcs;
using LibraryAIS3Windows.ExitLogica;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace LibraryCommandPublic.TestAutoit.Reg.YtochnenieSved.AutoCommand
{
   public class YtochnenieSved
    {
        /// <summary>
        /// Команда отработки пользовательского задания Регистрациии 
        /// </summary>
        /// <param name="statusButton">Модель кнопки </param>
        /// <param name="pathjurnalerror">Журнал ошибок</param>
        /// <param name="pathjurnalok">Журнал ОК</param>
        public void Ytochnenie(StatusButtonMethod statusButton, string pathjurnalerror, string pathjurnalok)
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
                        clickerButton.Click2(pathjurnalerror, pathjurnalok,statusButton.IsChekcs);
                    }

                    DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusYellow);
                }
                else
                {
                    MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                }
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statusButton">Кнопка</param>
        /// <param name="pathjurnalok">Путь к завершенным</param>
        public void JurnalReceivedDocument(StatusButtonMethod statusButton, string pathjurnalok)
        {
            DispatcherHelper.Initialize();
            Task.Run(delegate
            {
                DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                KclicerButton clickerButton = new KclicerButton();
                LibraryAIS3Windows.Window.WindowsAis3 ais3 = new LibraryAIS3Windows.Window.WindowsAis3();
                if (ais3.WinexistsAis3() == 1)
                {
                    clickerButton.Click18(statusButton,pathjurnalok);
                    DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusYellow);
                }
                else
                {
                    MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                }
            });
        }

    }
}
