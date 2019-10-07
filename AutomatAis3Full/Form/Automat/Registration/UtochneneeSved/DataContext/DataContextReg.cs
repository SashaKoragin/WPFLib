using Prism.Commands;
using LibaryCommandPublic.TestAutoit.Reg.YtochnenieSved.AutoCommand;
using AutomatAis3Full.Config;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Registration.UtochneneeSved.DataContext
{
   public class DataContextReg
    {
        public StatusButtonMethod StartButton { get; }
        public DataContextReg(YtochnenieSved ytochnenieSved)
        {
            StartButton = new StatusButtonMethod();
            StartButton.Button.Command = new DelegateCommand(() => { ytochnenieSved.Ytochnenie(StartButton, ConfigFile.FileJurnalError, ConfigFile.FileJurnalOk); });
        }
    }
}
