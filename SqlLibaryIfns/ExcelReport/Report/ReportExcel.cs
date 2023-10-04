using System;
using System.Data;
using System.IO;
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
        /// <param name="pathSave">Путь сохранения</param>
        /// <param name="nameSaveFile">Наименование файла</param>
        /// <param name="nameReport">Наименование листа xlsx</param>
        /// <param name="table">Таблица которая вставляется в отчет</param>
        public void ReportSave(string pathSave, string nameSaveFile,string nameReport, DataSet table)
        {
            var worksheet = XlWorkbook.Worksheets.Add(nameReport);
            worksheet.Cell("A1").InsertTable(table.Tables[0]).Worksheet.Columns().AdjustToContents();
            SaveAsFileXlsx(pathSave + nameSaveFile + ".xlsx");
        }
        /// <summary>
        /// Сохранение отчета
        /// </summary>
        /// <param name="pathSave">Путь сохранения</param>
        /// <param name="nameSaveFile">Наименование файла</param>
        /// <param name="tableReport">Данные для сохранения</param>
        public void ReportSaveFullReport(string pathSave, string nameSaveFile, DataSet tableReport)
        {
            foreach (DataTable tableReportTable in tableReport.Tables)
            {
                if(tableReportTable.TableName.Contains("Pivot"))
                {
                    CreatePivotTables(tableReportTable);
                }
                else
                {
                    try
                    {
                        XlWorkbook.Worksheets.Add(tableReportTable.TableName).Cell("A1").InsertTable(tableReportTable).Worksheet.Columns().AdjustToContents();
                    }
                    catch(Exception ex)
                    {
                        if (XlWorkbook.Worksheets.Count > 0)
                        {
                            XlWorkbook.Worksheets.Delete(tableReportTable.TableName);
                        }
                        XlWorkbook.Worksheets.Add("Ошибка выгрузки").Cell("A1").Value = "Файл слишком большой превышает возможности Excel!!!";
                        XlWorkbook.Worksheets.Worksheet("Ошибка выгрузки").Cell("A2").Value = ex.Message;
                    }
                }
            }
            SaveAsFileXlsx(pathSave + nameSaveFile + ".xlsx");
        }
        /// <summary>
        /// Создание умной таблицы для анализа данных только с  признаком Pivot
        /// </summary>
        /// <param name="dataTable">Таблица для создания умной таблицы</param>
        private void CreatePivotTables(DataTable dataTable)
        {
            var sumSheet = XlWorkbook.Worksheets.Add(dataTable.TableName);
            var sumTable = sumSheet.Cell(1, 1).InsertTable(dataTable, dataTable.TableName, true);
            sumTable.Worksheet.Columns().AdjustToContents();
            var header = sumTable.Range(1, 1, dataTable.Rows.Count, dataTable.Columns.Count);
            var range = sumTable.DataRange;
            var dataRange = sumSheet.Range(header.FirstCell(), range.LastCell());
            var pivotSheet = XlWorkbook.Worksheets.Add($"Свод {dataTable.TableName}");
            var pivotTable = pivotSheet.PivotTables.Add(dataTable.TableName, pivotSheet.Cell(1, 1), dataRange);
            pivotTable.ItemsToRetainPerField = XLItemsToRetain.Automatic;
            pivotTable.FilteredItemsInSubtotals = true;
            pivotTable.AutofitColumns = true;
            pivotTable.ShowPropertiesInTooltips = true;
            pivotTable.ShowColumnStripes = true;
            pivotTable.RepeatRowLabels = true;
            pivotTable.ShowGrandTotalsColumns = true;
            pivotTable.ShowGrandTotalsRows = true;
            pivotTable.ShowEmptyItemsOnRows = true;
            pivotTable.ShowEmptyItemsOnColumns = true;
            pivotTable.ShowExpandCollapseButtons = true;
            pivotTable.ShowValuesRow = true;
            pivotTable.Layout = XLPivotLayout.Tabular;
            pivotTable.Subtotals = XLPivotSubtotals.AtTop;
            foreach (DataColumn dataColumn in dataTable.Columns)
            {
                pivotTable.RowLabels.Add(dataColumn.ColumnName).SubtotalsAtTop = true;
            }
        }

        /// <summary>
        /// Добавление листа в отчет Excel
        /// </summary>
        /// <param name="nameReport">Наименование листа xlsx</param>
        /// <param name="table">Таблица которая вставляется в отчет</param>
        public void ReportAddListFile(string nameReport, DataSet table)
        {
            var worksheet = XlWorkbook.Worksheets.Add(nameReport);
            worksheet.Cell("A1").InsertTable(table.Tables[0]).Worksheet.Columns().AdjustToContents();
        }
        /// <summary>
        /// Сохранение файла Excel
        /// </summary>
        /// <param name="fullPathXlsx">Полный путь</param>
        public void SaveAsFileXlsx(string fullPathXlsx)
        {
            XlWorkbook.SaveAs(fullPathXlsx);
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

        /// <summary>
        /// Конвертация файла в массив данных
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns></returns>
        public Stream DownloadFile(string path)
        {
            return File.OpenRead(path);
        }
        /// <summary>
        /// Конвертация файла в массив данных
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns></returns>
        public byte[] ReadFileByte(string path)
        {
            var file = File.ReadAllBytes(path);
            File.Delete(path);
            return file;
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
