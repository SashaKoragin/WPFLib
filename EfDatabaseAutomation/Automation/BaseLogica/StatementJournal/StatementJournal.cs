using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EfDatabaseAutomation.Automation.Base;

namespace EfDatabaseAutomation.Automation.BaseLogica.StatementJournal
{
    public class StatementJournal : IDisposable
    {
        public Automation.Base.Automation Automation { get; set; }

        public StatementJournal()
        {
            Automation?.Dispose();
            Automation = new Base.Automation();
        }

        /// <summary>
        /// Выбираем плательщиков не обработанных
        /// </summary>
        /// <returns></returns>
        public List<StatementNp> SelectStatementNp(bool isendElement)
        {
            if (isendElement)
            {
                var listModel = Automation.StatementNps.Where(x => x.IsPriznakFullClosed == null).AsEnumerable();
                return listModel.Reverse().Take(300).Reverse().ToList();
            }
            return Automation.StatementNps.Where(x => x.IsPriznakFullClosed == null).Take(300).ToList();
        }

        /// <summary>
        /// Сохранение статуса отработки заявления
        /// </summary>
        /// <param name="statement">КРСБ</param>
        public void SaveModelStatement(Statement statement)
        {
            var modelStatement = new Statement()
            {
                IdStatement = statement.IdStatement,
                IdNp = statement.IdNp,
                NumberStatement = statement.NumberStatement,
                Kbk = statement.Kbk,
                Oktmo = statement.Oktmo,
                IsPriznak = statement.IsPriznak
            };
            using (var context = new Base.Automation())
            {
                context.Entry(modelStatement).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        /// <summary>
        /// Сохранение отработанных плательщиков
        /// </summary>
        /// <param name="statementNp">Плательщик</param>
        public void SaveModelNp(StatementNp statementNp)
        {
            var modelStatementNp = new StatementNp()
            {
                IdNp = statementNp.IdNp,
                Inn = statementNp.Inn,
                NameNp = statementNp.NameNp,
                IsPriznakFullClosed = statementNp.IsPriznakFullClosed
            };
            using (var context = new Base.Automation())
            {
                context.Entry(modelStatementNp).State = EntityState.Modified;
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
