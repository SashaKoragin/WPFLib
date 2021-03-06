﻿using System;
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
        /// <summary>
        /// Сохранение таблицы DataSet по всем листам
        /// </summary>
        /// <param name="pathSaveFullName">Полный путь с именем файла</param>
        /// <param name="tableReport">Набор таблиц для отчета</param>
        public void ReportSaveFullDataSet(string pathSaveFullName, DataSet tableReport)
        {
            foreach (DataTable tableReportTable in tableReport.Tables)
            {
                if (tableReportTable.Columns.Count > 0)
                {
                    XlWorkbook.Worksheets.Add(tableReportTable.TableName).Cell("A1").InsertTable(tableReportTable).Worksheet.Columns().AdjustToContents();
                }
                else
                {
                    XlWorkbook.Worksheets.Add(tableReportTable.TableName).Cell("A1").Value = "Отсутствует отчет в связи с отсутствием данных!!!";
                }
            }
            XlWorkbook.SaveAs(pathSaveFullName);
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
