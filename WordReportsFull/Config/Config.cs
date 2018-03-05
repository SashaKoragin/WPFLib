using System.Configuration;

namespace WordReportsFull.Config
{
   public class Config
    {
        public static string TemplateDirectory = ConfigurationManager.AppSettings["TemplateDirectory"];
        public static readonly string Connection = ConfigurationManager.ConnectionStrings["SQL"].ConnectionString;
    }
}
