using System;
using System.Windows.Input;
using AutomatAis3Full.Config;
using LibaryCommandPublic.TestAutoit.PublicCommand;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.LableAndErrorModel;
using ViewModelLib.ModelTestAutoit.PublicModel.ReportXlsx;
using ViewModelLib.ModelTestAutoit.PublicModel.ReportXml;

namespace AutomatAis3Full.Form.Report.ReportXml.DataContext
{
   public class DataContextReport
   {
        public LableModel LableModel { get; }
        public ICommand Update { get; }
        public ReportJurnalMethod ReportJurnalAndFile { get; }
        public ReportXlsxMethod Report { get; }
        public ICommand OpenFile { get; }
        public ICommand SendFileToServer { get; }
        public ICommand DeleteJurnal { get; }
        public ICommand DeleteReport { get; }

        public ICommand OpenReport { get; }

        public ICommand SenderDepartment { get; }


        public DataContextReport()
        {
            try
            {
                var command = new CommandSnuOneAuto();
                Report = new ReportXlsxMethod(ConfigFile.ExcelReportFile);
                ReportJurnalAndFile = new ReportJurnalMethod(ConfigFile.PathJurnal, ConfigFile.PathInn);
                LableModel = new LableModel();
                DeleteJurnal = new DelegateCommand(()=> {ReportJurnalAndFile.DeleteXmlReportJurnal();});
                DeleteReport = new DelegateCommand(() => { Report.DeleteReportFile(); });
                OpenReport = new DelegateCommand(() => { Report.OpenReport(); });
                OpenFile = new DelegateCommand(() => { command.ConvertXslToXmlAndOpen(Report, ReportJurnalAndFile, ConfigFile.ExcelReportFile); });
                SendFileToServer = new DelegateCommand(() => command.SenderServerReport(LableModel,ConfigFile.ServiceAndIpComputer, ConfigFile.ServerReport,ReportJurnalAndFile));
                SenderDepartment = new DelegateCommand(()=>command.DepartmentDocumentSenders(LableModel, ConfigFile.ServiceAndIpComputer, ConfigFile.ServerRuleUsersWordTemplate, ReportJurnalAndFile));
                Update = new DelegateCommand(() =>
                {
                    ReportJurnalAndFile.AddFileXml(ConfigFile.PathInn);
                    ReportJurnalAndFile.AddJurnal(ConfigFile.PathJurnal);
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
