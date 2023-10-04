using System.Data.Entity;
using System.Linq;
using EfDatabaseAutomation.Automation.Base;

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
            return Automation.MainOrgs.Where(x => x.IsReady == false).ToArray();
        }
        /// <summary>
        /// Вопросы на которые надо формировать шаблон
        /// </summary>
        /// <returns></returns>
        public TemplateQuestion[] SelectTemplateQuestions()
        {
            return Automation.TemplateQuestions.ToArray();
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
    }
}
