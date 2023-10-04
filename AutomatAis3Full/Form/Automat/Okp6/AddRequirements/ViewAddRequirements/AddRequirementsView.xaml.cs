using System.Windows.Controls;

namespace AutomatAis3Full.Form.Automat.Okp6.AddRequirements.ViewAddRequirements
{
    /// <summary>
    /// Логика взаимодействия для AddTermView.xaml
    /// </summary>
    public partial class AddRequirementsView : UserControl
    {
        public AddRequirementsView()
        {
            InitializeComponent();
            DataContext = new DataContextAddRequirements.DataContextAddRequirements();
        }
    }
}
