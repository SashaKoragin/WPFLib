using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using LibaryXMLAutoModelXmlSql.Model.Trebovanie;

namespace LibaryXMLAuto.ReadOrWrite.SerializationJson
{
    /// <summary>
    /// Сериализация JSON
    /// </summary>
   public class SerializeJson
    {
        /// <summary>
        /// Разбор модели на строку JSON
        /// --Данныю вещь можно попробовать делать с помощью официальных библиотек!!!--
        /// </summary>
        /// <param name="model">Модель класса для его преобразование в string JSON</param>
        /// <returns>string JSON</returns>
        public string Json(object model)
        {
            MemoryStream ms = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(SysNum), new DataContractJsonSerializerSettings()
            {
                DateTimeFormat = new DateTimeFormat("dd-MM-yyyy")
            });
            ser.WriteObject(ms, model);
            byte[] json = ms.ToArray();
            ms.Close();
            return Encoding.UTF8.GetString(json, 0, json.Length);
        }
     }
}
