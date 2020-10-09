using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfDatabaseAutomation.Automation.Base;

namespace EfDatabaseAutomation.Automation.BaseLogica.IdentificationFace
{
   public class IdentificationAddorEditFace : IDisposable
   {

        public Automation.Base.Automation Automation { get; set; }
        public IdentificationAddorEditFace()
        {
            Automation?.Dispose();
            Automation = new Base.Automation();
        }

        /// <summary>
        /// Запрос на 100 элементов
        /// </summary>
        /// <returns>Лист документов</returns>
        /// <param name="statusSelect">Статус выборки</param>
        public List<Documen2Ndfl> SelectDocument(int? statusSelect)
        {
            return Automation.Documen2Ndfl.Where(x=>x.ErrorNameStatus == null&& x.Priznak == statusSelect).Take(500).ToList();
        }
        /// <summary>
        /// Обновление документа
        /// </summary>
        /// <param name="document">Докемент</param>
        public void UpdateDocument(Documen2Ndfl document)
        {
            Automation.Entry(document).State = EntityState.Modified;
            Automation.SaveChanges();
        }
        /// <summary>
        /// Добавление уникальных документов их Id
        /// </summary>
        /// <param name="listIdDocument"></param>
        public ServiceAddFile AddNewIdDocument(List<long> listIdDocument)
        {
            var serviceAddFile = new ServiceAddFile() {ErrorAddId = new List<ErrorAddId>()};
            var countErrorFile = 0;
            foreach (var doc in listIdDocument)
            {
                try
                {
                    Automation.Documen2Ndfl.Add(new Documen2Ndfl() { IdDoc = doc });
                    Automation.SaveChanges();
                }
                catch (DbUpdateException e) when (e.InnerException?.InnerException is SqlException sqlEx && (sqlEx.Number==2601||sqlEx.Number==2627))
                {
                    Loggers.Log4NetLogger.Error(sqlEx);
                    serviceAddFile.ErrorAddId.Add(new ErrorAddId(){IdDoc = doc, NameError = e.Message});
                    countErrorFile++;
                    //Нельзя добавлять дубликаты значений 
                }
            }
            serviceAddFile.CountAddFile = listIdDocument.Count - countErrorFile;
            serviceAddFile.CountErrorFile = countErrorFile;
            return serviceAddFile;
        }
        /// <summary>
        /// Изменение статуса Ошибки
        /// </summary>
        /// <param name="idFile">Id файла</param>
        public void IsCheckError(long idFile)
        {
          var doc = Automation.Documen2Ndfl.FirstOrDefault(x => x.IdDoc == idFile);
          if (doc != null)
          {
              using (var context = new Base.Automation())
              {
                  doc.ErrorNameStatus = null;
                  context.Entry(doc).State = EntityState.Modified;
                  context.SaveChanges();
              }
          }
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


   public class ServiceAddFile
   {
        /// <summary>
        /// Количество добавленных файлов
        /// </summary>
        public int CountAddFile { get; set; }
        /// <summary>
        /// Количество ошибочных файлов
        /// </summary>
        public int CountErrorFile { get; set; }

        /// <summary>
        /// Ошибки
        /// </summary>
        public List<ErrorAddId> ErrorAddId { get; set; }
   }

    /// <summary>
    /// Модель ошибочных значений при добавлении в БД
    /// </summary>
    public class ErrorAddId
   {
       /// <summary>
        /// Ошибка
        /// </summary>
        public string NameError { get; set; }
        /// <summary>
        /// У документа
        /// </summary>
        public long IdDoc { get; set; }
   }
}
