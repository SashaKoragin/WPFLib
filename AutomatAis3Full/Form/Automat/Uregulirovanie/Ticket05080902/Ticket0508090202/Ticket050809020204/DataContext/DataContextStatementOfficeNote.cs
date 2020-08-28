
using AutomatAis3Full.Config;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Uregulirovanie.Ticket05080902.Ticket0508090202.Ticket050809020204.DataContext
{
   public class DataContextStatementOfficeNote
    {
        public StatusButtonMethod StartButton { get; }

        public DataContextStatementOfficeNote()
        {
            StartButton = new StatusButtonMethod();
            var commandAuto = new LibraryCommandPublic.TestAutoit.Uregulirovanie.MessageLk.AutoMessageLk();
            StartButton.Button.Command = new DelegateCommand(() => { commandAuto.AutoStatementOfficeNote(StartButton, ConfigFile.FileJurnalError, ConfigFile.FileJurnalOk); });
        }

    }
}
