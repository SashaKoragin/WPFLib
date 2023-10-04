using System.Windows.Input;
using AutomatAis3Full.Config;
using LibraryCommandPublic.TestAutoit.Okp6.JournalDoc;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.ModelFormirovanie.ListYearReport;
using ViewModelLib.ModelTestAutoit.ModelSnuOneAuto.DataXml;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Okp6.DocumentOwnerFact.OwnerFactZm.DataContextOwnerFactZm
{
    public class DataContextOwnerFactZm
    {
        public StatusButtonMethod StartButton { get; }

        public ListYearReport ListYearReport { get; }


        public XmlUseMethod Xml { get; }

        public ICommand Update { get; }

        public DataContextOwnerFactZm()
        {
            Xml = new XmlUseMethod();
            ListYearReport = new ListYearReport();
            StartButton = new StatusButtonMethod();
            var docStart = new AutoJournalDoc();
            StartButton.Button.Command = new DelegateCommand(() => { docStart.FindOwnerFactFlZm(StartButton, ListYearReport, ConfigFile.AllListModel, ConfigFile.PathTemp); });
            Update = new DelegateCommand(() => { Xml.UpdateFileXml(ConfigFile.AllListModel); });
        }

    }
}
