using System;
using System.Configuration;
using System.Runtime.Serialization;

namespace ServiceAutomation.ParametrConfig
{
    public class ParametrConfig
    {
        public ParametrConfig()
        {
            ConfigurationManager.RefreshSection(ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).AppSettings.SectionInformation.Name);
            PathSaveTemplate = ConfigurationManager.AppSettings["PathSaveTemplate"];
        }

        /// <summary>
        /// Путь к сохранению шаблонов 
        /// </summary>
        public string PathSaveTemplate { get; set; }
    }
}