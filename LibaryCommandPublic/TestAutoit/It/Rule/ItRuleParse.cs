using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
                  File.Delete(pathjurnalok);
                  DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                  KclicerButton clickerButton = new KclicerButton();
                  LibaryAIS3Windows.Window.WindowsAis3 ais3 = new LibaryAIS3Windows.Window.WindowsAis3();
                  if (ais3.WinexistsAis3() == 1)
                  {
                    clickerButton.Click15(statusButton,pathjurnalok, dataPickerSettings);
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
}
