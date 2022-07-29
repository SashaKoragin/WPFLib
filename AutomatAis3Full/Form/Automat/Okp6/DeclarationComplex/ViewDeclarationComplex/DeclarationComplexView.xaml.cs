using System.Windows.Controls;

namespace AutomatAis3Full.Form.Automat.Okp6.DeclarationComplex.ViewDeclarationComplex
{
    /// <summary>
    /// Логика взаимодействия для DeclarationComplexView.xaml
    /// </summary>
    public partial class DeclarationComplexView : UserControl
    {
        public DeclarationComplexView()
        {
            InitializeComponent();
            DataContext = new DataContextDeclarationComplex.DataContextDeclarationComplex();
        }
    }
}
