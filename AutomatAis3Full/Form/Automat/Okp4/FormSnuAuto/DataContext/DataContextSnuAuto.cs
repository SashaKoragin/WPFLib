using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AutomatAis3Full.Config;
using LibraryCommandPublic.TestAutoit.Okp4.SnuOneAuto.AutoCommand;
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

        public DataContextSnuAuto()
        {
            var commandauto = new AutoCklicsAisCommand();
            StartButton = new StatusButtonMethod();
            Xml = new XmlUseMethod();
            StartButton.Button.Command = new DelegateCommand(() => { commandauto.AutoClicerSnuOneForm(StartButton, ConfigFile.FileInn, ConfigFile.FileJurnalError, ConfigFile.FileJurnalOk); });
            Update = new DelegateCommand(() => { Xml.UpdateFileXml(ConfigFile.FileInn); });
        }

    }
}
