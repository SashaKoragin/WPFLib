using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AisPoco.Ifns51.ToAis
{
   public class TemplateModel
   {
        /// <summary>
        /// УН Шаблона
        /// </summary>
       public int IdTemplate { get; set; }
        /// <summary>
        /// Наименование шаблона
        /// </summary>
       public string NameTemplate { get; set; }
       /// <summary>
       /// Дата создания шаблона
       /// </summary>
       public DateTime DateCreate { get; set; }
    }
}
