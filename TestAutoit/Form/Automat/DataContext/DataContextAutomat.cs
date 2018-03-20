using System.Windows.Input;
using LibaryCommandPublic.TestAutoit.SnuOneAuto.AutoCommand;
using LibaryCommandPublic.TestAutoit.SnuOneAuto.PublicCommand;
using Prism.Commands;
using TestAutoit.Config;
using ViewModelLib.ModelTestAutoit.ModelSnuOneAuto.DataXml;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using ViewModelLib.ModelTestAutoit.PublicModel.ReportXlsx;
using ViewModelLib.ModelTestAutoit.PublicModel.ReportXml;

namespace TestAutoit.Form.Automat.DataContext
{
   internal class DataContextAutomat
    {
        public XmlUseMethod Xml { get; }
        public ICommand Update { get; }
        public ReportJurnalMethod ReportJurnalOnInn { get; }
        public StatusButtonMethod StartButton { get; }
        public ReportXlsxMethod Report { get; }
        public ICommand OpenFile { get; }
        public ICommand DeleteReport { get; }
        public ICommand OpenReport { get; }
        public ICommand Green { get; }
        public ICommand Yellow { get; }
        public DataContextAutomat()
        {
            var command = new CommandSnuOneAuto();
            var commandauto = new AutoCklicsAisCommand();
            Report = new ReportXlsxMethod(ConfigFile.ExcelReportFile);
            ReportJurnalOnInn = new ReportJurnalMethod(ConfigFile.PathJurnal, ConfigFile.PathInn);
            StartButton = new StatusButtonMethod();
            Xml = new XmlUseMethod();
            StartButton.Button.Command = new DelegateCommand(() => { commandauto.AutoClicerSnuOneForm(StartButton, ConfigFile.FileInn, ConfigFile.FileJurnalError, ConfigFile.FileJurnalOk); });
            DeleteReport = new DelegateCommand(()=> {Report.DeleteReportFile();});
            OpenReport = new DelegateCommand(()=> {Report.OpenReport();});
            Yellow = new DelegateCommand(() => { Yellows(StartButton); });
            Green = new DelegateCommand(() => { Greens(StartButton); });
            OpenFile = new DelegateCommand(()=> {command.ConvertXslToXmlAndOpen(Report, ReportJurnalOnInn, ConfigFile.ExcelReportFile);});
            Update = new DelegateCommand(() =>{command.UpdateModel(Xml, ReportJurnalOnInn, ConfigFile.FileInn, ConfigFile.PathJurnal, ConfigFile.PathInn);});
        }
        public void Yellows(StatusButtonMethod status)
        {
            status.StatusYellow();
        }
        public void Greens(StatusButtonMethod status)
        {
            status.StatusGrin();
        }
    }
}
