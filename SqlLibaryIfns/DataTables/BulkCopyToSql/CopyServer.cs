using System;
using System.Data;
using System.Data.SqlClient;

namespace SqlLibaryIfns.DataTables.BulkCopyToSql
{
   public class CopyServer
    {
        /// <summary>
        /// Перенос DateTable на сервер Sql
        /// </summary>
        /// <param name="conectionstring">Строка соединения с сервером</param>
        /// <param name="table">Таблица для переноса на сервер</param>
        /// <param name="nameremovetable">Наименование удаленной таблицы</param>
        public CopyServer(string conectionstring, DataTable table, string nameremovetable)
        {
                using (var loader = new SqlBulkCopy(conectionstring,SqlBulkCopyOptions.Default))
                {
                    try
                    {
                        loader.DestinationTableName = nameremovetable;
                        loader.BulkCopyTimeout = 9999;
                        foreach (DataColumn namecolum in table.Columns)
                        {
                            loader.ColumnMappings.Add(new SqlBulkCopyColumnMapping(namecolum.ColumnName,namecolum.ColumnName));
                        }
                        loader.WriteToServer(table);
                    }
                    catch (Exception exception)
                    {
                        Loggers.Log4NetLogger.Error(exception);
                    }
                }
        }
    }
}
