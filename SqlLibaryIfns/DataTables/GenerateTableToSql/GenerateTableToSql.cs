using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Reflection;

namespace SqlLibaryIfns.DataTables.GenerateTableToSql
{
    /// <summary>
    /// Класс для создания DataTable на основе ObservableCollection T где T это класс 
    /// </summary>
    public class GenerateTableToSql
    {
        /// <summary>
        /// Генерация Таблицы на основании ObservableCollection<T/> класса????
        /// колонки генерятся на основании coll[0] нулевого элемента
        /// </summary>
        /// <param name="coll">Коллекция класса</param>
        /// <returns></returns>
        public DataTable TableToSqlMass<T>(ObservableCollection<T> coll)
        {
            if (coll[0].GetType().IsClass)
            {
                DataTable dataTable = new DataTable();
                GenerateColum(ref dataTable, coll[0]);
                foreach (var fns in coll)
                {
                    DataRow row = dataTable.NewRow();
                    var properties = fns.GetType().GetProperties();
                    foreach (PropertyInfo info in properties)
                    {
                        row[info.Name] = info.GetValue(fns);
                    }
                    dataTable.Rows.Add(row);
                }
                return dataTable;
            }
            Loggers.Log4NetLogger.Error(new Exception($"Элемент коллекции {coll[0].GetType()} не является классом!!!"));
            return null;
        }
        /// <summary>
        /// Генерация колонок на основании класса
        /// </summary>
        /// <param name="table">Таблица</param>
        /// <param name="obj">Объект класса</param>
        private void GenerateColum(ref DataTable table, object obj)
        {
            var properties = obj.GetType().GetProperties();
            foreach (PropertyInfo info in properties)
            {
                table.Columns.Add(new DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
            }
        }


    }
}
