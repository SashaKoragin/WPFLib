using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AutomatAis3Full.Config;
using LibraryCommandPublic.TestAutoit.Okp5.Identification;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.ModelSnuOneAuto.DataXml;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Registration.AcceptanceDocuments.DataContext
{
   public class DataContextAcceptanceDocuments
    {

        public StatusButtonMethod StartButton { get; }
        public XmlUseMethod Xml { get; }

        public ICommand Update { get; }

        public DataContextAcceptanceDocuments()
        {
            Xml = new XmlUseMethod();
            var command = new LibraryCommandPublic.TestAutoit.Reg.AcceptanceDocuments.AcceptanceDocuments();
            StartButton = new StatusButtonMethod();
            StartButton.Button.Command = new DelegateCommand(() => { command.StartAcceptanceDocuments(StartButton, ConfigFile.AllListModel); });
            Update = new DelegateCommand(() => { Xml.UpdateFileXml(ConfigFile.AllListModel); });
        }

    }
}
