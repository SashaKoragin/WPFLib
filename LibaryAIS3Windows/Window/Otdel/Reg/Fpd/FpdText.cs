using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoIt;

namespace LibaryAIS3Windows.Window.Otdel.Reg.Fpd
{
   public class FpdText
   {
        /// <summary>
        /// Текст Идентификация выполнена.
        /// </summary>
        internal static string TextOk = "Идентификация выполнена.";
        /// <summary>
        /// Текст Внимание
        /// </summary>
        internal static string TextVnimanie = "Внимание";
        /// <summary>
        /// Текст Ун фл в ЕГРН
        /// </summary>
        internal static string TextUnfl = "УН ФЛ в ЕГРН";
        /// <summary>
        /// Переменная символизирует слово ФИД лица
        /// </summary>
        internal static string TextFidUser = "ФИД лица";
        /// <summary>
        /// Условие которое ищим
        /// </summary>
        internal static string TextUslovie = "Лицо не найдено в ФБД ЕГРН (ПОН ИЛ/ витрине лиц ЦУН), проводятся уточняющие мероприятия";
        /// <summary>
        /// Окно ЦУН
        /// </summary>
        internal static string TextCun = "Поиск лица по заданным параметрам в Витрине лиц ЦУН";
        /// <summary>
        /// Панель инструментов Выбрать ФЛ Обновить
        /// </summary>
        internal Rectangle WinVisualTool = AutoItX.ControlGetPos("АИС Налог-3 ПРОМ ", "", "[NAME:toolStrip3]");
        /// <summary>
        /// Позиция Conditions в обработке ответов на запрос
        /// </summary>
        internal Rectangle WinVisualPageControl = AutoItX.ControlGetPos("АИС Налог-3 ПРОМ ", "", "[NAME:ultraTabPageControl1]");
        /// <summary>
        /// Считываем окно Аис 3
        /// </summary>
        internal Rectangle WinCoordinat = AutoItX.WinGetPos("АИС Налог-3 ПРОМ ", "");
        /// <summary>
        /// Окно запрос на визуальную идентификацию
        /// </summary>
        internal static string TextIdent = "Запрос на визуальную идентификацию отсутствует.";

    }
}
