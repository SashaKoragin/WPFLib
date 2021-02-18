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

namespace AutomatAis3Full.Form.Automat.Uregulirovanie.StartProcessFace.StartCash.ViewStartCash
{
    /// <summary>
    /// Логика взаимодействия для ViewStartCash.xaml
    /// </summary>
    public partial class ViewStartCash : UserControl
    {
        public ViewStartCash()
        {
            InitializeComponent();
            DataContext = new DataContextStartCash.DataContextStartCash();
        }
    }
}
