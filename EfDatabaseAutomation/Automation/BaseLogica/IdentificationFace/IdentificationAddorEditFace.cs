﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
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
                    Loggers.Log4NetLogger.Info(new Exception($"Нельзя добавлять дубликаты значений {doc}"));
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
        /// <param name="idFile">Id файлов</param>
        public void IsCheckError(List<long> idFile)
        {
          var documents = Automation.Documen2Ndfl.Where(x => idFile.Contains(x.IdDoc));
          foreach (var document in documents)
          {
                using (var context = new Base.Automation())
                {
                    document.ErrorNameStatus = null;
                    context.Entry(document).State = EntityState.Modified;
                    context.SaveChanges();
                }
          }
        }
        /// <summary>
        /// Подстановка статуса принудительно обработан
        /// </summary>
        /// <param name="inn">ИНН</param>
        /// <param name="isExecute">Ун принудительного статуса</param>
        public void IsCheckErrorRegInn(string inn, bool isExecute)
        {
            var model = Automation.FlFaceMainRegistrations.FirstOrDefault(fl => fl.Inn == inn);
            if (model != null)
            {
                var modelEdit = new FlFaceMainRegistration()
                {
                    IdFl = model.IdFl,
                    IdNum = model.IdNum,
                    Fid = model.Fid,
                    Inn = model.Inn,
                    F = model.F,
                    I = model.I,
                    O = model.O,
                    DateOfBirth = model.DateOfBirth,
                    PlaceBirth = model.PlaceBirth,
                    CodeSd = model.CodeSd,
                    Document = model.Document,
                    SeriaDoc = model.SeriaDoc,
                    NumberDoc = model.NumberDoc,
                    DateCreateDoc = model.DateCreateDoc,
                    WhoDoc = model.WhoDoc,
                    CodePodr = model.CodePodr,
                    Citizenship = model.Citizenship,
                    Address = model.Address,
                    IdStatus = isExecute ? model.IdStatus : 1,
                    IdError = isExecute ? (int?)5 : null,
                    DateCreate = model.DateCreate
                };
                using (var context = new Base.Automation())
                {
                    context.Entry(modelEdit).State = EntityState.Modified;
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
