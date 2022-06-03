using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Uregulirovanie.Uvedomlenie0509.ApplicationManualProcessing.DataContext
{
    public class DataContextApplicationManualProcessing
    {

        public StatusButtonMethod StartButton { get; }

        public DataContextApplicationManualProcessing()
        {
            StartButton = new StatusButtonMethod();
            var commandAuto = new LibraryCommandPublic.TestAutoit.Uregulirovanie.MessageLk.AutoMessageLk();
            StartButton.Button.Command = new DelegateCommand(() => { commandAuto.ApplicationManualProcessing(StartButton); });
        }
    }
}
