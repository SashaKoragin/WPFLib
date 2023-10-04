using System;
using LibraryAIS3Windows.ButtonsClikcs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryAIS3Windows.AutomationsUI.LibaryAutomations;
using LibraryAIS3Windows.Window;
using System.Linq;
using System.Windows.Automation;
using System.Runtime.InteropServices;
using System.Data;
using Windows.ApplicationModel.Contacts;
using AttributeHelperModelXml;
using XPlat.ApplicationModel.DataTransfer;
using LibraryAIS3Windows.ButtonFullFunction.PreCheck;
using Net.SourceForge.Koogra;
using EfDatabaseAutomation.Automation.BaseLogica.XsdShemeSqlLoad.XsdAllBodyData;
using EfDatabaseAutomation.Automation.BaseLogica.XsdShemeSqlLoad;
using LibraryAIS3Windows.ButtonFullFunction.PublicGlobalFunction;
using LibraryAIS3Windows.AutomationsUI.Otdels.PublicJournal129And121;
using System.DirectoryServices.AccountManagement;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using LibraryAIS3Windows.AutomationsUI.Otdels.PreCheck;
using System.Windows.Automation.Text;
using System.Text;
using DocumentFormat.OpenXml.Drawing;
using Windows.ApplicationModel.DataTransfer;
using Clipboard = Windows.ApplicationModel.DataTransfer.Clipboard;
using AutoIt;
using LibraryAIS3Windows.AutomationsUI.Otdels.Okp6;
using LibraryAIS3Windows.Window.Otdel.Orn.Nbo;

namespace LibraryAIS3Windows.Tests
{
    /// <summary>Этот класс содержит параметризованные модульные тесты для KclicerButton</summary>
    [TestClass]
    public partial class KclicerButtonTest
    {
        [TestMethod]
        public void TestMet()
        {
            var kbk = "18210102040011000110";
            var Inn = "502499333103";
            var InnMo = "5024002119";
            var KppMo = "502401001";
            var Oktmo = "46744000";
            var bik = "004525987";
            var Name = "Управление Федерального казначейства по Московской области";
            var KbkCash = "03100643000000014800";
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);

            while (true)
            {

                if (libraryAutomation.IsEnableElements(IncomeJournalKrsb.DateResh, null, false, 5) != null)
                {
                    libraryAutomation.SetLegacyIAccessibleValuePattern(DateTime.Now.ToString("dd.MM.yy"));
                    var list = libraryAutomation.SelectAutomationColrction(libraryAutomation.IsEnableElements(IncomeJournalKrsb.GridSelect)).Cast<AutomationElement>().Where(elem => elem.Current.Name.Contains("List`1 row ")).Distinct();
                    foreach (var row in list)
                    {
                        var elemCheck = libraryAutomation.SelectAutomationColrction(row).Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("выбор"));
                        libraryAutomation.ClickElement(elemCheck);
                    }
                    break;
                }
            }

            //while (true)
            //{
            //    if (libraryAutomation.IsEnableElements(IncomeJournalKrsb.MemoNum, null, false, 5) != null)
            //    {
            //        libraryAutomation.SetLegacyIAccessibleValuePattern("1");
            //        libraryAutomation.IsEnableElements(IncomeJournalKrsb.Data, null, true);
            //        libraryAutomation.SetLegacyIAccessibleValuePattern(DateTime.Now.ToString("dd.MM.yyyy"));
            //        libraryAutomation.IsEnableElements(IncomeJournalKrsb.InnMemo, null, true);
            //        libraryAutomation.SetLegacyIAccessibleValuePattern(Inn);
            //        libraryAutomation.IsEnableElements(IncomeJournalKrsb.Status, null, true);
            //        libraryAutomation.SetLegacyIAccessibleValuePattern("13");
            //        libraryAutomation.IsEnableElements(IncomeJournalKrsb.Kbk, null, true);
            //        libraryAutomation.SetLegacyIAccessibleValuePattern(kbk);
            //        libraryAutomation.IsEnableElements(IncomeJournalKrsb.Inn, null, true);
            //        libraryAutomation.SetLegacyIAccessibleValuePattern(InnMo);
            //        libraryAutomation.IsEnableElements(IncomeJournalKrsb.Kpp, null, true);
            //        libraryAutomation.SetLegacyIAccessibleValuePattern(KppMo);
            //        libraryAutomation.IsEnableElements(IncomeJournalKrsb.Oktmo, null, true);
            //        libraryAutomation.SetLegacyIAccessibleValuePattern(Oktmo);
            //        libraryAutomation.IsEnableElements(IncomeJournalKrsb.KbkCash, null, true);
            //        libraryAutomation.SetLegacyIAccessibleValuePattern(KbkCash);
            //        libraryAutomation.IsEnableElements(IncomeJournalKrsb.BicCash, null, true);
            //        libraryAutomation.SetLegacyIAccessibleValuePattern(bik);
            //        libraryAutomation.IsEnableElements(IncomeJournalKrsb.NameCash, null, true);
            //        libraryAutomation.SetLegacyIAccessibleValuePattern(Name);
            //        break;
            //    }
            //}



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
            s20.Click25(null);
        }

        [TestMethod]
        public void TestCombobox()
        {
            var textErrorAndNotError = "Просмотр документа";
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
           // 
           // PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ViewDeclarationView);



            //  if (libraryAutomation.IsEnableElements(Journal129AndJournal121.ViewDeclaration, null, true, 1) != null)
            //    {
          //  libraryAutomation.IsExpandOpen(Journal129AndJournal121.ViewDeclaration);

        }

        [TestMethod]
        public void Okp2Reshenia()
        {
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            if (libraryAutomation.IsEnableElements(JournalSolutionCalculations.RichTextBox) != null)
            {

                var pattern = libraryAutomation.FindElement.GetSupportedPatterns();
                TextPattern textPatern = (TextPattern)libraryAutomation.FindElement.GetCurrentPattern(TextPattern.Pattern);
                var html = "<br>DataP</br><br>DataP</br><br>DataP</br>";
               
                 var htmlFormat = HtmlFormatHelper.CreateHtmlFormat(html);
                var dataP = new DataPackage();
                dataP.SetHtmlFormat(htmlFormat);
           
               // var stringB = new StringBuilder();
                // stringB.Append("\t");
                // stringB.Append("\r");

                //stringB.Append(@"\red0\green0\blue0");
                // stringB.Append("\n");
                //  stringB.Append(@"{\rtf1");
                //stringB.Append(@"\trowd");
                //for (int i = 0;  i < 5; i++)
                //    {
                //    stringB.Append(@"\cellx1000");
                //    stringB.Append(@"\cellx2000");
                //    stringB.Append(@"\cellx3000");
                //    stringB.Append(@"\intbl \cell \row");
                //}
                //stringB.Append(@"\pard");
                //stringB.Append("}");
                //var ob = new DataTable();
                //ob.Columns.Add("ttt");
                //ob.Columns.Add("tttsdff");

                Clipboard.SetContent(dataP);
               
                var y = AutoIt.AutoItX.ClipGet();
                //AutoIt.AutoItX.ClipPut(stringB.ToString());
                libraryAutomation.FindElement.SetFocus();
                SendKeys.SendWait("^v");

           

               //  var t = textPatern.DocumentRange.GetText(-1).Trim();
               
            }
                
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
            PublicGlobalFunction.CloseProcessProgram("AcroRd32");
        }


        [TestMethod]
        public void TestNewSendForm()
        {
            var period = "за 12 месяцев, квартальный";
            var god = 2021;
            //Проверка КНД Выставляем шаблон
            if (period != "за 12 месяцев, квартальный" && god <= 2022)
            {
                //Не меняем 30 на 25
            }
            else
            {
                //Меняем 30 на 25
            }

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
        /// <summary>
        /// Тест расчета месяца
        /// </summary>
        [TestMethod]
        public void TestMouthDeclaration()
        {
            using (var context = new EfDatabaseAutomation.Automation.Base.Automation())
            {
              var t = context.DeclarationDataFls.Where(x => x.RegNumDecl == 1457848780).ToArray();

             var s =  t.Where(model => model.CodeString == "П0388").Select(cash => Convert.ToDouble(cash.Error)).Sum();
            }
        }
        [TestMethod]
        public void TestDates()
        {
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ErrorGroup3);
            if (libraryAutomation.IsEnableElements(Journal129AndJournal121.ListCashFaceGr3, null, true) != null)
            {
                AutomationElement cashAdd;
                while ((cashAdd = libraryAutomation.IsEnableElements(Journal129AndJournal121.ListCashFaceGr3, null, false, 10)) != null)
                {
                    while (true)
                    {
                       var elem = libraryAutomation.SelectAutomationColrction(cashAdd)
                                         .Cast<AutomationElement>().Where(elems => elems.Current.ClassName == "Button").ToArray();
                     
                        libraryAutomation.ClickElement(elem[2]);
                        if (libraryAutomation.IsEnableElements(Journal129AndJournal121.ButtonGroup3Add2Add, null, true) != null)
                        {
                            libraryAutomation.ClickElement(libraryAutomation.IsEnableElements(Journal129AndJournal121.ButtonGroup3Add2Add));
                            break;
                        }
                    }
                    break;
                }
                LibraryAutomations libraryAutomationDiaolog = new LibraryAutomations(WindowsAis3.AisNalog3);
                AutoItX.Sleep(2000);
                LibraryAutomations libraryAutomationAddObject = new LibraryAutomations(TreeWalker.RawViewWalker.GetPreviousSibling(libraryAutomationDiaolog.RootAutomationElements));
                PublicGlobalFunction.WindowElementClick(libraryAutomationAddObject, Journal129AndJournal121.WinSelect1);
                AutomationElement listView;
                while ((listView = libraryAutomationAddObject.IsEnableElements(Journal129AndJournal121.WinSelect1Select, null, false, 10)) != null)
                {
                    while (true)
                    {
                        var elem = libraryAutomationAddObject.SelectAutomationColrction(listView)
                                          .Cast<AutomationElement>().Where(elems => elems.Current.Name == "Rnivc.Cam.Nsi.Business.TaxKindCircumstanceEntity").ToArray();
                        libraryAutomationAddObject.SelectionComboBoxPattern(elem[4]);
                        break;
                    }
                }
                PublicGlobalFunction.WindowElementClick(libraryAutomationAddObject, Journal129AndJournal121.WinSelect2);
                while ((listView = libraryAutomationAddObject.IsEnableElements(Journal129AndJournal121.WinSelect2Select, null, false, 10)) != null)
                {
                    while (true)
                    {
                        var elem = libraryAutomationAddObject.SelectAutomationColrction(listView)
                                          .Cast<AutomationElement>().Where(elems => elems.Current.Name == "Rnivc.Cam.Nsi.Business.TaxCircumstanceEntity").ToArray();
                        libraryAutomationAddObject.SelectionComboBoxPattern(elem[0]);
                        break;
                    }
                }
                PublicGlobalFunction.WindowElementClick(libraryAutomationAddObject, Journal129AndJournal121.WinSelectCircumstanceOk);
                //    AutoItX.Sleep(1000);
                //PublicGlobalFunction.WindowElementClick(libraryAutomationAddObject, Journal129AndJournal121.WinSelect1Select);
                //AutoItX.Sleep(1000);
                //AutoItX.Send(ButtonConstant.Tab);
                //PublicGlobalFunction.WindowElementClick(libraryAutomationAddObject, Journal129AndJournal121.WinSelect2);
                //AutoItX.Sleep(1000);
                //PublicGlobalFunction.WindowElementClick(libraryAutomationAddObject, Journal129AndJournal121.WinSelect2Select);
                //AutoItX.Sleep(1000);
                //AutoItX.Send(ButtonConstant.Tab);
                //libraryAutomationAddObject.IsEnableElements(Journal129AndJournal121.WinSelect2);
                //libraryAutomationAddObject.SetValuePattern("22");

                //if (!string.IsNullOrEmpty(sender))
                //{
                //    if (libraryAutomationSign.IsEnableElements(Journal129AndJournal121.SenderSign, null, true) != null)
                //    {
                //        libraryAutomationSign.SetValuePattern(sender);
                //    }
                //}
                //PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.AddNewErrror1293);

                //libraryAutomation.SetValuePattern("12911012");
                //libraryAutomation.IsEnableElements(Journal129AndJournal121.WinSelect2);
                //libraryAutomation.SetValuePattern("12911012");
                //PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.WinSelectOk);
                //PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.AddNewCircumstance1293);
                //libraryAutomation.IsEnableElements(Journal129AndJournal121.WinSelectCircumstance1);
                //libraryAutomation.SetValuePattern("отсутствие обстоятельств");
                //libraryAutomation.IsEnableElements(Journal129AndJournal121.WinSelectCircumstance2);
                //libraryAutomation.SetValuePattern("22");
                //PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.WinSelectCircumstanceOk);
                //PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ErrorGroup3);
                //PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Inoe);
                //libraryAutomation.IsEnableElements(Journal129AndJournal121.InoeText);
                //libraryAutomation.SetValuePattern(Journal129AndJournal121.TextInoeTemplate);
            }

            // PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ButtonGroup3Add);
            //PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ButtonGroup3Add2Add);

        }
        [TestMethod]
        public void TestCklic()
        {

            var t = Regex.Match(
                "Создана процедура допроса свидетеля УН = 9966149",
                "(\\d)+").Value;
            //LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            //if (libraryAutomation.IsEnableElements(FaceRegistryReferenceTextClass.ErrorMessage) != null)
            //{
            //    var message = libraryAutomation.FindElement.Current.Name;

            //    libraryAutomation.IsEnableElements(FaceRegistryReferenceTextClass.Error);
            //    libraryAutomation.InvokePattern(libraryAutomation.FindElement);

            //}

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
