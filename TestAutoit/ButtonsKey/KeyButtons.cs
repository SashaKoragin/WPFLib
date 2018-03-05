using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestAutoit.Window;

namespace TestAutoit.ButtonsKey
{
    /// <summary>
    /// Класс для манипуляции состояния кнопок и Горячих клавиш
    /// </summary>
   internal class KeyButtons
   {
        /// <summary>
        /// Переменная символизирует остановку автомата 
        /// </summary>
       internal static bool IsWork = true;
        /// <summary>
        /// Колличество отработаных записей нужна для вывода сколько сделали
        /// </summary>
       internal static int IsCount = 0;
        /// <summary>
        /// Горячии клавиши на форме 
        /// Esc Остановка
        /// Tab Продолжить запустить
        /// </summary>
        /// <param name="e">Аргументы клавиатуры</param>
        /// <param name="button">Наша кнопка для манипулировании состояний</param>
       public void Button(KeyEventArgs e,Button button)
       {
           switch (e.KeyCode)
           {
                case Keys.Escape:
                   IsWork = false;
                   StatusButtonYellow(button);
                   break;
                case Keys.Tab:
                   IsWork = true;
                   StatusButtonGrin(button);
                    break;
           }
       }
        /// <summary>
        /// Кнопка принимает состояние Red не может нажиматься во время работы автомата
        /// </summary>
        /// <param name="button">Кнопка от разных источников</param>
        internal static void StatusButtonRed(Button button)
        {
            button?.BeginInvoke((Action) (delegate
            {
                button.BackColor = System.Drawing.Color.Red;
                button.Text = @"Работаем!!!";
                button.Enabled = false;
            }));

        }
        /// <summary>
        /// Кнопка принимает состояние Grin штатное положение кнопки
        /// </summary>
        /// <param name="button">Кнопка от разных источников</param>
        internal static void StatusButtonGrin(Button button)
        {
            button?.BeginInvoke((Action) (delegate
            {
                button.BackColor = System.Drawing.Color.Lime;
                button.Text = @"Старт автомат!!!";
                button.Enabled = true;
            }));
        }
        /// <summary>
        /// Кнопка принимает состояние Yellow приостановлено кнопка не нажимается
        /// </summary>
        /// <param name="button">Кнопка от разных источников</param>
        internal static void StatusButtonYellow(Button button)
       {
           button?.BeginInvoke((Action) ((delegate
           {
               button.BackColor = System.Drawing.Color.Yellow;
               button.Text = @"Приостановлено!!!";
               button.Enabled = false;
           })));

       }
        /// <summary>
        /// Событие состояние когда закончили а когда приостановили вручную
        /// </summary>
        /// <param name="button">Наша кнопка</param>
        /// <param name="status">Статус на остановку или приостановление</param>
       internal static void StatusGrinandRed(Button button, string status)
       {
           if (status != "stop")
               StatusButtonGrin(button);
           else
               StatusButtonYellow(button);
       }
    }
}
