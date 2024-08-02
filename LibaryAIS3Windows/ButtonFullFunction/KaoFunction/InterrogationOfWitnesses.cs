using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Automation;
using System.Windows.Forms;
using AutoIt;
using EfDatabaseAutomation.Automation.Base;
using EfDatabaseAutomation.Automation.BaseLogica.SaveAndLoadInterrogationOfWitnesses;
using LibraryAIS3Windows.AutomationsUI.LibaryAutomations;
using LibraryAIS3Windows.AutomationsUI.Otdels.Kao;
using LibraryAIS3Windows.ButtonFullFunction.Okp3Function;
using LibraryAIS3Windows.ButtonsClikcs;
using LibraryAIS3Windows.Window;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace LibraryAIS3Windows.ButtonFullFunction.KaoFunction
{
    public class InterrogationOfWitnesses
    {
        /// <summary>
        /// Ветка для Инициализация процедуры допроса свидетеля
        /// </summary>
        private static string TreeInterrogationOfWitnesses = "Налоговое администрирование\\Контрольная работа\\Допрос свидетелей\\1. Инициализация процедуры допроса свидетеля";
        /// <summary>
        /// Ветка для Инициализация процедуры допроса свидетеля работа с процедурой
        /// </summary>
        private static string TreeProcedure = "Налоговое администрирование\\Контрольная работа\\Допрос свидетелей\\Работа с процедурой";
        /// <summary>
        /// Запуск процесса допрос свидетелей для ОКП 6
        /// </summary>
        /// <param name="statusButton">Кнопка запустить</param>
        public void StartModelInterrogationOfWitnesses(StatusButtonMethod statusButton)
        {
            var libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            var parametersModel = new ModelDataArea();
            SelectAndUpdateInterrogationOfWitnesses dataBaseAdd = new SelectAndUpdateInterrogationOfWitnesses();
            var departmentResponse = dataBaseAdd.SelectFirstModelResponse(Environment.UserName);
            if (departmentResponse==null)
                throw new InvalidOperationException($"Пользователь подписывающий документ не определен!");
            switch (departmentResponse.TemplateDepartment)
            {
                case "ОКП":
                    var parametersOrg = dataBaseAdd.SelectAllMainOrgIsNotReady(new []{ 1,2 }); //Организация
                    foreach (var faceUl in parametersOrg)
                    {
                        if (statusButton.Iswork)
                        {
                            var questions = dataBaseAdd.SelectTemplateQuestions(faceUl.IdType);  //Вопросы
                            foreach (var user in faceUl.UserOrgs)
                            {
                                if (!user.IsGood && !user.IsError)
                                {
                                    var modelProcedureUsers = InitProcedure(libraryAutomation, parametersModel.DataAreaInterrogationOfWitnesses[1], departmentResponse, faceUl.Inn);
                                    faceUl.NameOrg = modelProcedureUsers.NameSubject;
                                    faceUl.NoIn = modelProcedureUsers.NoIn;
                                    faceUl.IsReady = modelProcedureUsers.IsReady;
                                    dataBaseAdd.SaveMainOrg(faceUl);
                                    WorkProcedure(libraryAutomation, dataBaseAdd, faceUl, user, parametersModel.DataAreaInterrogationOfWitnesses, questions, modelProcedureUsers.IdProcedure, departmentResponse.SenderResponse.IdTemplateSender);
                                }
                            }
                            if (dataBaseAdd.IsEndListUserOrg(faceUl.IdOrg)) continue;
                            faceUl.IsReady = true;
                            faceUl.NoOut = "Организация отработана смотри журнал!";
                            dataBaseAdd.SaveMainOrg(faceUl);
                        }
                        else
                        {
                            break;
                        }
                    }
                    break;
                case "Регистрация":
                    var parametersUserCeo = dataBaseAdd.SelectAllUserRegistrationFlIsNotReady(); //Генеральные директора
                    foreach(var user in parametersUserCeo)
                    {
                        if (statusButton.Iswork)
                        {
                            var questions = dataBaseAdd.SelectTemplateQuestions(user.IdType);  //Вопросы
                            var modelProcedureUsers = InitProcedure(libraryAutomation, parametersModel.DataAreaInterrogationOfWitnesses[6], departmentResponse, user.Inn, true);
                            user.NoIn = modelProcedureUsers.NoIn;
                            user.IsReady = modelProcedureUsers.IsReady;
                            dataBaseAdd.SaveMainUserRegistrationFl(user);
                            WokProcedureRegistration(libraryAutomation, dataBaseAdd, user, parametersModel.DataAreaInterrogationOfWitnesses, questions, modelProcedureUsers.IdProcedure, departmentResponse.SenderResponse.IdTemplateSender);
                        }
                        else
                        {
                            break;
                        }
                    }

                    break;
                case "ОВП":
                    var parametersOrgVnp = dataBaseAdd.SelectAllMainOrgIsNotReady(new [] { 4 }); //Организация
                    foreach (var faceUl in parametersOrgVnp)
                    {
                            var questions = dataBaseAdd.SelectTemplateQuestions(faceUl.IdType);  //Вопросы
                            WorkProcedureVnp(libraryAutomation, dataBaseAdd, faceUl, parametersModel.DataAreaInterrogationOfWitnesses, questions, departmentResponse.SenderResponse.IdTemplateSender, statusButton);
                            if (dataBaseAdd.IsEndListUserOrg(faceUl.IdOrg)) continue;
                            faceUl.IsReady = true;
                            faceUl.NoOut = "Организация отработана смотри журнал!";
                            dataBaseAdd.SaveMainOrg(faceUl);
                    }
                    break;
            }

        }
        /// <summary>
        /// Инициализация процедуры
        /// </summary>
        /// <param name="libraryAutomation">Библиотека автоматизации</param>
        /// <param name="modelDataAreaSelect">Модель выборки</param>
        /// <param name="templateModel">Шаблон заполнения данными форму</param>
        /// <param name="isFace">Выбирать плательщика ФЛ или нет по умолчанию нет</param>
        /// <param name="inn">ИНН лица</param>
        private ModelReturnInit InitProcedure(LibraryAutomations libraryAutomation, DataArea modelDataAreaSelect, DepartmentOtdelResponse templateModel, string inn, bool isFace = false)
        {
            ModelReturnInit modelReturnInit = new ModelReturnInit();
            if (!libraryAutomation.IsEnableExpandTree(TreeInterrogationOfWitnesses)) return modelReturnInit;
            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.SelectFace);
            if (isFace)
            {
                if(libraryAutomation.IsEnableElements(ElementNameWitnesses.SelectFaceFl)!= null)
                {
                    libraryAutomation.SelectionComboBoxSelectionItemPattern(libraryAutomation.FindElement);
                }
            }
            if (ParameterSelectAdd(libraryAutomation, modelDataAreaSelect, "Name:Выбор Налогоплательщика\\Name:DropDown", inn))
            {
                libraryAutomation.IsEnableElements(ElementNameWitnesses.NameMnk);
                libraryAutomation.FindElement = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindElement).Cast<AutomationElement>().ToArray()[0];
                libraryAutomation.SetLegacyIAccessibleValuePattern(templateModel.TemplateModelResponse.NameMnk);
                libraryAutomation.IsEnableElements(ElementNameWitnesses.DocMail);
                libraryAutomation.FindElement = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindElement).Cast<AutomationElement>().ToArray()[0];
                libraryAutomation.SetLegacyIAccessibleValuePattern(templateModel.TemplateModelResponse.DocMail);
                libraryAutomation.IsEnableElements(ElementNameWitnesses.NumberDoc);
                libraryAutomation.FindElement = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindElement).Cast<AutomationElement>().ToArray()[0];
                libraryAutomation.SetLegacyIAccessibleValuePattern(templateModel.TemplateModelResponse.NumberDoc);
                if (templateModel.TemplateModelResponse.DataDoc != "GETDATE")
                {
                    libraryAutomation.IsEnableElements(ElementNameWitnesses.DataDoc);
                    libraryAutomation.SetValuePattern(templateModel.TemplateModelResponse.DataDoc);
                }
                modelReturnInit.NameSubject = libraryAutomation.IsEnableElements(ElementNameWitnesses.NameOrg).Current.Name;
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.StartProcedure);
                modelReturnInit.IdProcedure = Convert.ToInt32(Regex.Match(libraryAutomation.IsEnableElements(ElementNameWitnesses.NumberProcedure).Current.Name, "(\\d)+").Value);
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.OkProcedure);
            }
            else
            {
                modelReturnInit.IsReady = true;
                modelReturnInit.NoIn = "Отсутствуют сведения о лице!";
                MouseCloseFormRsb(1);
            }
            return modelReturnInit;
        }
        /// <summary>
        /// Работа с процедурой в отделе регистрации
        /// </summary>
        /// <param name="libraryAutomation">Библиотека автоматизации</param>
        /// <param name="dataBaseAdd">База данных</param>
        /// <param name="user">Генеральный директор из списка</param>
        /// <param name="modelDataAreaSelect">Модель выборок</param>
        /// <param name="templateQuestion">Шаблоны вопросов</param>
        /// <param name="idProcedureUsers">Ун процедуры</param>
        /// <param name="idSender">Ун подписанта</param>
        private void WokProcedureRegistration(LibraryAutomations libraryAutomation, SelectAndUpdateInterrogationOfWitnesses dataBaseAdd, MainUserRegistrationFl user, DataArea[] modelDataAreaSelect, TemplateQuestion[] templateQuestion, int idProcedureUsers, long idSender)
        {
            if (!libraryAutomation.IsEnableExpandTree(TreeProcedure)) return;
            if (ParameterSelectAdd(libraryAutomation, modelDataAreaSelect[0], "Name:DropDown", user.Inn, idProcedureUsers))
            {
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.Find);
                ParameterSelectAdd(libraryAutomation, modelDataAreaSelect[2], "Name:DropDown", user.Inn);
                if (libraryAutomation.IsEnableElements(ElementNameWitnesses.YesNo, null, true, 10) != null)
                {
                    
                    user.CodeNo = Convert.ToInt32(Regex.Match(libraryAutomation.IsEnableElements(ElementNameWitnesses.MessageCodeNo).Current.Name, "(\\d)+").Value);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.YesNo);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.Save);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.SaveYes);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.Registration);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.RegistrationYes);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.RegistrationOk);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.Senders);
                    AddQuestionsRegistration(libraryAutomation, dataBaseAdd, templateQuestion, user);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.FaceSender);
                    ParameterSelectAdd(libraryAutomation, modelDataAreaSelect[5], "Name:Выбор Должностного лица\\Name:DropDown", null, null, idSender);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.SaveDocument);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.DocumentOk);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.DocumentRegistration);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.DocumentYes);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.DocumentOk);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.DocYesToSend);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.Senders);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.SendMessage);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.SendInfo);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.SendInfo);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.Closed);
                    MouseCloseFormRsb(1);
                    user.IsReady = true;
                    user.NoOut = "Процедура отработана успешно в чужой НО!!!";
                }
                else
                {
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.Delete);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.DeleteYes);
                    libraryAutomation.IsEnableElements(ElementNameWitnesses.MessageError);
                    libraryAutomation.FindElement = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindElement).Cast<AutomationElement>().ToArray()[0];
                    libraryAutomation.FindElement.SetFocus();
                    SendKeys.SendWait("Ошибка");
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.DeleteProcedure);
                    AutoItX.Sleep(1000);
                    MouseCloseFormRsb(1);
                    user.IsReady = true;
                    user.NoIn = "Процедура аннулирована в связи отсутствием алгоритма!!!";
                }
            }
            dataBaseAdd.SaveMainUserRegistrationFl(user);
        }

        /// <summary>
        /// Работа с процедурой
        /// </summary>
        /// <param name="libraryAutomation">Библиотека автоматизации</param>
        /// <param name="dataBaseAdd">База данных</param>
        /// <param name="faceUl">Лицо ЮЛ</param>
        /// <param name="user">Сотрудник организации</param>
        /// <param name="modelDataAreaSelect">Массив параметров модели</param>
        /// <param name="templateQuestion">Шаблоны с вопросами</param>
        /// <param name="idProcedureUsers">Ун процедуры пользователя</param>
        /// <param name="idSender">Ун подписанта</param>
        private void WorkProcedure(LibraryAutomations libraryAutomation, SelectAndUpdateInterrogationOfWitnesses dataBaseAdd, MainOrg faceUl, UserOrg user, DataArea[] modelDataAreaSelect, TemplateQuestion[] templateQuestion, int idProcedureUsers, long idSender)
        {
            if (!libraryAutomation.IsEnableExpandTree(TreeProcedure)) return;
            if(ParameterSelectAdd(libraryAutomation, modelDataAreaSelect[0], "Name:DropDown", faceUl.Inn, idProcedureUsers))
            {
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.Find);
                ParameterSelectAdd(libraryAutomation, modelDataAreaSelect[2], "Name:DropDown", user.InnUser);
                if (libraryAutomation.IsEnableElements(ElementNameWitnesses.YesNo, null, true, 10) != null)
                {
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.YesNo);
                    ParseUserOrg(libraryAutomation,ref user, idProcedureUsers);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.Save);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.SaveYes);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.Registration);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.RegistrationYes);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.RegistrationOk);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.Senders);
                    libraryAutomation.InvokePattern(libraryAutomation.IsEnableElements(ElementNameWitnesses.InformationFace));
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.AddFace);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.FaceUl);
                    ParameterSelectAdd(libraryAutomation, modelDataAreaSelect[3], "Name:Выбор Налогоплательщика\\Name:DropDown", faceUl.Inn);
                    AutoItX.Sleep(2000);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.AddFace);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.FaceFl);
                    ParameterSelectAdd(libraryAutomation, modelDataAreaSelect[4], "Name:Выбор Налогоплательщика\\Name:DropDown", user.InnUser);
                    libraryAutomation.InvokePattern(libraryAutomation.IsEnableElements(ElementNameWitnesses.InformationFace));
                    AddQuestions(libraryAutomation, dataBaseAdd, templateQuestion, faceUl, user);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.FaceSender);
                    ParameterSelectAdd(libraryAutomation, modelDataAreaSelect[5], "Name:Выбор Должностного лица\\Name:DropDown", null ,null, idSender);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.SaveDocument);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.DocumentOk);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.DocumentRegistration);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.DocumentYes);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.DocumentOk);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.DocYesToSend);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.Senders);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.SendMessage);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.SendInfo);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.SendInfo);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.Closed);
                    MouseCloseFormRsb(1);
                    user.IsGood = true;
                    user.MessageInfo = "Обработано успешно!!!";
                }
                else
                {
                    ParseUserOrg(libraryAutomation, ref user, idProcedureUsers);
                    user.IsError = true;
                    user.MessageInfo = "Аннулировано в связи с ошибкой!!!";
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.Delete);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.DeleteYes);
                    libraryAutomation.IsEnableElements(ElementNameWitnesses.MessageError);
                    libraryAutomation.FindElement = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindElement).Cast<AutomationElement>().ToArray()[0];
                    libraryAutomation.FindElement.SetFocus();
                    SendKeys.SendWait("Ошибка");
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.DeleteProcedure);
                    AutoItX.Sleep(1000);
                    MouseCloseFormRsb(1);
                }
            }
            dataBaseAdd.SaveUsers(user);
        }

        /// <summary>
        /// Работа с процедурой
        /// </summary>
        /// <param name="libraryAutomation">Библиотека автоматизации</param>
        /// <param name="dataBaseAdd">База данных</param>
        /// <param name="faceUl">Лицо ЮЛ</param>
        /// <param name="modelDataAreaSelect">Массив параметров модели</param>
        /// <param name="templateQuestion">Шаблоны с вопросами</param>
        /// <param name="idSender">Ун подписанта</param>
        /// <param name="statusButton">Статус кнопки запуска</param>
        private void WorkProcedureVnp(LibraryAutomations libraryAutomation, SelectAndUpdateInterrogationOfWitnesses dataBaseAdd, MainOrg faceUl, DataArea[] modelDataAreaSelect, TemplateQuestion[] templateQuestion, long idSender, StatusButtonMethod statusButton)
        {
            if (!libraryAutomation.IsEnableExpandTree(TreeProcedure)) return;
              if (ParameterSelectAdd(libraryAutomation, modelDataAreaSelect[0], "Name:DropDown", faceUl.Inn, null, null, true))    
              {
                  var rowNumber = 1;
                  foreach (var user in faceUl.UserOrgs)
                  {
                    if (statusButton.Iswork)
                    {
                        UserOrg userRef = user;
                        if (!userRef.IsGood && !userRef.IsError)
                        {
                            AutomationElement automationElement;
                            while ((automationElement = libraryAutomation.IsEnableElements(string.Concat(modelDataAreaSelect[0].FullPathGrid, modelDataAreaSelect[0].ListRowDataGrid, rowNumber), null, true, 30)) != null)
                            {

                                libraryAutomation.SelectStateLegacyIAccessiblePatternIdentifiersState(automationElement, 0x200042);
                                var idProcedureUsers = Convert.ToInt32(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                    .SelectAutomationColrction(automationElement).Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("УН процедуры"))));

                                var statusProcedure = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                    .SelectAutomationColrction(automationElement).Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Основание процедуры допроса")));

                                var fio = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                    .SelectAutomationColrction(automationElement).Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Фамилия свидетеля")));
                                if (statusProcedure == "2, ВНП" && string.IsNullOrWhiteSpace(fio))
                                {
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, modelDataAreaSelect[0].Riborn);
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.Find);
                                    ParameterSelectAdd(libraryAutomation, modelDataAreaSelect[2], "Name:DropDown", userRef.InnUser);
                                    if (PublicGlobalFunction.PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation, modelDataAreaSelect[0].FullPathGrid)== "Данные, удовлетворяющие заданным условиям не найдены.")
                                    {
                                        userRef.IsError = true;
                                        userRef.MessageInfo = "Плательщик не найден!!!";
                                        MouseCloseFormRsb(2);
                                        break;
                                    }
                                    if (libraryAutomation.IsEnableElements(ElementNameWitnesses.YesNo, null, true, 10) != null)
                                    {
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.YesNo);
                                        ParseUserOrg(libraryAutomation,ref userRef, idProcedureUsers);
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.Save);
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.SaveYes);
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.Registration);
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.RegistrationYes);
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.RegistrationOk);
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.Senders);
                                        libraryAutomation.InvokePattern(libraryAutomation.IsEnableElements(ElementNameWitnesses.InformationFace));
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.AddFace);
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.FaceUl);
                                        ParameterSelectAdd(libraryAutomation, modelDataAreaSelect[3], "Name:Выбор Налогоплательщика\\Name:DropDown", faceUl.Inn);
                                        AutoItX.Sleep(2000);
                                        AddQuestions(libraryAutomation, dataBaseAdd, templateQuestion, faceUl, userRef);
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.FaceSender);
                                        ParameterSelectAdd(libraryAutomation, modelDataAreaSelect[5], "Name:Выбор Должностного лица\\Name:DropDown", null, null, idSender);
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.SaveDocument);
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.DocumentOk);
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.DocumentRegistration);
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.DocumentYes);
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.DocumentOk);
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.DocYesToSend);
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.Senders);
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.SendMessage);
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.SendInfo);
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.SendInfo);
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.Closed);
                                        userRef.IsGood = true;
                                        userRef.MessageInfo = "Обработано успешно!!!";
                                        rowNumber++;
                                        break;
                                    }
                                    //Предупреждение что приостановлена проверка
                                    if (libraryAutomation.IsEnableElements(ElementNameWitnesses.Warning, null, true, 10) != null)
                                    {
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.Warning);
                                        userRef.IsError = true;
                                        userRef.MessageInfo = "Процедура не может быть завершёна плательщик мобилизован!!!";
                                        MouseCloseFormRsb(1);
                                        break;
                                    }
                                    //Если наш
                                    userRef.IsError = true;
                                    userRef.MessageInfo = "Плательщик принадлежит к нашей инспекции!!!";
                                    MouseCloseFormRsb(2);
                                    break;
                                }
                                rowNumber++;
                            }
                            dataBaseAdd.SaveUsers(userRef);
                        }
                    }
                    else
                    {
                        MouseCloseFormRsb(2);
                        return;
                    }
                }
            }
        }


        /// <summary>
        /// Выбор плательщика
        /// </summary>
        /// <param name="libraryAutomation">Автоматизация </param>
        /// <param name="parametersModel">Модель</param>
        /// <param name="findElement">Наименование элемента поиска</param>
        /// <param name="inn">ИНН</param>
        /// <param name="idProcedure">Ун созданной процедуры</param>
        /// <param name="idSender">Ун подписанта</param>
        /// <param name="isVnp">Алгоритм ВНП</param>
        /// <returns></returns>
        private bool ParameterSelectAdd(LibraryAutomations libraryAutomation, DataArea parametersModel, string findElement, string inn, int? idProcedure = null, long? idSender= null, bool isVnp = false)
        {
            if (inn != null)
            {
                parametersModel.Parameters.First(parameters => parameters.NameParameters == "ИНН").ParametersGrid = inn;
            }
            if (idProcedure != null)
            {
                parametersModel.Parameters.First(parameters => parameters.NameParameters == "УН процедуры").ParametersGrid = idProcedure.ToString();
            }
            if (idSender != null)
            {
                parametersModel.Parameters.First(parameters => parameters.NameParameters == "УН инспектора").ParametersGrid = idSender.ToString();
            }
            foreach (var dataAreaParameters in parametersModel.Parameters)
            {
                while (true)
                {
                    if (libraryAutomation.FindFirstElement(string.Concat(parametersModel.FullPathDataArea, parametersModel.ListRowDataArea, dataAreaParameters.IndexParameters), null, true) != null)
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
                                parametersModel.FullPathDataArea,
                                parametersModel.ListRowDataArea,
                                dataAreaParameters.IndexParameters), null, true), true);
                            libraryAutomation.ClickElement(libraryAutomation.FindElement);
                            if (libraryAutomation.FindFirstElement(findElement) != null)
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
            if (idProcedure != null || isVnp)
            {
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.Navigator);
            }
            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, parametersModel.Update);
            if (!string.IsNullOrWhiteSpace(PublicGlobalFunction.PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation, parametersModel.FullPathGrid))) return false;
            if (!isVnp)
            {
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, parametersModel.Riborn);
            }
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="libraryAutomation">Автоматизация</param>
        /// <param name="user">Сотрудник организации</param>
        /// <param name="idProcedureUsers">Ун процедуры</param>
        private void ParseUserOrg(LibraryAutomations libraryAutomation, ref UserOrg user, int? idProcedureUsers)
        {
            user.Family = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(ElementNameWitnesses.Family));
            user.Name = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(ElementNameWitnesses.Name));
            user.Surname = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(ElementNameWitnesses.Surname));
            user.DateOfBirth = Convert.ToDateTime(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(ElementNameWitnesses.DateOfBirth)));
            user.VidDoc = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(ElementNameWitnesses.VidDoc));
            user.Seria = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(ElementNameWitnesses.Serial));
            user.Number = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(ElementNameWitnesses.Number));
            user.DateIn = Convert.ToDateTime(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(ElementNameWitnesses.DateIn)));
            user.Code = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(ElementNameWitnesses.Code));
            user.WhoIn = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(ElementNameWitnesses.WhoIn));
            user.Location = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(ElementNameWitnesses.Location));
            user.IdProcedure = idProcedureUsers;
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="libraryAutomation">Автоматизация</param>
        ///// <param name="user">Сотрудник организации</param>
        ///// <param name="idProcedureUsers">Ун процедуры</param>
        //private UserOrg ParseUserOrgVnp(LibraryAutomations libraryAutomation, UserOrg user, int? idProcedureUsers)
        //{
        //    user.Family = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(ElementNameWitnesses.Family));
        //    user.Name = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(ElementNameWitnesses.Name));
        //    user.Surname = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(ElementNameWitnesses.Surname));
        //    user.DateOfBirth = Convert.ToDateTime(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(ElementNameWitnesses.DateOfBirth)));
        //    user.VidDoc = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(ElementNameWitnesses.VidDoc));
        //    user.Seria = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(ElementNameWitnesses.Serial));
        //    user.Number = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(ElementNameWitnesses.Number));
        //    user.DateIn = Convert.ToDateTime(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(ElementNameWitnesses.DateIn)));
        //    user.Code = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(ElementNameWitnesses.Code));
        //    user.WhoIn = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(ElementNameWitnesses.WhoIn));
        //    user.Location = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(ElementNameWitnesses.Location));
        //    user.IdProcedure = idProcedureUsers;
        //    return user;
        //}

        /// <summary>
        /// <summary>
        /// Добавление вопросов в АИС 3 
        /// </summary>
        /// </summary>
        /// <param name="libraryAutomation">Автоматизация</param>
        /// <param name="dataBaseAdd">База данных</param>
        /// <param name="templateQuestion">Шаблоны вопросов</param>
        /// <param name="faceUl">Юл лицо</param>
        /// <param name="userFace">Сотрудник организации</param>
        private void AddQuestions(LibraryAutomations libraryAutomation, SelectAndUpdateInterrogationOfWitnesses dataBaseAdd, TemplateQuestion[] templateQuestion, MainOrg faceUl, UserOrg userFace)
        {
            string modelQuestions;
            foreach (var template in templateQuestion.Where(x=>x.IdGroupQuestions!=3))
            {
                switch (template.IdGroupQuestions)
                {
                    case 1:
                        modelQuestions = template.InfoQuestions.Replace("{NameOrg}", faceUl.NameOrg).Replace("{InnOrg}", faceUl.Inn).Replace("{Year}", $"{DateTime.Now.Year-1}-{DateTime.Now.Year}");
                        CreateAndSaveQuestionsUser(libraryAutomation, dataBaseAdd, userFace.IdUser, template.IdTemplateQuestions, modelQuestions);
                        break;
                    case 2:
                        foreach (var faceUlMainOrgAndUserQuestion in faceUl.MainOrgAndUserQuestions)
                        {
                            modelQuestions = template.InfoQuestions.Replace("{FIOGenDir}", faceUlMainOrgAndUserQuestion.Derector.NameDerector).Replace("{NameOrg}", faceUl.NameOrg).Replace("{InnOrg}", faceUl.Inn);
                            CreateAndSaveQuestionsUser(libraryAutomation, dataBaseAdd, userFace.IdUser, template.IdTemplateQuestions, modelQuestions);
                        }
                        break;
                }
            }
            foreach (var koontzAgent in faceUl.MainOrgAndKontrAgents)
            {
                foreach (var template in templateQuestion.Where(x => x.IdGroupQuestions == 3))
                {
                    modelQuestions = template.InfoQuestions.Replace("{NameOrgK}", koontzAgent.KontrAgent.NameKontrAgent).Replace("{InnOrgK}", koontzAgent.KontrAgent.InnKontrAgent).Replace("{Year}", $"{DateTime.Now.Year - 1}-{DateTime.Now.Year}").Replace("{NameOrg}", faceUl.NameOrg).Replace("{InnOrg}", faceUl.Inn);
                    CreateAndSaveQuestionsUser(libraryAutomation, dataBaseAdd, userFace.IdUser, template.IdTemplateQuestions, modelQuestions);
                }
            }

        }

        /// <summary>
        /// <summary>
        /// Добавление вопросов в АИС 3 
        /// </summary>
        /// </summary>
        /// <param name="libraryAutomation">Автоматизация</param>
        /// <param name="dataBaseAdd">База данных</param>
        /// <param name="templateQuestion">Шаблоны вопросов</param>
        /// <param name="mainUserRegistrationFl">Генеральный директор</param>
        private void AddQuestionsRegistration(LibraryAutomations libraryAutomation, SelectAndUpdateInterrogationOfWitnesses dataBaseAdd, TemplateQuestion[] templateQuestion, MainUserRegistrationFl mainUserRegistrationFl)
        {
            foreach (var template in templateQuestion)
            {
                CreateAndSaveQuestionsMainUserCeo(libraryAutomation, dataBaseAdd, mainUserRegistrationFl.IdUserRegistrationFl, template.IdTemplateQuestions, template.InfoQuestions);
            }
        }


        /// <summary>
        /// Функция создания и внесения типового вопроса по допросам
        /// </summary>
        /// <param name="libraryAutomation">Автоматизация</param>
        /// <param name="dataBaseAdd">База данных</param>
        /// <param name="idUser">Ун сотрудника</param>
        /// <param name="idTemplateQuestions">Ун шаблона</param>
        /// <param name="questions">Составной вопрос из шаблона</param>
        private void CreateAndSaveQuestionsUser(LibraryAutomations libraryAutomation, SelectAndUpdateInterrogationOfWitnesses dataBaseAdd, int idUser, int idTemplateQuestions, string questions)
        {
            SetQuestions(libraryAutomation, questions);
            dataBaseAdd.SaveQuestionsUser(idUser, idTemplateQuestions, questions);
        }

        /// <summary>
        /// Функция создания и внесения типового вопроса по допросам
        /// </summary>
        /// <param name="libraryAutomation">Автоматизация</param>
        /// <param name="dataBaseAdd">База данных</param>
        /// <param name="idUserRegistration">Ун генерального директора</param>
        /// <param name="idTemplateQuestions">Ун шаблона</param>
        /// <param name="questions">Составной вопрос из шаблона</param>
        private void CreateAndSaveQuestionsMainUserCeo(LibraryAutomations libraryAutomation, SelectAndUpdateInterrogationOfWitnesses dataBaseAdd, int idUserRegistration, int idTemplateQuestions, string questions)
        {
            SetQuestions(libraryAutomation, questions);
            dataBaseAdd.SaveQuestionsAndUserRegistrationFl(idUserRegistration, idTemplateQuestions, questions);
        }

        /// <summary>
        /// Проставить вопрос в поручение
        /// </summary>
        /// <param name="libraryAutomation">Автоматизация</param>
        /// <param name="questions">Составной вопрос из шаблона</param>
        public void SetQuestions(LibraryAutomations libraryAutomation, string questions)
        {
            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.AddQuestion);
            libraryAutomation.IsEnableElements(ElementNameWitnesses.AddTextQuestion);
            libraryAutomation.FindElement = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindElement).Cast<AutomationElement>().ToArray()[0];
            libraryAutomation.SetLegacyIAccessibleValuePattern(questions);
            libraryAutomation.InvokePattern(libraryAutomation.IsEnableElements(ElementNameWitnesses.OkQuestion));
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
    /// <summary>
    /// Возвращаемая модель из Инициализации процедуры
    /// </summary>
    public class ModelReturnInit
    {
        /// <summary>
        /// Ун процедуры для дальнейшей отработки
        /// </summary>
        public int IdProcedure { get; set; }

        /// <summary>
        /// Наименование субъекта
        /// </summary>
        public string NameSubject { get; set; }

        /// <summary>
        /// Завершение процедуры
        /// </summary>
        public bool IsReady { get; set; }

        /// <summary>
        /// Ошибка об нахождении
        /// </summary>
        public string NoIn { get; set; }
    }
}
