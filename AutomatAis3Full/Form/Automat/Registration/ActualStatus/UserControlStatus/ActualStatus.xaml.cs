using System.Windows.Controls;

namespace AutomatAis3Full.Form.Automat.Registration.ActualStatus.UserControlStatus
{
    /// <summary>
    /// Логика взаимодействия для ActualStatus.xaml
    /// </summary>
    public partial class ActualStatus : UserControl
    {
        public ActualStatus()
        {
            InitializeComponent();
            DataContext = new DataContext.DataContextActual();
        }
    }
}
