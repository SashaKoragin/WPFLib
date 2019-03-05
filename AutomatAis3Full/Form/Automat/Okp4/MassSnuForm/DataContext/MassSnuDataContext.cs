using System.Windows.Input;
using AutomatAis3Full.Config;
using LibaryCommandPublic.TestAutoit.Okp4.SnuOneAuto.AutoCommand;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.ModelSnuOneAuto.DataXml;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Okp4.MassSnuForm.DataContext
{
   public class MassSnuDataContext
    {
        public XmlUseMethod Xml2 { get; }
        public ICommand Update { get; }
        public StatusButtonMethod StartButton { get; }
        public MassSnuDataContext()
        {
            
            var commandauto = new AutoCklicsAisCommand();
            StartButton = new StatusButtonMethod();
            Xml2 = new XmlUseMethod();
            StartButton.Button.Command = new DelegateCommand((() => {commandauto.AutoClicerSnuMassInnForm(StartButton,ConfigFile.FileInnFull,ConfigFile.FileJurnalError,ConfigFile.FileJurnalOk);}));
            Update = new DelegateCommand(() => { Xml2.UpdateFileXml(ConfigFile.FileInnFull); });
        }
    }
}
