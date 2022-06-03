using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Automation;
using System.Windows.Forms;
using AutoIt;
using EfDatabaseAutomation.Automation.Base;
using EfDatabaseAutomation.Automation.BaseLogica.AddObjectDb;
using EfDatabaseAutomation.Automation.BaseLogica.PreCheck;
using LibaryXMLAuto.XsdModelAutoGenerate;
using LibraryAIS3Windows.AutomationsUI.LibaryAutomations;
using LibraryAIS3Windows.AutomationsUI.Otdels.Registration;
using LibraryAIS3Windows.AutomationsUI.PublicElement;
using LibraryAIS3Windows.ButtonFullFunction.Okp3Function;
using LibraryAIS3Windows.ButtonsClikcs;
using LibraryAIS3Windows.Window;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace LibraryAIS3Windows.ButtonFullFunction.RegistrationFunction
{
   public class AcceptanceDocumentsFunction
    {

        /// <summary>
        /// Ветка 1.01. Идентификационные характеристики физического лица
        /// </summary>
        private string modelTreeDataFl = "Налоговое администрирование\\Централизованный учет налогоплательщиков\\02. ЕГРН - физические лица\\1.01. Идентификационные характеристики физического лица";
        /// <summary>
        /// Ветка Прием документов учета НП (ФЛ)
        /// </summary>
        private string modelTreeRegistrationDocument = "Налоговое администрирование\\Учет документов\\Прием документов учета НП\\Прием документов учета НП (ФЛ)";
        /// <summary>
        /// Ветка 1.02. Ввод документов ФЛ
        /// </summary>
        private string modelTreeSendDocument = "Налоговое администрирование\\Централизованный учет налогоплательщиков\\18. Действия к выполнению\\1.02. Ввод документов ФЛ";
        /// <summary>
        ///Выставление документа по форме 1185
        /// </summary>
        /// <param name="statusButton">Кнопка Автомата</param>
        public void AcceptanceDocuments(StatusButtonMethod statusButton)
        {
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            var parametersModel = new ModelDataArea();
            if (!libraryAutomation.IsEnableExpandTree(modelTreeDataFl)) return;
            if (!libraryAutomation.IsEnableExpandTree(modelTreeRegistrationDocument)) return;
            if (!libraryAutomation.IsEnableExpandTree(modelTreeSendDocument)) return;
            var listFlModel = SelectFl();
            foreach (var flFaceMainRegistration in listFlModel)
            {
                if (statusButton.Iswork)
                {
                    FlFaceMainRegistration flFaceModel;
                    if(flFaceMainRegistration.IdStatus == 1)
                    {
                        OpenTree(libraryAutomation, modelTreeDataFl);
                        SelectTreeParameterUpdate(libraryAutomation, parametersModel.DataAreaRegFl, flFaceMainRegistration.Inn);
                        flFaceModel = FlParseSave(libraryAutomation, parametersModel.DataAreaRegFl, flFaceMainRegistration);
                    }
                    else
                    {
                         flFaceModel = flFaceMainRegistration;
                    }
                    //Если паспорт СССР то что делаем ???
                    if(flFaceModel.IdError == null)
                    {
                        if(flFaceModel.IdStatus == 2)
                        {
                            OpenTree(libraryAutomation, modelTreeRegistrationDocument);
                            flFaceModel = RegistrationDocument(libraryAutomation, parametersModel.DataAreaRegistrationFl, flFaceModel);
                        }
                        if (flFaceModel.IdStatus == 3)
                        {
                            OpenTree(libraryAutomation, modelTreeSendDocument);
                            SelectTreeParameterUpdate(libraryAutomation, parametersModel.DataAreaSendFl, flFaceModel.Inn);
                            SendDocument(libraryAutomation, flFaceModel);
                        }
                    }

                }
                else
                {
                    break;
                }
            }
        }

        /// <summary>
        ///Выставление документа по форме 1512
        /// </summary>
        /// <param name="addressModel">Модель на отработке</param>
        public void AcceptanceDocuments(AddressModel addressModel)
        {
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            var parametersModel = new ModelDataArea();
            if (!libraryAutomation.IsEnableExpandTree(modelTreeDataFl)) return;
            if (!libraryAutomation.IsEnableExpandTree(modelTreeRegistrationDocument)) return;
            if (!libraryAutomation.IsEnableExpandTree(modelTreeSendDocument)) return;
            FlFaceMainRegistration flFaceModel = new FlFaceMainRegistration();
            OpenTree(libraryAutomation, modelTreeDataFl);
            SelectTreeParameterUpdate(libraryAutomation, parametersModel.DataAreaRegFl, addressModel.Inn);
            flFaceModel = FlParseSave(libraryAutomation, parametersModel.DataAreaRegFl, flFaceModel);
            OpenTree(libraryAutomation, modelTreeRegistrationDocument);
            RegistrationDocument1512(libraryAutomation, parametersModel.DataAreaRegistrationFl, addressModel);
            OpenTree(libraryAutomation, modelTreeSendDocument);
            SelectTreeParameterUpdate(libraryAutomation, parametersModel.DataAreaSendFl, addressModel.Inn);
            SendDocument1512(libraryAutomation, flFaceModel, addressModel);
        }

        /// <summary>
        /// Открыть заданную ветку
        /// </summary>
        /// <param name="libraryAutomation">Библиотека автоматизации</param>
        /// <param name="treeName">Путь к ветке</param>
        private void OpenTree(LibraryAutomations libraryAutomation, string treeName)
        {
            var sw = treeName.Split('\\').Last();
            var fullTree = string.Concat(PublicElementName.FullTree, $"Name:{sw}");
            libraryAutomation.FindFirstElement(fullTree, null, true);
            libraryAutomation.FindElement.SetFocus();
            libraryAutomation.ClickElements(fullTree, null, false, 25, 0, 0, 2);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="libraryAutomation">Библиотека автоматизации</param>
        /// <param name="dataArea">Описание ветки для автоматизации</param>
        /// <param name="parameterInn">Параметр подстановки</param>
        private void SelectTreeParameterUpdate(LibraryAutomations libraryAutomation,  DataArea dataArea, string parameterInn)
        {
            dataArea.Parameters.First(parameters => parameters.NameParameters == "ИНН").ParametersGrid = parameterInn;
            foreach (var dataAreaParameters in dataArea.Parameters)
            {
                while (true)
                {
                    if (libraryAutomation.FindFirstElement(string.Concat(dataArea.FullPathDataArea, dataArea.ListRowDataArea, dataAreaParameters.IndexParameters), null, true) != null)
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
            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, dataArea.Update);
        }

        /// <summary>
        /// Собираем ФЛ для сбора и анализа данных
        /// </summary>
        /// <param name="libraryAutomation">Библиотека автоматизации</param>
        /// <param name="dataArea">Автоматизация</param>
        /// <param name="flFaceModel">Документ на обработке</param>
        private FlFaceMainRegistration FlParseSave(LibraryAutomations libraryAutomation, DataArea dataArea, FlFaceMainRegistration flFaceModel)
        {
            PublicGlobalFunction.PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation, dataArea.FullPathGrid);
            AutomationElement automationElement;
            while ((automationElement =
                       libraryAutomation.IsEnableElements(
                           string.Concat(dataArea.FullPathGrid, dataArea.ListRowDataGrid, 1), null, true, 30)) != null)
            {
                flFaceModel.IdNum = Convert.ToInt64(Regex.Replace(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                       .SelectAutomationColrction(automationElement)
                                       .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("УН ФЛ в ЕГРН"))), @"\s+", ""));

                flFaceModel.F = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                       .SelectAutomationColrction(automationElement)
                                       .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Фамилия")));

                flFaceModel.I = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                       .SelectAutomationColrction(automationElement)
                                       .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Имя")));

                flFaceModel.O = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                       .SelectAutomationColrction(automationElement)
                                       .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Отчество")));

                flFaceModel.DateOfBirth = Convert.ToDateTime(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                       .SelectAutomationColrction(automationElement)
                                       .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Дата рождения"))));

                flFaceModel.PlaceBirth = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                       .SelectAutomationColrction(automationElement)
                                       .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Место рождения")));

                flFaceModel.CodeSd = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                       .SelectAutomationColrction(automationElement)
                                       .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Код СПДУЛ")));

                flFaceModel.Document = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                       .SelectAutomationColrction(automationElement)
                                       .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Документ, удостоверяющий личность")));


                flFaceModel.SeriaDoc = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                       .SelectAutomationColrction(automationElement)
                                       .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Серия документа")));

                flFaceModel.NumberDoc = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                       .SelectAutomationColrction(automationElement)
                                       .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Номер документа")));

                flFaceModel.DateCreateDoc = Convert.ToDateTime(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                       .SelectAutomationColrction(automationElement)
                                       .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Дата выдачи документа"))));

                flFaceModel.WhoDoc = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                       .SelectAutomationColrction(automationElement)
                                       .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Кем выдан документ")));

                flFaceModel.CodePodr = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                       .SelectAutomationColrction(automationElement)
                                       .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Код подразделения")));

                flFaceModel.Citizenship = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                        .SelectAutomationColrction(automationElement)
                                        .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Гражданство")));

                flFaceModel.Address = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                        .SelectAutomationColrction(automationElement)
                                        .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Адрес места жительства")));

                flFaceModel.Fid = Convert.ToInt64(Regex.Replace(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                      .SelectAutomationColrction(automationElement)
                                      .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("ФИД лица"))), @"\s+", ""));

                if(flFaceModel.CodeSd == "01")
                {
                    flFaceModel.IdError = 1;
                }
                if (flFaceModel.CodeSd == "91")
                {
                    flFaceModel.IdError = 1;
                }
                if (string.IsNullOrWhiteSpace(flFaceModel.Address))
                {
                    flFaceModel.IdError = 2;
                }
                else
                {
                    var arrayAddress = flFaceModel.Address.Split(',');
                    if (arrayAddress.Count() < 8)
                    {
                        flFaceModel.IdError = 3;
                    }
                }
                flFaceModel.IdStatus = 2;
                break;      
            }
            MouseCloseFormRsb(1);
           // SaveDocument(flFaceModel);
            return flFaceModel;
        }
        /// <summary>
        /// Регистрация документа 1512
        /// </summary>
        /// <param name="libraryAutomation">Библиотека автоматизации</param>
        /// <param name="dataArea">Описание ветки для автоматизации</param>
        /// <param name="addressModel">Модель на отработке</param>
        private void RegistrationDocument1512(LibraryAutomations libraryAutomation, DataArea dataArea, AddressModel addressModel)
        {
            while (true)
            {
                if (libraryAutomation.IsEnableElements(AcceptanceDocumentsElementName.Forms, null, true) != null)
                {
                    libraryAutomation.SetValuePattern("1512");
                    SendKeys.SendWait("{ENTER}");
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, AcceptanceDocumentsElementName.Vk1);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, AcceptanceDocumentsElementName.ButtonSelect);
                    while (true)
                    {
                        if (libraryAutomation.IsEnableElements(AcceptanceDocumentsElementName.WinSelect, null, true) != null)
                        {
                            SelectTreeParameterUpdate(libraryAutomation, dataArea, addressModel.Inn);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, dataArea.Riborn);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, AcceptanceDocumentsElementName.Vk2);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, AcceptanceDocumentsElementName.ButtonCopy);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, AcceptanceDocumentsElementName.Vk3);
                            if (libraryAutomation.IsEnableElements(AcceptanceDocumentsElementName.SelectForm, null, true) != null)
                            {
                                libraryAutomation.SelectItemCombobox(libraryAutomation.FindElement, "02 - На бумажном носителе (лично)", 500);
                                if (libraryAutomation.IsEnableElements(AcceptanceDocumentsElementName.Number, null, true) != null)
                                {
                                    libraryAutomation.SetValuePattern("1");
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, AcceptanceDocumentsElementName.Send);
                                    while (true)
                                    {
                                        if (libraryAutomation.IsEnableElements(AcceptanceDocumentsElementName.WinPrint, null, true) != null)
                                        {
                                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, AcceptanceDocumentsElementName.WinClosed);
                                            break;
                                        }
                                    }
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, AcceptanceDocumentsElementName.Registration);
                                    while (true)
                                    {
                                        if (libraryAutomation.IsEnableElements(AcceptanceDocumentsElementName.WinError, null, true, 5) != null)
                                        {
                                           PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, AcceptanceDocumentsElementName.RegistrationStart);
                                        }
                                        if (libraryAutomation.IsEnableElements(AcceptanceDocumentsElementName.WinKor, null, true, 5) != null)
                                        {
                                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, AcceptanceDocumentsElementName.Kor);
                                            break;
                                        }
                                    }
                                    MouseCloseFormRsb(1);
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, AcceptanceDocumentsElementName.ClosedForm);
                                }
                            }
                            break;
                        }
                    }
                    break;
                }
            }
        }


        /// <summary>
        /// Регистрация документа
        /// </summary>
        /// <param name="libraryAutomation">Библиотека автоматизации</param>
        /// <param name="dataArea">Описание ветки для автоматизации</param>
        /// <param name="flFaceModel">Модель в работе</param>
        private FlFaceMainRegistration RegistrationDocument(LibraryAutomations libraryAutomation, DataArea dataArea, FlFaceMainRegistration flFaceModel)
        {
            while (true)
            {
                if (libraryAutomation.IsEnableElements(AcceptanceDocumentsElementName.Forms, null, true) != null)
                {
                    libraryAutomation.SetValuePattern("1185");
                    SendKeys.SendWait("{ENTER}");
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, AcceptanceDocumentsElementName.Vk1);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, AcceptanceDocumentsElementName.ButtonSelect);
                    while (true)
                    {
                        if (libraryAutomation.IsEnableElements(AcceptanceDocumentsElementName.WinSelect, null, true) != null)
                        {
                            SelectTreeParameterUpdate(libraryAutomation, dataArea, flFaceModel.Inn);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, dataArea.Riborn);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, AcceptanceDocumentsElementName.Vk2);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, AcceptanceDocumentsElementName.ButtonCopy);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, AcceptanceDocumentsElementName.Vk3);
                            if (libraryAutomation.IsEnableElements(AcceptanceDocumentsElementName.SelectForm, null, true) != null)
                            {
                                libraryAutomation.SelectItemCombobox(libraryAutomation.FindElement, "05 - Другое", 500);
                                if(libraryAutomation.IsEnableElements(AcceptanceDocumentsElementName.Number, null, true) != null)
                                {
                                    libraryAutomation.SetValuePattern("1");
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, AcceptanceDocumentsElementName.Send);
                                    while (true)
                                    {
                                        if (libraryAutomation.IsEnableElements(AcceptanceDocumentsElementName.WinPrint, null, true) != null)
                                        {
                                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, AcceptanceDocumentsElementName.WinClosed);
                                            break;
                                        }
                                    }
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, AcceptanceDocumentsElementName.Registration);
                                    while (true)
                                    {
                                        if (libraryAutomation.IsEnableElements(AcceptanceDocumentsElementName.WinError, null, true, 5) != null)
                                        {
                                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, AcceptanceDocumentsElementName.RegistrationStart);
                                        }
                                        if (libraryAutomation.IsEnableElements(AcceptanceDocumentsElementName.WinKor, null, true, 5) != null)
                                        {
                                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, AcceptanceDocumentsElementName.Kor);
                                            break;
                                        }
                                    }
                                    MouseCloseFormRsb(1);
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, AcceptanceDocumentsElementName.ClosedForm);
                                    flFaceModel.IdStatus = 3;
                                    SaveDocument(flFaceModel);
                                }
                            }
                            break;
                        }
                    }
                    break;
                }
            }
            return flFaceModel;
        }
        /// <summary>
        /// Ввод документа
        /// </summary>
        /// <param name="libraryAutomation">Библиотека автоматизации</param>
        /// <param name="flFaceModel">Модель в работе</param>
        /// <returns></returns>
        private void SendDocument(LibraryAutomations libraryAutomation, FlFaceMainRegistration flFaceModel)
        {
            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, SendDocuments.StartSend);
            var sexName = SelectName(flFaceModel.I);
            var isCloseForm = 1;
            if (sexName != null)
            {
                if (sexName.D1035)
                {
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, string.Format(SendDocuments.FloorSex, SendDocuments.SexM));
                }
                else
                {
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, string.Format(SendDocuments.FloorSex, SendDocuments.SexF));
                }
                if (libraryAutomation.IsEnableElements(SendDocuments.PlaceBirth, null, true) != null)
                {
                    libraryAutomation.SetValuePattern(flFaceModel.PlaceBirth.Replace(";", " "));
                    if (libraryAutomation.IsEnableElements(SendDocuments.Country, null, true) != null)
                    {
                        libraryAutomation.SelectItemCombobox(libraryAutomation.FindElement, flFaceModel.Citizenship, 1);
                    }
                }
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, SendDocuments.Vk2);
                if (libraryAutomation.IsEnableElements(string.Format(SendDocuments.GroupModel, SendDocuments.Code), null, true) != null)
                {
                    if (flFaceModel.CodeSd == "21")
                    {
                        libraryAutomation.IsEnableElement(string.Format(SendDocuments.GroupModel, SendDocuments.Code));
                        libraryAutomation.SetLegacyIAccessibleValuePattern(flFaceModel.CodeSd);
                        libraryAutomation.IsEnableElement(string.Format(SendDocuments.GroupModel, SendDocuments.SeriaDoc));
                        libraryAutomation.SetLegacyIAccessibleValuePattern(flFaceModel.SeriaDoc);
                        libraryAutomation.IsEnableElement(string.Format(SendDocuments.GroupModel, SendDocuments.NumberDoc));
                        libraryAutomation.SetLegacyIAccessibleValuePattern(flFaceModel.NumberDoc);
                        libraryAutomation.IsEnableElement(string.Format(SendDocuments.GroupModel, SendDocuments.DateDoc));
                        libraryAutomation.SetLegacyIAccessibleValuePattern(flFaceModel.DateCreateDoc?.ToString("dd.MM.yyyy"));
                        libraryAutomation.IsEnableElement(string.Format(SendDocuments.GroupModel, SendDocuments.CodePodr));
                        libraryAutomation.FindElement = libraryAutomation.GetChildren(libraryAutomation.FindElement)[0];
                        libraryAutomation.SetLegacyIAccessibleValuePattern(flFaceModel.CodePodr);
                        libraryAutomation.IsEnableElement(string.Format(SendDocuments.GroupModel, SendDocuments.Organization));
                        libraryAutomation.FindElement = libraryAutomation.GetChildren(libraryAutomation.FindElement)[0];
                        libraryAutomation.SetLegacyIAccessibleValuePattern(flFaceModel.WhoDoc);
                    }
                    if (flFaceModel.CodeSd == "03")
                    {
                        libraryAutomation.IsEnableElement(string.Format(SendDocuments.GroupModel, SendDocuments.Code));
                        libraryAutomation.SetLegacyIAccessibleValuePattern(flFaceModel.CodeSd);
                        libraryAutomation.IsEnableElement(string.Format(SendDocuments.GroupModel, SendDocuments.NumberDoc));
                        libraryAutomation.SetLegacyIAccessibleValuePattern(flFaceModel.NumberDoc);
                        libraryAutomation.IsEnableElement(string.Format(SendDocuments.GroupModel, SendDocuments.DateDoc));
                        libraryAutomation.SetLegacyIAccessibleValuePattern(flFaceModel.DateCreateDoc?.ToString("dd.MM.yyyy"));
                        libraryAutomation.IsEnableElement(string.Format(SendDocuments.GroupModel, SendDocuments.CodePodr));
                        libraryAutomation.FindElement = libraryAutomation.GetChildren(libraryAutomation.FindElement)[0];
                        libraryAutomation.SetLegacyIAccessibleValuePattern(flFaceModel.CodePodr);
                        libraryAutomation.IsEnableElement(string.Format(SendDocuments.GroupModel, SendDocuments.Organization));
                        libraryAutomation.FindElement = libraryAutomation.GetChildren(libraryAutomation.FindElement)[0];
                        libraryAutomation.SetLegacyIAccessibleValuePattern(flFaceModel.WhoDoc);
                    }
                }
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, SendDocuments.PlaceLife);
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, SendDocuments.Adress);
                if (libraryAutomation.IsEnableElements(SendDocuments.AdrMainWin, null, true) != null)
                {
                    
                    var arrayAdress = flFaceModel.Address.Split(',');

                    if (!string.IsNullOrWhiteSpace(arrayAdress[0]))
                    {
                        libraryAutomation.IsEnableElement(SendDocuments.Index);
                        libraryAutomation.SetLegacyIAccessibleValuePattern(arrayAdress[0].Trim());
                    }

                    if (!string.IsNullOrWhiteSpace(arrayAdress[2]))
                    {
                        libraryAutomation.IsEnableElement(SendDocuments.Region);
                        libraryAutomation.SelectItemCombobox(libraryAutomation.FindElement, arrayAdress[2].Trim(), 50);
                    }

                    if (!string.IsNullOrWhiteSpace(arrayAdress[3]))
                    {
                        libraryAutomation.IsEnableElement(SendDocuments.Raion);
                        libraryAutomation.SelectItemCombobox(libraryAutomation.FindElement, arrayAdress[3].Trim(), 50);
                    }

                    if (!string.IsNullOrWhiteSpace(arrayAdress[4]))
                    {
                        libraryAutomation.IsEnableElement(SendDocuments.City);
                        var elem = arrayAdress[4].Trim().Split(new[] { ' ' }, 2);
                        if (elem[0].Length > 2)
                        {
                            libraryAutomation.SelectItemCombobox(libraryAutomation.FindElement, arrayAdress[4].Trim(), 50);
                        }
                        else
                        {
                            libraryAutomation.SelectItemCombobox(libraryAutomation.FindElement, string.Join(" ", elem[1], elem[0]), 50);
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(arrayAdress[5]))
                    {
                        libraryAutomation.IsEnableElement(SendDocuments.Village);
                        var elem = arrayAdress[5].Trim().Split(new[] { ' ' }, 2);
                        if (elem[0].Length > 4)
                        {
                            libraryAutomation.SelectItemCombobox(libraryAutomation.FindElement, arrayAdress[5].Trim(), 50);
                        }
                        else
                        {
                            libraryAutomation.SelectItemCombobox(libraryAutomation.FindElement, string.Join(" ", elem[1], elem[0]), 50);
                        }
                        
                    }

                    if (!string.IsNullOrWhiteSpace(arrayAdress[6]))
                    {
                        var array = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
                        libraryAutomation.IsEnableElement(SendDocuments.Street);
                        var elem = arrayAdress[6].Trim().Split(new[] { ' ' }, 2);
                        var strAdr = string.Join(" ", elem[1], elem[0]);
                        if (elem[0].Length > 3 || elem[0].Contains("-"))
                        {
                            if (elem[0].Contains("пр"))
                            {
                                libraryAutomation.SelectItemCombobox(libraryAutomation.FindElement, strAdr, 50);
                            }
                            else
                            {
                                foreach (var number in array)
                                {
                                    if (elem[1].Contains(number.ToString()))
                                    {
                                        var moss = elem[1].Trim().Split(new[] { ' ' }, 2);
                                        if (moss[0].Contains(number.ToString()))
                                        {
                                            strAdr = string.Join(" ", moss[0], elem[0], moss[1]).Trim();
                                            break;
                                        }
                                        else
                                        {
                                            strAdr = string.Join(" ", moss[1], elem[0], moss[0]).Trim();
                                            break;
                                        }
                                    }
                                    strAdr = arrayAdress[6].Trim();
                                }
                                libraryAutomation.SelectItemCombobox(libraryAutomation.FindElement, strAdr, 50);
                            }
                        }
                        else
                        {
                            if (elem[1].Contains("ул"))
                            {
                                var mossStreet = elem[1].Trim().Split(new[] { ' ' }, 2);
                                if (mossStreet.Count() == 2)
                                {
                                    strAdr = string.Join(" ", mossStreet[1], elem[0], mossStreet[0]).Trim();
                                }
                            }
                            libraryAutomation.SelectItemCombobox(libraryAutomation.FindElement, strAdr, 50);
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(arrayAdress[7]))
                    {
                        libraryAutomation.IsEnableElement(SendDocuments.House);
                        libraryAutomation.FindElement = libraryAutomation.GetChildren(libraryAutomation.FindElement)[0];
                        libraryAutomation.SetLegacyIAccessibleValuePattern(arrayAdress[7].Trim());
                    }

                    if (!string.IsNullOrWhiteSpace(arrayAdress[8]))
                    {
                        libraryAutomation.IsEnableElement(SendDocuments.Building);
                        libraryAutomation.FindElement = libraryAutomation.GetChildren(libraryAutomation.FindElement)[0];
                        libraryAutomation.SetLegacyIAccessibleValuePattern(arrayAdress[8].Trim());
                    }

                    if (!string.IsNullOrWhiteSpace(arrayAdress[9]))
                    {
                        libraryAutomation.IsEnableElement(SendDocuments.Flat);
                        libraryAutomation.FindElement = libraryAutomation.GetChildren(libraryAutomation.FindElement)[0];
                        libraryAutomation.SetLegacyIAccessibleValuePattern(arrayAdress[9].Trim());
                    }

                    libraryAutomation.IsEnableElement(SendDocuments.CodeNo);
                    libraryAutomation.SetLegacyIAccessibleValuePattern("7751");

                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, SendDocuments.ButtonCopy);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, SendDocuments.Ok);

                    libraryAutomation.IsEnableElement(SendDocuments.DateLife);
                    libraryAutomation.FindElement.SetFocus();
                    libraryAutomation.SetLegacyIAccessibleValuePattern(flFaceModel.DateCreateDoc?.ToString("dd.MM.yy"));

                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, SendDocuments.Save);
                    if (libraryAutomation.IsEnableElements(SendDocuments.Warning, null, true, 5) != null)
                    {
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, SendDocuments.Warning);
                        flFaceModel.IdError = 4;
                        isCloseForm = 2;
                    }
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, SendDocuments.Yes);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, SendDocuments.OkWin);
                    flFaceModel.IdStatus = 4;
                    SaveDocument(flFaceModel);
                    MouseCloseFormRsb(isCloseForm);
                }
            }
            //Если отсутствует пол что делать?
        }
        /// <summary>
        /// Отправка документа 1512
        /// </summary>
        /// <param name="libraryAutomation">Библиотека автоматизации</param>
        /// <param name="addressModel">Модель в работе</param>
        /// <returns></returns>
        private void SendDocument1512(LibraryAutomations libraryAutomation, FlFaceMainRegistration flFaceModel, AddressModel addressModel)
        {
            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, SendDocuments.StartSend);
            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, string.Format(SendDocuments.FloorSex, SendDocuments.SexM));
            if (libraryAutomation.IsEnableElements(SendDocuments.PlaceBirth, null, true) != null)
            {
                libraryAutomation.SetValuePattern("-");
            }
            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, SendDocuments.Adress);
            if (libraryAutomation.IsEnableElements(SendDocuments.AdrMainWin, null, true) != null)
            {
                var arrayAdress = flFaceModel.Address.Split(',');
                if (!string.IsNullOrWhiteSpace(arrayAdress[0]))
                {
                    libraryAutomation.IsEnableElement(SendDocuments.Index);
                    libraryAutomation.SetLegacyIAccessibleValuePattern(addressModel.IndexNew.Trim());
                }
                if (!string.IsNullOrWhiteSpace(arrayAdress[2]))
                {
                    libraryAutomation.IsEnableElement(SendDocuments.Region);
                    libraryAutomation.SetLegacyIAccessibleValuePattern(arrayAdress[2].Trim());
                }
                if (!string.IsNullOrWhiteSpace(arrayAdress[3]))
                {
                    libraryAutomation.IsEnableElement(SendDocuments.Raion);
                    libraryAutomation.SetLegacyIAccessibleValuePattern(arrayAdress[3].Trim());
                }
                if (!string.IsNullOrWhiteSpace(arrayAdress[4]))
                {
                    libraryAutomation.IsEnableElement(SendDocuments.City);
                    var elem = arrayAdress[4].Trim().Split(new[] { ' ' }, 2);
                    if (elem[0].Length > 2)
                    {
                        libraryAutomation.SetLegacyIAccessibleValuePattern(arrayAdress[4].Trim());
                    }
                    else
                    {
                        libraryAutomation.SetLegacyIAccessibleValuePattern(string.Join(" ", elem[1], elem[0]));
                    }
                }
                if (!string.IsNullOrWhiteSpace(arrayAdress[5]))
                {
                    libraryAutomation.IsEnableElement(SendDocuments.Village);
                    var elem = arrayAdress[5].Trim().Split(new[] { ' ' }, 2);
                    if (elem[0].Length > 4)
                    {
                        libraryAutomation.SetLegacyIAccessibleValuePattern(arrayAdress[5].Trim());
                    }
                    else
                    {
                        libraryAutomation.SetLegacyIAccessibleValuePattern(string.Join(" ", elem[1], elem[0]));
                    }

                }
                if (!string.IsNullOrWhiteSpace(arrayAdress[6]))
                {
                    var array = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
                    libraryAutomation.IsEnableElement(SendDocuments.Street);
                    var elem = arrayAdress[6].Trim().Split(new[] { ' ' }, 2);
                    var strAdr = string.Join(" ", elem[1], elem[0]);
                    if (elem[0].Length > 3 || elem[0].Contains("-"))
                    {
                        if (elem[0].Contains("пр"))
                        {
                            libraryAutomation.SetLegacyIAccessibleValuePattern(strAdr);
                        }
                        if(elem[0].Contains("квартал"))
                        {
                            var moss = elem[1].Trim().Split(new[] { ' ' }, 2);
                            strAdr = string.Join(" ", moss[0], "кв-л").Trim();
                            libraryAutomation.SetLegacyIAccessibleValuePattern(strAdr);
                        }
                        if (elem[1].Contains("квартал"))
                        {
                            var moss = elem[1].Trim().Split(new[] { ' ' }, 2);
                            strAdr = string.Join(" ", moss[1], "кв-л").Trim();
                            libraryAutomation.SetLegacyIAccessibleValuePattern(strAdr);
                        }
                        else
                        {
                            foreach (var number in array)
                            {
                                if (elem[1].Contains(number.ToString()))
                                {
                                    var moss = elem[1].Trim().Split(new[] { ' ' }, 2);
                                    if (moss[0].Contains(number.ToString()))
                                    {
                                        strAdr = string.Join(" ", moss[0], elem[0], moss[1]).Trim();
                                        break;
                                    }
                                    else
                                    {
                                        strAdr = string.Join(" ", moss[1], elem[0], moss[0]).Trim();
                                        break;
                                    }
                                }
                                strAdr = arrayAdress[6].Trim();
                            }
                            libraryAutomation.SetLegacyIAccessibleValuePattern(strAdr);
                        }
                    }
                    else
                    {
                        if (elem[0].Contains("тер"))
                        {
                            if (elem[0].Contains("квартал"))
                            {
                                var moss = elem[1].Trim().Split(new[] { ' ' }, 2);
                                strAdr = string.Join(" ", moss[0], "кв-л").Trim();
                                libraryAutomation.SetLegacyIAccessibleValuePattern(strAdr);
                            }
                            if (elem[1].Contains("квартал"))
                            {
                                var moss = elem[1].Trim().Split(new[] { ' ' }, 2);
                                strAdr = string.Join(" ", moss[1], "кв-л").Trim();
                                libraryAutomation.SetLegacyIAccessibleValuePattern(strAdr);
                            }
                        }
                        if (elem[1].Contains("ул"))
                        {
                            var mossStreet = elem[1].Trim().Split(new[] { ' ' }, 2);
                            if (mossStreet.Count() == 2)
                            {
                                strAdr = string.Join(" ", mossStreet[1], elem[0], mossStreet[0]).Trim();
                            }
                        }
                        libraryAutomation.SetLegacyIAccessibleValuePattern(strAdr);
                    }
                }
                if (!string.IsNullOrWhiteSpace(arrayAdress[7]))
                {
                    libraryAutomation.IsEnableElement(SendDocuments.House);
                    libraryAutomation.FindElement = libraryAutomation.GetChildren(libraryAutomation.FindElement)[0];
                    libraryAutomation.SetLegacyIAccessibleValuePattern(arrayAdress[7].Trim());
                }
                if (!string.IsNullOrWhiteSpace(arrayAdress[8]))
                {
                    libraryAutomation.IsEnableElement(SendDocuments.Building);
                    libraryAutomation.FindElement = libraryAutomation.GetChildren(libraryAutomation.FindElement)[0];
                    libraryAutomation.SetLegacyIAccessibleValuePattern(arrayAdress[8].Trim());
                }
                if (!string.IsNullOrWhiteSpace(arrayAdress[9]))
                {
                    libraryAutomation.IsEnableElement(SendDocuments.Flat);
                    libraryAutomation.FindElement = libraryAutomation.GetChildren(libraryAutomation.FindElement)[0];
                    libraryAutomation.SetLegacyIAccessibleValuePattern(arrayAdress[9].Trim());
                }
                libraryAutomation.IsEnableElement(SendDocuments.CodeNo);
                libraryAutomation.SetLegacyIAccessibleValuePattern("7751");

                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, SendDocuments.ButtonCopy);
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, SendDocuments.ButtonIdentification);
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, SendDocuments.Ok);

                libraryAutomation.IsEnableElement(SendDocuments.DateLife);
                libraryAutomation.FindElement.SetFocus();
                libraryAutomation.SetLegacyIAccessibleValuePattern(DateTime.Now.ToString("dd.MM.yy"));

                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, SendDocuments.Save);
                if (libraryAutomation.IsEnableElements(SendDocuments.Warning, null, true, 5) != null)
                {
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, SendDocuments.Warning);

                }
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, SendDocuments.Yes);
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, SendDocuments.OkWin);
                MouseCloseFormRsb(1);
            }
        }

        /// <summary>
        /// Выбираем первые 100 значений
        /// </summary>
        /// <returns></returns>
        private FlFaceMainRegistration[] SelectFl()
        {
            PreCheckAddObject flReg = new PreCheckAddObject();
            var fl = flReg.FlSelect100();
            flReg.Dispose();
            return fl;
        }
        /// <summary>
        /// Запрос пола плательщика
        /// </summary>
        /// <param name="names">Имя</param>
        /// <returns></returns>
        private HName SelectName(string names)
        {
            PreCheckAddObject selectNames = new PreCheckAddObject();
            var name = selectNames.SelectName(names);
            selectNames.Dispose();
            return name;
        }

        /// <summary>
        /// Сохранение документа в БД
        /// </summary>
        /// <param name="fl">Физическое лицо</param>
        private void SaveDocument(FlFaceMainRegistration fl)
        {
            var dbAutomation = new AddObjectDb();
            dbAutomation.SaveFlFace(fl);
            dbAutomation.Dispose();
        }

        /// <summary>
        /// Закрыть подчиненные формы
        /// </summary>
        private void MouseCloseFormRsb(int countClose)
        {
            WindowsAis3 win = new WindowsAis3();
            while (countClose > 0)
            {
                AutoItX.Sleep(1000);
                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                countClose--;
            }
        }
    }
}
