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
using AutomatAis3Full.Form.Automat.Okp4.PravoEdit.DataContext;

namespace AutomatAis3Full.Form.Automat.Okp4.PravoEdit.PravoEdit
{
    /// <summary>
    /// Логика взаимодействия для PravoEditForm.xaml
    /// </summary>
    public partial class PravoEditForm : UserControl
    {
        public PravoEditForm()
        {
            InitializeComponent();
            DataContext = new PravoEditDataContext();
        }
    }
}
