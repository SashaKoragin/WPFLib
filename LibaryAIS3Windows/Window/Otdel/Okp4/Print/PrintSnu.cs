using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryAIS3Windows.Window.Otdel.Okp4.Print
{
   internal class PrintSnu
    {
        
        /// <summary>
        /// Текст ИНН при обновлении
        /// Константы для ветки 
        /// </summary>
        public static string Inn = "ИНН";
        /// <summary>
        /// В случае отсутствия в ЛК 2
        /// </summary>
        public static string NotLk2 = "Присутствует ЛК2";
        /// <summary>
        /// При успешном формировании СНУ
        /// </summary>
        public static string Woked = "Сформировали СНУ";
        /// <summary>
        /// ИНН по которым нету СНУ
        /// </summary>
        public static string InnNotSnu = "ИНН по которым нету СНУ";
        /// <summary>
        /// Окно нарушения структуры документа
        /// </summary>
        internal static string[] ErrorElectronSys =
        {
            "Формирование даннных для СНУ",
            "Печать невозможна, нарушена  структура  электронного образа документа"
        };
    }
}
