using System.Threading.Tasks;
using System.Windows.Forms;
using GalaSoft.MvvmLight.Threading;
using LibaryAIS3Windows.ButtonsClikcs;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using ViewModelLib.ModelTestAutoit.PublicModel.RaschetBuh;

namespace LibaryCommandPublic.TestAutoit.RaschBydj.Vedomost1
{
   public class StartVedomost1
    {
        /// <summary>
        /// Запуск анализа платежек 
        /// </summary>
        /// <param name="statusButton">Кнопка запуска процесса</param>
        /// <param name="uslovie">Условие запуска</param>
        /// <param name="pathjurnalerror">Путь к ошибке</param>
        /// <param name="pathjurnalok">Путь к журналу с отработанными</param>
        public void AutoClicsVed1(StatusButtonMethod statusButton, SelectVibor uslovie, string pathjurnalerror, string pathjurnalok)
        {
           DispatcherHelper.Initialize();
            if (uslovie.IsValidation())
            {
                Task.Run(delegate
                {
                    LibaryAIS3Windows.Window.WindowsAis3 ais3 = new LibaryAIS3Windows.Window.WindowsAis3();
                    if (ais3.WinexistsAis3() == 1)
                    {

                        DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                        KclicerButton clickerButton = new KclicerButton();
                        ais3.StartNavigate();
                        while (statusButton.Iswork)
                        {
                          var isnull =  clickerButton.Click10(pathjurnalerror, pathjurnalok, uslovie.Sel.Num);
                            if (isnull)
                            {
                                DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusYellow);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(LibaryAIS3Windows.Status.StatusAis.Status1);
                        DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusGrin);
                    }
                });
            }
        }
    }
}
