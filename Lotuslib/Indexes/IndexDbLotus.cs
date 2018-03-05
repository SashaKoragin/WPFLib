using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino;

namespace Lotuslib.Indexes
{
   public class IndexDbLotus
    {
        /// <summary>
        /// Проверка и востановление индекса Базы Данных
        /// </summary>
        /// <param name="dbDatabase">База данных Lotus</param>
        /// <returns></returns>
        public static NotesDatabase IndexDataBaseUseCreate(NotesDatabase dbDatabase)
        {
            if (dbDatabase.IsFTIndexed)
            {
                //Есть индекс
                return dbDatabase;
            }
            //Индекса нет востанавливаем
            dbDatabase.CreateFTIndex(FTINDEX_OPTIONS.FTINDEX_ALL_BREAKS & FTINDEX_OPTIONS.FTINDEX_CASE_SENSITIVE, false);
            return dbDatabase;
        }
    }
}
