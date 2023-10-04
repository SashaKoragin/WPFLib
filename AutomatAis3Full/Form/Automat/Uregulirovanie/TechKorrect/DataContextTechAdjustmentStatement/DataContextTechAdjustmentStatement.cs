using System.Windows.Input;
using AutomatAis3Full.Config;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.ModelSnuOneAuto.DataXml;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Uregulirovanie.TechKorrect.DataContextTechAdjustmentStatement
{
    public class DataContextTechAdjustmentStatement
    {
        public StatusButtonMethod StartButton { get; }
        public XmlUseMethod Xml { get; }

        public ICommand Update { get; }

        public DataContextTechAdjustmentStatement()
        {
            Xml = new XmlUseMethod();
            StartButton = new StatusButtonMethod();
            var commandAuto = new LibraryCommandPublic.TestAutoit.Uregulirovanie.MessageLk.AutoMessageLk();
            StartButton.Button.Command = new DelegateCommand(() => { commandAuto.TechAdjustmentStatement(StartButton, ConfigFile.AllListModel); });
            Update = new DelegateCommand(() => { Xml.UpdateFileXml(ConfigFile.AllListModel); });
        }

    }
}
