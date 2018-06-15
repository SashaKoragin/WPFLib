using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using LibaryXMLAutoModelXmlSql.Model.FaceError;

namespace LibaryXMLAuto.ReadOrWrite.SerializationJson
{
   public class SerializeJson
    {
        public string Json(Face f)
        {
            MemoryStream ms = new MemoryStream();

            // Serializer the User object to the stream.  
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Face));
            ser.WriteObject(ms, f);
            byte[] json = ms.ToArray();
            ms.Close();
            return Encoding.UTF8.GetString(json, 0, json.Length);
            //DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeObject);
            //try
            //{
            //    object o = jsonFormatter.ReadObject(reader);
            //    return o;
            //}
            //catch (Exception e)
            //{
            //  Console.WriteLine(e);
            //}
            //return null;
        }
     }
}
