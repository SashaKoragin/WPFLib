using SeathZip.SeathZipF.DataTrigrer;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace SeathZip.SeathZipF.SeathPath
{
  public class PathSt
    {
        public static void PathSeat(object sender,ComboBox item,RoutedEventArgs e)
        {

            var dir = new DirectoryInfo(Configuration.Conf.PathStart);
            var path = new PathStart{Path=new ObservableCollection<PathStart>()};
            DirectoryInfo[] dirs = dir.GetDirectories("*",SearchOption.TopDirectoryOnly);
            foreach ( DirectoryInfo di in dirs)
            {
                path.Path.Add(new PathStart {Namepath=di.FullName, Iconpath=IconsAdd.Extract(di.FullName) });
            }
            item.ItemsSource = path.Path;
        }

        public static void FilePath(object sender, ListView list)
        {
            var file = new Contents { File = new ObservableCollection<Contents>() };
            if (Directory.Exists(Configuration.Conf.OkPath))
            {
                var di = new DirectoryInfo(Configuration.Conf.OkPath);
                var fiArr = di.GetFiles();
                foreach (var item in fiArr)
                {
                    file.File.Add(new Contents { Namefile = item.Name, Fileicon = IconsAdd.Extrfile(item.FullName) });
                }
                list.Dispatcher.Invoke(() =>  list.ItemsSource = file.File);
            }
        }

        public static void PathNow(object sender,ComboBox combobox,ComboBox combonow, SelectionChangedEventArgs e)
        {
            var item = (PathStart)combobox.SelectedValue;
            DirectoryInfo dir = new DirectoryInfo(item.NamePath);
            var path = new PathStart { PathNew = new ObservableCollection<PathStart>() };
            DirectoryInfo[] dirs = dir.GetDirectories("*", SearchOption.TopDirectoryOnly);
            foreach (DirectoryInfo di in dirs)
            {
                path.PathNew.Add(new PathStart {Pathnow = di.Name, Iconpathnow = IconsAdd.Extract(di.FullName) } );
            }
            combonow.ItemsSource = path.PathNew;
        }

    }
}