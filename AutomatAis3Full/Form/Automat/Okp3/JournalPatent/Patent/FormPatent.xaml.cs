using System.Windows.Controls;


namespace AutomatAis3Full.Form.Automat.Okp3.JournalPatent.Patent
{
    /// <summary>
    /// Логика взаимодействия для FormPatent.xaml
    /// </summary>
    public partial class FormPatent : UserControl
    {
        public FormPatent()
        {
           
            InitializeComponent();
            DataContext = new DataContext.DataContextPatent();
        }
    }
}
