using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AutomatAis3Full.Config;
using LibaryCommandPublic.TestAutoit.Okp4.SnuOneAuto.AutoCommand;
using LibaryCommandPublic.TestAutoit.Reg.Status;
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
        public ICommand Green { get; }
        public ICommand Yellow { get; }

        public DataContextActual()
        {
            var commandauto = new StatusReg();
            StartButton = new StatusButtonMethod();
            Xml = new XmlUseMethod();
            StartButton.Button.Command = new DelegateCommand((() => { commandauto.StateReg(StartButton,ConfigFile.FidFace,ConfigFile.FileJurnalError,ConfigFile.FileJurnalOk); }));
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
