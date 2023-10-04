using System.Windows.Input;
using AutomatAis3Full.Config;
using LibraryCommandPublic.TestAutoit.Okp6.JournalDoc;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.ModelFormirovanie.ListYearReport;
using ViewModelLib.ModelTestAutoit.ModelSnuOneAuto.DataXml;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Okp6.DocumentOwnerFact.OwnerFactIm.DataContextOwnerFactIm
{
    public class DataContextOwnerFactIm
    {
        public StatusButtonMethod StartButton { get; }

        public ListYearReport ListYearReport { get; }


        public XmlUseMethod Xml { get; }

        public ICommand Update { get; }

        public DataContextOwnerFactIm()
        {
            Xml = new XmlUseMethod();
            ListYearReport = new ListYearReport();
            StartButton = new StatusButtonMethod();
            var docStart = new AutoJournalDoc();
            StartButton.Button.Command = new DelegateCommand(() => { docStart.FindOwnerFactFlIm(StartButton, ListYearReport, ConfigFile.AllListModel, ConfigFile.PathTemp); });
            Update = new DelegateCommand(() => { Xml.UpdateFileXml(ConfigFile.AllListModel); });
        }
    }
}
