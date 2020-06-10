using EfDatabaseAutomation.Automation.SelectParametrSheme;
using LibaryXMLAuto.ReadOrWrite.SerializationJson;
using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using EfDatabaseAutomation.Automation.BaseLogica.XsdAuto.FullShemeModel;
using EfDatabaseAutomation.Automation.BaseLogica.SqlSelect.XsdDTOSheme;
using EfDatabaseAutomation.Automation.Base;
using ModelKbkOnKbk = EfDatabaseAutomation.Automation.BaseLogica.XsdAuto.FullShemeModel.ModelKbkOnKbk;

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
        public string SelectSqlAll(SelectParametrSheme.LogicsSelectAutomation sqlSelect)
        {
            SerializeJson serializeJson = new SerializeJson();
            var webPage = new AutoWebPage();
            var dataBaseUlSelect = new DataBaseUlSelect();
            object result;
            switch (sqlSelect.Id)
            {
                case 2:
                    result = Automation.Database.SqlQuery<XsdAuto.FullShemeModel.TaxJournalAutoWebPage>(sqlSelect.SelectUser).ToArray();
                    webPage.TaxJournalAutoWebPage = (XsdAuto.FullShemeModel.TaxJournalAutoWebPage[])result;
                    break;
                case 3:
                    result = Automation.Database.SqlQuery<XsdAuto.FullShemeModel.TaxJournal121AutoWebPage>(sqlSelect.SelectUser).ToArray();
                    webPage.TaxJournal121AutoWebPage = (XsdAuto.FullShemeModel.TaxJournal121AutoWebPage[])result;
                    break;
                case 5:
                    result = Automation.Database.SqlQuery<XsdAuto.FullShemeModel.AddUlFace>(sqlSelect.SelectUser).ToArray();
                    webPage.AddUlFace = (XsdAuto.FullShemeModel.AddUlFace[])result;
                    break;
                case 8:
                    result = Automation.Database.SqlQuery<XsdAuto.FullShemeModel.ModelTree>(sqlSelect.SelectUser).ToArray();
                    webPage.ModelTree = (XsdAuto.FullShemeModel.ModelTree[])result;
                    break;
                case 13:
                    result = Automation.Database.SqlQuery<XsdDTOSheme.UlFace>(sqlSelect.SelectUser).ToArray();
                    dataBaseUlSelect.UlFace = (XsdDTOSheme.UlFace[])result;
                    return serializeJson.JsonLibary(dataBaseUlSelect);
                case 14:
                    result = Automation.Database.SqlQuery<ModelKbkOnKbk>(sqlSelect.SelectUser).ToArray();
                    webPage.ModelKbkOnKbk = (ModelKbkOnKbk[])result;
                    break;
                case 15:
                    result = Automation.Database.SqlQuery<HelpKbkAuto>(sqlSelect.SelectUser).ToArray();
                    webPage.HelpKbkAuto = (HelpKbkAuto[])result;
                    break;
                default:
                    return "Данная комманда не определена!!!";
            }
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
        /// Выгрузка документа по 121 статье
        /// </summary>
        /// <param name="idFile">Ун файла</param>
        /// <returns></returns>
        public Stream LoadFile121(int? idFile)
        {
            try
            {
                var doc = Automation.TaxJournal121.FirstOrDefault(x => x.Id == idFile);
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
        /// Запрос проверки КБК по платежу
        /// </summary>
        /// <param name="kbk">КБК для запроса уточнения</param>
        /// <returns></returns>
        public KbkPayment SelectKbkGroup(string kbk)
        {   
            return Automation.KbkPayments.FirstOrDefault(x => x.Kbk == kbk);
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
