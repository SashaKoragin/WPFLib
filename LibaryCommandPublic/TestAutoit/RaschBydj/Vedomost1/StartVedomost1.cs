using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using GalaSoft.MvvmLight.Threading;
using LibraryAIS3Windows.ButtonsClikcs;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using ViewModelLib.ModelTestAutoit.PublicModel.RaschetBuh;

namespace LibraryCommandPublic.TestAutoit.RaschBydj.Vedomost1
{
   public class StartVedomost1
    {
        /// <summary>
        /// Запуск анализа платежек 
        /// </summary>
        /// <param name="statusButton">Кнопка запуска процесса</param>
        public void AutoClicsVed1(StatusButtonMethod statusButton)
        {
            try
            {
                DispatcherHelper.Initialize();
                Task.Run(delegate
                    {
                        LibraryAIS3Windows.Window.WindowsAis3 ais3 = new LibraryAIS3Windows.Window.WindowsAis3();
                        if (ais3.WinexistsAis3() == 1)
                        {

                            DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                            KclicerButton clickerButton = new KclicerButton();
                            clickerButton.Click10(statusButton);
                            DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusYellow);
                        }
                        else
                        {
                            MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                            DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusGrin);
                        }
                    });
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
}
}
