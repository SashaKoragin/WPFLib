using System.Windows.Controls;

namespace AutomatAis3Full.Form.Automat.Orn.IonSend.FaceRegistryReferenceSend.ViewFaceRegistryReferenceSend
{
    /// <summary>
    /// Логика взаимодействия для ViewFaceRegistryReference.xaml
    /// </summary>
    public partial class ViewFaceRegistryReferenceSend : UserControl
    {
        public ViewFaceRegistryReferenceSend()
        {
            InitializeComponent();
            DataContext = new DataContextFaceRegistryReferenceSend.DataContextFaceRegistryReferenceSend();
        }
    }
}
