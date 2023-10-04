using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Automation;
using System.Windows.Forms;
using AutoIt;
using EfDatabaseAutomation.Automation.Base;
using LibaryXMLAuto.XsdModelAutoGenerate;
using LibraryAIS3Windows.AutomationsUI.LibaryAutomations;
using LibraryAIS3Windows.AutomationsUI.Otdels.Okp6;
using LibraryAIS3Windows.AutomationsUI.PublicElement;
using LibraryAIS3Windows.ButtonFullFunction.Okp3Function;
using LibraryAIS3Windows.ButtonFullFunction.PreCheck;
using LibraryAIS3Windows.ButtonFullFunction.PublicGlobalFunction;
using LibraryAIS3Windows.ButtonsClikcs;
using LibraryAIS3Windows.Window;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace LibraryAIS3Windows.ButtonFullFunction.Okp6Function
{
    public class Okp6FindFactOwner
    {
        /// <summary>
        /// Ветка Налоговое администрирование\Собственность\01. Картотека собственности ФБД\07. КС – ЗУ – Факты владения на земельные участки – ФЛ
        /// </summary>
        public string TreeFactZm = "Налоговое администрирование\\Собственность\\01. Картотека собственности ФБД\\07. КС – ЗУ – Факты владения на земельные участки – ФЛ";
        /// <summary>
        /// Налоговое администрирование\\Собственность\\01. Картотека собственности ФБД\\23. КС – ОН – Факты владения на объекты недвижимости – ФЛ
        /// </summary>
        public string TreeFactIm = "Налоговое администрирование\\Собственность\\01. Картотека собственности ФБД\\23. КС – ОН – Факты владения на объекты недвижимости – ФЛ";
        /// <summary>
        /// Автомат на ветку Налоговое администрирование\Собственность\01. Картотека собственности ФБД\07. КС – ЗУ – Факты владения на земельные участки – ФЛ
        /// Для поиска документов купли продажи недвижимости земли
        /// </summary>
        /// <param name="statusButton">Кнопка старт</param>
        /// <param name="pathListStatement">Полный путь к списку с уникальными номерами</param>
        /// <param name="pathTemp">Путь к папке Temp</param>
        /// <param name="year">Год отчуждения</param>
        public void FindFactOwnerZm(StatusButtonMethod statusButton, string pathListStatement, string pathTemp, int year)
        {
            DataBaseElementAdd dataBaseAdd = new DataBaseElementAdd();
            LibaryXMLAuto.ReadOrWrite.XmlReadOrWrite read = new LibaryXMLAuto.ReadOrWrite.XmlReadOrWrite();
            object obj = read.ReadXml(pathListStatement, typeof(AutoGenerateSchemes));
            AutoGenerateSchemes modelListIncomeJournal = (AutoGenerateSchemes)obj;
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            var parametersModel = new ModelDataArea();
            var sw = TreeFactZm.Split('\\').Last();
            var fullTree = string.Concat(PublicElementName.FullTree, $"Name:{sw}");
            libraryAutomation.IsEnableExpandTree(TreeFactZm);
            libraryAutomation.FindFirstElement(fullTree, null, true);
            libraryAutomation.FindElement.SetFocus();
            libraryAutomation.ClickElements(fullTree, null, false, 25, 0, 0, 2);
            var sheetName = "Sheet";
            if (modelListIncomeJournal.InnFace != null)
            {
                foreach (var inn in modelListIncomeJournal.InnFace)
                {
                    if (statusButton.Iswork)
                    {
                        parametersModel.DataAreaFactOwnerZm.Parameters.First(parameters => parameters.NameParameters == "ИНН").ParametersGrid = inn.Inn;
                        foreach (var dataAreaParameters in parametersModel.DataAreaFactOwnerZm.Parameters)
                        {
                            while (true)
                            {
                                if (libraryAutomation.FindFirstElement(string.Concat(parametersModel.DataAreaFactOwnerZm.FullPathDataArea, parametersModel.DataAreaFactOwnerZm.ListRowDataArea, dataAreaParameters.IndexParameters), null, true) != null)
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
                                                    parametersModel.DataAreaFactOwnerZm.FullPathDataArea,
                                                    parametersModel.DataAreaFactOwnerZm.ListRowDataArea,
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
     
                        if (libraryAutomation.IsEnableElements(parametersModel.DataAreaFactOwnerZm.Update, null, true) != null)
                        {
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, parametersModel.DataAreaFactOwnerIm.Update);
                        }
                        else
                        {
                            if (libraryAutomation.IsEnableElements(ModelElementFactOwner.RiboonZmIm, null, true) != null)
                            {
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ModelElementFactOwner.RiboonZmIm);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, parametersModel.DataAreaFactOwnerZm.Update);
                            }
                        }
                        PublicGlobalFunction.PublicGlobalFunction.IsWaitLoadtatuBar(libraryAutomation, PublicGlobalFunction.PublicGlobalFunction.StatusBar);
                        var isError = PublicGlobalFunction.PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation, parametersModel.DataAreaFactOwnerZm.FullPathGrid);
                        if (string.IsNullOrWhiteSpace(isError))
                        {
                            var rowNumber = 1;
                            AutomationElement automationElement;
                            while ((automationElement = libraryAutomation.IsEnableElements(string.Concat(parametersModel.DataAreaFactOwnerZm.FullPathGrid, parametersModel.DataAreaFactOwnerZm.ListRowDataGrid, rowNumber), null, false, 5)) != null)
                            {

                                var dateFinish = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                    .SelectAutomationColrction(automationElement).Cast<AutomationElement>()
                                    .First(elem => elem.Current.Name.Contains("Дата прекращения владения")));

                                var isDateFinish = string.IsNullOrWhiteSpace(dateFinish) ? null : (DateTime?)Convert.ToDateTime(dateFinish);
                                if (isDateFinish != null & isDateFinish?.Year == year)
                                {
                                    var flFace = new FlFace();
                                    var factOwner = new FactOfOwnershipImZmTrFl();
                                    automationElement.SetFocus();

                                    var actualCadastralCash = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                        libraryAutomation.SelectAutomationColrction(automationElement)
                                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Актуальная кадастровая стоимость")));

                                    flFace.Inn = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                                      .SelectAutomationColrction(automationElement)
                                                      .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("ИНН")));

                                    flFace.NameFl = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                                      .SelectAutomationColrction(automationElement)
                                                      .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("ФИО правообладателя")));

                                    factOwner.IdObject = 2;

                                    factOwner.FidObject = Convert.ToInt64(Regex.Replace(
                                            libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                                .SelectAutomationColrction(automationElement)
                                                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("ФИД объекта"))), @"\s+", ""));

                                    factOwner.FidFl = Convert.ToInt64(Regex.Replace(
                                            libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                                 .SelectAutomationColrction(automationElement)
                                                 .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("ФИД лица"))), @"\s+", ""));

                                    factOwner.FidFactOwnership = Convert.ToInt64(Regex.Replace(
                                            libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                                 .SelectAutomationColrction(automationElement)
                                                 .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("ФИД факта владения"))), @"\s+", ""));

                                    factOwner.CodeIfns = Convert.ToInt32(
                                            libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                                 .SelectAutomationColrction(automationElement).Cast<AutomationElement>()
                                                 .First(elem => elem.Current.Name.Contains("Код ИФНС адреса объекта"))));


                                    factOwner.CadastralNumber = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                                  .SelectAutomationColrction(automationElement)
                                                  .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Кадастровый номер объекта")));

                                    var dateStart = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                                      .SelectAutomationColrction(automationElement).Cast<AutomationElement>()
                                                      .First(elem => elem.Current.Name.Contains("Дата регистрации владения")));


                                    factOwner.DateStartRight = string.IsNullOrWhiteSpace(dateStart) ? null : (DateTime?)Convert.ToDateTime(dateStart);
                                    factOwner.DateStartFinish = isDateFinish;
                                    factOwner.ActualCadastralCash = string.IsNullOrWhiteSpace(actualCadastralCash) ? null : (Double?)Convert.ToDouble(actualCadastralCash);

   
                                    if (libraryAutomation.IsEnableElements(ModelElementFactOwner.SartViewSender, null, true, 1) != null)
                                    {
                                        libraryAutomation.ClickElement(libraryAutomation.FindElement);
                                        var memo = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindElement);
                                        var elemClick = memo.Cast<AutomationElement>().FirstOrDefault(x => x.Current.Name == "Просмотр сведений о ЗУ и факте владения на ЗУ");
                                        libraryAutomation.InvokePattern(elemClick);
                                    }
                                    
                                    while (true)
                                    {
                                        AutoItX.Sleep(2000);
                                        if (libraryAutomation.IsEnableElements(ModelElementFactOwner.PanelIsRightFaceZmIdent, null, true) != null)
                                        {
                                            if (libraryAutomation.IsEnableElements(ModelElementFactOwner.WinErrorFull, null, true) != null)
                                            {
                                                libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                                            }
                                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ModelElementFactOwner.RightFaceZm);
                                        }
                                        if (libraryAutomation.IsEnableElements(ModelElementFactOwner.PanelIsRightFaceZmSved, null, true) != null)
                                        {
                                            break;
                                        }
                                    }

                                    while (true)
                                    {
                                        SendKeys.SendWait("{ENTER}");
                                        isError = PublicGlobalFunction.PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation, ModelElementFactOwner.IsErrorZm);
                                        if (isError == "Данные, удовлетворяющие заданным условиям не найдены.")
                                        {
                                            dataBaseAdd.AddSaveFactOwner(flFace, factOwner, null, null);
                                            break;
                                        }
                                        if (string.IsNullOrWhiteSpace(isError))
                                        {
                                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, parametersModel.DataAreaFactOwnerZm.Export);
                                            GetFile file;
                                            while (true)
                                            {
                                                if (libraryAutomation.IsEnableElements(ModelElementFactOwner.WinExport, null, true) != null)
                                                {
                                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ModelElementFactOwner.WinExport);
                                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ModelElementFactOwner.ExportMenuXlsx);
                                                    libraryAutomation.FindFirstElement(ModelElementFactOwner.ExportNameList);
                                                    libraryAutomation.SetValuePattern(sheetName);
                                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ModelElementFactOwner.Export);
                                                    PublicGlobalFunction.PublicGlobalFunction.ExcelSaveAndClose();
                                                    file = PublicGlobalFunction.PublicGlobalFunction.ReturnNameLastFileTemp(pathTemp, "*.xlsx");
                                                    break;
                                                }
                                                else
                                                {
                                                    AutoItX.Sleep(3000);
                                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, parametersModel.DataAreaFactOwnerIm.Export);
                                                }
                                            }
                                            dataBaseAdd.AddSaveFactOwner(flFace, factOwner, file.NamePath, sheetName);
                                            break;
                                        }
                                        if (libraryAutomation.IsEnableElements(ModelElementFactOwner.WinErrorFull, null, true) != null)
                                        {
                                            libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                                        }
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ModelElementFactOwner.IsErrorUpdateZm);
                                    }
                                    MouseCloseFormRsb(1);
                                }
                                rowNumber++;
                            }
                        }
                        read.DeleteAtributXml(pathListStatement, LibaryXMLAuto.GenerateAtribyte.GeneratorAtribute.GenerateAtrAutoGenerateSchemesDeleteIdDocInn(inn.Inn));
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, parametersModel.DataAreaFactOwnerZm.Filters);
                    }
                }
            }
            MouseCloseFormRsb(1);
        }

        /// <summary>
        /// Автомат на ветку Налоговое администрирование\Собственность\01. Картотека собственности ФБД\07. КС – ЗУ – Факты владения на земельные участки – ФЛ
        /// Для поиска документов купли продажи недвижимости имущества
        /// </summary>
        /// <param name="statusButton">Кнопка старт</param>
        /// <param name="pathListStatement">Полный путь к списку с уникальными номерами</param>
        /// <param name="pathTemp">Путь к папке Temp</param>
        /// <param name="year">Год отчуждения</param>
        public void FindFactOwnerIm(StatusButtonMethod statusButton, string pathListStatement, string pathTemp, int year)
        {
            DataBaseElementAdd dataBaseAdd = new DataBaseElementAdd();
            LibaryXMLAuto.ReadOrWrite.XmlReadOrWrite read = new LibaryXMLAuto.ReadOrWrite.XmlReadOrWrite();
            object obj = read.ReadXml(pathListStatement, typeof(AutoGenerateSchemes));
            AutoGenerateSchemes modelListIncomeJournal = (AutoGenerateSchemes)obj;
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            var parametersModel = new ModelDataArea();
            var sw = TreeFactIm.Split('\\').Last();
            var fullTree = string.Concat(PublicElementName.FullTree, $"Name:{sw}");
            libraryAutomation.IsEnableExpandTree(TreeFactZm);
            libraryAutomation.FindFirstElement(fullTree, null, true);
            libraryAutomation.FindElement.SetFocus();
            libraryAutomation.ClickElements(fullTree, null, false, 25, 0, 0, 2);
            var sheetName = "Sheet";
            if (modelListIncomeJournal.InnFace != null)
            {
                foreach (var inn in modelListIncomeJournal.InnFace)
                {
                    if (statusButton.Iswork)
                    {
                        parametersModel.DataAreaFactOwnerIm.Parameters.First(parameters => parameters.NameParameters == "ИНН").ParametersGrid = inn.Inn;
                        foreach (var dataAreaParameters in parametersModel.DataAreaFactOwnerIm.Parameters)
                        {
                            while (true)
                            {
                                if (libraryAutomation.FindFirstElement(string.Concat(parametersModel.DataAreaFactOwnerIm.FullPathDataArea, parametersModel.DataAreaFactOwnerIm.ListRowDataArea, dataAreaParameters.IndexParameters), null, true) != null)
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
                                                    parametersModel.DataAreaFactOwnerIm.FullPathDataArea,
                                                    parametersModel.DataAreaFactOwnerIm.ListRowDataArea,
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

                        if (libraryAutomation.IsEnableElements(parametersModel.DataAreaFactOwnerIm.Update, null, true) != null)
                        {
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, parametersModel.DataAreaFactOwnerIm.Update);
                        }
                        else
                        {
                            if (libraryAutomation.IsEnableElements(ModelElementFactOwner.RiboonZmIm, null, true) != null)
                            {
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ModelElementFactOwner.RiboonZmIm);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, parametersModel.DataAreaFactOwnerIm.Update);
                            }
                        }
                        PublicGlobalFunction.PublicGlobalFunction.IsWaitLoadtatuBar(libraryAutomation, PublicGlobalFunction.PublicGlobalFunction.StatusBar);
                        var isError = PublicGlobalFunction.PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation, parametersModel.DataAreaFactOwnerIm.FullPathGrid);
                        if (string.IsNullOrWhiteSpace(isError))
                        {
                            var rowNumber = 1;
                            AutomationElement automationElement;
                            while ((automationElement = libraryAutomation.IsEnableElements(string.Concat(parametersModel.DataAreaFactOwnerIm.FullPathGrid, parametersModel.DataAreaFactOwnerIm.ListRowDataGrid, rowNumber), null, false, 5)) != null)
                            {

                                var dateFinish = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                    .SelectAutomationColrction(automationElement).Cast<AutomationElement>()
                                    .First(elem => elem.Current.Name.Contains("Дата прекращения владения")));

                                var isDateFinish = string.IsNullOrWhiteSpace(dateFinish) ? null : (DateTime?)Convert.ToDateTime(dateFinish);
                                if (isDateFinish != null & isDateFinish?.Year == year)
                                {
                                    var flFace = new FlFace();
                                    var factOwner = new FactOfOwnershipImZmTrFl();
                                    automationElement.SetFocus();

                                    var actualCadastralCash = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                        libraryAutomation.SelectAutomationColrction(automationElement)
                                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Актуальная кадастровая стоимость")));

                                    flFace.Inn = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                                      .SelectAutomationColrction(automationElement)
                                                      .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("ИНН")));

                                    flFace.NameFl = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                                      .SelectAutomationColrction(automationElement)
                                                      .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("ФИО правообладателя")));

                                    factOwner.IdObject = 1;

                                    factOwner.FidObject = Convert.ToInt64(Regex.Replace(
                                            libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                                .SelectAutomationColrction(automationElement)
                                                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("ФИД объекта"))), @"\s+", ""));

                                    factOwner.FidFl = Convert.ToInt64(Regex.Replace(
                                            libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                                 .SelectAutomationColrction(automationElement)
                                                 .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("ФИД лица"))), @"\s+", ""));

                                    factOwner.FidFactOwnership = Convert.ToInt64(Regex.Replace(
                                            libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                                 .SelectAutomationColrction(automationElement)
                                                 .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("ФИД факта владения"))), @"\s+", ""));

                                    factOwner.CodeIfns = Convert.ToInt32(
                                            libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                                 .SelectAutomationColrction(automationElement).Cast<AutomationElement>()
                                                 .First(elem => elem.Current.Name.Contains("Код ИФНС адреса объекта"))));


                                    factOwner.CadastralNumber = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                                  .SelectAutomationColrction(automationElement)
                                                  .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Кадастровый номер объекта")));

                                    var dateStart = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                                      .SelectAutomationColrction(automationElement).Cast<AutomationElement>()
                                                      .First(elem => elem.Current.Name.Contains("Дата регистрации владения")));


                                    factOwner.DateStartRight = string.IsNullOrWhiteSpace(dateStart) ? null : (DateTime?)Convert.ToDateTime(dateStart);
                                    factOwner.DateStartFinish = isDateFinish;
                                    factOwner.ActualCadastralCash = string.IsNullOrWhiteSpace(actualCadastralCash) ? null : (Double?)Convert.ToDouble(actualCadastralCash);

                                    if (libraryAutomation.IsEnableElements(ModelElementFactOwner.SartViewSender, null, true, 1) != null)
                                    {
                                        libraryAutomation.ClickElement(libraryAutomation.FindElement);
                                        var memo = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindElement);
                                        var elemClick = memo.Cast<AutomationElement>().FirstOrDefault(x => x.Current.Name == "Просмотр сведений об ОН и факте владения на ОН");
                                        libraryAutomation.InvokePattern(elemClick);
                                    }

                                    while (true)
                                    {
                                        AutoItX.Sleep(2000);
                                        if (libraryAutomation.IsEnableElements(ModelElementFactOwner.PanelIsRightFaceImIdent, null, true) != null)
                                        {
                                            if (libraryAutomation.IsEnableElements(ModelElementFactOwner.WinErrorFull, null, true) != null)
                                            {
                                                libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                                            }
                                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ModelElementFactOwner.RightFaceIm);
                                        }
                                        if (libraryAutomation.IsEnableElements(ModelElementFactOwner.PanelIsRightFaceImSved, null, true) != null)
                                        {
                                            break;
                                        }
                                    }
                                    while (true)
                                    {
                                        SendKeys.SendWait("{ENTER}");
                                        isError = PublicGlobalFunction.PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation, ModelElementFactOwner.IsErrorIm);
                                        if (isError== "Данные, удовлетворяющие заданным условиям не найдены.")
                                        {
                                            dataBaseAdd.AddSaveFactOwner(flFace, factOwner, null, null);
                                            break;
                                        }
                                        if (string.IsNullOrWhiteSpace(isError))
                                        {
                                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, parametersModel.DataAreaFactOwnerIm.Export);
                                            GetFile file;
                                            while (true)
                                            {
                                                if (libraryAutomation.IsEnableElements(ModelElementFactOwner.WinExport, null, true) != null)
                                                {
                                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ModelElementFactOwner.WinExport);
                                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ModelElementFactOwner.ExportMenuXlsx);
                                                    libraryAutomation.FindFirstElement(ModelElementFactOwner.ExportNameList);
                                                    libraryAutomation.SetValuePattern(sheetName);
                                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ModelElementFactOwner.Export);
                                                    PublicGlobalFunction.PublicGlobalFunction.ExcelSaveAndClose();
                                                    file = PublicGlobalFunction.PublicGlobalFunction.ReturnNameLastFileTemp(pathTemp, "*.xlsx");
                                                    break;
                                                }
                                                else
                                                {
                                                    AutoItX.Sleep(3000);
                                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, parametersModel.DataAreaFactOwnerIm.Export);
                                                }
                                            }
                                            dataBaseAdd.AddSaveFactOwner(flFace, factOwner, file.NamePath, sheetName);
                                            break;
                                        }
                                        if (libraryAutomation.IsEnableElements(ModelElementFactOwner.WinErrorFull, null, true) != null)
                                        {
                                            libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                                        }
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ModelElementFactOwner.IsErrorUpdateIm);
                                    }
                                    MouseCloseFormRsb(1);
                                }
                                rowNumber++;
                            }
                        }
                        read.DeleteAtributXml(pathListStatement, LibaryXMLAuto.GenerateAtribyte.GeneratorAtribute.GenerateAtrAutoGenerateSchemesDeleteIdDocInn(inn.Inn));
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, parametersModel.DataAreaFactOwnerIm.Filters);
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
