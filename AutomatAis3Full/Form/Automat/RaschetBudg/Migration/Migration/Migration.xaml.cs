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
using AutomatAis3Full.Form.Automat.RaschetBudg.Migration.DataContext;

namespace AutomatAis3Full.Form.Automat.RaschetBudg.Migration.Migration
{
    /// <summary>
    /// Логика взаимодействия для Migration.xaml
    /// </summary>
    public partial class Migration : UserControl
    {
        public Migration()
        {
            InitializeComponent();
            DataContext = new MigrationContext();
        }
    }
}
