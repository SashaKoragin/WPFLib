using System.Windows.Controls;

namespace AutomatAis3Full.Form.Automat.Registration.IdentificationFace.IdentificationFl.ViewIdentificationFl
{
    /// <summary>
    /// Логика взаимодействия для IdentificationFlView.xaml
    /// </summary>
    public partial class IdentificationFlView : UserControl
    {
        public IdentificationFlView()
        {
            InitializeComponent();
            DataContext = new DataContextIdentificationFl.DataContextIdentificationFl();
        }
    }
}
