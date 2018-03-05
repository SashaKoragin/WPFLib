using System.Configuration;

namespace WordReport.Config
{
    public static class ConectionString
    {
        public static readonly string Connection = ConfigurationManager.ConnectionStrings["SQL"].ConnectionString;
    }
}
