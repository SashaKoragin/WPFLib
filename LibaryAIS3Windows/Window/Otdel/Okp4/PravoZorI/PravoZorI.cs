using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryAIS3Windows.Window.Otdel.Okp4.PravoZorI
{
    /// <summary>
    /// Класс описывает разный текст в ветки 
    /// Налоговое администрирование\Собственность\02. Доопределение данных об объектах собственности\14. КС – Корректировка сведений о правах не зарегистрированных  в органах Росреестра и правах наследования на ОН и ЗУ
    /// </summary>
    internal class PravoZorI
    {
        /// <summary>
        /// Текст Фид для окна
        /// </summary>
        public static string Fid = "ФИД факта владения";

        /// <summary>
        /// Окно Внимание!!!
        /// </summary>
        public static string WinTitle = "Внимание";

        /// <summary>
        /// Заголовок удаление сведений
        /// </summary>
        public static string WinRemoveSved = "Удаление сведений о зарегистрированных правах";
        
        /// <summary>
        /// Ошибка не возможности корректировки
        /// </summary>
        public static string ErrorText = "По выбранному факту владения отсутствуют сведения о правах. Выполнение режима корректировки/удаления невозможно.";

        /// <summary>
        /// Ошибка не существует других записей
        /// </summary>
        public static string ErrorText2 = "Удаление невозможно. В ПОН КС по рассматриваемому ФИДу не существует других записей о правах. При необходимости выполните аннулирование факта владения";

        /// <summary>
        /// Записи успешно удалены
        /// </summary>
        public static string OkDelete = "Записи  успешно удалены из ПОН КС ФБД";

        /// <summary>
        /// Текст на окне Особые отметки
        /// </summary>
        public static string Exlusive = "Особые отметки";
        /// <summary>
        /// Номер документа основания для вставки
        /// </summary>
        public static string EditString = "1";
    }
}
