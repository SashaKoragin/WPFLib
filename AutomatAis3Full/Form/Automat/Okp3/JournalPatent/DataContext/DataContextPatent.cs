using AutomatAis3Full.Config;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using ViewModelLib.ModelTestAutoit.PublicModel.DataPickerItRule;
using ViewModelLib.ModelTestAutoit.PublicModel.QbeSelect;

namespace AutomatAis3Full.Form.Automat.Okp3.JournalPatent.DataContext
{
   public class DataContextPatent
    {

        public StatusButtonMethod StartButton { get; }

        

        public DataContextPatent()
        {
            var command = new LibraryCommandPublic.TestAutoit.Okp3.Patent.Patent();
            StartButton = new StatusButtonMethod();
            StartButton.Button.Command = new DelegateCommand(() => { command.PatentParsing(StartButton, ConfigFile.PathTemp); });
        }
    }
}

