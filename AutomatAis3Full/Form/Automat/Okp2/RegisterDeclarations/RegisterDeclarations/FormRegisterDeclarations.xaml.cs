using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace AutomatAis3Full.Form.Automat.Okp2.RegisterDeclarations.RegisterDeclarations
{
    /// <summary>
    /// Логика взаимодействия для FormRegisterDeclarations.xaml
    /// </summary>
    public partial class FormRegisterDeclarations : UserControl
    {
        public FormRegisterDeclarations()
        {
            InitializeComponent();
            DataContext = new DataContext.DataContextRegisterDeclarations();
        }

        private void NumberValidationTextBox(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
