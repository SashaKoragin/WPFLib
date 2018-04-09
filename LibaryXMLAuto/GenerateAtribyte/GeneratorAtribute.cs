using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryXMLAuto.GenerateAtribyte
{
    /// <summary>
    /// Класс для генерации атрибутов для разных целей
    /// </summary>
   public class GeneratorAtribute
    {
        /// <summary>
        /// Данный клас генерит Атрибут для поиска в xml для схемы SnuOneForm.xsd
        /// </summary>
        /// <param name="inn">ИНН</param>
        /// <returns>Сгенерированую строку для поиска Атрибута</returns>
        public static string GenerateAtributeInn(string inn)
        {
            return String.Format("/SnuOneForm/INN[@INN =\"{0}\"]",inn);
        }

        /// <summary>
        /// Данный клас генерит Атрибут для поиска в xml для схемы SnuOneForm.xsd
        /// </summary>
        /// <param name="fpd">ИНН</param>
        /// <returns>Сгенерированую строку для поиска Атрибута</returns>
        public static string GenerateAtributeFpd(string fpd)
        {
            return String.Format("/TreatmentFPD/Fpd[@FpdId =\"{0}\"]", fpd);
        }

    }
}
