using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace LibaryXMLAuto.ReadOrWrite.SerializationJson
{
    class IgnoreGuidsResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty prop = base.CreateProperty(member, memberSerialization);
            if (prop.ToString() == "DataCreate")
            {
                prop.Ignored = true;
            }
            if (prop.ToString() == "DateCreate")
            {
                prop.Ignored = true;
            }
            return prop;
        }
    }
    /// <summary>
    /// Сериализация JSON
    /// </summary>
    public class SerializeJson
    {


        /// <summary>
        /// Библиотечная функция получения данных JSON
        /// </summary>
        /// <param name="model">Объект модели класса</param>
        /// <param name="dateFormat">Формат даты</param>
        /// <param name="isNullValueHandling">Сцепить null параметры</param>
        /// <returns>JSON string</returns>
        public string JsonLibrary(object model, string dateFormat = "dd-MM-yyyy", bool isNullValueHandling = true)
        {
          return  JsonConvert.SerializeObject(model,new JsonSerializerSettings()
          {
              NullValueHandling = (isNullValueHandling) ? NullValueHandling.Ignore:NullValueHandling.Include,
              DateFormatString = dateFormat
          });
        }
        /// <summary>
        /// Библиотечная функция получения данных JSON
        /// </summary>
        /// <param name="model">Объект модели класса</param>
        /// <returns>JSON string</returns>
        public string JsonLibraryNullInclude(object model)
        {
            return JsonConvert.SerializeObject(model, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Include,
                DateFormatString = "dd-MM-yyyy",

            });
        }

        /// <summary>
        /// Библиотечная функция получения данных JSON
        /// </summary>
        /// <param name="model">Объект модели класса</param>
        /// <returns></returns>
        public string JsonLibraryVks(object model)
        {
            return JsonConvert.SerializeObject(model, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                DateFormatString = "dd.MM.yyyy HH:mm"
            });
        }
        /// <summary>
        /// Сериализация в json c игнорированием DateTime
        /// </summary>
        /// <param name="model">Объект модели класса</param>
        /// <param name="dateFormatString">Формат даты и времени</param>
        /// <returns></returns>
        public string JsonLibaryIgnoreDate(object model, string dateFormatString = "dd-MM-yyyy")
        {
            return JsonConvert.SerializeObject(model, Formatting.None, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new IgnoreGuidsResolver(),
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                DateFormatString = dateFormatString
            });
        }
        /// <summary>
        /// Десереализация Json List классов
        /// </summary>
        /// <param name="result">JSON</param>
        /// <returns></returns>
        public object JsonDeserializeObjectListClass<T>(string result)
        {
           return JsonConvert.DeserializeObject<List<T>>(result);
        }

        /// <summary>
        /// Десериализация Json Класс
        /// </summary>
        /// <param name="result">JSON</param>
        /// <returns></returns>
        public object JsonDeserializeObjectClass<T>(string result)
        {
            List<string> errors = new List<string>();
            JsonConvert.DeserializeObject<T>(result, new JsonSerializerSettings
            {
                Error = delegate(object sender, ErrorEventArgs arg)
                {
                    errors.Add(arg.ErrorContext.Error.Message);
                    arg.ErrorContext.Handled = true;
                },
                NullValueHandling = NullValueHandling.Include
            });
            return JsonConvert.DeserializeObject<T>(result);
        }
        /// <summary>
        /// Десериализация Json Класс
        /// </summary>
        /// <param name="result">JSON</param>
        /// <returns></returns>
        public T JsonDeserializeObjectClassModel<T>(string result)
        {
            List<string> errors = new List<string>();
           return JsonConvert.DeserializeObject<T>(result, new JsonSerializerSettings()
            {
                Error = delegate (object sender, ErrorEventArgs arg)
                {
                    errors.Add(arg.ErrorContext.Error.Message);
                    arg.ErrorContext.Handled = true;
                },
                NullValueHandling = NullValueHandling.Ignore,
                DateFormatString = "dd.MM.yyyy HH:mm"
            });
          //  return JsonConvert.DeserializeObject<T>(result);
        }

    }
}
