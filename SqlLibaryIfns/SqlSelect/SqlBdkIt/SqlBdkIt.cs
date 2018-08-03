using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLibaryIfns.SqlSelect.SqlBdkIt
{
   public class SqlBdkIt
   {
        /// <summary>
        /// Выборка для Xlxs отчета!!!
        /// </summary>
       public static string SelectXlsx = @"Select Idtable as 'Уникальный номер',
                                                  DbName_1 as 'Имя контейнера',
                                                  VerConteiner_1 as 'Версия контейнера',
                                                  RUS_1 as 'КЛС',
                                                  N279_1 as 'Инспекция',
                                                  D2702_1 as 'Наименование инспекции',
                                                  Viddela_1 as 'Вид дела',
                                                  D3970 as 'Ун дела в БДК',
                                                  D09 as 'Вид дела справочник',
                                                  D41 as 'Дата приема',
                                                  N279_2 as 'Код участка',
                                                  N1 as 'Ун плательщика в контейнере',
                                                  N134 as 'ИНН',
                                                  D3 as 'КПП',
                                                  N1002 as 'ОГРН',
                                                  N18 as 'Наименование плательщика',
                                                  idanalis as 'Ун сообщения анализа',
                                                  MessageError as 'Сообщения анализа',
                                                  DataError as 'Дата сообщения анализа',
                                                  idok as 'Ун сообщения обработки',
                                                  MessageOk as 'Сообщение Ок',
                                                  DataOk as 'Ун сообщения Ок',
                                                  NumDelo as 'Ун дела в БД'
                                           From AhalisBdk
                                           Order by idanalis";
       /// <summary>
       /// Анализ БДК до и после выполнения процесса анализа
       /// и данные после загрузки
       /// </summary>
        public static string SelectAnalisBdk = @"Select * From AhalisBdk Order by idanalis FOR XML AUTO,ROOT('AnalisBdkFull')";
        /// <summary>
        /// Предворительный анализ БДК
        /// </summary>
       public static string StartAnalis = "AddAnalizBdkFull";
        /// <summary>
        /// Запуск БДК с предворительным анализом
        /// </summary>
       public static string StartBdk = "StartBdk";
   }
}
