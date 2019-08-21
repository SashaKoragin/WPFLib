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
        /// <summary>
        /// Поле ФИД
        /// </summary>
        public static string[] FidMemo =
        {
            "АИС Налог-3 ПРОМ ",
            "[NAME:fidTE]"
        };

        /// <summary>
        /// Поле ИНН
        /// </summary>
        public static string[] InnMemo =
        {
            "АИС Налог-3 ПРОМ ",
            "[NAME:innTE]"
        };

        /// <summary>
        /// Поле КПП
        /// </summary>
        public static string[] KppMemo =
        {
            "АИС Налог-3 ПРОМ ",
            "[NAME:kppTE]"
        };

        /// <summary>
        /// Наименование организации
        /// </summary>
        public static string[] NameOrganization =
        {
            "АИС Налог-3 ПРОМ ",
            "[NAME:txtTP_NAME]"
        };

        /// <summary>
        /// Определение приема или передачи
        /// </summary>
        public static string[] PeredachaOrPriem =
        {
            "АИС Налог-3 ПРОМ ",
            "НО передающий данные"
        };

        /// <summary>
        /// Налоговая передающая данные
        /// </summary>
        public static string[] CodeIfnsPeredacha =
        {
            "АИС Налог-3 ПРОМ ",
            "[NAME:txtIFNS_SENDER]"
        };

        /// <summary>
        /// Налоговая пренимающая данные
        /// </summary>
        public static string[] CodeIfnsPriem =
        {
            "АИС Налог-3 ПРОМ ",
            "[NAME:txtIFNS_RECEIVER]"
        };

    }
}
