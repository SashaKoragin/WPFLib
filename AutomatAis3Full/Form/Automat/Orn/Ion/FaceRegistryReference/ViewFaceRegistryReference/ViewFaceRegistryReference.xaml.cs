using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace AutomatAis3Full.Form.Automat.Orn.Ion.FaceRegistryReference.ViewFaceRegistryReference
{
    /// <summary>
    /// Логика взаимодействия для ViewFaceRegistryReference.xaml
    /// </summary>
    public partial class ViewFaceRegistryReference : UserControl
    {
        public ViewFaceRegistryReference()
        {
            InitializeComponent();
            DataContext = new DataContextFaceRegistryReference.DataContextFaceRegistryReference();
        }
    }
}
