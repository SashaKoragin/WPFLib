using System;
using System.Data.SqlClient;
using System.Xml;
using LibaryXMLAuto.ModelXmlSql.ConvertModel.DesirializationSql;
using LibaryXMLAuto.ReadOrWrite.SerializationJson;
using LibaryXMLAutoModelXmlSql.Model.Bdk.BdkIt;
using LibaryXMLAutoModelXmlSql.Model.FaceError;
using LibaryXMLAutoModelXmlSql.Model.Trebovanie;


namespace SqlLibaryIfns.SqlZapros.ZaprosSelectNotParam
{
   public class SelectFull
    {
        /// <summary>
        /// Выполнение выборки Sql на сервере касательно сериализации десериализации
        /// </summary>
        /// <param name="conectionstring">Строка соединения</param>
        /// <param name="select">Команда Select</param>
        /// <param name="type">Тип возвращаемого значения класса образец "(SysNum)SelectFullSqlReader(conectionstring, select,typeof(SysNum)"</param>
        /// <returns>Возвращаем object для дальнейшего разбора по классу</returns>
        public object SelectFullSqlReader(string conectionstring,string select,Type type)
        {
            SqlDesirialization xmldesirealiz = new SqlDesirialization();
            object obj;
            using (var con = new SqlConnection(conectionstring))
            {
                using (var cmd = new SqlCommand(select, con))
                {
                    cmd.Connection.Open();
                    using (XmlReader reader = cmd.ExecuteXmlReader())
                    {
                     obj = xmldesirealiz.ReadXml(reader, type);
                    }
                }
            }
            return obj;
        }
        /// <summary>
        /// Данный блок относится к слиянию лиц
        /// </summary>
        /// <param name="conectionstring">Строка соединения</param>
        /// <param name="select">Параметры выборки</param>
        /// <returns>Модель Face</returns>
        public Face FaceError(string conectionstring, string select)
        {
           return (Face)SelectFullSqlReader(conectionstring, select, typeof(Face));
        }
        /// <summary>
        /// Данный блок относится к БДК
        /// </summary>
        /// <param name="conectionstring">Строка соединения</param>
        /// <param name="select">Команда Select</param>
        /// <returns>Возвращаем модель JSON в виде строки</returns>
        public string BdkSqlSelect(string conectionstring, string select)
        {
            SerializeJson serializeJson = new SerializeJson();
            return serializeJson.JsonLibary((AnalisBdkFull) SelectFullSqlReader(conectionstring, select,typeof(AnalisBdkFull)));
        }
    }
}