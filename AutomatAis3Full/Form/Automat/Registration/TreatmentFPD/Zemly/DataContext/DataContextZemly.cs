using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using AutomatAis3Full.Config;
using AutomatAis3Full.Form.AddResours.SelectBranch;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.ModelSnuOneAuto.DataXml;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using ViewModelLib.ModelTestAutoit.PublicModel.QbeSelect;
using ViewModelLib.ModelTestAutoit.PublicModel.SelectBranch;

namespace AutomatAis3Full.Form.Automat.Registration.TreatmentFPD.Zemly.DataContext
{
    public class DataContextZemly
    {
        public XmlUseMethod Xml1 { get; }
        public ICommand Update { get; }
        public DelegateCommand<object> SelectAddC { get; }
        public DelegateCommand<object> RemoveAddC { get; }
        public DelegateCommand<object> SelectAddF { get; }
        public DelegateCommand<object> RemoveAddF { get; }
        public StatusButtonMethod StartButton2 { get; }
        public QbeClassMethod QbeStatus { get; }
        public Branch Branch { get; }
        public DataContextZemly()
        {
            Branch = new SelectBranch().AddBranhc();
            QbeStatus = new QbeClassMethod();
            var commandauto = new LibaryCommandPublic.TestAutoit.Reg.TreatmentFPD.Zemly.Zemly();
            StartButton2 = new StatusButtonMethod();
            Xml1 = new XmlUseMethod();
            StartButton2.Button.Command = new DelegateCommand(() => { commandauto.ZemlyAuto(QbeStatus,Branch,StartButton2,ConfigFile.FileFpd, ConfigFile.FileJurnalError, ConfigFile.FileJurnalOk); });
            Update = new DelegateCommand(() => { Xml1.UpdateFileXml(ConfigFile.FileFpd); });
            SelectAddC = new DelegateCommand<object>(param=> {QbeStatus.SelectStatusAddC(param);});
            RemoveAddC = new DelegateCommand<object>(param=> {QbeStatus.DeleteStatusAddC(param);});
            SelectAddF = new DelegateCommand<object>(param => { QbeStatus.SelectStatusAddF(param);});
            RemoveAddF = new DelegateCommand<object>(param => { QbeStatus.DeleteStatusAddF(param); });
        }
    }
}
