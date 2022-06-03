using LibraryCommandPublic.TestAutoit.Okp6.JournalDoc;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Okp6.AddTerm.DataContextAddTerm
{
   public class DataContextAddTerm
    {
        /// <summary>
        /// Кнопка старт
        /// </summary>
        public StatusButtonMethod StartButton { get; }
        public DataContextAddTerm()
        {
            var docStart = new AutoJournalDoc();
            StartButton = new StatusButtonMethod
            {
                Button = { Command = new DelegateCommand(() => { docStart.StartAddTerm(StartButton); }) }
            };
        }
    }
}
