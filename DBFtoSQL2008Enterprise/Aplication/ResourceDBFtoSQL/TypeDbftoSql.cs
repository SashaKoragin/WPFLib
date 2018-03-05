using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlTypes;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Media;


namespace DBFtoSQL2008Enterprise.Aplication.ResourceDBFtoSQL
{
    /// <summary>
    /// Весь класс представляет словарь ресурсов для создания команды Create table to SQL
    /// </summary>
   public class TypeDbftoSql
    { 
        /// <summary>
        /// Метод обращается к словарю типов и находит сопоставлени DBF to SQL
        /// </summary>
        /// <param name="typedbf">Параметр Type DBF</param>
        /// <returns>Возвращает параметр Type SQL</returns>
        public static DbType TypeSql(string typedbf)
        {
            DbType sqldbtype = GetClrType(typedbf);
            return sqldbtype;
        }

        /// <summary>
        /// Словарь тивов данных нужно добавлять новые типы данных
        /// Нужно подумать как упростить и передавать параметр с типом и фиксированной длины а не тип на основе типа
        /// </summary>
        /// <param name="odbType"> Type DBF</param>
        /// <returns>Type Sql</returns>
        public static DbType GetClrType(string odbType)
        {

            switch (odbType)
            {
                
                case "DBTYPE_CHAR":
                    return DbType.AnsiString;
                case "DBTYPE_NUMERIC":
                    return DbType.Single;
                case "DBTYPE_BOOL":
                    return DbType.Boolean;
                case "DBTYPE_LONGVARCHAR":
                    return DbType.String;
                case "DBTYPE_DBDATE":
                    return DbType.Date;
                default:
                    throw new ArgumentOutOfRangeException(odbType);
            }
        }


    }
}
