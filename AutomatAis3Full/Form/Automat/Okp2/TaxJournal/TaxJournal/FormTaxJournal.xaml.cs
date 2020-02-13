using System.Windows.Controls;


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
    }
}
