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
using MaterialDesignThemes.Wpf;

namespace LotusNotes.LotusPage
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class LotusPage : Window
    {
        public static Snackbar Snackbar;
        public LotusPage()

        {
            
            InitializeComponent();
            DataContext = new ModelDialogs.DialogsmodelGlobal(MainSnackbar.MessageQueue);
            Snackbar = MainSnackbar;
        }

        private void ItemsDialog_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MenuToggleButton.IsChecked = false;
        }
    }
}
