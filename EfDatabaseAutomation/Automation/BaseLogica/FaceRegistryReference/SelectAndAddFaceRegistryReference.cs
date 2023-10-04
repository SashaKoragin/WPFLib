using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EfDatabaseAutomation.Automation.Base;

namespace EfDatabaseAutomation.Automation.BaseLogica.FaceRegistryReference
{
    public class SelectAndAddFaceRegistryReference : IDisposable
    {
        public Base.Automation Automation { get; set; }

        public SelectAndAddFaceRegistryReference()
        {
            Automation?.Dispose();
            Automation = new Base.Automation();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isState1">Признак статуса 1</param>
        /// <param name="isState2">Признак статуса 2</param>
        /// <param name="isEndElement">Брать с начала списка или с конца</param>
        /// <returns></returns>
        public List<AllFaceRegistryReference> SelectFaceReference(bool isState1 = false, bool isState2 = false, bool isEndElement = false)
        {
            if (isEndElement)
            {
                var listModel = Automation.AllFaceRegistryReferences.Where(x => x.IsState1 == isState1 & x.IsState2 == isState2 & x.IsErrorMessage == null).AsEnumerable();
                return listModel.Reverse().Take(500).ToList();
            }
            return Automation.AllFaceRegistryReferences.Where(x => x.IsState1 == isState1 & x.IsState2 == isState2 & x.IsErrorMessage == null).Take(500).ToList();
            
        }
        /// <summary>
        /// Сохранение обновление модели
        /// </summary>
        /// <param name="doc"></param>
        public void SaveModel(AllFaceRegistryReference doc)
        {
            using (var context = new Base.Automation())
            {
                context.Entry(doc).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        /// <summary>
        /// Удаление записи по ИНН в журнале!
        /// </summary>
        /// <param name="inn"></param>
        public string Delete(string inn)
        {
            try
            {
                using (var contextDelete = new Base.Automation())
                {
                    var model = contextDelete.AllFaceRegistryReferences.FirstOrDefault(x => x.InnFace == inn);
                    if (model == null) return $"Запись c ИНН {inn} для удаления не существует!!!";
                    contextDelete.Database.CommandTimeout = 120000;
                    contextDelete.AllFaceRegistryReferences.Remove(model);
                    contextDelete.SaveChanges();
                }
                return $"Запись c ИНН {inn} удалена успешно!!!";
            }
            catch (Exception e)
            {
                Loggers.Log4NetLogger.Error(e);
            }
            return $"Возникла ошибка при удалении записи с ИНН {inn}";
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
