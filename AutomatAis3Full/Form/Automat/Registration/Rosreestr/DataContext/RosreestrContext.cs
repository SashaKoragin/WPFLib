using System.Windows.Input;
using AutomatAis3Full.Config;
using LibaryCommandPublic.TestAutoit.Reg.VisualTreatmentFace;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.ModelSnuOneAuto.DataXml;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace AutomatAis3Full.Form.Automat.Registration.Rosreestr.DataContext
{
   public class RosreestrContext
    {
        public StatusButtonMethod StartButton { get; }
        public XmlUseMethod Xml { get; }

        public ICommand Update { get; }

        public RosreestrContext()
        {
            Xml = new XmlUseMethod();
            var visualTreatment = new VisualTreatmentFace();
            StartButton = new StatusButtonMethod();
            StartButton.Button.Command = new DelegateCommand(() => { visualTreatment.VisualFace(StartButton,ConfigFile.VisualId, ConfigFile.FileJurnalError, ConfigFile.FileJurnalOk); });
            Update = new DelegateCommand(() => { Xml.UpdateFileXml(ConfigFile.VisualId); });

            //StartButton.Button.Command = new DelegateCommand((() => { commandauto.Update(StartButton, ConfigFile.FidFace, ConfigFile.FileJurnalError, ConfigFile.FileJurnalOk); }));
            //VisualTreatment.VisualFace(StartButton);
        }
    }
}