using System.Windows;
using System.Windows.Input;
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
