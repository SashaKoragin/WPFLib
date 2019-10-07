using System;
using System.Windows.Controls;


namespace AutomatAis3Full.Form.Automat.Registration.Journal.ReceivedDocument.ReceivedDocuments
{
    /// <summary>
    /// Логика взаимодействия для ReceivedDocuments.xaml
    /// </summary>
    public partial class ReceivedDocuments : UserControl
    {
        public ReceivedDocuments(LibaryCommandPublic.TestAutoit.Reg.YtochnenieSved.AutoCommand.YtochnenieSved ytochnenieSved)
        {
            InitializeComponent();
            DataContext = new DataContext.DataContextReceivedDocuments(ytochnenieSved);
        }
    }
}
