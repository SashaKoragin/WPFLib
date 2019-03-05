using System.Windows.Input;
using AutomatAis3Full.Config;
using LibaryCommandPublic.TestAutoit.Okp4.EditPravo.Pravo;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.ModelSnuOneAuto.DataXml;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Okp4.PravoEdit.DataContext
{
   public class PravoEditDataContext
    {
        public XmlUseMethod Xml { get; }
        public ICommand Update { get; }
        public StatusButtonMethod StartButton { get; }

        public PravoEditDataContext()
        {
            var commandauto = new CommandPravo();
            StartButton = new StatusButtonMethod();
            Xml = new XmlUseMethod();
            StartButton.Button.Command = new DelegateCommand((() => { commandauto.AutoClicerEditPravo(StartButton, ConfigFile.FileFid, ConfigFile.FileJurnalError, ConfigFile.FileJurnalOk); }));
            Update = new DelegateCommand(() => { Xml.UpdateFileXml(ConfigFile.FileFid); });
        }
    }
}
