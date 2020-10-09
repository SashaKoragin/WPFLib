using System.Configuration;

namespace AutomatAis3Full.Config
{
   internal class ConfigFile
    {
        public static string FileInn = ConfigurationManager.AppSettings["FileInn"];
        public static string FileFpd = ConfigurationManager.AppSettings["FileFpd"];
        public static string FileJurnalError = ConfigurationManager.AppSettings["FileJurnalError"];
        public static string FileJurnalOk = ConfigurationManager.AppSettings["FileJurnalOk"];
        public static string FileSpisok = ConfigurationManager.AppSettings["FileSpisok"];
        public static string PathJurnal = ConfigurationManager.AppSettings["PathJurnal"];
        public static string PathInn = ConfigurationManager.AppSettings["PathInn"];
        public static string ExcelReportFile = ConfigurationManager.AppSettings["ExcelReportFile"];
        public static string FileInnFull = ConfigurationManager.AppSettings["FileInnFull"];
        public static string FileFid = ConfigurationManager.AppSettings["FileFid"];
        public static string FidFace = ConfigurationManager.AppSettings["FidFace"];
        public static string VisualId = ConfigurationManager.AppSettings["IdZaprosVisual"];
        public static string ReportMigration = ConfigurationManager.AppSettings["ReportMigration"];
        public static string UserRule = ConfigurationManager.AppSettings["UserRule"];
        public static string ServerReport = ConfigurationManager.AppSettings["ServerReport"];
        public static string ServerRuleUsersWordTemplate = ConfigurationManager.AppSettings["ServerRuleUsersWordTemplate"];
        public static string Ifns = ConfigurationManager.AppSettings["Ifns"];
        public static string Help = ConfigurationManager.AppSettings["Help"];
        public static string WebSite = ConfigurationManager.AppSettings["WebSite"];
        public static string ServiceGetOrPost = ConfigurationManager.AppSettings["ServiceGetOrPost"];
        public static string AllTemplate = ConfigurationManager.AppSettings["AllTemplate"];
        public static string BankSvedSave = ConfigurationManager.AppSettings["BankSvedSave"];
        /// <summary>
        /// Строка соединения с Sql для массовой загрузки xml
        /// </summary>
        public static readonly string BulkCopyXml = ConfigurationManager.ConnectionStrings["BulkCopyXml"].ConnectionString;
        /// <summary>
        /// Строка соединения с нашей БД
        /// </summary>
        public static readonly string Connection = ConfigurationManager.ConnectionStrings["SQL"].ConnectionString;
        /// <summary>
        /// Путь к PDF файлам сохранение Temp
        /// </summary>
        public static string PathPdfTemp = ConfigurationManager.AppSettings["PathPdfTemp"];
        /// <summary>
        /// Путь к PDF файлам сохранение Work
        /// </summary>
        public static string PathPdfWork = ConfigurationManager.AppSettings["PathPdfWork"];
        /// <summary>
        /// Путь к Xsd схемам
        /// </summary>
        public static string PathXsdScheme = ConfigurationManager.AppSettings["PathXsdScheme"];
        /// <summary>
        /// Выгрузка xml файлов
        /// </summary>
        public static string PathDownloadTempXml = ConfigurationManager.AppSettings["PathDownloadTempXml"];

    }
}
