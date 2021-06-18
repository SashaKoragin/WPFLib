using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GalaSoft.MvvmLight.Threading;
using LibraryAIS3Windows.ButtonsClikcs;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using ViewModelLib.ModelTestAutoit.PublicModel.DataPickerItRule;

namespace LibraryCommandPublic.TestAutoit.It.Rule
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
            if (dataPickerSettings.IsValidationFull())
            {
               DispatcherHelper.Initialize();
              Task.Run(delegate
               {
                  File.Delete(pathjurnalok);
                  DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                  KclicerButton clickerButton = new KclicerButton();
                  LibraryAIS3Windows.Window.WindowsAis3 ais3 = new LibraryAIS3Windows.Window.WindowsAis3();
                  if (ais3.WinexistsAis3() == 1)
                  {
                    clickerButton.Click15(statusButton,pathjurnalok, dataPickerSettings);
                    DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                  }
                  else
                  {
                      MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                  }
               });
            }
        }
        /// <summary>
        /// Сбор информации ветках ролях и папках
        /// </summary>
        /// <param name="statusButton">Кнопка статуса</param>
        /// <param name="pathJournalInfoRule">Путь к файлу сохранения с ролями и шаблонами</param>
        public void RuleInfoTemplate(StatusButtonMethod statusButton, string pathJournalInfoRule)
        {

                DispatcherHelper.Initialize();
                Task.Run(delegate
                {
                    DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                    KclicerButton clickerButton = new KclicerButton();
                    LibraryAIS3Windows.Window.WindowsAis3 ais3 = new LibraryAIS3Windows.Window.WindowsAis3();
                    if (ais3.WinexistsAis3() == 1)
                    {
                        if (statusButton.IsChekcs)
                        {
                            if (File.Exists(pathJournalInfoRule))
                            {
                                File.Delete(pathJournalInfoRule);
                            }
                        }
                        clickerButton.Click36(statusButton, pathJournalInfoRule);
                        DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                    }
                    else
                    {
                        MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                    }
                });
        }
        /// <summary>
        /// Сбор информации о пользователях и шаблонах с ролями которые у них открыты
        /// </summary>
        /// <param name="statusButton">Кнопка статуса</param>
        /// <param name="pathJournalInfoUserTemplateRule">Путь к файлу сохранения с пользователями и шаблонами ролей</param>
        public void UserTemplateRule(StatusButtonMethod statusButton, string pathJournalInfoUserTemplateRule)
        {
            DispatcherHelper.Initialize();
            Task.Run(delegate
            {
                DispatcherHelper.CheckBeginInvokeOnUI(statusButton.StatusRed);
                KclicerButton clickerButton = new KclicerButton();
                LibraryAIS3Windows.Window.WindowsAis3 ais3 = new LibraryAIS3Windows.Window.WindowsAis3();
                if (ais3.WinexistsAis3() == 1)
                {
                    if (statusButton.IsChekcs)
                    {
                        if (File.Exists(pathJournalInfoUserTemplateRule))
                        {
                            File.Delete(pathJournalInfoUserTemplateRule);
                        }
                    }
                    clickerButton.Click38(statusButton, pathJournalInfoUserTemplateRule);
                    DispatcherHelper.UIDispatcher.Invoke(statusButton.StatusYellow);
                }
                else
                {
                    MessageBox.Show(LibraryAIS3Windows.Status.StatusAis.Status1);
                }
            });
        }
    }
}
