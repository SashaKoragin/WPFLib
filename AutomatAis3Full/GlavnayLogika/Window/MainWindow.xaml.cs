using System;
using System.Deployment.Application;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Navigation;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;


namespace AutomatAis3Full.GlavnayLogika.Window
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        
        public MainWindow()
        {
            InitializeComponent();
            Window.Title = $"AutomatAis3Full - версия продукта {GetRunningVersion()}";
            DataContext = new Mvvm.WindowsMvvmAuto();
        }

        private void UIElement_OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scr = (ScrollViewer) sender;
            scr.ScrollToVerticalOffset(scr.VerticalOffset-e.Delta);
            e.Handled = true;
        }

        private Version GetRunningVersion()
        {
                return Assembly.GetExecutingAssembly().GetName().Version;
        }

        private void Hyperlink_Navigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
