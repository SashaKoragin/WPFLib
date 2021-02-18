using System.Windows.Controls;

namespace AutomatAis3Full.Form.Automat.Okp6.RegistryDeclaration.ViewRegistryDeclaration
{
    /// <summary>
    /// Логика взаимодействия для RegistryDeclarationView.xaml
    /// </summary>
    public partial class RegistryDeclarationView : UserControl
    {
        public RegistryDeclarationView()
        {
            InitializeComponent();
            DataContext = new DataContextRegistryDeclaration.DataContextRegistryDeclaration();
        }
    }
}
