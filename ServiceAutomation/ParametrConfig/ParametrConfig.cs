using System.Configuration;

namespace ServiceAutomation.ParametrConfig
{
    public class ParameterConfig
    {
        public ParameterConfig()
        {
            ConfigurationManager.RefreshSection(ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).AppSettings.SectionInformation.Name);
            PathSaveTemplate = ConfigurationManager.AppSettings["PathSaveTemplate"];
            ConnectionString = ConfigurationManager.ConnectionStrings["DatabaseAutomation"].ConnectionString;
        }

        /// <summary>
        /// Путь к сохранению шаблонов 
        /// </summary>
        public string PathSaveTemplate { get; set; }

        public string ConnectionString { get; set; }
    }
}