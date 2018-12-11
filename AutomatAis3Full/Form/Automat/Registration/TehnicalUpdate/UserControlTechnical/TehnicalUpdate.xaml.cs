using System.Windows.Controls;

namespace AutomatAis3Full.Form.Automat.Registration.TehnicalUpdate.UserControlTechnical
{
    /// <summary>
    /// Логика взаимодействия для TehnicalUpdate.xaml
    /// </summary>
    public partial class TehnicalUpdate : UserControl
    {
        public TehnicalUpdate()
        {
            InitializeComponent();
            DataContext = new DataContext.DataContextTehnical();
        }
    }
}
