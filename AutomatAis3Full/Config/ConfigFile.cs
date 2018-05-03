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
    }
}
