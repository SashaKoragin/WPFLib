using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AutomatAis3Full.Config;
using LibaryCommandPublic.TestAutoit.Okp4.SnuOneAuto.AutoCommand;
using LibaryCommandPublic.TestAutoit.SnuOneAuto.PublicCommand;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.ModelSnuOneAuto.DataXml;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using ViewModelLib.ModelTestAutoit.PublicModel.ReportXlsx;
using ViewModelLib.ModelTestAutoit.PublicModel.ReportXml;

namespace AutomatAis3Full.Form.Automat.Okp4.FormSnuAuto.DataContext
{
   public class DataContextSnuAuto
    {
        public XmlUseMethod Xml { get; }
        public ICommand Update { get; }
        public StatusButtonMethod StartButton { get; }
        public ICommand Green { get; }
        public ICommand Yellow { get; }

        public DataContextSnuAuto()
        {
            var commandauto = new AutoCklicsAisCommand();
            StartButton = new StatusButtonMethod();
            Xml = new XmlUseMethod();
            StartButton.Button.Command = new DelegateCommand(() => { commandauto.AutoClicerSnuOneForm(StartButton, ConfigFile.FileInn, ConfigFile.FileJurnalError, ConfigFile.FileJurnalOk); });
            Yellow = new DelegateCommand(() => { Yellows(StartButton); });
            Green = new DelegateCommand(() => { Greens(StartButton); });
            Update = new DelegateCommand(() => { Xml.UpdateFileXml(ConfigFile.FileInn); });
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
