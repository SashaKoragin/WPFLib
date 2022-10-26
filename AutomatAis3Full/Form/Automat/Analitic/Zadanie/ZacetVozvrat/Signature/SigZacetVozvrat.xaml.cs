using System.Windows.Controls;

namespace AutomatAis3Full.Form.Automat.Analitic.Zadanie.ZacetVozvrat.Signature
{
    /// <summary>
    /// Логика взаимодействия для SigZacetVozvrat.xaml
    /// </summary>
    public partial class SigZacetVozvrat : UserControl
    {
        public SigZacetVozvrat()
        {
            InitializeComponent();
            DataContext = new DataContext.DataContextSig();
        }
    }
}
