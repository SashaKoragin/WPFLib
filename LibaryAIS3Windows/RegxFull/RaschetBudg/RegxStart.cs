using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Automation;
using EfDatabaseAutomation.Automation.Base;
using EfDatabaseAutomation.Automation.BaseLogica.SqlSelect.SelectAll;
using LibraryAIS3Windows.AutomationsUI.LibaryAutomations;
using LibraryAIS3Windows.AutomationsUI.Otdels.RaschetBud;
using LibraryAIS3Windows.ButtonFullFunction.PublicGlobalFunction;

namespace LibraryAIS3Windows.RegxFull.RaschetBudg
{
   public class RegxStart
   {
        /// <summary>
        /// Поиск плательщика для отправки уведомления
        /// </summary>
        /// <param name="libraryAutomation">Библиотека автоматизации</param>
        /// <param name="inn">ИНН</param>
        /// <returns></returns>
        public string FindNpIsNull(LibraryAutomations libraryAutomation,string inn)
        {
            PublicGlobalFunction.WindowElementClick(libraryAutomation, RashetBudElementName.ButtonUvedNp);
             while (true)
             {
                if (libraryAutomation.IsEnableElements(RashetBudElementName.WinSelect, null, true) != null)
                {
                    break;
                }
             }
             PublicGlobalFunction.WindowElementClick(libraryAutomation, RashetBudElementName.WinFind);
            if (libraryAutomation.IsEnableElements(RashetBudElementName.ErrorWin, null, true,5) != null)
            {
                PublicGlobalFunction.WindowElementClick(libraryAutomation, RashetBudElementName.ErrorWin);
                PublicGlobalFunction.WindowElementClick(libraryAutomation, RashetBudElementName.CloseButton);
                return "Отсутствует ИНН отправка и уточнение не возможно";
            }
            libraryAutomation.IsEnableElement(RashetBudElementName.SelectGrid);
            var listElement = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindElement).Cast<AutomationElement>().Where(elem => elem.Current.Name.Contains("List`")).ToList();
            if (!listElement.Any())
            {
                libraryAutomation.IsEnableElement(RashetBudElementName.KppMemo);
                libraryAutomation.SetValuePattern("");
                PublicGlobalFunction.WindowElementClick(libraryAutomation, RashetBudElementName.WinFind);
                libraryAutomation.IsEnableElement(RashetBudElementName.SelectGrid);
                listElement = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindElement).Cast<AutomationElement>().Where(elem => elem.Current.Name.Contains("List`")).ToList();
                if (inn.Length == 12)
                {
                    FindIp(libraryAutomation, listElement);
                }
                else
                {
                    FindUl(libraryAutomation, listElement);
                }
                PublicGlobalFunction.WindowElementClick(libraryAutomation, RashetBudElementName.SelectButton);
                PublicGlobalFunction.WindowElementClick(libraryAutomation, RashetBudElementName.FormWin);
                PublicGlobalFunction.WindowElementClick(libraryAutomation, RashetBudElementName.SaveWin);
                PublicGlobalFunction.WindowElementClick(libraryAutomation, RashetBudElementName.Ok);
                PublicGlobalFunction.WindowElementClick(libraryAutomation, RashetBudElementName.Back);
                return "Некорректное КПП плательщика уточнение не возможно";
            }
            if (inn.Length == 12)
            {
                FindIp(libraryAutomation, listElement);
            }
            else
            {
                FindUl(libraryAutomation, listElement);
            }
            PublicGlobalFunction.WindowElementClick(libraryAutomation, RashetBudElementName.SelectButton);
            PublicGlobalFunction.WindowElementClick(libraryAutomation, RashetBudElementName.FormWin);
            PublicGlobalFunction.WindowElementClick(libraryAutomation, RashetBudElementName.SaveWin);
            PublicGlobalFunction.WindowElementClick(libraryAutomation, RashetBudElementName.Ok);
            PublicGlobalFunction.WindowElementClick(libraryAutomation, RashetBudElementName.Back);
            return null;
        }



       /// <summary>
        /// Анализ подстановки налогов 
        /// </summary>
        /// <param name="libraryAutomation">Библиотека автоматизации</param>
        /// <param name="modelKbk">Модель КБК</param>
        /// <returns></returns>
        public bool UseNalog(LibraryAutomations libraryAutomation, ModelKbkOnKbk modelKbk)
        {
            bool isTp = false; //Проверяем логику подстановки ТП
            var kbk = new[] { "18210803010014000110", "18210803010011000110" };
            if (Regex.Matches(modelKbk.Kbk100Before, @"^(100[0-9]+)$").Count > 0)
            {
                isTp = true;
                libraryAutomation.FindFirstElement(RashetBudElementName.SendKbk, null, true);
                libraryAutomation.SetValuePattern(modelKbk.KbkIfns);
            }
            if (kbk.Any(x => kbk.Contains(modelKbk.KbkIfns)))
            {
                modelKbk.KbkIfns = "18210803010011050110";
                libraryAutomation.FindFirstElement(RashetBudElementName.SendKbk, null, true);
                libraryAutomation.SetValuePattern(modelKbk.KbkIfns);
            }
            modelKbk.KbkUtcAfter = modelKbk.KbkIfns;
            return Status(libraryAutomation, modelKbk, isTp);
        }

        /// <summary>
        ///  Функция анализа подстановки
        /// </summary>
        /// <param name="libraryAutomation">Библиотека автоматизации</param>
        /// <param name="modelKbk">Модель КБК</param>
        /// <param name="isTp">Проверка ТП</param>
        /// <returns>Bool есть ли такой КБК в БД для проверки группы</returns>
        private bool Status(LibraryAutomations libraryAutomation, ModelKbkOnKbk modelKbk,bool isTp)
        {
            string status = "01";
            SelectAll select = new SelectAll();
            var payment = select.SelectKbkGroup(modelKbk.KbkIfns);
            if (payment != null)
            {
                switch (payment.IdQbe)
                {
                    case 1:
                        status = "13";
                        SendsStatus(IsSberbank(status, modelKbk), libraryAutomation);
                        break;
                    case 2:
                        SendsTp(isTp, libraryAutomation, modelKbk);
                        break;
                    case 3:
                        if (modelKbk.InnPayer.Length != 12)
                        {
                            SendsStatus(IsSberbank(status, modelKbk), libraryAutomation);
                            SendsTp(isTp, libraryAutomation, modelKbk);
                        }
                        else
                        {
                            status = "09";
                            SendsStatus(IsSberbank(status, modelKbk), libraryAutomation);
                            SendsTp(isTp, libraryAutomation, modelKbk);
                        }
                        break;
                    case 4:
                        status = "02";
                        SendsStatus(IsSberbank(status, modelKbk), libraryAutomation);
                        SendsTp(isTp, libraryAutomation, modelKbk);
                        break;
                }
                modelKbk.StatusPayerUtcAfter = status;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Функция проверки Сбербанка
        /// </summary>
        /// <param name="status">Статус</param>
        /// <param name="modelKbk">Модель КБК</param>
        /// <returns></returns>
        private string IsSberbank(string status, ModelKbkOnKbk modelKbk)
        {
            if (modelKbk.InnBank == "7707083893" && modelKbk.KppBank == "526002001")
            {
                status = "15";
            }
            return status;
        }
        /// <summary>
        /// Функция подстановки статуса
        /// </summary>
        /// <param name="status">Статус платежа</param>
        /// <param name="libraryAutomation">Библиотека автоматизации</param>
        private void SendsStatus(string status, LibraryAutomations libraryAutomation)
        {
           libraryAutomation.FindFirstElement(RashetBudElementName.SendStatus, null, true);
           libraryAutomation.SetValuePattern(status);
        }

        /// <summary>
        /// Постановка ТП в поле
        /// </summary>
        /// <param name="isTp">Проверка надо ли проставлять ТП после проверки на 100</param>
        /// <param name="libraryAutomation">Библиотека автоматизации</param>
        /// <param name="modelKbk">Модель КБК</param>
        private void SendsTp(bool isTp, LibraryAutomations libraryAutomation, ModelKbkOnKbk modelKbk)
        {
           if (isTp)
           {
                string tp = "ТП";
                libraryAutomation.FindFirstElement(RashetBudElementName.SendTp, null, true);
                libraryAutomation.SetValuePattern(tp);
                modelKbk.TpPayerUtcAfter = tp;
           }
        }

        /// <summary>
        /// Поиск ЮЛ по месту нахождения
        /// </summary>
        /// <param name="libraryAutomation">Библиотека автоматизации</param>
        /// <param name="listIsFirstUl">Список лиц</param>
        private void FindUl(LibraryAutomations libraryAutomation, List<AutomationElement> listIsFirstUl)
        {
            var findNp = listIsFirstUl.FirstOrDefault(elem => libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.SelectAutomationColrction(elem).Cast<AutomationElement>()
                                               .First(element => element.Current.Name.Contains("Тип объекта учёта"))) == "ЮЛ по МН");
            if (findNp != null)
            {
                findNp.SetFocus();
            }
        }

        /// <summary>
        /// Поиск ИП по месту регистрации
        /// </summary>
        /// <param name="libraryAutomation">Библиотека автоматизации</param>
        /// <param name="listIsFirstIp">Список лиц</param>
        private void FindIp(LibraryAutomations libraryAutomation, List<AutomationElement> listIsFirstIp)
        {
            var findNp = listIsFirstIp.FirstOrDefault(elem => libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.SelectAutomationColrction(elem).Cast<AutomationElement>()
                                               .First(element => element.Current.Name.Contains("Тип объекта учёта"))) == "ФЛ по месту жительства" && libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.SelectAutomationColrction(elem).Cast<AutomationElement>()
                                               .First(element => element.Current.Name.Contains("Дата снятия с учёта"))) == "");
            if (findNp != null)
            {
                findNp.SetFocus();
            }
        }
    }
}
