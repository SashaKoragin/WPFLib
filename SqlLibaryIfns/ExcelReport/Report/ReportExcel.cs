using System;
using System.Data;
using ClosedXML.Excel;

namespace SqlLibaryIfns.ExcelReport.Report
{
   public class ReportExcel:IDisposable
    {
        private XLWorkbook XlWorkbook { get; set; }
       public ReportExcel()
        {
            Dispose();
            XlWorkbook = new XLWorkbook();
        }

        /// <summary>
        /// Метод сохранения отчета в файл
        /// </summary>
        /// <param name="pathsave">Путь сохранения</param>
        /// <param name="namesavefile">Наименование файла</param>
        /// <param name="namereport">Наименование листа xlsx</param>
        /// <param name="table">Таблица которая вставляется в отчет</param>
        public void ReportSave(string pathsave, string namesavefile,string namereport, DataSet table)
        {
            var worksheet = XlWorkbook.Worksheets.Add(namereport);
            worksheet.Cell("A1").InsertTable(table.Tables[0]).Worksheet.Columns().AdjustToContents();
            XlWorkbook.SaveAs(pathsave + namesavefile+ ".xlsx");
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                XlWorkbook?.Dispose();
                XlWorkbook = null;
            }
        }
        public void Dispose()
        {
            Dispose(true);
        }
    }
}
