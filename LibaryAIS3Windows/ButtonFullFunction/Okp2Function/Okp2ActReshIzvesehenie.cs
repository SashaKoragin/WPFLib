using System;
using System.Linq;
using System.Windows.Automation;
using AutoIt;
using EfDatabaseAutomation.Automation.Base;
using EfDatabaseAutomation.Automation.BaseLogica.AddObjectDb;
using LibraryAIS3Windows.AutomationsUI.LibaryAutomations;
using LibraryAIS3Windows.AutomationsUI.Otdels.PublicJournal129And121;
using LibraryAIS3Windows.ButtonsClikcs;
using LibraryAIS3Windows.Window;
using ViewModelLib.ModelTestAutoit.PublicModel.ModelDatePickerAdd;

namespace LibraryAIS3Windows.ButtonFullFunction.Okp2Function
{
    /// <summary>
    /// Класс выставления Актов Решений Извещений по 119 статье
    /// </summary>
   public class Okp2ActAndSolutionAndNotification
    {
        /// <summary>
        /// Путь Сохранения Документа как правило Temp Пользователя
        /// По формам КНД 1151085 и КНД 1151006
        /// </summary>
        private string PathTempSave { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pathTemp">Путь Сохранения Документа как правило Temp Пользователя</param>
        public Okp2ActAndSolutionAndNotification(string pathTemp)
        {
            PathTempSave = pathTemp;
        }

        /// <summary>
        /// Метод создания Актов Решений Извещений по КНД 1151085
        /// </summary>
        /// <param name="libraryAutomation">Библиотека Автомата</param>
        /// <param name="listDocMemo">Лист Документов Акты Решения Извещения </param>
        /// <param name="journal">Журнал</param>
        /// <param name="datePicker">Дата вызова плательщика</param>
        /// <param name="senderSelect">Подписант документа</param>
        public void CreateForm1151085(LibraryAutomations libraryAutomation, AutomationElement[] listDocMemo, TaxJournal121 journal, DatePickerAdd datePicker, string senderSelect)
        {
            LibraryAutomations libraryAutomationDoc = new LibraryAutomations(WindowsAis3.AisNalog3);
            if (!listDocMemo.Any())
            {
                journal.ColorDoc = null;
                //Открыть или начать Проверку
                IsStartIsOpenKm(libraryAutomation, journal);
                while (true)
                {
                    if (libraryAutomation.IsEnableElements(Journal129AndJournal121.ClosedKnp, null, false, 10) != null)
                    {
                        libraryAutomation.ClickElements(Journal129AndJournal121.ClosedKnp, null, true);
                        AutoItX.WinWait(Journal129AndJournal121.EditWindows);
                        AutoItX.WinActivate(Journal129AndJournal121.EditWindows);
                        LibraryAutomations libraryAutomationSign = new LibraryAutomations(Journal129AndJournal121.EditWindows);
                        while (true)
                        {
                            if (libraryAutomationSign.IsEnableElements(Journal129AndJournal121.DateFinish, null, true) != null)
                            {
                                libraryAutomationSign.FindFirstElement(Journal129AndJournal121.DateFinish);
                                libraryAutomationSign.SelectItemCombobox(libraryAutomationSign.IsEnableElements(Journal129AndJournal121.ComboBoxError), "Выявлены нарушения");
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomationSign, Journal129AndJournal121.OkEdit);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomationSign, Journal129AndJournal121.WarningOk);
                                AutoItX.Sleep(1000);
                                break;
                            }
                        }
                        break;
                    }
                }
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.AktNo);
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Established);
                libraryAutomation.FindFirstElement(Journal129AndJournal121.EstablishedNote);
                //Проверка КНД Выставляем шаблон
                libraryAutomation.SetValuePattern(string.Format(Journal129AndJournal121.Template1151085, journal.Period, journal.God, journal.DateFinishDeclaration.ToString("dd.MM.yyyy"), journal.DateStartDeclaration.ToString("dd.MM.yyyy")));
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SaveAktNo);
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SignAktNo);
                SaveSendDoc(libraryAutomation, journal, "Акт успешно выставлен!!!", "Акт");
                MouseCloseForm();
            }
            else
            {
                var isAct = listDocMemo.FirstOrDefault(doc =>
                         libraryAutomationDoc.ParseElementLegacyIAccessiblePatternIdentifiers(
                            libraryAutomationDoc.SelectAutomationColrction(doc).Cast<AutomationElement>()
                                         .First(elem => elem.Current.Name.Contains("КНД"))) == "1160098");
                //Извещения если null то выставляем если 1 то 2
                var isNotification = listDocMemo.Where(doc =>
                                  libraryAutomationDoc.ParseElementLegacyIAccessiblePatternIdentifiers(
                                    libraryAutomationDoc.SelectAutomationColrction(doc).Cast<AutomationElement>()
                               .First(elem => elem.Current.Name.Contains("КНД"))) == "1160099");

                if ((isAct != null && isNotification == null) || (isNotification.Count() < datePicker.CountIzveshenie))
                {
                    var documentStatus = libraryAutomationDoc.SelectAutomationColrction(isAct).Cast<AutomationElement>().Where(automationElemenst => automationElemenst.Current.Name == "").ToList();
                    journal.ColorDoc = libraryAutomationDoc.GetColorPixel(documentStatus[0]);

                    if (journal.ColorDoc == "ffff00" || journal.ColorDoc == "8000")
                    {
                        //Выставляем извещение
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.OpenKnp);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.IzveshenieActNo);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ButtonSved);
                        while (true)
                        {
                            if (libraryAutomation.IsEnableElements(Journal129AndJournal121.NumKabinet, null, true) != null)
                            {
                                libraryAutomation.FindFirstElement(Journal129AndJournal121.NumKabinet);
                                libraryAutomation.SetValuePattern("366.2");
                                libraryAutomation.ClickElements(Journal129AndJournal121.AddButton);
                                AutoItX.WinWait(Journal129AndJournal121.DateTime);
                                AutoItX.WinActivate(Journal129AndJournal121.DateTime);
                                while (true)
                                {
                                    if (libraryAutomation.IsEnableElements(Journal129AndJournal121.WindowDateTime, null, true) != null)
                                    {
                                        journal.DateIzveshenie = datePicker.Date;
                                        libraryAutomation.SetValuePattern(datePicker.Date.ToString("dd.MM.yy"));
                                        libraryAutomation.FindFirstElement(Journal129AndJournal121.WindowHours);
                                        libraryAutomation.SetValuePattern("10");
                                        libraryAutomation.FindFirstElement(Journal129AndJournal121.WindowsOk);
                                        libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                        while (true)
                        {
                            if (libraryAutomation.IsEnableElements(Journal129AndJournal121.FaceName, null, true) != null)
                            {
                                libraryAutomation.ClickElements(Journal129AndJournal121.FaceName, null, true);
                                libraryAutomation.SelectItemCombobox(libraryAutomation.IsEnableElements(Journal129AndJournal121.FaceNameSign), senderSelect, 0);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Save);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SignAll);
                                break;
                            }
                        }
                        //Документ сохранить
                        SaveSendDoc(libraryAutomation, journal, "Извещение успешно выставлено!!!", "Извещение");
                        MouseCloseForm();
                    }
                }
                else
                {
                    var isGrinAll = isNotification.Any(x => libraryAutomationDoc.GetColorPixel(libraryAutomationDoc.SelectAutomationColrction(x).Cast<AutomationElement>().Where(automationElemenst => automationElemenst.Current.Name == "").ToList()[1]) != "8000");
                    var colorAct = libraryAutomationDoc.GetColorPixel(libraryAutomationDoc.SelectAutomationColrction(isAct).Cast<AutomationElement>().Where(automationElement => automationElement.Current.Name == "").ToList()[1]);
                    ////Если блок синий и акт и извещение зеленые
                    if (journal.GlobalColor == "ff" && colorAct == "8000" && !isGrinAll)
                    {
                        journal.ColorDoc = colorAct;
                        //Выставляем Решение
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.OpenKnp);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ReshNo);
                        while (true)
                        {
                            if (libraryAutomation.IsEnableElements(Journal129AndJournal121.FaceNameGr14, null, true) != null)
                            {
                                libraryAutomation.ClickElements(Journal129AndJournal121.FaceNameGr14, null, true);
                                libraryAutomation.SelectItemCombobox(libraryAutomation.IsEnableElements(Journal129AndJournal121.FaceNameSignGr14), senderSelect, 0);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Save);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SignAll);
                                break;
                            }
                        }
                        //Документ сохранить
                        SaveSendDoc(libraryAutomation, journal, "Решение успешно выставлено!!!", "Решение");
                        WindowsAis3 win = new WindowsAis3();
                        AutoItX.Sleep(1000);
                        AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ClosedComplex121);
                    }
                }
            }
        }
        /// <summary>
        /// Метод создания Актов Решений Извещений по КНД 1151006
        /// </summary>
        /// <param name="libraryAutomation">Библиотека Автомата</param>
        /// <param name="listDocMemo">Лист Документов Акты Решения Извещения </param>
        /// <param name="journal">Журнал</param>
        /// <param name="datePicker">Дата вызова плательщика</param>
        /// <param name="senderSelect">Подписант документа</param>
        public void CreateForm1151006(LibraryAutomations libraryAutomation, AutomationElement[] listDocMemo, TaxJournal121 journal, DatePickerAdd datePicker,string senderSelect)
        {
            LibraryAutomations libraryAutomationDoc = new LibraryAutomations(WindowsAis3.AisNalog3);
            if (!listDocMemo.Any())
            {
                journal.ColorDoc = null;
                //Открыть или начать Проверку
                IsStartIsOpenKm(libraryAutomation, journal);
                while (true)
                {
                    if (libraryAutomation.IsEnableElements(Journal129AndJournal121.ClosedKnp, null, false, 10) != null)
                    {
                        libraryAutomation.ClickElements(Journal129AndJournal121.ClosedKnp, null, true);
                        AutoItX.WinWait(Journal129AndJournal121.EditWindows);
                        AutoItX.WinActivate(Journal129AndJournal121.EditWindows);
                        LibraryAutomations libraryAutomationSign = new LibraryAutomations(Journal129AndJournal121.EditWindows);
                        while (true)
                        {
                            if (libraryAutomationSign.IsEnableElements(Journal129AndJournal121.DateFinish, null, true) != null)
                            {
                                libraryAutomationSign.FindFirstElement(Journal129AndJournal121.DateFinish);
                                libraryAutomationSign.DateControlComboboxNotValue(journal.DateFinishCheck);
                                libraryAutomationSign.SelectItemCombobox(libraryAutomationSign.IsEnableElements(Journal129AndJournal121.ComboBoxError), "Выявлены нарушения");
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomationSign, Journal129AndJournal121.OkEdit);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomationSign, Journal129AndJournal121.WarningOk);
                                AutoItX.Sleep(1000);
                                break;
                            }
                        }
                        break;
                    }
                }
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.AktNo);
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.PublicInfo);
                while (true)
                {
                     if (libraryAutomation.IsEnableElements(Journal129AndJournal121.DateReshenia, null, true) != null)
                     {
                        DateTime dateVAdd = journal.DateFinishCheck;
                        dateVAdd = dateVAdd.AddDays(5);
                        if (journal.DateFinishCheck.DayOfWeek == DayOfWeek.Saturday)
                            dateVAdd = journal.DateFinishCheck.AddDays(2);
                        if (journal.DateFinishCheck.DayOfWeek == DayOfWeek.Sunday)
                            dateVAdd = journal.DateFinishCheck.AddDays(1);
                        libraryAutomation.SetValuePattern(dateVAdd.Date.ToString("dd.MM.yy"));
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Established);
                        libraryAutomation.FindFirstElement(Journal129AndJournal121.EstablishedNote);
                        libraryAutomation.SetValuePattern(string.Format(Journal129AndJournal121.Template1151006, journal.Period, journal.God, journal.DateFinishDeclaration.ToString("dd.MM.yyyy"), journal.DateStartDeclaration.ToString("dd.MM.yyyy")));
                        break;
                     }
                }
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SaveAktNo);
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SignAktNo);
                SaveSendDoc(libraryAutomation, journal, "Акт успешно выставлен!!!", "Акт");
                MouseCloseForm();
            }
            else
            {
                var isAct = listDocMemo.FirstOrDefault(doc =>
                                                     libraryAutomationDoc.ParseElementLegacyIAccessiblePatternIdentifiers(
                                                     libraryAutomationDoc.SelectAutomationColrction(doc).Cast<AutomationElement>()
                                                     .First(elem => elem.Current.Name.Contains("КНД"))) == "1160098");
                //Извещения если null то выставляем если 1 то 2
                var isNotification = listDocMemo.Where(doc =>
                                  libraryAutomationDoc.ParseElementLegacyIAccessiblePatternIdentifiers(
                                  libraryAutomationDoc.SelectAutomationColrction(doc).Cast<AutomationElement>()
                                  .First(elem => elem.Current.Name.Contains("КНД"))) == "1160099");

                if ((isAct != null && isNotification == null) || (isNotification.Count() < datePicker.CountIzveshenie))
                {
                    var documentStatus = libraryAutomationDoc.SelectAutomationColrction(isAct).Cast<AutomationElement>().Where(automationElemenst => automationElemenst.Current.Name == "").ToList();
                    journal.ColorDoc = libraryAutomationDoc.GetColorPixel(documentStatus[0]);

                    if (journal.ColorDoc == "ffff00" || journal.ColorDoc == "8000")
                    {
                        //Выставляем извещение
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.OpenKnp);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.IzveshenieActNo);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ButtonSved);
                        while (true)
                        {
                            if (libraryAutomation.IsEnableElements(Journal129AndJournal121.NumKabinet, null, true) != null)
                            {
                                libraryAutomation.FindFirstElement(Journal129AndJournal121.NumKabinet);
                                libraryAutomation.SetValuePattern("366.2");
                                libraryAutomation.ClickElements(Journal129AndJournal121.AddButton);
                                AutoItX.WinWait(Journal129AndJournal121.DateTime);
                                AutoItX.WinActivate(Journal129AndJournal121.DateTime);
                                while (true)
                                {
                                    if (libraryAutomation.IsEnableElements(Journal129AndJournal121.WindowDateTime, null, true) != null)
                                    {
                                        journal.DateIzveshenie = datePicker.Date;
                                        libraryAutomation.SetValuePattern(datePicker.Date.ToString("dd.MM.yy"));
                                        libraryAutomation.FindFirstElement(Journal129AndJournal121.WindowHours);
                                        libraryAutomation.SetValuePattern("10");
                                        libraryAutomation.FindFirstElement(Journal129AndJournal121.WindowsOk);
                                        libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                        while (true)
                        {
                            if (libraryAutomation.IsEnableElements(Journal129AndJournal121.FaceName, null, true) != null)
                            {
                                libraryAutomation.ClickElements(Journal129AndJournal121.FaceName, null, true);
                                libraryAutomation.SelectItemCombobox(libraryAutomation.IsEnableElements(Journal129AndJournal121.FaceNameSign), senderSelect, 0);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Save);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SignAll);
                                break;
                            }
                        }
                        //Документ сохранить
                        SaveSendDoc(libraryAutomation, journal, "Извещение успешно выставлено!!!", "Извещение");
                        MouseCloseForm();
                    }
                }
                else
                {
                    
                    //Выставляем решения если Акт и Извещение не пустые
                }
            }
        }


        /// <summary>
        /// Если признак углубленной проверки не белый то Открыть Комплекс Мероприятий
        /// В противном случае Начать Углубленную Проверку
        /// </summary>
        /// <param name="libraryAutomation">Библиотека Автомата</param>
        /// <param name="journal">Журнал</param>
        private void IsStartIsOpenKm(LibraryAutomations libraryAutomation, TaxJournal121 journal)
        {
            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation,
                journal.GlobalProcessColor == "ffffff"
                    ? Journal129AndJournal121.StartKnp
                    : Journal129AndJournal121.OpenKnp);
        }

        /// <summary>
        /// Отправка и сохранение документа в БД
        /// </summary>
        /// <param name="libraryAutomation">Библиотека Автомата</param>
        /// <param name="journal">Журнал</param>
        /// <param name="messageInfo">Сообщение о документе</param>
        /// <param name="typeDocument">Тип документа</param>
        private void SaveSendDoc(LibraryAutomations libraryAutomation, TaxJournal121 journal,string messageInfo,string typeDocument)
        {
            Okp2GlobalFunction globalFunction = new Okp2GlobalFunction();
            globalFunction.SignAndSendDoc(libraryAutomation);
            journal.IsLk3 = globalFunction.IsLk3;
            journal.IsMail = globalFunction.IsMail;
            journal.IsTks = globalFunction.IsTks;
            journal.MessageInfo = messageInfo;
            journal.TypeDocument = typeDocument;
            globalFunction.AddFile(ref journal, PathTempSave);
            var dbAutomation = new AddObjectDb();
            dbAutomation.AddTaxJournal121(journal);
        }
        /// <summary>
        /// Закрыть подчиненные формы
        /// </summary>
        private void MouseCloseForm()
        {
            WindowsAis3 win = new WindowsAis3();
            AutoItX.Sleep(1000);
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
            AutoItX.Sleep(1000);
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
        }
    }
}
