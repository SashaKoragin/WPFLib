using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibaryXMLAutoReports.ReportsBdk;
using SqlLibaryIfns.SqlZapros.ZaprosSelectNotParam;

namespace SqlLibaryIfns.SqlModelReport.Bdk
{
   public class ModelFull
    {
        /// <summary>
        /// Данные которые будут раскладываться на шаблоне
        /// </summary>
        /// <param name="conectionstring">Строка соединения с сервером</param>
        /// <returns></returns>
        public Report ReportBdk(string conectionstring)
        {
            SelectFull selectmodel = new SelectFull();
            return (Report)selectmodel.SelectFullSqlReader(conectionstring, SqlSelect.Report.ReportBdk.ReportBdk.ReportBdkFull, typeof(Report));
        }
    }
}
