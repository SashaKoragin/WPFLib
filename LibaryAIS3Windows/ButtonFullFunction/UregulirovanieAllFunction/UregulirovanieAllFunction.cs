using System;
using System.Linq;
using System.Windows.Automation;
using System.Windows.Forms;
using AutoIt;
using EfDatabaseAutomation.Automation.BaseLogica.StatementJournal;
using LibaryXMLAuto.XsdModelAutoGenerate;
using LibraryAIS3Windows.AutomationsUI.LibaryAutomations;
using LibraryAIS3Windows.AutomationsUI.Otdels.Uregulirovanie;
using LibraryAIS3Windows.AutomationsUI.PublicElement;
using LibraryAIS3Windows.ButtonFullFunction.Okp3Function;
using LibraryAIS3Windows.ButtonsClikcs;
using LibraryAIS3Windows.Window;
using LibraryAIS3Windows.Window.Otdel.Uregulirovanie.UtverzdenieSz;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace LibraryAIS3Windows.ButtonFullFunction.UregulirovanieAllFunction
{
   public class UregulirovanieAllFunction
    {
        public string TreeStatement = "Налоговое администрирование\\Урегулирование задолженности\\Проведение зачетов/возвратов\\Заявления НП о зачете/возврате (реестр)";
        /// <summary>
        /// Путь к актам
        /// </summary>
        public string TreeActAdd = "Налоговое администрирование\\Урегулирование задолженности\\Взыскание задолженности за счет имущества НП ФЛ\\Ввод данных судебного акта";
        /// <summary>
        /// Заявления о зачете возврате
        /// </summary>
        /// <param name="statusButton">Кнопка автомата</param>
        public void StatementStart(StatusButtonMethod statusButton)
        {
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            var selectModel = new StatementJournal();
            var isClickExit = 1;
            var parametersModel = new ModelDataArea();
            var listModel = selectModel.SelectStatementNp(statusButton.IsChekcs);
            var sw = TreeStatement.Split('\\').Last();
            var fullTree = string.Concat(PublicElementName.FullTree, $"Name:{sw}");
            libraryAutomation.IsEnableExpandTree(TreeStatement);
            libraryAutomation.FindFirstElement(fullTree, null, true);
            libraryAutomation.FindElement.SetFocus();
            libraryAutomation.ClickElements(fullTree, null, false, 25, 0, 0, 2);
            foreach (var statements in listModel)
            {
                if (statusButton.Iswork)
                {
                    parametersModel.DataAreaStatement.Parameters.First(parameters => parameters.NameParameters == "ИНН").ParametersGrid = statements.Inn;
                    parametersModel.DataAreaStatement.Parameters.First(parameters => parameters.NameParameters == "Номер заявления").ParametersGrid = string.Join("/", statements.Statements.Select(x => x.NumberStatement).ToArray());
                    foreach (var dataAreaParameters in parametersModel.DataAreaStatement.Parameters)
                    {
                        while (true)
                        {
                            if (libraryAutomation.FindFirstElement(string.Concat(parametersModel.DataAreaStatement.FullPathDataArea, parametersModel.DataAreaStatement.ListRowDataArea, dataAreaParameters.IndexParameters), null, true) != null)
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
                                                                       string.Concat(parametersModel.DataAreaStatement.FullPathDataArea,
                                                                       parametersModel.DataAreaStatement.ListRowDataArea, dataAreaParameters.IndexParameters), null, true), true);
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
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, parametersModel.DataAreaStatement.Update);
                    PublicGlobalFunction.PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation, parametersModel.DataAreaStatement.FullPathGrid);
                    var listMemo = libraryAutomation.SelectAutomationColrction(libraryAutomation.IsEnableElements(parametersModel.DataAreaStatement.FullPathGrid))
                                   .Cast<AutomationElement>().Where(elem => elem.Current.Name.Contains("select0 row")).Distinct();
                    foreach (var automationElement in listMemo)
                    {
                        var numberStatement = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                .SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Номер заявления")));
                        var status = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                .SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Признак исполнения")));
                        if (!status.Contains("Полностью исполнено"))
                        {
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, StatementNp.EditStatement);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, StatementNp.Create);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, StatementNp.WinOk);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, StatementNp.CreateResh);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, StatementNp.WinOkResh);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, StatementNp.Send);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, StatementNp.WinOk1);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, StatementNp.WinOk2);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, StatementNp.Back);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, StatementNp.Return);
                        }
                        var statement = statements.Statements.First(x => x.NumberStatement == numberStatement);
                        statement.IsPriznak = "Ок!";
                        selectModel.SaveModelStatement(statement);
                    }
                    statements.IsPriznakFullClosed = "Ок!";
                    selectModel.SaveModelNp(statements);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, parametersModel.DataAreaStatement.Filters);
                }
                else
                {
                    break;
                }
            }
            MouseCloseFormRsb(isClickExit);
        }
        /// <summary>
        /// Налоговое администрирование\Урегулирование задолженности\Проведение зачетов/возвратов\Заявления НП о зачете/возврате (реестр)
        /// Очистить состояние обработки заявления НП
        /// </summary>
        /// <param name="statusButton">Запуск остановка</param>
        public void ClearStatusStatementNp(StatusButtonMethod statusButton)
        {
            var rowNumber = 1;
            var dateControl = new DateTime(2022, 1, 1);
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, StatementNp.Update);
            PublicGlobalFunction.PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation, StatementNp.JournalReestr);
            AutomationElement automationElement;
            while ((automationElement = libraryAutomation.IsEnableElements( string.Concat(StatementNp.JournalReestr, "\\Name:select0 row " + rowNumber), null, false, 50)) != null)
            {
                if (statusButton.Iswork)
                {
                    var dataStatementNp = Convert.ToDateTime(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                           .SelectAutomationColrction(automationElement)
                                           .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Дата заявления"))));

                    var resultStatus = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                       .SelectAutomationColrction(automationElement)
                                       .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Результат обработки налоговым автоматом")));

                    var status = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                 .SelectAutomationColrction(automationElement)
                                 .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Комментарий к обработке налоговым автоматом")));

                    if(!resultStatus.Contains("обработано") & !status.Contains("Статус обработки заявления был сброшен.") & dataStatementNp> dateControl)
                    {
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, StatementNp.Edit);
                        while (true)
                        {
                            if (libraryAutomation.IsEnableElements(StatementNp.Save, null, true, 1) != null)
                            {
                                if (libraryAutomation.IsEnableElements(StatementNp.DateAdd, null, true, 1) != null)
                                {
                                    libraryAutomation.SetValuePattern(DateTime.Now.ToString("dd.MM.yy"));
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, StatementNp.Save);
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, StatementNp.OkSave);
                                    break;
                                }
                            }
                        }
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, StatementNp.ClearStatus);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, StatementNp.YesWin);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, StatementNp.OkWin);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, StatementNp.OkWin);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, StatementNp.Back);
                        PublicGlobalFunction.PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation, StatementNp.JournalReestr);
                    }
                }
                else
                {
                    break;
                }
                rowNumber++;
                
            }
            MouseCloseFormRsb(1);
        }


        /// <summary>
        /// Общие задания\Урегулирование задолженности\05.08.09.02. Взыскание задолженности за счет имущества НП ФЛ. Формирование 
        /// Служебной записки и Заявлений о взыскании за счет имущества ФЛ
        /// \05.08.09.02.03 Утверждение и подписание Заявлений о взыскании за счет имущества ФЛ
        /// \05.08.09.02.03.06. Подпись руководителями Заявлений о взыскании за счет имущества ФЛ
        /// </summary>
        /// <param name="statusButton">Запуск остановка</param>
        public void SignatureHeadProperty(StatusButtonMethod statusButton)
        {
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            
            while ((libraryAutomation.IsEnableElements(AutomationsUI.Otdels.Uregulirovanie.SignatureHeadProperty.JournalSignature, null, true, 30)) != null)
            {
                if (statusButton.Iswork)
                {
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, PublicElementName.StartUser);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, AutomationsUI.Otdels.Uregulirovanie.SignatureHeadProperty.ButtonSignatureAll);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, AutomationsUI.Otdels.Uregulirovanie.SignatureHeadProperty.EndSignature);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, AutomationsUI.Otdels.Uregulirovanie.SignatureHeadProperty.WinExit);
                }
                else
                {
                    break;
                }
            }
        }
        /// <summary>
        /// Урегулирование задолженности/05.09 Уведомление о необходимости выгрузки документов в ЛК\
        /// 05.09 Сообщения о принятом решении об отказе  подлежащие выгрузке в ЛК
        /// </summary>
        /// <param name="statusButton">Запуск остановка</param>
        /// <param name="pathJournalError">Журнал ошибок</param>
        /// <param name="pathJournalOk">Журнал отработанных</param>
        public void RecouncementLk(StatusButtonMethod statusButton, string pathJournalError, string pathJournalOk)
        {
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            LibraryAutomations libraryAutomationCheck = new LibraryAutomations(WindowsAis3.AisNalog3);
            AutomationElement elemental;
            while ((elemental = libraryAutomation.IsEnableElements(AutomationsUI.Otdels.Uregulirovanie.RecouncementLk.JurnalsRecouncement, null, true)) !=
                   null)
            {
                if (statusButton.Iswork)
                {
                    var inn = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation.IsEnableElements(AutomationsUI.Otdels.Uregulirovanie.RecouncementLk.RowInn, elemental));
                    libraryAutomation.FindElement.SetFocus();
                    libraryAutomation.FindFirstElement(PublicElementName.StartUser);
                    var climbablePoint = libraryAutomation.FindElement.GetClickablePoint();
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, (int)climbablePoint.X, (int)climbablePoint.Y);
                    var isChecked = "";
                    while (true)
                    {
                        if (isChecked == "" || string.IsNullOrWhiteSpace(isChecked))
                        {
                            isChecked = libraryAutomationCheck.ParseElementLegacyIAccessiblePatternIdentifiers(
                                libraryAutomationCheck.IsEnableElements(AutomationsUI.Otdels.Uregulirovanie.RecouncementLk.CheckDataLk2));
                            if (isChecked != "") break;
                        }

                        if (libraryAutomation.IsEnableElements(AutomationsUI.Otdels.Uregulirovanie.RecouncementLk.CheckStatusLk2) == null) continue;
                        libraryAutomation.ClickElements(AutomationsUI.Otdels.Uregulirovanie.RecouncementLk.CheckStatusLk2);
                    }

                    while (true)
                    {
                        if (libraryAutomation.IsEnableElements(AutomationsUI.Otdels.Uregulirovanie.RecouncementLk.WinOkEndUser, null, true, 1) != null)
                        {
                            libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                            break;
                        }

                        if (libraryAutomation.IsEnableElements(AutomationsUI.Otdels.Uregulirovanie.RecouncementLk.CheckExit, null, true) == null) continue;
                        libraryAutomation.ClickElements(AutomationsUI.Otdels.Uregulirovanie.RecouncementLk.CheckExit);
                    }

                    LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathJournalOk,
                        $"ИНН Налогоплательщика: {inn}; Дата вручения: {isChecked}",
                        "Проставили признак отправки в ЛК успешно!");
                }
                else
                {
                    break;
                }
            }
        }
        /// <summary>
        /// Обработка задания требований
        /// 05.08.03.0X.03. Утверждение требований об уплате
        /// </summary>
        /// <param name="statusButton">Кнопка статуса чтобы остановить</param>
        /// <returns></returns>
        public void FormRequirementUplTax(StatusButtonMethod statusButton)
        {
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            LibraryAutomations libraryAutomationCheck = new LibraryAutomations(WindowsAis3.AisNalog3);
            AutomationElement elemental;
            while ((elemental = libraryAutomation.IsEnableElements(SettlementDebts.JournalDocuments, null, true)) != null)
            {
                if (statusButton.Iswork)
                {
                    libraryAutomation.IsEnableElements(SettlementDebts.SumT, elemental);
                    libraryAutomation.FindElement.SetFocus();
                    libraryAutomation.FindFirstElement(PublicElementName.StartBeforeQ);
                    var climbablePoint = libraryAutomation.FindElement.GetClickablePoint();
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, (int)climbablePoint.X, (int)climbablePoint.Y);
                    libraryAutomationCheck.IsEnableElements(SettlementDebts.JournalSum, null, true);
                    var isChecked = false;
                    while (true)
                    {
                        if (isChecked)
                        {
                            if (libraryAutomation.IsEnableElements(SluzZ.WinErrorNalog, null, false, 5) != null)
                            {
                                libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                                libraryAutomation.ClickElements(SettlementDebts.ButtonSettlement);
                            }
                            break;
                        }
                        if (libraryAutomation.IsEnableElements(SettlementDebts.ButtonSettlement) == null) continue;
                        libraryAutomation.ClickElements(SettlementDebts.ButtonSettlement);
                        isChecked = true;
                    }
                    while (true)
                    {
                        if (libraryAutomation.IsEnableElements(SluzZ.WinCloseNalog, null, false, 1) != null)
                        {
                            libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                            break;
                        }
                        if (libraryAutomation.IsEnableElements(SettlementDebts.ButtonSend, null, false, 1) == null)
                            continue;
                        libraryAutomation.ClickElements(SettlementDebts.ButtonSend);
                    }
                }
                else
                {
                    break;
                }
            }
        }
        /// <summary>
        /// Автоматизация Общие задания\Урегулирование задолженности\05.08.09.02.
        /// Взыскание задолженности за счет имущества НП ФЛ.Формирование Служебной записки и Заявлений о взыскании за счет имущества ФЛ\05.08.09.02.02 
        /// Утверждение и подписание Служебных записок\05.08.09.02.02.04. Утверждение Служебной записки
        /// Автомат для утверждения служебной записки
        /// </summary>
        /// <param name="statusButton">Запуск остановка</param>
        public void AutoStatementOfficeNote(StatusButtonMethod statusButton)
        {
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            while ((libraryAutomation.IsEnableElements(TextStatementOfficeNote.JournalStatementOffice, null, true)) != null)
            {
                if (statusButton.Iswork)
                {
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, PublicElementName.StartUser);
                    while (true)
                    {
                        libraryAutomation.IsEnableElements(TextStatementOfficeNote.IsCheck);
                        libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                        if (libraryAutomation.TogglePattern(libraryAutomation.FindElement) == "On")
                        {
                            break;
                        }
                    }
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, TextStatementOfficeNote.ButtonIsCheckAll);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, TextStatementOfficeNote.Exit);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, TextStatementOfficeNote.WinExit);
                }
                else
                {
                    break;
                }
            }
        }
        /// <summary>
        /// Автоматизация Общие задания\Урегулирование задолженности\05.08.09.02. Взыскание задолженности за счет имущества НП ФЛ. 
        /// Формирование Служебной записки и Заявлений о взыскании за счет имущества ФЛ\
        /// 05.08.09.02.02 Утверждение и подписание Служебных записок\05.08.09.02.02.06. Подписание Служебной записки
        /// </summary>
        /// <param name="statusButton">Запуск остановка</param>
        public void AutoSignatureOfficeNote(StatusButtonMethod statusButton)
        {
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            while ((libraryAutomation.IsEnableElements(TextSignatureOfficeNote.JournalSignatureOffice, null, true)) !=
                   null)
            {
                if (statusButton.Iswork)
                {
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, PublicElementName.StartUser);
                    while (true)
                    {
                        libraryAutomation.IsEnableElements(TextSignatureOfficeNote.IsCheck);
                        libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                        if (libraryAutomation.TogglePattern(libraryAutomation.FindElement) == "On")
                        {
                            break;
                        }
                    }
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, TextStatementOfficeNote.ButtonIsCheckAll);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, TextStatementOfficeNote.Exit);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, TextStatementOfficeNote.WinExit);
                }
                else
                {
                    break;
                }
            }
        }
        /// <summary>
        /// Функция автоматизации задачи подписания пользовательских заданий
        /// Общие задания\Урегулирование задолженности\05.09 Формирование решения об отказе по заявлению\Подписание руководителем НО
        /// </summary>
        /// <param name="statusButton">Статус кнопка</param>
        public void SigningDecisionApplication(StatusButtonMethod statusButton)
        {
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            while ((libraryAutomation.IsEnableElements(TextSignatureOfficeNote.JournalSignatureOffice, null, true)) != null)
            {
                if (statusButton.Iswork)
                {
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, PublicElementName.StartBeforeQ);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, TextSignatureOfficeNote.Sign);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, TextSignatureOfficeNote.WinOk);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, TextSignatureOfficeNote.WinOk1);
                }
                else
                {
                    break;
                }
            }
        }
        /// <summary>
        /// Функция утверждение решений
        /// Общие задания\Урегулирование задолженности\05.09 Формирование решения об отказе по заявлению\Утверждение решений об отказе
        /// </summary>
        /// <param name="statusButton">Статус кнопка</param>
        public void StatementDecisionApplication(StatusButtonMethod statusButton)
        {
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            while ((libraryAutomation.IsEnableElements(TextSignatureOfficeNote.JournalSignatureOffice, null, true)) != null)
            {
                if (statusButton.Iswork)
                {
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, PublicElementName.StartBeforeQ);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, TextSignatureOfficeNote.Statement);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, TextSignatureOfficeNote.WinStatement);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, TextSignatureOfficeNote.WinOk1);
                }
                else
                {
                    break;
                }
            }
        }
        /// <summary>
        /// Задача по запуску БП по списку 
        /// </summary>
        /// <param name="inn">ИНН</param>
        /// <param name="kpp">КПП</param>
        public void StartProcess(string inn, string kpp)
        {
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            if (libraryAutomation.IsEnableElement(ProcessStartSash.StartW))
            {
                libraryAutomation.IsEnableElements(ProcessStartSash.InnInput, null, true);
                libraryAutomation.SetValuePattern(inn);
                if (kpp != null)
                {
                    libraryAutomation.IsEnableElements(ProcessStartSash.KppInput, null, true);
                    libraryAutomation.SetValuePattern(kpp);
                }
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ProcessStartSash.StartW);
            }
        }
        /// <summary>
        /// Задача по запуску БП по списку
        /// Налоговое администрирование\Урегулирование задолженности\Взыскание задолженности за счет имущества НП ФЛ\Ввод данных судебного акта
        /// </summary>
        /// <param name="statusButton">Кнопка</param>
        /// <param name="pathList">Путь к списку ИНН</param>
        public void StartProcessAct(StatusButtonMethod statusButton, string pathList)
        {
            LibaryXMLAuto.ReadOrWrite.XmlReadOrWrite read = new LibaryXMLAuto.ReadOrWrite.XmlReadOrWrite();
            object obj = read.ReadXml(pathList, typeof(AutoGenerateSchemes));
            AutoGenerateSchemes modelList = (AutoGenerateSchemes)obj;
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            var sw = TreeActAdd.Split('\\').Last();
            var parametersModel = new ModelDataArea();
            var fullTree = string.Concat(PublicElementName.FullTree, $"Name:{sw}");
            libraryAutomation.IsEnableExpandTree(TreeActAdd);
            libraryAutomation.FindFirstElement(fullTree, null, true);
            libraryAutomation.FindElement.SetFocus();
            libraryAutomation.ClickElements(fullTree, null, false, 25, 0, 0, 2);
            if (modelList.JudicialAct != null)
            {
                foreach (var modelAct in modelList.JudicialAct)
                {
                    if (statusButton.Iswork)
                    {

                        parametersModel.DataAreaStatementAct.Parameters.First(parameters => parameters.NameParameters == "ИНН").ParametersGrid = modelAct.Inn;
                        parametersModel.DataAreaStatementAct.Parameters.First(parameters => parameters.NameParameters == "Номер заявления").ParametersGrid = modelAct.NumberAkt;
                        foreach (var dataAreaParameters in parametersModel.DataAreaStatementAct.Parameters)
                        {
                            while (true)
                            {
                                if (libraryAutomation.FindFirstElement(string.Concat(parametersModel.DataAreaStatementAct.FullPathDataArea, parametersModel.DataAreaStatementAct.ListRowDataArea, dataAreaParameters.IndexParameters), null, true) != null)
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
                                                                           string.Concat(parametersModel.DataAreaStatementAct.FullPathDataArea,
                                                                           parametersModel.DataAreaStatementAct.ListRowDataArea, dataAreaParameters.IndexParameters), null, true), true);
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
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, parametersModel.DataAreaStatementAct.Update);
                        PublicGlobalFunction.PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation, parametersModel.DataAreaStatementAct.FullPathGrid);
                        var listMemo = libraryAutomation.SelectAutomationColrction(libraryAutomation.IsEnableElements(parametersModel.DataAreaStatementAct.FullPathGrid))
                                       .Cast<AutomationElement>().Where(elem => elem.Current.Name.Contains("select0 row")).Distinct();
                        if (listMemo.Any())
                        {
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, StatementAct.SendAct);
                            while (true)
                            {
                                if (libraryAutomation.IsEnableElements(StatementAct.IsCheked, null, false, 5) != null)
                                {
                                    libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                                    libraryAutomation.IsEnableElements(StatementAct.SendActJ, null, true);
                                    libraryAutomation.SetLegacyIAccessibleValuePattern("Отказано");
                                    libraryAutomation.IsEnableElements(StatementAct.SendDelo, null, true);
                                    libraryAutomation.SetLegacyIAccessibleValuePattern("б\\н");
                                    libraryAutomation.IsEnableElements(StatementAct.DateSend, null, true);
                                    libraryAutomation.SetValuePattern(DateTime.Now.ToString("dd.MM.yy"));
                                    libraryAutomation.IsEnableElements(StatementAct.DateSendNo, null, true);
                                    libraryAutomation.SetValuePattern(DateTime.Now.ToString("dd.MM.yy"));
                                    libraryAutomation.IsEnableElements(StatementAct.DateSendNoPr, null, true);
                                    libraryAutomation.SetValuePattern(DateTime.Now.ToString("dd.MM.yy"));
                                    libraryAutomation.IsEnableElements(StatementAct.DateStrenge, null, true);
                                    libraryAutomation.SetValuePattern(DateTime.Now.ToString("dd.MM.yy"));
                                    libraryAutomation.SelectItemCombobox(libraryAutomation.IsEnableElements(StatementAct.ComboboxModel), "Отказано", 0);
                                    break;
                                }
                            }
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, StatementAct.Save);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, StatementAct.Ok);
                        }
                        read.DeleteAtributXml(pathList, LibaryXMLAuto.GenerateAtribyte.GeneratorAtribute.GenerateAtrAutoGenerateSchemesAct(modelAct.Inn));
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, parametersModel.DataAreaStatementAct.Filters);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            MouseCloseFormRsb(1);
        }

        /// <summary>
        /// Автомат на ветку
        /// Общие задания\Урегулирование задолженности\05.09 Ручное формирование решений на зачет/возврат/возврат процентов\05.09 Заявления НП для ручной обработки
        /// </summary>
        /// <param name="statusButton">Кнопка автомата</param>
        public void ApplicationManualProcessing(StatusButtonMethod statusButton)
        {
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            while ((libraryAutomation.IsEnableElements(TextSignatureOfficeNote.JournalSignatureOffice, null, true)) != null)
            {
                if (statusButton.Iswork)
                {
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, PublicElementName.StartBeforeQ);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, TextSignatureOfficeNote.FinishStatement);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, TextSignatureOfficeNote.WinFinishStatement);
                }
                else
                {
                    break;
                }
            }
        }
        /// <summary>
        /// Автомат на ветку
        /// Общие задания\Урегулирование задолженности\05.09.01(06.01) Формирование сообщения о факте излишней уплаты (излишнего взыскания)\05.09.01(06.01) Формирование сообщения об излишней уплате (взыскании)\Утверждение сообщений
        /// А так же на ветку 
        /// Общие задания\Урегулирование задолженности\05.09.01(06.01) Формирование сообщения о факте излишней уплаты (излишнего взыскания)\05.09.01(06.01) Формирование сообщения об излишней уплате (взыскании)\05.09.01(06.01) Формирование решений о зачете по инициативе НО\Утверждение решений о зачете
        /// </summary>
        /// <param name="statusButton">Кнопка автомата</param>
        public void MessageApprovalAndDecisionsApproval(StatusButtonMethod statusButton)
        {
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            while ((libraryAutomation.IsEnableElements(TextSignatureOfficeNote.JournalSignatureOffice, null, true)) != null)
            {
                if (statusButton.Iswork)
                {
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, PublicElementName.StartBeforeQ);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, TextSignatureOfficeNote.RejectAll);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, TextSignatureOfficeNote.SaveAndClose);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, TextSignatureOfficeNote.CloseWork);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, TextSignatureOfficeNote.OkWin);
                }
                else
                {
                    break;
                }
            }
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
