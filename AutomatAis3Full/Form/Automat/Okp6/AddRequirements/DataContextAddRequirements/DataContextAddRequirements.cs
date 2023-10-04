

using AutomatAis3Full.Config;
using LibraryCommandPublic.TestAutoit.Okp6.JournalDoc;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Okp6.AddRequirements.DataContextAddRequirements
{

    public class DataContextAddRequirements
    {
        /// <summary>
        /// Кнопка старт
        /// </summary>
        public StatusButtonMethod StartButton { get; }
        public DataContextAddRequirements()
        {
            var docStart = new AutoJournalDoc();
            StartButton = new StatusButtonMethod
            {
                Button = { Command = new DelegateCommand(() => { docStart.StartAddRequirements(StartButton, ConfigFile.PathTemp); }) }
            };
        }
    }
}
