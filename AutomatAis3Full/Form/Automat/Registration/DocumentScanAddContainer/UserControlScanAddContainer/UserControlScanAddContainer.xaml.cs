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

namespace AutomatAis3Full.Form.Automat.Registration.DocumentScanAddContainer.UserControlScanAddContainer
{
    /// <summary>
    /// Логика взаимодействия для UserControlScanAddContainer.xaml
    /// </summary>
    public partial class UserControlScanAddContainer : UserControl
    {
        public UserControlScanAddContainer()
        {
            InitializeComponent();
            DataContext = new DataContextScanAddContainer.DataContextScanAddContainer();
        }
    }
}
