using System;
using System.Collections.Generic;
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
        /// Минуты
        /// </summary>
        private readonly string[] _minutesList = { "00", "15", "30", "45" };
        /// <summary>
        /// Часы
        /// </summary>
        private readonly string[] _hoursList = { "10", "11", "12", "14", "15", "16" };

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
        /// <param name="dateCloseValidation">Дата окончания проверки</param>
        public void CreateForm1151085(LibraryAutomations libraryAutomation, AutomationElement[] listDocMemo, TaxJournal121 journal, DatePickerAdd datePicker, DepartamentOtdel senderSelect, DateTime? dateCloseValidation)
        {
            LibraryAutomations libraryAutomationDoc = new LibraryAutomations(WindowsAis3.AisNalog3);
            var allMaterial = new List<string>();
            var date = DateTime.Now;
            if (!listDocMemo.Any())
            {
                journal.ColorDoc = null;
                DateTime dateVAdd;
                if (dateCloseValidation == null)
                {
                    dateVAdd = journal.DateFinishCheck;
                    //Открыть или начать Проверку
                    IsStartIsOpenKm(libraryAutomation, journal);
                    while (true)
                    {
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ClosedKnp);
                        AutoItX.Sleep(1000);
                        LibraryAutomations libraryAutomationSign = new LibraryAutomations(TreeWalker.RawViewWalker.GetPreviousSibling(libraryAutomation.RootAutomationElements));
                        while (true)
                        {
                            if (libraryAutomationSign.IsEnableElements(Journal129AndJournal121.NewWindowEnable, null, true, 40, 0, false, ';') != null)
                            {
                                libraryAutomationSign.IsEnableElements(Journal129AndJournal121.NewComboBoxError, null, false, 40, 0, false, ';');
                                libraryAutomationSign.ClickElement(libraryAutomationSign.FindElement);
                                var memo = libraryAutomationSign.SelectAutomationColrction(libraryAutomationSign.FindElement);
                                var elemClick = memo.Cast<AutomationElement>().FirstOrDefault(x => x.Current.Name == "Выявлены нарушения");
                                libraryAutomationSign.ClickElement(elemClick);
                                libraryAutomationSign.InvokePattern(libraryAutomationSign.IsEnableElements(Journal129AndJournal121.NewOkEdit));
                                AutoItX.WinWait(Journal129AndJournal121.NewWarningOk);
                                AutoItX.WinActivate(Journal129AndJournal121.NewWarningOk);
                                libraryAutomationSign = new LibraryAutomations(Journal129AndJournal121.NewWarningOk);
                                libraryAutomationSign.InvokePattern(libraryAutomationSign.IsEnableElements(Journal129AndJournal121.NewWarningButtonOk));
                                AutoItX.Sleep(2000);
                                break;
                            }
                        }
                        break;
                    }
                }
                else
                {
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.OpenKnp);
                    dateVAdd = (DateTime)dateCloseValidation;
                    dateVAdd = dateVAdd.AddDays(5);
                }
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.AktNo);
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Established);
                libraryAutomation.FindFirstElement(Journal129AndJournal121.EstablishedNote);
                //Проверка КНД Выставляем шаблон
                libraryAutomation.SetValuePattern(string.Format(Journal129AndJournal121.AktTemplate1151085, journal.Period, journal.God, journal.DateFinishDeclaration.ToString("dd.MM.yyyy"), journal.DateStartDeclaration.ToString("dd.MM.yyyy")));

                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ErrorFaceGr11);
                if (libraryAutomation.IsEnableElements(Journal129AndJournal121.ListCashFace, null, true) != null)
                {
                    var listCash = libraryAutomation
                        .SelectAutomationColrction(
                            libraryAutomation.FindFirstElement(Journal129AndJournal121.ListCashFace))
                        .Cast<AutomationElement>().Distinct().Where(elem => elem.Current.Name.Contains("Sanctions row")
                        ).ToList();
                    if (listCash.Count > 1 || listCash.Count == 0)
                    {
                        AutomationElement cashDelete;
                        while ((cashDelete = libraryAutomation.IsEnableElements(Journal129AndJournal121.ListCashFaceRowNumber1, null, false, 10)) != null)
                        {
                            while (true)
                            {
                                libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                    .SelectAutomationColrction(cashDelete)
                                    .Cast<AutomationElement>().First(elemr => elemr.Current.Name.Contains("Ун документа НБО")));
                                var elem = libraryAutomation.FindFirstElement("Name:Удалить", cashDelete);
                                libraryAutomation.ClickElement(elem);

                                if (libraryAutomation.IsEnableElements(Journal129AndJournal121.DeleteWin, null, true) != null)
                                {
                                    libraryAutomation.ClickElement(libraryAutomation.IsEnableElements(Journal129AndJournal121.DeleteWin));
                                    break;
                                }
                            }
                        }
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ErrorFaceGr15);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.AddNewErrror);
                        libraryAutomation.IsEnableElements(Journal129AndJournal121.WinSelect1);
                        libraryAutomation.SetValuePattern("11901013");
                        libraryAutomation.IsEnableElements(Journal129AndJournal121.WinSelect2);
                        libraryAutomation.SetValuePattern("11901013");
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.WinSelectOk);
                    }
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ErrorFaceGr15);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.AddNewCircumstance);
                    libraryAutomation.IsEnableElements(Journal129AndJournal121.WinSelectCircumstance1);
                    libraryAutomation.SetValuePattern("отсутствие обстоятельств");
                    libraryAutomation.IsEnableElements(Journal129AndJournal121.WinSelectCircumstance2);
                    libraryAutomation.SetValuePattern("22");
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.WinSelectCircumstanceOk);
                }

                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SaveAktNo);
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Ok);
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SignAktNo);
                SaveSendDoc(libraryAutomation, journal, "Акт успешно выставлен!!!", "Акт");
                while (true)
                {
                    if (libraryAutomation.IsEnableElements(Journal129AndJournal121.ButtonAll, null, true) != null)
                    {
                        break;
                    }
                }
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
                //Решение о продлении срока
                var isReshDate = listDocMemo.Where(doc =>
                    libraryAutomationDoc.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomationDoc.SelectAutomationColrction(doc).Cast<AutomationElement>()
                            .First(elem => elem.Current.Name.Contains("КНД"))) == "1160088");
                //Решение об отложении
                var isReshBeginDate = listDocMemo.Where(doc =>
                    libraryAutomationDoc.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomationDoc.SelectAutomationColrction(doc).Cast<AutomationElement>()
                            .First(elem => elem.Current.Name.Contains("КНД"))) == "1160076");

                var isProtokol = listDocMemo.Where(doc =>
                    libraryAutomationDoc.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomationDoc.SelectAutomationColrction(doc).Cast<AutomationElement>()
                            .First(elem => elem.Current.Name.Contains("КНД"))) == "1165052");

                if ((isAct != null && isNotification == null) || (isNotification.Count() < datePicker.CountIzveshenie))
                {
                    var documentStatus = libraryAutomationDoc.SelectAutomationColrction(isAct).Cast<AutomationElement>().Where(automationElemenst => automationElemenst.Current.Name == "").ToList();
                    journal.ColorDoc = libraryAutomationDoc.GetColorPixel(documentStatus[0]);
                    //Дата документа
                    var createDocument = DateTime.Now;
                    if (journal.ColorDoc == "ffff00" || journal.ColorDoc == "8000")
                    {
                        var modelDecl = SelectJournal(journal.RegNumDeclaration);
                        if (modelDecl != null)
                        {
                            //Извещения
                            if (modelDecl.IsMail != null && (bool)modelDecl.IsMail)
                            {
                                //Если почта то Если почта - 5  рабочих дней на вручение ( со след. дня после даты акта) +6 рабочих дней на отправку + 1 месяц на возражения
                                createDocument = createDocument.AddWorkdays(5);
                                createDocument = createDocument.AddMonths(1);
                                createDocument = createDocument.AddWorkdays(5);
                                //Уходим от выходных
                                createDocument = IsWeekends(createDocument);
                            }
                            else
                            {
                                //В противном случае ТКС Если ТКС -   5  рабочих дней на вручение ( со след. дня после даты акта) + 1 месяц на возражения  
                                createDocument = createDocument.AddWorkdays(5);
                                createDocument = createDocument.AddMonths(1);
                                createDocument = createDocument.AddWorkdays(5);
                                //Уходим от выходных
                                createDocument = IsWeekends(createDocument);
                            }
                        }
                        //Выставляем извещение
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.OpenKnp);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.IzveshenieActNo);
                        var selectJournal = SelectJournal(journal.RegNumDeclaration);
                        if (selectJournal !=null)
                        {
                            if(selectJournal.DateFinishKnp != null)
                            {
                                var dateFinish = (DateTime)selectJournal.DateFinishKnp;
                                date = dateFinish > DateTime.Now ? DateTime.Now : dateFinish;
                                var dateAdd = dateFinish.AddWorkdays(5);
                                var totalDays = (dateAdd - DateTime.Now).TotalDays;
                                var countDay = (int)totalDays;
                                journal.IsPriznak = countDay < 0;
                            }
                        }
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ButtonAll);
                        libraryAutomation.IsEnableElements(Journal129AndJournal121.DateButtonAll, null, true);
                        libraryAutomation.SetValuePattern(date.ToString("dd.MM.yy"));
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ButtonAll);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ButtonSvedOpen);
                        while (true)
                        {
                            if (libraryAutomation.IsEnableElements(Journal129AndJournal121.NumKabinet, null, true) != null)
                            {
                                libraryAutomation.FindFirstElement(Journal129AndJournal121.NumKabinet);
                                libraryAutomation.SetValuePattern(senderSelect.Office);
                                libraryAutomation.ClickElements(Journal129AndJournal121.AddButton);
                                AutoItX.WinWait(Journal129AndJournal121.DateTime);
                                AutoItX.WinActivate(Journal129AndJournal121.DateTime);
                                while (true)
                                {
                                    if (libraryAutomation.IsEnableElements(Journal129AndJournal121.WindowDateTime, null, true) != null)
                                    {
                                        var hours = _hoursList[new Random().Next(0, _hoursList.Length)];
                                        var minute = _minutesList[new Random().Next(0, _minutesList.Length)];
                                        journal.DateIzveshenie = createDocument;
                                        libraryAutomation.SetValuePattern(createDocument.ToString("dd.MM.yy"));
                                        libraryAutomation.FindFirstElement(Journal129AndJournal121.WindowHours);
                                        libraryAutomation.SetValuePattern(hours);
                                        libraryAutomation.FindFirstElement(Journal129AndJournal121.WindowMinutes);
                                        libraryAutomation.SetValuePattern(minute);
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
                                libraryAutomation.SelectItemCombobox(libraryAutomation.IsEnableElements(Journal129AndJournal121.FaceNameSign), senderSelect.SenderTaxJournalOkp2.NameUser, 0);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Save);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SignAll);
                                break;
                            }
                        }
                        //Документ сохранить
                        SaveSendDoc(libraryAutomation, journal, "Извещение успешно выставлено!!!", "Извещение");
                        while (true)
                        {
                            if (libraryAutomation.IsEnableElements(Journal129AndJournal121.ButtonAll, null, true) != null)
                            {
                                break;
                            }
                        }
                        MouseCloseForm();
                    }
                }
                else
                {
                    //Выставляем Решение
                    //Иные материалы 
                    allMaterial.AddRange(ReturnMaterial(libraryAutomationDoc, isNotification, Journal129AndJournal121.TemplateIzveshenia));
                    allMaterial.AddRange(ReturnMaterial(libraryAutomationDoc, isReshBeginDate, Journal129AndJournal121.TemplateReshBeginDate));
                    allMaterial.AddRange(ReturnMaterial(libraryAutomationDoc, isReshDate, Journal129AndJournal121.TemplateReshDate));
                    allMaterial.AddRange(ReturnMaterial(libraryAutomationDoc, isProtokol, Journal129AndJournal121.Protokol));
                    var isGrinAll = isNotification.Any(x => libraryAutomationDoc.GetColorPixel(libraryAutomationDoc.SelectAutomationColrction(x).Cast<AutomationElement>().Where(automationElemenst => automationElemenst.Current.Name == "").ToList()[1]) != "8000");
                    var colorAct = libraryAutomationDoc.GetColorPixel(libraryAutomationDoc.SelectAutomationColrction(isAct).Cast<AutomationElement>().Where(automationElement => automationElement.Current.Name == "").ToList()[1]);
                    ////Если блок синий и акт и извещение зеленые
                    if (journal.GlobalColor == "ff" && colorAct == "8000" && !isGrinAll)
                    {
                        journal.ColorDoc = colorAct;

                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.OpenKnp);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ReshNo);
                        while (true)
                        {
                            if (libraryAutomation.IsEnableElements(Journal129AndJournal121.FaceNameGr15, null, true) != null)
                            {
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.AnyDocumentsGr3);
                                libraryAutomation.IsEnableElements(Journal129AndJournal121.AnyPastDocumentsGr3, null, true);
                                libraryAutomation.SetValuePattern(string.Join("\r\n", allMaterial));
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.AnyDocumentsGr3);
                                libraryAutomation.ClickElements(Journal129AndJournal121.FaceNameGr15, null, true);
                                libraryAutomation.SelectItemCombobox(libraryAutomation.IsEnableElements(Journal129AndJournal121.FaceNameSignGr15), senderSelect.SenderTaxJournalOkp2.NameUser, 0);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Save);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SignAll);
                                break;
                            }
                        }
                        //Документ сохранить
                        SaveSendDoc(libraryAutomation, journal, "Решение успешно выставлено!!!", "Решение");
                        while (true)
                        {
                            if (libraryAutomation.IsEnableElements(Journal129AndJournal121.ButtonAll, null, true) != null)
                            {
                                break;
                            }
                        }
                        WindowsAis3 win = new WindowsAis3();
                        AutoItX.Sleep(1000);
                        AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ClosedComplex121);
                        
                    }
                }
            }
            AutoItX.Sleep(1000);
        }
        /// <summary>
        /// Метод создания Актов Решений Извещений по КНД 1151006
        /// </summary>
        /// <param name="libraryAutomation">Библиотека Автомата</param>
        /// <param name="listDocMemo">Лист Документов Акты Решения Извещения </param>
        /// <param name="journal">Журнал</param>
        /// <param name="datePicker">Дата вызова плательщика</param>
        /// <param name="senderSelect">Подписант документа</param>
        /// <param name="dateCloseValidation">Дата окончания проверки</param>
        public void CreateForm1151006(LibraryAutomations libraryAutomation, AutomationElement[] listDocMemo, TaxJournal121 journal, DatePickerAdd datePicker, DepartamentOtdel senderSelect, DateTime? dateCloseValidation)
        {
            LibraryAutomations libraryAutomationDoc = new LibraryAutomations(WindowsAis3.AisNalog3);
            if (!listDocMemo.Any())
            {
                journal.ColorDoc = null;
                //Открыть или начать Проверку
                DateTime dateVAdd;
                if (dateCloseValidation == null)
                {
                     dateVAdd = journal.DateFinishCheck;
                     IsStartIsOpenKm(libraryAutomation, journal);
                    while (true)
                    {
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ClosedKnp);
                        AutoItX.Sleep(1000);
                        LibraryAutomations libraryAutomationSign = new LibraryAutomations(TreeWalker.RawViewWalker.GetPreviousSibling(libraryAutomation.RootAutomationElements));
                        while (true)
                        {
                            if (libraryAutomationSign.IsEnableElements(Journal129AndJournal121.NewWindowEnable, null, true, 40, 0, false, ';') != null)
                            {
                                libraryAutomationSign.IsEnableElements(Journal129AndJournal121.NewComboBoxError, null, false, 40, 0, false, ';');
                                libraryAutomationSign.ClickElement(libraryAutomationSign.FindElement);
                                var memo = libraryAutomationSign.SelectAutomationColrction(libraryAutomationSign.FindElement);
                                var elemClick = memo.Cast<AutomationElement>().FirstOrDefault(x => x.Current.Name == "Выявлены нарушения");
                                libraryAutomationSign.ClickElement(elemClick);
                                libraryAutomationSign.InvokePattern(libraryAutomationSign.IsEnableElements(Journal129AndJournal121.NewOkEdit));
                                AutoItX.WinWait(Journal129AndJournal121.NewWarningOk);
                                AutoItX.WinActivate(Journal129AndJournal121.NewWarningOk);
                                libraryAutomationSign = new LibraryAutomations(Journal129AndJournal121.NewWarningOk);
                                libraryAutomationSign.InvokePattern(libraryAutomationSign.IsEnableElements(Journal129AndJournal121.NewWarningButtonOk));
                                AutoItX.Sleep(1000);
                                break;
                            }
                        }
                        break;
                    }
                }
                else
                {
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.OpenKnp);
                    dateVAdd = (DateTime)dateCloseValidation;
                }
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.AktNo);
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.PublicInfo);
                while (true)
                {
                     if (libraryAutomation.IsEnableElements(Journal129AndJournal121.DateReshenia, null, true) != null)
                     {
                         dateVAdd = dateVAdd.AddDays(5);
                        if (journal.DateFinishCheck.DayOfWeek == DayOfWeek.Saturday)
                            dateVAdd = journal.DateFinishCheck.AddDays(2);
                        if (journal.DateFinishCheck.DayOfWeek == DayOfWeek.Sunday)
                            dateVAdd = journal.DateFinishCheck.AddDays(1);
                        libraryAutomation.SetValuePattern(dateVAdd.Date.ToString("dd.MM.yy"));
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Established);
                        libraryAutomation.FindFirstElement(Journal129AndJournal121.EstablishedNote);
                        libraryAutomation.SetValuePattern(string.Format(Journal129AndJournal121.AktTemplate1151006, journal.Period, journal.God, journal.DateFinishDeclaration.ToString("dd.MM.yyyy"), journal.DateStartDeclaration.ToString("dd.MM.yyyy")));
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
                                libraryAutomation.SelectItemCombobox(libraryAutomation.IsEnableElements(Journal129AndJournal121.FaceNameSign), senderSelect.SenderTaxJournalOkp2.NameUser, 0);
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
            AutoItX.Sleep(1000);
        }

        /// <summary>
        /// Метод создания Актов Решений Извещений по КНД 1151006
        /// </summary>
        /// <param name="libraryAutomation">Библиотека Автомата</param>
        /// <param name="listDocMemo">Лист Документов Акты Решения Извещения </param>
        /// <param name="journal">Журнал</param>
        /// <param name="datePicker">Дата вызова плательщика</param>
        /// <param name="senderSelect">Подписант документа</param>
        /// <param name="dateCloseValidation">Дата окончания проверки</param>
        /// <param name="summNp">Сумма по данным НП</param>
        /// <param name="colorError">Цвет 5 элемента если белый проставляем нарушения не выявлены</param>
        public void CreateForm1151111(LibraryAutomations libraryAutomation, AutomationElement[] listDocMemo, TaxJournal121 journal, DatePickerAdd datePicker, DepartamentOtdel senderSelect, DateTime? dateCloseValidation, string summNp, string colorError)
        {
            LibraryAutomations libraryAutomationDoc = new LibraryAutomations(WindowsAis3.AisNalog3);
            if(journal.GlobalColor == "6400")
            {
                return;
            }
            if (dateCloseValidation == null && colorError == "ffffff")
            {
                //Открыть или начать Проверку
                IsStartIsOpenKm(libraryAutomation, journal);
                DialogKnp(libraryAutomation, journal.DateFinishCheck, "Нарушения не выявлены");
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ClosedComplex121);
                return;
            }
            var allMaterial = new List<string>();
            if (!listDocMemo.Any())
            {
                //Акты
                journal.ColorDoc = null;
                if (dateCloseValidation == null && colorError != "ffffff")
                {
                    DateTime dateControl = DateTime.Now;
                    dateControl = dateControl.AddDays(-1);
                    IsStartIsOpenKm(libraryAutomation, journal);
                    DialogKnp(libraryAutomation, dateControl, "Выявлены нарушения");
                }
                else
                {
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.OpenKnp);
                }
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.AktNo);
                while (true)
                {
                    if (libraryAutomation.IsEnableElements(Journal129AndJournal121.ErrorFaceGr8, null, true) != null)
                    {
                        //Проверка на просрочку
                        var date = DateTime.Now;
                        if (journal.DateFinishKnp != null)
                        {
                            var dateFinish = (DateTime)journal.DateFinishKnp;
                            date = dateFinish > DateTime.Now ? DateTime.Now : dateFinish;
                            var dateAdd = dateFinish.AddWorkdays(5);
                            var totalDays = (dateAdd - DateTime.Now).TotalDays;
                            var countDay = (int)totalDays;
                            journal.IsPriznak = countDay < 0;
                        }
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ErrorFaceGr8);
                        var notCash = decimal.Parse(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(Journal129AndJournal121.NotCash)));
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ErrorFaceGr8);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ErrorFaceGr9);
                        var ischesleno = decimal.Parse(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(Journal129AndJournal121.Ischesleno)));
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ErrorFaceGr9);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ErrorFaceGr10);
                        var peny = decimal.Parse(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(Journal129AndJournal121.Peny)));
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ErrorFaceGr10);
                        if (notCash == 0 & ischesleno == 0 & peny == 0)
                        {

                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.PublicInfo);
                            libraryAutomation.IsEnableElements(Journal129AndJournal121.DateReshenia, null, true);
                            libraryAutomation.SetValuePattern(date.ToString("dd.MM.yy"));
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Established);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.DonloadButton);
                            libraryAutomation.FindFirstElement(Journal129AndJournal121.EstablishedNote);
                            //Проверка КНД Выставляем шаблон
                            libraryAutomation.SetValuePattern(string.Format(Journal129AndJournal121.AktTemplate1151111, journal.Period, journal.God, journal.DateStartCheck.ToString("dd.MM.yyyy"), summNp));
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SaveAktNo);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SignAktNo);

                            //Если есть просрочка то не отправляем документ плательщику 
                            if (journal.IsPriznak)
                            {
                                SaveSendDoc(libraryAutomation, journal, "Акт успешно выставлено!!!", "Акт", true);
                            }
                            else
                            {
                                SaveSendDoc(libraryAutomation, journal, "Акт успешно выставлено!!!", "Акт");
                            }
                            MouseCloseForm();
                            break;
                        }
                        else
                        {
                            journal.MessageInfo = $"Выставление Акта не возможно: пеня {peny}, неуплата {notCash}, исчислено {ischesleno}";
                            SaveDocument(journal);
                            WindowsAis3 win = new WindowsAis3();
                            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.WinCloseErrorAct);
                            AutoItX.Sleep(1000);
                            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                            break;
                        }
                    }

                }
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
                //Решение о продлении срока
                var isReshDate = listDocMemo.Where(doc =>
                    libraryAutomationDoc.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomationDoc.SelectAutomationColrction(doc).Cast<AutomationElement>()
                             .First(elem => elem.Current.Name.Contains("КНД"))) == "1160088");
                //Решение об отложении
                var isReshBeginDate = listDocMemo.Where(doc =>
                    libraryAutomationDoc.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomationDoc.SelectAutomationColrction(doc).Cast<AutomationElement>()
                             .First(elem => elem.Current.Name.Contains("КНД"))) == "1160076");
              
                var isProtokol = listDocMemo.Where(doc =>
                    libraryAutomationDoc.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomationDoc.SelectAutomationColrction(doc).Cast<AutomationElement>()
                            .First(elem => elem.Current.Name.Contains("КНД"))) == "1165052");
                //Логика принятия решения
                if ((isAct != null && isNotification == null) || (isNotification.Count() < datePicker.CountIzveshenie))
                {
                    //Извещения
                    var documentStatus = libraryAutomationDoc.SelectAutomationColrction(isAct).Cast<AutomationElement>().Where(automationElemenst => automationElemenst.Current.Name == "").ToList();
                    journal.ColorDoc = libraryAutomationDoc.GetColorPixel(documentStatus[0]);
                    //Дата документа
                    var createDocument = Convert.ToDateTime(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                  .SelectAutomationColrction(isAct)
                                  .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Дата документа"))));
                    if (journal.ColorDoc == "ffff00" || journal.ColorDoc == "8000")
                    {
                        var modelDecl = SelectJournal(journal.RegNumDeclaration);
                        if (modelDecl != null)
                        {
                            //Извещения
                            if (modelDecl.IsMail != null && (bool)modelDecl.IsMail)
                            {
                                //Если почта то Если почта - 5  рабочих дней на вручение ( со след. дня после даты акта) +6 рабочих дней на отправку + 1 месяц на возражения
                                createDocument = createDocument.AddWorkdays(11);
                                createDocument = createDocument.AddMonths(1);
                                //Уходим от выходных
                                createDocument = IsWeekends(createDocument);
                            }
                            else
                            {
                                //В противном случае ТКС Если ТКС -   5  рабочих дней на вручение ( со след. дня после даты акта) + 1 месяц на возражения  
                                createDocument = createDocument.AddWorkdays(5);
                                createDocument = createDocument.AddMonths(1);
                                //Уходим от выходных
                                createDocument = IsWeekends(createDocument);
                            }
                            //Выставляем извещение
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.OpenKnp);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.IzveshenieActNo);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ButtonSved);
                            while (true)
                            {
                                if (libraryAutomation.IsEnableElements(Journal129AndJournal121.NumKabinet, null, true) != null)
                                {
                                    libraryAutomation.FindFirstElement(Journal129AndJournal121.NumKabinet);
                                    libraryAutomation.SetValuePattern("366");
                                    libraryAutomation.ClickElements(Journal129AndJournal121.AddButton);
                                    AutoItX.WinWait(Journal129AndJournal121.DateTime);
                                    AutoItX.WinActivate(Journal129AndJournal121.DateTime);
                                    while (true)
                                    {
                                        if (libraryAutomation.IsEnableElements(Journal129AndJournal121.WindowDateTime, null, true) != null)
                                        {
                                            var hours = _hoursList[new Random().Next(0, _hoursList.Length)];
                                            var minute = _minutesList[new Random().Next(0, _minutesList.Length)];
                                            journal.DateIzveshenie = createDocument;
                                            libraryAutomation.SetValuePattern(createDocument.ToString("dd.MM.yy"));
                                            libraryAutomation.FindFirstElement(Journal129AndJournal121.WindowHours);
                                            libraryAutomation.SetValuePattern(hours);
                                            libraryAutomation.FindFirstElement(Journal129AndJournal121.WindowMinutes);
                                            libraryAutomation.SetValuePattern(minute);
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
                                    libraryAutomation.SelectItemCombobox(libraryAutomation.IsEnableElements(Journal129AndJournal121.FaceNameSign), senderSelect.SenderTaxJournalOkp2.NameUser, 0);
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Save);
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SignAll);
                                    break;
                                }
                            }
                            //Документ сохранить
                            SaveSendDoc(libraryAutomation, journal, "Извещение успешно выставлено!!!", "Извещение",false, senderSelect.SenderTaxJournalOkp2.NameUser);
                            MouseCloseForm();
                        }
                    }
                }
                else
                {
                      //Решения
                      //Иные материалы 
                      allMaterial.AddRange(ReturnMaterial(libraryAutomationDoc, isNotification, Journal129AndJournal121.TemplateIzveshenia));
                      allMaterial.AddRange(ReturnMaterial(libraryAutomationDoc, isReshBeginDate, Journal129AndJournal121.TemplateReshBeginDate));
                      allMaterial.AddRange(ReturnMaterial(libraryAutomationDoc, isReshDate, Journal129AndJournal121.TemplateReshDate));
                      allMaterial.AddRange(ReturnMaterial(libraryAutomationDoc, isProtokol, Journal129AndJournal121.Protokol));
                      var isGrinAll = isNotification.Any(x => libraryAutomationDoc.GetColorPixel(libraryAutomationDoc.SelectAutomationColrction(x).Cast<AutomationElement>().Where(automationElemenst => automationElemenst.Current.Name == "").ToList()[1]) != "8000");
                      var colorAct = libraryAutomationDoc.GetColorPixel(libraryAutomationDoc.SelectAutomationColrction(isAct).Cast<AutomationElement>().Where(automationElement => automationElement.Current.Name == "").ToList()[1]);
                      ////Если блок синий и акт и все извещение зеленые выставляем Решения
                      if (journal.GlobalColor == "ff" && colorAct == "8000" && !isGrinAll)
                      {
                        journal.ColorDoc = colorAct;
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.OpenKnp);
                        libraryAutomation.ScrollPatternViewElement(Journal129AndJournal121.ReshScroll);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ReshNo, null, true);
                        while (true)
                        {
                            if (libraryAutomation.IsEnableElements(Journal129AndJournal121.ErrorFaceGr8, null, true) != null)
                            {
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ErrorFaceGr8);
                                var notCash = decimal.Parse(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(Journal129AndJournal121.NotCash)));
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ErrorFaceGr8);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ErrorFaceGr9);
                                var ischesleno = decimal.Parse(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(Journal129AndJournal121.Ischesleno)));
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ErrorFaceGr9);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ErrorFaceGr10);
                                var peny = decimal.Parse(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(Journal129AndJournal121.Peny)));
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ErrorFaceGr10);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ErrorFaceGr11);
                                var cash = decimal.Parse(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(Journal129AndJournal121.CashFace)));
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ErrorFaceGr11);
                                if (cash == 1000 & notCash==0 & ischesleno ==0 & peny ==0 )
                                {
                                    //Проверка на просрочку
                                    var date = DateTime.Now;
                                    if (journal.DateFinishKnp != null)
                                    {
                                        var dateFinish = (DateTime)journal.DateFinishKnp;
                                        date = dateFinish > DateTime.Now ? DateTime.Now : dateFinish;
                                        var dateAdd = dateFinish.AddWorkdays(5);
                                        var totalDays = (dateAdd - DateTime.Now).TotalDays;
                                        var countDay = (int)totalDays;
                                        journal.IsPriznak = countDay < 0;
                                    }
                                  
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.PublicInfo);
                                    libraryAutomation.IsEnableElements(Journal129AndJournal121.DateReshenia, null, true);
                                    libraryAutomation.SetValuePattern(date.ToString("dd.MM.yy"));
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.AnyDocumentsGr3);
                                    libraryAutomation.IsEnableElements(Journal129AndJournal121.AnyPastDocumentsGr3, null, true);
                                    libraryAutomation.SetValuePattern(string.Join("\r\n", allMaterial));
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.AnyDocumentsGr3);
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.InstallGr6);
                                    var template = libraryAutomation.ParseValuePattern(libraryAutomation.IsEnableElements(Journal129AndJournal121.InstallTextGr6));
                                    libraryAutomation.SetValuePattern(string.Join("\r\n", template, string.Format(Journal129AndJournal121.TemplateAddText, journal.Period, journal.God)));
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.InstallGr6);
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.FaceNameGr15);
                                    libraryAutomation.SelectItemCombobox(libraryAutomation.IsEnableElements(Journal129AndJournal121.FaceNameSignGr15), senderSelect.SenderTaxJournalOkp2.NameUser, 0);
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Save);
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SignAll);
                                    //Если есть просрочка то не отправляем документ плательщику 
                                    if (journal.IsPriznak)
                                    {
                                        SaveSendDoc(libraryAutomation, journal, "Решение успешно выставлено!!!", "Решение", true);
                                    }
                                    else
                                    {
                                        SaveSendDoc(libraryAutomation, journal, "Решение успешно выставлено!!!", "Решение");
                                    }
                                    WindowsAis3 win = new WindowsAis3();
                                    AutoItX.Sleep(1000);
                                    AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                                    if (libraryAutomation.IsEnableElements(Journal129AndJournal121.ClosedComplex121, null, false, 5) != null)
                                    {
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ClosedComplex121);
                                        AutoItX.WinWait(Journal129AndJournal121.WinNameComplex);
                                        AutoItX.WinActivate(Journal129AndJournal121.WinNameComplex);
                                        LibraryAutomations libraryAutomationWin = new LibraryAutomations(Journal129AndJournal121.WinNameComplex);
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomationWin, Journal129AndJournal121.WinOkCloseComplex);
                                    }
                                    else
                                    {
                                        WindowsAis3 winClose = new WindowsAis3();
                                        AutoItX.Sleep(1000);
                                        AutoItX.MouseClick(ButtonConstant.MouseLeft, winClose.WindowsAis.X + winClose.WindowsAis.Width - 20, winClose.WindowsAis.Y + 160);
                                    }
                                    break;
                                }
                                else
                                {
                                    //Не выставляем решения так как Итого {cash}
                                    journal.MessageInfo = $"Выставление решения не возможно сумма {cash} больше 1000 или не 0: пеня {peny}, неуплата {notCash}, исчислено {ischesleno}";
                                    SaveDocument(journal);
                                    WindowsAis3 win = new WindowsAis3();
                                    AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.WinCloseError);
                                    AutoItX.Sleep(1000);
                                    AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                                    break;
                                }
                            }
                        }
                        
                      }
                }
            }
            AutoItX.Sleep(1000);
        }
        /// <summary>
        /// Метод создания Актов Решений Извещений по КНД 1151020
        /// </summary>
        /// <param name="libraryAutomation">Библиотека Автомата</param>
        /// <param name="listDocMemo">Лист Документов Акты Решения Извещения </param>
        /// <param name="journal">Журнал</param>
        /// <param name="datePicker">Дата вызова плательщика</param>
        /// <param name="senderSelect">Подписант документа</param>
        /// <param name="dateCloseValidation">Дата окончания проверки</param>
        /// <param name="summNp">Сумма по данным НП</param>
        /// <param name="colorError">Цвет 5 элемента если белый проставляем нарушения не выявлены</param>
        public void CreateForm1151020(LibraryAutomations libraryAutomation, AutomationElement[] listDocMemo, TaxJournal121 journal, DatePickerAdd datePicker, DepartamentOtdel senderSelect, DateTime? dateCloseValidation, string summNp, string colorError)
        {
            var date = DateTime.Now;
            if (!listDocMemo.Any())
            {
                //Акты
                journal.ColorDoc = null;
                if (dateCloseValidation == null && colorError != "ffffff")
                {

                }
                else
                {
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.OpenKnp);
                }
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.AktNo);
                while (true)
                {
                    if (libraryAutomation.IsEnableElements(Journal129AndJournal121.ErrorFaceGr8, null, true) != null)
                    {
                        //Проверка на просрочку
                        if (journal.DateFinishKnp != null)
                        {
                            var dateFinish = (DateTime)journal.DateFinishKnp;
                            date = dateFinish > DateTime.Now ? DateTime.Now : dateFinish;
                            var dateAdd = dateFinish.AddWorkdays(5);
                            var totalDays = (dateAdd - DateTime.Now).TotalDays;
                            var countDay = (int)totalDays;
                            journal.IsPriznak = countDay < 0;
                        }
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.PublicInfo);
                        libraryAutomation.IsEnableElements(Journal129AndJournal121.DateReshenia, null, true);
                        libraryAutomation.SetValuePattern(date.ToString("dd.MM.yy"));
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Established);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.DonloadButton);
                        libraryAutomation.FindFirstElement(Journal129AndJournal121.EstablishedNote);
                        libraryAutomation.SetValuePattern("Согласно представленным Вами документам, налоговый вычет не подтвержден в заявленном размере.");
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SaveAktNo);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SignAktNo);

                        SaveSendDoc(libraryAutomation, journal, "Акт успешно выставлено!!!", "Акт");
                        while (true)
                        {
                            if (libraryAutomation.IsEnableElements(Journal129AndJournal121.Established, null, true) != null)
                            {
                                break;
                            }
                        }
                        MouseCloseForm();
                        break;
                    }
                }
            }
            else
            {

            }

            //Данная функция закрыта так как используется не по назначению принадлежит ОКП 6
                //if (journal.GlobalColor == "ff0000")
                //{
                //    return;
                //}
                //if (journal.GlobalColor == "6400")
                //{
                //    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.StartKnp);
                //    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ClosedComplex121);
                //    AutoItX.WinWait(Journal129AndJournal121.WinNameComplex);
                //    AutoItX.WinActivate(Journal129AndJournal121.WinNameComplex);
                //    LibraryAutomations libraryAutomationWin = new LibraryAutomations(Journal129AndJournal121.WinNameComplex);
                //    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomationWin, Journal129AndJournal121.WinOkCloseComplex);
                //    AutoItX.Sleep(1000);
                //    return;
                //}
                //var isError = false;
                //PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.StartKnp);
                //if (libraryAutomation.IsEnableElements(Journal129AndJournal121.WinErrorWin) != null){
                //    libraryAutomation.InvokePattern(libraryAutomation.IsEnableElements(Journal129AndJournal121.WinErrorWin));
                //    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.OpenKnp);
                //}
                //while (true)
                //{
                //    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.CloseKnp);
                //    AutoItX.Sleep(1000);
                //    while (true)
                //    {
                //        LibraryAutomations libraryAutomationSign = new LibraryAutomations(TreeWalker.RawViewWalker.GetPreviousSibling(libraryAutomation.RootAutomationElements));
                //        if (libraryAutomationSign.IsEnableElements(Journal129AndJournal121.NewWindowEnable, null, true, 40, 0, false, ';') != null)
                //        {
                //            libraryAutomationSign.IsEnableElements(Journal129AndJournal121.NewComboBoxError, null, false, 40, 0, false, ';');
                //            libraryAutomationSign.ClickElement(libraryAutomationSign.FindElement);
                //            var memo = libraryAutomationSign.SelectAutomationColrction(libraryAutomationSign.FindElement);
                //            var elemClick = memo.Cast<AutomationElement>().FirstOrDefault(x => x.Current.Name == "Нарушения не выявлены");
                //            libraryAutomationSign.ClickElement(elemClick);
                //            libraryAutomationSign.InvokePattern(libraryAutomationSign.IsEnableElements(Journal129AndJournal121.NewOkEdit));
                //            AutoItX.Sleep(1000);
                //            if (AutoItX.WinExists(Journal129AndJournal121.NewWarningError) != 0)
                //            {
                //                AutoItX.WinActivate(Journal129AndJournal121.NewWarningError);
                //                AutoItX.Send(ButtonConstant.Enter);
                //                libraryAutomationSign.IsEnableElements(Journal129AndJournal121.NewComboBoxError, null, false, 40, 0, false, ';');
                //                libraryAutomationSign.ClickElement(libraryAutomationSign.FindElement);
                //                memo = libraryAutomationSign.SelectAutomationColrction(libraryAutomationSign.FindElement);
                //                elemClick = memo.Cast<AutomationElement>().FirstOrDefault(x => x.Current.Name == "Выявлены нарушения (но не учитываются в 2НК)");
                //                libraryAutomationSign.ClickElement(elemClick);
                //                libraryAutomationSign.InvokePattern(libraryAutomationSign.IsEnableElements(Journal129AndJournal121.NewOkEdit));
                //                isError = true;
                //            }
                //            AutoItX.WinWait(Journal129AndJournal121.NewWarningOk);
                //            AutoItX.WinActivate(Journal129AndJournal121.NewWarningOk);
                //            libraryAutomationSign = new LibraryAutomations(Journal129AndJournal121.NewWarningOk);
                //            libraryAutomationSign.InvokePattern(libraryAutomationSign.IsEnableElements(Journal129AndJournal121.NewWarningButtonOk));
                //            AutoItX.Sleep(1000);
                //            break;
                //        }
                //    }
                //    break;
                //}
                //if (isError)
                //{
                //    WindowsAis3 win = new WindowsAis3();
                //    AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                //    AutoItX.Sleep(1000);
                //}
                //else
                //{
                //    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ClosedComplex121);
                //    AutoItX.WinWait(Journal129AndJournal121.WinNameComplex);
                //    AutoItX.WinActivate(Journal129AndJournal121.WinNameComplex);
                //    LibraryAutomations libraryAutomationWin = new LibraryAutomations(Journal129AndJournal121.WinNameComplex);
                //    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomationWin, Journal129AndJournal121.WinOkCloseComplex);
                //    AutoItX.Sleep(1000);
                //}
            }


        /// <summary>
        /// Метод создания Актов Решений Извещений по КНД 1151001
        /// </summary>
        /// <param name="libraryAutomation">Библиотека Автомата</param>
        /// <param name="listDocMemo">Лист Документов Акты Решения Извещения </param>
        /// <param name="journal">Журнал</param>
        /// <param name="datePicker">Дата вызова плательщика</param>
        /// <param name="senderSelect">Подписант документа</param>
        /// <param name="dateCloseValidation">Дата окончания проверки</param>
        /// <param name="sumNp">Сумма по данным НП</param>
        /// <param name="colorError">Цвет 5 элемента если белый проставляем нарушения не выявлены</param>
        public void CreateForm1151001(LibraryAutomations libraryAutomation, AutomationElement[] listDocMemo, TaxJournal121 journal, DatePickerAdd datePicker, DepartamentOtdel senderSelect, DateTime? dateCloseValidation,  string sumNp, string colorError)
        {
            var ratchet = 0;
            decimal sumNedoim = (decimal)0.00;
            var date = DateTime.Now;
            var month = "1";
            if ((journal.DateStartDeclaration.Year != journal.DateFinishDeclaration.Year || journal.DateStartDeclaration.Month != journal.DateFinishDeclaration.Month || journal.DateStartDeclaration.Day != journal.DateFinishDeclaration.Day))
            {
                if (journal.DateStartDeclaration.Day > 25)
                {
                    ratchet++;
                }
            }
            ratchet += ((journal.DateStartDeclaration.Year - journal.DateFinishDeclaration.Year) * 12) + journal.DateStartDeclaration.Month - journal.DateFinishDeclaration.Month;
            if (ratchet == 1)
            {
                sumNedoim = decimal.Parse(sumNp) * (decimal)0.5;
                month = "1";
            }
            else if (ratchet == 2)
            {
                sumNedoim = decimal.Parse(sumNp) * (decimal)0.10;
                month = "2";
            }
            else if (ratchet == 3)
            {
                sumNedoim = decimal.Parse(sumNp) * (decimal)0.15;
                month = "3";
            }
            else if (ratchet == 4)
            {
                sumNedoim = decimal.Parse(sumNp) * (decimal)0.20;
                month = "4";
            }
            else if (ratchet == 5)
            {
                sumNedoim = decimal.Parse(sumNp) * (decimal)0.25;
                month = "5";
            }
            else if (ratchet >= 6)
            {
                sumNedoim = decimal.Parse(sumNp) * (decimal)0.30;
                month = "6";
            }
            LibraryAutomations libraryAutomationDoc = new LibraryAutomations(WindowsAis3.AisNalog3);
            if (journal.GlobalColor == "6400")
            {
                return;
            }
            var allMaterial = new List<string>();
            if (!listDocMemo.Any())
            {
                //Акты
                journal.ColorDoc = null;
                if (dateCloseValidation == null && colorError != "ffffff")
                {
                    return;
                }
                else
                {
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.OpenKnp);
                }
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.AktNo);
                while (true)
                {
                    if (libraryAutomation.IsEnableElements(Journal129AndJournal121.ErrorFaceGr8, null, true) != null)
                    {
                        //Проверка на просрочку
                        if (journal.DateFinishKnp != null)
                        {
                            var dateFinish = (DateTime)journal.DateFinishKnp;
                            date = dateFinish > DateTime.Now ? DateTime.Now : dateFinish;
                            var dateAdd = dateFinish.AddWorkdays(5);
                            var totalDays = (dateAdd - DateTime.Now).TotalDays;
                            var countDay = (int)totalDays;
                            journal.IsPriznak = countDay < 0;
                        }
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.PublicInfo);
                        libraryAutomation.IsEnableElements(Journal129AndJournal121.DateReshenia, null, true);
                        libraryAutomation.SetValuePattern(date.ToString("dd.MM.yy"));

                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ErrorFaceGr11);
                        if (libraryAutomation.IsEnableElements(Journal129AndJournal121.ListCashFace, null, true) != null)
                        {
                            var listCash = libraryAutomation
                                .SelectAutomationColrction(
                                    libraryAutomation.FindFirstElement(Journal129AndJournal121.ListCashFace))
                                .Cast<AutomationElement>().Distinct().Where(elem => elem.Current.Name.Contains("Sanctions row")
                                ).ToList();
                            if (listCash.Count > 1|| listCash.Count == 0)
                            {
                                AutomationElement cashDelete;
                                while ((cashDelete = libraryAutomation.IsEnableElements(Journal129AndJournal121.ListCashFaceRowNumber1, null, false, 10)) != null)
                                {
                                    while (true)
                                    {
                                        libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                            .SelectAutomationColrction(cashDelete)
                                            .Cast<AutomationElement>().First(elementFine => elementFine.Current.Name.Contains("Ун документа НБО")));
                                        var elem = libraryAutomation.FindFirstElement("Name:Удалить", cashDelete);
                                        libraryAutomation.ClickElement(elem);

                                        if (libraryAutomation.IsEnableElements(Journal129AndJournal121.DeleteWin, null, true) != null)
                                        {
                                            libraryAutomation.ClickElement(libraryAutomation.IsEnableElements(Journal129AndJournal121.DeleteWin));
                                            break;
                                        }
                                    }
                                }
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ErrorFaceGr15);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.AddNewErrror);
                                libraryAutomation.IsEnableElements(Journal129AndJournal121.WinSelect1);
                                libraryAutomation.SetValuePattern("11901013");
                                libraryAutomation.IsEnableElements(Journal129AndJournal121.WinSelect2);
                                libraryAutomation.SetValuePattern("11901013");
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.WinSelectOk);
                                if (sumNedoim > 1000)
                                {
                                    while ((cashDelete = libraryAutomation.IsEnableElements(Journal129AndJournal121.ListCashFaceRowNumber1, null, false, 10)) != null)
                                    {
                                        var sumSt = libraryAutomation
                                            .SelectAutomationColrction(cashDelete)
                                            .Cast<AutomationElement>().First(elementFine => elementFine.Current.Name == "Штраф, рублей");
                                        libraryAutomation.FindElement = sumSt;
                                        libraryAutomation.SetValuePattern(Convert.ToString(decimal.Round(sumNedoim)));
                                        break;
                                    }
                                }
                            }
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ErrorFaceGr15);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.AddNewCircumstance);
                            libraryAutomation.IsEnableElements(Journal129AndJournal121.WinSelectCircumstance1);
                            libraryAutomation.SetValuePattern("отсутствие обстоятельств");
                            libraryAutomation.IsEnableElements(Journal129AndJournal121.WinSelectCircumstance2);
                            libraryAutomation.SetValuePattern("22");
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.WinSelectCircumstanceOk);
                        }
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ErrorFaceGr11);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Established);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.DonloadButton);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ButtonSend);
                        while (true)
                        {
                            if (libraryAutomation.IsEnableElements(Journal129AndJournal121.EstablishedNotePred, null, true) != null)
                            {
                                libraryAutomation.FindFirstElement(Journal129AndJournal121.EstablishedNotePred);
                                break;
                            }
                        }
                        //Проверка КНД Выставляем шаблон
                        //Если сумма не 0.00 то тогда подставляем строку
                        if (Convert.ToDecimal(sumNedoim) > 1000)
                        {
                            //Подставить сумму в зависимости от просрочки месяцев

                            libraryAutomation.SetValuePattern(string.Format(Journal129AndJournal121.AktTemplate1151001, journal.NameFace, journal.Period, journal.God,
                                journal.DateFinishDeclaration.ToString("dd.MM.yyyy"), journal.DateStartDeclaration.ToString("dd.MM.yyyy"),
                                ratchet, string.Format(Journal129AndJournal121.SummIsExists,decimal.Round(sumNedoim), senderSelect.Telephon)));
                        }
                        else
                        {
                            libraryAutomation.SetValuePattern(string.Format(Journal129AndJournal121.AktTemplate1151001, journal.NameFace, journal.Period, journal.God,
                                journal.DateFinishDeclaration.ToString("dd.MM.yyyy"), journal.DateStartDeclaration.ToString("dd.MM.yyyy"),
                                ratchet, "", senderSelect.Telephon));
                        }
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.AddNote);
                        if (libraryAutomation.IsEnableElements(Journal129AndJournal121.Breake, null, true) != null)
                        {
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Breake);
                        }
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SaveAktNo);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Ok);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SignAktNo);
                        SaveSendDoc(libraryAutomation, journal, "Акт успешно выставлено!!!", "Акт");
                        while (true)
                        {
                            if(libraryAutomation.IsEnableElements(Journal129AndJournal121.Established, null, true) != null)
                            {
                                break;
                            }
                        }
                        MouseCloseForm();
                        break;
                    }

                }
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
                //Решение о продлении срока
                var isReshDate = listDocMemo.Where(doc =>
                    libraryAutomationDoc.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomationDoc.SelectAutomationColrction(doc).Cast<AutomationElement>()
                             .First(elem => elem.Current.Name.Contains("КНД"))) == "1160088");
                //Решение об отложении
                var isReshBeginDate = listDocMemo.Where(doc =>
                    libraryAutomationDoc.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomationDoc.SelectAutomationColrction(doc).Cast<AutomationElement>()
                             .First(elem => elem.Current.Name.Contains("КНД"))) == "1160076");

                var isProtokol = listDocMemo.Where(doc =>
                    libraryAutomationDoc.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomationDoc.SelectAutomationColrction(doc).Cast<AutomationElement>()
                            .First(elem => elem.Current.Name.Contains("КНД"))) == "1165052");
                var isResh = listDocMemo.Where(doc =>
                    libraryAutomationDoc.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomationDoc.SelectAutomationColrction(doc).Cast<AutomationElement>()
                            .First(elem => elem.Current.Name.Contains("КНД"))) == "1165020");
                //Логика принятия решения
                if ((isAct != null && isNotification == null) || (isNotification.Count() < datePicker.CountIzveshenie))
                {
                    //Извещения
                    var documentStatus = libraryAutomationDoc.SelectAutomationColrction(isAct).Cast<AutomationElement>().Where(automationElemenst => automationElemenst.Current.Name == "").ToList();
                    journal.ColorDoc = libraryAutomationDoc.GetColorPixel(documentStatus[0]);
                    //Дата документа
                    var createDocument = DateTime.Now;
                    if (journal.ColorDoc == "ffff00" || journal.ColorDoc == "8000")
                    {
                        var modelDecl = SelectJournal(journal.RegNumDeclaration);
                        if (modelDecl != null)
                        {
                            //Извещения
                            if (modelDecl.IsMail != null && (bool)modelDecl.IsMail)
                            {
                                //Если почта то Если почта - 5  рабочих дней на вручение ( со след. дня после даты акта) +6 рабочих дней на отправку + 1 месяц на возражения
                                createDocument = createDocument.AddWorkdays(5);
                                createDocument = createDocument.AddMonths(1);
                                createDocument = createDocument.AddWorkdays(5);
                                //Уходим от выходных
                                createDocument = IsWeekends(createDocument);
                            }
                            else
                            {
                                //В противном случае ТКС Если ТКС -   5  рабочих дней на вручение ( со след. дня после даты акта) + 1 месяц на возражения  
                                createDocument = createDocument.AddWorkdays(5);
                                createDocument = createDocument.AddMonths(1);
                                createDocument = createDocument.AddWorkdays(5);
                                //Уходим от выходных
                                createDocument = IsWeekends(createDocument);
                            }
                            //Выставляем извещение
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.OpenKnp);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.IzveshenieActNo);
                            var selectJournal = SelectJournal(journal.RegNumDeclaration);
                            if (selectJournal.DateFinishKnp != null)
                            {
                                var dateFinish = (DateTime)selectJournal.DateFinishKnp;
                                date = dateFinish > DateTime.Now ? DateTime.Now : dateFinish;
                                var dateAdd = dateFinish.AddWorkdays(5);
                                var totalDays = (dateAdd - DateTime.Now).TotalDays;
                                var countDay = (int)totalDays;
                                journal.IsPriznak = countDay < 0;
                            }
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ButtonAll);
                            libraryAutomation.IsEnableElements(Journal129AndJournal121.DateButtonAll, null, true);
                            libraryAutomation.SetValuePattern(date.ToString("dd.MM.yy"));
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ButtonAll);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ButtonSvedOpen);
                            while (true)
                            {
                                if (libraryAutomation.IsEnableElements(Journal129AndJournal121.NumKabinet, null, true) != null)
                                {
                                    libraryAutomation.FindFirstElement(Journal129AndJournal121.NumKabinet);
                                    libraryAutomation.SetValuePattern(senderSelect.Office);
                                    libraryAutomation.ClickElements(Journal129AndJournal121.AddButton);
                                    AutoItX.WinWait(Journal129AndJournal121.DateTime);
                                    AutoItX.WinActivate(Journal129AndJournal121.DateTime);
                                    while (true)
                                    {
                                        if (libraryAutomation.IsEnableElements(Journal129AndJournal121.WindowDateTime, null, true) != null)
                                        {
                                            var hours = _hoursList[new Random().Next(0, _hoursList.Length)];
                                            var minute = _minutesList[new Random().Next(0, _minutesList.Length)];
                                            journal.DateIzveshenie = createDocument;
                                            libraryAutomation.SetValuePattern(createDocument.ToString("dd.MM.yy"));
                                            libraryAutomation.FindFirstElement(Journal129AndJournal121.WindowHours);
                                            libraryAutomation.SetValuePattern(hours);
                                            libraryAutomation.FindFirstElement(Journal129AndJournal121.WindowMinutes);
                                            libraryAutomation.SetValuePattern(minute);
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
                                    libraryAutomation.SelectItemCombobox(libraryAutomation.IsEnableElements(Journal129AndJournal121.FaceNameSign), senderSelect.SenderTaxJournalOkp2.NameUser, 0);
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Save);
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SignAll);
                                    break;
                                }
                            }
                            //Документ сохранить
                            SaveSendDoc(libraryAutomation, journal, "Извещение успешно выставлено!!!", "Извещение", false, senderSelect.SenderTaxJournalOkp2.NameUser);
                            while (true)
                            {
                                if (libraryAutomation.IsEnableElements(Journal129AndJournal121.ButtonAll, null, true) != null)
                                {
                                    break;
                                }
                            }
                            MouseCloseForm();
                        }
                    }
                }
                else
                {
                    //Решения
                    //////Иные материалы 
                    allMaterial.AddRange(ReturnMaterial(libraryAutomationDoc, isNotification, Journal129AndJournal121.TemplateIzveshenia));
                    allMaterial.AddRange(ReturnMaterial(libraryAutomationDoc, isReshBeginDate, Journal129AndJournal121.TemplateReshBeginDate));
                    allMaterial.AddRange(ReturnMaterial(libraryAutomationDoc, isReshDate, Journal129AndJournal121.TemplateReshDate));
                    allMaterial.AddRange(ReturnMaterial(libraryAutomationDoc, isProtokol, Journal129AndJournal121.Protokol));
                    var isGrinAll = isNotification.Any(x => libraryAutomationDoc.GetColorPixel(libraryAutomationDoc.SelectAutomationColrction(x).Cast<AutomationElement>().Where(automationElemenst => automationElemenst.Current.Name == "").ToList()[1]) != "8000");
                    var colorAct = libraryAutomationDoc.GetColorPixel(libraryAutomationDoc.SelectAutomationColrction(isAct).Cast<AutomationElement>().Where(automationElement => automationElement.Current.Name == "").ToList()[1]);
                    ////Если блок синий и акт и все извещение зеленые выставляем Решения
                    if (journal.GlobalColor == "ff" && colorAct == "8000" && !isGrinAll && isResh.Count()==0)
                    {
                        journal.ColorDoc = colorAct;
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.OpenKnp);
                        libraryAutomation.ScrollPatternViewElement(Journal129AndJournal121.ReshScroll);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ReshNo, null, true);
                        while (true)
                        {
                            if (libraryAutomation.IsEnableElements(Journal129AndJournal121.ErrorFaceGr8, null, true) != null)
                            {
                                //Проверка на просрочку
                                date = DateTime.Now;
                                if (journal.DateFinishKnp != null)
                                {
                                    var dateFinish = (DateTime)journal.DateFinishKnp;
                                    date = dateFinish > DateTime.Now ? DateTime.Now : dateFinish;
                                    var dateAdd = dateFinish.AddWorkdays(5);
                                    var totalDays = (dateAdd - DateTime.Now).TotalDays;
                                    var countDay = (int)totalDays;
                                    journal.IsPriznak = countDay < 0;
                                }

                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.PublicInfo);
                                libraryAutomation.IsEnableElements(Journal129AndJournal121.DateReshenia, null, true);
                                libraryAutomation.SetValuePattern(date.ToString("dd.MM.yy"));
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.PublicInfo);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.AnyDocumentsGr3);
                                libraryAutomation.IsEnableElements(Journal129AndJournal121.AnyPastDocumentsGr3, null, true);
                                libraryAutomation.SetValuePattern(string.Join("\r\n", allMaterial));
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.AnyDocumentsGr3);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.InstallGr6);
                                libraryAutomation.IsEnableElements(Journal129AndJournal121.InstallTextGr6);
                                if (Convert.ToDecimal(sumNedoim) < 1000)
                                {
                                    libraryAutomation.SetValuePattern(string.Format(Journal129AndJournal121.ReshTemplate1151001_1, journal.NameFace, journal.Period, journal.God,
                                           journal.DateFinishDeclaration.ToString("dd.MM.yyyy"), journal.DateStartDeclaration.ToString("dd.MM.yyyy"),
                                            ratchet, journal.NameFace));
                                }
                                else
                                {
                                    libraryAutomation.SetValuePattern(string.Format(Journal129AndJournal121.ReshTemplate1151001_2, journal.NameFace, journal.Period, journal.God,
                                          journal.DateFinishDeclaration.ToString("dd.MM.yyyy"), journal.DateStartDeclaration.ToString("dd.MM.yyyy"),
                                           ratchet, sumNp, decimal.Round(sumNedoim).ToString(), sumNp, month, journal.NameFace));
                                }
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.InstallGr6);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ErrorFaceGr11);
                                if (libraryAutomation.IsEnableElements(Journal129AndJournal121.ListCashFace, null, true) != null)
                                {
                                    var listCash = libraryAutomation
                                        .SelectAutomationColrction(
                                            libraryAutomation.FindFirstElement(Journal129AndJournal121.ListCashFace))
                                        .Cast<AutomationElement>().Distinct().Where(elem => elem.Current.Name.Contains("Sanctions row")
                                        ).ToList();
                                    if (listCash.Count > 1)
                                    {
                                        AutomationElement cashDelete;
                                        while ((cashDelete = libraryAutomation.IsEnableElements(Journal129AndJournal121.ListCashFaceRowNumber1, null, false, 10)) != null)
                                        {
                                            while (true)
                                            {
                                                libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                                    .SelectAutomationColrction(cashDelete)
                                                    .Cast<AutomationElement>().First(elemr => elemr.Current.Name.Contains("Ун документа НБО")));
                                                var elem = libraryAutomation.FindFirstElement("Name:Удалить", cashDelete);
                                                libraryAutomation.ClickElement(elem);

                                                if (libraryAutomation.IsEnableElements(Journal129AndJournal121.DeleteWin, null, true) != null)
                                                {
                                                    libraryAutomation.ClickElement(libraryAutomation.IsEnableElements(Journal129AndJournal121.DeleteWin));
                                                    break;
                                                }
                                            }
                                        }
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ErrorFaceGr15);
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.AddNewErrror);
                                        libraryAutomation.IsEnableElements(Journal129AndJournal121.WinSelect1);
                                        libraryAutomation.SetValuePattern("11901013");
                                        libraryAutomation.IsEnableElements(Journal129AndJournal121.WinSelect2);
                                        libraryAutomation.SetValuePattern("11901013");
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.WinSelectOk);
                                        if (sumNedoim > 1000)
                                        {
                                            while ((cashDelete = libraryAutomation.IsEnableElements(Journal129AndJournal121.ListCashFaceRowNumber1, null, false, 10)) != null)
                                            {
                                                var summSt = libraryAutomation
                                                    .SelectAutomationColrction(cashDelete)
                                                    .Cast<AutomationElement>().First(elemr => elemr.Current.Name == "Штраф, рублей");
                                                libraryAutomation.FindElement = summSt;
                                                libraryAutomation.SetValuePattern(Convert.ToString(decimal.Round(sumNedoim)));
                                                break;
                                            }
                                        }
                                    }
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ErrorFaceGr15);
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.AddNewCircumstance);
                                    libraryAutomation.IsEnableElements(Journal129AndJournal121.WinSelectCircumstance1);
                                    libraryAutomation.SetValuePattern("отсутствие обстоятельств");
                                    libraryAutomation.IsEnableElements(Journal129AndJournal121.WinSelectCircumstance2);
                                    libraryAutomation.SetValuePattern("22");
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.WinSelectCircumstanceOk);
                                }
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ErrorFaceGr11);
                                libraryAutomation.SelectItemCombobox(libraryAutomation.IsEnableElements(Journal129AndJournal121.FaceNameSignGr15), senderSelect.SenderTaxJournalOkp2.NameUser, 0);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Save);
                                while (true)
                                {
                                    if (libraryAutomation.IsEnableElements(Journal129AndJournal121.SignAll, null, true) != null)
                                    {
                                        break;
                                    }
                                }
                                //PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SignAll);
                                //Если есть просрочка то не отправляем документ плательщику 
                                //SaveSendDoc(libraryAutomation, journal, "Решение успешно выставлено!!!", "Решение");
                                WindowsAis3 win = new WindowsAis3();
                                AutoItX.Sleep(500);
                                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                                AutoItX.Sleep(500);
                                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);  //Доработка закрытия
                                //if (libraryAutomation.IsEnableElements(Journal129AndJournal121.ClosedComplex121, null, false, 5) != null)
                                //{
                                //    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ClosedComplex121);
                                //    AutoItX.WinWait(Journal129AndJournal121.WinNameComplex);
                                //    AutoItX.WinActivate(Journal129AndJournal121.WinNameComplex);
                                //    LibraryAutomations libraryAutomationWin = new LibraryAutomations(Journal129AndJournal121.WinNameComplex);
                                //    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomationWin, Journal129AndJournal121.WinOkCloseComplex);
                                //}
                                //else
                                //{
                                //    WindowsAis3 winClose = new WindowsAis3();
                                //    AutoItX.Sleep(1000);
                                //    AutoItX.MouseClick(ButtonConstant.MouseLeft, winClose.WindowsAis.X + winClose.WindowsAis.Width - 20, winClose.WindowsAis.Y + 160);
                                //}
                                break;
                            }
                        }

                    }
                }
            }
            AutoItX.Sleep(1000);
        }


        /// <summary>
        /// Метод создания Актов Решений Извещений по КНД 1152017
        /// </summary>
        /// <param name="libraryAutomation">Библиотека Автомата</param>
        /// <param name="listDocMemo">Лист Документов Акты Решения Извещения </param>
        /// <param name="journal">Журнал</param>
        /// <param name="datePicker">Дата вызова плательщика</param>
        /// <param name="senderSelect">Подписант документа</param>
        /// <param name="dateCloseValidation">Дата окончания проверки</param>
        /// <param name="sumNp">Сумма по данным НП</param>
        /// <param name="colorError">Цвет 5 элемента если белый проставляем нарушения не выявлены</param>
        public void CreateForm1152017(LibraryAutomations libraryAutomation, AutomationElement[] listDocMemo, TaxJournal121 journal, DatePickerAdd datePicker, DepartamentOtdel senderSelect, DateTime? dateCloseValidation, string sumNp, string colorError)
        {

        }


        /// <summary>
            /// Отправка в A01
            /// </summary>
            /// <param name="libraryAutomation">Библиотека Автомата</param>
            public void SendA01(LibraryAutomations libraryAutomation)
        {
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SendA01);
                while (true)
                {
                    AutoItX.WinWait("Отправка документов");
                    var libAuto = new LibraryAutomations("Отправка документов");
                    if (libAuto.IsEnableElements(Journal129AndJournal121.CloseA01, null, true) != null)
                    {
                        libAuto.ClickElements(Journal129AndJournal121.CloseA01, null, false, 25, -30, 30);
                        break;
                    }
                }
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.WinA01Ok);
        }

        /// <summary>
        /// Проставить даты вручения по документам!
        /// </summary>
        /// <param name="libraryAutomation">Библиотека Автомата</param>
        /// <param name="taxJournalDelivery">Журнал отправки</param>
        public void AddDateDelivery(LibraryAutomations libraryAutomation, ref TaxJournalDelivery taxJournalDelivery)
        {
            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.DocumentSendDelivery);
            var dateSend = IsWeekends(taxJournalDelivery.DateDocument.AddWorkdays(5));
            var dateDelivery = IsWeekends(dateSend.AddWorkdays(6));
            taxJournalDelivery.DateSend = dateSend;
            taxJournalDelivery.DateDelivery = dateDelivery;
            while (true)
            {
                if (libraryAutomation.IsEnableElements(Journal129AndJournal121.WinSendAndSend, null, true) != null)
                {
                    
                    libraryAutomation.SetValuePattern(dateSend.ToString("dd.MM.yy"));
                    libraryAutomation.IsEnableElements(Journal129AndJournal121.WinSendAndDelivery, null, true);
                    libraryAutomation.SetValuePattern(dateDelivery.ToString("dd.MM.yy"));
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.WindowSave);
                    break;
                }
            }
        }




        /// <summary>
        /// Если выходные то плюсуем
        /// </summary>
        /// <param name="dateTime">Дата для проверки выходного дня</param>
        /// <returns></returns>
        private DateTime IsWeekends(DateTime dateTime)
        {
            if (dateTime.DayOfWeek == DayOfWeek.Saturday)
                dateTime = dateTime.AddDays(2);
            if (dateTime.DayOfWeek == DayOfWeek.Sunday)
                dateTime = dateTime.AddDays(1);
            return dateTime;
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
        /// <param name="isClose">Отправить или закрыть</param>
        /// <param name="sender">Подписант на форме документа</param>
        private void SaveSendDoc(LibraryAutomations libraryAutomation, TaxJournal121 journal,string messageInfo,string typeDocument, bool isClose = false, string sender = null)
        {
            Okp2GlobalFunction globalFunction = new Okp2GlobalFunction();
            globalFunction.SignAndSendDoc(libraryAutomation, isClose, sender);
            journal.IsLk3 = globalFunction.IsLk3;
            journal.IsMail = globalFunction.IsMail;
            journal.IsTks = globalFunction.IsTks;
            journal.MessageInfo = messageInfo;
            journal.TypeDocument = typeDocument;
            globalFunction.AddFile(ref journal, PathTempSave);
            SaveDocument(journal);
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
        /// <summary>
        /// Метод для ОКП 5 создание шаблона извещений
        /// </summary>
        /// <param name="libraryAutomations">Библиотека автоматизации</param>
        /// <param name="elementGrid">Список Grid</param>
        /// <param name="templateText">Шаблон</param>
        /// <returns></returns>
        private List<string> ReturnMaterial(LibraryAutomations libraryAutomations, IEnumerable<AutomationElement> elementGrid, string templateText)
        {
            var listMaterial = new List<string>();
            if (elementGrid == null) return null;
            elementGrid.Select(x => libraryAutomations.SelectAutomationColrction(x).Cast<AutomationElement>()).ToList().ForEach(doc =>
            {
                string dateDoc = null;
                string number = null;
                doc.ToList().ForEach(model =>
                {
                    switch (model.Current.Name)
                    {
                        case "Дата документа":
                            dateDoc = libraryAutomations.ParseElementLegacyIAccessiblePatternIdentifiers(model);
                            break;
                        case "Номер":
                            number = libraryAutomations.ParseElementLegacyIAccessiblePatternIdentifiers(model);
                            break;
                    }
                });
                listMaterial.Add(string.Format(templateText, number, dateDoc));
            });
            return listMaterial;
        }
        /// <summary>
        /// Сохранение журнала Отправки вручения документа
        /// </summary>
        /// <param name="taxJournalDelivery">Журнал отправки вручения документа!</param>
        public void SaveAndUpdateDocumet(TaxJournalDelivery taxJournalDelivery)
        {
            var dbAutomation = new AddObjectDb();
            dbAutomation.AddAndUpdateTaxJournalDelivery(taxJournalDelivery);
            dbAutomation.Dispose();
        }

        

        /// <summary>
        /// Сохранение документа в БД
        /// </summary>
        /// <param name="journal">Журнал</param>
        private void SaveDocument(TaxJournal121 journal)
        {
            var dbAutomation = new AddObjectDb();
            dbAutomation.AddTaxJournal121(journal);
            dbAutomation.Dispose();
        }
        /// <summary>
        /// Регистрационный номер декларации
        /// </summary>
        /// <param name="regNumber">Регистрационный нjvth</param>
        /// <returns></returns>
        private TaxJournal121 SelectJournal(int? regNumber)
        {
            var dbAutomation = new AddObjectDb();
            var model = dbAutomation.SelectJournal(regNumber);
            dbAutomation.Dispose();
            return model;
        }
        /// <summary>
        /// Gдстановка признака выявлены ли нарушения или нет
        /// </summary>
        /// <param name="libraryAutomation">Библиотека Автомата</param>
        /// <param name="dateEnd">Дата которую надо подставить</param>
        /// <param name="textErrorAndNotError">Выбранный текст</param>
        private void DialogKnp(LibraryAutomations libraryAutomation,DateTime dateEnd,string textErrorAndNotError)
        {
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
                            libraryAutomationSign.DateControlComboboxNotValue(dateEnd);
                            libraryAutomationSign.SelectItemCombobox(libraryAutomationSign.IsEnableElements(Journal129AndJournal121.ComboBoxError), textErrorAndNotError);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomationSign, Journal129AndJournal121.OkEdit);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomationSign, Journal129AndJournal121.WarningOk);
                            AutoItX.Sleep(1000);
                            break;
                        }
                    }
                    break;
                }
            }
        }
     

        /// <summary>
        /// Закрыть подчиненные формы
        /// </summary>
        private void MouseCloseFormRsb(int countClose)
        {
            WindowsAis3 win = new WindowsAis3();
            while (countClose>0)
            {
                AutoItX.Sleep(1000);
                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                countClose--;
            }
        }
    }
    /// <summary>
    /// Прибавляем рабочие дни
    /// </summary>
    public static class DateTimeExtensions
    {
        public static DateTime AddWorkdays(this DateTime originalDate, int workDays)
        {
            DateTime tmpDate = originalDate;
            while (workDays > 0)
            {
                tmpDate = tmpDate.AddDays(1);
                if (tmpDate.DayOfWeek < DayOfWeek.Saturday &&
                    tmpDate.DayOfWeek > DayOfWeek.Sunday &&
                    !tmpDate.IsHoliday())
                    workDays--;
            }
            while (workDays < 0)
            {
                tmpDate = tmpDate.AddDays(-1);
                if (tmpDate.DayOfWeek < DayOfWeek.Saturday &&
                    tmpDate.DayOfWeek > DayOfWeek.Sunday &&
                    !tmpDate.IsHoliday())
                    workDays++;
            }
            return tmpDate;
        }
        /// <summary>
        /// Праздничный день
        /// </summary>
        /// <param name="originalDate">Дата</param>
        /// <returns></returns>
        public static bool IsHoliday(this DateTime originalDate)
        {
            var dbAutomation = new AddObjectDb();
            var isHoliday = dbAutomation.IsHolidays(originalDate);
            dbAutomation.Dispose();
            return isHoliday;
        }
    }

}
