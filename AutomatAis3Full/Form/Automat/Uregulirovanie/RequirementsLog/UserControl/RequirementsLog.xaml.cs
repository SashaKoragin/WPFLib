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

namespace AutomatAis3Full.Form.Automat.Uregulirovanie.RequirementsLog.UserControl
{
    /// <summary>
    /// Логика взаимодействия для RequirementsLog.xaml
    /// </summary>
    public partial class RequirementsLog : System.Windows.Controls.UserControl
    {
        public RequirementsLog()
        {
            InitializeComponent();
            DataContext = new DataContext.DataContextRequirementsLog();
        }
    }
}
