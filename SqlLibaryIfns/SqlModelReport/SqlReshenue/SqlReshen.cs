using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Xml;
using LibaryXMLAuto.ModelXmlSql.ConvertModel.DesirializationSql;
using LibaryXMLAuto.ModelXmlSql.Model.FullSetting;
using LibaryXMLAuto.ReadOrWrite.SerializationJson;
using LibaryXMLAutoModelXmlSql.Model.Bdk.BdkIt;
using LibaryXMLAutoModelXmlSql.Model.FaceError;
using LibaryXMLAutoModelXmlSql.Model.Trebovanie;
using SqlLibaryIfns.SqlZapros.ZaprosSelectParametr;

namespace SqlLibaryIfns.SqlModelReport.SqlReshenue
{
   public class SqlReshen
    {
        /// <summary>
        /// Данный блок относится к Решениям 
        /// </summary>
        /// <param name="conectionstring">Строка соединения</param>
        /// <param name="setting">Настройки</param>
        /// <returns>Возвращаем модель JSON в виде строки</returns>
        public string SysNumReshenie(string conectionstring, FullSetting setting)
        {
            try
            {
            SerializeJson serializeJson = new SerializeJson();
            SelectFullParametr selectmodel = new SelectFullParametr();
            Dictionary<string, string> listparametr = null;
            GenerateParametrSql.GenerateParametrSql sql = new GenerateParametrSql.GenerateParametrSql();
            if (setting.ParametrReshen.D85DateStart != DateTime.MinValue)
               {
                sql.CreateParamert(ref listparametr, setting.ParametrReshen.GetType(), setting.ParametrReshen);
               }
            return serializeJson.JsonLibary((SysNum)selectmodel.SelectFullParametrSqlReader(conectionstring, SqlSelect.SqlReshenia.ProcedureReshenie.SelectReshenie, typeof(SysNum),listparametr));
            }
            catch (Exception e)
            {
                Loggers.Log4NetLogger.Error(e);
            }
            return null;
        }
    }
}
