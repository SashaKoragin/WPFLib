using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryAIS3Windows.Mode.Okp4.PrintSnu
{
    internal class PrintSnuControl
    {
        /// <summary>
        /// Расположение ИНН в форме
        /// </summary>
        internal static string[] InnText =
        {
            "АИС Налог-3 ПРОМ ",
            "[NAME:txtN134]"
        };
        /// <summary>
        /// GridTextFocus
        /// Перемещение фокуса на Grid
        /// </summary>
        internal static string[] GridText =
        {
            "АИС Налог-3 ПРОМ ",
            "[NAME:gridData]"
        };
    }
}
