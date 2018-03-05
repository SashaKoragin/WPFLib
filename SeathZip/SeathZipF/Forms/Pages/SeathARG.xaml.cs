using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

namespace SeathZip.SeathZipF.Forms.Pages
{
    /// <summary>
    /// Логика взаимодействия для SeathARG.xaml
    /// </summary>
    public partial class SeathArg
    {
        public SeathArg()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Sobytie.Sobytie sob = new Sobytie.Sobytie(this);
            sob.ToGo();
        }

        private void OpenF(object sender, MouseButtonEventArgs e)
        {
            TargetSeathArg.OpenFile(sender, ListFileArh, e);
        }

        private void LoadForm(object sender, RoutedEventArgs e)
        {
            SeathPath.PathSt.PathSeat(sender, ComboBox, e);
            SeathPath.PathSt.FilePath(sender, ListFileArh);
        }

        private void SelectPath(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox.SelectedValue!=null)
            { 
               SeathPath.PathSt.PathNow(sender, ComboBox, ComboBox1, e);
            }
        }

        private void CommandBinding_OnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (ListFileArh.SelectedValue != null)
            {
                TargetSeathArg target = new TargetSeathArg();
                target.Delete_Execute(sender, e, ListFileArh);
            }
        }
    }
}
