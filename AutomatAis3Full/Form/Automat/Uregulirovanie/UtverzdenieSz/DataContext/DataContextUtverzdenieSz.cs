using AutomatAis3Full.Config;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Uregulirovanie.UtverzdenieSz.DataContext
{
   public class DataContextUtverzdenieSz
    {

        public StatusButtonMethod StartButton { get; }

        public DataContextUtverzdenieSz()
        {
            StartButton = new StatusButtonMethod();
            var commandauto = new LibaryCommandPublic.TestAutoit.Uregulirovanie.UtverzdenieSz.AutoStart();
            StartButton.Button.Command = new DelegateCommand(() => { commandauto.UtberzdenieSz(StartButton, ConfigFile.FileJurnalError, ConfigFile.FileJurnalOk); });
        }
    }
}
