using System.Data;
using System.IO;
using ClosedXML.Excel;

namespace LibaryXMLAuto.Converts.ConvertXmlToXslx
{
   public class ConvertXmltoXlsx
    {
        /// <summary>
        /// Конвертирует xml d Excel
        /// </summary>
        /// <param name="pathxml">Файл XML</param>
        /// <param name="savereport">Путь куда сохранить</param>
        /// <returns>Возвращает информацию об Excel файле</returns>
        public static FileInfo ConvertXmlToXls(string pathxml, string savereport)
        {
                FileInfo file = new FileInfo(pathxml);
                string pathsavefull = savereport + file.Name + ".xlsx";
                DataSet table = new DataSet(file.Name);
                table.ReadXml(file.FullName);
                XLWorkbook workbooks = new XLWorkbook();
                workbooks.Worksheets.Add(table);
                workbooks.SaveAs(pathsavefull);
            return new FileInfo(pathsavefull);
        }
    }
}
