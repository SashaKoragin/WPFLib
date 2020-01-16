using AutomatAis3Full.Config;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Uregulirovanie.Uvedomlenie0509.MessageLk.DataContext
{
   public class DataContextMessageLk
    {

        public StatusButtonMethod StartButton { get; }

        public DataContextMessageLk()
        {
            StartButton = new StatusButtonMethod();
            var commandauto = new LibaryCommandPublic.TestAutoit.Uregulirovanie.MessageLk.AutoMessageLk();
            StartButton.Button.Command = new DelegateCommand(() => { commandauto.MessageLk(StartButton, ConfigFile.FileJurnalError, ConfigFile.FileJurnalOk); });
        }
    }
}
