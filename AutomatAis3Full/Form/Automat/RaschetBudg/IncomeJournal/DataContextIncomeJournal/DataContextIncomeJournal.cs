using System.Windows.Input;
using AutomatAis3Full.Config;
using LibraryCommandPublic.TestAutoit.RaschBydj.Krsb;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.ModelSnuOneAuto.DataXml;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.RaschetBudg.IncomeJournal.DataContextIncomeJournal
{
    public class DataContextIncomeJournal
    {
        public StatusButtonMethod StartButton { get; }

        public XmlUseMethod Xml { get; }

        public ICommand Update { get; }

        public DataContextIncomeJournal()
        {
            Xml = new XmlUseMethod();
            StartButton = new StatusButtonMethod();
            var krsb = new StartKrsb();
            StartButton.Button.Command = new DelegateCommand(() => { krsb.IncomeJournalStart(StartButton, ConfigFile.AllListModel); });
            Update = new DelegateCommand(() => { Xml.UpdateFileXml(ConfigFile.AllListModel); });
        }
    }
}
