using AutomatAis3Full.Config;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Uregulirovanie.Uvedomlenie0509.RenouncementLk.DataContext
{
   public class DataContextRecouncementLk
    {
        public StatusButtonMethod StartButton { get; }
        /// <summary>
        /// Автомат отказов ЛК
        /// </summary>
        public DataContextRecouncementLk()
        {
            StartButton = new StatusButtonMethod();
            var commandauto = new LibaryCommandPublic.TestAutoit.Uregulirovanie.MessageLk.AutoMessageLk();
            StartButton.Button.Command = new DelegateCommand(() => { commandauto.RecouncementLk(StartButton, ConfigFile.FileJurnalError, ConfigFile.FileJurnalOk); });
        }

    }
}
