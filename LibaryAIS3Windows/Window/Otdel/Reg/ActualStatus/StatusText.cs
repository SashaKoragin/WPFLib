
namespace LibraryAIS3Windows.Window.Otdel.Reg.ActualStatus
{
   public class StatusText
   {
        public static string FidOk = "Отработали Фид актуальное состояние!!!";
        /// <summary>
        /// Ошибка
        /// </summary>
        public static string FidError = "Невозможно завершить обработку статус 101 был проставлен ранее!!!";
        /// <summary>
        /// Символизирует ФИД лица
        /// </summary>
        public static string FidText = "ФИД";
        /// <summary>
        /// Символизирует ФИД лица
        /// </summary>
        public static string FidTextFace = "ФИД лица";
        /// <summary>
        /// Символизирует Статус сведений о лице в ПОН ИЛ
        /// </summary>
        public static string StateSved = "Статус сведений о лице в ПОН ИЛ";
        /// <summary>
        /// Текст в [NAME:cbDataStatusPonIl] "Исключен из ИЛ"
        /// Исключен
        /// </summary>
        public static string IsklFl = "3";
        /// <summary>
        /// Текст в [NAME:cbDataStatusPonIl] "Включен в ИЛ"
        /// Включен
        /// </summary>
        public static string VkllFl = "1";
        /// <summary>
        /// Текст в [NAME:cbReasonDataStatusPonIl] "Исключено в связи с ошибочным внесением"
        /// </summary>
        public static string IsklFlError = "101";
        /// <summary>
        /// Диалог выхода из системы
        /// </summary>
       public static string[] DialogWin =
       {
           "Информация",
           "Операция успешно выполнена"
       };
        /// <summary>
        ///В случае ошибки отсутствует статус 101
        /// </summary>
        public static string[] ErrorStateWin =
       {
           "Непредвиденная ситуация",
           "При выполнении сервисной операции произошла ошибка!"
       };
    }
}
