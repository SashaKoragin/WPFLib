using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using DBFtoSQL2008Enterprise.Aplication.ViewModelStyle.VievModelPage;
using MaterialDesignThemes.Wpf;

namespace DBFtoSQL2008Enterprise.Aplication.FormsWindows.Glavnoe
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Snackbar Snackbar;
        public MainWindow()
        {
            InitializeComponent();
            
            DataContext = new PageViewModel(MainSnackbar.MessageQueue);
            Snackbar = MainSnackbar;
        }

        private void UIElement_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //until we had a StaysOpen glag to Drawer, this will help with scroll bars
            var dependencyObject = Mouse.Captured as DependencyObject;
            while (dependencyObject != null)
            {
                if (dependencyObject is ScrollBar) return;
                dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
            }

            MenuToggleButton.IsChecked = false;
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            //GavnazPage1 sob = new GavnazPage1(this);
            //sob.SaveAs();
        }
    }
}
