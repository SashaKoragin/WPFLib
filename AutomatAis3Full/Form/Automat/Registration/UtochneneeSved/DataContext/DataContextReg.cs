using Prism.Commands;
using System.Windows.Input;
using AutomatAis3Full.Config;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Registration.UtochneneeSved.DataContext
{
   public class DataContextReg
    {
        public StatusButtonMethod StartButton1 { get; }
        public ICommand Green { get; }
        public ICommand Yellow { get; }
        public DataContextReg()
        {
            var commandauto = new LibaryCommandPublic.TestAutoit.Reg.YtochnenieSved.AutoCommand.YtochnenieSved();
            StartButton1 = new StatusButtonMethod();
            StartButton1.Button.Command = new DelegateCommand(() => { commandauto.Ytochnenie(StartButton1, ConfigFile.FileJurnalError, ConfigFile.FileJurnalOk); });
            Yellow = new DelegateCommand(() => { Yellows(StartButton1); });
            Green = new DelegateCommand(() => { Greens(StartButton1); });
        }

        public void Yellows(StatusButtonMethod status)
        {
            status.StatusYellow();
        }
        public void Greens(StatusButtonMethod status)
        {
            status.StatusGrin();
        }

    }
}
