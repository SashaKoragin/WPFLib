using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AutomatAis3Full.Config;
using LibaryCommandPublic.TestAutoit.SnuOneAuto.PublicCommand;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.ModelSnuOneAuto.DataXml;
using ViewModelLib.ModelTestAutoit.PublicModel.ReportXlsx;
using ViewModelLib.ModelTestAutoit.PublicModel.ReportXml;

namespace AutomatAis3Full.Form.Report.ReportXml.DataContext
{
   public class DataContextReport
    {
        public XmlUseMethod Xml { get; }
        public ICommand Update { get; }
        public ReportJurnalMethod ReportJurnalAndFile { get; }
        public ReportXlsxMethod Report { get; }
        public ICommand OpenFile { get; }
        public ICommand DeleteJurnal { get; }
        public ICommand DeleteReport { get; }

        public ICommand OpenReport { get; }

        public DataContextReport()
        {
            var command = new CommandSnuOneAuto();
            Report = new ReportXlsxMethod(ConfigFile.ExcelReportFile);
            ReportJurnalAndFile = new ReportJurnalMethod(ConfigFile.PathJurnal, ConfigFile.PathInn);
            Xml = new XmlUseMethod();
            DeleteJurnal = new DelegateCommand(()=> {ReportJurnalAndFile.DeleteXmlReportJurnal();});
            DeleteReport = new DelegateCommand(() => { Report.DeleteReportFile(); });
            OpenReport = new DelegateCommand(() => { Report.OpenReport(); });
            OpenFile = new DelegateCommand(() => { command.ConvertXslToXmlAndOpen(Report, ReportJurnalAndFile, ConfigFile.ExcelReportFile); });
            Update = new DelegateCommand(() =>{ ReportJurnalAndFile.AddFileXml(ConfigFile.PathJurnal);});
        }
    }
}
