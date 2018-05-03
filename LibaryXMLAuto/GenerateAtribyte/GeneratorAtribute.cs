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
        /// Данный метод генерит Атрибут для поиска в xml для схемы FullInnCount.xsd
        /// </summary>
        /// <param name="numcollection">Коллекция ИНН через слеш</param>
        /// <returns>Сгенерированую строку для поиска Атрибута</returns>
        public static string GenerateAtributeMassNumCollection(string numcollection)
        {
            return String.Format("/INNList/ListInn[@NumColection =\"{0}\"]", numcollection);
        }

        /// <summary>
        /// Данный метод генерит Атрибут для поиска в xml для схемы FpdReg.xsd
        /// </summary>
        /// <param name="fpd">ИНН</param>
        /// <returns>Сгенерированую строку для поиска Атрибута</returns>
        public static string GenerateAtributeFpd(string fpd)
        {
            return String.Format("/TreatmentFPD/Fpd[@FpdId =\"{0}\"]", fpd);
        }

        /// <summary>
        /// Данный метод генерит Атрибут для поиска в xml для схемы FidZemlyOrImushestvo.xsd
        /// </summary>
        /// <param name="fid">ФИД</param>
        /// <returns>Сгенерированую строку для поиска Атрибута</returns>
        public static string GenerateAtributeFid(string fid)
        {
            return String.Format("/FidFactZemlyOrImushestvo/Fid[@FidZemlyOrImushestvo =\"{0}\"]", fid);
        }
    }
}
