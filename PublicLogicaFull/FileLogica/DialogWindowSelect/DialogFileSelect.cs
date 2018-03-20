using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace PublicLogicaFull.FileLogica.DialogWindowSelect
{
   public class DialogFileSelect
    {
        /// <summary>
        /// Возвращает выбранный файл в Диалоговом окне
        /// </summary>
        /// <returns>Возвращает файл</returns>
        public FileInfo OpenFileDialog()
        {
            var win = new OpenFileDialog() {Filter = "Файлы xlsx|*.xlsx", Multiselect = false };
            if (win.ShowDialog() == true)
            {
                return new FileInfo(win.FileName);
            }
            return null;
        }

        /// <summary>
        /// Возвращает все выбранные файлы по маске xlsx
        /// </summary>
        /// <returns>Массив файлов</returns>
        public FileInfo[] OpenFileDialogSelectFile()
        {
            var win = new OpenFileDialog() { Filter = "Файлы xlsx|*.xlsx", Multiselect = true };
            if (win.ShowDialog() == true)
            {
                return win.FileNames.Select(file => new FileInfo(file)).ToArray();
            }
            return null;
        }

    }
}
