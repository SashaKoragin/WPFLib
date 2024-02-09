using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace AutomatAis3Full.Form.Automat.PublicFunctionLogics.PublicTaxJournal.FormTaxJournal
{
    /// <summary>
    /// Логика взаимодействия для FormTaxJournal.xaml
    /// </summary>
    public partial class FormTaxJournal : UserControl
    {
        public FormTaxJournal()
        {
            InitializeComponent();
            DataContext = new DataContextTaxJournal.DataContextTaxJournal();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
