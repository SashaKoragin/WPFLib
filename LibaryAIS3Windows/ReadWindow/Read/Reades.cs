using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryAIS3Windows.ReadWindow.Read
{
    /// <summary>
    /// Класс для считывания значений с Формы
    /// </summary>
   public class Reades
    {
        /// <summary>
        /// Функция считывает данные с любого поданного контрола 
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
                    AutoIt.AutoItX.ControlFocus(element[0], "", element[1]);
                    AutoIt.AutoItX.Sleep(500);
                    AutoIt.AutoItX.Send(ButtonsClikcs.ButtonConstant.CtrlC);
                    AutoIt.AutoItX.Send(ButtonsClikcs.ButtonConstant.CtrlC);
                    parametr = AutoIt.AutoItX.ClipGet();
                }
                else
                {
                    AutoIt.AutoItX.ClipPut(null);
                    break;
                }
            }
            return parametr;
        }
    }
}