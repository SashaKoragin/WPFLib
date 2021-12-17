using System.Linq;
using System.Windows.Automation;
using System.Windows.Forms;
using AutoIt;
using EfDatabaseAutomation.Automation.BaseLogica.StatementJournal;
using LibraryAIS3Windows.AutomationsUI.LibaryAutomations;
using LibraryAIS3Windows.AutomationsUI.PublicElement;
using LibraryAIS3Windows.ButtonFullFunction.Okp3Function;
using LibraryAIS3Windows.ButtonsClikcs;
using LibraryAIS3Windows.Window;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace LibraryAIS3Windows.ButtonFullFunction.UregulirovanieFunction
{
   public class StatementF
    {

        public string TreeStatement = "Налоговое администрирование\\Урегулирование задолженности\\Проведение зачетов/возвратов\\Заявления НП о зачете/возврате (реестр)";

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
                        if(!status.Contains("Полностью исполнено"))
                        {
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, AutomationsUI.Otdels.Uregulirovanie.StatementNp.EditStatement);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, AutomationsUI.Otdels.Uregulirovanie.StatementNp.Create);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, AutomationsUI.Otdels.Uregulirovanie.StatementNp.WinOk);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, AutomationsUI.Otdels.Uregulirovanie.StatementNp.CreateResh);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, AutomationsUI.Otdels.Uregulirovanie.StatementNp.WinOkResh);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, AutomationsUI.Otdels.Uregulirovanie.StatementNp.Send);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, AutomationsUI.Otdels.Uregulirovanie.StatementNp.WinOk1);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, AutomationsUI.Otdels.Uregulirovanie.StatementNp.WinOk2);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, AutomationsUI.Otdels.Uregulirovanie.StatementNp.Back);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, AutomationsUI.Otdels.Uregulirovanie.StatementNp.Return);
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
