using LibraryCommandPublic.TestAutoit.Okp6.JournalDoc;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Okp6.DeclarationComplex.DataContextDeclarationComplex
{
    public class DataContextDeclarationComplex
    {
        /// <summary>
        /// Кнопка старт
        /// </summary>
        public StatusButtonMethod StartButton { get; }

        /// <summary>
        /// Дата контекст закрытие комплекса мероприятий
        /// </summary>
        public DataContextDeclarationComplex()
        {
            var docStart = new AutoJournalDoc();
            StartButton = new StatusButtonMethod
            {
                Button = { Command = new DelegateCommand(() => { docStart.StartDeclarationComplexClosed(StartButton); }) }
            };
        }
    }
}
