using System;
using System.Configuration;
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
        private static string TreeDataArea = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:MasterNavigator\\AutomationId:splitContainer\\AutomationId:gridConditions\\Name:List`1 row ";
        /// <summary>
        /// Обновить документы
        /// </summary>
        private static string TreeUpdate = "Name:DockTop\\Name:Ribbon\\Name:Реестр документов НБО\\Name:Документ\\Name:Обновить данные";
        /// <summary>
        /// Полный путь к Grid
        /// </summary>
        private static string FullPathGrid = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:MasterNavigator\\AutomationId:splitContainer\\AutomationId:gridData";

        private static string TreeExport = "Name:DockTop\\Name:Ribbon\\Name:Работа с налоговым документом\\Name:Документ\\Name:Экспорт в Excel";
        /// <summary>
        /// Режим проставки статистики по КНД 1151001 и КНД 1151006
        /// </summary>
        /// <param name="libraryAutomation">Библиотека автоматизации</param>
        /// <param name="listDocError">Список ошибок</param>
        public void StaticMode1Nk1151001And1151006(LibraryAutomations libraryAutomation, AutomationElement[] listDocError)
        {
            LibraryAutomations libraryAutomationDoc = new LibraryAutomations(WindowsAis3.AisNalog3);
            var numHelp = new[] { "3", "6", "9" };
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
                    var isNum = listModeDocument.FirstOrDefault(doc => numHelp.Any(num => num.Equals(
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
                IsExistsErrorWinInfo(libraryAutomation);
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
                while (true)
                {
                    if (libraryAutomation.IsEnableElements(Journal129AndJournal121.YesClosed, null, true) != null)
                    {
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.YesClosed);
                        break;
                    }
                }
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
                        ParseDeclaration(libraryAutomation, automationElement, ref taxJournal);
                        if (taxJournal.Color5 != "ff")
                        {
                            IsStartIsOpenKm(libraryAutomation, taxJournal);
                            IsExistsErrorWinInfo(libraryAutomation);
                            if (taxJournal.KorrectNumber != 0)
                            {
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation,
                                    Journal129AndJournal121.PriznakDecl);
                                AutoItX.WinWait(Journal129AndJournal121.WinPriznakDecl);
                                AutoItX.WinActivate(Journal129AndJournal121.WinPriznakDecl);
                                libraryAutomationWin = new LibraryAutomations(Journal129AndJournal121.WinPriznakDecl);
                                if (libraryAutomationWin.IsEnableElements(Journal129AndJournal121.PriznComboBox, null) != null)
                                {
                                    libraryAutomationWin.ClickElement(libraryAutomationWin.FindElement, 280);
                                    var memo = libraryAutomationWin.SelectAutomationColrction(libraryAutomationWin.FindElement);
                                    var elemClick = memo.Cast<AutomationElement>().FirstOrDefault(x => x.Current.Name == "учтены результаты КНП (с учетом решений ВНО и судов)  по предыдущей декларации");
                                    libraryAutomationWin.SelectionComboBoxSelectionItemPattern(elemClick);
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomationWin, Journal129AndJournal121.PriznakOk);
                                }
                                //Написать алгоритм для таких
                            }
                            if (taxJournal.DateCloseValidation == null && taxJournal.Color5 == "ffffff")
                            {
                                //Открыть или начать Проверку
                                DialogKnp(libraryAutomation, "Нарушения не выявлены");
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ClosedComplex121);
                                AutoItX.WinWait(Journal129AndJournal121.WinNameComplex);
                                AutoItX.WinActivate(Journal129AndJournal121.WinNameComplex);
                                libraryAutomationWin = new LibraryAutomations(Journal129AndJournal121.WinNameComplex);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomationWin, Journal129AndJournal121.WinOkCloseComplex);
                                AutoItX.Sleep(1000);
                                taxJournal.MessageInfoR1 = "Нарушения не выявлены";
                            }
                            else if (taxJournal.DateCloseValidation == null && taxJournal.Color5 != "ffffff")
                            {
                                DialogKnp(libraryAutomation, "Выявлены нарушения");
                                win = new WindowsAis3();
                                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                                AutoItX.Sleep(1000);
                                while (true)
                                {
                                    if (libraryAutomation.IsEnableElements(Journal129AndJournal121.YesClosed, null, true) != null)
                                    {
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.YesClosed);
                                        break;
                                    }
                                }
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
        /// Функция проверки декларации на нарушения и проставления нарушения
        /// </summary>
        /// <param name="libraryAutomation">Библиотека автоматизации</param>
        /// <param name="taxJournal">Журнал для проверок деклараций на наличие нарушений</param>
        public void IsErrorDeclaration1151100(LibraryAutomations libraryAutomation, TaxJournal121Error taxJournal)
        {
            //if (taxJournal.Color5 == "ff" || taxJournal.Color5 == "ffffff")
            //{
                IsStartIsOpenKm(libraryAutomation, taxJournal);
                IsExistsErrorWinInfo(libraryAutomation);
                LibraryAutomations libraryAutomationWin;
                if (taxJournal.KorrectNumber != 0)
                {
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.PriznakDecl);
                    AutoItX.WinWait(Journal129AndJournal121.WinPriznakDecl);
                    AutoItX.WinActivate(Journal129AndJournal121.WinPriznakDecl);
                    libraryAutomationWin = new LibraryAutomations(Journal129AndJournal121.WinPriznakDecl);
                    if (libraryAutomationWin.IsEnableElements(Journal129AndJournal121.PriznComboBox, null) != null)
                    {
                        libraryAutomationWin.ClickElement(libraryAutomationWin.FindElement, 275);
                        var memo = libraryAutomationWin.SelectAutomationColrction(libraryAutomationWin.FindElement);
                        var elemClick = memo.Cast<AutomationElement>().FirstOrDefault(x => x.Current.Name == "не учтены результаты проверок по предыдущей декларации");
                        libraryAutomationWin.SelectionComboBoxSelectionItemPattern(elemClick);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomationWin, Journal129AndJournal121.PriznakOk);
                    }
                    //Написать алгоритм для таких
                }
                //if (taxJournal.DateCloseValidation == null && taxJournal.Color5 == "ffffff")
                //{
                    //Открыть или начать Проверку
                    DialogKnp(libraryAutomation, "Нарушения не выявлены");
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ClosedComplex121);
                    AutoItX.WinWait(Journal129AndJournal121.WinNameComplex);
                    AutoItX.WinActivate(Journal129AndJournal121.WinNameComplex);
                    libraryAutomationWin = new LibraryAutomations(Journal129AndJournal121.WinNameComplex);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomationWin, Journal129AndJournal121.WinOkCloseComplex);
                    AutoItX.Sleep(1000);
                    taxJournal.MessageInfoR1 = "Нарушения не выявлены";
                //}
                //else if (taxJournal.DateCloseValidation == null && taxJournal.Color5 != "ffffff")
                //{
                //    DialogKnp(libraryAutomation, "Выявлены нарушения");
                //    var win = new WindowsAis3();
                //    AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                //    AutoItX.Sleep(1000);
                //    while (true)
                //    {
                //        if (libraryAutomation.IsEnableElements(Journal129AndJournal121.YesClosed, null, true) != null)
                //        {
                //            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.YesClosed);
                //            break;
                //        }
                //    }
                //    taxJournal.MessageInfoR1 = "Выявлены нарушения";
                //}
            //}
            //else
            //{
            //    taxJournal.MessageError = "Статус документа не позволяет проставить выявление нарушения!";
            //}
            SaveDocument(taxJournal);
        }


        /// <summary>
        /// Метод закрытия комплекса мероприятий КНП 1151020
        /// </summary>10
        /// <param name="libraryAutomation">Библиотека Автомата</param>
        /// <param name="journal">Журнал</param>
        public void CloseComplex1151020(LibraryAutomations libraryAutomation, TaxJournal121 journal)
        {
            //Данная функция закрыта так как используется не по назначению
            if (journal.GlobalColor == "ff0000")
            {
                return;
            }
            if (journal.GlobalColor == "6400")
            {
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.StartKnp);
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ClosedComplex121);
                AutoItX.WinWait(Journal129AndJournal121.WinNameComplex);
                AutoItX.WinActivate(Journal129AndJournal121.WinNameComplex);
                LibraryAutomations libraryAutomationWin = new LibraryAutomations(Journal129AndJournal121.WinNameComplex);
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomationWin, Journal129AndJournal121.WinOkCloseComplex);
                AutoItX.Sleep(1000);
                return;
            }
            var isError = false;
            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.StartKnp);
            if (libraryAutomation.IsEnableElements(Journal129AndJournal121.WinErrorWin) != null)
            {
                libraryAutomation.InvokePattern(libraryAutomation.IsEnableElements(Journal129AndJournal121.WinErrorWin));
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.OpenKnp);
            }
            while (true)
            {
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.CloseKnp);
                AutoItX.Sleep(1000);
                while (true)
                {
                    LibraryAutomations libraryAutomationSign = new LibraryAutomations(TreeWalker.RawViewWalker.GetPreviousSibling(libraryAutomation.RootAutomationElements));
                    if (libraryAutomationSign.IsEnableElements(Journal129AndJournal121.NewWindowEnable, null, true, 40, 0, false, ';') != null)
                    {
                        libraryAutomationSign.IsEnableElements(Journal129AndJournal121.NewComboBoxError, null, false, 40, 0, false, ';');
                        libraryAutomationSign.ClickElement(libraryAutomationSign.FindElement);
                        var memo = libraryAutomationSign.SelectAutomationColrction(libraryAutomationSign.FindElement);
                        var elemClick = memo.Cast<AutomationElement>().FirstOrDefault(x => x.Current.Name == "Нарушения не выявлены");
                        libraryAutomationSign.ClickElement(elemClick);
                        libraryAutomationSign.InvokePattern(libraryAutomationSign.IsEnableElements(Journal129AndJournal121.NewOkEdit));
                        AutoItX.Sleep(1000);
                        if (AutoItX.WinExists(Journal129AndJournal121.NewWarningError) != 0)
                        {
                            AutoItX.WinActivate(Journal129AndJournal121.NewWarningError);
                            AutoItX.Send(ButtonConstant.Enter);
                            libraryAutomationSign.IsEnableElements(Journal129AndJournal121.NewComboBoxError, null, false, 40, 0, false, ';');
                            libraryAutomationSign.ClickElement(libraryAutomationSign.FindElement);
                            memo = libraryAutomationSign.SelectAutomationColrction(libraryAutomationSign.FindElement);
                            elemClick = memo.Cast<AutomationElement>().FirstOrDefault(x => x.Current.Name == "Выявлены нарушения (но не учитываются в 2НК)");
                            libraryAutomationSign.ClickElement(elemClick);
                            libraryAutomationSign.InvokePattern(libraryAutomationSign.IsEnableElements(Journal129AndJournal121.NewOkEdit));
                            isError = true;
                        }
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
            if (isError)
            {
                WindowsAis3 win = new WindowsAis3();
                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                AutoItX.Sleep(1000);
            }
            else
            {
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ClosedComplex121);
                AutoItX.WinWait(Journal129AndJournal121.WinNameComplex);
                AutoItX.WinActivate(Journal129AndJournal121.WinNameComplex);
                LibraryAutomations libraryAutomationWin = new LibraryAutomations(Journal129AndJournal121.WinNameComplex);
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomationWin, Journal129AndJournal121.WinOkCloseComplex);
                AutoItX.Sleep(1000);
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
        /// Странная ошибка
        /// </summary>
        /// <param name="libraryAutomation"></param>
        private void IsExistsErrorWinInfo(LibraryAutomations libraryAutomation)
        {
            while (true)
            {
                LibraryAutomations libraryError = new LibraryAutomations(TreeWalker.RawViewWalker.GetPreviousSibling(libraryAutomation.RootAutomationElements));
                AutoItX.Sleep(1000);
                if (libraryError.RootAutomationElements != null)
                {
                    SendKeys.SendWait("{ENTER}");
                    AutoItX.Sleep(500);
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
