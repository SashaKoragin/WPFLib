using System.Windows;
using SeathZip.SeathZipF.Arh;

namespace SeathZip.SeathZipF.Forms
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ClickP1(object sender, RoutedEventArgs e)
        {

            var page = new Pages.SeathArg();
            var navigationService = Pages1.NavigationService;
            navigationService?.Navigate(page);
        }

        private void ClickP2(object sender, RoutedEventArgs e)
        {
            var page1 = new Pages.SeathFullPath();
            var navigationService = Pages1.NavigationService;
            navigationService?.Navigate(page1);
        }
    }
}
