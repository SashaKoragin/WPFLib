using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Windows.Automation;
using AutoIt;
using EfDatabaseAutomation.Automation.Base;
using EfDatabaseAutomation.Automation.BaseLogica.AddObjectDb;
using LibraryAIS3Windows.AutomationsUI.LibaryAutomations;
using LibraryAIS3Windows.AutomationsUI.Otdels.PublicJournal129And121;
using LibraryAIS3Windows.ButtonsClikcs;
using LibraryAIS3Windows.Window;
using ViewModelLib.ModelTestAutoit.PublicModel.ModelDatePickerAdd;
using LibraryAIS3Windows.AutomationsUI.PublicElement;
using System.Windows.Forms;
using EfDatabaseAutomation.Automation.BaseLogica.SqlSelect.SelectAll;
using LibraryAIS3Windows.ButtonFullFunction.Okp3Function;
using LibraryAIS3Windows.ButtonFullFunction.PreCheck;
using LibraryAIS3Windows.ButtonFullFunction.RaschBydjFunction;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using System.Text.RegularExpressions;

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
        private readonly string[] minutesList = { "00", "15", "30", "45" };
        /// <summary>
        /// Часы
        /// </summary>
        private readonly string[] hoursList = { "10", "11", "12", "14", "15", "16" };

        /// <summary>
        /// Путь Сохранения Документа как правило Temp Пользователя
        /// По формам КНД 1151085 и КНД 1151006
        /// </summary>
        private string PathTempSave { get; }
        /// <summary>
        /// Путь для проверки почты
        /// </summary>
        private string PathMailDecl = "Налоговое администрирование\\Контрольная работа (налоговые проверки)\\101. Мониторинг и обработка документов\\Реестр документов НБО";
        /// <summary>
        ///  Ветка для поиска повторного правонарушения
        /// </summary>
        private string PathAllDocument = "Налоговое администрирование\\Контрольная работа (налоговые проверки)\\121. Камеральная налоговая проверка\\04. Журнал документов, выписанных в ходе налоговой проверки";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pathTemp">Путь Сохранения Документа как правило Temp Пользователя</param>
        public Okp2ActAndSolutionAndNotification(string pathTemp)
        {
            PathTempSave = pathTemp;
        }
        /// <summary>
        /// Проведение камеральных проверок по КНД (1151085, 1151006, 1151111, 1151020, 1151001, 1152017) Акты Извещения Решения
        /// </summary>
        /// <param name="statusButton">Кнопка Старт</param>
        /// <param name="datePicker">Дата вызова плательщика</param>
        public void CreateFullFormMethod(StatusButtonMethod statusButton, DatePickerAdd datePicker)
        {
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            var senderSelect = new SelectAll().SelectSenderJournal(Environment.UserName);
            if (senderSelect == null)
            {
                throw new InvalidOperationException($"Пользователь подписывающий документ не определен!");
            }
            var rowNumber = 1;
            libraryAutomation.ClickElements(Journal129AndJournal121.UpdateData121);
            PublicGlobalFunction.PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation, Journal129AndJournal121.GridTaxJournal121);
            AutomationElement automationElement;
            while ((automationElement =
                       libraryAutomation.IsEnableElements(
                           string.Concat(Journal129AndJournal121.AllTaxJournal121, rowNumber), null, true, 30)) != null)
            {
                var journal = new TaxJournal121();
                if (statusButton.Iswork)
                {
                    automationElement.SetFocus();
                    AutoItX.Sleep(1000);
                    journal.LoginUser = Environment.UserName;
                    journal.RegNumDeclaration = Convert.ToInt32(
                        libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem =>
                                elem.Current.Name.Contains("Рег. номер декларации (расчета)"))));
                    journal.Period = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                        .SelectAutomationColrction(automationElement)
                        .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Отчетный период")));

                    var correctNumber = Convert.ToInt32(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                        .SelectAutomationColrction(automationElement)
                        .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Номер корректировки"))));

                    journal.God = Convert.ToInt32(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Отчетный год"))));
                    journal.Knd = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                        .SelectAutomationColrction(automationElement)
                        .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("КНД")));
                    journal.NameKnd = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Документ")));

                    var sumNp = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation.SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>()
                            .First(elem => elem.Current.Name.Contains("Сумма по данным НП")));

                    //Убранно в версии 20.11.4.1 по КНД 1151111
                    //journal.Fid = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                    //    .SelectAutomationColrction(automationElement)
                    //    .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("ФИД НП")));

                    journal.NameFace = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Налогоплательщик")));
                    journal.Inn = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                        .SelectAutomationColrction(automationElement)
                        .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("ИНН")));
                    journal.IdComplex = Convert.ToInt32(
                        libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("УН комплекса"))));

                    var dateFinishCheck = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                  .SelectAutomationColrction(automationElement)
                                  .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Срок проверки по регламенту")));

                    journal.DateFinishCheck = string.IsNullOrWhiteSpace(dateFinishCheck)
                       ? DateTime.Now
                       : Convert.ToDateTime(dateFinishCheck);

                    var dateEnd = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                        .SelectAutomationColrction(automationElement)
                        .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Окончание срока")));
                    journal.DateFinishKnp = string.IsNullOrWhiteSpace(dateEnd)
                        ? (DateTime?)null
                        : Convert.ToDateTime(dateEnd);

                    if (correctNumber != 0)
                    {
                        journal.DateStartCheck = Convert.ToDateTime(
                            libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                .SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>()
                                .First(elem => elem.Current.Name.Contains("Дата представления первичной декларации"))));
                    }
                    else
                    {
                        journal.DateStartCheck = Convert.ToDateTime(
                            libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                .SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>()
                                .First(elem => elem.Current.Name.Contains("Дата начала проверки"))));
                    }

                    journal.DateStartDeclaration = Convert.ToDateTime(
                        libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                             .SelectAutomationColrction(automationElement)
                             .Cast<AutomationElement>()
                             .First(elem => elem.Current.Name.Contains("Дата представления декларации"))));
                    journal.DateFinishDeclaration = Convert.ToDateTime(
                        libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>()
                            .First(elem => elem.Current.Name.Contains("Срок  представления декларации"))));
                    var status = libraryAutomation.SelectAutomationColrction(automationElement)
                        .Cast<AutomationElement>().Where(automationElemenst => automationElemenst.Current.Name == "")
                        .ToList();

                    var dateEndValidation = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>()
                            .First(elem => elem.Current.Name.Contains("Дата окончания проверки")));
                    var dateCloseValidation = string.IsNullOrWhiteSpace(dateEndValidation)
                        ? (DateTime?)null
                        : Convert.ToDateTime(dateEndValidation);

                    journal.GlobalColor = libraryAutomation.GetColorPixel(status[1]);
                    journal.GlobalProcessColor = libraryAutomation.GetColorPixel(status[2]);
                    var colorComplex = libraryAutomation.GetColorPixel(status[3]);
                    var colorError = libraryAutomation.GetColorPixel(status[4]);
                    var panel = libraryAutomation.SelectAutomationColrction(libraryAutomation.IsEnableElements(Journal129AndJournal121.PanelDoc)).Cast<AutomationElement>().ToArray();
                    var tab = libraryAutomation.SelectAutomationColrction(libraryAutomation.IsEnableElements(Journal129AndJournal121.DetalTabs, panel[1])).Cast<AutomationElement>().ToArray();
                    //Поиск и нажатие на Исходящие документы
                    var oktmo = "";
                    while (true)
                    {
                        if (libraryAutomation.IsEnableElements($"Name:{tab[7].Current.Name}", panel[1], false, 1) != null)
                        {
                            libraryAutomation.ClickElements($"Name:{tab[7].Current.Name}", panel[1], false, 1);
                            AutoItX.Sleep(5000);
                        }
                        var grid = PublicGlobalFunction.PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation, Journal129AndJournal121.JournaOktmoCaption, panel[1]); //Здесь баг если ошибка обновляем данные нужно кидать на обновить кнопку до 3 раз
                        if (string.IsNullOrWhiteSpace(grid))
                        {
                            oktmo = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.SelectAutomationColrction(libraryAutomation.FindFirstElement(Journal129AndJournal121.JournaOktmo, panel[1]))
                                                         .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("ОКТМО")));
                            break;
                        }
                        if (grid == "Данные, удовлетворяющие заданным условиям не найдены.")
                        {
                            break;
                        }
                        libraryAutomation.ClickElements($"Name:{tab[4].Current.Name}", panel[1], false, 1);
                    }

                    //Поиск и нажатие на Исходящие документы
                    while (true)
                    {
                        if (libraryAutomation.IsEnableElements($"Name:{tab[3].Current.Name}", panel[1], false, 1) != null)
                        {
                            libraryAutomation.ClickElements($"Name:{tab[3].Current.Name}", panel[1], false, 1);
                            AutoItX.Sleep(5000);
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
                        libraryAutomation.ClickElements($"Name:{tab[4].Current.Name}", panel[1], false, 1);
                    }
                    var listDocMemo = libraryAutomation.SelectAutomationColrction(
                                       libraryAutomation.FindFirstElement(Journal129AndJournal121.JournalIsh, panel[1]))
                                       .Cast<AutomationElement>().Distinct().Where(elem => elem.Current.Name.Contains("select0 row") &&
                                       libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                       libraryAutomation.SelectAutomationColrction(elem).Cast<AutomationElement>()
                                     .First(doc => doc.Current.Name.Contains("КНД"))) != "1165050"
                                     ).ToArray();

                    //Выставляем Акты Решения и Извещения по разным КНД
                    switch (journal.Knd)
                    {
                        case "1151085": //Полностью рабочий
                            CreateForm1151085(libraryAutomation, listDocMemo, journal, datePicker, senderSelect, dateCloseValidation);
                            break;
                        case "1151006": //Не тестировался давно
                            CreateForm1151006(libraryAutomation, listDocMemo, journal, datePicker, senderSelect, dateCloseValidation);
                            break;
                        case "1151111": //Полностью рабочий
                            //Ветка Налоговое администрирование\Контрольная работа (налоговые проверки)\106. Реестр расчетов по страховым взносам и персонифицированным сведениям\Реестр расчетов по страховым взносам, сведения о КНП (все) 
                            CreateForm1151111(libraryAutomation, listDocMemo, journal, datePicker, senderSelect, dateCloseValidation, sumNp, colorError, correctNumber, oktmo);
                            break;
                        case "1151020": //Не тестировался давно
                            CreateForm1151020(libraryAutomation, listDocMemo, journal, datePicker, senderSelect, dateCloseValidation, sumNp, colorError);
                            break;
                        case "1151001": //Не тестировался давно
                            CreateForm1151001(libraryAutomation, listDocMemo, journal, datePicker, senderSelect, dateCloseValidation, Convert.ToDecimal(sumNp) >= (decimal)0.00 ? sumNp : "0,00", colorError, correctNumber, oktmo);
                            break;
                        case "1152017": //Рабочий Акт и Извещение и Решения только нулевки
                            listDocMemo = libraryAutomation.SelectAutomationColrction(
                                          libraryAutomation.FindFirstElement(Journal129AndJournal121.JournalIsh, panel[1]))
                                          .Cast<AutomationElement>().Distinct().Where(elem => elem.Current.Name.Contains("select0 row")).ToArray(); //Для этой КНД берем все и уже внутри исключаем
                            CreateForm1152017(libraryAutomation, listDocMemo, journal, datePicker, senderSelect, dateCloseValidation, Convert.ToDecimal(sumNp) >= (decimal)0.00 ? sumNp : "0,00", colorError, correctNumber, oktmo);
                            break;
                    }
                }
                else
                {
                    break;
                }
                automationElement.SetFocus();
                rowNumber++;
            }
        }


        /// <summary>
        /// Налоговое администрирование\Контрольная работа (налоговые проверки)\122. Камеральная налоговая проверка НДФЛ\04. Реестр расчетов по продаже и(или) дарению объектов недвижимости в подлежащих КНП в соответствии с п.1.2 ст. 88НК
        /// Выставление требований для категории ДП3НДФЛ для ОКП 6
        /// </summary>
        /// <param name="statusButton">Кнопка проставить Даты вручения</param>
        public void AddRequirementsDeclaration(StatusButtonMethod statusButton)
        {
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            var dataBaseAdd = new DataBaseElementAdd();
            var senderSelect = new SelectAll();
            var stringTemplate = new StringBuilder();
            var rowNumber = 1;
            libraryAutomation.ClickElements(JournalSolutionCalculations.UpdateTree);
            PublicGlobalFunction.PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation, Journal129AndJournal121.GridTaxJournal121);
            AutomationElement automationElement;
            while ((automationElement = libraryAutomation.IsEnableElements(string.Concat(Journal129AndJournal121.AllTaxJournal121, rowNumber), null, true, 30)) != null)
            {
                if (statusButton.Iswork)
                {
                    automationElement.SetFocus();
                    var declaration3NdflFl = new Declaration3NdflFl
                    {
                        ColorType1 = libraryAutomation.GetColorPixel(libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().Where(elem => elem.Current.Name == "").ToList()[0]),
                        ColorType2 = libraryAutomation.GetColorPixel(libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().Where(elem => elem.Current.Name == "").ToList()[1]),
                        ColorType3 = libraryAutomation.GetColorPixel(libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().Where(elem => elem.Current.Name == "").ToList()[2]),
                        ColorType4 = libraryAutomation.GetColorPixel(libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().Where(elem => elem.Current.Name == "").ToList()[3]),
                        ColorType5 = libraryAutomation.GetColorPixel(libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().Where(elem => elem.Current.Name == "").ToList()[4]),
                        ColorType6 = libraryAutomation.GetColorPixel(libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().Where(elem => elem.Current.Name == "").ToList()[5]),
                        RegNumDecl = Convert.ToInt32(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                            libraryAutomation
                                .SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>().First(elem =>
                                    elem.Current.Name.Contains("Регистрационный номер проверяемого документа")))),
                        NameDocument = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                            libraryAutomation
                                .SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Документ"))),
                        IdObject = Convert.ToInt64(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                            libraryAutomation
                                .SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>()
                                .First(elem => elem.Current.Name.Contains("Ун Объекта учета")))),
                        NameNp = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                     .SelectAutomationColrction(automationElement)
                                     .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Фамилия"))) +
                                 ' ' +
                                 libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                     .SelectAutomationColrction(automationElement)
                                     .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Имя"))) +
                                 ' ' +
                                 libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                     .SelectAutomationColrction(automationElement)
                                     .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Отчество"))),
                        InnNp = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("ИНН"))),
                        God = Convert.ToInt32(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                            libraryAutomation
                                .SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Отчетный год")))),
                        SummR = Convert.ToDouble(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                            libraryAutomation
                                .SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>().First(elem =>
                                    elem.Current.Name.Contains("Сумма реализованного имущества")))),
                        SummP = Convert.ToDouble(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                            libraryAutomation
                                .SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>().First(elem =>
                                    elem.Current.Name.Contains("Сумма имущества, полученного в дар")))),
                        SummV = Convert.ToDouble(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                            libraryAutomation
                                .SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>()
                                .First(elem => elem.Current.Name.Contains("Налоговый вычет")))),
                        SummPv = Convert.ToDouble(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                            libraryAutomation
                                .SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>()
                                .First(elem => elem.Current.Name.Contains("Предполагаемый налог")))),
                        SummI = Convert.ToDouble(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                            libraryAutomation
                                .SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>()
                                .First(elem => elem.Current.Name.Contains("Исчисленный налог")))),
                        LoginUser = Environment.UserName
                    };
                    if (!senderSelect.IsExistsRequirements(declaration3NdflFl.RegNumDecl))
                    {
                         PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, JournalSolutionCalculations.OpenViewDecl);
                         PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ExportDeclaration);
                         PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ExportFileOk);
                         AutoItX.ProcessWait("EXCEL.EXE", 60000);
                         AutoItX.Sleep(Convert.ToInt32(ConfigurationManager.AppSettings["Sleepeng"]));
                         PublicGlobalFunction.PublicGlobalFunction.CloseProcessProgram("EXCEL");
                         var file = PublicGlobalFunction.PublicGlobalFunction.ReturnNameLastFileTemp(PathTempSave, "*.xlsx");
                         dataBaseAdd.AddDeclaration3Ndfl(file.NamePath, ref declaration3NdflFl);
                         MouseCloseFormRsb(1);  //Закрываем форму 1 раз
                         IsStartIsOpenKm(libraryAutomation, declaration3NdflFl);
                         while (true)
                         {
                             if (libraryAutomation.IsEnableElements(JournalSolutionCalculations.TrebText, null, true) != null)
                             {
                                 AutoItX.Sleep(1000);
                                 AutoItX.MouseWheel(ButtonConstant.WheelDown, 20);
                                 PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, JournalSolutionCalculations.TrebTextButton);
                                 break;
                             }
                         }
                         PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, JournalSolutionCalculations.Group2);
                         while (true)
                         {
                              var toggle = libraryAutomation.TogglePattern(libraryAutomation.IsEnableElements(JournalSolutionCalculations.IsCheck));
                              if (toggle == "Off" || toggle == null)
                              {
                                   while (true)
                                   {
                                        if (libraryAutomation.IsEnableElements(JournalSolutionCalculations.IsCheckText, null, true) != null)
                                        {
                                             libraryAutomation.ClickElement(libraryAutomation.FindElement);
                                             break;
                                        }
                                   }
                              }
                              if (toggle == "On")
                              {
                                    AutoItX.Sleep(2000);
                                    if (libraryAutomation.IsEnableElements(JournalSolutionCalculations.RichTextBox, null, false, 40, 1) != null)
                                    {
                                        var declarationMemo = senderSelect.SelectMemoDeclaration(declaration3NdflFl.RegNumDecl);
                                        stringTemplate.Append(JournalSolutionCalculations.TemplateHead);
                                        foreach (var memo in declarationMemo.DeclarationMemo)
                                        {
                                            stringTemplate.Append(JournalSolutionCalculations.TemplateData.Replace("{П0020}", memo.П0020)
                                                .Replace("{П0148}", memo.П0148 ?? memo.П0417)
                                                .Replace("{П0031}", memo.П0031 ?? memo.П0419)
                                                .Replace("{П0033}", memo.П0033!=null?Convert.ToDateTime(memo.П0033).ToString("dd.MM.yyyy"):
                                                    memo.П0421!=null? Convert.ToDateTime(memo.П0421).ToString("dd.MM.yyyy"):null)
                                                .Replace("{П0425}", memo.П0425!=null?Convert.ToDateTime(memo.П0425).ToString("dd.MM.yyyy"):null)
                                                .Replace("{П0010}", memo.П0010 ?? memo.П0430)
                                                .Replace("{П0975}", memo.П0975));
                                        }
                                        stringTemplate.Append(JournalSolutionCalculations.TemplateStone);
                                        AutoItX.ClipPut(stringTemplate.ToString());
                                        libraryAutomation.FindElement.SetFocus();
                                        AutoItX.Send(ButtonConstant.CtrlV);
                                        break;
                                    }
                                    MouseCloseFormRsb(1);
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, JournalSolutionCalculations.WinNo);
                                    while (true)
                                    {
                                        if (libraryAutomation.IsEnableElements(JournalSolutionCalculations.EditDelete, null, true) != null)
                                        {
                                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, JournalSolutionCalculations.EditDelete);
                                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, JournalSolutionCalculations.Delete);
                                        }
                                        else { break; }
                                    }
                                    while (true)
                                    {
                                        if (libraryAutomation.IsEnableElements(JournalSolutionCalculations.TrebText, null, true, 1) != null)
                                        {
                                            AutoItX.Sleep(1000);
                                            AutoItX.MouseWheel(ButtonConstant.WheelDown, 20);
                                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, JournalSolutionCalculations.TrebTextButton);
                                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, JournalSolutionCalculations.Group2);
                                            break;
                                        }
                                    }
                              }
                         }
                         PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, JournalSolutionCalculations.Save);
                         PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, JournalSolutionCalculations.Utver);
                         ApproveSaveDoc(libraryAutomation, declaration3NdflFl, "Требование успешно выставлено!!!", "Требование");
                         dataBaseAdd.EndSaveDeclaration3Ndfl(ref declaration3NdflFl);
                         while (true)
                         {
                            if (libraryAutomation.IsEnableElements(JournalSolutionCalculations.Group2, null, true) != null)
                            {
                                break;
                            }
                         }
                         MouseCloseFormRsb(2);  //Закрытие формы 2 раза
                         PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, JournalSolutionCalculations.YesExit);
                    }
                }
                else
                {
                    break;
                }
                stringTemplate.Clear();
                rowNumber++;
            }
            senderSelect.Dispose();
        }


        /// <summary>
        /// Проведение камеральных проверок по КНД (ДП3НДФЛ) Решения
        /// Отдельный метод для ОКП 6 
        /// для ветки
        /// Налоговое администрирование\Контрольная работа (налоговые проверки)\122. Камеральная налоговая проверка НДФЛ\04. Реестр расчетов по продаже и(или) дарению объектов недвижимости в подлежащих КНП в соответствии с п.1.2 ст. 88НК
        /// </summary>
        /// <param name="statusButton">Кнопка Старт</param>
        /// <param name="datePicker">Дата вызова плательщика</param>
        public void CreateSolutionCalculationsFullFormMethod(StatusButtonMethod statusButton, DatePickerAdd datePicker)
        {
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            var senderSelect = new SelectAll().SelectSenderJournal(Environment.UserName);
            if (senderSelect == null)
            {
                throw new InvalidOperationException($"Пользователь подписывающий документ не определен!");
            }
            var rowNumber = 1;
            libraryAutomation.ClickElements(JournalSolutionCalculations.UpdateTree);
            PublicGlobalFunction.PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation, Journal129AndJournal121.GridTaxJournal121);
            AutomationElement automationElement;
            while ((automationElement = libraryAutomation.IsEnableElements(string.Concat(Journal129AndJournal121.AllTaxJournal121, rowNumber), null, true, 30)) != null)
            {

                if (statusButton.Iswork)
                {
                    automationElement.SetFocus();
                    AutoItX.Sleep(1000);
                    var knd = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                        .SelectAutomationColrction(automationElement)
                        .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Документ")));
                   
                    var status = libraryAutomation.SelectAutomationColrction(automationElement)
                        .Cast<AutomationElement>().Where(automationElemenst => automationElemenst.Current.Name == "")
                        .ToList();

                    var st1 = libraryAutomation.GetColorPixel(status[0]);
                    if(st1== "ff")
                    {
                        switch (knd)
                        {
                            case "ДП3НДФЛ":
                                CreateForm3Ndfl(libraryAutomation, senderSelect.SenderTaxJournalOkp2.NameUser);
                                break;
                        }
                    }
                }
                else
                {
                    break;
                }
                automationElement.SetFocus();
                rowNumber++;
            }
        }
        /// <summary>
        /// Выставление решений по 3 НДФЛ
        /// </summary>
        /// <param name="libraryAutomation">Библиотека Автомата</param>
        /// <param name="sender">Подписант</param>
        public void CreateForm3Ndfl(LibraryAutomations libraryAutomation, string sender)
        {
            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, JournalSolutionCalculations.OpenKnp);
            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, JournalSolutionCalculations.ButtonEdit);
            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, JournalSolutionCalculations.Calculations);
            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, JournalSolutionCalculations.Confirm);
            AutoItX.Sleep(2000);
            if (libraryAutomation.IsEnableElements(JournalSolutionCalculations.Error, null, true, 1) != null)
            {
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, JournalSolutionCalculations.Error);
                MouseCloseFormRsb(2);
                return;
            }
            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, JournalSolutionCalculations.UpdateForm);
            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, JournalSolutionCalculations.WinOk);
            while (true)
            {
                if (libraryAutomation.IsEnableElements(JournalSolutionCalculations.ButtonResh, null, true, 1) != null)
                {
                    libraryAutomation.FindElement.SetFocus();
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, JournalSolutionCalculations.ButtonResh);
                    break;
                }
            }
            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, JournalSolutionCalculations.Group11);
            var rowNumber = 1;
            while (true)
            {
                if (libraryAutomation.IsEnableElements(string.Concat(JournalSolutionCalculations.ListGroup11, rowNumber), null, true) != null)
                {

                    AutomationElement automationElementSanctions;
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, JournalSolutionCalculations.Group12);
                    while ((automationElementSanctions = libraryAutomation.IsEnableElements(string.Concat(JournalSolutionCalculations.ListGroup11, rowNumber), null, true, 30)) != null)
                    {
                        automationElementSanctions.SetFocus();
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, JournalSolutionCalculations.AddObject);
                        libraryAutomation.IsEnableElements(Journal129AndJournal121.WinSelectCircumstance1);
                        libraryAutomation.SetValuePattern("отсутствие обстоятельств");
                        libraryAutomation.IsEnableElements(Journal129AndJournal121.WinSelectCircumstance2);
                        libraryAutomation.SetValuePattern("22");
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.WinSelectCircumstanceOk);
                        rowNumber++;
                    }
                    break;
                }
            }
            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, JournalSolutionCalculations.Save);
            while (true)
            {
                LibraryAutomations libraryAutomationOk = new LibraryAutomations(TreeWalker.RawViewWalker.GetPreviousSibling(libraryAutomation.RootAutomationElements));
                if (libraryAutomationOk.IsEnableElements(JournalSolutionCalculations.OkWinButton, null, true) != null)
                {
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomationOk, JournalSolutionCalculations.OkWinButton);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, JournalSolutionCalculations.OkSave);
                    break;
                }
            }
            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, JournalSolutionCalculations.Sign);
            while (true)
            {
                LibraryAutomations libraryAutomationOk = new LibraryAutomations(TreeWalker.RawViewWalker.GetPreviousSibling(libraryAutomation.RootAutomationElements));
                if (libraryAutomationOk.IsEnableElements(JournalSolutionCalculations.OkWinButton, null, true) != null)
                {
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomationOk, JournalSolutionCalculations.OkWinButton);
                    break;
                }
            }
            while (true)
            {
                LibraryAutomations libraryAutomationDialog = new LibraryAutomations(WindowsAis3.AisNalog3);
                AutoItX.Sleep(2000);
                LibraryAutomations libraryAutomationSign = new LibraryAutomations(TreeWalker.RawViewWalker.GetPreviousSibling(libraryAutomationDialog.RootAutomationElements));
                if (!string.IsNullOrEmpty(sender))
                {
                    if (libraryAutomationSign.IsEnableElements(Journal129AndJournal121.SenderSign, null, true) != null)
                    {
                        libraryAutomationSign.SetValuePattern(sender);
                    }
                }
                if (libraryAutomationSign.IsEnableElements(Journal129AndJournal121.ViewPrint, null, true) != null)
                {
                    libraryAutomationSign.ClickElement(libraryAutomationSign.FindElement);
                    AutoItX.Sleep(10000);
                    PublicGlobalFunction.PublicGlobalFunction.CloseProcessProgram("AcroRd32", true);
                    PublicGlobalFunction.PublicGlobalFunction.CloseProcessProgram("FoxitPhantom", true);
                    while (true)
                    {
                        var toggle = libraryAutomationSign.TogglePattern(libraryAutomationSign.IsEnableElements(Journal129AndJournal121.ViewCheks));
                        if (toggle == "Off" || toggle == null)
                        {
                            while (true)
                            {
                                if (libraryAutomationSign.IsEnableElements(Journal129AndJournal121.ViewCheksText, null, true) != null)
                                {
                                    libraryAutomationSign.ClickElement(libraryAutomationSign.FindElement);
                                    break;
                                }
                            }
                        }
                        if (toggle == "On")
                        {
                            while (true)
                            {
                                if (libraryAutomationSign.IsEnableElements(Journal129AndJournal121.Sign, null, true) != null)
                                {
                                    libraryAutomationSign.ClickElement(libraryAutomationSign.FindElement);
                                    break;
                                }
                            }
                            break;
                        }
                    }
                    break;
                }
            }
            while (true)
            {
                if (libraryAutomation.IsEnableElements(JournalSolutionCalculations.Group12, null, true) != null)
                {
                    break;
                }
            }
            MouseCloseFormRsb(2);  //Закрытие формы 2 раза
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
        private void CreateForm1151085(LibraryAutomations libraryAutomation, AutomationElement[] listDocMemo, TaxJournal121 journal, DatePickerAdd datePicker, DepartamentOtdel senderSelect, DateTime? dateCloseValidation)
        {
            LibraryAutomations libraryAutomationDoc = new LibraryAutomations(WindowsAis3.AisNalog3);
            var allMaterial = new List<string>();
            var date = DateTime.Now;
            if (!listDocMemo.Any())
            {
                journal.ColorDoc = null;
                if (dateCloseValidation == null)
                {
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
                                //libraryAutomationSign.ClickElement(libraryAutomationSign.FindElement);
                                libraryAutomationSign.ExpandElement(libraryAutomationSign.FindElement);
                                var memo = libraryAutomationSign.SelectAutomationColrction(libraryAutomationSign.FindElement);
                                var elemClick = memo.Cast<AutomationElement>().FirstOrDefault(x => x.Current.Name == "Выявлены нарушения");
                                libraryAutomationSign.SelectionComboBoxSelectionItemPattern(elemClick);
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
                    while (true)
                    {
                        if (libraryAutomation.IsEnableElements(Journal129AndJournal121.WinErrorStatus, null, true, 5) != null)
                        {
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.WinErrorStatus);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.StartKnp);
                        }
                        break;
                    }
                }
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
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.AktNo);
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.PublicInfo);
                libraryAutomation.IsEnableElements(Journal129AndJournal121.DateReshenia119, null, true);
                libraryAutomation.SetValuePattern(date.ToString("dd.MM.yy"));
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.PublicInfo);
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.CollapseAll);
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Established);
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.DonloadButton);
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SendText);
                string textsMemo;
                while (true)
                {
                    if (libraryAutomation.IsEnableElements(Journal129AndJournal121.Error119, null, true, 5) != null)
                    {
                        textsMemo = string.Format(Journal129AndJournal121.AktTemplate1151085, journal.Period, journal.God, journal.DateFinishDeclaration.ToString("dd.MM.yyyy"), journal.DateStartDeclaration.ToString("dd.MM.yyyy"));
                        libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                        break;
                    }
                    textsMemo = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(Journal129AndJournal121.TextMemo, null, true));
                    string fullKbk = Regex.Match(textsMemo, "КБК(.+)").Value;
                    string fullSum = Regex.Match(textsMemo, "Сумма подлежащая (.+)").Value;
                    textsMemo = textsMemo.Replace("#Fact#", "").Replace(fullKbk, fullSum);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.AddText);
                    break;
                }
                while (true)
                {
                    if (libraryAutomation.IsEnableElements(Journal129AndJournal121.EstablishedNote, null, true) != null)
                    {
                        libraryAutomation.SetValuePattern(textsMemo);
                        break;
                    }
                }
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Established);
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ErrorFaceGr11);
                AddCircumstance(libraryAutomation, "11901023");
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ErrorFaceGr11);
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Established);
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.AddObs);
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.AddText);
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Established);

                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SaveAktNo);
                LibraryAutomations libraryAutomationDialog;
                LibraryAutomations libraryAutomationAddObject;
                while (true)
                {
                    libraryAutomationDialog = new LibraryAutomations(WindowsAis3.AisNalog3);
                    libraryAutomationAddObject = new LibraryAutomations(TreeWalker.RawViewWalker.GetPreviousSibling(libraryAutomationDialog.RootAutomationElements));
                    if (libraryAutomationAddObject.IsEnableElements(Journal129AndJournal121.OkStringOktmo, null, true) != null)
                    {
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomationAddObject, Journal129AndJournal121.OkStringOktmo);
                        break;
                    }
                }
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Ok);
                AutoItX.Sleep(1000);
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SignAktNo);
                while (true)
                {
                    libraryAutomationDialog = new LibraryAutomations(WindowsAis3.AisNalog3);
                    libraryAutomationAddObject = new LibraryAutomations(TreeWalker.RawViewWalker.GetPreviousSibling(libraryAutomationDialog.RootAutomationElements));
                    if (libraryAutomationAddObject.IsEnableElements(Journal129AndJournal121.OkStringOktmo, null, true) != null)
                    {
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomationAddObject, Journal129AndJournal121.OkStringOktmo);
                        break;
                    }
                }
                SaveSendDoc(libraryAutomation, journal, "Акт успешно выставлен!!!", "Акт");
                while (true)
                {
                    if (libraryAutomation.IsEnableElements(Journal129AndJournal121.Established, null, true) != null)
                    {
                        break;
                    }
                }
                MouseCloseFormRsb(2);  //Закрытие формы 2 раза
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Warning);
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
                        if(selectJournal?.DateFinishKnp != null)
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
                        journal.DateIzveshenie = createDocument;
                        var hours = hoursList[new Random().Next(0, hoursList.Length)];
                        var minute = minutesList[new Random().Next(0, minutesList.Length)];
                        AddDataAndTimeInvoke(libraryAutomation, senderSelect.Office, createDocument, hours, minute);
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
                        MouseCloseFormRsb(2);  //Закрытие формы 2 раза
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Warning);
                    }
                }
                else
                {
                //    //Выставляем Решение
                //    //Иные материалы 
                //    allMaterial.AddRange(ReturnMaterial(libraryAutomationDoc, isNotification, Journal129AndJournal121.TemplateIzveshenia));
                //    allMaterial.AddRange(ReturnMaterial(libraryAutomationDoc, isReshBeginDate, Journal129AndJournal121.TemplateReshBeginDate));
                //    allMaterial.AddRange(ReturnMaterial(libraryAutomationDoc, isReshDate, Journal129AndJournal121.TemplateReshDate));
                //    allMaterial.AddRange(ReturnMaterial(libraryAutomationDoc, isProtokol, Journal129AndJournal121.Protokol));
                //    var isGrinAll = isNotification.Any(x => libraryAutomationDoc.GetColorPixel(libraryAutomationDoc.SelectAutomationColrction(x).Cast<AutomationElement>().Where(automationElemenst => automationElemenst.Current.Name == "").ToList()[1]) != "8000");
                //    var colorAct = libraryAutomationDoc.GetColorPixel(libraryAutomationDoc.SelectAutomationColrction(isAct).Cast<AutomationElement>().Where(automationElement => automationElement.Current.Name == "").ToList()[1]);
                //    ////Если блок синий и акт и извещение зеленые
                //    if (journal.GlobalColor == "ff" && colorAct == "8000" && !isGrinAll)
                //    {
                //        journal.ColorDoc = colorAct;

                //        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.OpenKnp);
                //        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ReshNo);
                //        while (true)
                //        {
                //            if (libraryAutomation.IsEnableElements(Journal129AndJournal121.FaceNameGr15, null, true) != null)
                //            {
                //                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.AnyDocumentsGr3);
                //                libraryAutomation.IsEnableElements(Journal129AndJournal121.AnyPastDocumentsGr3, null, true);
                //                libraryAutomation.SetValuePattern(string.Join("\r\n", allMaterial));
                //                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.AnyDocumentsGr3);
                //                libraryAutomation.ClickElements(Journal129AndJournal121.FaceNameGr15, null, true);
                //                libraryAutomation.SelectItemCombobox(libraryAutomation.IsEnableElements(Journal129AndJournal121.FaceNameSignGr15), senderSelect.SenderTaxJournalOkp2.NameUser, 0);
                //                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Save);
                //                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SignAll);
                //                break;
                //            }
                //        }
                //        //Документ сохранить
                //        SaveSendDoc(libraryAutomation, journal, "Решение успешно выставлено!!!", "Решение");
                //        while (true)
                //        {
                //            if (libraryAutomation.IsEnableElements(Journal129AndJournal121.ButtonAll, null, true) != null)
                //            {
                //                break;
                //            }
                //        }
                //        WindowsAis3 win = new WindowsAis3();
                //        AutoItX.Sleep(1000);
                //        AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                //        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ClosedComplex121);
                        
                //    }
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
        private void CreateForm1151006(LibraryAutomations libraryAutomation, AutomationElement[] listDocMemo, TaxJournal121 journal, DatePickerAdd datePicker, DepartamentOtdel senderSelect, DateTime? dateCloseValidation)
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
                     if (libraryAutomation.IsEnableElements(Journal129AndJournal121.DateReshenia119, null, true) != null)
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
                MouseCloseFormRsb(2);  //Закрытие формы 2 раза
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
                        MouseCloseFormRsb(2);  //Закрытие формы 2 раза
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
        /// <param name="correctNumber">Номер корректировки</param>
        private void CreateForm1151111(LibraryAutomations libraryAutomation, AutomationElement[] listDocMemo, TaxJournal121 journal, DatePickerAdd datePicker, DepartamentOtdel senderSelect, DateTime? dateCloseValidation, string summNp, string colorError, int correctNumber, string oktmo)
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
                IsCorrectStart(libraryAutomation, "учтены результаты КНП (с учетом решений ВНО и судов)  по предыдущей декларации", correctNumber);
                DialogKnp(libraryAutomation, journal.DateFinishCheck, "Нарушения не выявлены");
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ClosedComplex121);
                AutoItX.WinWait(Journal129AndJournal121.WinNameComplex);
                AutoItX.WinActivate(Journal129AndJournal121.WinNameComplex);
                LibraryAutomations libraryAutomationWinClosed = new LibraryAutomations(Journal129AndJournal121.WinNameComplex);
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomationWinClosed, Journal129AndJournal121.WinOkCloseComplex);
                AutoItX.Sleep(1000);
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
                    IsCorrectStart(libraryAutomation, "учтены результаты КНП (с учетом решений ВНО и судов)  по предыдущей декларации", correctNumber);
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
                        var strCash = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(Journal129AndJournal121.NotCash)); //Не видим поле
                        var notCash = string.IsNullOrWhiteSpace(strCash) ? 0 : decimal.Parse(strCash);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ErrorFaceGr8);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ErrorFaceGr9);
                        var strIschesleno = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(Journal129AndJournal121.Ischesleno));
                        var ischesleno = string.IsNullOrWhiteSpace(strIschesleno) ? 0 : decimal.Parse(strIschesleno);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ErrorFaceGr9);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ErrorFaceGr10);
                        var strPeny = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(Journal129AndJournal121.Peny));
                        var peny = string.IsNullOrWhiteSpace(strPeny) ? 0 : decimal.Parse(strPeny);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ErrorFaceGr10);
                        if (notCash == 0 & ischesleno == 0 & peny == 0)
                        {
                            LibraryAutomations libraryAutomationDialog;
                            LibraryAutomations libraryAutomationAddObject;
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.PublicInfo);
                            libraryAutomation.IsEnableElements(Journal129AndJournal121.DateReshenia119, null, true);
                            libraryAutomation.SetValuePattern(date.ToString("dd.MM.yy"));
                            AutoItX.MouseWheel(ButtonConstant.Wheel, 5);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.CollapseAll);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ErrorFaceGr11);
                            AddCircumstance(libraryAutomation, "11901023", oktmo);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ErrorFaceGr11);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Established);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.DonloadButton);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SendText);
                            var textsMemo = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(Journal129AndJournal121.TextMemo, null, true));
                            //Проверка КНД Выставляем шаблон
                            if (journal.God <= 2022)
                            {
                                textsMemo = textsMemo.Replace("#Fact#", "");
                            }
                            else
                            {
                                textsMemo = textsMemo.Replace("30-го", "25-го").Replace("#Fact#", "");
                            }
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.AddText);
                            while (true)
                            {
                                if (libraryAutomation.IsEnableElements(Journal129AndJournal121.EstablishedNote, null, true) != null)
                                {
                                    libraryAutomation.SetValuePattern(textsMemo);
                                    break;
                                }
                            }
                            AutoItX.Sleep(1000);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SaveAktNo);
                            while (true)
                            {
                                libraryAutomationDialog = new LibraryAutomations(WindowsAis3.AisNalog3);
                                libraryAutomationAddObject = new LibraryAutomations(TreeWalker.RawViewWalker.GetPreviousSibling(libraryAutomationDialog.RootAutomationElements));
                                if (libraryAutomationAddObject.IsEnableElements(Journal129AndJournal121.OkStringOktmo, null, true) != null)
                                {
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomationAddObject, Journal129AndJournal121.OkStringOktmo);
                                    break;
                                }
                            }
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.WarningMessage);
                            AutoItX.Sleep(1000);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SignAktNo);
                            while (true)
                            {
                                libraryAutomationDialog = new LibraryAutomations(WindowsAis3.AisNalog3);
                                libraryAutomationAddObject = new LibraryAutomations(TreeWalker.RawViewWalker.GetPreviousSibling(libraryAutomationDialog.RootAutomationElements));
                                if (libraryAutomationAddObject.IsEnableElements(Journal129AndJournal121.OkStringOktmo, null, true) != null)
                                {
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomationAddObject, Journal129AndJournal121.OkStringOktmo);
                                    break;
                                }
                            }
                            //Если есть просрочка то не отправляем документ плательщику 
                            if (journal.IsPriznak)
                            {
                                SaveSendDoc(libraryAutomation, journal, "Акт успешно выставлено!!!", "Акт", true);
                            }
                            else
                            {
                                SaveSendDoc(libraryAutomation, journal, "Акт успешно выставлено!!!", "Акт");
                            }
                            while (true)
                            {
                                if (libraryAutomation.IsEnableElements(Journal129AndJournal121.PublicInfo, null, true) != null)
                                {
                                    break;
                                }
                            }
                            MouseCloseFormRsb(2);  //Закрытие формы 2 раза
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Warning);
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
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Warning);
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
                                createDocument = createDocument.AddWorkdays(6);
                                //Уходим от выходных
                                createDocument = IsWeekends(createDocument);
                            }
                            else
                            {
                                //В противном случае ТКС Если ТКС -   5  рабочих дней на вручение ( со след. дня после даты акта) + 1 месяц на возражения  
                                createDocument = createDocument.AddWorkdays(5);
                                createDocument = createDocument.AddMonths(1);
                                createDocument = createDocument.AddWorkdays(1);
                                //Уходим от выходных
                                createDocument = IsWeekends(createDocument);
                            }
                            //Выставляем извещение
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.OpenKnp);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.IzveshenieActNo);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ButtonSved);
                            var hours = hoursList[new Random().Next(0, hoursList.Length)];
                            var minute = minutesList[new Random().Next(0, minutesList.Length)];
                            journal.DateIzveshenie = createDocument;
                            AddDataAndTimeInvoke(libraryAutomation, senderSelect.Office, createDocument, hours, minute);
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
                            while (true)
                            {
                                if (libraryAutomation.IsEnableElements(Journal129AndJournal121.FaceName, null, true) != null)
                                {
                                    break;
                                }
                            }
                            MouseCloseFormRsb(2);  //Закрытие формы 2 раза
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Warning);
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
                                    libraryAutomation.IsEnableElements(Journal129AndJournal121.DateReshenia119, null, true);
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
                                    MouseCloseFormRsb(1);  //Закрытие формы 1 раз
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.WinCloseError);
                                    MouseCloseFormRsb(1);  //Закрытие формы 1 раза
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
        private void CreateForm1151020(LibraryAutomations libraryAutomation, AutomationElement[] listDocMemo, TaxJournal121 journal, DatePickerAdd datePicker, DepartamentOtdel senderSelect, DateTime? dateCloseValidation, string summNp, string colorError)
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
                        libraryAutomation.IsEnableElements(Journal129AndJournal121.DateReshenia119, null, true);
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
                        MouseCloseFormRsb(2);  //Закрытие формы 2 раза
                        break;
                    }
                }
            }
            else
            {

            }
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
        /// <param name="correctNumber">Номер корректировки</param>
        /// <param name="oktmo">ОКТМО</param>
        private void CreateForm1151001(LibraryAutomations libraryAutomation, AutomationElement[] listDocMemo, TaxJournal121 journal, DatePickerAdd datePicker, DepartamentOtdel senderSelect, DateTime? dateCloseValidation,  string sumNp, string colorError, int correctNumber, string oktmo)
        {
            var mouthAll = 0;
            decimal sumNedoim = (decimal)0.00;
            var date = DateTime.Now;
            var month = "1";
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
                var summNpKrsb = FindSumNp(libraryAutomation, journal, senderSelect, new string[] { "18210301000010000110" }, correctNumber, oktmo, sumNp);
                TranslatorSum(journal, summNpKrsb, 25, ref sumNedoim, ref month, ref mouthAll);
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
                        libraryAutomation.IsEnableElements(Journal129AndJournal121.DateReshenia119, null, true);
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
                                mouthAll, string.Format(Journal129AndJournal121.SummIsExists,decimal.Round(sumNedoim), senderSelect.Telephon)));
                        }
                        else
                        {
                            libraryAutomation.SetValuePattern(string.Format(Journal129AndJournal121.AktTemplate1151001, journal.NameFace, journal.Period, journal.God,
                                journal.DateFinishDeclaration.ToString("dd.MM.yyyy"), journal.DateStartDeclaration.ToString("dd.MM.yyyy"),
                                mouthAll, "", senderSelect.Telephon));
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
                        MouseCloseFormRsb(2);  //Закрытие формы 2 раза
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
                                            var hours = hoursList[new Random().Next(0, hoursList.Length)];
                                            var minute = minutesList[new Random().Next(0, minutesList.Length)];
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
                            MouseCloseFormRsb(2);  //Закрытие формы 2 раза
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
                        var summNpKrsb = FindSumNp(libraryAutomation, journal, senderSelect, new string[] { "18210301000010000110" }, correctNumber, oktmo, sumNp);
                        TranslatorSum(journal, summNpKrsb, 25, ref sumNedoim, ref month, ref mouthAll);
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
                                libraryAutomation.IsEnableElements(Journal129AndJournal121.DateReshenia119, null, true);
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
                                           mouthAll, journal.NameFace));
                                }
                                else
                                {
                                    libraryAutomation.SetValuePattern(string.Format(Journal129AndJournal121.ReshTemplate1151001_2, journal.NameFace, journal.Period, journal.God,
                                          journal.DateFinishDeclaration.ToString("dd.MM.yyyy"), journal.DateStartDeclaration.ToString("dd.MM.yyyy"),
                                          mouthAll, sumNp, decimal.Round(sumNedoim).ToString(), sumNp, month, journal.NameFace));
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
                                MouseCloseFormRsb(2);  //Закрытие формы 2 раза
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
        /// <param name="correctNumber">Номер корректировки</param>
        /// <param name="oktmo">ОКТМО</param>
        private void CreateForm1152017(LibraryAutomations libraryAutomation, AutomationElement[] listDocMemo, TaxJournal121 journal, DatePickerAdd datePicker, DepartamentOtdel senderSelect, DateTime? dateCloseValidation, string sumNp, string colorError, int correctNumber, string oktmo)
        {
            var mouthAll = 0;
            decimal sumArrears = (decimal)0.00;
            var date = DateTime.Today;
            var month = "1";
            var libraryAutomationDoc = new LibraryAutomations(WindowsAis3.AisNalog3);
            var isRequirement = listDocMemo.FirstOrDefault(doc => libraryAutomationDoc.ParseElementLegacyIAccessiblePatternIdentifiers(
                                                                      libraryAutomationDoc.SelectAutomationColrction(doc).Cast<AutomationElement>()
                                                                          .First(elem => elem.Current.Name.Contains("КНД"))) == "1165050");
            if (isRequirement != null)
            {
                return;
            }
            if (journal.GlobalColor == "6400")
            {
                return;
            }
          //  if (oktmo.Trim().Length > 8)
          //  {
          //     return;
          //  }
            var parametersModel = new ModelDataArea();
            var allMaterial = new List<string>();
            if (!listDocMemo.Any())
            {
                //Акты
                journal.ColorDoc = null;
              //  parametersModel.DataAreaDeclaration.Parameters.First(parameters => parameters.NameParameters == "РегНомер").ParametersGrid = journal.RegNumDeclaration.ToString();
                parametersModel.DataAreaDeclarationFace.Parameters.First(parameters => parameters.NameParameters == "Отчетный год").ParametersGrid = journal.God.ToString();
                parametersModel.DataAreaDeclarationFace.Parameters.First(parameters => parameters.NameParameters == "ИНН").ParametersGrid = journal.Inn;
                sumNp = FindMailDateDecl(libraryAutomation, ref journal, FindPathTree(libraryAutomation, parametersModel.DataAreaDeclarationFace, PathMailDecl));
                //if(correctNumber > 0)
                //{

                //    sumNp = FindMailDateDeclSummAll(libraryAutomation, FindPathTree(libraryAutomation, parametersModel.DataAreaDeclarationFace, PathMailDecl));
                //}
               // var summNpKrsb = FindSumNp(libraryAutomation, journal, senderSelect, new string[] {"18210501011010000110", "18210501021010000110"}, correctNumber, oktmo, sumNp);
               // TranslatorSum(journal, summNpKrsb, 30, ref sumArrears, ref month, ref mouthAll);
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
                            date = dateFinish > DateTime.Today ? DateTime.Today : dateFinish;
                            var dateAdd = dateFinish.AddWorkdays(5);
                            var totalDays = (dateAdd - DateTime.Now).TotalDays;
                            var countDay = (int)totalDays;
                            journal.IsPriznak = countDay < 0;
                        }
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.PublicInfo);
                        libraryAutomation.IsEnableElements(Journal129AndJournal121.DateReshenia119, null, true);
                        libraryAutomation.SetValuePattern(date.ToString("dd.MM.yyyy"));
                        if (date < DateTime.Today)
                        {
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ErrorFaceGr10);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ErrorFaceGr11);
                        }
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ErrorFaceGr11);
                        var summScore = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(Journal129AndJournal121.ErrorFaceGr11Summ, null, true));
                        AddCircumstance(libraryAutomation, "11901023", oktmo);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ErrorFaceGr11);
                        var textsMemo = "";
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Established);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.DonloadButton);
                        if (correctNumber == 0)
                        {
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SendText);
                            textsMemo = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(Journal129AndJournal121.TextMemo, null, true));
                            //Проверка КНД Выставляем шаблон journal.DateStartCheck -Дата первичной декларации
                            textsMemo = textsMemo.Replace("#AmountDuee#", sumNp);
                            //Проверка КНД Выставляем шаблон
                            textsMemo = journal.God < 2022 ? Regex.Replace(textsMemo, "#Fact#(.+)\\n(.+)", "").Replace("25-го", "30-го") : Regex.Replace(textsMemo, "#Fact#(.+)\\n(.+)", "");
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.AddText);
                        }
                        else
                        {
                            textsMemo = string.Format(Journal129AndJournal121.AktTemplate1152017_2, journal.God<2022?"30-го":"25-го", journal.God<2022?"30-го":"25-го", journal.God, journal.DateFinishDeclaration.ToString("dd.MM.yyyy"), journal.NameFace, journal.Inn, journal.DateStartCheck.ToString("dd.MM.yyyy"), "первичную", journal.God, journal.God, sumNp,   journal.God);
                        }
                        while (true)
                        {
                            if (libraryAutomation.IsEnableElements(Journal129AndJournal121.EstablishedNote, null, true) != null)
                            {
                                libraryAutomation.SetValuePattern(textsMemo);
                                break;
                            }
                        }
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Established);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SaveAktNo);
                        LibraryAutomations libraryAutomationDialog;
                        LibraryAutomations libraryAutomationAddObject;
                        while (true)
                        {
                            libraryAutomationDialog = new LibraryAutomations(WindowsAis3.AisNalog3);
                            libraryAutomationAddObject = new LibraryAutomations(TreeWalker.RawViewWalker.GetPreviousSibling(libraryAutomationDialog.RootAutomationElements));
                            if(libraryAutomationAddObject.IsEnableElements(Journal129AndJournal121.OkStringOktmo, null, true) != null){
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomationAddObject, Journal129AndJournal121.OkStringOktmo);
                                break;
                            }
                        }
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Ok);
                        AutoItX.Sleep(1000);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SignAktNo);
                        while (true)
                        {
                            libraryAutomationDialog = new LibraryAutomations(WindowsAis3.AisNalog3);
                            libraryAutomationAddObject = new LibraryAutomations(TreeWalker.RawViewWalker.GetPreviousSibling(libraryAutomationDialog.RootAutomationElements));
                            if (libraryAutomationAddObject.IsEnableElements(Journal129AndJournal121.OkStringOktmo, null, true) != null){
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomationAddObject, Journal129AndJournal121.OkStringOktmo);
                                break;
                            }
                        }
                        SaveSendDoc(libraryAutomation, journal, "Акт успешно выставлено!!!", "Акт", true);
                        while (true)
                        {
                            if (libraryAutomation.IsEnableElements(Journal129AndJournal121.Established, null, true) != null)
                            {
                                break;
                            }
                        }
                        MouseCloseFormRsb(2);  //Закрытие формы 2 раза
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Warning);
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
                    if (journal.ColorDoc == "ffff00" || journal.ColorDoc == "8000" || journal.ColorDoc == "ff")
                    {
                        var modelDecl = SelectJournal(journal.RegNumDeclaration);
                        if (modelDecl != null)
                        {
                         
                            createDocument = createDocument.AddWorkdays(21);
                            createDocument = createDocument.AddMonths(1);
                            //Уходим от выходных
                            createDocument = IsWeekends(createDocument);
                            //Выставляем извещение
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.OpenKnp);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.IzveshenieActNo);
                            var selectJournal = SelectJournal(journal.RegNumDeclaration);
                            if (selectJournal.DateFinishKnp != null)
                            {
                                var dateFinish = (DateTime)selectJournal.DateFinishKnp;
                                var dateAdd = dateFinish.AddWorkdays(5);
                                var totalDays = (dateAdd - DateTime.Now).TotalDays;
                                var countDay = (int)totalDays;
                                journal.IsPriznak = countDay < 0;
                            }
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ButtonAll);
                            libraryAutomation.IsEnableElements(Journal129AndJournal121.DateButtonAll, null, true);
                            journal.DateIzveshenie = createDocument;
                            libraryAutomation.SetValuePattern(date.ToString("dd.MM.yyyy"));
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ButtonAll);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ButtonSved);
                            var hours = hoursList[new Random().Next(0, hoursList.Length)];
                            var minute = minutesList[new Random().Next(0, minutesList.Length)];
                            AddDataAndTimeInvoke(libraryAutomation, senderSelect.Office, createDocument, hours, minute, true);
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
                            SaveSendDoc(libraryAutomation, journal, "Извещение успешно выставлено!!!", "Извещение", true, senderSelect.SenderTaxJournalOkp2.NameUser);
                            while (true)
                            {
                                if (libraryAutomation.IsEnableElements(Journal129AndJournal121.ButtonAll, null, true) != null)
                                {
                                    break;
                                }
                            }
                            MouseCloseFormRsb(2);  //Закрытие формы 2 раза
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Warning);
                        }
                    }
                }
                else
                {
                    ////Решения
                    ////////Иные материалы 
                    IEnumerable<AutomationElement> akt = new List<AutomationElement>() { isAct };
                    allMaterial.AddRange(ReturnMaterial(libraryAutomationDoc, akt, Journal129AndJournal121.TemplateAkt));
                    allMaterial.AddRange(ReturnMaterial(libraryAutomationDoc, isNotification, Journal129AndJournal121.TemplateIzveshenia));
                    allMaterial.AddRange(ReturnMaterial(libraryAutomationDoc, isReshBeginDate, Journal129AndJournal121.TemplateReshBeginDate));
                    allMaterial.AddRange(ReturnMaterial(libraryAutomationDoc, isReshDate, Journal129AndJournal121.TemplateReshDate));
                    allMaterial.AddRange(ReturnMaterial(libraryAutomationDoc, isProtokol, Journal129AndJournal121.Protokol));
                    var isGrinAll = isNotification.Any(x => libraryAutomationDoc.GetColorPixel(libraryAutomationDoc.SelectAutomationColrction(x).Cast<AutomationElement>().Where(automationElemenst => automationElemenst.Current.Name == "").ToList()[1]) != "8000");
                    var colorAct = libraryAutomationDoc.GetColorPixel(libraryAutomationDoc.SelectAutomationColrction(isAct).Cast<AutomationElement>().Where(automationElement => automationElement.Current.Name == "").ToList()[1]);
                    //////Если блок синий и акт и все извещение зеленые выставляем Решения
                    if (journal.GlobalColor == "ff" && colorAct == "8000" && !isGrinAll && isResh.Count() == 0 && sumNp == "00,00")
                    {
                        journal.ColorDoc = colorAct; 
                    //    Бывший поиск и анализ сумм штрафа
                    //    parametersModel.DataAreaDeclaration.Parameters.First(parameters => parameters.NameParameters == "РегНомер").ParametersGrid = journal.RegNumDeclaration.ToString();
                    //    parametersModel.DataAreaAllDeclarationDocument.Parameters.First(parameters => parameters.NameParameters == "ИНН").ParametersGrid = journal.Inn;
                    //    parametersModel.DataAreaAllDeclarationDocument.Parameters.First(parameters => parameters.NameParameters == "КНД декларации").ParametersGrid = journal.Knd.ToString();
                    //    FindMailDateDecl(libraryAutomation, ref journal, FindPathTree(libraryAutomation, parametersModel.DataAreaDeclaration, PathMailDecl));
                    //    var sumNpKrsb = FindSumNp(libraryAutomation, journal, senderSelect, new string[] { "18210501011010000110", "18210501021010000110" }, correctNumber, oktmo, sumNp);
                    //    TranslatorSum(journal, sumNpKrsb, 30, ref sumArrears, ref month, ref mouthAll); //Проверку сумму недоимки штрафа нарушение
                    //    var isCheck = FindSolutionRepeat(libraryAutomation, FindPathTree(libraryAutomation, parametersModel.DataAreaAllDeclarationDocument, PathAllDocument), ref sumArrears); //Проверку на повторное нарушение
                       
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.OpenKnp);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.EditP);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Avg);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SendAvg);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.UpdateDecl);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.UpdateYes);

                        libraryAutomation.ScrollPatternViewElement(Journal129AndJournal121.ReshScroll);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ReshNo, null, true);
                        while (true)
                        {
                            if (libraryAutomation.IsEnableElements(Journal129AndJournal121.ErrorFaceGr8, null, true) != null)
                            {
                                date = DateTime.Now;
                                //            //Проверка на просрочку не нужно
                                //            if (journal.DateFinishKnp != null)
                                //            {
                                //                var dateFinish = (DateTime)journal.DateFinishKnp;
                                //                date = dateFinish > DateTime.Now ? DateTime.Now : dateFinish; ///??? Текущая или нет
                                //                var dateAdd = dateFinish.AddWorkdays(5);
                                //                var totalDays = (dateAdd - DateTime.Now).TotalDays;
                                //                var countDay = (int)totalDays;
                                //                journal.IsPriznak = countDay < 0;
                                //            }

                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.PublicInfo);
                                libraryAutomation.IsEnableElements(Journal129AndJournal121.DateReshenia119, null, true);
                                libraryAutomation.SetValuePattern(date.ToString("dd.MM.yy"));
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.PublicInfo);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.AnyDocumentsGr3);
                                libraryAutomation.InvokePattern(libraryAutomation.IsEnableElements(Journal129AndJournal121.DocumentsGr3AddButton, null, true));
                                libraryAutomation.IsEnableElements(Journal129AndJournal121.AnyPastDocumentsGr3, null, true);
                                AutoItX.Sleep(1000);
                                libraryAutomation.FindElement.SetFocus();
                                SendKeys.SendWait(string.Join("\r\n", allMaterial));
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.AnyDocumentsGr3);
                           
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ErrorFaceGr11);
                                AddCircumstance(libraryAutomation, "11901013", oktmo, 0, 7);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ErrorFaceGr11);

                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.InstallGr6);
                                
                                libraryAutomation.IsEnableElements(Journal129AndJournal121.InstallTextGr6);

                                libraryAutomation.SetValuePattern(string.Format(Journal129AndJournal121.ReshenieTemplate1152017New, journal.God, journal.DateFinishDeclaration.ToString("dd.MM.yyyy"), journal.NameFace, journal.Inn, journal.DateStartDeclaration.ToString("dd.MM.yyyy"), correctNumber == 0 ? "первичную" : "уточненную", journal.God, journal.God, sumNp, journal.God));
                                
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.InstallGr6);


                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ErrorFaceGr15);
                                libraryAutomation.SelectItemCombobox(libraryAutomation.IsEnableElements(Journal129AndJournal121.FaceNameSignGr15), senderSelect.SenderTaxJournalOkp2.NameUser, 0);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Save);
                                LibraryAutomations libraryAutomationDialog;
                                LibraryAutomations libraryAutomationAddObject;
                                while (true)
                                {
                                    libraryAutomationDialog = new LibraryAutomations(WindowsAis3.AisNalog3);
                                    libraryAutomationAddObject = new LibraryAutomations(TreeWalker.RawViewWalker.GetPreviousSibling(libraryAutomationDialog.RootAutomationElements));
                                    if (libraryAutomationAddObject.IsEnableElements(Journal129AndJournal121.OkStringOktmo, null, true) != null)
                                    {
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomationAddObject, Journal129AndJournal121.OkStringOktmo);
                                        break;
                                    }
                                }
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Ok);
                                AutoItX.Sleep(1000);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SignAll);
                                while (true)
                                {
                                    libraryAutomationDialog = new LibraryAutomations(WindowsAis3.AisNalog3);
                                    libraryAutomationAddObject = new LibraryAutomations(TreeWalker.RawViewWalker.GetPreviousSibling(libraryAutomationDialog.RootAutomationElements));
                                    if (libraryAutomationAddObject.IsEnableElements(Journal129AndJournal121.OkStringOktmo, null, true) != null)
                                    {
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomationAddObject, Journal129AndJournal121.OkStringOktmo);
                                        break;
                                    }
                                }
                                SaveSendDoc(libraryAutomation, journal, "Решение успешно выставлено!!!", "Решение", true);
                                while (true)
                                {
                                    if (libraryAutomation.IsEnableElements(Journal129AndJournal121.PublicInfo, null, true) != null)
                                    {
                                        break;
                                    }
                                }
                                MouseCloseFormRsb(2);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Warning);
                                break;
                               
                                //            Алгоритм комплекса мероприятия 
                                //            //if (libraryAutomation.IsEnableElements(Journal129AndJournal121.ClosedComplex121, null, false, 5) != null)
                                //            //{
                                //            //    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ClosedComplex121);
                                //            //    AutoItX.WinWait(Journal129AndJournal121.WinNameComplex);
                                //            //    AutoItX.WinActivate(Journal129AndJournal121.WinNameComplex);
                                //            //    LibraryAutomations libraryAutomationWin = new LibraryAutomations(Journal129AndJournal121.WinNameComplex);
                                //            //    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomationWin, Journal129AndJournal121.WinOkCloseComplex);
                                //            //}
                                //            //else
                                //            //{
                                //            //    WindowsAis3 winClose = new WindowsAis3();
                                //            //    AutoItX.Sleep(1000);
                                //            //    AutoItX.MouseClick(ButtonConstant.MouseLeft, winClose.WindowsAis.X + winClose.WindowsAis.Width - 20, winClose.WindowsAis.Y + 160);
                                //            //} 
                            }
                        }

                    }
                }
            }
            AutoItX.Sleep(1000);
        }

        /// <summary>
        /// Поиск сумм неуплаты уплаты по КРСБ
        /// </summary>
        /// <param name="libraryAutomation">Библиотека Автомата</param>
        /// <param name="journal">Журнал</param>
        /// <param name="senderSelect">Подписант документа</param>
        /// <param name="kbk">КБК для поиска</param>
        /// <param name="correctNumber">Номер корректировки</param>
        /// <param name="oktmo">ОКТМО</param>
        /// <param name="sumNp">Сумма заявленная в декларации</param>
        private string FindSumNp(LibraryAutomations libraryAutomation, TaxJournal121 journal, DepartamentOtdel senderSelect, string[] kbk,  int correctNumber, string oktmo, string sumNp)
        {
            var sumNpKrsb = "0,00";
            var functionKrsb = new KrsbFunction();
            if (Convert.ToDecimal(sumNp) > (decimal)0.00 && correctNumber == 0)
            {
                sumNpKrsb = functionKrsb.FindSum(libraryAutomation, Convert.ToDecimal(sumNp), journal, kbk, senderSelect.StatusFace, oktmo);
            }
            else
            {
                if (Convert.ToDecimal(sumNp) >= (decimal)0.00 && correctNumber != 0)
                {
                    sumNpKrsb = functionKrsb.FindSum(libraryAutomation, Convert.ToDecimal(sumNp), journal, kbk, senderSelect.StatusFace, oktmo);
                }
            }
            return sumNpKrsb;
        }

        /// <summary>
        /// Формула расчета недоимки просрочки по НДС и УСН
        /// </summary>
        /// <param name="journal">Журнал деклараций</param>
        /// <param name="sumNp">Сумма по декларации</param>
        /// <param name="sumArrears">Сумма недоимки к штрафу</param>
        /// <param name="month">Месяцев просрочки</param>
        /// <param name="dayReport">Отчетная дата</param>
        /// <param name="mouthAll">Количество полных месяцев просрочки</param>
        private void TranslatorSum(TaxJournal121 journal, string sumNp, int dayReport, ref decimal sumArrears, ref string month, ref int mouthAll)
        {
            if ((journal.DateStartDeclaration.Year != journal.DateFinishDeclaration.Year || journal.DateStartDeclaration.Month != journal.DateFinishDeclaration.Month || journal.DateStartDeclaration.Day != journal.DateFinishDeclaration.Day))
            {
                if (journal.DateStartDeclaration.Day > dayReport)
                {
                    mouthAll++;
                }
            }
            mouthAll += ((journal.DateStartDeclaration.Year - journal.DateFinishDeclaration.Year) * 12) + journal.DateStartDeclaration.Month - journal.DateFinishDeclaration.Month;
            if (decimal.Parse(sumNp) >= (decimal)0.00)
            {
                if (mouthAll == 1)
                {
                    sumArrears = decimal.Parse(sumNp) * (decimal)0.5;
                    month = "1";
                }
                else if (mouthAll == 2)
                {
                    sumArrears = decimal.Parse(sumNp) * (decimal)0.10;
                    month = "2";
                }
                else if (mouthAll == 3)
                {
                    sumArrears = decimal.Parse(sumNp) * (decimal)0.15;
                    month = "3";
                }
                else if (mouthAll == 4)
                {
                    sumArrears = decimal.Parse(sumNp) * (decimal)0.20;
                    month = "4";
                }
                else if (mouthAll == 5)
                {
                    sumArrears = decimal.Parse(sumNp) * (decimal)0.25;
                    month = "5";
                }
                else if (mouthAll >= 6)
                {
                    sumArrears = decimal.Parse(sumNp) * (decimal)0.30;
                    month = "6";
                }
            }
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
        /// Поиск писем на бумажном носителе с подстановкой даты
        /// </summary>
        /// <param name="libraryAutomation">Библиотека Автомата</param>
        /// <param name="journal">Журнал</param>
        /// <param name="automationElementsTree">Элементы сторонней ветки</param>
        private string FindMailDateDecl(LibraryAutomations libraryAutomation, ref TaxJournal121 journal, AutomationElement[] automationElementsTree)
        {
          decimal summAll = (decimal)0.00;
          var regNumberDecl = journal.RegNumDeclaration;
          var firstDecl = automationElementsTree.Cast<AutomationElement>().Where(elem => elem.Current.Name != "Data Area").Distinct().Where(doc=>
                            libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                        libraryAutomation.SelectAutomationColrction(doc).Cast<AutomationElement>()
                                            .First(elem => elem.Current.Name.Contains("РегНомер"))) == regNumberDecl.ToString()).First();
            var nameStatus = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                             .SelectAutomationColrction(firstDecl).Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Наименование способа представления")));
            if(nameStatus == "По телекоммуникационным каналам связи с ЭП" || nameStatus == "На бумажном носителе (по почте)")
            {
                journal.DateStartDeclaration = Convert.ToDateTime(
                                         libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                         .SelectAutomationColrction(firstDecl).Cast<AutomationElement>()
                                         .First(elem => elem.Current.Name.Contains("Дата отправки по почте/ТКС"))));
            }
            foreach (var decl in automationElementsTree.Distinct())
            {
                summAll += Convert.ToDecimal(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                             .SelectAutomationColrction(decl).Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("П-Сумма"))));
            }
            MouseCloseFormRsb(1);
            return Convert.ToString(summAll);
        }
        /// <summary>
        /// Поиск повторного правонарушения (Решения)
        /// </summary>
        /// <param name="libraryAutomation">Библиотека Автомата</param>
        /// <param name="automationElementsTree">Все записи по декларации УСН</param>
        /// <param name="sumArrears">Сумма недоимки для расчета </param>
        /// <returns>Признак правонарушения</returns>
        private bool FindSolutionRepeat(LibraryAutomations libraryAutomation, AutomationElement[] automationElementsTree, ref decimal sumArrears)
        {
            var listDocMemo = automationElementsTree.Distinct().Where(elem => elem.Current.Name.Contains("select0 row") &&
                            libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                            libraryAutomation.SelectAutomationColrction(elem).Cast<AutomationElement>()
                            .First(doc => doc.Current.Name.Contains("КНД"))) == "1165020").ToArray();
            // Если сумма недоимки меньше 1000 то оставляем какой она была проверяем повторное правонарушение *2 если оно есть в противном случае какой она была
            // Если сумма больше 1000  и есть повторное правонарушение то *2 
            MouseCloseFormRsb(1);
            if (listDocMemo.Any())
            {
                //Правонарушение есть
                if (sumArrears > 1000)
                {
                    sumArrears = sumArrears * 2;
                }
                else
                {
                    sumArrears = 1000 * 2;
                }
                MouseCloseFormRsb(1);
                return true;
            }
            //Правонарушение нет
            MouseCloseFormRsb(1);
            return false;
        }
        /// <summary>
        /// Добавление обстоятельства для ветки Налоговое администрирование\Контрольная работа (налоговые проверки)\106. Реестр расчетов по страховым взносам и персонифицированным сведениям\Реестр расчетов по страховым взносам, сведения о КНП (все)
        /// </summary>
        /// <param name="libraryAutomation">Автоматизированный элемент</param>
        /// <param name="kndForm">КНД форма </param>
        /// <param name="oktmo">ОКТМО</param>
        /// <param name="type">Тип обстаятельства</param>
        /// <param name="vid">Вид обстаятельства</param>
        private void AddCircumstance(LibraryAutomations libraryAutomation, string kndForm, string oktmo = "", int type = 4, int vid = 0 )
        {
          
            if (libraryAutomation.IsEnableElements(Journal129AndJournal121.ListCashFace, null, true) != null)
            {
                
                AutomationElement cashAdd;
                LibraryAutomations libraryAutomationDialog = new LibraryAutomations(WindowsAis3.AisNalog3);
                LibraryAutomations libraryAutomationAddObject;
                AutomationElement listView;
                while ((cashAdd = libraryAutomation.IsEnableElements(Journal129AndJournal121.ListCashFace, null, false, 10)) != null)
                {
                    var elem = libraryAutomation.SelectAutomationColrction(cashAdd).Cast<AutomationElement>().Where(elems => elems.Current.ClassName == "Button").ToArray();
                    if (elem.Length <= 2)
                    {
                        while ((cashAdd = libraryAutomation.IsEnableElements(Journal129AndJournal121.ListCashFace, null, false, 10)) != null)
                        {
                            elem = libraryAutomation.SelectAutomationColrction(cashAdd).Cast<AutomationElement>().Where(elems => elems.Current.ClassName == "Button").ToArray();
                            libraryAutomation.ClickElement(elem[1]);
                            if (libraryAutomation.IsEnableElements(Journal129AndJournal121.ButtonGroup11Add2Add, null, true) == null) continue;
                            libraryAutomation.ClickElement(libraryAutomation.IsEnableElements(Journal129AndJournal121.ButtonGroup11Add2Add));
                            break;
                        }
                        AutoItX.Sleep(2000);
                        libraryAutomationAddObject = new LibraryAutomations(TreeWalker.RawViewWalker.GetPreviousSibling(libraryAutomationDialog.RootAutomationElements));
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomationAddObject, Journal129AndJournal121.WinSelect1Error);
                        while ((listView = libraryAutomationAddObject.IsEnableElements(Journal129AndJournal121.WinSelectErrorPopup, null, false, 10)) != null)
                        {
                            while (true)
                            {
                                elem = libraryAutomationAddObject.SelectAutomationColrction(listView).Cast<AutomationElement>().Where(elems => elems.Current.Name == kndForm).ToArray();
                                libraryAutomationAddObject.SelectionComboBoxPattern(elem[0]);
                                break;
                            }
                            break;
                        }
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomationAddObject, Journal129AndJournal121.WinSelect2Error);
                        while ((listView = libraryAutomationAddObject.IsEnableElements(Journal129AndJournal121.WinSelectErrorPopup, null, false, 10)) != null)
                        {
                            while (true)
                            {
                                elem = libraryAutomationAddObject.SelectAutomationColrction(listView).Cast<AutomationElement>().Where(elems => elems.Current.Name == kndForm).ToArray();
                                libraryAutomationAddObject.SelectionComboBoxPattern(elem[0]);
                                break;
                            }
                            break;
                        }
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomationAddObject, Journal129AndJournal121.WinSelectCircumstanceOk);
                    }
                    break;
                }
                while ((cashAdd = libraryAutomation.IsEnableElements(Journal129AndJournal121.ListCashFace, null, false, 10)) != null)
                {
                    var TextBox = libraryAutomation.SelectAutomationColrction(cashAdd).Cast<AutomationElement>().Where(elems => elems.Current.ClassName == "TextBox").ToArray();
                    var flag = libraryAutomation.SelectAutomationColrction(cashAdd).Cast<AutomationElement>().Where(elems => elems.Current.ClassName == "CheckBox").ToArray();
                    var indexChekBoxAndTextSumm = SelectArrayToNumberChekBox(TextBox.Length);
                    foreach (var box in indexChekBoxAndTextSumm)
                    {
                        var summ = Convert.ToInt32(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(TextBox.ElementAtOrDefault(box.Key)));
                        if (summ <= 0)
                        {
                            libraryAutomation.TogglePatternInputAndStatus(flag.ElementAtOrDefault(box.Value));
                        }
                    }
                    var elem = libraryAutomation.SelectAutomationColrction(cashAdd).Cast<AutomationElement>().Where(elems => elems.Current.ClassName == "Button").ToArray();
                    libraryAutomation.InvokePattern(elem.ElementAtOrDefault(0));
                    var dictionary = SelectArrayToNumberButton(elem.Length);
                    var flagExit = 0;
                    foreach (var dict in dictionary)
                    {
                        while ((cashAdd = libraryAutomation.IsEnableElements(Journal129AndJournal121.ListCashFace, null, false, 10)) != null)
                        {
                            elem = libraryAutomation.SelectAutomationColrction(cashAdd).Cast<AutomationElement>().Where(elems => elems.Current.ClassName == "Button").ToArray();
                            flag = libraryAutomation.SelectAutomationColrction(cashAdd).Cast<AutomationElement>().Where(elems => elems.Current.ClassName == "CheckBox").ToArray();
                            var elementKey = elem.ElementAtOrDefault(dict.Key);
                            if (elementKey == null || flagExit == flag.Length) //Это в случае если нет внутри обстоятельств
                            {
                                return;
                            }
                            libraryAutomation.InvokePattern(elementKey);
                            var flagExitYes = libraryAutomation.SelectAutomationColrction(cashAdd).Cast<AutomationElement>().Where(elems => elems.Current.ClassName == "CheckBox").ToArray();
                            if (flagExitYes.Length > flag.Length)
                            {
                                break;
                            }
                            libraryAutomation.InvokePattern(elem.ElementAtOrDefault(dict.Value));
                            AutoItX.Sleep(2000);
                            libraryAutomationAddObject = new LibraryAutomations(TreeWalker.RawViewWalker.GetPreviousSibling(libraryAutomationDialog.RootAutomationElements));
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomationAddObject, Journal129AndJournal121.WinSelect1Obs);
                            while ((listView = libraryAutomationAddObject.IsEnableElements(Journal129AndJournal121.WinSelectErrorPopup, null, false, 10)) != null)
                            {
                                while (true)
                                {
                                    elem = libraryAutomationAddObject.SelectAutomationColrction(listView).Cast<AutomationElement>().Where(elems => elems.Current.Name == "Rnivc.Cam.Nsi.Business.TaxKindCircumstanceEntity").ToArray();
                                    libraryAutomationAddObject.SelectionComboBoxPattern(elem[type]);
                                    break;
                                }
                                break;
                            }
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomationAddObject, Journal129AndJournal121.WinSelect2Obs);
                            while ((listView = libraryAutomationAddObject.IsEnableElements(Journal129AndJournal121.WinSelectErrorPopup, null, false, 10)) != null)
                            {
                                while (true)
                                {
                                    elem = libraryAutomationAddObject.SelectAutomationColrction(listView).Cast<AutomationElement>().Where(elems => elems.Current.Name == "Rnivc.Cam.Nsi.Business.TaxCircumstanceEntity").ToArray();
                                    libraryAutomationAddObject.SelectionComboBoxPattern(elem[vid]);
                                    break;
                                }
                                break;
                            }
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomationAddObject, Journal129AndJournal121.WinSelectCircumstanceOk);
                            flagExit += 2;
                            break;
                        }
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// Добавление даты и места вызова плательщика
        /// Новое 12.07.2023
        /// </summary>
        /// <param name="libraryAutomation"></param>
        /// <param name="office">Номер кабинета</param>
        /// <param name="date">Дата вызова плательщика</param>
        /// <param name="hours">Час вызова</param>
        /// <param name="minute">Минуты вызова</param>
        /// <param name="isAddress">Параметр вставки адреса кабинета</param>
        public void AddDataAndTimeInvoke(LibraryAutomations libraryAutomation, string office, DateTime date, string hours, string minute, bool isAddress = false)
        {
            while (true)
            {
                if (libraryAutomation.IsEnableElements(Journal129AndJournal121.NumKabinet, null, true) != null)
                {
                    AutomationElement setValue;
                    while ((setValue = libraryAutomation.IsEnableElements(Journal129AndJournal121.NumKabinet, null, false, 10)) != null)
                    {
                        var elem = libraryAutomation.SelectAutomationColrction(setValue).Cast<AutomationElement>().Where(elems => elems.Current.LocalizedControlType == "поле").ToArray();
                        if (isAddress)
                        {
                            libraryAutomation.FindElement = elem[0];
                            libraryAutomation.SetValuePattern("108814,Москва г,Сосенское п,Коммунарка п,Сосенский Стан ул,4,блок А,этаж 2");
                        }
                        libraryAutomation.FindElement = elem[1];
                        libraryAutomation.SetValuePattern(office);
                        break;
                    }
                    libraryAutomation.ClickElements(Journal129AndJournal121.AddButton);
                    LibraryAutomations libraryAutomationDialog = new LibraryAutomations(WindowsAis3.AisNalog3);
                    AutoItX.Sleep(2000);
                    var libraryAutomationAddObject = new LibraryAutomations(TreeWalker.RawViewWalker.GetPreviousSibling(libraryAutomationDialog.RootAutomationElements));
                    while (true)
                    {
                        if (libraryAutomationAddObject.IsEnableElements(Journal129AndJournal121.WindowDateTime, null, true) != null)
                        {
                            libraryAutomationAddObject.SetValuePattern(date.ToString("dd.MM.yy"));
                            while ((setValue = libraryAutomationAddObject.IsEnableElements(Journal129AndJournal121.WindowHoursAndMinutes, null, false, 10)) != null)
                            {
                                var elem = libraryAutomationAddObject.SelectAutomationColrction(setValue).Cast<AutomationElement>().Where(elems => elems.Current.LocalizedControlType == "поле").ToArray();
                                libraryAutomationAddObject.FindElement = elem[0];
                                libraryAutomationAddObject.SetValuePattern(hours);
                                libraryAutomationAddObject.FindElement = elem[1];
                                libraryAutomationAddObject.SetValuePattern(minute);
                                break;
                            }
                            libraryAutomationAddObject.FindFirstElement(Journal129AndJournal121.WindowsOk);
                            libraryAutomationAddObject.InvokePattern(libraryAutomationAddObject.FindElement);
                            break;
                        }
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// Поиск сторонней ветки по параметрам поиска 
        /// </summary>
        /// <param name="libraryAutomation">Библиотека Автомата</param>
        /// <param name="modelDataArea">Параметры ветки</param>
        /// <param name="tree">Ветка</param>
        private AutomationElement[] FindPathTree(LibraryAutomations libraryAutomation, DataArea modelDataArea, string tree)
        {
            var sw = tree.Split('\\').Last();
            var fullTree = string.Concat(PublicElementName.FullTree, $"Name:{sw}");
            libraryAutomation.IsEnableExpandTree(tree);
            libraryAutomation.FindFirstElement(fullTree, null, true);
            libraryAutomation.FindElement.SetFocus();
            libraryAutomation.ClickElements(fullTree, null, false, 25, 0, 0, 2);
            foreach (var dataAreaParameters in modelDataArea.Parameters)
            {
                while (true)
                {
                    if (libraryAutomation.FindFirstElement(string.Concat(modelDataArea.FullPathDataArea, modelDataArea.ListRowDataArea, dataAreaParameters.IndexParameters), null, true) != null)
                    {
                        libraryAutomation.FindFirstElement(dataAreaParameters.FindNameMemo, libraryAutomation.FindElement, true);
                        libraryAutomation.FindElement.SetFocus();
                        SendKeys.SendWait("{ENTER}");
                        AutoItX.Sleep(1000);
                        SendKeys.SendWait(dataAreaParameters.ParametersGrid);
                        SendKeys.SendWait("{ENTER}");
                        while (true)
                        {
                            libraryAutomation.FindFirstElement("Name:Условие", libraryAutomation.FindFirstElement(
                                                                   string.Concat(modelDataArea.FullPathDataArea,
                                                                   modelDataArea.ListRowDataArea, dataAreaParameters.IndexParameters), null, true), true);
                            libraryAutomation.ClickElement(libraryAutomation.FindElement);
                            if (libraryAutomation.FindFirstElement("Name:DropDown") != null)
                            {
                                var memo = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindElement);
                                var elemClick = memo.Cast<AutomationElement>().FirstOrDefault(x => x.Current.Name == dataAreaParameters.FindSelectParameter);
                                libraryAutomation.ClickElement(elemClick);
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, modelDataArea.Update);
            PublicGlobalFunction.PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation, modelDataArea.FullPathGrid);
            return libraryAutomation.SelectAutomationColrction(libraryAutomation.IsEnableElements(modelDataArea.FullPathGrid)).Cast<AutomationElement>().Where(elem => elem.Current.Name.Contains("select0 row")).ToArray();
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
        /// Функция если корректировка
        /// </summary>
        /// <param name="libraryAutomation">Библиотека Автомата</param>
        /// <param name="selectStatus">Выбор статуса</param>
        /// <param name="isCorrectStart">Признак корректировки</param>
        private void IsCorrectStart(LibraryAutomations libraryAutomation, string selectStatus, int isCorrectStart)
        {
            if (isCorrectStart != 0)
            {
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.PriznakDecl);
                AutoItX.WinWait(Journal129AndJournal121.WinPriznakDecl);
                AutoItX.WinActivate(Journal129AndJournal121.WinPriznakDecl);
                var libraryAutomationWin = new LibraryAutomations(Journal129AndJournal121.WinPriznakDecl);
                if (libraryAutomationWin.IsEnableElements(Journal129AndJournal121.PriznComboBox, null) != null)
                {
                    libraryAutomationWin.ClickElement(libraryAutomationWin.FindElement, 275);
                    var memo = libraryAutomationWin.SelectAutomationColrction(libraryAutomationWin.FindElement);
                    var elemClick = memo.Cast<AutomationElement>().FirstOrDefault(x => x.Current.Name == selectStatus);
                    libraryAutomationWin.SelectionComboBoxSelectionItemPattern(elemClick);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomationWin, Journal129AndJournal121.PriznakOk);
                }
            }
        }
        /// <summary>
        /// Роверка завершения углубленной проверки
        /// </summary>
        /// <param name="libraryAutomation"></param>
        /// <param name="journal"></param>
        private void IsStartIsOpenKm(LibraryAutomations libraryAutomation, Declaration3NdflFl journal)
        {
            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation,
             journal.ColorType2 == "ffffff"
                      ? JournalSolutionCalculations.StartKnp
                      : JournalSolutionCalculations.OpenKnp);
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
        /// Отправка и утверждение документа документа в БД
        /// </summary>
        /// <param name="libraryAutomation">Библиотека Автомата</param>
        /// <param name="journal">Журнал</param>
        /// <param name="messageInfo">Сообщение о документе</param>
        /// <param name="typeDocument">Тип документа</param>
        /// <param name="isClose">Отправить или закрыть</param>
        private void ApproveSaveDoc(LibraryAutomations libraryAutomation, Declaration3NdflFl journal, string messageInfo, string typeDocument, bool isClose = false)
        {
            Okp2GlobalFunction globalFunction = new Okp2GlobalFunction();
            globalFunction.ApproveRequirements(libraryAutomation, isClose);
            journal.IsLk3 = globalFunction.IsLk3;
            journal.IsMail = globalFunction.IsMail;
            journal.IsTks = globalFunction.IsTks;
            journal.MessageInfo = messageInfo;
            journal.TypeDocument = typeDocument;
            globalFunction.AddFileRequirements(ref journal, PathTempSave);
        }



        /// <summary>
        /// Метод для ОКП 5 создание шаблона извещений
        /// </summary>
        /// <param name="libraryAutomation">Библиотека автоматизации</param>
        /// <param name="elementGrid">Список Grid</param>
        /// <param name="templateText">Шаблон</param>
        /// <returns></returns>
        private List<string> ReturnMaterial(LibraryAutomations libraryAutomation, IEnumerable<AutomationElement> elementGrid, string templateText)
        {
            var listMaterial = new List<string>();
            if (elementGrid == null) return null;
            elementGrid.Select(x => libraryAutomation.SelectAutomationColrction(x).Cast<AutomationElement>()).ToList().ForEach(doc =>
            {
                string dateDoc = null;
                string number = null;
                doc.ToList().ForEach(model =>
                {
                    switch (model.Current.Name)
                    {
                        case "Дата документа":
                            dateDoc = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(model);
                            break;
                        case "Номер":
                            number = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(model);
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
        public void SaveAndUpdateDocument(TaxJournalDelivery taxJournalDelivery)
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
        /// <param name="regNumber">Регистрационный номер</param>
        /// <returns></returns>
        private TaxJournal121 SelectJournal(int? regNumber)
        {
            var dbAutomation = new AddObjectDb();
            var model = dbAutomation.SelectJournal(regNumber);
            dbAutomation.Dispose();
            return model;
        }
        /// <summary>
        /// Подстановка признака выявлены ли нарушения или нет
        /// </summary>
        /// <param name="libraryAutomation">Библиотека Автомата</param>
        /// <param name="dateEnd">Дата которую надо подставить</param>
        /// <param name="textErrorAndNotError">Выбранный текст</param>
        private void DialogKnp(LibraryAutomations libraryAutomation,DateTime dateEnd,string textErrorAndNotError)
        {
            while (true)
            {
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.CloseKnp);
                AutoItX.Sleep(1000);
                while (true)
                {

                    while (true)
                    {
                        if (libraryAutomation.IsEnableElements(Journal129AndJournal121.NewWindowEnable, null, true, 40, 0, false, ';') != null)
                        {
                            libraryAutomation.IsEnableElements(Journal129AndJournal121.NewComboBoxError, null, false, 40, 0, false, ';');
                            libraryAutomation.ClickElement(libraryAutomation.FindElement, 85);
                            var memo = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindElement);
                            var elemClick = memo.Cast<AutomationElement>().FirstOrDefault(x => x.Current.Name == textErrorAndNotError);
                            libraryAutomation.SelectionComboBoxSelectionItemPattern(elemClick);
                            libraryAutomation.IsEnableElements(Journal129AndJournal121.NewComboBoxError, null, false, 40, 0, false, ';');
                            if (libraryAutomation.SelectionComboBoxPatternIsSelect(libraryAutomation.FindElement) != "")
                            {
                                break;
                            }
                        }
                    }
                    libraryAutomation.InvokePattern(libraryAutomation.IsEnableElements(Journal129AndJournal121.NewOkEdit));
                    //Здесь ок и ошибка на дочернем окне libraryAutomationSign у ОКП 1
                    AutoItX.Sleep(1000);
                    AutoItX.WinWait(Journal129AndJournal121.NewWarningOk);
                    AutoItX.WinActivate(Journal129AndJournal121.NewWarningOk);
                    libraryAutomation.InvokePattern(libraryAutomation.IsEnableElements(Journal129AndJournal121.NewWarningButtonOk));
                    AutoItX.Sleep(1000);
                    break;
                }
                break;
            }
        }
        /// <summary>
        /// Функция генерации нажатий кнопок для вставки обстоятельств
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public Dictionary<int, int> SelectArrayToNumberButton(int number)
        {
            var startArray = new[] { 2, 4 };
            var arrayStart = new Dictionary<int, int>() { { startArray[0], startArray[1] } };
            var min_Row = 5;
            var stepRow = 3;
            if (number < min_Row) return null;
            var indexRow = (int)Math.Floor((decimal)(number - min_Row) / stepRow);
            if (indexRow != 0)
            {
                while (indexRow > 0)
                {
                    arrayStart.Add(startArray[0] += stepRow, startArray[1] += stepRow);
                    indexRow--;
                }
                return arrayStart;
            }
            return arrayStart;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number">Количество CheckBox</param>
        /// <returns></returns>
        public Dictionary<int, int> SelectArrayToNumberChekBox(int number)
        {
            var startArray = new[] { 6, 0 };
            var arrayStart = new Dictionary<int, int>() { { startArray[0], startArray[1] } };
            var min_Row = 6;
            var stepRow = 14;
            if (number < min_Row) return null;
            var indexRow = (int)Math.Floor((decimal)(number - min_Row) / stepRow);
            if (indexRow != 0)
            {
                while (indexRow > 0)
                {
                    arrayStart.Add(startArray[0] += stepRow, startArray[1] += 1);
                    indexRow--;
                }
                return arrayStart;
            }
            return arrayStart;
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
