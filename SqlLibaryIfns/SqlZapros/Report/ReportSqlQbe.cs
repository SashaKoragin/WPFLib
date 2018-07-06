using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLibaryIfns.SqlZapros.Report
{
   public class ReportSqlQbe
    {
        /// <summary>
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
                using (var cmd = new SqlCommand(select,con) {CommandTimeout = 0})
                {
                    con.Open();
                    using (var sqlreport =new SqlDataAdapter(cmd))
                    {
                        sqlreport.Fill(dataSet);
                    }
                }
            }
            return dataSet;
        }
    }
}
