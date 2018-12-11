using System.Windows.Input;
using AutomatAis3Full.Config;
using LibaryCommandPublic.TestAutoit.Reg.TechinicalUpdate;
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
        public ICommand Green { get; }
        public ICommand Yellow { get; }

        public DataContextTehnical()
        {
            var commandauto = new TchinicalUpdate();
            StartButton = new StatusButtonMethod();
            Xml = new XmlUseMethod();
            StartButton.Button.Command = new DelegateCommand((() => { commandauto.Update(StartButton, ConfigFile.FidFace, ConfigFile.FileJurnalError, ConfigFile.FileJurnalOk); }));
            Yellow = new DelegateCommand(() => { Yellows(StartButton); });
            Green = new DelegateCommand(() => { Greens(StartButton); });
            Update = new DelegateCommand(() => { Xml.UpdateFileXml(ConfigFile.FidFace); });
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
