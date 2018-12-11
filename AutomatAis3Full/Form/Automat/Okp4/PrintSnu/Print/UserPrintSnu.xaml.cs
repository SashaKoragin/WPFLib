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
using AutomatAis3Full.Form.Automat.Okp4.MassSnuForm.DataContext;
using AutomatAis3Full.Form.Automat.Okp4.PrintSnu.DataContext;

namespace AutomatAis3Full.Form.Automat.Okp4.PrintSnu.Print
{
    /// <summary>
    /// Логика взаимодействия для UserPrintSnu.xaml
    /// </summary>
    public partial class UserPrintSnu : UserControl
    {
        public UserPrintSnu()
        {
            InitializeComponent();
            DataContext = new UserPrintSnuDataContext();
        }
    }
}
