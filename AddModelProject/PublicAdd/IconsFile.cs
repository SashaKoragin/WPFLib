using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.Shell;

namespace AddModelProject.PublicAdd
{
    /// <summary>
    /// Вспомогательный класс для разных плюшек
    /// </summary>
   public class IconsFile
    {
        /// <summary>
        /// Плюшка раз вытаскивает Иконку из файла
        /// </summary>
        /// <param name="namefile"></param>
        /// <returns></returns>
        public static Icon Extracticonfile(String namefile)
        {

            var shell = ShellObject.FromParsingName(namefile);
            ShellThumbnail sh = shell.Thumbnail;
            return sh.MediumIcon;
        }
    }
}
