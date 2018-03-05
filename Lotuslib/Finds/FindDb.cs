using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino;

namespace Lotuslib.Finds
{
   public class FindDb
    {
        /// <summary>
        /// Функция поиска по заданной выборке
        /// </summary>
        /// <param name="db">База данных</param>
        /// <param name="find">Параметры запроса</param>
        /// <returns>Возвращается колекция найденных документов</returns>
        public NotesDocumentCollection Finds(NotesDatabase db, string find)
        {
            var col = db.Search(find, null, 0);
            return col;
        }

    }
}
