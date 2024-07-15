using System;
using System.Linq;
using System.Windows.Automation;
using System.Windows.Forms;
using AutoIt;
using EfDatabaseAutomation.Automation.Base;
using EfDatabaseAutomation.Automation.BaseLogica.StatementJournal;
using LibraryAIS3Windows.AutomationsUI.LibaryAutomations;
using LibraryAIS3Windows.AutomationsUI.Otdels.Uregulirovanie;
using LibraryAIS3Windows.AutomationsUI.PublicElement;
using LibraryAIS3Windows.ButtonFullFunction.Okp3Function;
using LibraryAIS3Windows.ButtonsClikcs;
using LibraryAIS3Windows.Window;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using ViewModelLib.ModelTestAutoit.PublicModel.ModelDatePickerAdd;

namespace LibraryAIS3Windows.ButtonFullFunction.UregulirovanieAllFunction
{
    public class UregulirovaniePrintDocument
    {
        /// <summary>
        /// Путь ветки печати документа
        /// </summary>
        public string TreePrintDocument = "Налоговое администрирование\\Направление документов налогоплательщику\\2. Единичная печать и отправка в ОПС\\Печать и отправка\\2 - Документы к отправке";

        /// <summary>
        /// Печать документов для ветки  Налоговое администрирование\Направление документов налогоплательщику\2. Единичная печать и отправка в ОПС\Печать и отправка\2 - Документы к отправке
        /// </summary>
        /// <param name="statusButton">Кнопка</param>
        /// <param name="kndTemplate">КНД форма</param>
        /// <param name="datePicker">Календарь дата документа на печать</param>
        public void PrintDocument(StatusButtonMethod statusButton, string kndTemplate, DatePickerAdd datePicker)
        {
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            var selectModel = new RegisterDocumentsPrintingJournal();
            var rowNumber = 1;
            var parametersModel = new ModelDataArea();
            var sw = TreePrintDocument.Split('\\').Last();
            var fullTree = string.Concat(PublicElementName.FullTree, $"Name:{sw}");
            libraryAutomation.IsEnableExpandTree(TreePrintDocument);
            if (libraryAutomation.IsEnableElements(UregulirovaniePrintDocumentButton.OpenContextMenu) != null)
            {
                libraryAutomation.SetValuePattern("Номер документа, Дата документа");
                SendKeys.SendWait("{DOWN}");
            }
            parametersModel.PrintDocumentSend.Parameters.First(parameters => parameters.NameParameters == "КНД").ParametersGrid = kndTemplate;
            parametersModel.PrintDocumentSend.Parameters.First(parameters => parameters.NameParameters == "Дата документа").ParametersGrid = datePicker.DateResh.ToString("g");
            foreach (var dataAreaParameters in parametersModel.PrintDocumentSend.Parameters)
            {
                while (true)
                {
                    if (libraryAutomation.FindFirstElement(string.Concat(parametersModel.PrintDocumentSend.FullPathDataArea, parametersModel.PrintDocumentSend.ListRowDataArea, dataAreaParameters.IndexParameters), null, true) != null)
                    {
                        libraryAutomation.FindFirstElement(dataAreaParameters.FindNameMemo, libraryAutomation.FindElement, true);
                        libraryAutomation.FindElement.SetFocus();
                        SendKeys.SendWait("{ENTER}");
                        AutoItX.Sleep(1000);
                        SendKeys.SendWait(dataAreaParameters.ParametersGrid);
                        SendKeys.SendWait("{ENTER}");
                        break;
                    }
                }
            }
            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, parametersModel.PrintDocumentSend.Update);
            if(string.IsNullOrEmpty(PublicGlobalFunction.PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation, parametersModel.PrintDocumentSend.FullPathGrid)))
            {
                var allColumn = libraryAutomation.SelectAutomationColrction(libraryAutomation.IsEnableElements(string.Concat(parametersModel.PrintDocumentSend.FullPathGrid, parametersModel.PrintDocumentSend.ListRowDataGrid, rowNumber))).Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Column Headers"));
                libraryAutomation.InvokePattern(libraryAutomation.SelectAutomationColrction(allColumn).Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Получатель документа (полное наименование)")));
                AutomationElement automationElement;
                while ((automationElement = libraryAutomation.IsEnableElements(string.Concat(parametersModel.PrintDocumentSend.FullPathGrid, parametersModel.PrintDocumentSend.ListRowDataGrid, rowNumber), null, true)) != null)
                {
                    if (statusButton.Iswork)
                    {
                        var guidDoc = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Учетный номер")));
                        if (!selectModel.IsPrint(guidDoc))
                        {
                            var documentPrinter = new RegisterDocumentsPrinting
                            {
                                MachineName = Environment.MachineName,
                                TabelNumberUser = Environment.UserName,
                                NameFace = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                    libraryAutomation
                                        .SelectAutomationColrction(automationElement)
                                        .Cast<AutomationElement>().First(elem =>
                                            elem.Current.Name.Contains("Получатель документа (полное наименование)"))),
                                Inn = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                    libraryAutomation
                                        .SelectAutomationColrction(automationElement)
                                        .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("ИНН"))),
                                Address = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                    libraryAutomation
                                        .SelectAutomationColrction(automationElement)
                                        .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Адрес"))),
                                DateDocument = datePicker.DateResh,
                                NumberDocument = Convert.ToInt32(
                                    libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                        .SelectAutomationColrction(automationElement)
                                        .Cast<AutomationElement>()
                                        .First(elem => elem.Current.Name.Contains("Номер документа")))),
                                FormKnd = kndTemplate,
                                RegNumberDocumetGuid = guidDoc
                            };
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, parametersModel.PrintDocumentSend.Riborn);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, UregulirovaniePrintDocumentButton.Print);
                            documentPrinter.CountPage = Convert.ToInt32(libraryAutomation.IsEnableElements(UregulirovaniePrintDocumentButton.CoutPage, null, true).Current.Name);
                            if (documentPrinter.CountPage >= 2)
                            {
                                while (true)
                                {
                                    if (libraryAutomation.IsEnableElements(UregulirovaniePrintDocumentButton.IsTwoPrint) != null)
                                    {
                                        libraryAutomation.TogglePatternInputAndStatus(libraryAutomation.FindElement);
                                        if (libraryAutomation.IsEnableElements(UregulirovaniePrintDocumentButton.IsTwoPrintTwo) != null)
                                        {
                                            libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                                            break;
                                        }
                                    }
                                    if (libraryAutomation.IsEnableElements( UregulirovaniePrintDocumentButton.FocusListPrinter, null, true) == null) continue;
                                    libraryAutomation.FindElement.SetFocus();
                                    SendKeys.SendWait("{DOWN}");
                                }
                            }
                            else
                            {
                                while (true)
                                {
                                    if (libraryAutomation.IsEnableElements(UregulirovaniePrintDocumentButton.IsTwoPrintOne) != null)
                                    {
                                        libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                                        break;
                                    }
                                    if (libraryAutomation.IsEnableElements(UregulirovaniePrintDocumentButton.FocusListPrinter, null, true) == null) continue;
                                    libraryAutomation.FindElement.SetFocus();
                                    SendKeys.SendWait("{DOWN}");
                                }
                            }
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, UregulirovaniePrintDocumentButton.PrintAll);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, UregulirovaniePrintDocumentButton.Closed);
                            selectModel.SaveDocument(documentPrinter);
                        }
                    }
                    else
                    {
                        break;
                    }
                    rowNumber++;
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
