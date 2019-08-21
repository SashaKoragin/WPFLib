using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModelLib.ModelTestAutoit.PublicModel.PdfHelp
{
   public class PdfHelp
    {
        /// <summary>
        /// Открытие отчета PDF файла инструкция пользователя
        /// </summary>
        public void OpenReport(string path)
        {
            PublicLogicaFull.FileLogica.OpenFile.OpenFile.Openxls(path);
        }
    }
}
