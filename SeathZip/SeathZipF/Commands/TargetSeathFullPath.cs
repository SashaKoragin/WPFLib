using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using SeathZip.SeathZipF.SeathPath;
using SeathZip.SeathZipF.Forms.Pages;
using SeathZip.SeathZipF.DataTrigrer;

namespace SeathZip.SeathZipF.Commands
{
    public class TargetSeathFullPath
    {
        public SeathFullPath P2;
        public TargetSeathFullPath(SeathFullPath owner)  //Конструктор для формы xaml
        {
            P2 = owner;
        }

        public void FindingPath(object sender, ExecutedRoutedEventArgs e)
        {
            var pathfull = (PathStart)P2.Resources["Path"];
            var color = (Trige)P2.Resources["Trig"];
            var browse = new FolderBrowserDialog
            {
                Description = @"Выбор директорию для поиска!",
                SelectedPath = @"C:\"
            };
            if (browse.ShowDialog() == DialogResult.OK)
            {
                pathfull.FullPath = browse.SelectedPath;
                pathfull.FullIcon = IconsAdd.Extract(browse.SelectedPath);
                color.ElementError = @"ok";

            }
        }

    }
}
