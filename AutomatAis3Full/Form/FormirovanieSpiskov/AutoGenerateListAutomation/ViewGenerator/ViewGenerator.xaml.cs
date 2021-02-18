using System.Windows;
using System.Windows.Controls;
using AutomatAis3Full.Form.FormirovanieSpiskov.AutoGenerateListAutomation.DataContext;


namespace AutomatAis3Full.Form.FormirovanieSpiskov.AutoGenerateListAutomation.ViewGenerator
{
    /// <summary>
    /// Логика взаимодействия для ViewGenerator.xaml
    /// </summary>
    public partial class ViewGenerator : UserControl
    {

        private readonly DataContextGenerator _context = new DataContextGenerator();
        public ViewGenerator()
        {
            InitializeComponent();
            DataContext = _context;
        }

        private void ListView_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[]) e.Data.GetData(DataFormats.FileDrop);
                _context.ModelXlsx.AddFiles(files);
            }
        }
    }
}
