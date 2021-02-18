using AutomatAis3Full.Config;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Okp2.UserTask.TaxApprove.DataContext
{
   public class DataContextTaxApprove
    {


        public StatusButtonMethod StartButton { get; }

        public DataContextTaxApprove()
        {
            StartButton = new StatusButtonMethod();
            var command = new LibraryCommandPublic.TestAutoit.Okp2.TaxJournal();
            StartButton.Button.Command = new DelegateCommand(() => {
                command.StartTaxApprove(StartButton);
            });
        }
    }
}
