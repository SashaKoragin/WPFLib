using System.Xml;

namespace LibaryXMLAuto.ReadOrWrite.LogicaXml
{
   public class LogicaXml
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
        /// Количество атрибутов в документе xml
        /// </summary>
        /// <param name="doc">Документ XML</param>
        /// <returns>Количество атрибутов</returns>
        public int CountAtribute(XmlDocument doc)
        {
            return doc.DocumentElement.ChildNodes.Count;
        }
        /// <summary>
        /// Возвращаем текст XML по индексу элемента
        /// </summary>
        /// <param name="doc">Документ</param>
        /// <param name="i">Индекс</param>
        /// <returns></returns>
        public string XmlAtribyte(XmlDocument doc, int i)
        {

            return doc.DocumentElement.ChildNodes.Item(i).OuterXml;
        }

    }
}
