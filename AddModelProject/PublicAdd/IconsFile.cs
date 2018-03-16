using System;
using System.Drawing;
using System.IO;
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

        //public static Icon ExtracticonNameFile(String namefile)
        //{
        //    DirectoryInfo
        //    var shell = ShellObject.FromParsingName(namefile);
        //    ShellThumbnail sh = shell.Thumbnail;
        //    return sh.MediumIcon;
        //}

        public static FileInfo[] FileinfoMass(string path)
        {
            var dir = new DirectoryInfo(path);
            var files = dir.GetFiles();
            return files;
        }
    }
}
