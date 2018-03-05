using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordReport.Resursys.SqlZapr
{
    public class SqlZapr
    {
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
                                         AND(FN212.N134 = @INN)";

        public const string Seathadress = @"Select N320 From FN212 a Join FN213 b on a.N314 = b.N314 Where a.N134=@INN and a.D3='775101001'";
        public const string Seathname = @"Select N18 From FN212 a Join FN213 b on a.N314 = b.N314 Where a.N134=@INN and a.D3='775101001'";

    }
}
