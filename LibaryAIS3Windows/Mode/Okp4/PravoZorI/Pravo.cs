using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryAIS3Windows.Mode.Okp4.PravoZorI
{
   internal class Pravo
   {
      
       /// <summary>
       /// Control Дата документа основания
       /// </summary>
       internal static string EditDate = "[NAME:teDataACT]";

        /// <summary>
        /// Control Номер документа основания
        /// </summary>
        internal static string[] EditNum =
        {
            "",
            "[NAME:teNumACT]"
        } ;

        /// <summary>
        /// Выборвида документа из перечня документов
        /// </summary>
        public static string[] ComboboxEdit =
        {
            "",
            "[NAME:teVIDDOCBASE]"
        };

        /// <summary>
        /// Нажатие Ок завершаем операцию 
        /// </summary>
       public static string[] ButtonOk =
       {
           "ОК",
           "[NAME:ultraButton1]"
       };
   }
}
