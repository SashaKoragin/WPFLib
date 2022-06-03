using AutomatAis3Full.Form.Automat.Uregulirovanie.Uvedomlenie0509.ApplicationManualProcessing.DataContext;

namespace AutomatAis3Full.Form.Automat.Uregulirovanie.Uvedomlenie0509.ApplicationManualProcessing.UserControl
{
    /// <summary>
    /// Логика взаимодействия для ApplicationManualProcessing.xaml
    /// </summary>
    public partial class ApplicationManualProcessing : System.Windows.Controls.UserControl
    {
        public ApplicationManualProcessing()
        {
            InitializeComponent();
            DataContext = new DataContextApplicationManualProcessing();
        }
    }
}
