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
using WordReportsFull.EventsFull;

namespace WordReportsFull.WpfForm.Mains
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        { 
            InitializeComponent();
        }

        //private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        //{
        //    PathForm.PathLoadForm.PathSeat(sender,ComboBox,e);
        //}

        //private void ReportGenerate(object sender, RoutedEventArgs e)
        //{
        //    ReportsStart report = new ReportsStart(this);
        //    report.Report();
        //}

        //private void SelectPath(object sender, SelectionChangedEventArgs e)
        //{
        //    if (ComboBox.SelectedValue != null)
        //    {
    
        //    }
        //}

        private void ClickP1(object sender, RoutedEventArgs e)
        {

            var page = new FormYreg.Uregulirovanie();
            var navigationService = Pages1.NavigationService;
            navigationService?.Navigate(page);
        }

    }
}
