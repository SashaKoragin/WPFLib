using System;
using System.Linq;
using System.Windows.Automation;
using AisPoco.Ifns51.ToAis;
using AutoIt;
using EfDatabaseAutomation.Automation.Base;
using EfDatabaseAutomation.Automation.BaseLogica.AddObjectDb;
using EfDatabaseAutomation.Automation.BaseLogica.SqlSelect.SelectAll;
using LibraryAIS3Windows.AutomationsUI.LibaryAutomations;
using LibraryAIS3Windows.AutomationsUI.Otdels.PublicJournal129And121;
using LibraryAIS3Windows.ButtonFullFunction.Okp2Function;
using LibraryAIS3Windows.Window;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using ViewModelLib.ModelTestAutoit.PublicModel.ModelDatePickerAdd;

namespace LibraryAIS3Windows.ButtonFullFunction.OkpTaxJournal129
{
    public class OkpTaxJournal129Full
    {

        /// <summary>
        /// Автомат для ветки Налоговое администрирование\Контрольная работа (налоговые проверки)\129. Налоговые правонарушения\2. Журнал налоговых правонарушений
        /// ОКП 2 ОКП 5 ОКП 7
        /// </summary>
        /// <param name="statusButton">Кнопка Старт</param>
        /// <param name="pathPdfTemp">Путь к Temp</param>
        /// <param name="datePicker">Дата вызова плательщика</param>
        /// <param name="templateModel">Модель шаблона для номера</param>
        public void TaxJournal29AllAlgorithm(StatusButtonMethod statusButton, string pathPdfTemp, DatePickerAdd datePicker, TemplateModel templateModel)
        {
            Okp2GlobalFunction globalFunction = new Okp2GlobalFunction();
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            AddObjectDb dbAutomation = new AddObjectDb();
            LibraryAutomations libraryAutomationDoc = new LibraryAutomations(WindowsAis3.AisNalog3);
            var senderSelect = new SelectAll().SelectSenderJournal(Environment.UserName);
            string[] minutesList = { "00", "15", "30", "45" };
            string[] hoursList = { "10", "11", "12", "14", "15", "16" };
            if (senderSelect == null)
            {
                throw new InvalidOperationException($"Пользователь подписывающий документ не определен!");
            }
            var rowNumber = 1;
            libraryAutomation.ClickElements(Journal129AndJournal121.UpdateData);
            AutomationElement automationElement;
            while ((automationElement =
                       libraryAutomation.IsEnableElements(
                           string.Concat(Journal129AndJournal121.AllTaxJournal, rowNumber), null, false, 50)) != null)
            {
                var taxFace = new TaxJournal();
                if (statusButton.Iswork)
                {
                    automationElement.SetFocus();
                    AutoItX.Sleep(1000);
                    taxFace.LoginUser = Environment.UserName;
                    taxFace.IdDelo = Convert.ToInt32(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("УН дела"))));
                    taxFace.DateError = Convert.ToDateTime(
                        libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                            libraryAutomation
                                .SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>()
                                .First(elem => elem.Current.Name.Contains("Дата обнаружения нарушения"))));
                    taxFace.Inn = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                        .SelectAutomationColrction(automationElement)
                        .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("ИНН")));
                    taxFace.Kpp = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("КПП")));

                    var state = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Статья НК нарушения")));

                    taxFace.NameFace = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Лицо")));
                    taxFace.Fid = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("ФИД НП")));
                    var status = libraryAutomation.SelectAutomationColrction(automationElement)
                        .Cast<AutomationElement>()
                        .Where(automationElemenst => automationElemenst.Current.Name != "Column Headers")
                        .First(elem => elem.Current.Name.Contains(""));
                    var color = libraryAutomation.GetColorPixel(status);
                    taxFace.Color = color;

                    var panel = libraryAutomation.SelectAutomationColrction(libraryAutomation.IsEnableElements(Journal129AndJournal121.SelectDocPanel)).Cast<AutomationElement>().ToArray();
                    var tab = libraryAutomation.SelectAutomationColrction(libraryAutomation.IsEnableElements(Journal129AndJournal121.DetalTabs, panel[1])).Cast<AutomationElement>().ToArray();
                    //Поиск и нажатие на Исходящие документы
                    while (true)
                    {
                        if (libraryAutomation.IsEnableElements($"Name:{tab[1].Current.Name}", panel[1], false, 1) != null)
                        {
                            libraryAutomation.ClickElements($"Name:{tab[1].Current.Name}", panel[1], false, 1);
                            //AutoItX.Sleep(2000);
                        }
                        var grid = PublicGlobalFunction.PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation, Journal129AndJournal121.JournalIsh, panel[1]); //Здесь баг если ошибка обновляем данные нужно кидать на обновить кнопку до 3 раз
                        if (string.IsNullOrWhiteSpace(grid))
                        {
                            break;
                        }
                        if (grid == "Данные, удовлетворяющие заданным условиям не найдены.")
                        {
                            break;
                        }
                        libraryAutomation.ClickElements($"Name:{tab[2].Current.Name}", panel[1], false, 1);
                    }
                    switch (color)
                    {
                        case "ff":



                            //Реестр всех документов
                            var listDocMemo = libraryAutomationDoc
                                .SelectAutomationColrction(
                                    libraryAutomationDoc.FindFirstElement(Journal129AndJournal121.DocAllJournal))
                                .Cast<AutomationElement>().Distinct()
                                .Where(elem => elem.Current.Name.Contains("select0 row"));

                            //Желтый акт или Зеленый отбор
                            var isActYellowAndGreen = listDocMemo.FirstOrDefault(doc =>
                                libraryAutomationDoc.ParseElementLegacyIAccessiblePatternIdentifiers(
                                    libraryAutomationDoc.SelectAutomationColrction(doc).Cast<AutomationElement>()
                                        .First(elem => elem.Current.Name.Contains("КНД"))) == "1160100" &&
                                libraryAutomationDoc.GetColorPixel(libraryAutomationDoc.SelectAutomationColrction(doc)
                                    .Cast<AutomationElement>()
                                    .Where(automationElemenst => automationElemenst.Current.Name != "Column Headers")
                                    .First(elem => elem.Current.Name.Contains(""))) == "8000" ||
                                libraryAutomationDoc.GetColorPixel(libraryAutomationDoc.SelectAutomationColrction(doc)
                                    .Cast<AutomationElement>()
                                    .Where(automationElemenst => automationElemenst.Current.Name != "Column Headers")
                                    .First(elem => elem.Current.Name.Contains(""))) == "ffff00"
                            );
                            //Выбор отсутствует ли извещение
                            var isIzvestia = listDocMemo.FirstOrDefault(doc =>
                                libraryAutomationDoc.ParseElementLegacyIAccessiblePatternIdentifiers(
                                    libraryAutomationDoc.SelectAutomationColrction(doc).Cast<AutomationElement>()
                                        .First(elem => elem.Current.Name.Contains("КНД"))) == "1165213");

                            //Зеленый акт отбор
                            var isActGreen = listDocMemo.FirstOrDefault(doc =>
                                libraryAutomationDoc.ParseElementLegacyIAccessiblePatternIdentifiers(
                                    libraryAutomationDoc.SelectAutomationColrction(doc).Cast<AutomationElement>()
                                        .First(elem => elem.Current.Name.Contains("КНД"))) == "1160100" &&
                                libraryAutomationDoc.GetColorPixel(libraryAutomationDoc.SelectAutomationColrction(doc)
                                    .Cast<AutomationElement>()
                                    .Where(automationElemenst => automationElemenst.Current.Name != "Column Headers")
                                    .First(elem => elem.Current.Name.Contains(""))) == "8000"
                            );

                            //Выбор зеленого извещение
                            var isIzvestiaGreen = listDocMemo.FirstOrDefault(doc =>
                                libraryAutomationDoc.ParseElementLegacyIAccessiblePatternIdentifiers(
                                    libraryAutomationDoc.SelectAutomationColrction(doc).Cast<AutomationElement>()
                                        .First(elem => elem.Current.Name.Contains("КНД"))) == "1165213" &&
                                libraryAutomationDoc.GetColorPixel(libraryAutomationDoc.SelectAutomationColrction(doc)
                                    .Cast<AutomationElement>()
                                    .Where(automationElemenst => automationElemenst.Current.Name != "Column Headers")
                                    .First(elem => elem.Current.Name.Contains(""))) == "8000"
                            );

                            //Есть ли наличие решения
                            var isReshenie = listDocMemo.FirstOrDefault(doc =>
                                libraryAutomationDoc.ParseElementLegacyIAccessiblePatternIdentifiers(
                                    libraryAutomationDoc.SelectAutomationColrction(doc).Cast<AutomationElement>()
                                        .First(elem => elem.Current.Name.Contains("КНД"))) == "1165022"
                            );

                            //Выставление извещений
                            if (isActYellowAndGreen != null && isIzvestia == null)
                            {
                                //Обработка Отсутствует извещение но есть акт желтый статус
                                libraryAutomation.ClickElements(Journal129AndJournal121.OpenComplex, null, true);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Izveshenie);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.IzveshenieAkt);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ButtonSved);
                                var hours = hoursList[new Random().Next(0, hoursList.Length)];
                                var minute = minutesList[new Random().Next(0, minutesList.Length)];
                                var createDocument = DateTime.Now;
                                createDocument = createDocument.AddWorkdays(5);
                                createDocument = createDocument.AddMonths(1);
                                createDocument = createDocument.AddWorkdays(5);
                                //Уходим от выходных 
                                createDocument = IsWeekends(createDocument);
                                taxFace.DateIzveshenie = createDocument;
                                globalFunction.AddDataAndTimeInvoke(libraryAutomation, senderSelect.Office, createDocument, hours, minute);
                                //Подписание
                                while (true)
                                {
                                    if (libraryAutomation.IsEnableElements(Journal129AndJournal121.FaceName, null, true) != null)
                                    {
                                        libraryAutomation.ClickElements(Journal129AndJournal121.FaceName, null, true);
                                        libraryAutomation.IsEnableElements(Journal129AndJournal121.FaceNameSign);
                                        libraryAutomation.SetValuePattern(senderSelect.SenderTaxJournalOkp2.NameUser);
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Save);
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SignAll);
                                        break;
                                    }
                                }
                                globalFunction.SignAndSendDoc(libraryAutomation);
                                taxFace.IsLk3 = globalFunction.IsLk3;
                                taxFace.IsMail = globalFunction.IsMail;
                                taxFace.IsTks = globalFunction.IsTks;
                                while (true)
                                {
                                    if (libraryAutomation.IsEnableElements(Journal129AndJournal121.FaceName, null, true) != null)
                                    {
                                        break;
                                    }
                                }
                                globalFunction.SendJournalClose();
                                taxFace.MessageInfo = "Извещение успешно выставлено!!!";
                                taxFace.TypeDocument = "Извещение";
                                globalFunction.AddFile(ref taxFace, pathPdfTemp);
                                dbAutomation.AddTaxJournal(taxFace);
                            }
                            else
                            {
                                //Выставление решений        isActGreen != null && isIzvestiaGreen != null &&                     
                                if (isReshenie == null && isActGreen!=null && isIzvestiaGreen!=null)
                                {
                                    var dateAct = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                                                   .SelectAutomationColrction(isActYellowAndGreen)
                                                                   .Cast<AutomationElement>().First(elem => elem.Current.Name == "Дата"));

                                    var numberAct = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                                                .SelectAutomationColrction(isActYellowAndGreen)
                                                                .Cast<AutomationElement>().First(elem => elem.Current.Name == "Номер"));

                                    //Обработка присутствует Акт и извещение зеленое
                                    //Решение надо делать так как вход изменился
                                    libraryAutomation.ClickElements(Journal129AndJournal121.OpenComplex, null, true);
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.OpenReshenia);
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, statusButton.IsChekcs ? Journal129AndJournal121.Reshenia : Journal129AndJournal121.ResheniaCancel);
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.PublicInfo);
                                    while (true)
                                    {
                                        if (libraryAutomation.IsEnableElements(Journal129AndJournal121.DateReshenia119, null, true) != null)
                                        {
                                            taxFace.DateIzveshenie = datePicker.DateResh;
                                            libraryAutomation.SetValuePattern(datePicker.DateResh.ToString("dd.MM.yy"));
                                            if (!statusButton.IsChekcs)
                                            {
                                                //Решение об отказе
                                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Install);
                                                while (true)
                                                {
                                                    if (libraryAutomation.IsEnableElements(Journal129AndJournal121.InstallAdd, null, true) != null)
                                                    {
                                                        libraryAutomation.FindFirstElement(Journal129AndJournal121.InstallAdd);
                                                        break;
                                                    }
                                                }
                                                libraryAutomation.SetValuePattern(string.Format(Journal129AndJournal121.InfoAct, numberAct, dateAct)); // Решение об отказе
                                            }
                                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ResheniaFaceSignOpen);
                                            libraryAutomation.IsEnableElements(Journal129AndJournal121.ResheniaFaceSendSign);
                                            libraryAutomation.SetValuePattern(senderSelect.SenderTaxJournalOkp2.NameUser);
                                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Save);
                                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SignAll);
                                            break;
                                        }
                                    }
                                    globalFunction.SignAndSendDoc(libraryAutomation);
                                    taxFace.IsLk3 = globalFunction.IsLk3;
                                    taxFace.IsMail = globalFunction.IsMail;
                                    taxFace.IsTks = globalFunction.IsTks;
                                    while (true)
                                    {
                                        if (libraryAutomation.IsEnableElements(Journal129AndJournal121.ErrorGroup5, null, true) != null)
                                        {
                                            break;
                                        }
                                    }
                                    globalFunction.SendJournalClose();
                                    taxFace.MessageInfo = "Решение успешно выставлено!!!";
                                    taxFace.TypeDocument = "Решение";
                                    globalFunction.AddFile(ref taxFace, pathPdfTemp);
                                    dbAutomation.AddTaxJournal(taxFace);
                                }
                            }
                            break;
                        case "ff0000":
                            libraryAutomation.ClickElements(Journal129AndJournal121.OpenComplex, null, true);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.EditTask1);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.EditTask2);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.EditTask3);
                            if (templateModel.IdTemplate != 1)
                            {
                                //Подстановка Номер изменить КВВ-{19123}/15-13 параметр + Дата акта +1 день
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ErrorGroup0);
                                libraryAutomation.FindElement = libraryAutomation.SelectAutomationColrction(libraryAutomation.IsEnableElements(Journal129AndJournal121.ErrorGroup0Number, null, true))[3];
                                var numberElement = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.FindElement);
                                libraryAutomation.SetValuePattern(templateModel.NameTemplate.Replace("{numberDocument}", numberElement));
                                if (state != "88")
                                {
                                    if (libraryAutomation.IsEnableElements(Journal129AndJournal121.ErrorGroup0DataAct, null, true) != null)
                                    {
                                        var dataElement = Convert.ToDateTime(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.FindElement));
                                        var date = dataElement.AddWorkdays(1);
                                        libraryAutomation.SetValuePattern(date.ToString("dd.MM.yyyy"));
                                    }
                                }
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ErrorGroup0);
                            }
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ErrorGroup3);
                            globalFunction.AddCircumstance(libraryAutomation);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ErrorGroup3);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SignAll);
                            globalFunction.SignAndSendDoc(libraryAutomation);
                            taxFace.IsLk3 = globalFunction.IsLk3;
                            taxFace.IsMail = globalFunction.IsMail;
                            taxFace.IsTks = globalFunction.IsTks;
                            while (true)
                            {
                                if (libraryAutomation.IsEnableElements(Journal129AndJournal121.ErrorGroup3, null, true) != null)
                                {
                                    break;
                                }
                            }
                            globalFunction.SendJournalClose();
                            taxFace.MessageInfo = "Акт успешно выставлен!!!";
                            taxFace.TypeDocument = "Акт";
                            globalFunction.AddFile(ref taxFace, pathPdfTemp);
                            dbAutomation.AddTaxJournal(taxFace);
                            break;
                        default:
                            taxFace.MessageInfo = "Цвет обработки не определен";
                            dbAutomation.AddTaxJournal(taxFace);
                            break;
                    }
                }
                else
                {
                    break;
                }
                rowNumber++;
            }
        }

        /// <summary>
        /// Если выходные то плюс дней до будней
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
    }
}
