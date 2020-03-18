using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using LibaryXMLAutoModelXmlAuto.MigrationReport;
using LibaryXMLAutoModelXmlSql.Model.Trebovanie;
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
        /// <returns>JSON string</returns>
        public string JsonLibary(object model)
        {
           
         return  JsonConvert.SerializeObject(model,new JsonSerializerSettings()
          {
            NullValueHandling = NullValueHandling.Ignore,
            DateFormatString = "dd-MM-yyyy"
          });
        }
        /// <summary>
        /// Сериализация в json c игнорированием DateTime
        /// </summary>
        /// <param name="model">Объект модели класса</param>
        /// <returns></returns>
        public string JsonLibaryIgnoreDate(object model)
        {
            return JsonConvert.SerializeObject(model, Formatting.None, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new IgnoreGuidsResolver(),
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }
    }
}
