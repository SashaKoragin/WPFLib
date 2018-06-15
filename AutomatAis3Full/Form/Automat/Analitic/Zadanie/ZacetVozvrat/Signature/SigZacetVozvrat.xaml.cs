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

namespace AutomatAis3Full.Form.Automat.Analitic.Zadanie.ZacetVozvrat.Signature
{
    /// <summary>
    /// Логика взаимодействия для SigZacetVozvrat.xaml
    /// </summary>
    public partial class SigZacetVozvrat : UserControl
    {
        public SigZacetVozvrat()
        {
            InitializeComponent();
            DataContext = new DataContext.DataContextSig();
        }
    }
}
