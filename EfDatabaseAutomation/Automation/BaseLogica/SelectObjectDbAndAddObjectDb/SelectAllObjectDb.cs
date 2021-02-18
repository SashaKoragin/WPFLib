using LibaryXMLAuto.ReadOrWrite.SerializationJson;
using System;


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
