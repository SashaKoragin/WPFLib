using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Threading;
using LibaryAIS3Windows.ButtonsClikcs;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace LibaryCommandPublic.TestAutoit.Uregulirovanie.UtverzdenieSz
{
   public class AutoStart
    {

        public void UtberzdenieSz(StatusButtonMethod statusButton, string pathjurnalerror, string pathjurnalok)
        {
            //DispatcherHelper.Initialize();
            //Task.Run(delegate
            //{
            //    DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
            //    KclicerButton clickerButton = new KclicerButton();
            //    LibaryAIS3Windows.Window.WindowsAis3 ais3 = new LibaryAIS3Windows.Window.WindowsAis3();
            //    if (ais3.WinexistsAis3() == 1)
            //    {
                    MessageBox.Show("В разработке");
                    //while (statusButton.Iswork)
                    //{
                    // var strexit = clickerButton.Click15(pathjurnalerror, pathjurnalok);
                    //  if (strexit.Equals(LibaryAIS3Windows.Status.StatusAis.Status6))
                    //  {
                    //    DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                    //  }
                    //}

            //    }
            //    else
            //    {
            //        MessageBox.Show(LibaryAIS3Windows.Status.StatusAis.Status1);
            //    }
            //});
        }
    }
}
