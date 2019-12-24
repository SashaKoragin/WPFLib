using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LibaryAIS3Windows.RegxFull.PublicRegx
{
    /// <summary>
    /// Класс с регулярными выражениями 
    /// </summary>
   public class FullRegx
    {
        /// <summary>
        /// Парсинг ТП
        /// </summary>
        public string Tp = @"((\n0\n)|(\nТП\n)|(\nТР\n))";
    }
}
