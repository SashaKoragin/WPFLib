using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using LibaryXMLAuto.ReadOrWrite.SerializationJson;

namespace AutomatAis3Full.Config
{
   internal class ConfigFile
   {
        /// <summary>
        /// Полный путь к файлу АИС 3 для запуска
        /// </summary>
        public static string FullPathAis3 = ConfigurationManager.AppSettings["FullPathAis3"];
        /// <summary>
        /// Компьютер где расположен сервис
        /// </summary>
        public static string HostNameService = ConfigurationManager.AppSettings["HostNameService"];
        /// <summary>
        /// Список api Model
        /// </summary>
        public static string ServiceModelInventory = ConfigurationManager.AppSettings["ServiceModelInventory"];
        public static string LoginUser = Environment.UserName;
        public static string AllListModel = ConfigurationManager.AppSettings["AllListModel"];
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
        public static string InfoRuleTemplate = ConfigurationManager.AppSettings["InfoRuleTemplate"];
        public static string InfoUserTemplateRule = ConfigurationManager.AppSettings["InfoUserTemplateRule"];
        public static string Ifns = ConfigurationManager.AppSettings["Ifns"];
        public static string Help = ConfigurationManager.AppSettings["Help"];
        public static string WebSite = ConfigurationManager.AppSettings["WebSite"];
        public static string ServiceGetOrPost = ConfigurationManager.AppSettings["ServiceGetOrPost"];
        public static string AllTemplate = ConfigurationManager.AppSettings["AllTemplate"];
        public static string AllUserScan = ConfigurationManager.AppSettings["AllUserScan"];
        public static string PathDownloadsReplaceLogin =string.Format(ConfigurationManager.AppSettings["PathDownloads"], LoginUser);
        public static int Slepping = Convert.ToInt32(ConfigurationManager.AppSettings["Sleepeng"]);
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
        public static string PathTemp = System.IO.Path.GetTempPath();
        /// <summary>
        /// Путь к PDF файлам сохранение Work
        /// </summary>
        /// 
        public static string PathPdfWork = ConfigurationManager.AppSettings["PathPdfWork"];
        /// <summary>
        /// Путь к Xsd схемам
        /// </summary>
        public static string PathXsdScheme = ConfigurationManager.AppSettings["PathXsdScheme"];
        /// <summary>
        /// Выгрузка xml файлов
        /// </summary>
        public static string PathDownloadTempXml = ConfigurationManager.AppSettings["PathDownloadTempXml"];

        /// <summary>
        /// Загрузка Данных через сервис Get
        /// </summary>
        /// <param name="serviceGetTemplate">Маршрут для конфигурации</param>
        /// <returns></returns>
        public static List<T> ResultGetTemplate<T>(string serviceGetTemplate)
        {
            var json = new SerializeJson();
            var request = (HttpWebRequest)WebRequest.Create(serviceGetTemplate);
            request.Method = "GET";
            request.ContentType = "application/json";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string resultServer;
            using (StreamReader rdr = new StreamReader(response.GetResponseStream()))
            {
                resultServer = rdr.ReadToEnd();
            }

            return (List<T>)json.JsonDeserializeObjectListClass<T>(resultServer);
        }
    }
}
