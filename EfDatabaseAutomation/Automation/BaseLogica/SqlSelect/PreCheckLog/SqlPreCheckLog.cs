using System;
using EfDatabaseAutomation.Automation.Base;

namespace EfDatabaseAutomation.Automation.BaseLogica.SqlSelect.PreCheckLog
{
   public class SqlPreCheckLog : IDisposable
    {
        public Base.Automation Automation { get; set; }

        public SqlPreCheckLog()
        {
            Automation?.Dispose();
            Automation = new Base.Automation();
        }

        /// <summary>
        /// Легирование ошибок с сервера
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        /// <param name="method">Метод</param>
        /// <param name="statusCode">Код статуса</param>
        /// <param name="error">Ошибка</param>
        public void AddTaxJournal(string userName,string method,string statusCode,string error)
        {
            var logsFile = new LogPreCheck();
            logsFile.UserTabelNum = userName;
            logsFile.Method = method;
            logsFile.StatusMethod = statusCode;
            logsFile.ErrorLog = error;
            Automation.LogPreChecks.Add(logsFile);
            Automation.SaveChanges();
        }


        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Automation?.Dispose();
                Automation = null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
