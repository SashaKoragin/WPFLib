using System;
using System.Configuration;
using System.Diagnostics.Eventing.Reader;
using AutoIt;
using LibraryAIS3Windows.AutomationsUI.LibaryAutomations;
using LibraryAIS3Windows.AutomationsUI.Otdels.PublicJournal129And121;
using LibraryAIS3Windows.ButtonsClikcs;
using LibraryAIS3Windows.Window;
using System.Linq;
using System.Windows.Automation;
using System.Windows.Forms;
using EfDatabaseAutomation.Automation.Base;
using LibraryAIS3Windows.AutomationsUI.Otdels.PreCheck;
using LibraryAIS3Windows.ButtonFullFunction.PreCheck;
using LibraryAIS3Windows.AutomationsUI.PublicElement;
using EfDatabaseAutomation.Automation.BaseLogica.AddObjectDb;

namespace LibraryAIS3Windows.ButtonFullFunction.Okp1Function
{
    public class StaticMode121
    {
        /// <summary>
        /// Ветка для НБО
        /// </summary>
        private static string Tree = "Налоговое администрирование\\Контрольная работа (налоговые проверки)\\101. Мониторинг и обработка документов\\Реестр документов НБО";
        /// <summary>
        /// Data Area НБО
        /// </summary>
        private static string TreeDataArea = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:masterNavigator\\AutomationId:splitContainer\\AutomationId:gridConditions\\Name:List`1 row ";
        /// <summary>
        /// Обновить документы
        /// </summary>
        private static string TreeUpdate = "Name:DockTop\\Name:Ribbon\\Name:Реестр документов НБО\\Name:Документ\\Name:Обновить данные";
        /// <summary>
        /// Полный путь к Grid
        /// </summary>
        private static string FullPathGrid = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:masterNavigator\\AutomationId:splitContainer\\AutomationId:gridData";

        private static string TreeExport = "Name:DockTop\\Name:Ribbon\\Name:Работа с налоговым документом\\Name:Документ\\Name:Экспорт в Excel";
        /// <summary>
        /// Режим проставки статистики по КНД 1151001 и КНД 1151006
        /// </summary>
        /// <param name="libraryAutomation">Библиотека автоматизации</param>
        /// <param name="listDocError">Список ошибок</param>
        public void StaticMode1Nk1151001And1151006(LibraryAutomations libraryAutomation, AutomationElement[] listDocError)
        {
            LibraryAutomations libraryAutomationDoc = new LibraryAutomations(WindowsAis3.AisNalog3);
            var numHelp = new[] {"3","6","9"};
            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ModeStatic);
            AutoItX.Send(ButtonConstant.Tab);
            AutoItX.Send(ButtonConstant.Enter);
            while (true)
            {
                if (libraryAutomation.IsEnableElements(Journal129AndJournal121.WinTableError, null, true) != null)
                {
                    var listModeDocument = libraryAutomationDoc.SelectAutomationColrction(libraryAutomationDoc.FindFirstElement(Journal129AndJournal121.WinTableError)).Cast<AutomationElement>().Distinct().Where(elem => elem.Current.Name.Contains("Band 0 row"));
                    //Надо искать проставленна ли галочка или нет если проставлена закрываем если нет проставляем idObject
                    var isCheck = listModeDocument.FirstOrDefault(doc =>
                                     libraryAutomationDoc.ParseElementLegacyIAccessiblePatternIdentifiers(
                                       libraryAutomationDoc.SelectAutomationColrction(doc).Cast<AutomationElement>()
                                           .First(elem => elem.Current.Name.Contains("Выбрать"))) == "True");
                    var isNum = listModeDocument.FirstOrDefault(doc =>  numHelp.Any(num =>num.Equals(
                                                              libraryAutomationDoc.ParseElementLegacyIAccessiblePatternIdentifiers(
                                                              libraryAutomationDoc.SelectAutomationColrction(doc).Cast<AutomationElement>()
                                                              .First(elem => elem.Current.Name.Contains("Ун записи"))))));
                    var idObject = libraryAutomationDoc.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.FindFirstElement("Name:Ун записи", isNum, true));
                    if (isCheck == null)
                    {
                        var selectRow = listModeDocument.FirstOrDefault(doc =>
                                     libraryAutomationDoc.ParseElementLegacyIAccessiblePatternIdentifiers(
                                       libraryAutomationDoc.SelectAutomationColrction(doc).Cast<AutomationElement>()
                                           .First(elem => elem.Current.Name.Contains("Ун записи"))) == idObject);
                        libraryAutomation.FindFirstElement("Name:Выбрать", selectRow, true);
                        libraryAutomation.ClickElement(libraryAutomation.FindElement);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SaveUdError);
                        break;
                    }
                    else
                    {
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.CloseWinError);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Функция проверки декларации на нарушения и проставления нарушения
        /// </summary>
        /// <param name="libraryAutomation">Библиотека автоматизации</param>
        /// <param name="taxJournal">Журнал для проверок деклараций на наличие нарушений</param>
        /// <param name="pathTemp">Путь к сохранению документа</param>
        /// <param name="rowNumber">Номер обрабатываемой строки</param>
        public void IsErrorDeclaration(LibraryAutomations libraryAutomation, TaxJournal121Error taxJournal, string pathTemp, int rowNumber)
        {
            //Проверка декларации раскладка
            var sum = DeclarationIntelligenceUl(libraryAutomation, taxJournal.RegNumDeclaration, pathTemp);
            if (sum != null)
            {
                IsStartIsOpenKm(libraryAutomation, taxJournal);
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.EditP);
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Avg);
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SendAvg);
                while (true)
                {
                    if (libraryAutomation.IsEnableElements(Journal129AndJournal121.SendAvg, null, true) == null)
                    {
                        break;
                    }
                }
                var win = new WindowsAis3();
                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                if (sum == (decimal)0.00)
                {
                    libraryAutomation.ClickElements(Journal129AndJournal121.UpdateData121);
                    while (true)
                    {
                        if (string.IsNullOrWhiteSpace(PublicGlobalFunction.PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation, Journal129AndJournal121.GridTaxJournal121)))
                        {
                            break;
                        }
                        libraryAutomation.ClickElements(Journal129AndJournal121.UpdateData121);
                    }
                    AutomationElement automationElement;
                    LibraryAutomations libraryAutomationWin;
                    while ((automationElement =
                               libraryAutomation.IsEnableElements(
                                   string.Concat(Journal129AndJournal121.AllTaxJournal121, rowNumber), null, true, 30)) != null)
                    {
                        ParseDeclaration(libraryAutomation, automationElement,ref taxJournal);
                        if (taxJournal.Color5 != "ff")
                        {
                            IsStartIsOpenKm(libraryAutomation, taxJournal);
                            if (taxJournal.KorrectNumber != 0)
                            {
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation,
                                    Journal129AndJournal121.PriznakDecl);
                                AutoItX.WinWait(Journal129AndJournal121.WinPriznakDecl);
                                AutoItX.WinActivate(Journal129AndJournal121.WinPriznakDecl);
                                libraryAutomationWin = new LibraryAutomations(Journal129AndJournal121.WinPriznakDecl);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomationWin,
                                    Journal129AndJournal121.PriznComboBox);
                                var memo = libraryAutomationWin.SelectAutomationColrction(
                                    libraryAutomationWin.FindFirstElement(Journal129AndJournal121.PanelComboBox));
                                var elemClick = memo.Cast<AutomationElement>().FirstOrDefault(x =>
                                    x.Current.Name ==
                                    "учтены результаты КНП (с учетом решений ВНО и судов)  по предыдущей декларации");
                                libraryAutomationWin.ClickElement(elemClick);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomationWin,
                                    Journal129AndJournal121.PriznakOk);
                                //Написать алгоритм для таких
                            }

                            if (taxJournal.DateCloseValidation == null && taxJournal.Color5 == "ffffff")
                            {
                                //Открыть или начать Проверку
                                DialogKnp(libraryAutomation, "Нарушения не выявлены");
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation,
                                    Journal129AndJournal121.ClosedComplex121);
                                AutoItX.WinWait(Journal129AndJournal121.WinNameComplex);
                                AutoItX.WinActivate(Journal129AndJournal121.WinNameComplex);
                                libraryAutomationWin = new LibraryAutomations(Journal129AndJournal121.WinNameComplex);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomationWin,
                                    Journal129AndJournal121.WinOkCloseComplex);
                                AutoItX.Sleep(1000);
                                taxJournal.MessageInfoR1 = "Нарушения не выявлены";
                            }
                            else if (taxJournal.DateCloseValidation == null && taxJournal.Color5 != "ffffff")
                            {

                                DialogKnp(libraryAutomation, "Выявлены нарушения");
                                win = new WindowsAis3();
                                AutoItX.MouseClick(ButtonConstant.MouseLeft,
                                    win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                                AutoItX.Sleep(1000);
                                taxJournal.MessageInfoR1 = "Выявлены нарушения";
                            }
                        }
                        else
                        {
                            taxJournal.MessageError = "Статус документа не позволяет проставить выявление нарушения!";
                        }
                        break;
                    }
                }
                else
                {
                    taxJournal.MessageError = $"Сумма по учёту расхождения равна {sum}. Дальнейшая обработка не возможна!";
                }
                SaveDocument(taxJournal);
                //Сохранение журнала
            }
            else
            {
                MessageBox.Show("Нет доступа к ветке " + Tree);
            }
        }

        /// <summary>
        /// Подстановка признака выявлены ли нарушения или нет
        /// </summary>
        /// <param name="libraryAutomation">Библиотека Автомата</param>
        /// <param name="textErrorAndNotError">Выбранный текст</param>
        private void DialogKnp(LibraryAutomations libraryAutomation, string textErrorAndNotError)
        {
            while (true)
            {
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.CloseKnp);
                AutoItX.Sleep(1000);
                while (true)
                {
                    LibraryAutomations libraryAutomationSign = new LibraryAutomations(TreeWalker.RawViewWalker.GetPreviousSibling(libraryAutomation.RootAutomationElements));
                    while (true)
                    {
                        if (libraryAutomationSign.IsEnableElements(Journal129AndJournal121.NewWindowEnable, null, true, 40, 0, false, ';') != null)
                        {
                            libraryAutomationSign.IsEnableElements(Journal129AndJournal121.NewComboBoxError, null, false, 40, 0, false, ';');
                            libraryAutomationSign.ClickElement(libraryAutomationSign.FindElement, 0, 10);
                            var memo = libraryAutomationSign.SelectAutomationColrction(libraryAutomationSign.FindElement);
                            var elemClick = memo.Cast<AutomationElement>().FirstOrDefault(x => x.Current.Name == textErrorAndNotError);
                            libraryAutomationSign.ClickElement(elemClick);
                            libraryAutomationSign.IsEnableElements(Journal129AndJournal121.NewComboBoxError, null, false, 40, 0, false, ';');
                            if (libraryAutomationSign.SelectionComboBoxPatternIsSelect(libraryAutomationSign.FindElement) != "")
                            {
                                break;
                            }
                        }
                    }
                    libraryAutomationSign.InvokePattern(libraryAutomationSign.IsEnableElements(Journal129AndJournal121.NewOkEdit));
                    AutoItX.Sleep(1000);
                    AutoItX.WinWait(Journal129AndJournal121.NewWarningOk);
                    AutoItX.WinActivate(Journal129AndJournal121.NewWarningOk);
                    libraryAutomationSign = new LibraryAutomations(Journal129AndJournal121.NewWarningOk);
                    libraryAutomationSign.InvokePattern(libraryAutomationSign.IsEnableElements(Journal129AndJournal121.NewWarningButtonOk));
                    AutoItX.Sleep(1000);
                    break;
                }
                break;
            }
        }

        /// <summary>
        /// Если признак углубленной проверки не белый то Открыть Комплекс Мероприятий
        /// В противном случае Начать Углубленную Проверку
        /// </summary>
        /// <param name="libraryAutomation">Библиотека Автомата</param>
        /// <param name="taxJournal">Журнал</param>
        private void IsStartIsOpenKm(LibraryAutomations libraryAutomation, TaxJournal121Error taxJournal)
        {
            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation,
                taxJournal.Color3 == "ffffff"
                    ? Journal129AndJournal121.StartKnp
                    : Journal129AndJournal121.OpenKnp);
        }

        /// <summary>
        /// Обработка ветки Налоговое администрирование\Контрольная работа (налоговые проверки)\101. Мониторинг и обработка документов\Реестр документов НБО
        /// </summary>
        /// <param name="libraryAutomation">Библиотека автоматизации</param>
        /// <param name="regNumDeclaration">Регистрационный номер декларации</param>
        /// <param name="pathTemp">Путь к сохранению документа</param>
        private decimal? DeclarationIntelligenceUl(LibraryAutomations libraryAutomation, int regNumDeclaration, string pathTemp)
        {
            if (!libraryAutomation.IsEnableExpandTree(Tree)) return null;
            var sw = Tree.Split('\\').Last();
            var fullTree = string.Concat(PublicElementName.FullTree, $"Name:{sw}");
            DataBaseElementAdd dataBaseAdd = new DataBaseElementAdd();
            WindowsAis3 win;
            libraryAutomation.FindFirstElement(fullTree, null, true);
            libraryAutomation.FindElement.SetFocus();
            libraryAutomation.ClickElements(fullTree, null, false, 25, 0, 0, 2);

            while (true)
            {
                if (libraryAutomation.FindFirstElement(string.Concat(TreeDataArea, 9), null, true) != null)
                {
                    libraryAutomation.FindFirstElement("Name:Значение", libraryAutomation.FindElement, true);
                    libraryAutomation.FindElement.SetFocus();
                    SendKeys.SendWait("{ENTER}");
                    AutoItX.Sleep(500);
                    SendKeys.SendWait(regNumDeclaration.ToString());
                    break;
                }
            }
            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, TreeUpdate);
            PublicGlobalFunction.PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation, FullPathGrid);
            if (PublicGlobalFunction.PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation, FullPathGrid) != "Данные, удовлетворяющие заданным условиям не найдены.")
            {
                var allReport = libraryAutomation
                    .SelectAutomationColrction(libraryAutomation.IsEnableElements(FullPathGrid))
                    .Cast<AutomationElement>().Where(elem => elem.Current.Name != "Data Area").Distinct().ToList();

                foreach (var element in allReport)
                {
                    var declarationAll = dataBaseAdd.AddDeclarationAll(libraryAutomation, element);
                    while (true)
                    {
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, PreCheckElementNameDeclaration.ReestrNbo);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, PreCheckElementNameDeclaration.ViewDeclaretion);
                        AutoItX.Sleep(10000);
                        if (libraryAutomation.IsEnableElements(TreeExport) != null)
                        {
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, TreeExport);
                            break;
                        }
                    }
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, PreCheckElementNameDeclaration.ExportFileOk);
                    AutoItX.ProcessWait("EXCEL.EXE", 60000);
                    AutoItX.Sleep(Convert.ToInt32(ConfigurationManager.AppSettings["Sleepeng"]));
                    PublicGlobalFunction.PublicGlobalFunction.CloseProcessProgram("EXCEL");
                    var file = PublicGlobalFunction.PublicGlobalFunction.ReturnNameLastFileTemp(pathTemp, "*.xlsx");
                    dataBaseAdd.AddDeclarationDataAll(file.NamePath, declarationAll);
                    win = new WindowsAis3();
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                }
            }
            win = new WindowsAis3();
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
            return dataBaseAdd.DeclarationSumError(regNumDeclaration);
            //Расчет и возврат суммы
        }
        /// <summary>
        /// Полностью парсим декларацию
        /// </summary>
        /// <param name="libraryAutomation">Библиотека</param>
        /// <param name="automationElement">Элемент автоматизации</param>
        /// <param name="taxJournal">Журнал</param>
        private void ParseDeclaration(LibraryAutomations libraryAutomation, AutomationElement automationElement, ref TaxJournal121Error taxJournal)
        {
            automationElement.SetFocus();
            AutoItX.Sleep(1000);

            var status = libraryAutomation.SelectAutomationColrction(automationElement)
                    .Cast<AutomationElement>().Where(automationElemenst => automationElemenst.Current.Name == "")
                    .ToList();

            taxJournal.Color1 = libraryAutomation.GetColorPixel(status[0]);
            taxJournal.Color2 = libraryAutomation.GetColorPixel(status[1]);
            taxJournal.Color3 = libraryAutomation.GetColorPixel(status[2]);
            taxJournal.Color4 = libraryAutomation.GetColorPixel(status[3]);
            taxJournal.Color5 = libraryAutomation.GetColorPixel(status[4]);
        }


        /// <summary>
        /// Сохранение документа в БД
        /// </summary>
        /// <param name="taxJournal">Журнал</param>
        private void SaveDocument(TaxJournal121Error taxJournal)
        {
            var dbAutomation = new AddObjectDb();
            dbAutomation.TaxJournal121Error(taxJournal);
            dbAutomation.Dispose();
        }
    }
}
