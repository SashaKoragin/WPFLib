using System.Windows.Controls;

namespace TestAutoit.Form.Automat.Okp4.WpfPage
{
    /// <summary>
    /// Логика взаимодействия для FormSnuAuto.xaml
    /// </summary>
    public partial class FormSnuAuto : UserControl
    {
        public FormSnuAuto()
        {
            InitializeComponent();
            DataContext = new DataContext.DataContextAutomat();
        }
    }
}
