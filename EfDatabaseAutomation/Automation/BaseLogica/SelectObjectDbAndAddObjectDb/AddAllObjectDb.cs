using EfDatabaseAutomation.Automation.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfDatabaseAutomation.Automation.BaseLogica.SelectObjectDbAndAddObjectDb
{
   public class AddAllObjectDb : IDisposable
    {
        public Base.Automation AutomationContext { get; set; }

        public AddAllObjectDb()
        {
            AutomationContext?.Dispose();
            AutomationContext = new Base.Automation();
          
        }
        /// <summary>
        /// Добавление или редактирование подписанта на отделе
        /// </summary>
        /// <param name="department">Отдел и подписант</param>
        /// <returns></returns>
        public DepartamentOtdel AddAndEditDepartment(DepartamentOtdel department)
        {
            var departmentAddAndModified = new DepartamentOtdel()
            {
                Id = department.Id,
                IdSender = department.IdSender,
                NameDepartament = department.NameDepartament,
                NameDepartamentActiveDerectory = department.NameDepartamentActiveDerectory,
                StatusFace = department.StatusFace,
                Office = department.Office,
                Telephon = department.Telephon
            };
            try
            {
                using (var context = new Base.Automation())
                {
                    var modelDb = from dep in context.DepartamentOtdels where dep.Id == department.Id select new { DepartamentOtdel = dep };
                    if (modelDb.Any())
                    {
                        AutomationContext.Entry(departmentAddAndModified).State = System.Data.Entity.EntityState.Modified;
                        AutomationContext.SaveChanges();
                        return department;
                    }
                }
                AutomationContext.DepartamentOtdels.Add(departmentAddAndModified);
                AutomationContext.SaveChanges();
                department.Id = departmentAddAndModified.Id;
                return department;
            }
            catch (Exception e)
            {
                Loggers.Log4NetLogger.Error(e);
                return null;
            }
        }




        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                AutomationContext?.Dispose();
                AutomationContext = null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
