using System.Windows.Controls;
using AutomatAis3Full.Form.Automat.Orn.ConfirmationNbo.DataContext;

namespace AutomatAis3Full.Form.Automat.Orn.ConfirmationNbo.ConfirmationNbo
{
    /// <summary>
    /// Логика взаимодействия для ConfirmationNbo.xaml
    /// </summary>
    public partial class ConfirmationNbo : UserControl
    {
        public ConfirmationNbo()
        {
            InitializeComponent();
            DataContext = new DataContextConfirmationNbo();
        }
    }
}
