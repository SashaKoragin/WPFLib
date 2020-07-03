using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EfDatabaseAutomation.Automation.Base;
using EfDatabaseAutomation.Automation.BaseLogica.XsdAuto.TaxJournalAuto;

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
            journal.IsPrint = false;
            Automation.TaxJournals.Add(journal);
            Automation.SaveChanges();
        }
        /// <summary>
        /// Добавление файла 121
        /// </summary>
        /// <param name="journal"></param>
        public void AddTaxJournal121(TaxJournal121 journal)
        {
            journal.IsPrint = false;
            Automation.TaxJournal121.Add(journal);
            Automation.SaveChanges();
        }
        /// <summary>
        /// Добавление в 129 Журнал
        /// </summary>
        /// <param name="journal">Журнал</param>
        public void AddJournal129(TaxJournal129 journal)
        {
            journal.IsPrint = false;
            Automation.TaxJournal129.Add(journal);
            Automation.SaveChanges();
        }
        /// <summary>
        /// Поиск извещений в БД таблице
        /// </summary>
        /// <returns></returns>
        public List<TaxJournalAuto> DownloadFileNotPrint()
        {
           var logicModel = Automation.LogicsSelectAutomations.FirstOrDefault(logic => logic.Id == 1);
           if (logicModel != null) 
               return Automation.Database.SqlQuery<TaxJournalAuto>(logicModel.SelectUser).ToList();
           return null;
        }
        /// <summary>
        /// Обновления статуса печати
        /// </summary>
        /// <param name="idDoc">Ун документа</param>
        public void UpdatePrintDoc(int idDoc)
        {
            var journalTax = Automation.TaxJournals.FirstOrDefault(journal => journal.Id == idDoc);
            if (journalTax == null) return;
            journalTax.IsPrint = true;
            Automation.Entry(journalTax).State = EntityState.Modified;
            Automation.SaveChanges();
        }
        /// <summary>
        /// Добавление КБК лога уточнение платежа
        /// </summary>
        /// <param name="modelKbk">Модель уточнение платежа</param>
        public void AddModelKbkOnKbk(ModelKbkOnKbk modelKbk)
        {
            modelKbk.DateCreate = DateTime.Now;
            Automation.ModelKbkOnKbks.Add(modelKbk);
            Automation.SaveChanges();
        }
    }
}
