using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibaryXMLAutoReports.ReportsBdk;
using LibaryXMLAutoReports.TemplateSheme;
using SqlLibaryIfns.SqlZapros.ZaprosSelectNotParam;

namespace SqlLibaryIfns.SqlModelReport.SqlTemplate
{
   public class ModelTemplate
    {
        /// <summary>
        /// Шаблон который используем написано кустарно нужно давать Ун шаблона на вход!!!
        /// </summary>
        /// <param name="conectionstring">Строка соединения</param>
        /// <returns></returns>
        public Document Template(string conectionstring)
        {
            SelectFull selectmodel = new SelectFull();
            return (Document)selectmodel.SelectFullSqlReader(conectionstring, SqlSelect.Report.Template.Template.SelectTemplate, typeof(Document));
        }
    }
}
