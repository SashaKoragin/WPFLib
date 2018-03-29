using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LibaryCommandPublic.TestAutoit.SnuOneAuto.PublicCommand;
using Prism.Commands;
using TestAutoit.Config;
using ViewModelLib.ModelTestAutoit.ModelSnuOneAuto.DataXml;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using ViewModelLib.ModelTestAutoit.PublicModel.ReportXlsx;
using ViewModelLib.ModelTestAutoit.PublicModel.ReportXml;

namespace TestAutoit.Form.Report.DataContext
{
   public class DataContextReport
    {
        public XmlUseMethod Xml { get; }
        public ICommand Update { get; }
        public ReportJurnalMethod ReportJurnalOnInn { get; }
        public ReportXlsxMethod Report { get; }
        public ICommand OpenFile { get; }
        public ICommand DeleteReport { get; }
        public ICommand OpenReport { get; }
        public DataContextReport()
        {
            var command = new CommandSnuOneAuto();
            Report = new ReportXlsxMethod(ConfigFile.ExcelReportFile);
            ReportJurnalOnInn = new ReportJurnalMethod(ConfigFile.PathJurnal);
            Xml = new XmlUseMethod();
            DeleteReport = new DelegateCommand(() => { Report.DeleteReportFile(); });
            OpenReport = new DelegateCommand(() => { Report.OpenReport(); });
            OpenFile = new DelegateCommand(() => { command.ConvertXslToXmlAndOpen(Report, ReportJurnalOnInn, ConfigFile.ExcelReportFile); });
            Update = new DelegateCommand(() =>
            {
                ReportJurnalOnInn.AddJurnal(ConfigFile.PathJurnal);
            });
        }
    }
}
