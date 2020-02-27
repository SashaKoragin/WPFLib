using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace AutomatAis3Full.Form.Automat.Okp2.TaxJournal.TaxJournal
{
    /// <summary>
    /// Логика взаимодействия для FormTaxJournal.xaml
    /// </summary>
    public partial class FormTaxJournal : UserControl
    {
        public FormTaxJournal()
        {
            InitializeComponent();
            DataContext = new DataContext.DataContextTaxJournal();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
