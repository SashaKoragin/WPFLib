using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace SqlLibaryIfns.ExcelReport.Report
{
   public class ReportExcel
    {
        public void ReportSave(string pathsave, string namesavefile,string namereport, DataSet table)
        {
            var workbookreport = new XLWorkbook();
            var worksheet = workbookreport.Worksheets.Add(namereport);
            worksheet.Cell("A1").InsertTable(table.Tables[0]).Worksheet.Columns().AdjustToContents();
            workbookreport.SaveAs(pathsave + namesavefile+ ".xlsx");
        }
    }
}
