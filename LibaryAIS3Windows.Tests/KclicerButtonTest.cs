// <copyright file="KclicerButtonTest.cs">Copyright ©  2018</copyright>

using System;
using LibraryAIS3Windows.ButtonsClikcs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryAIS3Windows.AutomationsUI.LibaryAutomations;
using LibraryAIS3Windows.Window;
using System.Linq;
using AutoIt;
using System.Windows.Automation;
using System.Runtime.InteropServices;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using AttributeHelperModelXml;
using Ifns51.FromAis;
using LibraryAIS3Windows.ButtonFullFunction.PreCheck;
using Net.SourceForge.Koogra;
using EfDatabaseAutomation.Automation.BaseLogica.XsdShemeSqlLoad.XsdAllBodyData;
using EfDatabaseAutomation.Automation.BaseLogica.XsdShemeSqlLoad;
using LibraryAIS3Windows.ButtonFullFunction.PublicGlobalFunction;
using LibraryAIS3Windows.AutomationsUI.Otdels.PublicJournal129And121;
using System.DirectoryServices.AccountManagement;
using System.Globalization;
using System.Text.RegularExpressions;
using LibraryAIS3Windows.AutomationsUI.Otdels.PreCheck;

namespace LibraryAIS3Windows.Tests
{
    /// <summary>Этот класс содержит параметризованные модульные тесты для KclicerButton</summary>
    [TestClass]
    public partial class KclicerButtonTest
    {
        [TestMethod]
        public void TestMet()
        {
            KclicerButton s0 = new KclicerButton();
            s0.Click15(null, null, null);
        }
        [TestMethod]
        public void Method()
        {
            KclicerButton s20 = new KclicerButton();
            s20.Click20(null, null);
        }
        [TestMethod]
        public void MethodTrebovanie()
        {
            KclicerButton s20 = new KclicerButton();
            s20.Click22(null, null, null);
        }
        [TestMethod]
        public void MethodStatementOfficeNote()
        {
            KclicerButton s20 = new KclicerButton();
            s20.Click25(null, null, null);
        }

        [TestMethod]
        public void TestCombobox()
        {
            var T = @"List`1 row 023";

          var   y = Regex.Matches(T, @"(\d{1,4})").Cast<Match>().Select(m => m.Value).ToArray().Last();
            //var kndNotSendA01 = new[] { "1160098", "1160099", "115050", "1165009" };

            //string dateDelivery = null;

            //string knd = "1160076";

            //var r = !string.IsNullOrEmpty(dateDelivery);
            //var t = !kndNotSendA01.Contains(knd);
            //if (!string.IsNullOrEmpty(dateDelivery) && !kndNotSendA01.Contains(knd))
            //{


            //}
            //else
            //{

            //}

        }

        [TestMethod]
        public void Okp2Reshenia()
        {
          //  int year = 2021;
          ////  var year2 = "4 кв. 2020;";
          //  LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
          //  var path = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:InspectorDeclarationsView\\AutomationId:preFilterControl\\AutomationId:mainPanel\\AutomationId:comboTaxPeriod";
          //  if (libraryAutomation.IsEnableElements(path, null, true) != null)
          //  {

          //      LibraryAutomations elem;
          //      var elemClick = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindElement)[0];
          //      var valuePatternYear = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(elemClick);
          //      AutoItX.Send(string.Format(ButtonConstant.UpCountClick, 20));
          //      libraryAutomation.ClickElement(elemClick);
          //      elem = new LibraryAutomations(TreeWalker.RawViewWalker.GetFirstChild(libraryAutomation.RootAutomationElements));
          //      var elemSelect = elem.SelectAutomationColrction(elem.RootAutomationElements)[0];
          //        elem.SelectAutomationColrction(elemSelect).Cast<AutomationElement>().Where(x => x.Current.Name.Contains(year.ToString())).ToList().ForEach(x => {
          //            if (!valuePatternYear.Contains(x.Current.Name))
          //            {
          //                libraryAutomation.ClickElement(x, -65);
          //            }
                      
          //            //libraryAutomation.SelectionComboBoxPattern(x);
          //        });
          //      valuePatternYear = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(elemClick);
          //      libraryAutomation.ClickElement(elemClick, -45, 0, 2);

          //      elem.SelectAutomationColrction(elemSelect).Cast<AutomationElement>().Where(x => x.Current.Name.Contains((year - 1).ToString())).ToList().ForEach(x => {
          //          // libraryAutomation.SelectionComboBoxPattern(x);
          //          if (!valuePatternYear.Contains(x.Current.Name))
          //          {
          //              libraryAutomation.ClickElement(x, -65);
          //          }
          //      });
          //      valuePatternYear = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(elemClick);
          //      libraryAutomation.ClickElement(elemClick, -45, 0, 2);
          //      elem.SelectAutomationColrction(elemSelect).Cast<AutomationElement>().Where(x => x.Current.Name.Contains((year - 2).ToString())).ToList().ForEach(x => {
          //          //libraryAutomation.SelectionComboBoxPattern(x);
          //          if (!valuePatternYear.Contains(x.Current.Name))
          //          {
          //              libraryAutomation.ClickElement(x, -65);
          //          }
          //      });
          //      valuePatternYear = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(elemClick);
          //      libraryAutomation.ClickElement(elemClick, -45, 0, 2);

          //      elem.SelectAutomationColrction(elemSelect).Cast<AutomationElement>().Where(x => x.Current.Name.Contains((year - 3).ToString())).ToList().ForEach(x => {
          //          if (!valuePatternYear.Contains(x.Current.Name))
          //          {
          //              libraryAutomation.ClickElement(x, -65);
          //          }
          //          //libraryAutomation.SelectionComboBoxPattern(x);
          //      });
          //  }
        }

        /// <summary>
        /// Если выходные то плюсуем
        /// </summary>
        /// <param name="dateTime">Дата для проверки выходного дня</param>
        /// <returns></returns>
        private DateTime IsWeekends(DateTime dateTime)
        {
            if (dateTime.DayOfWeek == DayOfWeek.Saturday)
                dateTime = dateTime.AddDays(2);
            if (dateTime.DayOfWeek == DayOfWeek.Sunday)
                dateTime = dateTime.AddDays(1);
            return dateTime;
        }


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
                                if (!double.TryParse(cell.Value.ToString(), NumberStyles.Any, CultureInfo.CurrentCulture, out result) &&
                                    // Then try in US english
                                    !double.TryParse(cell.Value.ToString(), NumberStyles.Any,
                                        CultureInfo.GetCultureInfo("en-US"), out result) &&
                                    // Then in neutral language
                                    !double.TryParse(cell.Value.ToString(), NumberStyles.Any,
                                        CultureInfo.InvariantCulture, out result))
                                {
                                    dr[Convert.ToInt32(j)] = cell.Value != null ? cell.GetFormattedValue() : string.Empty;
                                }
                                else
                                {
                                    dr[Convert.ToInt32(j)] = result.ToString();
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
    


    [TestMethod]
        public void Send()
        {
            var pathXlsx = @"D:\WWW.xlsx";
            var sheetName = @"1";
            DataTable dataTable = GetDateTableXslx(pathXlsx, sheetName);
            dataTable.Columns.Remove(dataTable.Columns[0]);
            DataNamesMapper<BookPurchase> mapper = new DataNamesMapper<BookPurchase>();
            var bookSales = new ArrayBodyDoc() { BookPurchase = mapper.Map(dataTable).ToArray() };
        }
        

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        private const UInt32 WM_CLOSE = 0x0010;

        void CloseWindow(IntPtr hwnd)
        {
            SendMessage(hwnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
        }

        [TestMethod]
        public void TestTableMapper()
        {
            DataBaseElementAdd date = new DataBaseElementAdd();
            var t = new AisParsedData();
            date.AddCashBankAllUlFace("", "D:\\13082020_09-36.xlsx", "Sheet1");
        }
        [TestMethod]
        public void TestTableIkn()
        {
            using (PrincipalContext context = new PrincipalContext(ContextType.Domain, "regions.tax.nalog.ru"))
            {
                using (var user = UserPrincipal.FindByIdentity(context, "7751-00-469"))
                {

                    var group = user.GetGroups();
                    var groups = new string[group.Count()];
                    var i = 0;
                    foreach (var gr in group)
                    {
                        groups[i] = gr.Name;
                        i++;
                    }
                }
            }
        }


            public static void SetSelectedComboBoxItem(AutomationElement
comboBox, string item)
        {
            AutomationPattern automationPatternFromElement =
    GetSpecifiedPattern(comboBox,
    "ExpandCollapsePatternIdentifiers.Pattern");

            ExpandCollapsePattern expandCollapsePattern =
    comboBox.GetCurrentPattern(automationPatternFromElement) as
    ExpandCollapsePattern;

            expandCollapsePattern.Expand();
            expandCollapsePattern.Collapse();

            AutomationElement listItem =
    comboBox.FindFirst(TreeScope.Subtree, new
    PropertyCondition(AutomationElement.NameProperty, item));

            automationPatternFromElement = GetSpecifiedPattern(listItem,
    "SelectionItemPatternIdentifiers.Pattern");

            SelectionItemPattern selectionItemPattern =
    listItem.GetCurrentPattern(automationPatternFromElement) as
    SelectionItemPattern;

            selectionItemPattern.Select();
        }

        private static AutomationPattern
GetSpecifiedPattern(AutomationElement element, string patternName)
        {
            AutomationPattern[] supportedPattern = element.GetSupportedPatterns();

            foreach (AutomationPattern pattern in supportedPattern)
            {
                if (pattern.ProgrammaticName == patternName)
                    return pattern;
            }

            return null;
        }

        public class GetFile
        {
            public string namePath { get; set; }
            public DateTime DateWrite { get; set; }
        }
    }


    public static class DateTimeExtensions
    {
        public static DateTime AddWorkdays(this DateTime originalDate, int workDays)
        {
            DateTime tmpDate = originalDate;
            while (workDays > 0)
            {
                tmpDate = tmpDate.AddDays(1);
                if (tmpDate.DayOfWeek < DayOfWeek.Saturday &&
                    tmpDate.DayOfWeek > DayOfWeek.Sunday &&
                    !tmpDate.IsHoliday())
                    workDays--;
            }
            return tmpDate;
        }

        public static bool IsHoliday(this DateTime originalDate)
        {
            // INSERT YOUR HOlIDAY-CODE HERE!
            return false;
        }
    }

}
