

namespace AutomatAis3Full.Form.Automat.Registration.DocumentScan.UserControlScan
{
    /// <summary>
    /// Логика взаимодействия для UserControlDocumentScan.xaml
    /// </summary>
    public partial class UserControlDocumentScan : System.Windows.Controls.UserControl
    {
        public UserControlDocumentScan()
        {
            InitializeComponent();
            DataContext = new DataContextScan.DataContextDocumentScan();
        }
    }
}
