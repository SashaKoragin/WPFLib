using System.Windows.Controls;

namespace AutomatAis3Full.Form.Automat.Okp6.AddTerm.ViewAddTerm
{
    /// <summary>
    /// Логика взаимодействия для ViewAddTerm.xaml
    /// </summary>
    public partial class AddTermView : UserControl
    {
        public AddTermView()
        {
            InitializeComponent();
            DataContext = new DataContextAddTerm.DataContextAddTerm();
        }
    }
}
