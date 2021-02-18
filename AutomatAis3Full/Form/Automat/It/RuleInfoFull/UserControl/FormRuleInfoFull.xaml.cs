

namespace AutomatAis3Full.Form.Automat.It.RuleInfoFull.UserControl
{
    /// <summary>
    /// Логика взаимодействия для FormRuleInfoFull.xaml
    /// </summary>
    public partial class FormRuleInfoFull : System.Windows.Controls.UserControl
    { 
        public FormRuleInfoFull()
        {
            InitializeComponent();
            DataContext = new DataContext.RuleInfoFullDataContext();
        }
    }
}
