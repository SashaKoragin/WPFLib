using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibaryXMLAuto.ModelXmlSql.Model.FullSetting;
using LibaryXMLAutoReports.ReportsBdk;
using LibaryXMLAutoReports.TemplateSheme;
using SqlLibaryIfns.SqlZapros.ZaprosSelectNotParam;
using SqlLibaryIfns.SqlZapros.ZaprosSelectParametr;

namespace SqlLibaryIfns.SqlModelReport.SqlTemplate
{
   public class ModelTemplate
    {
        /// <summary>
        /// Шаблон который используем написано кустарно нужно давать Ун шаблона на вход!!!
        /// </summary>
        /// <param name="conectionstring">Строка соединения</param>
        /// <param name="setting">Параметры шаблона</param>
        /// <returns></returns>
        public Document Template(string conectionstring, FullSetting setting)
        {
            SelectFullParametr selectmodel = new SelectFullParametr();
            Dictionary<string, string> listparametr = null;
            GenerateParametrSql.GenerateParametrSql sql = new GenerateParametrSql.GenerateParametrSql();
            if (setting.UseTemplate.IdTemplate != 0)
            {
                sql.CreateParamert(ref listparametr, setting.UseTemplate.GetType(), setting.UseTemplate);
            }
            return (Document)selectmodel.SelectFullParametrSqlReader(conectionstring, SqlSelect.Report.Template.Template.SelectTemplate, typeof(Document), listparametr);
        }
    }
}
