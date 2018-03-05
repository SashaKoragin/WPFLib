using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SeathZip.SeathZipF.Commands;
using SeathZip.SeathZipF.FindPathArhFull;

namespace SeathZip.SeathZipF.Forms.Pages
{
    /// <summary>
    /// Логика взаимодействия для SeathDB.xaml
    /// </summary>
    public partial class SeathFullPath
    {
        public SeathFullPath()
        {
            InitializeComponent();
        }

        private void LoadForm2(object sender, RoutedEventArgs e)
        {
            SeathPath.PathSt.FilePath(sender, ListFileArhFull);
        }

        private void Finding(object sender, ExecutedRoutedEventArgs e)
        {
            TargetSeathFullPath target = new TargetSeathFullPath(this);
            target.FindingPath(sender, e);
        }

        private void OpenF(object sender, MouseButtonEventArgs e)
        {
           TargetSeathArg.OpenFile(sender, ListFileArhFull, e);
        }

        private void CommandBinding_OnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (ListFileArhFull.SelectedValue != null)
            {
                TargetSeathArg target = new TargetSeathArg();
                target.Delete_Execute(sender, e, ListFileArhFull);
            }
        }

        private void SeathFull(object sender, RoutedEventArgs e)
        {
            SobitieSeathFull sob = new SobitieSeathFull(this);
            sob.ToGo();
        }
    }
}
