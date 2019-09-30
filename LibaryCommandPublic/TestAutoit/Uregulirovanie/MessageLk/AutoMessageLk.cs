using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Threading;
using LibaryAIS3Windows.ButtonsClikcs;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace LibaryCommandPublic.TestAutoit.Uregulirovanie.MessageLk
{
  public class AutoMessageLk
    {
        /// <summary>
        /// Обработка сообщений ЛК2
        /// </summary>
        /// <param name="statusButton">Кнопка старт </param>
        /// <param name="pathjurnalerror">Журнал ошибок</param>
        /// <param name="pathjurnalok">Журнал хороших (обработанных)</param>
        public void MessageLk(StatusButtonMethod statusButton, string pathjurnalerror, string pathjurnalok)
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
                        var strexit = clickerButton.Click16(pathjurnalerror, pathjurnalok);
                        
                        if (strexit.Equals(LibaryAIS3Windows.Status.StatusAis.Status6))
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

        public void FormTrebUplNaloga(StatusButtonMethod statusButton, string pathjurnalerror, string pathjurnalok){
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
                        var strexit = clickerButton.Click17();

                        if (strexit.Equals(LibaryAIS3Windows.Status.StatusAis.Status6))
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

    }
}
