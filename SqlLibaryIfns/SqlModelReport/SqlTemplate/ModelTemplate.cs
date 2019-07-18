using System.Collections.Generic;
using LibaryXMLAuto.ModelXmlSql.Model.FullSetting;
using LibaryXMLAutoModelServiceWcfCommand.TestIfnsService;
using LibaryXMLAutoModelXmlAuto.Inspection;
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
            Dictionary<string, string> listparametr = new Dictionary<string, string>();
            GenerateParametrSql.GenerateParametrSql sql = new GenerateParametrSql.GenerateParametrSql();
            if (setting.UseTemplate.IdTemplate != 0)
            {
                sql.CreateParamert(ref listparametr, setting.UseTemplate.GetType(), setting.UseTemplate);
            }
            return (Document)sqlconnect.SelectFullParametrSqlReader(conectionstring, ((ServiceWcf)sqlconnect.SelectFullParametrSqlReader(conectionstring, ModelSqlFullService.ProcedureSelectParametr, typeof(ServiceWcf), ModelSqlFullService.ParamCommand("10"))).ServiceWcfCommand.Command, typeof(Document), listparametr);
        }


        /// <summary>
        /// Возвращает название инспекции по номеру инспекции FullSetting.Inspection.Number
        /// </summary>
        /// <param name="conectionstring">Строка соединения</param>
        /// <param name="N279">Номер инспекции</param>
        /// <returns>Название инспекции</returns>
        public Insp Inspection(string conectionstring, string N279)
        {
            var sqlconnect = new SqlConnectionType();
            Dictionary<string, string> listparametr = new Dictionary<string, string>();
            listparametr.Add("@N279", N279);
            return (Insp)sqlconnect.SelectFullParametrSqlReader(conectionstring, ((ServiceWcf)sqlconnect.SelectFullParametrSqlReader(conectionstring, ModelSqlFullService.ProcedureSelectParametr, typeof(ServiceWcf), ModelSqlFullService.ParamCommand("30"))).ServiceWcfCommand.Command, typeof(Insp), listparametr);
        }

    }
}
