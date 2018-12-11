using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoIt;

namespace LibaryAIS3Windows.ReadWindow.Read
{
    /// <summary>
    /// Класс для считывания значений с Формы
    /// </summary>
   public class Reades
    {
        /// <summary>
        /// Функция считывает данные с активного поданного контрола 
        /// </summary>
        /// <param name="element">Наш контол Название ,идентификатор Name</param>
        /// <returns></returns>
        public static string ReadForm(string[] element)
        {
            string parametr = null;
            while (true)
            {
                if (String.IsNullOrWhiteSpace(parametr))
                {
                    AutoItX.ControlFocus(element[0], "", element[1]);
                    AutoItX.Sleep(500);
                    AutoItX.Send(ButtonsClikcs.ButtonConstant.CtrlC);
                    AutoItX.Send(ButtonsClikcs.ButtonConstant.CtrlC);
                    parametr = AutoItX.ClipGet();
                }
                else
                {
                    AutoItX.ClipPut(null);
                    break;
                }
            }
            AutoItX.ClipPut(""); //Очистка буфера обмена
            return parametr;
        }

        /// <summary>
        /// Функция считывает данные с не активного поданного контрола 
        /// </summary>
        /// <param name="element">Наш контол Название ,идентификатор Name</param>
        /// <returns></returns>
        public static string ReadFormNotActiv(string[] element)
        {
            string parametr = null;
            while (true)
            {
                if (String.IsNullOrWhiteSpace(parametr))
                {
                    parametr = AutoIt.AutoItX.ControlGetText(element[0], "", element[1]);
                }
                else
                {
                    break;
                }
            }
            return parametr;
        }

        public static void ClearBuffer()
        {
            while (true)
            {
                if (String.IsNullOrWhiteSpace(AutoItX.ClipGet()))
                {
                    break;
                }
                    AutoItX.ClipPut(null);
            }
        }
    }
}