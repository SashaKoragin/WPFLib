using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace LibaryXMLAuto.ReadOrWrite
{
   public class XmlReadOrWrite
    {
        /// <summary>
        /// Открывает документ xml
        /// </summary>
        /// <param name="path">Путь к Xml</param>
        /// <returns>Документ</returns>
        public static XmlDocument Document(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            return doc;
        }
        /// <summary>
        /// Дессериализация в объекта
        /// </summary>
        /// <param name="filename">путь к файлу xml</param>
        /// <param name="objType">Тип объекта сериализации</param>
        public object ReadXml(string filename, Type objType)
        {
            using (Stream fs = new FileStream(filename, FileMode.Open))
            {
                XmlReader reader = new XmlTextReader(fs);
                XmlSerializer serializer = new XmlSerializer(objType);
                if (serializer.CanDeserialize(reader))
                {
                    object o = serializer.Deserialize(reader);
                    return o;
                }
            }
            return null;
        }
        /// <summary>
        /// Удаление Атрибута Образец поиска /players/player[@name='значение']
        /// </summary>
        /// <param name="pathxml"></param>
        /// <param name="atribut"></param>
        public void DeleteAtributXml(string pathxml, string atribut)
        {
            var doc = Document(pathxml);
            XmlNode node = doc.SelectSingleNode(atribut);
            node.ParentNode.RemoveChild(node);
            doc.Save(pathxml);
        }
        /// <summary>
        /// Метод Добавление в журнал ошибки по схеме ErrorJurnal.xsd
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <param name="znacenie">Значение в котором ошибка</param>
        /// <param name="branch">Ветка автоматизации</param>
        /// <param name="err">Ошибка</param>
        public void AddElementError(string path , string znacenie, string branch, string err)
        {
            var doc = Document(path);
            XmlElement xRoot = doc.DocumentElement;
            XmlElement error = doc.CreateElement("Error");
            XmlAttribute errors = doc.CreateAttribute("Error");
            XmlAttribute inn = doc.CreateAttribute("Inn");
            XmlAttribute system = doc.CreateAttribute("System");
            // создаем текстовые значения для элементов и атрибута
            XmlText errorstext = doc.CreateTextNode(err);
            XmlText inntext = doc.CreateTextNode(znacenie);
            XmlText systemtext = doc.CreateTextNode(branch);
            //добавляем узлы
            inn.AppendChild(inntext);
            errors.AppendChild(errorstext);
            system.AppendChild(systemtext);
            error.Attributes.Append(inn);
            error.Attributes.Append(errors);
            error.Attributes.Append(system);
            xRoot.AppendChild(error);
            doc.Save(path);
        }
        /// <summary>
        /// Метод Добавление в журнал отработаных значений по схеме OkJurnal.xsd
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <param name="znacenie">Значение</param>
        /// <param name="ok">Отработано</param>
        public void AddElementOk(string path, string znacenie,  string ok)
        {
            var doc = Document(path);
            XmlElement xRoot = doc.DocumentElement;
            XmlElement okey = doc.CreateElement("Ok");
            XmlAttribute inn = doc.CreateAttribute("Inn");
            XmlAttribute message = doc.CreateAttribute("Message");
            // создаем текстовые значения для элементов и атрибута
            XmlText inntext = doc.CreateTextNode(znacenie);
            XmlText messagetext = doc.CreateTextNode(ok);
            //добавляем узлы
            inn.AppendChild(inntext);
            message.AppendChild(messagetext);
            okey.Attributes.Append(inn);
            okey.Attributes.Append(message);
            xRoot.AppendChild(okey);
            doc.Save(path);
        }

        public int CountAtribute(string path)
        {
            var doc = Document(path);
            return doc.DocumentElement.ChildNodes.Count;
        }
    }
}
