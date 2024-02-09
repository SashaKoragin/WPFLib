using EfDatabaseAutomation.Automation.Base;
using System;
using System.Linq;

namespace EfDatabaseAutomation.Automation.BaseLogica.StatementJournal
{
    public class RegisterDocumentsPrintingJournal : IDisposable
    {
        public Base.Automation Automation { get; set; }

        public RegisterDocumentsPrintingJournal()
        {
            Automation?.Dispose();
            Automation = new Base.Automation();
        }

        public bool IsPrint(string guidDocument)
        {
           return Automation.RegisterDocumentsPrintings.Any(x => x.RegNumberDocumetGuid == guidDocument);
        }


        /// <summary>
        /// Сохранение документа для печати
        /// </summary>
        /// <param name="documentsPrinting">Документ для сохранения</param>
        public void SaveDocument(RegisterDocumentsPrinting documentsPrinting)
        {
            Automation.RegisterDocumentsPrintings.Add(documentsPrinting);
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
