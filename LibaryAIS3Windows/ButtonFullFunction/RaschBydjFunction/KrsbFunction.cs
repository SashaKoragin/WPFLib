using System;
using System.Globalization;
using System.Linq;
using System.Windows.Automation;
using System.Windows.Forms;
using AutoIt;
using EfDatabaseAutomation.Automation.Base;
using EfDatabaseAutomation.Automation.BaseLogica.KrsbJournal;
using LibaryXMLAuto.XsdModelAutoGenerate;
using LibraryAIS3Windows.AutomationsUI.LibaryAutomations;
using LibraryAIS3Windows.AutomationsUI.Otdels.PublicJournal129And121;
using LibraryAIS3Windows.AutomationsUI.PublicElement;
using LibraryAIS3Windows.ButtonFullFunction.Okp3Function;
using LibraryAIS3Windows.ButtonsClikcs;
using LibraryAIS3Windows.Window;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace LibraryAIS3Windows.ButtonFullFunction.RaschBydjFunction
{
   public class KrsbFunction
   {
        /// <summary>
        /// Ветка Налоговое администрирование\\Расчеты с бюджетом\\Ведение КРСБ\\Просмотр списка КРСБ налогоплательщика
        /// </summary>
        public string TreeKrsb =  "Налоговое администрирование\\Расчеты с бюджетом\\Ведение КРСБ\\Просмотр списка КРСБ налогоплательщика ";
        /// <summary>
        /// Ветка Налоговое администрирование\Расчеты с бюджетом\Журнал неналоговых доходов\Раздел II. Доходы, начисления по которым отсутствуют в базе данных налоговых органов
        /// </summary>
        public string TreeIncomeJournal = "Налоговое администрирование\\Расчеты с бюджетом\\Журнал неналоговых доходов\\Раздел II. Доходы, начисления по которым отсутствуют в базе данных налоговых органов";

        /// <summary>
        /// Логика поиска суммы КРСБ и расчет
        /// </summary>
        /// <param name="libraryAutomation">Библиотека автоматизации</param>
        /// <param name="sumNp">Сумма плательщика для анализа</param>
        /// <param name="journal">Журнал БД</param>
        /// <param name="status">Статус карточки</param>
        /// <param name="kbk">Cписок КБК</param>
        /// <param name="oktmo">ОКТМО</param>
        public string FindSum(LibraryAutomations libraryAutomation, decimal sumNp, TaxJournal121 journal, string[] kbk, string status = "01", string oktmo = "")
        {
            decimal sumUpl = (decimal)0.00;
            int isClosed = 2;
            var sw = TreeKrsb.Split('\\').Last();
            var fullTree = string.Concat(PublicElementName.FullTree, $"Name:{sw}");
            libraryAutomation.IsEnableExpandTree(TreeKrsb);
            libraryAutomation.FindFirstElement(fullTree, null, true);
            libraryAutomation.FindElement.SetFocus();
            libraryAutomation.ClickElements(fullTree, null, false, 25, 0, 0, 2);
            while (true)
            {
                if (libraryAutomation.IsEnableElements(KrsbAis3.MemoInn, null, true) != null)
                {
                    libraryAutomation.SetValuePattern(journal.Inn);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, KrsbAis3.FindInn);
                    while (true)
                    {
                        if (libraryAutomation.IsEnableElements(KrsbAis3.Rrsb, null, true) != null)
                        {
                            //Если не находим продолжаем выставлять 1000
                            var allKrsb = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindFirstElement(KrsbAis3.ListKrsb)).Cast<AutomationElement>().Distinct()
                               .FirstOrDefault(elem => elem.Current.Name.Contains("List`1 row ") &&
                               kbk.Contains(
                               libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                               libraryAutomation.SelectAutomationColrction(elem).Cast<AutomationElement>()
                               .First(doc => doc.Current.Name.Contains("КБК")))) &&
                               libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                               libraryAutomation.SelectAutomationColrction(elem).Cast<AutomationElement>()
                               .First(doc => doc.Current.Name.Contains("Закрыта"))) == "False" &&
                               libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                               libraryAutomation.SelectAutomationColrction(elem).Cast<AutomationElement>()
                               .First(doc => doc.Current.Name.Contains("Статус НП"))) == status &&
                               libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                               libraryAutomation.SelectAutomationColrction(elem).Cast<AutomationElement>()
                               .First(doc => doc.Current.Name.Contains("ОКТМО"))) == oktmo.Trim());
                            if (allKrsb != null)
                            {
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, KrsbAis3.Rrsb);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, KrsbAis3.OpenYers);
                                libraryAutomation.InvokePattern(libraryAutomation.FindFirstElement(KrsbAis3.ListYers));
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, KrsbAis3.UpdateInfo);
                                if (libraryAutomation.IsEnableElements(KrsbAis3.UpdateInfo, null, true) != null)
                                {
                                    var listCash = libraryAutomation
                                        .SelectAutomationColrction(
                                            libraryAutomation.FindFirstElement(KrsbAis3.ListCash))
                                        .Cast<AutomationElement>().Distinct().Where(elem => elem.Current.Name.Contains("List`1 row ") &&
                                                                                            libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                                                                                libraryAutomation.SelectAutomationColrction(elem).Cast<AutomationElement>()
                                                                                                    .First(doc => doc.Current.Name.Contains("Отчётный период"))) == $"{journal.Period.Replace("за ", "")} {journal.God}"
                                                                                            &&
                                                                                            libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                                                                                libraryAutomation.SelectAutomationColrction(elem).Cast<AutomationElement>()
                                                                                                    .First(doc => doc.Current.Name.Contains("Наименование операции"))) == $"начислено налога по расчету"
                                        ).ToList();
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, KrsbAis3.Summ);

                                    foreach (var sum in listCash)
                                    {
                                        sum.SetFocus();
                                        var panel = libraryAutomation
                                            .SelectAutomationColrction(libraryAutomation.IsEnableElements(KrsbAis3.viewPl, null, false, 40, 0, false, ';'))
                                            .Cast<AutomationElement>().ToArray();
                                        if (libraryAutomation.IsEnableElements(KrsbAis3.FindPl, panel[1], false, 1) != null)
                                        {
                                            var listSum = libraryAutomation
                                                .SelectAutomationColrction(
                                                    libraryAutomation.FindElement)
                                                .Cast<AutomationElement>().Distinct().Where(elem => elem.Current.Name.Contains("List`1 row ")).ToList();
                                            foreach (var ss in listSum)
                                            {
                                                sumUpl += Convert.ToDecimal(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                                    libraryAutomation
                                                        .SelectAutomationColrction(ss)
                                                        .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Сумма погашения"))));
                                            }
                                        }
                                    }
                                }
                                isClosed = 3;
                            }
                            break;
                        }
                    }
                    MouseCloseFormRsb(isClosed);
                    break;
                }
            }
            return Convert.ToString(sumNp - sumUpl, CultureInfo.CurrentCulture);
        }
        /// <summary>
        /// Закрытие КРСБ по списку плательщиков
        /// </summary>
        /// <param name="statusButton">Кнопка старт</param>
        public void ClosedKrsbPl(StatusButtonMethod statusButton)
        {
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            var selectModel = new KrsbJournal();
            var isCklickExit = 1;
            var listModel = selectModel.SelectKrsbNps(statusButton.IsChekcs);
            var sw = TreeKrsb.Split('\\').Last();
            var fullTree = string.Concat(PublicElementName.FullTree, $"Name:{sw}");
            libraryAutomation.IsEnableExpandTree(TreeKrsb);
            libraryAutomation.FindFirstElement(fullTree, null, true);
            libraryAutomation.FindElement.SetFocus();
            libraryAutomation.ClickElements(fullTree, null, false, 25, 0, 0, 2);
            foreach (var krsbNp in listModel)
            {
                if (statusButton.Iswork)
                {
                    while (true)
                    {
                        if (libraryAutomation.IsEnableElements(KrsbAis3.MemoInn, null, true) != null)
                        {
                            libraryAutomation.SetValuePattern(krsbNp.Inn);
                            if(libraryAutomation.ParseValuePattern(libraryAutomation.IsEnableElements(KrsbAis3.VielListKrsb))!="True")
                            {
                                libraryAutomation.InvokePattern(libraryAutomation.IsEnableElements(KrsbAis3.VielListKrsb));
                            }
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, KrsbAis3.FindInn);
                            while (true)
                            {
                                if (libraryAutomation.IsEnableElements(KrsbAis3.UpdateButton, null, true) != null)
                                {
                                    var id = krsbNp.Krsbs.Select(x => x.IdParameter).ToArray();
                                    var firstIsClosedKrsb = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindFirstElement(KrsbAis3.ListKrsb)).Cast<AutomationElement>()
                                        .FirstOrDefault(elem => elem.Current.Name.Contains("List`1 row ") &&
                                                                libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                                                    libraryAutomation.SelectAutomationColrction(elem).Cast<AutomationElement>()
                                                                        .First(doc => doc.Current.Name.Contains("Закрыта"))) == "False"
                                                                && id.Any(idKrsb => idKrsb.Equals(Convert.ToInt64(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                                                    libraryAutomation.SelectAutomationColrction(elem).Cast<AutomationElement>()
                                                                        .First(doc => doc.Current.Name.Contains("ИД КРСБ"))))))) ;
                                    if (firstIsClosedKrsb != null)
                                    {
                                        libraryAutomation.InvokePattern(libraryAutomation.IsEnableElements(KrsbAis3.ClosedKrsbMenu));
                                        while (true)
                                        {
                                            if (libraryAutomation.IsEnableElements(KrsbAis3.ClosedUpdate, null, true) != null)
                                            {
                                                var allClosedKrsb = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindFirstElement(KrsbAis3.ListKrsbClosed)).Cast<AutomationElement>().Where(elem => elem.Current.Name != "Data Area").Distinct()
                                                    .Where(elem => elem.Current.Name.Contains("List`1 row ") &&
                                                                   libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                                                       libraryAutomation.SelectAutomationColrction(elem).Cast<AutomationElement>()
                                                                           .First(doc => doc.Current.Name.Contains("Отметка"))) == "False"
                                                                   && id.Any(idKrsb => idKrsb.Equals(Convert.ToInt64(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                                                       libraryAutomation.SelectAutomationColrction(elem).Cast<AutomationElement>()
                                                                           .First(doc => doc.Current.Name.Contains("ИД КРСБ"))))))).ToList();
                                                foreach (AutomationElement closed in allClosedKrsb)
                                                {
                                                    Krsb krsb;
                                                    var elem = libraryAutomation.FindFirstElement("Name:Отметка", closed);
                                                    elem.SetFocus();
                                                    libraryAutomation.ClickElement(elem);
                                                    AutoItX.Sleep(200);
                                                    if (libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(elem) == "False")
                                                    {
                                                        var idkrsb = libraryAutomation.FindFirstElement("Name:ИД КРСБ", closed);
                                                        idkrsb.SetFocus();
                                                        var idModel = Convert.ToInt64(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(idkrsb));
                                                        krsb = krsbNp.Krsbs.First(x => x.IdParameter == idModel);
                                                        krsb.IsPriznak = false;
                                                    }
                                                    else
                                                    {
                                                        var idkrsb = libraryAutomation.FindFirstElement("Name:ИД КРСБ", closed);
                                                        idkrsb.SetFocus();
                                                        var idModel = Convert.ToInt64(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(idkrsb));
                                                        krsb = krsbNp.Krsbs.First(x => x.IdParameter == idModel);
                                                        krsb.IsPriznak = true;
                                                    }
                                                    selectModel.SaveModelKrsb(krsb);
                                                }
                                                libraryAutomation.IsEnableElements(KrsbAis3.MemoClosed);
                                                libraryAutomation.FindElement.SetFocus();
                                                AutoItX.ClipPut("Ликвидация предприятия");
                                                AutoItX.Send(ButtonConstant.CtrlV);
                                                if (libraryAutomation.IsEnableElements(KrsbAis3.WinError3, null, true, 5) != null) 
                                                {
                                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, KrsbAis3.WinError3);
                                                    //libraryAutomation.IsEnableElements(KrsbAis3.MemoClosed);
                                                    //libraryAutomation.FindElement.SetFocus();
                                                    //AutoItX.ClipPut("Ошибочное создание КРСБ");
                                                    //AutoItX.Send(ButtonConstant.CtrlV);
                                                    isCklickExit = 2;
                                                    krsbNp.IsPriznakFullClosed = false;
                                                    break;
                                                }
                                                libraryAutomation.FindFirstElement(KrsbAis3.ClosedKrsbButton);
                                                if (libraryAutomation.FindElement.Current.IsEnabled)
                                                {
                                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, KrsbAis3.ClosedKrsbButton);
                                                    if (libraryAutomation.IsEnableElements(KrsbAis3.WinError4Cancel, null, true, 5) != null)
                                                    {
                                                        if (libraryAutomation.IsEnableElements(KrsbAis3.WinError2, null, true, 5) != null)
                                                        {
                                                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, KrsbAis3.WinError2);
                                                        }
                                                        else
                                                        {
                                                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, KrsbAis3.ClosedKrsbButton);
                                                            if (libraryAutomation.IsEnableElements(KrsbAis3.WinError4Cancel, null, true, 5) != null)
                                                            {
                                                                //Здесь надо делать
                                                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, KrsbAis3.WinError4Ok);
                                                                if (libraryAutomation.IsEnableElements(KrsbAis3.Win2QwetionKill, null, true, 5) != null)
                                                                {
                                                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, KrsbAis3.Win1Ok);
                                                                    if (libraryAutomation.IsEnableElements(KrsbAis3.Win2Qwetion, null, true, 5) != null)
                                                                    {
                                                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation,KrsbAis3.Win2No);
                                                                    }
                                                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, KrsbAis3.Win2Yes);
                                                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, KrsbAis3.Win3Ok);
                                                                    if (libraryAutomation.IsEnableElements(KrsbAis3.WinError1, null, true, 5) != null)
                                                                    {
                                                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, KrsbAis3.WinError1);
                                                                    }
                                                                }
                                                            }
                                                            krsbNp.IsPriznakFullClosed = true;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (libraryAutomation.IsEnableElements(KrsbAis3.WinError2, null, true, 5) != null)
                                                        {
                                                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, KrsbAis3.WinError2);
                                                        }
                                                        else
                                                        {
                                                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, KrsbAis3.Win1Ok);
                                                            if (libraryAutomation.IsEnableElements(KrsbAis3.Win2Qwetion, null, true, 5) != null)
                                                            {
                                                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, KrsbAis3.Win2No);
                                                            }
                                                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, KrsbAis3.Win2Yes);
                                                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, KrsbAis3.Win3Ok);
                                                            if (libraryAutomation.IsEnableElements(KrsbAis3.WinError1, null, true, 5) != null)
                                                            {
                                                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, KrsbAis3.WinError1);
                                                            }
                                                        } 
                                                        krsbNp.IsPriznakFullClosed = true;
                                                    }
                                                    isCklickExit = libraryAutomation.IsEnableElements(KrsbAis3.UpdateButton, null, true) != null ? 1 : 2;
                                                }
                                                else
                                                {
                                                    isCklickExit = 2;
                                                    krsbNp.IsPriznakFullClosed = true;
                                                }
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        foreach(var krsb in krsbNp.Krsbs)
                                        {
                                            krsb.IsPriznak = true;
                                            selectModel.SaveModelKrsb(krsb);
                                        }
                                        krsbNp.IsPriznakFullClosed = true;
                                    }
                                    MouseCloseFormRsb(isCklickExit);
                                    isCklickExit = 1;
                                    break;
                                }
                            }
                            break;
                        }
                    }
                    selectModel.SaveModelNp(krsbNp);
                }
                else
                {
                    MouseCloseFormRsb(isCklickExit);
                    break;
                }
            }
        }

        /// <summary>
        /// Автомат на ветку Налоговое администрирование\Расчеты с бюджетом\Журнал неналоговых доходов\Раздел II. Доходы, начисления по которым отсутствуют в базе данных налоговых органов
        /// </summary>
        /// <param name="statusButton">Кнопка старт</param>
        /// <param name="pathListStatement">Полный путь к списку с начислениями</param>
        public void IncomeJournalStart(StatusButtonMethod statusButton, string pathListStatement)
        {
            var codeIfns = "7751";
            var kbk = "18210102040011000110";
            var KbkCash = "03100643000000014800";
            LibaryXMLAuto.ReadOrWrite.XmlReadOrWrite read = new LibaryXMLAuto.ReadOrWrite.XmlReadOrWrite();
            object obj = read.ReadXml(pathListStatement, typeof(AutoGenerateSchemes));
            AutoGenerateSchemes modelListIncomeJournal = (AutoGenerateSchemes)obj;
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            var parametersModel = new ModelDataArea();
            var sw = TreeIncomeJournal.Split('\\').Last();
            var fullTree = string.Concat(PublicElementName.FullTree, $"Name:{sw}");
            libraryAutomation.IsEnableExpandTree(TreeIncomeJournal);
            libraryAutomation.FindFirstElement(fullTree, null, true);
            libraryAutomation.FindElement.SetFocus();
            libraryAutomation.ClickElements(fullTree, null, false, 25, 0, 0, 2);
            if (modelListIncomeJournal.IncomeJournal != null)
            {
                var groupInn = modelListIncomeJournal.IncomeJournal.GroupBy(x => x.Inn).ToList();
                AutoItX.Sleep(1000);
                if (libraryAutomation.IsEnableElements(IncomeJournalKrsb.CodeNo, null, true) != null)
                {
                    libraryAutomation.SetLegacyIAccessibleValuePattern(codeIfns);
                }
                foreach (var inn in groupInn)
                {
                    var selectModel = modelListIncomeJournal.IncomeJournal.Where(x => x.Inn == inn.Key).ToArray();
                    if (libraryAutomation.IsEnableElements(IncomeJournalKrsb.Error, null, false, 5) != null)
                    {
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, IncomeJournalKrsb.Error);
                    }
                    if (statusButton.Iswork)
                    {
                        parametersModel.DataAreaIncomeJournal.Parameters.First(parameters => parameters.NameParameters == "КБК УФК").ParametersGrid = kbk;
                        parametersModel.DataAreaIncomeJournal.Parameters.First(parameters => parameters.NameParameters == "ИНН").ParametersGrid = inn.Key;
                        foreach (var dataAreaParameters in parametersModel.DataAreaIncomeJournal.Parameters)
                        {
                            while (true)
                            {
                                if (libraryAutomation.FindFirstElement(string.Concat(parametersModel.DataAreaIncomeJournal.FullPathDataArea, parametersModel.DataAreaIncomeJournal.ListRowDataArea, dataAreaParameters.IndexParameters), null, true) != null)
                                {
                                    libraryAutomation.FindFirstElement(dataAreaParameters.FindNameMemo, libraryAutomation.FindElement, true);
                                    libraryAutomation.FindElement.SetFocus();
                                    SendKeys.SendWait("{ENTER}");
                                    AutoItX.Sleep(1000);
                                    SendKeys.SendWait(dataAreaParameters.ParametersGrid);
                                    SendKeys.SendWait("{ENTER}");
                                    while (true)
                                    {
                                        libraryAutomation.FindFirstElement("Name:Условие", libraryAutomation.FindFirstElement(string.Concat(
                                                    parametersModel.DataAreaIncomeJournal.FullPathDataArea,
                                                    parametersModel.DataAreaIncomeJournal.ListRowDataArea,
                                                    dataAreaParameters.IndexParameters), null, true), true);
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
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, parametersModel.DataAreaIncomeJournal.Update);
                        PublicGlobalFunction.PublicGlobalFunction.IsWaitLoadtatuBar(libraryAutomation, IncomeJournalKrsb.StatusBar);
                        foreach (var incomeJournal in selectModel)
                        {
                            try
                            {
                                var findP = libraryAutomation
                                .SelectAutomationColrction(libraryAutomation.IsEnableElements(parametersModel.DataAreaIncomeJournal.FullPathGrid)).Cast<AutomationElement>().Where(elem => elem.Current.Name != "Data Area")
                                .Distinct().FirstOrDefault(doc => libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                                                      libraryAutomation.SelectAutomationColrction(doc).Cast<AutomationElement>()
                                                                          .First(elem => elem.Current.Name.Contains("Сумма (рублей)"))) == incomeJournal.Summ
                                                                  &&
                                                                  Convert.ToDateTime(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                                                      libraryAutomation.SelectAutomationColrction(doc).Cast<AutomationElement>()
                                                                          .First(elem => elem.Current.Name.Contains("Дата зачисления на счёт 40101")))) == incomeJournal.DateTimePayment);
                                if (findP == null) continue;
                                {
                                    libraryAutomation.ClickElement(findP);
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, IncomeJournalKrsb.StartUt);
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, IncomeJournalKrsb.YesUt);
                                    if (libraryAutomation.IsEnableElements(IncomeJournalKrsb.ErrorUt) != null)
                                    {
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, IncomeJournalKrsb.ErrorUt);
                                    }
                                    else
                                    {
                                        while (true)
                                        {
                                            if (libraryAutomation.IsEnableElements(IncomeJournalKrsb.MemoNum, null, false, 5) == null) continue;
                                            libraryAutomation.SetLegacyIAccessibleValuePattern("1");
                                            libraryAutomation.IsEnableElements(IncomeJournalKrsb.Data, null, true);
                                            libraryAutomation.SetLegacyIAccessibleValuePattern(DateTime.Now.ToString("dd.MM.yy"));
                                            libraryAutomation.IsEnableElements(IncomeJournalKrsb.InnMemo, null, true);
                                            libraryAutomation.SetLegacyIAccessibleValuePattern(incomeJournal.Inn);
                                            libraryAutomation.IsEnableElements(IncomeJournalKrsb.Status, null, true);
                                            libraryAutomation.SetLegacyIAccessibleValuePattern("13");
                                            libraryAutomation.IsEnableElements(IncomeJournalKrsb.Kbk, null, true);
                                            libraryAutomation.SetLegacyIAccessibleValuePattern(kbk);
                                            libraryAutomation.IsEnableElements(IncomeJournalKrsb.Inn, null, true);
                                            libraryAutomation.SetLegacyIAccessibleValuePattern(incomeJournal.InnMo);
                                            libraryAutomation.IsEnableElements(IncomeJournalKrsb.Kpp, null, true);
                                            libraryAutomation.SetLegacyIAccessibleValuePattern(incomeJournal.KppMo);
                                            libraryAutomation.IsEnableElements(IncomeJournalKrsb.Oktmo, null, true);
                                            libraryAutomation.SetLegacyIAccessibleValuePattern(incomeJournal.Oktmo);
                                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, IncomeJournalKrsb.ButtonSelectCash);
                                            libraryAutomation.SelectAutomationColrction(libraryAutomation.IsEnableElements(IncomeJournalKrsb.SelectCash)).Cast<AutomationElement>().Where(elem => elem.Current.Name != "Data Area")
                                                             .Distinct().FirstOrDefault(doc => libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                                                                      libraryAutomation.SelectAutomationColrction(doc).Cast<AutomationElement>()
                                                                                          .First(elem => elem.Current.Name.Contains("Номер счета"))) == KbkCash);

                                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, IncomeJournalKrsb.Select);
                                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, IncomeJournalKrsb.ButtonResh);
                                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, IncomeJournalKrsb.ButtonYesResh);
                                            break;
                                        }
                                        while (true)
                                        {
                                            if (libraryAutomation.IsEnableElements(IncomeJournalKrsb.DateResh, null, false, 5) == null) continue;
                                            libraryAutomation.SetLegacyIAccessibleValuePattern(DateTime.Now.ToString("dd.MM.yy"));
                                            var list = libraryAutomation.SelectAutomationColrction(libraryAutomation.IsEnableElements(IncomeJournalKrsb.GridSelect)).Cast<AutomationElement>().Where(elem => elem.Current.Name.Contains("List`1 row ")).Distinct();
                                            foreach (var row in list)
                                            {
                                                var elemCheck = libraryAutomation.SelectAutomationColrction(row).Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("выбор"));
                                                libraryAutomation.ClickElement(elemCheck);
                                            }
                                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, IncomeJournalKrsb.Send);
                                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, IncomeJournalKrsb.SendYes);
                                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, IncomeJournalKrsb.Exit);
                                            break;
                                        }
                                    }
                                    read.DeleteAtributXml(pathListStatement, LibaryXMLAuto.GenerateAtribyte.GeneratorAtribute.GenerateAtrAutoGenerateSchemesIncomeJournal(incomeJournal.Number));
                                }
                            }
                            catch
                            {
                                //ignore ошибка в сложном Linq findP продолжаем перебор
                            }
                            //Перебор значений в группе
                        }
                    }
                }
            }
            MouseCloseFormRsb(1);
        }

        /// <summary>
        /// Закрыть подчиненные формы
        /// </summary>
        private void MouseCloseFormRsb(int countClose)
        {
            var win = new WindowsAis3();
            while (countClose > 0)
            {
                AutoItX.Sleep(1000);
                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                countClose--;
            }
        }
   }
}
