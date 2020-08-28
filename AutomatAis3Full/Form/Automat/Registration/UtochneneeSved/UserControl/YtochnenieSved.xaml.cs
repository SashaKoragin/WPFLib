
namespace AutomatAis3Full.Form.Automat.Registration.UtochneneeSved.UserControl
{
    /// <summary>
    /// Логика взаимодействия для YtochnenieSved.xaml
    /// </summary>
    public partial class YtochnenieSved : System.Windows.Controls.UserControl
    {
        public YtochnenieSved(LibraryCommandPublic.TestAutoit.Reg.YtochnenieSved.AutoCommand.YtochnenieSved ytochnenieSved)
        {
            InitializeComponent();
            DataContext = new DataContext.DataContextReg(ytochnenieSved);
        }
    }
}
