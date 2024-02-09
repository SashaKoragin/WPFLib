using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AisPoco.Ifns51.ToAis;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using ViewModelLib.ModelTestAutoit.PublicModel.PublicModelCollectionSelect;

namespace AutomatAis3Full.Form.Automat.Kao.InterrogationOfWitnesses.InterrogationOfWitnessesDataContext
{
    public class InterrogationOfWitnessesDataContext
    {
        /// <summary>
        /// Кнопка старт автомат
        /// </summary>
        public StatusButtonMethod StartButton { get; }
        /// <summary>
        /// Модель подписантов
        /// </summary>
        public PublicModelCollectionSelect<TemplateModel> ModelTemplate { get; }
        public DelegateCommand<object> SelectModelTemplate { get; }
        public DelegateCommand<object> DeleteModelTemplate { get; }
        /// <summary>
        /// Дата контекст
        /// </summary>
        public InterrogationOfWitnessesDataContext()
        {
            var senderList = new List<TemplateModel>();
            senderList.Add(new TemplateModel(){IdTemplate = 17019218, NameTemplate = "Юрковский А.В.", DateCreate = DateTime.Now});
            senderList.Add(new TemplateModel() { IdTemplate = 17019220, NameTemplate = "Чукалкин В.Г.", DateCreate = DateTime.Now });
            var command = new LibraryCommandPublic.TestAutoit.Kao.InterrogationOfWitnesses();
            ModelTemplate = new PublicModelCollectionSelect<TemplateModel>(senderList);
            StartButton = new StatusButtonMethod();
            StartButton.Button.Command = new DelegateCommand(() => { command.StartInterrogationOfWitnesses(StartButton, ModelTemplate); });
            SelectModelTemplate = new DelegateCommand<object>(param => { ModelTemplate.SelectModelTemplate(param); });
            DeleteModelTemplate = new DelegateCommand<object>(param => { ModelTemplate.DeleteModelTemplate(param); });
        }
    }
}
