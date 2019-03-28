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
using TestDynamicElement.Bonus.ViewModel;

namespace TestDynamicElement.Bonus
{
    /// <summary>
    /// Логика взаимодействия для Xaml1.xaml
    /// </summary>
    public partial class Xaml1 : UserControl
    {
        public Xaml1(ElemViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
