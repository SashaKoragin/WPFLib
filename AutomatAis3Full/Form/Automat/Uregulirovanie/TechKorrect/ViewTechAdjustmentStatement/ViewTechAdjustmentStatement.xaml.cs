using System.Windows.Controls;

namespace AutomatAis3Full.Form.Automat.Uregulirovanie.TechKorrect.ViewTechAdjustmentStatement
{
    /// <summary>
    /// Логика взаимодействия для ViewTechAdjustmentStatement.xaml
    /// </summary>
    public partial class ViewTechAdjustmentStatement : UserControl
    {
        public ViewTechAdjustmentStatement()
        {
            InitializeComponent();
            DataContext = new DataContextTechAdjustmentStatement.DataContextTechAdjustmentStatement();
        }
    }
}
