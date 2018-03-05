using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotuslib.LotusItem
{
   public class DbImnsItem
    {
        /// <summary>
        /// Наименование отдела
        /// </summary>
        public const string NameOtdel = @"Dep_Name";

        /// <summary>
        /// Абривеатура отдела
        /// </summary>
        public const string Abbreviation = @"Abbreviation";
        /// <summary>
        /// Департамент
        /// </summary>
        public const string Departament = @"Department";
    }

    public class ImnsLotusUsers
    {
        /// <summary>
        /// Полное имя сотрудника
        /// </summary>
        public const string User = @"Person_FullName";

        /// <summary>
        /// Признак увольнение сотрудника
        /// </summary>
        public const string Dismissal = @"Discharged";
    }
}
