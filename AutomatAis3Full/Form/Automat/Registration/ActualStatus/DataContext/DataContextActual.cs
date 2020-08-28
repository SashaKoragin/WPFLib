using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AutomatAis3Full.Config;
using LibraryCommandPublic.TestAutoit.Okp4.SnuOneAuto.AutoCommand;
using LibraryCommandPublic.TestAutoit.Reg.Status;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.ModelSnuOneAuto.DataXml;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Registration.ActualStatus.DataContext
{
   public class DataContextActual
    {
        public XmlUseMethod Xml { get; }
        public StatusButtonMethod StartButton { get; }
        public ICommand Update { get; }

        public DataContextActual()
        {
            var commandauto = new StatusReg();
            StartButton = new StatusButtonMethod();
            Xml = new XmlUseMethod();
            StartButton.Button.Command = new DelegateCommand((() => { commandauto.StateReg(StartButton,ConfigFile.FidFace,ConfigFile.FileJurnalError,ConfigFile.FileJurnalOk); }));
            Update = new DelegateCommand(() => { Xml.UpdateFileXml(ConfigFile.FidFace); });
        }
    }
}
