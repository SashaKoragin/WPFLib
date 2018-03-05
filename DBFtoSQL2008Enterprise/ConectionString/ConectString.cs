
using System.Configuration;

namespace DBFtoSQL2008Enterprise.ConectionString
{
    class ConectString
    {
        public static string DbfConect = ConfigurationManager.ConnectionStrings["DBF"].ConnectionString;
        public static string SqlConection = ConfigurationManager.ConnectionStrings["SQL"].ConnectionString;
    }
}
