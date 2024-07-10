using System;
using System.Data.Entity;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using EfDatabaseAutomation.Automation.Base;
using EfDatabaseAutomation.Automation.BaseLogica.ActiveDirectory;

namespace EfDatabaseAutomation.Automation.BaseLogica.SaveAndLoadInterrogationOfWitnesses
{

 
    public class SelectAndUpdateInterrogationOfWitnesses
    {

        public Base.Automation Automation { get; set; }

        /// <summary>
        /// Выборка или редактирования Опросы свидетелей
        /// </summary>
        public SelectAndUpdateInterrogationOfWitnesses()
        {
            Automation = new Base.Automation();
            Automation.Database.CommandTimeout = 120000;
        }
        /// <summary>
        /// Запрос всех не выполненных организаций
        /// </summary>
        /// <returns></returns>
        public MainOrg[] SelectAllMainOrgIsNotReady()
        {
            return Automation.MainOrgs.Include(x=>x.UserOrgs).Where(x => x.IsReady == false).ToArray();
        }
        /// <summary>
        /// Запрос всех неотработаных генеральных директоров
        /// </summary>
        /// <returns></returns>
        public MainUserRegistrationFl[] SelectAllUserRegistrationFlIsNotReady()
        {
            return Automation.MainUserRegistrationFls.Where(x => x.IsReady == false).ToArray();
        }
        /// <summary>
        /// Шаблон заполнения дополнительных для Допроса свидетелей
        /// </summary>
        /// <returns></returns>
        /// <param name="idUserDomain">Табельный номер пользователя</param>
        public DepartmentOtdelResponse SelectFirstModelResponse(string idUserDomain)
        {
            var activeDirectorySelectModel = new ActiveDirectorySelectModel();
            var groups = activeDirectorySelectModel.SelectAllGroupUser(idUserDomain);
            if (groups == null)
                return null;
            var senderUser = from departmentOtdelResponse in Automation.DepartmentOtdelResponses
                             where groups.Any(gr => gr.Contains(departmentOtdelResponse.NameDepartmentActiveDirectory))
                join senderResponses in Automation.SenderResponses on departmentOtdelResponse.IdSenderResponse equals senderResponses.IdSenderResponse
                select senderResponses;
            return senderUser.SelectMany(h => h.DepartmentOtdelResponses.Where(y => groups.Any(r => r.Contains(y.NameDepartmentActiveDirectory)))).Include(x => x.SenderResponse).Include(y=>y.TemplateModelResponse).FirstOrDefault();
        }
        /// <summary>
        /// Вопросы на которые надо формировать шаблон
        /// </summary>
        /// <returns></returns>
        ///<param name="typeQuestions">Тип вопросов для организации</param>
        public TemplateQuestion[] SelectTemplateQuestions(int typeQuestions)
        {
            return Automation.TemplateQuestions.Where(x=>x.IdType == typeQuestions).ToArray();
        }
        /// <summary>
        /// Функция Проверки все ли лица обработаны
        /// </summary>
        /// <returns></returns>
        /// <param name="idOrg">Ун организации</param>
        public bool IsEndListUserOrg(int idOrg)
        {
           return Automation.UserOrgs.Any(x => x.IdOrg == idOrg & !x.IsGood && !x.IsError);
        }

        /// <summary>
        /// Сохранение организации
        /// </summary>
        /// <param name="mainOrg">Организация</param>
        public void SaveMainOrg(MainOrg mainOrg)
        {
            Automation.Entry(mainOrg).State = EntityState.Modified;
            Automation.SaveChanges();
        }
        /// <summary>
        /// Сохранение генерального директора 
        /// </summary>
        /// <param name="mainUser">Генеральный директор</param>
        public void SaveMainUserRegistrationFl(MainUserRegistrationFl mainUser)
        {
            Automation.Entry(mainUser).State = EntityState.Modified;
            Automation.SaveChanges();
        }
        /// <summary>
        /// Сотрудник в организации
        /// </summary>
        /// <param name="userOrg">Сотрудник</param>
        public void SaveUsers(UserOrg userOrg)
        {
            Automation.Entry(userOrg).State = EntityState.Modified;
            Automation.SaveChanges();
        }
        /// <summary>
        /// Сохранение или обновление вопроса для рабочего класса сотрудника
        /// </summary>
        /// <param name="idUser">Ун пользователя</param>
        /// <param name="idTemplateQuestions">Ун вопроса</param>
        /// <param name="questions">Составленный вопрос</param>
        public void SaveQuestionsUser(int idUser, int idTemplateQuestions, string questions)
        {
            var questionsAndUsersModelEditAndAdd = new QuestionsAndUser()
            {
                IdUser = idUser,
                IdTemplateQuestions = idTemplateQuestions,
                ModelQuestions = questions
            };
            using (var context = new Base.Automation())
            {
                var modelDb = from usersQ in context.QuestionsAndUsers 
                    where usersQ.IdUser == idUser && usersQ.IdTemplateQuestions == idTemplateQuestions && usersQ.ModelQuestions == questions
                    select new { UsersQuestions = usersQ };
                if (modelDb.Any())
                {
                    questionsAndUsersModelEditAndAdd.IdQuestions = modelDb.First().UsersQuestions.IdQuestions;
                    Automation.Entry(questionsAndUsersModelEditAndAdd).State = EntityState.Modified;
                    Automation.SaveChanges();
                    return;
                }
                Automation.QuestionsAndUsers.Add(questionsAndUsersModelEditAndAdd);
                Automation.SaveChanges();
            }
        }
        /// <summary>
        /// Сохранение вопроса генеральному директору
        /// </summary>
        /// <param name="idUserRegistration">Ун генерального директора</param>
        /// <param name="idTemplateQuestions">Ун шаблона вопроса</param>
        /// <param name="question">Вопрос</param>
        public void SaveQuestionsAndUserRegistrationFl(int idUserRegistration, int idTemplateQuestions, string question)
        {
            var questionsAndUsersModelEditAndAdd = new QuestionsAndUserRegistrationFl()
            {
                IdUserRegistrationFl = idUserRegistration,
                IdTemplateQuestions = idTemplateQuestions,
                ModelQuestions = question
            };
            using (var context = new Base.Automation())
            {
                var modelDb = from usersQ in context.QuestionsAndUserRegistrationFls
                              where usersQ.IdUserRegistrationFl == idUserRegistration && usersQ.IdTemplateQuestions == idTemplateQuestions && usersQ.ModelQuestions == question
                              select new { UsersQuestions = usersQ };
                if (modelDb.Any())
                {
                    questionsAndUsersModelEditAndAdd.IdQuestions = modelDb.First().UsersQuestions.IdQuestions;
                    Automation.Entry(questionsAndUsersModelEditAndAdd).State = EntityState.Modified;
                    Automation.SaveChanges();
                    return;
                }
                Automation.QuestionsAndUserRegistrationFls.Add(questionsAndUsersModelEditAndAdd);
                Automation.SaveChanges();
            }
        }
    }
}
