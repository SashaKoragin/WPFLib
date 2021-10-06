using AutomatAis3Full.Form.Automat.Registration.AcceptanceDocuments.DataContext;

namespace AutomatAis3Full.Form.Automat.Registration.AcceptanceDocuments.UserControl
{
    /// <summary>
    /// Логика взаимодействия для UserControlAcceptanceDocuments.xaml
    /// </summary>
    public partial class UserControlAcceptanceDocuments : System.Windows.Controls.UserControl
    {
        public UserControlAcceptanceDocuments()
        {
            InitializeComponent();
            DataContext = new DataContextAcceptanceDocuments();
        }
    }
}
