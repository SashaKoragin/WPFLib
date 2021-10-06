using AutomatAis3Full.Form.Automat.Okp1.Declaration121ActIsh.DataContext;
using System.Windows.Controls;


namespace AutomatAis3Full.Form.Automat.Okp1.Declaration121ActIsh.Declaration121ActIsh
{
    /// <summary>
    /// Логика взаимодействия для FormDeclaration121ActIsh.xaml
    /// </summary>
    public partial class FormDeclaration121ActIsh : UserControl
    {
        public FormDeclaration121ActIsh()
        {
            InitializeComponent();
            DataContext = new DataContextDeclaration121ActIsh();
        }
    }
}
