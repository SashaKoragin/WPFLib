using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
namespace LibaryAIS3Windows.Function.PublicFunc
{
  public class PublicFunc
    {
        /// <summary>
        /// Статическая функция делающая вывод что не попало на обработку
        /// </summary>
        /// <param name="list">Лист со значениями</param>
        /// <param name="str">Строка разделенная "/"</param>
        /// <returns>Возвращает элементы которых нету!!!</returns>
        public static string NotArray(List<string> list, string str)
        {
            List<string> listnew= new List<string>(Regex.Split(str, @"/"));
            return String.Join("/", listnew.Except(list).ToList());
        }
    }
}
