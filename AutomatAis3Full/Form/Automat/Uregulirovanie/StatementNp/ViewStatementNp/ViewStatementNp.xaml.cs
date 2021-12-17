using System.Windows.Controls;


namespace AutomatAis3Full.Form.Automat.Uregulirovanie.StatementNp.ViewStatementNp
{
    /// <summary>
    /// Логика взаимодействия для ViewStatementNp.xaml
    /// </summary>
    public partial class ViewStatementNp : UserControl
    {
        public ViewStatementNp()
        {
            InitializeComponent();
            DataContext = new DataContextStatementNp.DataContextStatementNp();
        }
    }
}
