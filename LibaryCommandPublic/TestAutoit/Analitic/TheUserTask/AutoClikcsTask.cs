using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Threading;
using LibaryAIS3Windows.ButtonsClikcs;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace LibaryCommandPublic.TestAutoit.Analitic.TheUserTask
{
   public class AutoClikcsTask
    {
        /// <summary>
        /// Автоматизация подписания Зачета возврата Аналитическим отделом
        /// </summary>
        /// <param name="statusButton">Кнопка которая меняет статус</param>
        public void SigZacetVozvrat(StatusButtonMethod statusButton)
        {
            DispatcherHelper.Initialize();
            Task.Run(delegate
            {
                DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                KclicerButton clickerButton = new KclicerButton();
                LibaryAIS3Windows.Window.WindowsAis3 ais3 = new LibaryAIS3Windows.Window.WindowsAis3();
                if (ais3.WinexistsAis3() == 1)
                {
                    while (statusButton.Iswork)
                    {
                     string status = clickerButton.Click6();

                       if (status.Equals(LibaryAIS3Windows.Status.StatusAis.Status6))
                        {
                            DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                        }
                    }
                }
                else
                {
                    MessageBox.Show(LibaryAIS3Windows.Status.StatusAis.Status1);
                }
            });
        }
        public void SigZacetVozvratNo()
        {

        }
    }
}
