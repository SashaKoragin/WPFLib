using System;
using System.Linq;
using System.Windows.Automation;
using System.Windows.Forms;
using AutoIt;
using EfDatabaseAutomation.Automation.BaseLogica.FaceRegistryReference;
using LibraryAIS3Windows.AutomationsUI.LibaryAutomations;
using LibraryAIS3Windows.AutomationsUI.PublicElement;
using LibraryAIS3Windows.ButtonFullFunction.Okp3Function;
using LibraryAIS3Windows.ButtonsClikcs;
using LibraryAIS3Windows.Window;
using LibraryAIS3Windows.Window.Otdel.Orn.Nbo;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace LibraryAIS3Windows.ButtonFullFunction.OrnFunction
{
    public class OrnRegistryReference
    {
        /// <summary>
        /// Ветка Налоговое администрирование\ИОН\Информационное обслуживание\Формирование справки о наличии сальдо по инициативе НО
        /// </summary>
        public string TreeRegistryReference = "Налоговое администрирование\\ИОН\\Информационное обслуживание\\Формирование справки о наличии сальдо по инициативе НО";

        /// <summary>
        /// Ветка Налоговое администрирование\\ИОН\\Информационное обслуживание\\Журнал учета запросов НО
        /// </summary>
        public string TreeRegistryReferenceSend = "Налоговое администрирование\\ИОН\\Информационное обслуживание\\Журнал учета запросов НО";

        /// <summary>
        /// Автомат на ветку Налоговое администрирование\ИОН\Информационное обслуживание\Формирование справки о наличии сальдо по инициативе НО
        /// </summary>
        /// <param name="statusButton">Кнопка запустить задание</param>
        public void StartFaceRegistryReference(StatusButtonMethod statusButton)
        {
            SelectAndAddFaceRegistryReference selectAndAddDataBase = new SelectAndAddFaceRegistryReference();
            var allParameters = selectAndAddDataBase.SelectFaceReference(false, false, statusButton.IsChekcs);
            if(allParameters.Count<=0) return;
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            var parametersModel = new ModelDataArea();
            var sw = TreeRegistryReference.Split('\\').Last();
            var fullTree = string.Concat(PublicElementName.FullTree, $"Name:{sw}");
            libraryAutomation.IsEnableExpandTree(TreeRegistryReference);
            libraryAutomation.FindFirstElement(fullTree, null, true);
            libraryAutomation.FindElement.SetFocus();
            libraryAutomation.ClickElements(fullTree, null, false, 25, 0, 0, 2);
            foreach (var faceDoc in allParameters)
            {
                if (statusButton.Iswork)
                {
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, string.Format(FaceRegistryReferenceTextClass.PanelFace, faceDoc.TypeFace));
                     parametersModel.DataAreaFaceRegistryReference.Parameters.First(parameters => parameters.NameParameters == "ИНН").ParametersGrid = faceDoc.InnFace;
                     foreach (var dataAreaParameters in parametersModel.DataAreaFaceRegistryReference.Parameters)
                     {
                         while (true)
                         {
                             if (libraryAutomation.FindFirstElement(string.Concat(parametersModel.DataAreaFaceRegistryReference.FullPathDataArea, parametersModel.DataAreaFaceRegistryReference.ListRowDataArea, dataAreaParameters.IndexParameters), null, true) != null)
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
                                         parametersModel.DataAreaFaceRegistryReference.FullPathDataArea,
                                         parametersModel.DataAreaFaceRegistryReference.ListRowDataArea,
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
                     PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, parametersModel.DataAreaFaceRegistryReference.Update);
                     var rowNumber = 1;
                     AutomationElement automationElement;
                     while ((automationElement = libraryAutomation.IsEnableElements(string.Concat(parametersModel.DataAreaFaceRegistryReference.FullPathGrid, parametersModel.DataAreaFaceRegistryReference.ListRowDataGrid, rowNumber), null, true, 5)) != null)
                     {
                         var codeNo = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                             .SelectAutomationColrction(automationElement).Cast<AutomationElement>()
                             .First(elem => elem.Current.Name.Contains("Код НО")));
                         var status = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                             .SelectAutomationColrction(automationElement).Cast<AutomationElement>()
                             .First(elem => elem.Current.Name.Contains("Тип объекта учета")));

                         var nameFace = !faceDoc.TypeFaceBool ? libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                             .SelectAutomationColrction(automationElement).Cast<AutomationElement>()
                             .First(elem => elem.Current.Name.Contains("ФИО"))) : libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                             .SelectAutomationColrction(automationElement).Cast<AutomationElement>()
                             .First(elem => elem.Current.Name.Contains("Наименование")));

                         if (codeNo.Contains("7751") && (status.Contains("ФЛ по месту жительства") || status.Contains("ЮЛ по МН")))
                         {
                             faceDoc.TypeObjectModel = status;
                             faceDoc.CodeNo = Convert.ToInt32(codeNo);
                             faceDoc.NameFace = nameFace;
                             PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, FaceRegistryReferenceTextClass.SendWay);
                             while (true)
                             {
                                 if (libraryAutomation.IsEnableElement(FaceRegistryReferenceTextClass.Check))
                                 {
                                     libraryAutomation.InvokePattern(libraryAutomation.IsEnableElements(FaceRegistryReferenceTextClass.Check));
                                     libraryAutomation.IsEnableElements(FaceRegistryReferenceTextClass.SendText, null, true);
                                     libraryAutomation.SetLegacyIAccessibleValuePattern("Информационное сообщение");
                                     break;
                                 }
                             }
                             PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, FaceRegistryReferenceTextClass.Registration);
                             PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, FaceRegistryReferenceTextClass.Ok);
                             faceDoc.IsState1 = true;
                             faceDoc.DateState1 = DateTime.Now;
                             selectAndAddDataBase.SaveModel(faceDoc);
                             break;
                         }
                         rowNumber++;
                     }
                }
                else
                {
                    break;
                }
            }
            MouseCloseFormRsb(1);
        }
        /// <summary>
        /// Автомат на ветку Налоговое администрирование\ИОН\Информационное обслуживание\Журнал учета запросов НО
        /// </summary>
        /// <param name="statusButton">Кнопка запустить задание</param>
        public void StartFaceRegistryReferenceSend(StatusButtonMethod statusButton)
        {
            SelectAndAddFaceRegistryReference selectAndAddDataBase = new SelectAndAddFaceRegistryReference();
            var allParameters = selectAndAddDataBase.SelectFaceReference(true, false, statusButton.IsChekcs);
            if (allParameters.Count <= 0) return;
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            var parametersModel = new ModelDataArea();
            var sw = TreeRegistryReferenceSend.Split('\\').Last();
            var fullTree = string.Concat(PublicElementName.FullTree, $"Name:{sw}");
            libraryAutomation.IsEnableExpandTree(TreeRegistryReferenceSend);
            libraryAutomation.FindFirstElement(fullTree, null, true);
            libraryAutomation.FindElement.SetFocus();
            libraryAutomation.ClickElements(fullTree, null, false, 25, 0, 0, 2);
            foreach (var faceDoc in allParameters)
            {
                if (statusButton.Iswork)
                {
                    
                    parametersModel.DataAreaFaceRegistryReferenceSend.Parameters.First(parameters => parameters.NameParameters == "ИНН").ParametersGrid = faceDoc.InnFace;
                    foreach (var dataAreaParameters in parametersModel.DataAreaFaceRegistryReferenceSend.Parameters)
                    {
                        while (true)
                        {
                            if (libraryAutomation.FindFirstElement(string.Concat(parametersModel.DataAreaFaceRegistryReferenceSend.FullPathDataArea, parametersModel.DataAreaFaceRegistryReferenceSend.ListRowDataArea, dataAreaParameters.IndexParameters), null, true) != null)
                            {
                                libraryAutomation.FindFirstElement(dataAreaParameters.FindNameMemo, libraryAutomation.FindElement, true);
                                libraryAutomation.FindElement.SetFocus();
                                SendKeys.SendWait("{ENTER}");
                                AutoItX.Sleep(1000);
                                SendKeys.SendWait(dataAreaParameters.ParametersGrid);
                                SendKeys.SendWait("{ENTER}");
                                //while (true)
                                //{
                                //    libraryAutomation.FindFirstElement("Name:Условие", libraryAutomation.FindFirstElement(string.Concat(
                                //        parametersModel.DataAreaFaceRegistryReferenceSend.FullPathDataArea,
                                //        parametersModel.DataAreaFaceRegistryReferenceSend.ListRowDataArea,
                                //        dataAreaParameters.IndexParameters), null, true), true);
                                //    libraryAutomation.ClickElement(libraryAutomation.FindElement);
                                //    if (libraryAutomation.FindFirstElement("Name:DropDown") != null)
                                //    {
                                //        var memo = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindElement);
                                //        var elemClick = memo.Cast<AutomationElement>().FirstOrDefault(x => x.Current.Name == dataAreaParameters.FindSelectParameter);
                                //        libraryAutomation.ClickElement(elemClick);
                                //        break;
                                //    }
                                //}
                                break;
                            }
                        }
                    }
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, FaceRegistryReferenceTextClass.Journal);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, parametersModel.DataAreaFaceRegistryReferenceSend.Update);
                    PublicGlobalFunction.PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation, parametersModel.DataAreaFaceRegistryReferenceSend.FullPathGrid);
                    var rowNumber = 1;
                    AutomationElement automationElement;
                    while ((automationElement = libraryAutomation.IsEnableElements(string.Concat(parametersModel.DataAreaFaceRegistryReferenceSend.FullPathGrid, parametersModel.DataAreaFaceRegistryReferenceSend.ListRowDataGrid, rowNumber), null, true, 10)) != null)
                    {
                        
                        var isSend = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                                      .SelectAutomationColrction(automationElement).Cast<AutomationElement>()
                                                      .First(elem => elem.Current.Name.Contains("Признак формирования документа")));

                        var isSendMesage = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                            .SelectAutomationColrction(automationElement).Cast<AutomationElement>()
                                            .First(elem => elem.Current.Name.Contains("Признак отправки сообщения")));

                        //var dateSend = Convert.ToDateTime(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                        //                              .SelectAutomationColrction(automationElement).Cast<AutomationElement>()
                        //                              .First(elem => elem.Current.Name.Contains("Дата запроса"))));
                        //&faceDoc.DateState1 <= dateSend
                        if (isSend.Contains("0"))
                        {
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, FaceRegistryReferenceTextClass.Journal);
                            if (libraryAutomation.IsEnableElements(FaceRegistryReferenceTextClass.ReportForm)!=null){
                                if (libraryAutomation.FindElement.Current.IsEnabled)
                                {
                                    //Ошибка что делать?++Сделано!!!
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, FaceRegistryReferenceTextClass.ReportForm);
                                    AutoItX.Sleep(250);
                                    if (libraryAutomation.IsEnableElements(FaceRegistryReferenceTextClass.Error) == null)
                                    {
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, FaceRegistryReferenceTextClass.Up);
                                        AutoItX.Sleep(250);
                                        while ((automationElement = libraryAutomation.IsEnableElements(string.Concat(parametersModel.DataAreaFaceRegistryReferenceSend.FullPathGrid, parametersModel.DataAreaFaceRegistryReferenceSend.ListRowDataGrid, rowNumber), null, true, 10)) != null)
                                        {
                                            automationElement.SetFocus();
                                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, FaceRegistryReferenceTextClass.SendNp);
                                            break;
                                        }
                                        AutoItX.Sleep(250);
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, FaceRegistryReferenceTextClass.Service);
                                        AutoItX.Sleep(250);
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, FaceRegistryReferenceTextClass.Right);
                                        AutoItX.Sleep(250);
                                        MouseCloseFormRsb(1);
                                    }
                                    else
                                    {
                                        if (libraryAutomation.IsEnableElements(FaceRegistryReferenceTextClass.ErrorMessage) != null)
                                        {
                                            faceDoc.IsErrorMessage = libraryAutomation.FindElement.Current.Name;
                                            libraryAutomation.IsEnableElements(FaceRegistryReferenceTextClass.Error);
                                            libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                                            PublicGlobalFunction.PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation, parametersModel.DataAreaFaceRegistryReferenceSend.FullPathGrid);
                                        }
                                    }
                                }
                                faceDoc.IsState2 = true;
                                faceDoc.DateState2 = DateTime.Now;
                                selectAndAddDataBase.SaveModel(faceDoc);
                            }
                        }
                        else
                        {
                            if (isSendMesage.Contains("0"))
                            {
                                if (libraryAutomation.IsEnableElements(FaceRegistryReferenceTextClass.SendNp) != null)
                                {
                                    if (libraryAutomation.FindElement.Current.IsEnabled)
                                    {
                                        while ((automationElement = libraryAutomation.IsEnableElements(string.Concat(parametersModel.DataAreaFaceRegistryReferenceSend.FullPathGrid, parametersModel.DataAreaFaceRegistryReferenceSend.ListRowDataGrid, rowNumber), null, true, 10)) != null)
                                        {
                                            automationElement.SetFocus();
                                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, FaceRegistryReferenceTextClass.SendNp);
                                            break;
                                        }
                                        faceDoc.IsState2 = true;
                                        faceDoc.DateState2 = DateTime.Now;
                                        selectAndAddDataBase.SaveModel(faceDoc);
                                        PublicGlobalFunction.PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation, parametersModel.DataAreaFaceRegistryReferenceSend.FullPathGrid);
                                    }
                                }
                            }
                        }
                        rowNumber++;
                    }
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, parametersModel.DataAreaFaceRegistryReferenceSend.Filters);
                }
                else
                {
                    break;
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