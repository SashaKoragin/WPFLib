using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutoit.Constantsfile
{
    /// <summary>
    /// Константы пути к файлам
    /// </summary>
   public class ConstantFile
   {
        /// <summary>
        /// Путь к файлу ИНН по схеме SnuOneForm.xsd
        /// </summary>
        public static string FileInn = @"XmlFile/Inn.xml";
        /// <summary>
        /// Путь к файлу Журналу ошибок по схеме ErrorJurnal.xsd
        /// </summary>
        public static string FileJurnalError = @"XmlJurnal/InnError.xml";
        /// <summary>
        /// Путь к файлу Журналу отрабтаных по схеме OkJurnal.xsd
        /// </summary>
        public static string FileJurnalOk = @"XmlJurnal/InnOk.xml";
    }
}
