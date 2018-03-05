using System;
using System.Drawing;
using Microsoft.WindowsAPICodePack.Shell;

namespace SeathZip.SeathZipF.SeathPath
{
   public class IconsAdd
    {

            public static Icon Extract(String st)
            {
            //var icon = Icon.ExtractAssociatedIcon(icons);
            //return icon;
            var shellobject = (ShellFolder)ShellObject.FromParsingName(st);
            ShellThumbnail shellt = shellobject.Thumbnail;
            return shellt.Icon;
            }

        public static Icon Extrfile(String namefile)
        {
            var shell = (ShellFile)ShellObject.FromParsingName(namefile);
            ShellThumbnail sh = shell.Thumbnail;
            return sh.Icon;
        }
    }
}
