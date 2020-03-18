using EfDatabaseAutomation.Automation.SelectParametrSheme;
using LibaryXMLAuto.ReadOrWrite.SerializationJson;
using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using EfDatabaseAutomation.Automation.BaseLogica.XsdAuto.Okp2.ShemeTaxJournal;


namespace EfDatabaseAutomation.Automation.BaseLogica.SqlSelect.SelectAll
{
   public class SelectAll : IDisposable
    {
        public Base.Automation Automation { get; set; }

        public SelectAll()
        {
            Automation?.Dispose();
            Automation = new Base.Automation();
        }

        /// <summary>
        /// Выполнение запроса и конвертация его в JSON
        /// </summary>
        /// <param name="sqlSelect">Выборка пользовательская</param>
        /// <returns></returns>
        public string SelectSqlAll(LogicsSelectAutomation sqlSelect)
        {
            SerializeJson serializeJson = new SerializeJson();
            var webPage = new AutoWebPage();
            var result = Automation.Database.SqlQuery<TaxJournalAutoWebPage>(sqlSelect.SelectUser).ToArray();
            webPage.TaxJournalAutoWebPage = result;
            var json = serializeJson.JsonLibary(webPage);
            return json;
        }

        /// <summary>
        /// Выгрузка файла из БД
        /// </summary>
        /// <param name="idFile">Ун файла</param>
        /// <returns>Файл</returns>
        public Stream LoadFilePdf(int? idFile)
        {
            try
            {  
                var doc = Automation.TaxJournals.FirstOrDefault(x => x.Id == idFile);
                if (doc?.Document != null)
                {
                 doc.IsPrint = true;
                 Automation.Entry(doc).State = EntityState.Modified;
                 Automation.SaveChanges();
                 return new MemoryStream(doc.Document);
                }
            }
            catch (Exception e)
            {
               Loggers.Log4NetLogger.Error(e);
            }
            return null;
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
