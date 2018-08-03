using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using LibaryXMLAutoModelXmlSql.Model.Trebovanie;
using Newtonsoft.Json;

namespace LibaryXMLAuto.ReadOrWrite.SerializationJson
{
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
     }
}
