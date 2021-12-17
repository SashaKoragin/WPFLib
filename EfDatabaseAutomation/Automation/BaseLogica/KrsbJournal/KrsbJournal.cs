using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EfDatabaseAutomation.Automation.Base;

namespace EfDatabaseAutomation.Automation.BaseLogica.KrsbJournal
{
   public class KrsbJournal : IDisposable
    {

        public Automation.Base.Automation Automation { get; set; }
        public KrsbJournal()
        {
            Automation?.Dispose();
            Automation = new Base.Automation();
        }
        /// <summary>
        /// Выбираем плательщиков не обработанных
        /// </summary>
        /// <returns></returns>
        public List<KrsbNp> SelectKrsbNps(bool isendElement)
        {
            if (isendElement)
            {
                var listModel = Automation.KrsbNps.Where(x => x.IsPriznakFullClosed == false).AsEnumerable();
                return listModel.Reverse().Take(300).Reverse().ToList();
            }
            return Automation.KrsbNps.Where(x => x.IsPriznakFullClosed == false).Take(300).ToList();
        }

        /// <summary>
        /// Сохранение КРСБ
        /// </summary>
        /// <param name="krsb">КРСБ</param>
        public void SaveModelKrsb(Krsb krsb)
        {
            var modelKrsb = new Krsb()
            {
                IdKrsb = krsb.IdKrsb,
                IdNp = krsb.IdNp,
                Kbk = krsb.Kbk,
                NameKrsb = krsb.NameKrsb,
                Oktmo = krsb.Oktmo,
                IdParameter = krsb.IdParameter,
                IsPriznak = krsb.IsPriznak
            };
            using (var context = new Base.Automation())
            {
                context.Entry(modelKrsb).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        /// <summary>
        /// Сохранение Плательщиков
        /// </summary>
        /// <param name="krsbNp">Плательщик</param>
        public void SaveModelNp(KrsbNp krsbNp)
        {
            var modelKrsbNp = new KrsbNp()
            {
                IdNp = krsbNp.IdNp,
                Fid = krsbNp.Fid,
                Kpp = krsbNp.Kpp,
                Inn = krsbNp.Inn,
                NameNp = krsbNp.NameNp,
                IsPriznakFullClosed = krsbNp.IsPriznakFullClosed
            };
            using (var context = new Base.Automation())
            {
                context.Entry(modelKrsbNp).State = EntityState.Modified;
                context.SaveChanges();
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
}
