using AutomatAis3Full.Config;
using LibraryCommandPublic.TestAutoit.Okp6.JournalDoc;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Okp6.DeclarationCalculation.DataContextDeclarationCalculation
{
   public class DataContextDeclarationCalculation
    {

        /// <summary>
        /// Кнопка старт
        /// </summary>
        public StatusButtonMethod StartButton { get; }
        public DataContextDeclarationCalculation()
        {
            var docStart = new AutoJournalDoc();
            StartButton = new StatusButtonMethod
            {
                Button = { Command = new DelegateCommand(() => { docStart.StartDeclarationCalculation(StartButton, ConfigFile.PathTemp); }) }
            };
        }
    }
}
