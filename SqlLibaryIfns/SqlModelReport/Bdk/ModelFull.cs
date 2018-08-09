using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibaryXMLAuto.ModelXmlSql.Model.FullSetting;
using LibaryXMLAutoReports.ReportsBdk;
using SqlLibaryIfns.SqlZapros.ZaprosSelectNotParam;
using SqlLibaryIfns.SqlZapros.ZaprosSelectParametr;

namespace SqlLibaryIfns.SqlModelReport.Bdk
{
   public class ModelFull
    {
        /// <summary>
        /// Данные которые будут раскладываться на шаблоне
        /// </summary>
        /// <param name="conectionstring">Строка соединения с сервером</param>
        /// <param name="setting">Нфстроики пользователя</param>
        /// <returns></returns>
        public Report ReportBdk(string conectionstring, FullSetting setting)
        {
            try
            {
            SelectFullParametr selectmodel = new SelectFullParametr();
            Dictionary<string, string> listparametr = null;
            GenerateParametrSql.GenerateParametrSql sql = new GenerateParametrSql.GenerateParametrSql();
            if (setting.ParametrBdkOut.D85DateStart!= DateTime.MinValue)
            {
                sql.CreateParamert(ref listparametr, setting.ParametrBdkOut.GetType(), setting.ParametrBdkOut);
            }
            return (Report)selectmodel.SelectFullParametrSqlReader(conectionstring, SqlSelect.Report.ReportBdk.ReportBdk.ReportBdkFull, typeof(Report), listparametr);
            }
            catch (Exception e)
            {
                Loggers.Log4NetLogger.Error(e);
            }
            return null;
        }
    }
}
