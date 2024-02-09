using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;
using AutomatAis3Full.Form.Automat.Okp5.ActIzvesheniaReshenia121.DataContext;

namespace AutomatAis3Full.Form.Automat.Okp5.ActIzvesheniaReshenia121.ActIzvesheniaReshenia
{
    /// <summary>
    /// Логика взаимодействия для ActIzvesheniaResheniaView.xaml
    /// </summary>
    public partial class ActIzvesheniaResheniaView : UserControl
    {
        public ActIzvesheniaResheniaView()
        {
            InitializeComponent();
            DataContext = new ActIzvesheniaResheniaDataContext();
        }

        //private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        //{
        //    Regex regex = new Regex("[^0-9]+");
        //    e.Handled = regex.IsMatch(e.Text);
        //}
    }
}
