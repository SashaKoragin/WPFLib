using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Uregulirovanie.StatementNp.DataContextStatementNp
{
   public class DataContextStatementNp
    {

        public StatusButtonMethod StartButton { get; }

        public DataContextStatementNp()
        {
            StartButton = new StatusButtonMethod();
            var commandAuto = new LibraryCommandPublic.TestAutoit.Uregulirovanie.MessageLk.AutoMessageLk();
            StartButton.Button.Command = new DelegateCommand(() => { commandAuto.StartProcessStatementNp(StartButton); });
        }

    }
}
