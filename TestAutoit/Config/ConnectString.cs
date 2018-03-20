using System.Configuration;

namespace TestAutoit.Config
{
   internal class ConnectString
    {
            public static readonly string Connection = ConfigurationManager.ConnectionStrings["SQL"].ConnectionString;
    }
}
