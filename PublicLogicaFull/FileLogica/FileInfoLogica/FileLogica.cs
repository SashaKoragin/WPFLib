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

        public static Icon Extracticonfile(string namefile)
        {

            var shell = ShellObject.FromParsingName(namefile);
            ShellThumbnail sh = shell.Thumbnail;
            return sh.MediumIcon;
        }

        public static string FormatFile(string path)
        {
            return Path.GetExtension(path);
        }
    }
}
