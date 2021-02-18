using System.Windows.Controls;


namespace AutomatAis3Full.Form.Automat.Okp2.UserTask.TaxApprove.TaxApprove
{
    /// <summary>
    /// Логика взаимодействия для VeiwTaxApprove.xaml
    /// </summary>
    public partial class ViewTaxApprove : UserControl
    {


        public ViewTaxApprove()
        {
            InitializeComponent();
            DataContext = new DataContext.DataContextTaxApprove();
        }
    }
}
