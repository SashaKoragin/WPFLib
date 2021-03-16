using System.Linq;
using System.Text.RegularExpressions;
using EfDatabaseAutomation.Automation.Base;
using EfDatabaseAutomation.Automation.BaseLogica.SqlSelect.SelectAll;
using LibraryAIS3Windows.AutomationsUI.LibaryAutomations;
using LibraryAIS3Windows.AutomationsUI.Otdels.RaschetBud;

namespace LibraryAIS3Windows.RegxFull.RaschetBudg
{
   public class RegxStart
   {
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
    }
}
