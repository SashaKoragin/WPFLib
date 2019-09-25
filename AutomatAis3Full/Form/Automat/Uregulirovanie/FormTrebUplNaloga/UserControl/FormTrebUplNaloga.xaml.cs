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

namespace AutomatAis3Full.Form.Automat.Uregulirovanie.FormTrebUplNaloga.UserControl
{
    /// <summary>
    /// Логика взаимодействия для FormTrebUplNaloga.xaml
    /// </summary>
    public partial class FormTrebUplNaloga : System.Windows.Controls.UserControl
    {
        public FormTrebUplNaloga()
        {
            InitializeComponent();
            DataContext = new DataContext.DataContextFormTrebUplNaloga();
        }
    }
}
