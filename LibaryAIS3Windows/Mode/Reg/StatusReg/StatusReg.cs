using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryAIS3Windows.Mode.Reg.StatusReg
{
   public class StatusReg
    {
        /// <summary>
        /// Выпадающий список в изменении статуса лица
        /// Перемещение фокуса на ComboBox
        /// </summary>
        internal static string[] ComboBox =
        {
            "",
            "[NAME:cbDataStatusPonIl]"
        };
        /// <summary>
        /// Выпадающий список причина установки статуса
        /// Перемещение фокуса на ComboBox1
        /// </summary>
        internal static string[] ComboBox1 =
        {
            "",
            "[NAME:cbReasonDataStatusPonIl]"
        };

        /// <summary>
        /// Дата установки статуса
        /// Перемещение фокуса на DateStatus
        /// </summary>
        internal static string[] DateStatus =
        {
            "",
            "[NAME:dtpDataStatus]"
        };
        /// <summary>
        /// Дата подтверждения актуальности
        /// Перемещение фокуса на DateActual
        /// </summary>
        internal static string[] DateActual =
        {
            "",
            "[NAME:dtDateActual]"
        };
        /// <summary>
        /// Выбрать
        /// Перемещение фокуса на ButtonSelect
        /// </summary>
        internal static string[] ButtonSelect =
        {
            "Выбрать",
            "[NAME:ubApply]"
        };

    }
}
