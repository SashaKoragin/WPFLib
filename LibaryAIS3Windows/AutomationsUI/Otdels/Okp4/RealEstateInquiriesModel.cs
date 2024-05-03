using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAIS3Windows.AutomationsUI.Otdels.Okp4
{
    public class RealEstateInquiriesModel
    {
        /// <summary>
        /// Режимы
        /// </summary>
        public static string StartProcess = "Name:DockTop\\Name:Ribbon\\Name:Собственность\\Name:Дополнительно\\Name:Режимы";

        /// <summary>
        /// Глобальное окно
        /// </summary>
        private static string GlobalWin = "Name:Сформировать уточняющий запрос по СМЭВ в органы Росреестра по Кадастровому номеру\\";

        /// <summary>
        /// Поле ввода кадастрового номера
        /// </summary>
        public static string MemoNumber = $"{GlobalWin}AutomationId:VP_D942_TextEditor\\LocalizedControlType:поле";
        /// <summary>
        /// Раскрыть список
        /// </summary>
        public static string ComboBox = $"{GlobalWin}AutomationId:VP_TYPE_OBJ_ComboEditor\\Name:Open";
        /// <summary>
        /// Список ComboBox
        /// </summary>
        public static string List = $"{GlobalWin}LocalizedControlType:панель\\LocalizedControlType:список";
        /// <summary>
        /// Запрос о переходе прав
        /// </summary>
        public static string CheckPassport = $"{GlobalWin}AutomationId:VP_Q3\\Name:Запрос в Росреестр/ЕГРП/ по объекту на предоставление «Выписка о переходе прав объекта»";
        /// <summary>
        /// Сформировать запрос в рос реестр
        /// </summary>
        public static string ButtonStartSender = $"{GlobalWin}Name:Сформировать выбранные типы запросов по введенному КН";
        /// <summary>
        /// Окно что все Ок
        /// </summary>
        public static string WinOk = $"{GlobalWin}Name:Информация\\Name:ОК";
        /// <summary>
        /// Кнопка закрыть дочернее окно
        /// </summary>
        public static string Closed = $"{GlobalWin}AutomationId:TitleBar\\Name:Закрыть";
    }
}
