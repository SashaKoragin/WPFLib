using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Uregulirovanie.Uvedomlenie0509.DecisionsApproval.DataContext
{
    public class DataContextDecisionsApproval
    {
        public StatusButtonMethod StartButton { get; }

        public DataContextDecisionsApproval()
        {
            StartButton = new StatusButtonMethod();
            var commandAuto = new LibraryCommandPublic.TestAutoit.Uregulirovanie.MessageLk.AutoMessageLk();
            StartButton.Button.Command = new DelegateCommand(() => { commandAuto.MessageApprovalAndDecisionsApproval(StartButton); });
        }
    }
}
