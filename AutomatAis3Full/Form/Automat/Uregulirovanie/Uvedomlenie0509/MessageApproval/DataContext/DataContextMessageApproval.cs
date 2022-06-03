using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Uregulirovanie.Uvedomlenie0509.MessageApproval.DataContext
{
   public class DataContextMessageApproval
    {

        public StatusButtonMethod StartButton { get; }

        public DataContextMessageApproval()
        {
            StartButton = new StatusButtonMethod();
            var commandAuto = new LibraryCommandPublic.TestAutoit.Uregulirovanie.MessageLk.AutoMessageLk();
            StartButton.Button.Command = new DelegateCommand(() => {commandAuto.MessageApprovalAndDecisionsApproval(StartButton); });
        }
    }
}
