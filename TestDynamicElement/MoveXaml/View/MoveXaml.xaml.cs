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

namespace TestDynamicElement.MoveXaml.View
{
    /// <summary>
    /// Логика взаимодействия для MoveXaml.xaml
    /// </summary>
    public partial class MoveXaml : UserControl
    {

        public MoveXaml()
        {
            
        }
        public MoveXaml(ViewModel.ViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
