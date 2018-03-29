using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LibaryXMLAuto.ReadOrWrite.CreateElement
{
   internal class CreteElement
    {
        /// <summary>
        /// Создание строкового Атрибута XML
        /// </summary>
        /// <param name="xmlDocument">XML Document</param>
        /// <param name="nameAtribute">Имя атрибута</param>
        /// <param name="znacenie">Значение атрибута</param>
        /// <returns>XML атрибут который можно добавить</returns>
        internal static XmlAttribute AtributeAddString(XmlDocument xmlDocument, string nameAtribute, string znacenie)
        {
            XmlAttribute atributeinn= xmlDocument.CreateAttribute(nameAtribute);
            XmlText inntext = xmlDocument.CreateTextNode(znacenie);
            atributeinn.AppendChild(inntext);
            return atributeinn;
        }
        /// <summary>
        /// Создание текущей даты Атрибута XML
        /// </summary>
        /// <param name="xmlDocument">XML Document</param>
        /// <param name="nameAtribute">Имя атрибута</param>
        /// <returns>XML атрибут который можно добавить</returns>
        internal static XmlAttribute AtributeAddDateNow(XmlDocument xmlDocument, string nameAtribute)
        {
            XmlAttribute atributeinn = xmlDocument.CreateAttribute(nameAtribute);
            XmlText inntext = xmlDocument.CreateTextNode(DateTime.Now.ToString("O"));
            atributeinn.AppendChild(inntext);
            return atributeinn;
        }
        
    }
}
