using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AutomatAis3Full.Config;
using LibraryCommandPublic.TestAutoit.Reg.VisualBank;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.ModelSnuOneAuto.DataXml;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Registration.VisualBank.DataContext
{
   public class DataContextVisualBank
    {
        public XmlUseMethod Xml { get; }
        public StatusButtonMethod StartButton { get; }

        public ICommand Update { get; }
        public DataContextVisualBank()
        {
            StartButton = new StatusButtonMethod();
            var visual = new VisualBankMessages();
            Xml = new XmlUseMethod();
            Update = new DelegateCommand(() => { Xml.UpdateFileXml(ConfigFile.VisualId); });
            StartButton.Button.Command = new DelegateCommand(() => { visual.StartVisualBank(StartButton, ConfigFile.VisualId, ConfigFile.FileJurnalError, ConfigFile.FileJurnalOk); });
        }
    }
}
