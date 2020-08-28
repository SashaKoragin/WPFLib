using System.Windows.Input;
using AutomatAis3Full.Config;
using LibraryCommandPublic.TestAutoit.Reg.TechinicalUpdate;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.ModelSnuOneAuto.DataXml;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Registration.TehnicalUpdate.DataContext
{
   public class DataContextTehnical
    {
        public XmlUseMethod Xml { get; }
        public StatusButtonMethod StartButton { get; }
        public ICommand Update { get; }

        public DataContextTehnical()
        {
            var commandauto = new TchinicalUpdate();
            StartButton = new StatusButtonMethod();
            Xml = new XmlUseMethod();
            StartButton.Button.Command = new DelegateCommand((() => { commandauto.Update(StartButton, ConfigFile.FidFace, ConfigFile.FileJurnalError, ConfigFile.FileJurnalOk); }));
            Update = new DelegateCommand(() => { Xml.UpdateFileXml(ConfigFile.FidFace); });
        }
    }
}
