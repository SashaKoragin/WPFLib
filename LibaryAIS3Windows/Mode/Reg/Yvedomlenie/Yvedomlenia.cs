using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryAIS3Windows.Mode.Reg.Yvedomlenie
{
   internal class Yvedomlenia
    {
        /// <summary>
        /// Расположение Фида в форме
        /// </summary>
        internal static string[] FidText =
        {
            "АИС Налог-3 ПРОМ ",
            "[NAME:txtTpFID]"
        };
        /// <summary>
        /// Кнопка Визуальная идентификация ФЛ
        /// </summary>
        internal static string[] Visual =
        {
            "Визуальная идентификация ФЛ",
            "[NAME:btnIdentificationFL]"
        };
        /// <summary>
        /// Кнопка Обновить в режиме Ветка которую обрабатываем Пользовательзкое задание
        /// </summary>
        internal static string[] Update =
        {
            "Обновить",
            "[NAME:btnRefresh]"
        };
        /// <summary>
        /// Кнопка выбрать
        /// </summary>
        internal static string[] Select =
        {
            "Выбрать",
            "[NAME:btnChoice]"
        };

        /// <summary>
        /// Кнопка закрыть
        /// </summary>
        internal static string[] Close =
        {
            "Закрыть",
            "[NAME:btnClose]"
        };
        /// <summary>
        /// Наш комбо бокс с содержанием режима выбора
        /// </summary>
        internal static string[] ComboboxSelect =
        {
            "",
            "[NAME:cmbD428]"
        };
        /// <summary>
        /// Кнопка сохранить
        /// </summary>
        internal static string[] Save =
        {
            "",
            "[NAME:btnSave]"
        };
    }
}
