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
using AutomatAis3Full.Form.Automat.PreCheck.Journal129.DataContext;

namespace AutomatAis3Full.Form.Automat.PreCheck.Journal129.Journal129
{
    /// <summary>
    /// Логика взаимодействия для Journal129.xaml
    /// </summary>
    public partial class Journal129 : UserControl
    {
        public Journal129()
        {
            InitializeComponent();
            DataContext = new Journal129Context();
        }
    }
}
