
namespace AutomatAis3Full.Form.Automat.Registration.Rosreestr.UserControl
{
    /// <summary>
    /// Логика взаимодействия для UserControlRosreestr.xaml
    /// </summary>
    public partial class UserControlRosreestr
    {
        public UserControlRosreestr()
        {
            InitializeComponent();
            DataContext = new DataContext.RosreestrContext();
        }
    }
}
