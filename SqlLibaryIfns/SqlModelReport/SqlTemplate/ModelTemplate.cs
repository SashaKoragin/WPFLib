using System.Collections.Generic;
using LibaryXMLAuto.ModelXmlSql.Model.FullSetting;
using LibaryXMLAutoModelServiceWcfCommand.TestIfnsService;
using LibaryXMLAutoReports.FullTemplateSheme;
using SqlLibaryIfns.SqlSelect.ModelSqlFullService;
using SqlLibaryIfns.SqlZapros.SqlConnections;

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
            var sqlconnect = new SqlConnectionType();
            Dictionary<string, string> listparametr = null;
            GenerateParametrSql.GenerateParametrSql sql = new GenerateParametrSql.GenerateParametrSql();
            if (setting.UseTemplate.IdTemplate != 0)
            {
                sql.CreateParamert(ref listparametr, setting.UseTemplate.GetType(), setting.UseTemplate);
            }
            return (Document)sqlconnect.SelectFullParametrSqlReader(conectionstring, ((ServiceWcf)sqlconnect.SelectFullParametrSqlReader(conectionstring, ModelSqlFullService.ProcedureSelectParametr, typeof(ServiceWcf), ModelSqlFullService.ParamCommand("10"))).ServiceWcfCommand.Command, typeof(Document), listparametr);
        }
    }
}
