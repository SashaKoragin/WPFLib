using System;
using System.Collections.Generic;
using System.Windows.Input;
using AisPoco.ModelServiceDataBase;
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
        /// <summary>
        /// Модель адресов api
        /// </summary>
        public List<ModelServiceDataBase> ModelApi { get; }
        public LabelModel LabelModel { get; }
        public ICommand Update { get; }
        public ReportJournalMethod ReportJournalAndFile { get; }
        public ReportXlsxMethod Report { get; }
        public ICommand OpenFile { get; }
        /// <summary>
        /// Команда отправки файла на сервер
        /// </summary>
        public ICommand FileToServerApiReport { get; }
        public ICommand DeleteJournal { get; }
        public ICommand DeleteReport { get; }

        public ICommand OpenReport { get; }

        public DataContextReport()
        {
            try
            {
                var command = new CommandSnuOneAuto();
                ModelApi = ConfigFile.ResultGetTemplate<ModelServiceDataBase>(ConfigFile.ServiceModelInventory);
                ModelApi.ForEach(service=>service.ApiService = string.Format(service.ApiService, ConfigFile.HostNameService));
                Report = new ReportXlsxMethod(ConfigFile.ExcelReportFile);
                ReportJournalAndFile = new ReportJournalMethod(ConfigFile.PathJurnal, ConfigFile.PathInn, ModelApi);
                LabelModel = new LabelModel();
                DeleteJournal = new DelegateCommand(()=> { ReportJournalAndFile.DeleteXmlReportJournal();});
                DeleteReport = new DelegateCommand(() => { Report.DeleteReportFile(); });
                OpenReport = new DelegateCommand(() => { Report.OpenReport(); });
                OpenFile = new DelegateCommand(() => { command.ConvertXslToXmlAndOpen(Report, ReportJournalAndFile, ConfigFile.ExcelReportFile); });
                FileToServerApiReport = new DelegateCommand(() => command.FileToServerApiReport(LabelModel, ModelApi, ReportJournalAndFile));
                Update = new DelegateCommand(() =>
                {
                    ReportJournalAndFile.AddFileXml(ConfigFile.PathInn);
                    ReportJournalAndFile.AddJournal(ConfigFile.PathJurnal);
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
