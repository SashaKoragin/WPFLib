using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfDatabaseAutomation.Automation.Base;

namespace EfDatabaseAutomation.Automation.BaseLogica.AddObjectDb
{
   public class AddObjectDb 
    {
        public Automation.Base.Automation Automation { get; set; }
        public AddObjectDb()
        {
            Automation?.Dispose();
            Automation = new Base.Automation();
        }

        /// <summary>
        /// Добавление отработанного КМ
        /// </summary>
        /// <param name="journal">Отработанный комплекс</param>
        public void AddTaxJournal(TaxJournal journal)
        {
            Automation.TaxJournals.Add(journal);
            Automation.SaveChanges();
        }
    }
}
