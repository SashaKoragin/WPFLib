using System;
using System.Windows.Input;
using AutomatAis3Full.Config;
using LibraryCommandPublic.TestAutoit.PublicCommand;
using Prism.Commands;
using ViewModelLib.ModelTestAutoit.PublicModel.LabelAndErrorModel;
using ViewModelLib.ModelTestAutoit.PublicModel.ReportXlsx;
using ViewModelLib.ModelTestAutoit.PublicModel.ReportXml;

namespace AutomatAis3Full.Form.Report.ReportXml.DataContext
{
   public class DataContextReport
   {
        public LabelModel LabelModel { get; }
        public ICommand Update { get; }
        public ReportJurnalMethod ReportJournalAndFile { get; }
        public ReportXlsxMethod Report { get; }
        public ICommand OpenFile { get; }
        public ICommand SendFileToServer { get; }
        public ICommand DeleteJournal { get; }
        public ICommand DeleteReport { get; }

        public ICommand OpenReport { get; }

        public ICommand SenderDepartment { get; }

        public ICommand LoadTemplateInfo { get; }

        public DataContextReport()
        {
            try
            {
                var command = new CommandSnuOneAuto();
                Report = new ReportXlsxMethod(ConfigFile.ExcelReportFile);
                ReportJournalAndFile = new ReportJurnalMethod(ConfigFile.PathJurnal, ConfigFile.PathInn);
                LabelModel = new LabelModel();
                DeleteJournal = new DelegateCommand(()=> { ReportJournalAndFile.DeleteXmlReportJurnal();});
                DeleteReport = new DelegateCommand(() => { Report.DeleteReportFile(); });
                OpenReport = new DelegateCommand(() => { Report.OpenReport(); });
                OpenFile = new DelegateCommand(() => { command.ConvertXslToXmlAndOpen(Report, ReportJournalAndFile, ConfigFile.ExcelReportFile); });
                SendFileToServer = new DelegateCommand(() => command.SenderServerReport(LabelModel, ConfigFile.ServerReport, ReportJournalAndFile));
                SenderDepartment = new DelegateCommand(()=>command.DepartmentDocumentSenders(LabelModel, ConfigFile.ServerRuleUsersWordTemplate, ReportJournalAndFile));
                LoadTemplateInfo = new DelegateCommand(()=>command.LoadInfoTemplate(LabelModel, ConfigFile.LoadInfoTemplate, ReportJournalAndFile));
                Update = new DelegateCommand(() =>
                {
                    ReportJournalAndFile.AddFileXml(ConfigFile.PathInn);
                    ReportJournalAndFile.AddJurnal(ConfigFile.PathJurnal);
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
