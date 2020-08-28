using AutomatAis3Full.Config;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Uregulirovanie.RequirementsLog.DataContext
{
   public class DataContextRequirementsLog
    {

        public StatusButtonMethod StartButton { get; }

        public DataContextRequirementsLog()
        {
            StartButton = new StatusButtonMethod();
            var commandauto = new LibraryCommandPublic.TestAutoit.Uregulirovanie.MessageLk.AutoMessageLk();
            StartButton.Button.Command = new DelegateCommand(() => { commandauto.AutoRequirementsLog(StartButton, ConfigFile.FileJurnalError, ConfigFile.FileJurnalOk); });
        }
    }
}
