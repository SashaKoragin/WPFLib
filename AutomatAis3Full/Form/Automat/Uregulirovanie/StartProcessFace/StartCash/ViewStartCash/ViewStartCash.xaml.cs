using System.Windows.Controls;

namespace AutomatAis3Full.Form.Automat.Uregulirovanie.StartProcessFace.StartCash.ViewStartCash
{
    /// <summary>
    /// Логика взаимодействия для ViewStartCash.xaml
    /// </summary>
    public partial class ViewStartCash : UserControl
    {
        public ViewStartCash()
        {
            InitializeComponent();
            DataContext = new DataContextStartCash.DataContextStartCash();
        }
    }
}
