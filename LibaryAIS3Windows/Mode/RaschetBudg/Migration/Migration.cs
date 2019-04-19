using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryAIS3Windows.Mode.RaschetBudg.Migration
{
   public class Migration
    {

        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        internal static string[] Identity =
        {
            "АИС Налог-3 ПРОМ ",
            "[NAME:txtID]"
        };
        /// <summary>
        /// Текст миграция НП
        /// </summary>
        public static string MigrationNp = "Тип:";
        /// <summary>
        /// Команда ControlCommand Работает по Handle
        /// </summary>
        public static string[] Button =
       {
            "АИС Налог-3 ПРОМ ",
            "Разблокировать",
            "[NAME:unlockButton]"
       };
    }
}
