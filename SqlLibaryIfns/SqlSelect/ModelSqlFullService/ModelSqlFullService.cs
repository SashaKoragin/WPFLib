using System.Collections.Generic;

namespace SqlLibaryIfns.SqlSelect.ModelSqlFullService
{
   public class ModelSqlFullService
   {
        /// <summary>
        /// Процедура выбора параметров для обработки.
        /// Все основные выборки хранятся на сервере это позволит нам избежать лишних классов на WCF Сервисе
        /// данную процедуру гонять через метод SqlLibaryIfns.SqlZapros.ZaprosSelectParametr.SelectFullParametrSqlReader
        /// </summary>
        public static readonly string ProcedureSelectParametr = "[dbo].[CommandWcfToSql] @Id";
       /// <summary>
       /// Параметр процедуры
       /// </summary>
       /// <param name="paramcommand">цифра в виде строки от 1 до n</param>
       /// <returns></returns>
       public static Dictionary<string,string> ParamCommand(string paramcommand)
       {
           return new Dictionary<string, string>() {{"@Id", paramcommand }};
       }
    }
}
