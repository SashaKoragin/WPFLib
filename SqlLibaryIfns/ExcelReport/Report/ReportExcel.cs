using System.Data;
using ClosedXML.Excel;

namespace SqlLibaryIfns.ExcelReport.Report
{
   public class ReportExcel
    {
        /// <summary>
        /// Метод сохранения отчета в файл
        /// </summary>
        /// <param name="pathsave">Путь сохранения</param>
        /// <param name="namesavefile">Наименование файла</param>
        /// <param name="namereport">Наименование листа xlsx</param>
        /// <param name="table">Таблица которая вставляется в отчет</param>
        public void ReportSave(string pathsave, string namesavefile,string namereport, DataSet table)
        {
            var workbookreport = new XLWorkbook();
            var worksheet = workbookreport.Worksheets.Add(namereport);
            worksheet.Cell("A1").InsertTable(table.Tables[0]).Worksheet.Columns().AdjustToContents();
            workbookreport.SaveAs(pathsave + namesavefile+ ".xlsx");
        }
    }
}
