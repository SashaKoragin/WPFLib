using System;
using System.Collections.Generic;
using LibaryXMLAuto.ModelXmlSql.Model.FullSetting;
using LibaryXMLAutoModelServiceWcfCommand.TestIfnsService;
using LibaryXMLAutoReports.ReportsBdk;
using SqlLibaryIfns.SqlSelect.ModelSqlFullService;
using SqlLibaryIfns.SqlZapros.SqlConnections;

namespace SqlLibaryIfns.SqlModelReport.Bdk
{
   public class ModelFull
    {
        /// <summary>
        /// Данные которые будут раскладываться на шаблоне
        /// </summary>
        /// <param name="conectionstring">Строка соединения с сервером</param>
        /// <param name="connecttestsqlcommand">Строка соединения с таблицей комманд для запроса данных</param>
        /// <param name="setting">Настроики пользователя</param>
        /// <returns></returns>
        public Report ReportBdk(string conectionstring, string connecttestsqlcommand, FullSetting setting)
        {
            try
            {
                var sqlconnect = new SqlConnectionType();
                Dictionary<string, string> listparametr = new Dictionary<string, string>();
            GenerateParametrSql.GenerateParametrSql sql = new GenerateParametrSql.GenerateParametrSql();
            if (setting.ParametrBdkOut.D85DateStart!= DateTime.MinValue)
            {
                sql.CreateParamert(ref listparametr, setting.ParametrBdkOut.GetType(), setting.ParametrBdkOut);
            }
            return (Report)sqlconnect.SelectFullParametrSqlReader(conectionstring, ((ServiceWcf)sqlconnect.SelectFullParametrSqlReader(connecttestsqlcommand, ModelSqlFullService.ProcedureSelectParametr, typeof(ServiceWcf), ModelSqlFullService.ParamCommand("11"))).ServiceWcfCommand.Command, typeof(Report), listparametr);
            }
            catch (Exception e)
            {
                Loggers.Log4NetLogger.Error(e);
            }
            return null;
        }
    }
}
