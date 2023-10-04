using System;
using System.IO;
using System.Linq;
using System.Windows.Automation;
using System.Windows.Forms;
using AutoIt;
using EfDatabaseAutomation.Automation.Base;
using LibraryAIS3Windows.AutomationsUI.LibaryAutomations;
using LibraryAIS3Windows.AutomationsUI.Otdels.PreCheck;
using LibraryAIS3Windows.AutomationsUI.PublicElement;
using LibraryAIS3Windows.ButtonFullFunction.PreCheck;
using LibraryAIS3Windows.ButtonFullFunction.PublicGlobalFunction;
using LibraryAIS3Windows.ButtonsClikcs;
using LibraryAIS3Windows.Window;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace LibraryAIS3Windows.ButtonFullFunction.Okp3Function
{
   public class Okp3Patent
    {
        /// <summary>
        /// Ветка мои роли
        /// </summary>
        private string _modelTreePatent =  "Налоговое администрирование\\Контрольная работа (налоговые проверки)\\203. Применение патентной системы налогообложения\\03. Журнал учета и формирования документов, связанных с применением ПСН";

        /// <summary>
        /// Сбор информации по СПН
        /// </summary>
        /// <param name="statusButton">Кнопка старт автомат</param>
        /// <param name="pathTemp">Путь сохранения Temp</param>
        public void LoadPatent(StatusButtonMethod statusButton, string pathTemp)
        {
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            var parametersModel = new ModelDataArea();
            if (!libraryAutomation.IsEnableExpandTree(_modelTreePatent)) return;
            DataBaseElementAdd dataBaseAdd = new DataBaseElementAdd();
            var sw = _modelTreePatent.Split('\\').Last();
            var fullTree = string.Concat(PublicElementName.FullTree, $"Name:{sw}");
            libraryAutomation.FindFirstElement(fullTree, null, true);
            libraryAutomation.FindElement.SetFocus();
            libraryAutomation.ClickElements(fullTree, null, false, 25, 0, 0, 2);
            parametersModel.DataArea.Parameters.First(parameters => parameters.NameParameters == "РегНомер патента").ParametersGrid = string.Join("/", dataBaseAdd.PatentExportFull().Select(x => x.RegNumPatent).ToArray());
            foreach (var dataAreaParameters in parametersModel.DataArea.Parameters)
            {
                while (true)
                {
                    if (libraryAutomation.FindFirstElement(string.Concat(parametersModel.DataArea.FullPathDataArea, parametersModel.DataArea.ListRowDataArea , dataAreaParameters.IndexParameters), null, true) != null)
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
                                                               string.Concat(parametersModel.DataArea.FullPathDataArea, 
                                                               parametersModel.DataArea.ListRowDataArea, dataAreaParameters.IndexParameters), null, true), true);
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
            if (libraryAutomation.FindFirstElement(string.Concat(parametersModel.DataArea.FullPathDataArea, parametersModel.DataArea.Headers), null, true) != null)
            {
                var memo = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindElement);
                libraryAutomation.ClickElement(memo[4]);
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, parametersModel.DataArea.Update);
            }
            PublicGlobalFunction.PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation, parametersModel.DataArea.FullPathGrid);
            var listMemo = libraryAutomation.SelectAutomationColrction(libraryAutomation.IsEnableElements(parametersModel.DataArea.FullPathGrid))
                           .Cast<AutomationElement>().Where(elem => elem.Current.Name.Contains("select0 row")).Distinct();
            foreach (var automationElement in listMemo)
            {
                if (statusButton.Iswork)
                {
                    automationElement.SetFocus();
                    AutoItX.Sleep(1000);
                    FlFaceMain face = new FlFaceMain()
                    {
                          Inn = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                .SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("ИНН"))),
                          NameFull = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                .SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Налогоплательщик"))),
                          OgrnIp = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                .SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("ОГРНИП"))),
                          Address = "Отсутствует",
                          Fid = Convert.ToInt64(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                .SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("ФИД налогоплательщика"))))
                    };
                    Patent patent = new Patent()
                    {
                         DateStartPatent = Convert.ToDateTime(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                  .SelectAutomationColrction(automationElement)
                                  .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Дата начала действия патента")))),
                         DateFinishPatent = Convert.ToDateTime(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                  .SelectAutomationColrction(automationElement)
                                  .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Дата окончания действия патента")))),
                         CodeWork = Convert.ToInt32(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                .SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Код вида предпринимательской деятельности ПСН")))),
                         NameVid = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                .SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Наименование вида предпринимательской деятельности ПСН"))),
                         CodeOkun = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                .SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Код по ОКУН"))),
                         NameCodeOkun = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                .SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Наименование по ОКУН"))),
                         CountMouth = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                .SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Количество месяцев, на которое выдан патент"))),
                         CountDays = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                .SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Количество дней, на которое выдан патент"))),
                         AvgPeople = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                .SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Средняя численность наемных работников"))),
                         NalogStav = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                .SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Налоговая ставка"))),
                         NormalCodex = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                .SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Норма закона субъекта РФ"))),
                         DateWaitResh = Convert.ToDateTime(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                .SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Ожидаемая дата принятия решения")))),
                         DateResh = Convert.ToDateTime(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                .SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Дата принятия решения")))),
                         DateCancel = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                .SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Дата отмены действия"))),
                         RegNumInfoVz = string.IsNullOrWhiteSpace(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("РегНомер заявления на патент, выписанного взамен")))) ? (long?)null :
                                Convert.ToInt64(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                .SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("РегНомер заявления на патент, выписанного взамен")))),
                         RegNumPatentVz = string.IsNullOrWhiteSpace(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("РегНомер патента, выписанного взамен")))) ? (long?)null :
                                Convert.ToInt64(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                .SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("РегНомер патента, выписанного взамен")))),
                         DateObjectNot = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                .SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Дата признания объекта не актуальным"))),
                         IdObjectPsn = Convert.ToInt64(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                .SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("УН объекта ПСН")))),
                         RegNumInfo = string.IsNullOrWhiteSpace(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.SelectAutomationColrction(automationElement)
                                 .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("РегНомер патента")))) ? (long?)null :
                                 Convert.ToInt64(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                 .SelectAutomationColrction(automationElement)
                                 .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("РегНомер патента")))),
                         RegNumPatent = string.IsNullOrWhiteSpace(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("РегНомер патента")))) ? (long?)null :
                                Convert.ToInt64(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                .SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("РегНомер патента"))))
                    };
                    var parseModel = dataBaseAdd.AddFlFaceAndPatent(face, ref patent);
                    parseModel.IsParseFullPatent = true;
                    GetFile file;
                    var sheetName = "Sheet";
                    parametersModel.DataAreaModel.First(param => param.Headers == "Документы объекта ПСН").IsParseModel = parseModel.IsParseDocPatent;
                    parametersModel.DataAreaModel.First(param => param.Headers == "Сведения об обособленных объектах").IsParseModel = parseModel.IsParseSvedObject;
                    parametersModel.DataAreaModel.First(param => param.Headers == "Сведения о месте осуществления деятельности").IsParseModel = parseModel.IsParsePlaceOfBusiness;
                    parametersModel.DataAreaModel.First(param => param.Headers == "Параметры расчета налога").IsParseModel = parseModel.IsParseParametrNalog;
                    parametersModel.DataAreaModel.First(param => param.Headers == "Сведения о транспортных средствах").IsParseModel = parseModel.IsParseSvedTr;
                    parametersModel.DataAreaModel.First(param => param.Headers == "Сведения по фактическому действию патента").IsParseModel = parseModel.IsParseSvedFactPatent;
                    foreach (var parameter in parametersModel.DataAreaModel)
                    {
                        if (!parameter.IsParseModel)
                        {
                             PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, parameter.Riborn);
                             while (true)
                             {
                                 var grid = PublicGlobalFunction.PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation, parameter.FullPathGrid);
                                 
                                 if (string.IsNullOrWhiteSpace(grid))
                                 {
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, parameter.Export);
                                    while (true)
                                    {
                                        if (libraryAutomation.IsEnableElements(PreCheckElementName.WinExport, null, true) != null)
                                        {
                                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, PreCheckElementName.WinExport);
                                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, PreCheckElementName.ExportMenuXlsx);
                                            libraryAutomation.FindFirstElement(PreCheckElementName.ExportNameList);
                                            libraryAutomation.SetValuePattern(sheetName);
                                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, PreCheckElementName.Export);
                                            PublicGlobalFunction.PublicGlobalFunction.ExcelSaveAndClose();
                                            file = PublicGlobalFunction.PublicGlobalFunction.ReturnNameLastFileTemp(pathTemp, "*.xlsx");
                                            break;
                                        }
                                    }
                                    switch (parameter.Headers)
                                    {
                                        case "Документы объекта ПСН":
                                            dataBaseAdd.AddDocPatent(patent, file.NamePath, sheetName);
                                            break;
                                        case "Сведения об обособленных объектах":
                                            dataBaseAdd.AddSvedObject(patent, file.NamePath, sheetName);
                                            break;
                                        case "Сведения о месте осуществления деятельности":
                                            dataBaseAdd.AddPlaceOfBusiness(patent, file.NamePath, sheetName);
                                            break;
                                        case "Параметры расчета налога":
                                            dataBaseAdd.AddParametrNalog(patent, file.NamePath, sheetName);
                                            break;
                                        case "Сведения о транспортных средствах":
                                            dataBaseAdd.AddSvedTr(patent, file.NamePath, sheetName);
                                            break;
                                        case "Сведения по фактическому действию патента":
                                            dataBaseAdd.AddSvedFactPatent(patent, file.NamePath, sheetName);
                                            break;
                                    }
                                    File.Delete(file.NamePath);
                                    break;
                                 }
                                 if (grid == "Данные, удовлетворяющие заданным условиям не найдены.")
                                 {
                                     break;
                                 }
                                 PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, parameter.Update);
                             }
                             switch (parameter.Headers)
                             {
                                case "Документы объекта ПСН":
                                    parseModel.IsParseDocPatent = true;
                                    break;
                                case "Сведения об обособленных объектах":
                                    parseModel.IsParseSvedObject = true;
                                    break;
                                case "Сведения о месте осуществления деятельности":
                                    parseModel.IsParsePlaceOfBusiness = true;
                                    break;
                                case "Параметры расчета налога":
                                    parseModel.IsParseParametrNalog = true;
                                    break;
                                case "Сведения о транспортных средствах":
                                    parseModel.IsParseSvedTr = true;
                                    break;
                                case "Сведения по фактическому действию патента":
                                    parseModel.IsParseSvedFactPatent = true;
                                    break;
                             }
                            dataBaseAdd.UpdateIsParseModel(parseModel);
                            WindowsAis3 win = new WindowsAis3();
                            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                        }
                    }
                }
                else
                {
                    break;
                }
            }
            WindowsAis3 winFullClose = new WindowsAis3();
            AutoItX.MouseClick(ButtonConstant.MouseLeft, winFullClose.WindowsAis.X + winFullClose.WindowsAis.Width - 20, winFullClose.WindowsAis.Y + 160);
        }
    }
}
