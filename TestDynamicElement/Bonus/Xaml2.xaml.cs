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
    /// Логика взаимодействия для Xaml2.xaml
    /// </summary>
    public partial class Xaml2 : UserControl
    {
        public Xaml2(ElemViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
