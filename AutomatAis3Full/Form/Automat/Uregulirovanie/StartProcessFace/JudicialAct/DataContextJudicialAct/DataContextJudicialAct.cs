using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AutomatAis3Full.Config;
using LibraryCommandPublic.TestAutoit.Uregulirovanie.MessageLk;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.ModelSnuOneAuto.DataXml;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Uregulirovanie.StartProcessFace.JudicialAct.DataContextJudicialAct
{
    public class DataContextJudicialAct
    {
        public StatusButtonMethod StartButton { get; }
        public XmlUseMethod Xml { get; }

        public ICommand Update { get; }

        public DataContextJudicialAct()
        {
            Xml = new XmlUseMethod();
            var command = new AutoMessageLk();
            StartButton = new StatusButtonMethod();
            StartButton.Button.Command = new DelegateCommand(() => { command.StartProcessAct(StartButton, ConfigFile.AllListModel); });
            Update = new DelegateCommand(() => { Xml.UpdateFileXml(ConfigFile.AllListModel); });
        }
    }
}
