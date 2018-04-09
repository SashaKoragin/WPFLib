
namespace AutomatAis3Full.Form.Automat.Registration.TreatmentFPD.Zemly.UserControl
{
    /// <summary>
    /// Логика взаимодействия для FpdZemly.xaml
    /// </summary>
    public partial class FpdZemly : System.Windows.Controls.UserControl
    {
        public FpdZemly()
        {
            InitializeComponent();
            DataContext = new DataContext.DataContextZemly();
        }
    }
}
