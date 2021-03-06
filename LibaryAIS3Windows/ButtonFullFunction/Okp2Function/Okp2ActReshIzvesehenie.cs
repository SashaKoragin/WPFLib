﻿using System;
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
        public void CreateForm1151085(LibraryAutomations libraryAutomation, AutomationElement[] listDocMemo, TaxJournal121 journal, DatePickerAdd datePicker, string senderSelect, DateTime? dateCloseValidation)
        {
            LibraryAutomations libraryAutomationDoc = new LibraryAutomations(WindowsAis3.AisNalog3);
            var allMaterial = new List<string>();
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
                    dateVAdd = dateVAdd.AddDays(5);
                }
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.AktNo);
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Established);
                libraryAutomation.FindFirstElement(Journal129AndJournal121.EstablishedNote);
                //Проверка КНД Выставляем шаблон
                libraryAutomation.SetValuePattern(string.Format(Journal129AndJournal121.AktTemplate1151085, journal.Period, journal.God, journal.DateFinishDeclaration.ToString("dd.MM.yyyy"), journal.DateStartDeclaration.ToString("dd.MM.yyyy")));
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
                            if (libraryAutomation.IsEnableElements(Journal129AndJournal121.FaceNameGr14, null, true) != null)
                            {
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.AnyDocumentsGr3);
                                libraryAutomation.IsEnableElements(Journal129AndJournal121.AnyPastDocumentsGr3, null, true);
                                libraryAutomation.SetValuePattern(string.Join("\r\n", allMaterial));
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.AnyDocumentsGr3);
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
        public void CreateForm1151006(LibraryAutomations libraryAutomation, AutomationElement[] listDocMemo, TaxJournal121 journal, DatePickerAdd datePicker,string senderSelect, DateTime? dateCloseValidation)
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
        public void CreateForm1151111(LibraryAutomations libraryAutomation, AutomationElement[] listDocMemo, TaxJournal121 journal, DatePickerAdd datePicker, string senderSelect, DateTime? dateCloseValidation, string summNp, string colorError)
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
                                SaveSendDoc(libraryAutomation, journal, "Акт успешно выставлено!!!", "Акт", 0, 0);
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
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ReshNo);
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
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.FaceNameGr14);
                                    libraryAutomation.SelectItemCombobox(libraryAutomation.IsEnableElements(Journal129AndJournal121.FaceNameSignGr14), senderSelect, 0);
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Save);
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SignAll);
                                    //Если есть просрочка то не отправляем документ плательщику 
                                    if (journal.IsPriznak)
                                    {
                                        SaveSendDoc(libraryAutomation, journal, "Решение успешно выставлено!!!", "Решение", 0, 0);
                                    }
                                    else
                                    {
                                        SaveSendDoc(libraryAutomation, journal, "Решение успешно выставлено!!!", "Решение");
                                    }
                                    WindowsAis3 win = new WindowsAis3();
                                    AutoItX.Sleep(1000);
                                    AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ClosedComplex121);
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
        /// Метод закрытия комплекса менроприятий КНП 1151020
        /// </summary>
        /// <param name="libraryAutomation">Библиотека Автомата</param>
        /// <param name="journal">Журнал</param>
        public void CreateForm1151020(LibraryAutomations libraryAutomation, TaxJournal121 journal)
        {
            if (journal.GlobalProcessColor == "ff0000")
            {
                return;
            }
            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.StartKnp);
            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ClosedComplex121);
            AutoItX.Sleep(2000);
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
                    var libAyto = new LibraryAutomations("Отправка документов");
                    if (libAyto.IsEnableElements(Journal129AndJournal121.CloseA01, null, true) != null)
                    {
                        libAyto.ClickElements(Journal129AndJournal121.CloseA01, null, false, 25, -30, 30);
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
        /// <param name="x">Координата смещения x для отправки</param>
        /// <param name="y">Координата смещения y для отправки</param>
        private void SaveSendDoc(LibraryAutomations libraryAutomation, TaxJournal121 journal,string messageInfo,string typeDocument, int x = -30, int y = 30)
        {
            Okp2GlobalFunction globalFunction = new Okp2GlobalFunction();
            globalFunction.SignAndSendDoc(libraryAutomation,x,y);
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


    }
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
            return tmpDate;
        }

        public static bool IsHoliday(this DateTime originalDate)
        {
            // INSERT YOUR HOlIDAY-CODE HERE!
            return false;
        }
    }

}
