using System.Windows.Forms;
using System.Windows.Input;
using AddModelProject.TestAutoit.CommandAddModel;
using LibaryCommandPublic.TestAutoit.SnuOneAuto.AutoCommand;
using LibaryCommandPublic.TestAutoit.SnuOneAuto.PublicCommand;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.ModelSnuOneAuto.DataXml;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using ViewModelLib.ModelTestAutoit.PublicModel.ReportXlsx;
using ViewModelLib.ModelTestAutoit.PublicModel.ReportXml;

namespace TestAutoit.Form.Automat.DataContext
{
   internal class DataContextAutomat
    {
        public XmlUse Xml { get; }
        public ICommand Update { get; }
        public ReportJurnal ReportJurnalOnInn { get; }
        public StartOnStop StartButton { get; }
        public ReportXlsx Report { get; }
        public ICommand ConvertXmltoXlsx { get; }
        public ICommand OpenFile { get; }
        public ICommand Green { get; }
        public ICommand Yellow { get; }
        public DataContextAutomat()
        {
            var report = new ReportXlsx();
            var jurnaloninn = new ReportJurnal();
            var command = new CommandSnuOneAuto();
            var commandmodel = new CommandAddModel();
            var status = new StatusButton();
            var commandauto = new AutoCklicsAisCommand();
            Report = report;
            status.StatusGrin();
            commandmodel.JurnalOnInn(jurnaloninn, Constantsfile.ConstantFile.PathJurnal, Constantsfile.ConstantFile.PathInn);
            StartButton = status.Start;
            ReportJurnalOnInn = jurnaloninn;
            Xml = new XmlUse();
            status.Start.Button.Command = new DelegateCommand(() => {commandauto.AutoClicerSnuOneForm(status,Constantsfile.ConstantFile.FileInn,Constantsfile.ConstantFile.FileJurnalError,Constantsfile.ConstantFile.FileJurnalOk);});
            Yellow = new DelegateCommand(() => { Yellows(status); });
            Green = new DelegateCommand(() => { Greens(status); });
            ConvertXmltoXlsx = new DelegateCommand(()=> {commandauto.});
            OpenFile = new DelegateCommand(()=> {command.OpenFile(jurnaloninn.XmlJurnal.Path);});
            Update = new DelegateCommand(() =>
            {
                command.UpdateStatus(Xml, Constantsfile.ConstantFile.FileInn);
                commandmodel.JurnalOnInn(jurnaloninn, Constantsfile.ConstantFile.PathJurnal, Constantsfile.ConstantFile.PathInn);
            });
        }
        public void Yellows(StatusButton status)
        {
            status.StatusYellow();
        }
        public void Greens(StatusButton status)
        {
            status.StatusGrin();
        }
    }
}
