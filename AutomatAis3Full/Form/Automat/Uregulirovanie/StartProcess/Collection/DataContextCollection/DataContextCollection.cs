using System.Windows.Input;
using AutomatAis3Full.Config;
using LibraryCommandPublic.TestAutoit.Uregulirovanie.MessageLk;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.ModelSnuOneAuto.DataXml;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Uregulirovanie.StartProcess.Collection.DataContextCollection
{
    public class DataContextCollection
    {
        public StatusButtonMethod StartButton { get; }
        public XmlUseMethod Xml { get; }

        public ICommand Update { get; }

        public DataContextCollection()
        {
            Xml = new XmlUseMethod();
            var bpAuto = new AutoMessageLk();
            StartButton = new StatusButtonMethod();
            StartButton.Button.Command = new DelegateCommand(() =>
            {
                bpAuto.StartProcessCollection(StartButton, ConfigFile.AllListModel);
            });
            Update = new DelegateCommand(() => { Xml.UpdateFileXml(ConfigFile.AllListModel); });
        }
    }
}
