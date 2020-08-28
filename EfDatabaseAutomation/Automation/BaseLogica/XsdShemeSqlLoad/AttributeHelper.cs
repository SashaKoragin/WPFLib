using System;
using System.Collections.Generic;
using System.Linq;

namespace EfDatabaseAutomation.Automation.BaseLogica.XsdShemeSqlLoad
{
    public static class AttributeHelper
    {
        public static List<string> GetDataNames(Type type, string propertyName)
        {
            var property = type.GetProperty(propertyName).GetCustomAttributes(false).
                Where(x => x.GetType().Name == "DataNamesAttribute").FirstOrDefault();
            if (property != null)
            {
                return ((DataNamesAttribute)property).ValueNames;
            }
            return new List<string>();
        }
    }
}
