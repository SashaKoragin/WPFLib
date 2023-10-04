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

        public static string GenerateAtributeIdIden(string idIden)
        {
            return String.Format("/VisualIdent/IdZapros[@VisualId =\"{0}\"]", idIden);
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
        /// <summary>
        /// Данный метод генерит Атрибут для поиска в xml для схемы FaceFid.xsd
        /// </summary>
        /// <param name="fid">ФИД</param>
        /// <returns>Сгенерированую строку для поиска Атрибута</returns>
        public static string GenerateAtributeFaceFid(string fid)
        {
            return String.Format("/Face/Fid[@FidFace =\"{0}\"]", fid);
        }

        /// <summary>
        /// Удаление атрибута по ИНН TaxArrears
        /// </summary>
        /// <param name="inn">ИНН</param>
        /// <returns></returns>
        public static string GenerateAtrAutoGenerateSchemes(string inn)
        {
            return String.Format("/AutoGenerateSchemes/TaxArrears[@Inn =\"{0}\"]", inn);
        }
        /// <summary>
        /// Удаление атрибута по ИНН TaxArrears
        /// </summary>
        /// <param name="inn">ИНН</param>
        /// <returns></returns>
        public static string GenerateAtrAutoGenerateSchemesAct(string inn)
        {
            return String.Format("/AutoGenerateSchemes/JudicialAct[@Inn =\"{0}\"]", inn);
        }
        /// <summary>
        /// Удаление атрибута по ИНН FaceStatement
        /// </summary>
        /// <param name="inn">ИНН</param>
        /// <returns></returns>
        public static string GenerateAtrAutoGenerateSchemesFaceStatement(string inn)
        {
            return String.Format("/AutoGenerateSchemes/FaceStatement[@Inn =\"{0}\"]", inn);
        }
        /// <summary>
        /// Шаблон удаления платежа
        /// </summary>
        /// <param name="number">Номер платежа</param>
        /// <returns></returns>
        public static string GenerateAtrAutoGenerateSchemesIncomeJournal(int number)
        {
            return String.Format("/AutoGenerateSchemes/IncomeJournal[@Number =\"{0}\"]", number);
        }
        /// <summary>
        /// Удаление атрибута по ФИДУ AddressModel
        /// </summary>
        /// <param name="fid">ИНН</param>
        /// <returns></returns>
        public static string GenerateAtrAutoGenerateSchemesDeleteFid(string fid)
        {
            return String.Format("/AutoGenerateSchemes/AddressModel[@Fid =\"{0}\"]", fid);
        }
        /// <summary>
        /// Удаление Id из журнала
        /// </summary>
        /// <param name="id">Ун входящего документа</param>
        /// <returns></returns>
        public static string GenerateAtrAutoGenerateSchemesDeleteIdDoc(string id)
        {
            return String.Format("/AutoGenerateSchemes/IdentytiFace[@Id =\"{0}\"]", id);
        }
        /// <summary>
        /// Поиск и удаление ИНН из списка
        /// </summary>
        /// <param name="inn">ИНН</param>
        /// <returns></returns>
        public static string GenerateAtrAutoGenerateSchemesDeleteIdDocInn(string inn)
        {
            return String.Format("/AutoGenerateSchemes/InnFace[@Inn =\"{0}\"]", inn);
        }
    }

}
