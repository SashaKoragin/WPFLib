using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
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
            //Надо думать над конвертацией даты
            //foreach (DataTable dataTable in table.Tables)
            //{
            //     dataTable.Columns[""].GetType
            //}
            //Regex.IsMatch(, "("\"d{4}(-"\"d{2}){2}T"\"d{2}(:"\"d{2}){2})")
                 XLWorkbook workbooks = new XLWorkbook();
                workbooks.Worksheets.Add(table);
                workbooks.SaveAs(pathsavefull);
            return new FileInfo(pathsavefull);
        }
    }
}