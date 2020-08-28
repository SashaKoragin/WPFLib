using AutomatAis3Full.Config;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Registration.Journal.ReceivedDocument.DataContext
{
   public class DataContextReceivedDocuments
    {
        public StatusButtonMethod StartButton { get; }

        public DataContextReceivedDocuments(LibraryCommandPublic.TestAutoit.Reg.YtochnenieSved.AutoCommand.YtochnenieSved ytochnenieSved)
        {
            StartButton = new StatusButtonMethod();
            StartButton.Button.Command = new DelegateCommand(() => { ytochnenieSved.JurnalReceivedDocument(StartButton, ConfigFile.FileJurnalOk); });
        }
    }
}
