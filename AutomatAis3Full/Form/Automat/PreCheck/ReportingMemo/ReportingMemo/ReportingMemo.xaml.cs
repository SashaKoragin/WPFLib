using System.Windows.Controls;
using AutomatAis3Full.Form.Automat.PreCheck.ReportingMemo.DataContext;

namespace AutomatAis3Full.Form.Automat.PreCheck.ReportingMemo.ReportingMemo
{
    /// <summary>
    /// Логика взаимодействия для ReportingMemo.xaml
    /// </summary>
    public partial class ReportingMemo : UserControl
    {
        public ReportingMemo()
        {
            InitializeComponent();
            DataContext = new ReportingMemoContext();
        }
    }
}
