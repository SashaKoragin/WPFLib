﻿using LibaryXMLAuto.ReadOrWrite.SerializationJson;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.DirectoryServices.AccountManagement;
using System.Dynamic;
using System.IO;
using System.Linq;
using EfDatabaseAutomation.Automation.Base;
using LibaryXMLAuto.ReadOrWrite;

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
        /// <param name="sqlSelect">Выборка пользовательская из таблицы LogicsSelectAutomation</param>
        /// <returns></returns>
        public string SqlModelAutomation<T>(SelectParametrSheme.LogicsSelectAutomation sqlSelect)
        {
            SerializeJson serializeJson = new SerializeJson();
            object result;
            string resultModel;
            Automation.Database.CommandTimeout = 120000;
            if (sqlSelect.IsResultXml)
            {
                var xml = new XmlReadOrWrite();
                result = Automation.Database.SqlQuery<string>(sqlSelect.SelectUser).ToArray();
                var resultXml = (T)xml.ReadXmlText(string.Join("", (string[])result), typeof(T));
                resultModel = serializeJson.JsonLibrary(resultXml, "dd.MM.yyyy HH:mm");
            }
            else
            {
                result = Automation.Database.SqlQuery<T>(sqlSelect.SelectUser).ToList();
                dynamic expand = new ExpandoObject();
                AddProperty(expand, typeof(T).Name, result);
                resultModel = serializeJson.JsonLibrary(expand, "dd.MM.yyyy HH:mm");
            }
            return resultModel;
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
        public DepartamentOtdel SelectSenderJournal(string idUserDomain)
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
                select sender;
            return senderUser.SelectMany(h => h.DepartamentOtdels.Where(y => groups.Any(r => r.Contains(y.NameDepartamentActiveDerectory)))).FirstOrDefault();
        }


        /// <summary>
        /// Добавление в ExpandoObject динамического названия типа
        /// </summary>
        /// <param name="expando">Динамический объект ExpandoObject</param>
        /// <param name="propertyName">Наименование параметра </param>
        /// <param name="propertyValue">Объект прикрепляемый к модели</param>
        private void AddProperty(ExpandoObject expando, string propertyName, object propertyValue)
        {
            var expandoDict = expando as IDictionary<string, object>;
            if (expandoDict.ContainsKey(propertyName))
                expandoDict[propertyName] = propertyValue;
            else
                expandoDict.Add(propertyName, propertyValue);
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
