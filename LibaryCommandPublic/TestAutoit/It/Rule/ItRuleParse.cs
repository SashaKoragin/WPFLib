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
        /// <summary>
        /// Парсим роли
        /// </summary>
        /// <param name="statusButton">Кнопка статуса</param>
        /// <param name="dataPickerSettings">Шаблон параметров</param>
        /// <param name="pathjurnalok">Путь к файлу сохранения</param>
        public void RuleUsers(StatusButtonMethod statusButton, DataPickerRuleItModel dataPickerSettings, string pathjurnalok)
        {
            if (dataPickerSettings.IsValidation())
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
                           var result = clickerButton.Click15(pathjurnalok,dataPickerSettings.CountRow,dataPickerSettings.DateStart,dataPickerSettings.DateFinish);
                           if (result.Equals(LibaryAIS3Windows.Status.StatusAis.Status6))
                           {
                               DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                               break;
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
}
