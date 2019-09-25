using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GalaSoft.MvvmLight.Threading;
using LibaryAIS3Windows.ButtonsClikcs;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using ViewModelLib.ModelTestAutoit.PublicModel.DataPickerItRule;

namespace LibaryCommandPublic.TestAutoit.It.Rule
{
   public class ItRuleParse
    {
        public void RuleUsers(StatusButtonMethod statusButton, DataPickerRuleItModel DataPickerSettings, string pathjurnalerror, string pathjurnalok)
        {
            if (DataPickerSettings.IsValidation())
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
                         clickerButton.Click18(pathjurnalerror, pathjurnalok);

                        //if (strexit.Equals(LibaryAIS3Windows.Status.StatusAis.Status6))
                        //{
                        //    DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                        //}
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
}
