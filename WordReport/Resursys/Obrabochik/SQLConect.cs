using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Reflection;

namespace WordReport.Resursys.Obrabochik
{
   public class SqlConect
   {
        private static readonly object[] SqlObjects =
        {
           SqlZapr.SqlZapr.Seathinn,
           SqlZapr.SqlZapr.Seathadress,
           SqlZapr.SqlZapr.Seathname
       };




        public DataSet AdataTable(string inn, ref string exceptionMsg)
       {
            var i = 0;
            var dt = new DataSet();
            foreach (var sql in SqlObjects)
            {
                try
                {
                    dt.Tables.Add();
                       using (var con =new SqlConnection(Config.ConectionString.Connection))
                 {
                    using (var cmd = new SqlCommand(sql.ToString(), con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@INN", inn);
                        con.Open();
                        using (var dr = cmd.ExecuteReader())
                            {
                                dt.Tables[i].Load(dr);
                                
                            }
                            con.Close();
                            i++;
                    }
                }
            }
                catch (Exception e)
                {
                    exceptionMsg = e.Message;
                }
            }
            return dt;
        }
    }
}
