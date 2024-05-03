using AisPoco.UserLoginScan;
using AutomatAis3Full.Config;
using LibraryCommandPublic.TestAutoit.Reg.VisualTreatmentFace;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using ViewModelLib.ModelTestAutoit.PublicModel.PublicModelCollectionSelect;

namespace AutomatAis3Full.Form.Automat.Registration.DocumentScan.DataContextScan
{
    public class DataContextDocumentScan
    {
        /// <summary>
        /// Кнопка старт автомат
        /// </summary>
        public StatusButtonMethod StartButton { get; }

        public PublicModelCollectionSelect<UserLoginDatabaseModel> ModelTemplate { get; }

        public DelegateCommand<object> SelectModelTemplate { get; }
        public DelegateCommand<object> DeleteModelTemplate { get; }
        /// <summary>
        /// Автомат для ветки Налоговое администрирование\Централизованная система регистрации\Электронный архив\Запросить электронные образы документов дела из архива(преобразование) 
        /// </summary>
        public DataContextDocumentScan()
        {
            var visualTreatment = new VisualTreatmentFace();
            var model = ConfigFile.ResultGetTemplate<UserLoginDatabaseModel>(ConfigFile.AllUserScan);
            ModelTemplate = new PublicModelCollectionSelect<UserLoginDatabaseModel>(model);
            StartButton = new StatusButtonMethod();
            StartButton.Button.Command = new DelegateCommand(() => { visualTreatment.ScanDocuments(StartButton, ModelTemplate); });
            SelectModelTemplate = new DelegateCommand<object>(param => { ModelTemplate.SelectModelTemplate(param); });
            DeleteModelTemplate = new DelegateCommand<object>(param => { ModelTemplate.DeleteModelTemplate(param); });
        }
    }
}
