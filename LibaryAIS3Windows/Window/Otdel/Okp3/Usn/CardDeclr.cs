using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryAIS3Windows.Window.Otdel.Okp3.Usn
{
   public class CardDeclr
   {
       /// <summary>
       /// Учетный номер
       /// </summary>
       public string IdDec { get; set; } = null;

        /// <summary>
        /// Рег номер
        /// </summary>
        public string Id { get; set; } = null;
        /// <summary>
        /// Ошибка
        /// </summary>
        public string Error { get; set; } = null;

        /// <summary>
        /// Описание ошибки
        /// </summary>
        public string DescriptionError { get; set; } = null;

    }
}
