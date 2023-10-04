using System;
using System.IO;
using System.Linq;
using EfDatabase.Inventory.Base;
using EfDatabase.Inventory.BaseLogic.Select;
using EfDatabaseXsdSupportNalog;
using LibaryDocumentGenerator.Documents.TemplateExcel;
using SqlLibaryIfns.ExcelReport.Report;
using SqlLibaryIfns.SqlZapros.SqlConnections;

namespace SqlLibaryIfns.ZaprosSelectNotParam
{
   public class SelectReportPassportTechnique : IDisposable
    {

        /// <summary>
        /// Строка соединения с БД
        /// </summary>
        public string ConnectionString { get; set; }

        public InventoryContext Inventory { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString">Строка соединения с БД</param>
        public SelectReportPassportTechnique(string connectionString)
        {
            Inventory?.Dispose();
            Inventory = new InventoryContext();
            ConnectionString = connectionString;
        }
        /// <summary>
        /// Полный анализ данных ЭПО с инвентаризацией запросы можно расширять
        /// </summary>
        /// <param name="pathSaveReport"></param>
        /// <param name="idReport">Уникальные номера отчетов ЭПО</param>
        /// <returns></returns>
        public Stream CreateFullReportEpo(string pathSaveReport, int[] idReport)
        {
            var xlsx = new ReportExcel();
            var sqlConnect = new SqlConnectionType();
            var modelsReports = Inventory.AnalysisEpoAndInventarkas.Where(id=>idReport.Contains(id.Id));
            foreach (var modelReport in modelsReports)
            {
                var reportAnalysis = sqlConnect.ReportQbe(ConnectionString, modelReport.ViewReport);
                xlsx.ReportAddListFile(modelReport.NameListXlsx, reportAnalysis);
            }
            Dispose(true);
            xlsx.SaveAsFileXlsx(Path.Combine(pathSaveReport, "Полный анализ данных.xlsx"));
            return xlsx.DownloadFile(Path.Combine(pathSaveReport, "Полный анализ данных.xlsx"));
        }

        /// <summary>
        /// Загрузка файла на шаге 3
        /// </summary>
        /// <param name="modelSupport">Модель запроса на сервис</param>
        /// <param name="pathSaveReport">Путь сохранения файла</param>
        public void CreateStoParametersStep3(ref ModelParametrSupport modelSupport, string pathSaveReport)
        {
            var modelParameterInputStep3 = modelSupport.TemplateSupport.Where(temple => temple.NameStepSupport == "Step3" && temple.TemplateParametrType != null).ToArray();
            foreach (var templateStep3 in modelParameterInputStep3)
            {
                if (templateStep3.TemplateParametrType.Equals("AnalisysEpo") && modelSupport.IdAnalisysEpo != 0)
                {
                    var idAnalisys = modelSupport.IdAnalisysEpo;
                    var analysis = Inventory.AnalysisEpoAndInventarkas.First(id => id.Id == idAnalisys);
                    templateStep3.ParameterStep3 = CreateReportEpo(pathSaveReport, analysis);
                    templateStep3.NameGuidParametr = string.Format(templateStep3.NameGuidParametr, analysis.NameFileXlsx, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
                }
                if (templateStep3.TemplateParametrType.Equals("CardAksiok"))
                {
                    templateStep3.ParameterStep3 = CreateCardAksiok(modelSupport.AksiokAddAndEdit, pathSaveReport);
                    templateStep3.NameGuidParametr = string.Format(templateStep3.NameGuidParametr, "Карточка АКСИОК.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
                }
                if (templateStep3.TemplateParametrType.Equals("ExpertiseFile") &&  modelSupport?.AksiokAddAndEdit?.ParametersRequestAksiok?.FileExpertise?.File != null)
                {
                    templateStep3.ParameterStep3 = modelSupport.AksiokAddAndEdit.ParametersRequestAksiok.FileExpertise.File;
                    templateStep3.NameGuidParametr = string.Format(templateStep3.NameGuidParametr, modelSupport.AksiokAddAndEdit.ParametersRequestAksiok.FileExpertise.NameFile, modelSupport.AksiokAddAndEdit.ParametersRequestAksiok.FileExpertise.TypeFile);
                }
                if (templateStep3.TemplateParametrType.Equals("OffFile") && modelSupport?.AksiokAddAndEdit?.ParametersRequestAksiok?.FileAkt?.File != null)
                {
                    templateStep3.ParameterStep3 = modelSupport.AksiokAddAndEdit.ParametersRequestAksiok.FileAkt.File;
                    templateStep3.NameGuidParametr = string.Format(templateStep3.NameGuidParametr, modelSupport.AksiokAddAndEdit.ParametersRequestAksiok.FileAkt.NameFile, modelSupport.AksiokAddAndEdit.ParametersRequestAksiok.FileAkt.TypeFile);
                }
            }
        }
        /// <summary>
        /// Создание карточки АКСИОК для редактирования
        /// </summary>
        /// <param name="aksiokAddAndEdit">Модель АКСИОК</param>
        /// <param name="pathSaveReport">Путь сохранения</param>
        /// <returns></returns>
        private byte[] CreateCardAksiok(AksiokAddAndEdit aksiokAddAndEdit, string pathSaveReport)
        {
            SelectSql selectSql = new SelectSql();
            ReportComparableAksiokAndInventoryResult reportCard = new ReportComparableAksiokAndInventoryResult();
            var model = selectSql.SelectCardAksiokAndInventory(aksiokAddAndEdit);
            reportCard.CreateDocument(pathSaveReport, model);
            var file = System.IO.File.ReadAllBytes(reportCard.FullPathDocumentWord);
            System.IO.File.Delete(reportCard.FullPathDocumentWord);
            return file;
        }

        /// <summary>
        /// Отчет для СТО выгрузка
        /// </summary>
        /// <param name="pathSaveReport">Путь сохранения</param>
        /// <param name="analysisEpo">Выбранный анализ</param>
        /// <returns></returns>
        private byte[] CreateReportEpo(string pathSaveReport, AnalysisEpoAndInventarka analysisEpo)
        {
            var xlsx = new ReportExcel();
            var sqlConnect = new SqlConnectionType();
            var reportAnalysis = sqlConnect.ReportQbe(ConnectionString, analysisEpo.ViewReport);
            xlsx.ReportAddListFile(analysisEpo.NameListXlsx, reportAnalysis);
            Dispose(true);
            xlsx.SaveAsFileXlsx(Path.Combine(pathSaveReport, analysisEpo.NameFileXlsx));
            return xlsx.ReadFileByte(Path.Combine(pathSaveReport, analysisEpo.NameFileXlsx));
        }

        /// <summary>
        /// Disposing
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Inventory?.Dispose();
                Inventory = null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
