using System.Windows.Controls;

namespace AutomatAis3Full.Form.Automat.Okp6.JournalDoc.ViewJournalDoc
{
    /// <summary>
    /// Логика взаимодействия для JourrnalDocView.xaml
    /// </summary>
    public partial class JourrnalDocView : UserControl
    {
        public JourrnalDocView()
        {
            InitializeComponent();
            DataContext = new DataContextJournalDoc.DataContextJourrnalDoc();
        }
    }
}
