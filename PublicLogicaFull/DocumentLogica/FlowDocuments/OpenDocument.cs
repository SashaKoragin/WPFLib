using System.IO;
using System.Windows;
using System.Windows.Documents;


namespace PublicLogicaFull.DocumentLogica.FlowDocuments
{
   public class OpenDocument
    {
        /// <summary>
        /// Функция показа содержимого xml файла без главного элемента
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns>Возвращает документ XML</returns>
        public static FlowDocument DocumentJurnal(string path)
        {
            if (File.Exists(path) & FileLogica.FileInfoLogica.FileLogica.FormatFile(path) == ".xml")
            {
                var xmldoc = new  LibaryXMLAuto.ReadOrWrite.LogicaXml.LogicaXml();
                var documentxml = LibaryXMLAuto.ReadOrWrite.LogicaXml.LogicaXml.Document(path);
                FlowDocument doc = new FlowDocument
                {
                    TextAlignment = TextAlignment.Left,
                    IsOptimalParagraphEnabled = true,
                    IsHyphenationEnabled = true,
                    FontStyle = FontStyles.Italic,
                    Background = System.Windows.Media.Brushes.Yellow,
                    Foreground = System.Windows.Media.Brushes.Blue
                };
                for (int i = 1; i < xmldoc.CountAtribute(documentxml) ; i++)
                {
                    doc.Blocks.Add(new Paragraph(new Run(xmldoc.XmlAtribyte(documentxml, i))));
                }
                return doc;
            }
            return null;
        }
    }
}
