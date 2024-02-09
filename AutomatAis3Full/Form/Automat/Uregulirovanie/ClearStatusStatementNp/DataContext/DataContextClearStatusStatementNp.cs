using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Uregulirovanie.ClearStatusStatementNp.DataContext
{
    public class DataContextClearStatusStatementNp
    {

        public StatusButtonMethod StartButton { get; }

        public DataContextClearStatusStatementNp()
        {
            StartButton = new StatusButtonMethod();
            var commandAuto = new LibraryCommandPublic.TestAutoit.Uregulirovanie.MessageLk.AutoMessageLk();
            StartButton.Button.Command = new DelegateCommand(() => { commandAuto.StartClearStatusStatementNp(StartButton); });
        }

    }
}
