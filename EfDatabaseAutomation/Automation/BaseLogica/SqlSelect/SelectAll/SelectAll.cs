using LibaryXMLAuto.ReadOrWrite.SerializationJson;
using System;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.DirectoryServices.AccountManagement;
using System.IO;
using System.Linq;
using EfDatabaseAutomation.Automation.BaseLogica.XsdAuto.FullShemeModel;
using EfDatabaseAutomation.Automation.BaseLogica.SqlSelect.XsdDTOSheme;
using EfDatabaseAutomation.Automation.Base;
using ModelKbkOnKbk = EfDatabaseAutomation.Automation.BaseLogica.XsdAuto.FullShemeModel.ModelKbkOnKbk;
using HelpKbkAuto = EfDatabaseAutomation.Automation.BaseLogica.XsdAuto.FullShemeModel.HelpKbkAuto;
using FormulNdfl = EfDatabaseAutomation.Automation.BaseLogica.XsdAuto.FullShemeModel.FormulNdfl;
using DeliveryDocument = EfDatabaseAutomation.Automation.BaseLogica.XsdAuto.FullShemeModel.DeliveryDocument;

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
                case 16:
                    result = Automation.Database.SqlQuery<XsdAuto.FullShemeModel.AllJournal129>(sqlSelect.SelectUser).ToArray();
                    webPage.AllJournal129 = (XsdAuto.FullShemeModel.AllJournal129[])result;
                    break;
                case 17:
                    break;
                case 18:
                    result = Automation.Database.SqlQuery<Documen2NDFLIdentification>(sqlSelect.SelectUser).ToArray();
                    webPage.Documen2NDFLIdentification = (Documen2NDFLIdentification[])result;
                    break;
                case 19:
                    result = Automation.Database.SqlQuery<Documen2NDFLIdentification>(sqlSelect.SelectUser).ToArray();
                    webPage.Documen2NDFLIdentification = (Documen2NDFLIdentification[])result;
                    break;
                case 20:
                    result = Automation.Database.SqlQuery<Documen2NDFLIdentification>(sqlSelect.SelectUser).ToArray();
                    webPage.Documen2NDFLIdentification = (Documen2NDFLIdentification[])result;
                    break;
                case 22:
                    result = Automation.Database.SqlQuery<FormulNdfl>(sqlSelect.SelectUser).ToArray();
                    webPage.FormulNdfl = (FormulNdfl[])result;
                    break;
                case 23:
                    result = Automation.Database.SqlQuery<XsdDTOSheme.UlFace>(sqlSelect.SelectUser).ToArray();
                    dataBaseUlSelect.UlFace = (XsdDTOSheme.UlFace[])result;
                    return serializeJson.JsonLibary(dataBaseUlSelect);
                case 24:
                    result = Automation.Database.SqlQuery<DeliveryDocument>(sqlSelect.SelectUser).ToArray();
                    webPage.DeliveryDocument = (DeliveryDocument[])result;
                    break;
                case 25:
                    result = Automation.Database.SqlQuery<XsdDTOSheme.UlFace>(sqlSelect.SelectUser).ToArray();
                    dataBaseUlSelect.UlFace = (XsdDTOSheme.UlFace[])result;
                    return serializeJson.JsonLibary(dataBaseUlSelect);
                default:
                    return "Данная команда не определена!!!";
            }
            var json = serializeJson.JsonLibary(webPage);
            return json;
        }

        /// <summary>
        /// Выгрузка отчета по id параметру!
        /// </summary>
        /// <param name="idReport">Ун Отчета</param>
        /// <returns></returns>
        public ReportXlsx ReturnReportModelXlsx(int idReport)
        {
           return Automation.ReportXlsxes.FirstOrDefault(report => report.IdReport == idReport);
        }
        /// <summary>
        /// Выгрузка Отчета по покупкам
        /// На другие отчеты надо думать!!! Как сделать модель массово на разные отчеты!
        /// </summary>
        /// <param name="reportModel">Модель с параметром</param>
        /// <param name="inn">Параметр ИНН</param>
        /// <returns></returns>
        public DataTable ReturnModelReport(ReportXlsx reportModel,string inn)
        {
            var dateTable = new DataTable();
            dateTable.TableName = reportModel.NameTable + inn;
            var cmd = Automation.Database.Connection.CreateCommand();
            cmd.CommandText = reportModel.ProcedureReport;
            cmd.Parameters.Add(new SqlParameter(reportModel.ParameterProcedure.Split(',')[0], inn));
            cmd.Connection.Open();
            dateTable.Load(cmd.ExecuteReader());
            cmd.Dispose();
            return dateTable;
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
        /// Подписант документов для ОКП 2
        /// </summary>
        /// <returns></returns>
        /// <param name="idUserDomain">Табельный номер пользователя</param>
        public string SelectSenderJournal(string idUserDomain)
        {
            string[] groups;
            using (PrincipalContext context = new PrincipalContext(ContextType.Domain, "regions.tax.nalog.ru"))
            {
                using (var user = UserPrincipal.FindByIdentity(context, idUserDomain))
                {
                    if (user != null)
                    {
                        var group = user.GetGroups();
                        {
                            groups = new string[@group.Count()];
                            var i = 0;
                            foreach (var gr in @group)
                            {
                                groups[i] = gr.Name;
                                i++;
                            }
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException($"Пользователь по табельному номеру {idUserDomain} не найден в Active Directory!");
                    }
                }
            }
            var senderUser = from departmentOdell in Automation.DepartamentOtdels
                where groups.Any(gr => gr.Contains(departmentOdell.NameDepartamentActiveDerectory))
                join sender in Automation.SenderTaxJournalOkp2 on departmentOdell.IdSender equals sender.Id
                select sender.NameUser;
            return senderUser.FirstOrDefault();
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
