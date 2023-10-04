using AutomatAis3Full.Config;
using LibraryCommandPublic.TestAutoit.Reg.VisualTreatmentFace;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModelLib.ModelTestAutoit.ModelSnuOneAuto.DataXml;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Registration.IdentificationFace.IdentificationFl.DataContextIdentificationFl
{
    public class DataContextIdentificationFl
    {
        public StatusButtonMethod StartButton { get; }

        public XmlUseMethod Xml { get; }

        public ICommand Update { get; }

        public DataContextIdentificationFl()
        {
            Xml = new XmlUseMethod();
            StartButton = new StatusButtonMethod();
            var visualTreatment = new VisualTreatmentFace();
            StartButton.Button.Command = new DelegateCommand(() => { visualTreatment.IdentificationFl(StartButton, ConfigFile.AllListModel); });
            Update = new DelegateCommand(() => { Xml.UpdateFileXml(ConfigFile.AllListModel); });
        }

    }
}
