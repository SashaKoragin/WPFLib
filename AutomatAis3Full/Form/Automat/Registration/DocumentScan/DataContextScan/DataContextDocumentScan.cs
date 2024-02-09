using LibraryCommandPublic.TestAutoit.Reg.VisualTreatmentFace;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Registration.DocumentScan.DataContextScan
{
    public class DataContextDocumentScan
    {
        /// <summary>
        /// Кнопка старт автомат
        /// </summary>
        public StatusButtonMethod StartButton { get; }
        /// <summary>
        /// Автомат для ветки Налоговое администрирование\Централизованная система регистрации\Электронный архив\Запросить электронные образы документов дела из архива(преобразование) 
        /// </summary>
        public DataContextDocumentScan()
        {
            var visualTreatment = new VisualTreatmentFace();
            StartButton = new StatusButtonMethod();
            StartButton.Button.Command = new DelegateCommand(() => { visualTreatment.ScanDocuments(StartButton); });
        }
    }
}
