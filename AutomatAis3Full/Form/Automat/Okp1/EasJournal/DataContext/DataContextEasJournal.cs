using AutomatAis3Full.Config;
using LibraryCommandPublic.TestAutoit.Okp5.Identification;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Okp1.EasJournal.DataContext
{
   public class DataContextEasJournal
    {
        public StatusButtonMethod StartButton { get; }

        public DataContextEasJournal()
        {
            var command = new IdentificationFace();
            StartButton = new StatusButtonMethod();
            StartButton.Button.Command = new DelegateCommand(() => { command.StartSubscribe(StartButton, ConfigFile.PathTemp); });
        }

    }
}
