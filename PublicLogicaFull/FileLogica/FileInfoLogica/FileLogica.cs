using Microsoft.WindowsAPICodePack.Shell;
using System.Drawing;
using System.IO;

namespace PublicLogicaFull.FileLogica.FileInfoLogica
{
    public class FileLogica
    {
        public static FileInfo[] FileinfoMass(string path)
        {
            var dir = new DirectoryInfo(path);
            var files = dir.GetFiles();
            return files;
        }
        /// <summary>
        /// Операция поиска файлов в текущем каталоге
        /// </summary>
        /// <param name="paterns"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static FileInfo[] FileinfoMass(string paterns,string path)
        {
            var dir = new DirectoryInfo(path);
            var files = dir.GetFiles(paterns,SearchOption.TopDirectoryOnly);
            return files;
        }

        public Icon Extracticonfile(string namefile)
        {
            return Icon.ExtractAssociatedIcon(namefile);
        }

        public static string FormatFile(string path)
        {
            return Path.GetExtension(path);
        }
    }
}
