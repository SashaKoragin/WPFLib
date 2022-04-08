using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using EfDatabaseAutomation.Automation.Base;
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
        /// Проверить праздничный день
        /// </summary>
        /// <param name="dateTime">День который проверяем</param>
        /// <returns></returns>
        public bool IsHolidays(DateTime dateTime)
        {
            return Automation.RbHolidays.Any(x => x.DateTimeHoliday == dateTime && x.IsHoliday);
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
        /// Добавление файла в журнал
        /// </summary>
        /// <param name="easJournal"></param>
        public void AddEasJournal(EasJournal easJournal)
        {
            Automation.EasJournals.Add(easJournal);
            Automation.SaveChanges();
        }
        /// <summary>
        /// Сохранение журнала Ошибок
        /// </summary>
        /// <param name="journal">Журнал сохраняем</param>
        public void TaxJournal121Error(TaxJournal121Error journal)
        {
            if (!(from taxJournal121Error in Automation.TaxJournal121Error
                  where taxJournal121Error.RegNumDeclaration == journal.RegNumDeclaration
                  select new { TaxJournal121Error = taxJournal121Error }).Any())
            {
                Automation.TaxJournal121Error.Add(journal);
                Automation.SaveChanges();
            }
        }
        /// <summary>
        /// Сохранение ФЛ в реестр
        /// </summary>
        /// <param name="fl">Физическое лицо</param>
        public void SaveFlFace(FlFaceMainRegistration fl)
        {
            if ((from flFaceMainRegistrations in Automation.FlFaceMainRegistrations
                  where flFaceMainRegistrations.Inn == fl.Inn
                  select new { FlFaceMainRegistrations = flFaceMainRegistrations }).Any())
            {
                try
                {
                    Automation.Entry(fl).State = EntityState.Modified;
                    Automation.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                    {
                        Trace.WriteLine(validationError.Entry.Entity.ToString());
                        Trace.WriteLine("");
                        foreach (DbValidationError err in validationError.ValidationErrors)
                        {
                            Trace.WriteLine(err.ErrorMessage);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Выбор записи из БД Акта 
        /// </summary>
        /// <param name="regNumber">Регистрационный номер</param>
        /// <returns></returns>
        public TaxJournal121 SelectJournal(int? regNumber)
        {
          return Automation.TaxJournal121.FirstOrDefault(x => x.RegNumDeclaration == regNumber && x.TypeDocument == "Акт");
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
