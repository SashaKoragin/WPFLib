using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryAIS3Windows.ExitLogica
{
    /// <summary>
    /// Вспомогательный класс значений
    /// </summary>
    public class ExitClass 
    {
        /// <summary>
        /// Признак состояния работаем или нет
        /// </summary>
        public bool IsWork { get; set; }
        /// <summary>
        /// Сбрасываем счетчик
        /// </summary>
        public int IsCount { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public string Stat { get; set; }
    }
}
