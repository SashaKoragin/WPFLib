using Prism.Commands;
using System.Windows.Input;
using AutomatAis3Full.Config;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Registration.UtochneneeSved.DataContext
{
   public class DataContextReg
    {
        public StatusButtonMethod StartButton1 { get; }
        public DataContextReg()
        {
            var commandauto = new LibaryCommandPublic.TestAutoit.Reg.YtochnenieSved.AutoCommand.YtochnenieSved();
            StartButton1 = new StatusButtonMethod();
            StartButton1.Button.Command = new DelegateCommand(() => { commandauto.Ytochnenie(StartButton1, ConfigFile.FileJurnalError, ConfigFile.FileJurnalOk); });
        }
    }
}
