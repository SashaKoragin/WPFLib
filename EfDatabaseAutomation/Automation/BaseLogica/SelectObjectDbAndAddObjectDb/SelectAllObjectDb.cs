using LibaryXMLAuto.ReadOrWrite.SerializationJson;
using System;
using System.Linq;
using EfDatabaseAutomation.Automation.Base;


namespace EfDatabaseAutomation.Automation.BaseLogica.SelectObjectDbAndAddObjectDb
{
   public class SelectAllObjectDb : IDisposable
    {

        public Base.Automation AutomationContext { get; set; }

        public SelectAllObjectDb()
        {
            AutomationContext?.Dispose();
            AutomationContext = new Base.Automation();
        }


        /// <summary>
        /// Все подписанты БД
        /// </summary>
        /// <returns></returns>
        public string AllSender()
        {
            SerializeJson json = new SerializeJson();
            return json.JsonLibaryIgnoreDate(AutomationContext.SenderTaxJournalOkp2);
        }
        /// <summary>
        /// Сопоставление подписи отделу подписания Акты Решения Извещения
        /// </summary>
        /// <returns></returns>
        public string AllSenderDepartment()
        {
            SerializeJson json = new SerializeJson();
            return json.JsonLibaryIgnoreDate(AutomationContext.DepartamentOtdels);
        }
        /// <summary>
        /// Все сотрудники организации
        /// </summary>
        /// <param name="inn">Инн организации</param>
        /// <returns></returns>
        public string AllUsersOrg(string inn)
        {
            SerializeJson json = new SerializeJson();
            return json.JsonLibaryIgnoreDate(AutomationContext.UserOrgs.Where(x=>x.MainOrg.Inn == inn));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsers">Ун пользователя</param>
        /// <returns></returns>
        public string AllQuestions(int idUsers)
        {
            SerializeJson json = new SerializeJson();
            return json.JsonLibaryIgnoreDate(AutomationContext.QuestionsAndUsers.Where(x => x.IdUser == idUsers).Select(x=>new 
            {
                x.IdQuestions, 
                x.IdUser,
                x.ModelQuestions
            }));
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                AutomationContext?.Dispose();
                AutomationContext = null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
