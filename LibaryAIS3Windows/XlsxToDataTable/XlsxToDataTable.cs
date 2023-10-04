using System;
using System.Data;
using System.Globalization;
using Net.SourceForge.Koogra;
using System.Text.RegularExpressions;

namespace LibraryAIS3Windows.XlsxToDataTable
{
   public class XlsxToDataTable
    {
        /// <summary>
        /// Перевод листа xlsx в DataTable
        /// </summary>
        /// <param name="pathXlsx">Путь к xlsx</param>
        /// <param name="sheetName">Имя листа</param>
        /// <param name="indexColumn">Индекс колонки по умолчанию 1</param>
        /// <param name="indexRow">Индекс строки с какой начинать</param>
        /// <returns></returns>
        public DataTable GetDateTableXslx(string pathXlsx, string sheetName, int indexColumn = 1, uint indexRow = 0)
        {
            DataTable dt = new DataTable();
            Regex regex = new Regex(@"^\d+$");
            var xlFile = WorkbookFactory.GetExcel2007Reader(pathXlsx);
            var sheet = xlFile.Worksheets.GetWorksheetByName(sheetName, true);

            uint minRow = sheet.FirstRow + indexRow;
            uint maxRow = sheet.LastRow;

            IRow firstRow = sheet.Rows.GetRow(minRow);

            uint minCol = sheet.FirstCol;
            uint maxCol = sheet.LastCol;

            for (uint i = minCol; i <= maxCol; i++)
            {
                var valueNameColums = firstRow.GetCell(i).GetFormattedValue();
                if (!dt.Columns.Contains(valueNameColums))
                {
                    dt.Columns.Add(valueNameColums);
                }
                else
                {
                    dt.Columns.Add(string.Concat(valueNameColums, indexColumn));
                    indexColumn++;
                }
            }
            for (uint i = minRow + 1; i <= maxRow; i++)
            {
                IRow row = sheet.Rows.GetRow(i);
                if (row != null)
                {
                    DataRow dr = dt.NewRow();
                    for (uint j = minCol; j <= maxCol; j++)
                    {
                        ICell cell = row.GetCell(j);
                        if (cell != null)
                        {
                            if (cell.Value != null)
                            {
                                double result;
                                // Try parsing in the current culture
                                if (!double.TryParse(cell.Value.ToString(), NumberStyles.Float, CultureInfo.CurrentCulture, out result) &&
                                    // Then try in US english
                                    !double.TryParse(cell.Value.ToString(), NumberStyles.Float,
                                        CultureInfo.GetCultureInfo("en-US"), out result) &&
                                    // Then in neutral language
                                    !double.TryParse(cell.Value.ToString(), NumberStyles.Float,
                                        CultureInfo.InvariantCulture, out result))
                                {
                                    dr[Convert.ToInt32(j)] = cell.Value != null ? cell.GetFormattedValue() : string.Empty;
                                }
                                else
                                {
                                    if (cell.Value.ToString().Length == 20 && regex.IsMatch(cell.Value.ToString()))
                                    {
                                        dr[Convert.ToInt32(j)] = cell.Value != null ? cell.GetFormattedValue() : string.Empty;
                                    }
                                    else
                                    {
                                        var isDate = cell.GetFormattedValue();
                                        DateTime dateTime;
                                        bool isValid = DateTime.TryParseExact(isDate, "MM-dd-yy", new CultureInfo("en-US"), DateTimeStyles.AssumeLocal, out dateTime);
                                        if (isValid)
                                        {
                                            dr[Convert.ToInt32(j)] = dateTime;
                                        }
                                        else
                                        {
                                            isValid = DateTime.TryParseExact(isDate, "MMddyyyy", new CultureInfo("en-US"), DateTimeStyles.AssumeLocal, out dateTime);
                                            if (isValid)
                                            {
                                                dr[Convert.ToInt32(j)] = dateTime;
                                            }
                                            else
                                            {
                                                isValid = DateTime.TryParseExact(isDate, "dd.MM.yyyy H:mm:ss", new CultureInfo("en-US"), DateTimeStyles.AssumeLocal, out dateTime);
                                                if (isValid)
                                                {
                                                    dr[Convert.ToInt32(j)] = dateTime;
                                                }
                                                else
                                                {
                                                    dr[Convert.ToInt32(j)] = result.ToString();
                                                }

                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                dr[Convert.ToInt32(j)] = null;
                            }
                        }
                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }


        /// <summary>
        /// Перевод листа xlsx в DataTable со сложным форматом
        /// </summary>
        /// <param name="pathXlsx">Путь к xlsx</param>
        /// <param name="sheetName">Имя листа</param>
        /// <param name="indexColumn">Индекс колонки по умолчанию 1</param>
        /// <param name="indexRow">Индекс строки с какой начинать</param>
        /// <returns></returns>
        public DataTable GetDateTableXslxFormatNodDouble(string pathXlsx, string sheetName, int indexColumn = 1, uint indexRow = 0)
        {
            DataTable dt = new DataTable();
            var xlFile = WorkbookFactory.GetExcel2007Reader(pathXlsx);
            var sheet = xlFile.Worksheets.GetWorksheetByName(sheetName, true);

            uint minRow = sheet.FirstRow + indexRow;
            uint maxRow = sheet.LastRow;

            IRow firstRow = sheet.Rows.GetRow(minRow);

            uint minCol = sheet.FirstCol;
            uint maxCol = sheet.LastCol;

            for (uint i = minCol; i <= maxCol; i++)
            {
                var valueNameColums = firstRow.GetCell(i).GetFormattedValue();
                if (!dt.Columns.Contains(valueNameColums))
                {
                    dt.Columns.Add(valueNameColums);
                }
                else
                {
                    dt.Columns.Add(string.Concat(valueNameColums, indexColumn));
                    indexColumn++;
                }
            }
            for (uint i = minRow + 1; i <= maxRow; i++)
            {
                IRow row = sheet.Rows.GetRow(i);
                if (row != null)
                {
                    DataRow dr = dt.NewRow();
                    for (uint j = minCol; j <= maxCol; j++)
                    {
                        ICell cell = row.GetCell(j);
                        if (cell != null)
                        {
                            if (cell.Value != null)
                            {
                                    dr[Convert.ToInt32(j)] = cell.Value != null ? cell.GetFormattedValue() : string.Empty;
                            }
                            else
                            {
                                dr[Convert.ToInt32(j)] = null;
                            }
                        }
                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }

    }
}
