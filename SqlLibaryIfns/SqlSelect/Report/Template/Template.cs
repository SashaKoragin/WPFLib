using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLibaryIfns.SqlSelect.Report.Template
{
   public class Template
   {
        /// <summary>
        /// Запрос на шаблон
        /// </summary>
       public static string SelectTemplate = @" Select * ,
                                                    (SELECT Headers.* FROM Headers WHERE Headers.IdHeaders = Template.IdHeaders FOR XML AUTO, TYPE),
                                                    (SELECT Body.* FROM Body WHERE Body.IdBody = Template.IdBody FOR XML AUTO, TYPE),
                                                    (SELECT Stone.* FROM Stone WHERE Stone.IdStone = Template.IdStone FOR XML AUTO, TYPE)
                                                From NameDocument
                                                Join Template on Template.IdTemplate = NameDocument.IdTemplate
                                                Where NameDocument.IdTemplate = @IdTemplate
                                                FOR XML AUTO,ROOT('TemplateFull')";
   }
}
