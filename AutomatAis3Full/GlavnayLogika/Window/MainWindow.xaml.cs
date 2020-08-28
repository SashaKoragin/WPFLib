using System;
using System.Deployment.Application;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Navigation;
using DocumentFormat.OpenXml.Spreadsheet;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;


namespace AutomatAis3Full.GlavnayLogika.Window
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool PostMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        static extern int LoadKeyboardLayout(string pwszKlid, uint flags);
        public MainWindow()
        {
            InitializeComponent();
            Window.Title = $"AutomatAis3Full - версия продукта {GetRunningVersion()}";
            DataContext = new Mvvm.WindowsMvvmAuto();
            string lang = "00000409";
            int ret = LoadKeyboardLayout(lang, 1);
            PostMessage(GetForegroundWindow(), 0x50, 1, ret);
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
