using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLibaryIfns.Inventarization.ModelProcedure
{
   public class ModelProcedure
    {
        /// <summary>
        /// Процедура выбора параметров для обработки.
        /// Все основные выборки хранятся на сервере это позволит нам избежать лишних классов на WCF Сервисе
        /// данную процедуру гонять через метод SqlLibaryIfns.SqlZapros.ZaprosSelectParametr.SelectFullParametrSqlReader
        /// </summary>
        public static readonly string ProcedureSelect = "[dbo].[InventarizationCommandWcfToSql] @Id";
        /// <summary>
        /// Параметр процедуры
        /// </summary>
        /// <param name="paramcommand">цифра в виде строки от 1 до n</param>
        /// <returns></returns>
        public static Dictionary<string, string> ParamCommand(string paramcommand)
        {
            return new Dictionary<string, string>() { { "@Id", paramcommand } };
        }

    }
}
