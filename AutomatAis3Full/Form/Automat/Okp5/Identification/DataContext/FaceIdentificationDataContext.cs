using System.Collections.Generic;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using LibraryCommandPublic.TestAutoit.Okp5.Identification;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using ViewModelLib.ModelTestAutoit.PublicModel.PublicModelCollectionSelect;

namespace AutomatAis3Full.Form.Automat.Okp5.Identification.DataContext
{
   public class FaceIdentificationDataContext
    {
        /// <summary>
        /// Параметры выборки Модели Признак выборки
        /// </summary>
        public List<UniversalCollection> ListParameter  = new List<UniversalCollection>()
        {
         new UniversalCollection() {NameParameter  = "Отсутствует",Parameter = null},
         new UniversalCollection() { NameParameter = "Признак 1",Parameter = 1},
         new UniversalCollection() { NameParameter = "Признак 2",Parameter = 2},
         new UniversalCollection() { NameParameter = "Признак 3",Parameter = 3},
         new UniversalCollection() { NameParameter = "Признак 4",Parameter = 4},
        };

        public StatusButtonMethod StartButton { get; }

        public PublicModelCollectionSelect<UniversalCollection> ModelSelect {get; }
        /// <summary>
        /// VM DataContext
        /// </summary>
        public FaceIdentificationDataContext()
        {
            ModelSelect = new PublicModelCollectionSelect<UniversalCollection>(ListParameter);
            var command = new IdentificationFace();
            StartButton = new StatusButtonMethod();
            StartButton.Button.Command = new DelegateCommand(() => { command.StartIdentification(StartButton, ModelSelect); });
        }
    }
}
