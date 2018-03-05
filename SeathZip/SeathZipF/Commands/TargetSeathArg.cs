using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using SeathZip.SeathZipF.Forms.Pages;

namespace SeathZip.SeathZipF.Commands
{
    public class TargetSeathArg
    {
        public void Delete_Execute(object sender, ExecutedRoutedEventArgs e, ListView list)
        {
            if (list.SelectedValue != null)
            {
                var item = (DataTrigrer.Contents)list.SelectedItems[0];
                File.Delete(Configuration.Conf.OkPath + item.NameFile);
                SeathPath.PathSt.FilePath(sender, list);
            }
        }

        public static void OpenFile(object sender, ListView listtxt, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                if (listtxt.SelectedIndex > -1)
                {
                    var item = (DataTrigrer.Contents)listtxt.SelectedItems[0];
                    SeathZipF.OpenFile.OpenF.Openxls(Configuration.Conf.OkPath + item.NameFile);
                }
            }
        }

    }
}
