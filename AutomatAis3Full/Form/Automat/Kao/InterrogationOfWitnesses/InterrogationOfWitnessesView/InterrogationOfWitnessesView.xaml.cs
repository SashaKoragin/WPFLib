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

namespace AutomatAis3Full.Form.Automat.Kao.InterrogationOfWitnesses.InterrogationOfWitnessesView
{
    /// <summary>
    /// Логика взаимодействия для InterrogationOfWitnessesView.xaml
    /// </summary>
    public partial class InterrogationOfWitnessesView : UserControl
    {
        public InterrogationOfWitnessesView()
        {
            InitializeComponent();
            DataContext = new InterrogationOfWitnessesDataContext.InterrogationOfWitnessesDataContext();
        }
    }
}
