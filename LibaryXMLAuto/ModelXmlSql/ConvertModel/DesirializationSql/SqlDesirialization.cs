using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using LibaryXMLAutoModelXmlSql.Model.Trebovanie;

//using LibaryXMLAutoModelXmlSql.Model.FaceError;

namespace LibaryXMLAuto.ModelXmlSql.ConvertModel.DesirializationSql
{
   public class SqlDesirialization
    {
        /// <summary>
        /// Дессериализация файла xml в объект
        /// </summary>
        /// <param name="reader">путь к файлу xml</param>
        /// <param name="objType">Тип объекта сериализации cs sql файла</param>
        public object ReadXml(XmlReader reader, Type objType)
        {
                XmlSerializer serializer = new XmlSerializer(objType);
                if (serializer.CanDeserialize(reader))
                {
                    try
                    {
                    object o = serializer.Deserialize(reader);
                    return o;
                    }
                    catch (Exception e)
                    {
                      Console.Write(e.Message);
                    }

                }
            return null;
        }
    }
}
