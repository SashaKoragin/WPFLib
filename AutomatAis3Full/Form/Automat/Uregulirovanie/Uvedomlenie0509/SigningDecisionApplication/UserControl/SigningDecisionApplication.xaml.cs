using AutomatAis3Full.Form.Automat.Uregulirovanie.Uvedomlenie0509.SigningDecisionApplication.DataContext;

namespace AutomatAis3Full.Form.Automat.Uregulirovanie.Uvedomlenie0509.SigningDecisionApplication.UserControl
{
    /// <summary>
    /// Логика взаимодействия для SigningDecisionApplication.xaml
    /// </summary>
    public partial class SigningDecisionApplication : System.Windows.Controls.UserControl
    {
        public SigningDecisionApplication()
        {
            InitializeComponent();
            DataContext = new DataContextSigningDecisionApplication();
        }
    }
}
