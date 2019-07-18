using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryAIS3Windows.Window.Otdel.Okp3.Usn
{
   public class UsnText
    {

        /// <summary>
        /// Текст окна хоста проверки
        /// </summary>
        public static string ElemHost = "elementHost1";
        /// <summary>
        /// Титульный лист
        /// </summary>
        public static string TitleUsn = "Титульный лист";

        /// <summary>
        /// Ввод входящего элемента
        /// </summary>
        public static string[] VvodVxod =
        {
            "Подтвердить ввод входящего документа",
            "Вы уверены, что обработка входящего документа закончена? После выполнения операции редактирование документа будет невозможным.",
        };
        /// <summary>
        /// Отложить пользовательское задание
        /// </summary>
        public static string[] UserWork =
        {
            "Завершение работы с пользовательским заданием",
            "Пользовательское задание не завершено и будет отложено",
        };


        public static string[] WinSnr =
        {
            "АИС Налог-3 ПРОМ ",
            "elementHost1",
            "[Text:elementHost1]"
        };
        /// <summary>
        /// Открытие пользовательского задания
        /// </summary>
        public int IsOpen { get; set; }
        /// <summary>
        /// Ввод завершен
        /// </summary>
        public int Sender { get; set; }
        /// <summary>
        /// Финиш
        /// </summary>
        public int Finish { get; set; }

        public void Coordinate(bool isCoordinate)
        {
            if (isCoordinate)
            {
                IsOpen = 480;
                Sender = 258;
                Finish = 238;
            }
            else
            {
                IsOpen = 580;
                Sender = 283;
                Finish = 260;
            }
        }
    }
}
