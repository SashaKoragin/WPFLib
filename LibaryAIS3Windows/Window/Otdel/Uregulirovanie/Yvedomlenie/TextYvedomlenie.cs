using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoIt;

namespace LibaryAIS3Windows.Window.Otdel.Reg.Yvedomlenie
{
    /// <summary>
    /// В данном классе используется текст окон относя щихся к режиму в пользовательских заданиях
    /// Физические лица/1.08. Сообщение ФЛ об объектах собственности\Уточнение сведений о ФЛ
    /// </summary>
   internal class TextYvedomlenie
    {
        /// <summary>
        /// Переменная символизирует слово ФИД 
        /// </summary>
        internal static string TextFid = "ФИД";
        /// <summary>
        /// Переменная символизирует слово ФИД лица
        /// </summary>
        internal static string TextFidUser = "ФИД лица";
        /// <summary>
        /// Визуальная идентификация ФЛ по ЦУН в пользовательских заданиях
        /// </summary>
        internal static string VisualVindow = "Визуальная идентификация ФЛ по ЦУН";
        /// <summary>
        /// Текст обновить
        /// </summary>
        internal static string UpdateText = "Обновить";
        /// <summary>
        /// Считать позицию Общего окна АИС 3
        /// </summary>
        internal Rectangle WindowsIdentification = AutoItX.WinGetPos(VisualVindow);
        /// <summary>
        /// Окно визуальная идентификация фид
        /// </summary>
        internal Rectangle WinVisualIdentification = AutoItX.ControlGetPos("Визуальная идентификация ФЛ по ЦУН", "", "[NAME:gridConditions]");
    }
}
