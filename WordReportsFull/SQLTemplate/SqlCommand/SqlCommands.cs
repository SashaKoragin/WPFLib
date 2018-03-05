using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordReportsFull.SQLTemplate.SqlCommand
{
   public class SqlCommands
    {

        public static readonly object[] SummNedoim =
       {
           Seathinn,
           Seathadress,
           Seathname,
           GetDataServer
       };

        public static readonly object[] Ndflfl =
       {
                Ndfl,
                FlNameAdress
       };

        public const string Seathinn = @"SELECT CONVERT(varchar(10),FN1505.D83) as D83,FN52.N313,FN1011.D39,FN1002.D126 FROM FN1505
                                         INNER JOIN  FN1011 ON  FN1505.D73 = FN1011.D73
                                         INNER   JOIN FN52     ON FN1505.n120 = fn52.n120
                                         INNER   JOIN FN1002   ON FN1002.d6 = fn1505.d6
                                         INNER JOIN  FN1003 ON  FN1003.d8 = fn1505.d8
                                         INNER JOIN  FN212
                                         JOIN  FN213 ON  FN213.N314= FN212.N314 ON FN1505.N1 = FN212.N1
                                         LEFT JOIN FN1262 ON FN1002.D2718= FN1262.D2718
                                         LEFT JOIN FN1262 FN1262_b ON FN1003.D2718= FN1262_b.D2718
                                         Left Join FN1041 On FN1041.N1 = FN1505.N1 And FN1041.N120 = FN1505.N120 And FN1041.D6 = FN1505.D6
                                         WHERE (FN1505.D83< 0)
                                         AND((FN1002.D17_18_127 LIKE '%18210202010060000160%')
                                         OR(FN1002.D17_18_127 LIKE '%18210202020060000160%')
                                         OR(FN1002.D17_18_127 LIKE '%18210202031060000160%')
                                         OR(FN1002.D17_18_127 LIKE '%18210202032060000160%')
                                         OR(FN1002.D17_18_127 LIKE '%18210202080060000160%')
                                         OR(FN1002.D17_18_127 LIKE '%18210202090070000160%')
                                         OR(FN1002.D17_18_127 LIKE '%18210202100060000160%')
                                         OR(FN1002.D17_18_127 LIKE '%18210202101080011160%')
                                         OR(FN1002.D17_18_127 LIKE '%18210202103080011160%')
                                         OR(FN1002.D17_18_127 LIKE '%18210202110060000160%')
                                         OR(FN1002.D17_18_127 LIKE '%18210202131060000160%')
                                         OR(FN1002.D17_18_127 LIKE '%18210202132060000160%')
                                         OR(FN1002.D17_18_127 LIKE '%18210202140060000160%')
                                         OR(FN1002.D17_18_127 LIKE '%18210202150060000160%'))
                                         AND(FN212.N134 = @INN) FOR XML AUTO, ROOT('Summ')";

        public const string Seathadress = @"Select FN213.N320 From FN212 Join FN213 on FN213.N314 = FN212.N314 Where FN212.N134=@INN and FN212.D3='775101001' FOR XML AUTO, ROOT('Adress')";
        public const string Seathname = @"Select FN212.N18 From FN212 Where FN212.N134=@INN and FN212.D3='775101001' FOR XML AUTO, ROOT('Name')";
        public const string GetDataServer = @"Select GETDATE() as Date FOR XML RAW, ROOT('GetDate')";

        public const string Ndfl = @"Select 'Вами '+convert(varchar(30),FN1532.D223,104)+' года в Инспекцию представлена налоговая декларация по форме 3-НДФЛ за ' +  convert(varchar(30),FN1709.D250) + ' год.' as NDFL,
                                      Fn1534.N590,FN17091.D83_1,convert(varchar(30),Fn1534.D85,104) as DataIzd
                                      From FN1709
                                      join FN1532 on FN1709.D270 = FN1532.D270
                                      join FN17091 on Fn1709.D270 = Fn17091.D270
                                      join Fn1182 on Fn1182.D270 = Fn1709.D270
                                      join Fn1517 on Fn1182.D865 = Fn1517.D865
                                      join Fn1534 on Fn1534.D270 = Fn1517.D270
                                     Where D3811_1 = @INN and FN1709.D250=@GOD FOR XML AUTO, ROOT('Ndfl')";

        public const string FlNameAdress = @"Select N18, N320, N142 +' ' +N610 as Uvaz From Fn212
                                             Join FN213 on Fn213.N314 = Fn212.N314
                                             Join FN211 on Fn211.N1 = Fn212.N1
                                             Where N134 = @INN FOR XML AUTO, ROOT('FlAdressName')";
    }
}
