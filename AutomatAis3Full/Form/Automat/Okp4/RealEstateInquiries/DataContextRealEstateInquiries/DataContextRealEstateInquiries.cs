using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AutomatAis3Full.Config;
using LibraryCommandPublic.TestAutoit.Okp4.SnuOneAuto.AutoCommand;
using LibraryCommandPublic.TestAutoit.Uregulirovanie.MessageLk;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.ModelSnuOneAuto.DataXml;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Okp4.RealEstateInquiries.DataContextRealEstateInquiries
{
    public class DataContextRealEstateInquiries
    {
        public StatusButtonMethod StartButton { get; }
        public XmlUseMethod Xml { get; }

        public ICommand Update { get; }

        public DataContextRealEstateInquiries()
        {
            Xml = new XmlUseMethod();
            var commandAuto = new AutoCklicsAisCommand();
            StartButton = new StatusButtonMethod();
            StartButton.Button.Command = new DelegateCommand(() =>
            {
                commandAuto.StartRealEstateInquiries(StartButton, ConfigFile.AllListModel);
            });
            Update = new DelegateCommand(() => { Xml.UpdateFileXml(ConfigFile.AllListModel); });
        }
    }
}
