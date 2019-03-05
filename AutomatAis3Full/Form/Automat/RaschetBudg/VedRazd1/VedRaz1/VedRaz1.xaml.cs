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
using AutomatAis3Full.GlavnayLogika.Mvvm;

namespace AutomatAis3Full.Form.Automat.RaschetBudg.VedRazd1.VedRaz1
{
    /// <summary>
    /// Логика взаимодействия для VedRaz1.xaml
    /// </summary>
    public partial class VedRaz1 : UserControl
    {
        public VedRaz1()
        {
            InitializeComponent();
            DataContext = new DataContext.VedRazd1();
    }
    }
}
