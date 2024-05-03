using System.Windows.Input;
using AutomatAis3Full.Config;
using LibraryCommandPublic.TestAutoit.Uregulirovanie.MessageLk;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.ModelSnuOneAuto.DataXml;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Uregulirovanie.StartProcess.Requirement.DataContextRequirement
{
    public class DataContextRequirement
    {
        public StatusButtonMethod StartButton { get; }
        public XmlUseMethod Xml { get; }

        public ICommand Update { get; }

        public DataContextRequirement()
        {
            Xml = new XmlUseMethod();
            var bpAuto = new AutoMessageLk();
            StartButton = new StatusButtonMethod();
            StartButton.Button.Command = new DelegateCommand(() =>
            {
                bpAuto.StartProcessRequirement(StartButton, ConfigFile.AllListModel);
            });
            Update = new DelegateCommand(() => { Xml.UpdateFileXml(ConfigFile.AllListModel); });
        }
    }
}
