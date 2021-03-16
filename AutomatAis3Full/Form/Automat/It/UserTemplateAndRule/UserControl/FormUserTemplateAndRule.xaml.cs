using System.Windows.Controls;
using AutomatAis3Full.Form.Automat.It.UserTemplateAndRule.DataContext;

namespace AutomatAis3Full.Form.Automat.It.UserTemplateAndRule.UserControl
{
    /// <summary>
    /// Логика взаимодействия для FormUserTemplateAndRule.xaml
    /// </summary>
    public partial class FormUserTemplateAndRule : System.Windows.Controls.UserControl
    {
        public FormUserTemplateAndRule()
        {
            InitializeComponent();
            DataContext = new UserTemplateAndRuleDataContext();
        }
    }
}
