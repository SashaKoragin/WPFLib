using System.Windows.Controls;


namespace AutomatAis3Full.Form.Automat.Okp1.EasJournal.EasJournal
{
    /// <summary>
    /// Логика взаимодействия для FormEasJournal.xaml
    /// </summary>
    public partial class FormEasJournal : UserControl
    {
        public FormEasJournal()
        {
            InitializeComponent();
            DataContext = new DataContext.DataContextEasJournal();
        }
    }
}
