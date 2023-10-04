using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfDatabaseAutomation.Automation.BaseLogica.ReturnModelError
{
    public class ModelErrorInterrogationOfWitnesses
    {
        /// <summary>
        /// Наименование файла и т.п.
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// ИНН где случилась ошибка
        /// </summary>
        public string Inn { get; set; }

        /// <summary>
        /// Сообщение об ошибке
        /// </summary>
        public string MessagesError { get; set; }

    }
}
