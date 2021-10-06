using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutomatAis3Full.Form.Automat.Okp1.Declaration121Error.Declaration121Error
{
    /// <summary>
    /// Логика взаимодействия для FormDeclaration121Error.xaml
    /// </summary>
    public partial class FormDeclaration121Error : UserControl
    {
        public FormDeclaration121Error()
        {
            InitializeComponent();
            DataContext = new DataContext.DataContextDeclaration121Error();
        }
    }
}
