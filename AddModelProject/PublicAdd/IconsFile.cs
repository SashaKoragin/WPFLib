using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.Shell;

namespace AddModelProject.PublicAdd
{
   public class IconsFile
    {
        public static Icon Extracticonfile(String namefile)
        {

            var shell = ShellObject.FromParsingName(namefile);
            ShellThumbnail sh = shell.Thumbnail;
            return sh.MediumIcon;
        }
    }
}
