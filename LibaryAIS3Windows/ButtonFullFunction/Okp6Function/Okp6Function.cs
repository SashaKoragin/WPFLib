using AutoIt;
using EfDatabaseAutomation.Automation.Base;
using EfDatabaseAutomation.Automation.BaseLogica.SqlSelect.SelectAll;
using LibraryAIS3Windows.AutomationsUI.LibaryAutomations;
using LibraryAIS3Windows.AutomationsUI.Otdels.PublicJournal129And121;
using LibraryAIS3Windows.ButtonFullFunction.PreCheck;
using LibraryAIS3Windows.ButtonsClikcs;
using LibraryAIS3Windows.Window;
using System;
using System.Configuration;
using System.Linq;
using System.Windows.Automation;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace LibraryAIS3Windows.ButtonFullFunction.Okp6Function
{
    public class Okp6Function
    {
        /// <summary>
        /// Налоговое администрирование\Контрольная работа (налоговые проверки)\122. Камеральная налоговая проверка НДФЛ\03. Реестр налоговых деклараций (расчетов), сведения о КНП (все)
        /// Проверить завершить закрыть декларацию
        /// </summary>
        /// <param name="statusButton">Кнопка проставить Даты вручения</param>
        /// <param name="pathTemp">Путь к папке с выгрузкой</param>
        public void CheckDeclaration(StatusButtonMethod statusButton, string pathTemp)
        {
            var rowNumber = 1;
            var libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            var dataBaseAdd = new DataBaseElementAdd();
            libraryAutomation.ClickElements(Journal129AndJournal121.UpdateData121);
            PublicGlobalFunction.PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation, Journal129AndJournal121.GridTaxJournal121);
            AutomationElement automationElement;
            while ((automationElement = libraryAutomation.IsEnableElements(string.Concat(Journal129AndJournal121.AllTaxJournal121, rowNumber), null, true, 30)) != null)
            {
                if (statusButton.Iswork)
                {
                    var journalDeclarationFl = new DeclarationFl();

                    journalDeclarationFl.ColorType2 = libraryAutomation.GetColorPixel(libraryAutomation.SelectAutomationColrction(automationElement)
                                                      .Cast<AutomationElement>().Where(elem => elem.Current.Name == "").ToList()[1]);

                    var colorType3 = libraryAutomation.GetColorPixel(libraryAutomation.SelectAutomationColrction(automationElement)
                                                      .Cast<AutomationElement>().Where(elem => elem.Current.Name == "").ToList()[2]);

                    journalDeclarationFl.RegNumDecl = Convert.ToInt32(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                                      .SelectAutomationColrction(automationElement)
                                                      .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Рег. номер декларации (расчета)"))));

                    journalDeclarationFl.Psumm = Convert.ToDouble(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                                      .SelectAutomationColrction(automationElement)
                                                      .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Сумма по данным НП"))));

                    journalDeclarationFl.Knd = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                                     .SelectAutomationColrction(automationElement)
                                                     .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("КНД")));

                    journalDeclarationFl.NameDocument = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                                     .SelectAutomationColrction(automationElement)
                                                     .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Документ")));

                    journalDeclarationFl.Period = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                                     .SelectAutomationColrction(automationElement)
                                                     .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Отчетный период")));

                    journalDeclarationFl.NumberKor = Convert.ToInt32(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                                     .SelectAutomationColrction(automationElement)
                                                     .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Номер корректировки"))));

                    journalDeclarationFl.God = Convert.ToInt32(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                                     .SelectAutomationColrction(automationElement)
                                                     .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Отчетный год"))));

                    journalDeclarationFl.NameNp = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                                     .SelectAutomationColrction(automationElement)
                                                     .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Налогоплательщик")));

                    journalDeclarationFl.InnNp = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                                     .SelectAutomationColrction(automationElement)
                                                     .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("ИНН")));

                    if(journalDeclarationFl.ColorType2 == "add8e6")
                    {
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ViewDeclaration);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ExportDeclaration);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ExportFileOk);
                        AutoItX.ProcessWait("EXCEL.EXE", 60000);
                        AutoItX.Sleep(Convert.ToInt32(ConfigurationManager.AppSettings["Sleepeng"]));
                        PublicGlobalFunction.PublicGlobalFunction.CloseProcessProgram("EXCEL");
                        var file = PublicGlobalFunction.PublicGlobalFunction.ReturnNameLastFileTemp(pathTemp, "*.xlsx");
                        dataBaseAdd.AddDeclarationFl(file.NamePath, ref journalDeclarationFl);
                        var win = new WindowsAis3();
                        AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                        if (journalDeclarationFl.SummSignOfDevialion == 0)
                        {
                            if(colorType3 != "ffffff")
                            {
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.OpenComplexM);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.EditDeclaration);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Calculate);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ConfirmInput);
                                AutoItX.Sleep(4000);
                                while (true)
                                {
                                    if(libraryAutomation.IsEnableElements(Journal129AndJournal121.ClosedComplexDecl, null, true, 1) != null)
                                    {
                                        AutoItX.MouseWheel(ButtonConstant.Wheel, 10);
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ClosedComplexDecl);
                                        while (true)
                                        {
                                            AutoItX.Sleep(1000);
                                            libraryAutomation.SelectGetPreviousSiblingWindows();
                                            if (libraryAutomation.NewPreviousSiblingWindows.IsEnableElements(Journal129AndJournal121.NewWindowEnable, null, true, 1, 0, false, ';') != null)
                                            {
                                                libraryAutomation.NewPreviousSiblingWindows.IsEnableElements(Journal129AndJournal121.NewComboBoxError, null, false, 40, 0, false, ';');
                                                libraryAutomation.NewPreviousSiblingWindows.ClickElement(libraryAutomation.NewPreviousSiblingWindows.FindElement, -5);
                                                var memo = libraryAutomation.NewPreviousSiblingWindows.SelectAutomationColrction(libraryAutomation.NewPreviousSiblingWindows.FindElement);
                                                var elemClick = memo.Cast<AutomationElement>().FirstOrDefault(x => x.Current.Name == "Нарушения не выявлены");
                                                libraryAutomation.NewPreviousSiblingWindows.ClickElement(elemClick);
                                                libraryAutomation.NewPreviousSiblingWindows.InvokePattern(libraryAutomation.NewPreviousSiblingWindows.IsEnableElements(Journal129AndJournal121.NewOkEdit));
                                                AutoItX.WinWait(Journal129AndJournal121.NewWarningOk);
                                                AutoItX.WinActivate(Journal129AndJournal121.NewWarningOk);
                                                libraryAutomation.NewPreviousSiblingWindows = new LibraryAutomations(Journal129AndJournal121.NewWarningOk);
                                                libraryAutomation.NewPreviousSiblingWindows.InvokePattern(libraryAutomation.NewPreviousSiblingWindows.IsEnableElements(Journal129AndJournal121.NewWarningButtonOk));
                                                AutoItX.Sleep(2000);
                                                break;
                                            }
                                            if (libraryAutomation.NewPreviousSiblingWindows.IsEnableElements(Journal129AndJournal121.WinOkDecl, null, true, 1) != null)
                                            {
                                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation.NewPreviousSiblingWindows, Journal129AndJournal121.WinOkDecl);
                                            }
                                        }
                                        break;
                                    }
                                }
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ClosedComplex121);
                            }
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
        /// Налоговое администрирование\Контрольная работа (налоговые проверки)\122. Камеральная налоговая проверка НДФЛ\03. Реестр налоговых деклараций (расчетов), сведения о КНП (все)
        /// Проставить срок проверки декларации
        /// </summary>
        /// <param name="statusButton">Кнопка проставить Даты вручения</param>
        public void AddTerm(StatusButtonMethod statusButton)
        {
            var rowNumber = 1;
            var libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            libraryAutomation.ClickElements(Journal129AndJournal121.UpdateData121);
            PublicGlobalFunction.PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation, Journal129AndJournal121.GridTaxJournal121);
            AutomationElement automationElement;
            while ((automationElement = libraryAutomation.IsEnableElements(string.Concat(Journal129AndJournal121.AllTaxJournal121, rowNumber), null, true, 30)) != null)
            {
                if (statusButton.Iswork)
                {
                    var term = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                        .SelectAutomationColrction(automationElement)
                        .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Название срока")));
                    if (string.IsNullOrWhiteSpace(term))
                    {
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.OpenComplexM);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.UpdateComplex);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.WinOkC);
                        while (true)
                        {
                            if (libraryAutomation.IsEnableElements(Journal129AndJournal121.EditP, null, true, 1) != null)
                            {
                                var win = new WindowsAis3();
                                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                                break;
                            }
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
    }
}
