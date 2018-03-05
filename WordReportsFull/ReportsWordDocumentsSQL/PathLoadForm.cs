using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using WordReportsFull.ValidationControl;
using System.Drawing;
using Microsoft.WindowsAPICodePack.Shell;


namespace WordReportsFull.PathForm
{
   public class PathLoadForm
    {
        public static void PathSeat(object sender, ComboBox item, RoutedEventArgs e)
        {
           var dir = new DirectoryInfo(Config.Config.TemplateDirectory);
            var path = new ContentZn { PathTemplate= new ObservableCollection<ContentZn>() };
            var dirs = dir.GetFiles();
            foreach (var param in dirs)
            {
                    path.PathTemplate.Add(new ContentZn
                    {
                      NameTemplate = param.Name,
                      Icontemplate = ExecuteIcon.Extrfile(param.FullName),
                      Sqlt = SQLTemplate.SqlSelect.SqlSelect.SqlCom(param.Name),
                      Fullname = param.FullName,
                      Xmlcol = SQLTemplate.SqlSelect.XmlSelect.SqlCom(param.Name)
                    });
            }
            item.ItemsSource = path.PathTemplate;
        }
    }


    public class ExecuteIcon
    {
        public static Icon Extrfile(String namefile)
        {
            var shell = (ShellFile)ShellObject.FromParsingName(namefile);
            ShellThumbnail sh = shell.Thumbnail;
            return sh.Icon;
        }
    }

}
