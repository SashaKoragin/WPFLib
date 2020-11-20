using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using EfDatabaseAutomation.Automation.Base;
using EfDatabaseAutomation.Automation.BaseLogica.XsdAuto.FullShemeModel;
using EfDatabaseAutomation.Automation.BaseLogica.XsdAuto.TaxJournalAuto;
using ModelKbkOnKbk = EfDatabaseAutomation.Automation.Base.ModelKbkOnKbk;

namespace EfDatabaseAutomation.Automation.BaseLogica.AddObjectDb
{
   public class AddObjectDb : IDisposable
    {
        public Automation.Base.Automation Automation { get; set; }
        public AddObjectDb()
        {
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
        /// Добавление или обновление журнала отправки документа
        /// </summary>
        /// <param name="taxJournalDelivery">Журнал отправки документа</param>
        public void AddAndUpdateTaxJournalDelivery(TaxJournalDelivery taxJournalDelivery)
        {
            if (!(from taxJournalDeliveries in Automation.TaxJournalDeliveries where taxJournalDeliveries.RegNumber == taxJournalDelivery.RegNumber select new { TaxJournalDeliveries = taxJournalDeliveries }).Any())
            {
                Automation.TaxJournalDeliveries.Add(taxJournalDelivery);
                Automation.SaveChanges();
            }
            else
            {
                using (var context = new Base.Automation())
                {
                    var selectJournalDeliveries = (from taxJournalDeliveries in context.TaxJournalDeliveries where taxJournalDeliveries.RegNumber == taxJournalDelivery.RegNumber select new { TaxJournalDeliveries = taxJournalDeliveries }).FirstOrDefault();
                    taxJournalDelivery.Id = selectJournalDeliveries.TaxJournalDeliveries.Id;
                    Automation.Entry(taxJournalDelivery).State = EntityState.Modified;
                    Automation.SaveChanges();
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="regNum">Регистрационный номер</param>
        public bool IsExistsDocument(Int64 regNum)
        {
           return (from taxJournalDeliveries in Automation.TaxJournalDeliveries where taxJournalDeliveries.RegNumber == regNum select new { TaxJournalDeliveries = taxJournalDeliveries }).Any();
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
        /// <summary>
        /// Процедура актуализации статуса подписывающего лица!!!
        /// </summary>
        /// <param name="signatureSenderTaxJournalOkp2">Ун подписи</param>
        public void IsActualStatus(int signatureSenderTaxJournalOkp2)
        {
            var resultFullOnBlockStatus = Automation.Database.SqlQuery<string>("Exec [dbo].[ActualStatusSignature] @Id", new SqlParameter("Id", signatureSenderTaxJournalOkp2)).FirstOrDefault();
        }


        /// <summary>
        /// Disposing
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Automation?.Dispose();
                Automation = null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
