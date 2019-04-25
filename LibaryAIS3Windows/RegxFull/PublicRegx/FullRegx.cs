using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LibaryAIS3Windows.RegxFull.PublicRegx
{
    /// <summary>
    /// Класс с регулярными выражениями 
    /// </summary>
   public class FullRegx
    {
        /// <summary>
        /// Регулярное выражение парсинга строки "Расчетный документ. Номер:7150733343497 Дата:06.02.2019 Сумма:5000223,00"
        /// </summary>
        public string RegxRasch = @"(Расчетный документ. \w+:\d+\s\w+:\d{2}.\d{2}.\d{4}\s\w+:\d+(,|.)\d{2}?)";
        /// <summary>
        /// Парсим распределение платежа
        /// </summary>
        public string RaspredPl = @"(Распределение платежа УФК. \w+:\d+\s\w+:\d+)";
        /// <summary>
        /// Платеж
        /// </summary>
        public string Platej = @"(Платеж. \w+\s\w+:\d+\s\w+\s\w+:\d+\s\w+:\d+\s\w+:\d+)";
        /// <summary>
        /// Парсинг Кбк
        /// </summary>
        public string Kbk = @"(\d{20})";
        /// <summary>
        /// Плательщик
        /// </summary>
        public string Platelsik = @"(Плательщик. \w+:\d+\s\w+:\d+)";
        /// <summary>
        /// ИНН грязный
        /// </summary>
        public string Inn = @"(ИНН:\d+)";
        /// <summary>
        /// Вытаскиваем чисто числа
        /// </summary>
        public string Number = @"(\d+)";
        /// <summary>
        /// КПП
        /// </summary>
        public string Kpp = @"(КПП:\d+)";
        /// <summary>
        /// Парсим ОКТМО по распределению
        /// </summary>
        public string Oktmo = @"(ОКТМО:\d+)";
        /// <summary>
        /// Парсинг ТП
        /// </summary>
        public string Tp = @"((\n0\n)|(\nТП\n)|(\nТР\n))";
    }
}
