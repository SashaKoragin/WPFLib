using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using LibaryXMLAuto.ModelXmlSql.ConvertModel.DesirializationSql;
using SqlLibaryIfns.SqlZapros.SobytieSql;

namespace SqlLibaryIfns.SqlZapros.SqlConnections
{
    /// <summary>
    /// Данный класс преднозначен для генерации соединия с БД и получения разных ответов
    /// </summary>
   public class SqlConnectionType
    {
        /// <summary>
        /// Соединение для выгрузки в Excel
        /// Отчеты QBE Настроим выполнение по времени
        /// </summary>
        /// <param name="conectionstring">Строка соединения</param>
        /// <param name="select">QBE</param>
        /// <returns>Возвращаем таблицу из которой генерим файл для отчета</returns>
        public DataSet ReportQbe(string conectionstring, string select)
        {
            DataSet dataSet = new DataSet();
            using (var con = new SqlConnection(conectionstring))
            {
                using (var cmd = new SqlCommand(select, con) { CommandTimeout = 0 })
                {
                    con.Open();
                    using (var sqlreport = new SqlDataAdapter(cmd))
                    {
                        sqlreport.Fill(dataSet);
                    }
                }
                con.Close();
                SqlConnection.ClearPool(con);
            }
            return dataSet;
        }

        /// <summary>
        /// Функция выполнения процедуры и с параметром и без параметров
        /// 1 - Если нет параметров то выполняется процедура без параметров
        /// 2 - Если есть параметры то выполняется Генерация параметров для SqlCommand а потом и процедура
        /// </summary>
        /// <typeparam name="TKey">Ключ параметра</typeparam>
        /// <typeparam name="TValue">Тип параметра</typeparam>
        /// <param name="conectionstring">Строка соединения</param>
        /// <param name="procedure">Название процедуры</param>
        /// <param name="listparametr">Словарь параметров</param>
        /// <returns>Сообщение от сервера</returns>
        public string StartingProcedure<TKey, TValue>(string conectionstring, string procedure, Dictionary<TKey, TValue> listparametr = null)
        {
            try
            {
                Sobytie sobytie = new Sobytie { Messages = null };
                using (var con = new SqlConnection(conectionstring))
                {
                    SqlCommand command = new SqlCommand(procedure) { CommandType = CommandType.StoredProcedure, Connection = con, CommandTimeout = 0 };
                    con.InfoMessage += sobytie.Con_InfoMessage;
                    if (listparametr?.Count > 0)
                    {
                        GenerateParametrSql.GenerateParametrSql sql = new GenerateParametrSql.GenerateParametrSql();
                        command = sql.GenerateParametrs(command, listparametr);
                    }
                    con.Open();
                   
                    using (command.ExecuteReader())
                    {

                    }
                    con.Close();
                    SqlConnection.ClearPool(con);
                }
                return sobytie.Messages;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

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
        public object SelectFullParametrSqlReader<TKey, TValue>(string conectionstring, string select, Type type, Dictionary<TKey, TValue> listparametr = null)
        {
            SqlDesirialization xmldesirealiz = new SqlDesirialization();
            object obj;
            if (listparametr?.Count > 0)
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
                        if (obj == null)
                        {
                            Loggers.Log4NetLogger.Error(new Exception($"Объект {type.FullName} вернул NULL"));
                        }
                    }
                }
                con.Close();
                SqlConnection.ClearPool(con);
            }
            return obj;
        }
    }
}
