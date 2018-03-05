using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domino;

namespace Lotuslib.ConectDb
{
   public class ConectDb
    {
        /// <summary>
        /// Данный класс служит для подключения к Базе данных Lotus
        /// </summary>
        /// <param name="password">Пароль для подключеня к сесии</param>
        /// <param name="server">Сам сервер локальный или удаленный</param>
        /// <param name="database">База даных полный путь с названием</param>
        /// <param name="createofjncreatedb">Данное булевское значение говорит если false мы открываем BD true создаем БД</param>
        /// <returns></returns>
        public static NotesDatabase Databaseconect(string password,string server, string database, bool createofjncreatedb)
        {
            NotesSession session = new NotesSession();
            session.Initialize(password);
            var db = session.GetDatabase(server, database, createofjncreatedb);
            return db;
        }
        
    }
}
