using System.Windows.Controls;

namespace AutomatAis3Full.Form.Automat.Uregulirovanie.StartProcessFace.JudicialAct.ViewJudicialAct
{
    /// <summary>
    /// Логика взаимодействия для ViewJudicialAct.xaml
    /// </summary>
    public partial class ViewJudicialAct : UserControl
    {
        public ViewJudicialAct()
        {
            InitializeComponent();
            DataContext = new DataContextJudicialAct.DataContextJudicialAct();
        }
    }
}
