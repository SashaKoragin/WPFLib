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
using LibraryAIS3Windows.AutomationsUI.PublicElement;
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
        /// Запуск процесса допрос свидетелей
        /// </summary>
        /// <param name="statusButton">Кнопка запустить</param>
        public void StartModelInterrogationOfWitnesses(StatusButtonMethod statusButton)
        {
            var libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            var parametersModel = new ModelDataArea();
            SelectAndUpdateInterrogationOfWitnesses dataBaseAdd = new SelectAndUpdateInterrogationOfWitnesses();
            var parametersOrg = dataBaseAdd.SelectAllMainOrgIsNotReady(); //Организация
            var questions = dataBaseAdd.SelectTemplateQuestions();  //Вопросы
            foreach (var faceUl in parametersOrg)
            {
                if (statusButton.Iswork)
                {
                    foreach (var user in faceUl.UserOrgs)
                    {
                        if (!user.IsGood && !user.IsError)
                        {
                            var idProcedureUsers = InitProcedure(libraryAutomation, dataBaseAdd, faceUl, parametersModel.DataAreaInterrogationOfWitnesses);
                            WorkProcedure(libraryAutomation, dataBaseAdd, faceUl, user, parametersModel.DataAreaInterrogationOfWitnesses, questions, idProcedureUsers);
                        }
                    }
                    faceUl.IsReady = true;
                    faceUl.NoOut = "Организация отработана смотри журнал!";
                    dataBaseAdd.SaveMainOrg(faceUl);
                }
                else
                {
                    break;
                }
            }
        }
        /// <summary>
        /// Инициализация процедуры
        /// </summary>
        /// <param name="libraryAutomation">Библиотека автоматизации</param>
        /// <param name="dataBaseAdd">База данных</param>
        /// <param name="faceUl">Лицо ЮЛ</param>
        /// <param name="modelDataAreaSelect">Массив параметров модели</param>
        private int InitProcedure(LibraryAutomations libraryAutomation, SelectAndUpdateInterrogationOfWitnesses dataBaseAdd, MainOrg faceUl, DataArea[] modelDataAreaSelect)
        {
            var idProcedure = 0;
            if (!libraryAutomation.IsEnableExpandTree(TreeInterrogationOfWitnesses)) return idProcedure;
            var sw = TreeInterrogationOfWitnesses.Split('\\').Last();
            var fullTree = string.Concat(PublicElementName.FullTree, $"Name:{sw}");
            libraryAutomation.FindFirstElement(fullTree, null, true);
            libraryAutomation.FindElement.SetFocus();
            libraryAutomation.ClickElements(fullTree, null, false, 25, 0, 0, 2);
            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.SelectFace);
            if (ParameterSelectAdd(libraryAutomation, modelDataAreaSelect[1], "Name:Выбор Налогоплательщика\\Name:DropDown", faceUl.Inn))
            {
                libraryAutomation.IsEnableElements(ElementNameWitnesses.NameMnk);
                libraryAutomation.FindElement = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindElement).Cast<AutomationElement>().ToArray()[0];
                libraryAutomation.SetLegacyIAccessibleValuePattern("Допрос должностного лица");
                libraryAutomation.IsEnableElements(ElementNameWitnesses.DocMail);
                libraryAutomation.FindElement = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindElement).Cast<AutomationElement>().ToArray()[0];
                libraryAutomation.SetLegacyIAccessibleValuePattern("Письмо ФНС России");
                libraryAutomation.IsEnableElements(ElementNameWitnesses.NumberDoc);
                libraryAutomation.FindElement = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindElement).Cast<AutomationElement>().ToArray()[0];
                libraryAutomation.SetLegacyIAccessibleValuePattern("БВ-4-7/3060@");
                libraryAutomation.IsEnableElements(ElementNameWitnesses.DataDoc);
                libraryAutomation.SetValuePattern("10.03.2021");
                faceUl.NameOrg = libraryAutomation.IsEnableElements(ElementNameWitnesses.NameOrg).Current.Name;
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.StartProcedure);
                idProcedure = Convert.ToInt32(Regex.Match(libraryAutomation.IsEnableElements(ElementNameWitnesses.NumberProcedure).Current.Name, "(\\d)+").Value);
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.OkProcedure);
                dataBaseAdd.SaveMainOrg(faceUl);
            }
            else
            {
                faceUl.IsReady = true;
                faceUl.NoIn = "Отсутствует организация!";
                dataBaseAdd.SaveMainOrg(faceUl);
                MouseCloseFormRsb(1);
            }
            return idProcedure;
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
        /// 
        private void WorkProcedure(LibraryAutomations libraryAutomation, SelectAndUpdateInterrogationOfWitnesses dataBaseAdd, MainOrg faceUl, UserOrg user, DataArea[] modelDataAreaSelect, TemplateQuestion[] templateQuestion, int idProcedureUsers)
        {
            if (!libraryAutomation.IsEnableExpandTree(TreeProcedure)) return;
            var sw = TreeProcedure.Split('\\').Last();
            var fullTree = string.Concat(PublicElementName.FullTree, $"Name:{sw}");
            libraryAutomation.FindFirstElement(fullTree, null, true);
            libraryAutomation.FindElement.SetFocus();
            libraryAutomation.ClickElements(fullTree, null, false, 25, 0, 0, 2);
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
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.AddFace);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.FaceFl);
                    ParameterSelectAdd(libraryAutomation, modelDataAreaSelect[4], "Name:Выбор Налогоплательщика\\Name:DropDown", user.InnUser);
                    libraryAutomation.InvokePattern(libraryAutomation.IsEnableElements(ElementNameWitnesses.InformationFace));
                    AddQuestions(libraryAutomation, dataBaseAdd, templateQuestion, faceUl, user);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.FaceSender);
                    ParameterSelectAdd(libraryAutomation, modelDataAreaSelect[5], "Name:Выбор Должностного лица\\Name:DropDown", null);
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
        /// Выбор плательщика
        /// </summary>
        /// <param name="libraryAutomation">Автоматизация </param>
        /// <param name="parametersModel">Модель</param>
        /// <param name="findElement">Наименование элемента поиска</param>
        /// <param name="inn">ИНН</param>
        /// <param name="idProcedure">Ун созданной процедуры</param>
        /// <returns></returns>
        private bool ParameterSelectAdd(LibraryAutomations libraryAutomation, DataArea parametersModel, string findElement, string inn, int? idProcedure = null)
        {
            if (inn != null)
            {
                parametersModel.Parameters.First(parameters => parameters.NameParameters == "ИНН").ParametersGrid = inn;
            }
            if (idProcedure != null)
            {
                parametersModel.Parameters.First(parameters => parameters.NameParameters == "УН процедуры").ParametersGrid = idProcedure.ToString();
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
            if (idProcedure != null)
            {
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.Navigator);
            }
            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, parametersModel.Update);
            if (!string.IsNullOrWhiteSpace(PublicGlobalFunction.PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation, parametersModel.FullPathGrid))) return false;
            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, parametersModel.Riborn);
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
            foreach (var template in templateQuestion)
            {
                string modelQuestions;
                switch (template.IdGroupQuestions)
                {
                    case 1:
                        modelQuestions = template.InfoQuestions.Replace("{NameOrg}", faceUl.NameOrg).Replace("{InnOrg}", faceUl.Inn).Replace("{Year}", $"{DateTime.Now.Year}");
                        CreateAndSaveQuestionsUser(libraryAutomation, dataBaseAdd, userFace.IdUser, template.IdTemplateQuestions, modelQuestions);
                        break;
                    case 2:
                        modelQuestions = template.InfoQuestions.Replace("{FIOGenDir}", faceUl.Derector.NameDerector).Replace("{NameOrg}", faceUl.NameOrg).Replace("{InnOrg}", faceUl.Inn);
                        CreateAndSaveQuestionsUser(libraryAutomation, dataBaseAdd, userFace.IdUser, template.IdTemplateQuestions, modelQuestions);
                        break;
                    case 3:
                        foreach (var koontzAgent in faceUl.MainOrgAndKontrAgents)
                        {
                            modelQuestions = template.InfoQuestions.Replace("{NameOrgK}", koontzAgent.KontrAgent.NameKontrAgent).Replace("{InnOrgK}", koontzAgent.KontrAgent.InnKontrAgent).Replace("{Year}", $"{DateTime.Now.Year}").Replace("{NameOrg}", faceUl.NameOrg).Replace("{InnOrg}", faceUl.Inn);
                            CreateAndSaveQuestionsUser(libraryAutomation, dataBaseAdd, userFace.IdUser, template.IdTemplateQuestions, modelQuestions);
                        }
                        break;
                }
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
            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ElementNameWitnesses.AddQuestion);
            libraryAutomation.IsEnableElements(ElementNameWitnesses.AddTextQuestion);
            libraryAutomation.FindElement = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindElement).Cast<AutomationElement>().ToArray()[0];
            libraryAutomation.SetLegacyIAccessibleValuePattern(questions);
            libraryAutomation.InvokePattern(libraryAutomation.IsEnableElements(ElementNameWitnesses.OkQuestion));
            dataBaseAdd.SaveQuestionsUser(idUser, idTemplateQuestions, questions);
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
