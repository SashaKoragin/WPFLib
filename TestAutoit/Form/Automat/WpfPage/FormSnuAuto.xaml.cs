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

namespace TestAutoit.Form.Automat.WpfPage
{
    /// <summary>
    /// Логика взаимодействия для FormSnuAuto.xaml
    /// </summary>
    public partial class FormSnuAuto : UserControl
    {
        public FormSnuAuto()
        {
            InitializeComponent();
            DataContext = new DataContext.DataContextAutomat();
        }

        private void CanExecuteCustomCommand(object sender,
            CanExecuteRoutedEventArgs e)
        {
            Control target = e.Source as Control;

            if (target != null)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        private void ExecutedCustomCommand(object sender,
    ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Custom Command Executed");
        }
    }
}
