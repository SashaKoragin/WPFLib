using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Uregulirovanie.TechKorrectAgreement.DataContextTechKorrectAgreement
{
    public class DataContextTechKorrectAgreement
    {
        public StatusButtonMethod StartButton { get; }

        public DataContextTechKorrectAgreement()
        {
            StartButton = new StatusButtonMethod();
            var commandAuto = new LibraryCommandPublic.TestAutoit.Uregulirovanie.MessageLk.AutoMessageLk();
            StartButton.Button.Command = new DelegateCommand(() => { commandAuto.TechAdjustmentAgreement(StartButton); });
        }
    }
}
