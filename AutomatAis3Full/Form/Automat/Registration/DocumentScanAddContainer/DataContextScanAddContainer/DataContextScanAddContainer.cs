using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryCommandPublic.TestAutoit.Reg.VisualTreatmentFace;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Registration.DocumentScanAddContainer.DataContextScanAddContainer
{
    public class DataContextScanAddContainer
    {
        /// <summary>
        /// Кнопка старт автомат
        /// </summary>
        public StatusButtonMethod StartButton { get; }
        /// <summary>
        /// Автомат на ветку Налоговое администрирование\Документооборот\Передача документов\Комплектование тары
        /// </summary>
        public DataContextScanAddContainer()
        {
            var visualTreatment = new VisualTreatmentFace();
            StartButton = new StatusButtonMethod();
            StartButton.Button.Command = new DelegateCommand(() => { visualTreatment.ScanAddContainer(StartButton); });
        }
    }
}
