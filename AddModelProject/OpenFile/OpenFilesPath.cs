using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows;
using ClosedXML.Excel;


namespace AddModelProject.OpenFile
{
   public class OpenFilesPath
    {
        public static void ConvertXmlToXls(string pathxml,string savepath)
        {
            try
            {
                FileInfo file = new FileInfo(pathxml);
                DataSet table = new DataSet(file.Name);
                table.ReadXml(file.FullName);
                XLWorkbook workbooks = new XLWorkbook();
                workbooks.Worksheets.Add(table);
                workbooks.SaveAs(@"C:\222\"+file.Name+".xlsx");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }



        public static void Openxls(string fileName)
        {
            var startInfo = new ProcessStartInfo(fileName)
            {
                UseShellExecute = true,

            };
            Process.Start(startInfo);
        }
    }
}
