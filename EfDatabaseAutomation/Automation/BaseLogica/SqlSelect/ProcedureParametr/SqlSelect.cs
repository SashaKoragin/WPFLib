using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EfDatabaseAutomation.Automation.SelectParametrSheme;

namespace EfDatabaseAutomation.Automation.BaseLogica.SqlSelect.ProcedureParametr
{
    public class SqlSelect : IDisposable
    {
        public static string ProcedureSelect = "Exec [dbo].[AutomationCommandSelectWcfToSql] {0}";

        public Base.Automation Automation { get; set; }

        public SqlSelect()
        {
            Automation?.Dispose();
            Automation = new Base.Automation();
        }

        /// <summary>
        /// Генерация модели с параметрами для пользовательских выборок
        /// </summary>
        /// <param name="model">Модель</param>
        /// <returns></returns>
        public ModelSelect SelectSql(ModelSelect model)
        {
            try
            {
                model.LogicsSelectAutomation = SqlSelectModel(model.ParametrsSelect.Id);
                model.InfoViewAutomation = Automation.Database.SqlQuery<InfoViewAutomation> (model.LogicsSelectAutomation.SelectedParametr).ToArray();
                return model;
            }
            catch (Exception e)
            {
                Loggers.Log4NetLogger.Error(e);
                return null;
            }

        }

        /// <summary>
        /// Выборка модели для манипуляции
        /// </summary>
        /// <param name="id">Параметр индекса в таблицы</param>
        /// <returns></returns>
        public LogicsSelectAutomation SqlSelectModel(int id)
        {
            return Automation.Database.SqlQuery<LogicsSelectAutomation>(String.Format(ProcedureSelect, id)).ToList()[0];
        }


        /// <summary>
        /// Dispose
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
