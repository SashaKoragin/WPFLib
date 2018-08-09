using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Xml;
using DocumentFormat.OpenXml.Spreadsheet;
using LibaryXMLAuto.ModelXmlSql.ConvertModel.DesirializationSql;

namespace SqlLibaryIfns.SqlZapros.ZaprosSelectParametr
{
   public class SelectFullParametr
    {
        /// <summary>
        /// Выполнение выборки Sql на сервере касательно сериализации десериализации
        /// </summary>
        /// <typeparam name="TKey">Ключ параметра</typeparam>
        /// <typeparam name="TValue">Тип параметра</typeparam>
        /// <param name="conectionstring">Строка соединения</param>
        /// <param name="select">Команда Select</param>
        /// <param name="type">Тип возвращаемого значения класса образец "(SysNum)SelectFullSqlReader(conectionstring, select,typeof(SysNum)"</param>
        /// <param name="listparametr">Словарь параметров</param>
        /// <returns>Возвращаем object для дальнейшего разбора по классу</returns>
        public object SelectFullParametrSqlReader<TKey, TValue>(string conectionstring, string select, Type type, Dictionary<TKey,TValue> listparametr = null)
        {
            SqlDesirialization xmldesirealiz = new SqlDesirialization();
            object obj;
            if (listparametr != null)
            {
                GenerateParametrSql.GenerateParametrSql sql = new GenerateParametrSql.GenerateParametrSql();
                sql.GenerateStringParametr(ref select, listparametr);
            }
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
    }
}
