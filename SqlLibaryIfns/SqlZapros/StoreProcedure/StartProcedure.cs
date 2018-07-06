using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using SqlLibaryIfns.SqlZapros.SobytieSql;

namespace SqlLibaryIfns.SqlZapros.StoreProcedure
{
   public class StartProcedure
    {

        /// <summary>
        /// Функция выполнения процедуры и с параметром и без параметров
        /// 1 - Если нет параметров то выполняется процедура без параметров
        /// 2 - Если есть параметры то выполняется Генерация параметров для SqlCommand а потом и процедура
        /// </summary>
        /// <typeparam name="TKey">Ключ параметра</typeparam>
        /// <typeparam name="TValue">Тип параметра</typeparam>
        /// <param name="conectionstring">Строка соединения</param>
        /// <param name="procedure">Название процедуры</param>
        /// <param name="listparametr">Словарь параметров</param>
        /// <returns>Сообщение от сервера</returns>
        public string StartingProcedure<TKey, TValue>(string conectionstring, string procedure, Dictionary<TKey, TValue> listparametr = null)
        {
            try
            {
                Sobytie sobytie = new Sobytie { Messages = null };
                using (var con = new SqlConnection(conectionstring))
                {
                    SqlCommand command = new SqlCommand(procedure) { CommandType = CommandType.StoredProcedure, Connection = con };
                    con.InfoMessage += sobytie.Con_InfoMessage;
                    if (listparametr != null)
                    {
                        command = GenerateParametrs(command, listparametr);
                    }
                    con.Open();
                    using (command.ExecuteReader())
                    {

                    }
                    con.Close();
                }
                return sobytie.Messages;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        /// <summary>
        /// Генерация параметров для SqlCommand
        /// </summary>
        /// <typeparam name="TKey">Ключ параметра</typeparam>
        /// <typeparam name="TValue">Значение параметра</typeparam>
        /// <param name="command">Команда ref SqlCommand</param>
        /// <param name="listparametr">Словарь параметров для подставления в SqlCommand</param>
        /// <returns></returns>
        public SqlCommand GenerateParametrs<TKey, TValue>(SqlCommand command, Dictionary<TKey, TValue> listparametr)
        {
            foreach (var param in listparametr)
            {
                command.Parameters.AddWithValue(param.Key.ToString(), param.Value);
            }
            return command;
        }
    }
}
