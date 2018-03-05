using System.Configuration;

namespace SeathZip.Configuration
{
    internal class Conf
    {
        public static string RunTimeDerectory = ConfigurationManager.AppSettings["RunTimeDirectory"];
        public static string OkPath = ConfigurationManager.AppSettings["OkPath"];
        public static string PathStart = ConfigurationManager.AppSettings["PathSeath"];
        public static string PathDll64 = ConfigurationManager.AppSettings["PathDLL64"];
        public static string PathDll32 = ConfigurationManager.AppSettings["PathDLL32"];
    }
}
