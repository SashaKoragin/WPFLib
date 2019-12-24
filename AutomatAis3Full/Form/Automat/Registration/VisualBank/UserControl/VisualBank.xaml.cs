namespace AutomatAis3Full.Form.Automat.Registration.VisualBank.UserControl
{
    /// <summary>
    /// Логика взаимодействия для VisualBank.xaml
    /// </summary>
    public partial class VisualBank : System.Windows.Controls.UserControl
    {
        public VisualBank()
        {
            InitializeComponent();
            DataContext = new DataContext.DataContextVisualBank();
        }
    }
}
