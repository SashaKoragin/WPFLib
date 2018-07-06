using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text;
using System.Threading.Tasks;

namespace SqlLibaryIfns.SqlSelect.SqlReshenia
{
   public class ProcedureReshenie
   {
        /// <summary>
        /// Главная выборка отбора Требований по которым нет Решений и Инкассовых поручений
        /// </summary>
       public static readonly string SqlFullTreb = @"Select doc.D865 as 'Ун решения',
                                                         doc.D270 as 'Системный номер',
                                                         doc.N1 as 'Ун плательщика',
                                                         doc.Остаток as 'Остаток',
                                                         doc.D851 as 'Ун документа к управленческому решению',
                                                         doc.D850 as 'Ун дела ГНИ',
                                                         doc.D430 as 'Ун вида документа',
                                                         doc.N120 as 'Ун валюты',
                                                         doc.D1967 as 'Срок исполнения Налог обяз',
                                                         doc.colday as 'Колличество дней' --Не должно превышать 365 дней просрочки
                                                   From (Select fn1596.d865,fn1517.D270, fn1577.N1, sum (fn1500.d512) as 'Остаток', FN1016.D82,fn1517.D851,fn1517.D850,FN1016.D81,FN1016.D430,FN1519.N120,FN1517.D1967,fn1517.D09,DATEDIFF(day, dateadd(day, isnull(fn1044.d2320,0)-1, FN1517.D1967), getdate()) as colday From Fn1500  --fn1182.D81,fn1016.D82,fn1016.D146,
                                                Left join fn1596 (nolock) on fn1500.d307 = fn1596.d307
                                                Left Join fn1517 on fn1517.d865 =fn1596.D865
                                                Left join fn1577 (nolock) on fn1517.d850 = fn1577.d850
                                                Left Join FN1519 (nolock) on fn1519.D850 = fn1577.D850
                                                Left Join fn1182 on fn1596.d865 =  fn1182.D865
                                                Left Join FN1016 on FN1016.D81 = fn1182.D81
                                                CROSS JOIN fn1044 (nolock)
                                                      Where  fn1182.D81 in (1353,1352, 1353, 1355, 2426, 2427, 2428, 2767) and fn1517.D09_6 <>2  --Документ требование на уплату пени и признак fn1517.D09_6 <>2 не физическое лицо
                                                           group by fn1596.d865,fn1577.N1, fn1517.D270,FN1016.D82,fn1517.D851,fn1517.D850,FN1016.D81,FN1016.D430,FN1519.N120,FN1517.D1967,fn1517.D09,fn1044.D2320
                                                      HAVING sum (fn1500.d512) > 0.00) doc 
                                                join (select distinct fn212.n1,fn212.N18 from fn212 (nolock)
                                                join fn1577 (nolock) on fn1577.n1 = fn212.n1
                                                join fn1517 (nolock) on fn1517.d850 = fn1577.d850
                                                join fn1016 (nolock) on fn1016.d81 = fn1517.d81
                                              where fn1016.d430 = 1354 --Документ выявление недоимки отбор лиц у кого есть нарушение
                                                    and DateDiff(Day, DateAdd(Year, -3, GetDate()), fn1517.d87) > 0 and fn212.D428 not in (380, 381) --Лица не в состоянии передачи 
                                              group by fn212.n1,fn212.N18
                                                having count(fn1517.d851) > 0) Face on Face.N1 = doc.N1
                                               Left join vGetFLActionType_2 v2 on v2.n1=Face.N1
                                               Left Join (Select fn1517.d851_2, fn1517.d87, fn1517.d851,fn1016.d430,fn1517.d270 From fn1517 (nolock)
                                                    join fn1016 (nolock) on fn1016.d81 = fn1517.d81) a on a.D851_2 = doc.D851
                                             Where a.D851_2 is NULL  and doc.D09<>1 and doc.D1967<GETDATE() and doc.colday<365 and doc.colday>-45 --and doc.D270 =116718895 --and cash.N1 is Null  and doc.D270 =116718895--IsBusinessman ИП или не ИП --Удаление фиктивных D09";

        /// <summary>
        /// Выборка отработаных решений и инкассовых поручений!!!
        /// </summary>
       public static readonly string SelectReshenie = @"Select * From TableSysNumReshen
                                                        Left Join Reshenie on Reshenie.D270=TableSysNumReshen.D270
                                                        Left Join Incass on Incass.D851Res_1 = Reshenie.D851Res FOR XML AUTO,ROOT('SysNum')";
        /// <summary>
        /// Процедура AddTreb
        /// </summary>
        public static readonly string ProcedureAddTreb = "AddReshenie";
        /// <summary>
        /// Процедура StartTreb
        /// </summary>
        public static readonly string ProcedureStartTreb = "StartReshenie";
        /// <summary>
        /// Процедура StartIncass
        /// </summary>
        public static readonly string ProcedureStartIncass = "StartIncass";
    }
}
