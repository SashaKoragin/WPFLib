using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLibaryIfns.AutoItSelect.Sql
{
   public class Lk2
    {
        /// <summary>
        /// Анализ есть ЛК2 или нет
        /// </summary>
        private bool Yeslk { get; set; }


        /// <summary>
        /// Выборка проверки Личного кабинета у плательщика.
        /// </summary>
        private string Lk2Fl = @"SELECT TOP 1 case when isnull(a.N279,'') = FN1044.N279 then 10 else 7 end,case when isnull(FN211.N608,'') <> '' then 1 else 7 end,case when FN212_LK2.N2296 = 1 then 10 else 7 end,FN212_LK2.N1,a.N134,FN211.N146,FN211.N142,FN211.N610,FN98.N236,FN211.N148,FN211.N147,FN211.N149,FN211.N150,a.N279,FN213.N320,FN212_LK2.D40,FN212_LK2.D41,case when FN212_LK2.N2296 = 1 then 'да' else 'нет' end FROM FN212_LK2
                              join FN211 on fn212_LK2.N1 = FN211.N1
                              left join FN212 a on  a.N1 = FN211.N1
                              left join FN213 on a.N314 = FN213.N314
                              left join FN98 on FN211.N235 = FN98.N235,
                              FN1044 WHERE ( FN212_LK2.N1 > 0) AND((a.N134 ='{0}'))";
        public bool SqlLk(string conection, string inn)
        {
            var sqlzapr = String.Format(Lk2Fl, inn);
            var dt = new DataSet();
            dt.Tables.Add();
            using (var con = new SqlConnection(conection))
            {
                using (var cmd = new SqlCommand(sqlzapr, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        dt.Tables[0].Load(dr);
                        if (dt.Tables[0].Rows.Count >= 1)
                        {
                            Yeslk = true;
                        }
                        else
                        {
                            Yeslk = false;
                        }
                    }
                    con.Close();
                }
            }
            return Yeslk;
        }
    }
}
