using System.Threading.Tasks;
using System.Windows.Forms;
using GalaSoft.MvvmLight.Threading;
using LibaryAIS3Windows.ButtonsClikcs;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace LibaryCommandPublic.TestAutoit.RaschBydj.Vedomost1
{
   public class StartVedomost1
    {

        public void AutoClicsVed1(StatusButtonMethod statusButton, string pathjurnalerror, string pathjurnalok)
        {
           DispatcherHelper.Initialize();
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
                        clickerButton.Click10(pathjurnalerror, pathjurnalok);
                    }
                     DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusGrin);
                   
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
