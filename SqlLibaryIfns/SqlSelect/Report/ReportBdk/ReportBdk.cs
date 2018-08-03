using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLibaryIfns.SqlSelect.Report.ReportBdk
{
   public class ReportBdk
   {
       public static string ReportBdkFull = @"Select FN71.N279,FN1723_2.D85,FN1723_2.D981,FN1723_2.GUID,FN71.N280 From FN71
                                                JOIN FN1723_2 on FN71.N279 = FN1723_2.N279 and FN71.N1 in (Select MAX(FN71.N1) From FN71 GROUP BY FN71.N279)
                                                JOIN FN1534 on FN1534.d270 = FN1723_2.D270
                                               WHERE ( FN1534.D430 in (2532, 2535)) AND (fn1723_2.D270_2 is null) AND fn1534.D430 = 2532 AND FN1723_2.D982 = 2 and FN1723_2.D85 BETWEEN '01.01.2012' and '01.07.2018'
                                               order by FN1723_2.N279 FOR XML AUTO,ROOT('ReportBdk')";
   }
}
