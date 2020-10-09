using System.Windows.Controls;
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
    }
}
