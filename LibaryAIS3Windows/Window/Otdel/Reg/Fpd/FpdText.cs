﻿using System.Drawing;
using AutoIt;

namespace LibraryAIS3Windows.Window.Otdel.Reg.Fpd
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
        /// Условие 1 которое ищим
        /// </summary>
        internal static string TextUslovie = "Лицо не найдено в ФБД ЕГРН (ПОН ИЛ/ витрине лиц ЦУН), проводятся уточняющие мероприятия";
        /// <summary>
        /// Условие 2 которое ищем
        /// </summary>
        internal static string Text11 = "Документ ФПД требует повторной обработки по итогам выполненных уточняющих мероприятий по определению лица";
        /// <summary>
        /// Условие 3 которое ищем
        /// </summary>
        internal static string Text4 = "Обнаружены критичные ошибки ФЛК 2-го уровня в сведениях об объекте  или правах";
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
