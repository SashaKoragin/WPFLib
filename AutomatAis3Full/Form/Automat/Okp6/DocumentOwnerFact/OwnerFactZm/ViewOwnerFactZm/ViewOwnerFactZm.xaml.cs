using System.Windows.Controls;

namespace AutomatAis3Full.Form.Automat.Okp6.DocumentOwnerFact.OwnerFactZm.ViewOwnerFactZm
{
    /// <summary>
    /// Логика взаимодействия для ViewOwnerFactZm.xaml
    /// </summary>
    public partial class ViewOwnerFactZm : UserControl
    {
        public ViewOwnerFactZm()
        {
            InitializeComponent();
            DataContext = new DataContextOwnerFactZm.DataContextOwnerFactZm();

        }
    }
}
