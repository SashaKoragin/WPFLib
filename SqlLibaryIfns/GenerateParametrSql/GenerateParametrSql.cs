using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace SqlLibaryIfns.GenerateParametrSql
{
   public class GenerateParametrSql
    {
        /// <summary>
        /// Процесс генерации словаря параметров для процедуры если они есть
        /// </summary>
        /// <param name="listparametr">ref вернет ссылку на обект с изменениями Словарь параметров</param>
        /// <param name="param">Тип класса из функции GetType()</param>
        /// <param name="ob">Сам класс в виде object</param>
        public void CreateParamert(ref Dictionary<string, string> listparametr, Type param, object ob)
        {
            if (param.IsClass)
            {
                PropertyInfo[] property = param.GetProperties();
                foreach (var prop in property)
                {
                    var value = prop.GetValue(ob, null);
                    var name = prop.Name;
                    if (value == null) continue;
                    if (prop.PropertyType != typeof(DateTime))
                        listparametr.Add("@" + name, value.ToString());
                    else
                        listparametr.Add("@" + name, "Date:" + value);
                }
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
                if (param.Value.ToString().Contains("Date:"))
                    command.Parameters.Add(param.Key.ToString(), SqlDbType.SmallDateTime).Value = DateTime.Parse(param.Value.ToString().Replace("Date:", "")).Date;
                else
                    command.Parameters.AddWithValue(param.Key.ToString(), param.Value);
            }
            return command;
        }
        /// <summary>
        /// Ищет по TKey в выборке sqlSelect и если находит заменяет его на TValue и возвращеет полную Sql выборку для Servera
        /// </summary>
        /// <typeparam name="TKey">Ключ параметра</typeparam>
        /// <typeparam name="TValue">Значение параметра</typeparam>
        /// <param name="sqlSelect">Выборка  с подставными значениями Например @D85</param>
        /// <param name="listparametr">Параметры замены значения Например TKey =@D85,TValue = 10.01.2018</param>
        /// <returns>Возвращает выборку с заменненными параметрами Работает только со строковыми параметрами</returns>
        public void GenerateStringParametr<TKey, TValue>(ref string sqlSelect, Dictionary<TKey, TValue> listparametr)
        {
            foreach (var value in listparametr)
            {
                sqlSelect = sqlSelect.Replace(value.Key.ToString(), value.Value.ToString().Contains("Date:") ? "'" + value.Value.ToString().Replace("Date:", "") + "'" : value.Value.ToString());
            }
        }
    }
}
