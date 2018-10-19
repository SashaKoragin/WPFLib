namespace SqlLibaryIfns.SqlSelect.SqlLk2
{
   public class SelectSqlLk2
    {
        /// <summary>
        /// Отбор есть ли у пользователя Личный кабинет или нет
        /// </summary>
        public string Lk2 = @"SELECT TOP 1 case when isnull(a.N279,'') = FN1044.N279 then 10 else 7 end,case when isnull(FN211.N608,'') <> '' then 1 else 7 end,case when FN212_LK2.N2296 = 1 then 10 else 7 end,FN212_LK2.N1,a.N134,FN211.N146,FN211.N142,FN211.N610,FN98.N236,FN211.N148,FN211.N147,FN211.N149,FN211.N150,a.N279,FN213.N320,FN212_LK2.D40,FN212_LK2.D41,case when FN212_LK2.N2296 = 1 then 'да' else 'нет' end FROM FN212_LK2
                               join FN211 on fn212_LK2.N1 = FN211.N1
                               left join FN212 a on  a.N1 = FN211.N1
                               left join FN213 on a.N314 = FN213.N314
                               left join FN98 on FN211.N235 = FN98.N235,
                              FN1044 WHERE ( FN212_LK2.N1 > 0) AND((a.N134 ='{0}'))";
    }
}
