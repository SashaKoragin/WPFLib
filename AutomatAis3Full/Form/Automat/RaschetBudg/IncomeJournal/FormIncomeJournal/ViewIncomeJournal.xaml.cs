using System.Windows.Controls;

namespace AutomatAis3Full.Form.Automat.RaschetBudg.IncomeJournal.FormIncomeJournal
{
    /// <summary>
    /// Логика взаимодействия для ViewIncomeJournal.xaml
    /// </summary>
    public partial class ViewIncomeJournal : UserControl
    {
        public ViewIncomeJournal()
        {
            InitializeComponent();
            DataContext = new DataContextIncomeJournal.DataContextIncomeJournal();
        }
    }
}
