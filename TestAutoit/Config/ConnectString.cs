using System.Configuration;

namespace TestAutoit.Config
{
    class ConnectString
    {
            public static readonly string Connection = ConfigurationManager.ConnectionStrings["SQL"].ConnectionString;
    }
}
