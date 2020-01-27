using AutomatAis3Full.Form.Automat.Uregulirovanie.Ticket05080902.Ticket0508090202.Ticket050809020204.DataContext;

namespace AutomatAis3Full.Form.Automat.Uregulirovanie.Ticket05080902.Ticket0508090202.Ticket050809020204.UserControl
{
    /// <summary>
    /// Логика взаимодействия для StatementOfficeNote.xaml
    /// </summary>
    public partial class StatementOfficeNote : System.Windows.Controls.UserControl
    {
        public StatementOfficeNote()
        {
            InitializeComponent();
            DataContext = new DataContextStatementOfficeNote();
        }
    }
}
