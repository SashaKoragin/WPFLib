
namespace AutomatAis3Full.Form.Automat.Uregulirovanie.Uvedomlenie0509.MessageApproval.UserControl
{
    /// <summary>
    /// Логика взаимодействия для MessageApproval.xaml
    /// </summary>
    public partial class MessageApproval : System.Windows.Controls.UserControl
    {
        public MessageApproval()
        {
            InitializeComponent();
            DataContext = new DataContext.DataContextMessageApproval();
        }
    }
}
