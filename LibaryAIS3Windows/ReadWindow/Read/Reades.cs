using System;
using AutoIt;

namespace LibraryAIS3Windows.ReadWindow.Read
{
    /// <summary>
    /// Класс для считывания значений с Формы
    /// </summary>
   public class Reades
    {
        /// <summary>
        /// Парсинг явной строки преобразование
        /// </summary>
        /// <returns></returns>
        public static string ReadCtrlC()
        {
            string parametr = null;
            ClearBuffer();
            while (true)
            {
                if (String.IsNullOrWhiteSpace(parametr))
                {
                    AutoItX.Send(ButtonsClikcs.ButtonConstant.CtrlC);
                    parametr = AutoItX.ClipGet();
                }
                else
                {
                    break;
                }
            }
            ClearBuffer();
            return parametr;
        }

        /// <summary>
        /// Парсинг не явной строки преобразование
        /// </summary>
        /// <returns></returns>
        public static string ReadCtrlCno()
        {
            string parametr = null;
            ClearBuffer();
            while (true)
            {
                if (parametr==null)
                {
                    AutoItX.Send(ButtonsClikcs.ButtonConstant.CtrlC);
                    parametr = AutoItX.ClipGet();
                }
                else
                {
                    break;
                }
            }
            ClearBuffer();
            return parametr;
        }



        /// <summary>
        /// Функция считывает данные с активного поданного контрола 
        /// </summary>
        /// <param name="element">Наш контол Название ,идентификатор Name если numberbutton>0 то нажимается количество Tabov и парсится
        /// элемент после всех табов от ближайшего element</param>
        /// <param name="numberbutton">Количество нажатий Tab</param>
        /// <returns></returns>
        public static string ReadForm(string[] element,int numberbutton = 0)
        {
            string parametr = null;
            while (true)
            {
                if (String.IsNullOrWhiteSpace(parametr))
                {
                    AutoItX.ControlFocus(element[0], "", element[1]);
                    if (numberbutton > 0)
                    {
                        AutoItX.Send(String.Format(ButtonsClikcs.ButtonConstant.TabCountClick,numberbutton));
                    }
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
                    parametr = AutoItX.ControlGetText(element[0], "", element[1]);
                }
                else
                {
                    break;
                }
            }
            return parametr;
        }
        /// <summary>
        /// Получаем не видимый текст с окна
        /// </summary>
        /// <param name="namewinactive">Наименование заголовка окна</param>
        /// <returns></returns>
        public static string HidenTextReturn(string namewinactive)
        {
            string parametr = null;
            AutoItX.AutoItSetOption("WinDetectHiddenText", 1);
            while (true)
            {
                if (String.IsNullOrWhiteSpace(parametr))
                {
                    parametr = AutoItX.WinGetText(namewinactive, "");
                }
                else
                {
                    break;
                }
            }
            return parametr;
        }

        /// <summary>
        /// Очистка буфера
        /// </summary>
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