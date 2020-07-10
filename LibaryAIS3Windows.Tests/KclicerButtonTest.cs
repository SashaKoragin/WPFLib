// <copyright file="KclicerButtonTest.cs">Copyright ©  2018</copyright>

using System;
using LibaryAIS3Windows.ButtonsClikcs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibaryAIS3Windows.AutomationsUI.LibaryAutomations;
using LibaryAIS3Windows.Window;
using System.Linq;
using AutoIt;
using System.Windows.Automation;
using System.IO;
using System.Collections.Generic;
using LibaryAIS3Windows.ButtonFullFunction.PublicGlobalFunction;
using System.Runtime.InteropServices;
using LibaryAIS3Windows.ButtonFullFunction.Okp2Function;
using Ifns51.ToAis;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using System.Data.OleDb;
using System.Data;
using LibaryAIS3Windows.AutomationsUI.Otdels.PreCheck;
using LibaryXMLAuto.Converts.ConvettToXml;
using System.Xml;
using LibaryAIS3Windows.AutomationsUI.Otdels.RaschetBud;

namespace LibaryAIS3Windows.Tests
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
            try
            {
                var libraryAutomation = new LibaryAutomations(WindowsAis3.AisNalog3);
                var ComboBoxSelect = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:RequirementDocDetailView\\AutomationId:grpBig\\AutomationId:tab\\AutomationId:ultraTabPageControl2\\AutomationId:ultraGroupBox1\\AutomationId:ctrlDocDeliveryInfoControl\\AutomationId:grpDeliveryInfo\\AutomationId:cmbDeliveryWay";
                libraryAutomation.SelectItemCombobox(libraryAutomation.IsEnableElements(ComboBoxSelect, null, true), "По каналам ТКС");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
        [TestMethod]
        public void Send()
        {

            var listFile = new List<GetFile>();
            var pdf = Directory.GetFiles("C:/Users/7751-00-450/AppData/Local/Temp/", "*.pdf");
            foreach (var path in pdf)
            {
                Path.GetExtension(path);
                listFile.Add(new GetFile { DateWrite = Directory.GetLastWriteTime(path), namePath = path });
            }
            var list = listFile.Where(file => file.DateWrite == listFile.Max(files => files.DateWrite)).FirstOrDefault();
            byte[] bytes;
         //   FileStream stream = new FileStream(list.namePath, FileMode.Open);
            using (FileStream stream = new FileStream(list.namePath, FileMode.Open))
            {

                 bytes = new byte[stream.Length];
             //   taxJournal.Document = bytes;
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        private const UInt32 WM_CLOSE = 0x0010;

        void CloseWindow(IntPtr hwnd)
        {
            SendMessage(hwnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
        }

        [TestMethod]
        public void TestColor()
        {
            //http://i7751-app196.regions.tax.nalog.ru/DataInterchange/api/Ais
            // var model = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:AbdListSmartPart\\ClassName:TaxpayerListControl\\ClassName:RadExpander\\AutomationId:RadDocking\\ClassName:RadSplitContainer\\AutomationId:RadPaneGroup\\AutomationId:RadPane\\ClassName:CircularProgressBar";
            // LibaryAutomations libraryAutomation = new LibaryAutomations(WindowsAis3.AisNalog3);
            //// var t = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiersState(libraryAutomation.IsEnableElements(model, null, true, 1));
            // var t = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiersState(libraryAutomation.IsEnableElements("AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:AbdListSmartPart\\ClassName:TaxpayerListControl\\ClassName:RadExpander\\ClassName:CircularProgressBar", null, true, 1));
            //  t = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiersState(libraryAutomation.IsEnableElements("AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:AbdListSmartPart\\ClassName:TaxpayerListControl\\ClassName:RadExpander\\ClassName:CircularProgressBar", null, true, 1));
            //  t = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiersState(libraryAutomation.IsEnableElements("AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:AbdListSmartPart\\ClassName:TaxpayerListControl\\ClassName:RadExpander\\ClassName:CircularProgressBar", null, true, 1));

            KclicerButton s20 = new KclicerButton();
            StatusButtonMethod statusButton = new StatusButtonMethod();
            var listSrvToLoad = new List<SrvToLoad>();
            //listSrvToLoad.Add(new SrvToLoad()
            //{
            //    N134 = new[] { "5074039918" },
            //    Tree = "Налоговое администрирование\\Централизованный учет налогоплательщиков\\01. ЕГРН - российские организации\\1.01. Идентификационные характеристики организации"
            // ,
            //    Fields = new[] {
            //     "УН ЮЛ в ЕГРН",
            //     "ИНН",
            //     "Полное наименование ЮЛ",
            //     "КПП ЮЛ",
            //     "Сокращенное наименование ЮЛ",
            //     "Адрес МН ЮЛ","Дата принятия решения о ликвидации",
            //     "Дата принятия решения о реорганизации",
            //     "ОГРН",
            //     "Статус ЮЛ в ЦСР",
            //     "Дата присвоения ОГРН",
            //     "ФИД лица"},
            //});
            //listSrvToLoad.Add(new SrvToLoad()
            //{
            //    N134 = new[] { "5074039918" },
            //    Tree = "Налоговое администрирование\\Централизованный учет налогоплательщиков\\01. ЕГРН - российские организации\\1.03. Сведения об учете организации в НО"
            //,
            //    Fields = new[]
            //   {
            //      "УН записи об учете ЮЛ в НО",
            //        "Тип объекта учета",
            //        "КПП",
            //        "Наименование объекта учета",
            //        "Адрес объекта учета",
            //        "Код НО по месту учета",
            //        "Дата постановки на учет",
            //        "Дата фактической постановки на учет",
            //        "Код по СППУНО",
            //        "Причина постановки на учет",
            //        "Дата снятия с учета",
            //        "Дата фактического снятия с учета",
            //        "Код по СПСУНО",
            //        "Причина снятия с учета"
            //    }
            //});

            //listSrvToLoad.Add(new SrvToLoad() { N134 = new[] { "5074039918" }, Tree = "Налоговое администрирование\\Централизованный учет налогоплательщиков\\01. ЕГРН - российские организации\\2.02. История изменений сведений об учете организации в НО" });
            //listSrvToLoad.Add(new SrvToLoad() { N134 = new[] { "5074039918" }, Tree = "Налоговое администрирование\\Централизованный учет налогоплательщиков\\01. ЕГРН - российские организации\\1.12. Сведения о филиалах, представительствах, иных обособленных подразделениях" });
            //listSrvToLoad.Add(new SrvToLoad() { N134 = new[] { "5074039918" }, Tree = "Налоговое администрирование\\Банковские и лицевые счета\\09. Картотека счетов\\01. Картотека счетов РО, ИО, ИП" });
            //listSrvToLoad.Add(new SrvToLoad() { N134 = new[] { "5074039918" }, Tree = "Налоговое администрирование\\Контрольная работа (налоговые проверки)\\109. Прочие документы\\Сведения о среднесписочной численности работников" });
            //listSrvToLoad.Add(new SrvToLoad() { N134 = new[] { "5074039918" }, Tree = "Налоговое администрирование\\Централизованный учет налогоплательщиков\\01. ЕГРН - российские организации\\1.18. Сведения об объектах собственности российской организации – имущество" });
            //listSrvToLoad.Add(new SrvToLoad() { N134 = new[] { "5074039918" }, Tree = "Налоговое администрирование\\Централизованный учет налогоплательщиков\\01. ЕГРН - российские организации\\1.19. Сведения об объектах собственности российской организации – земля" });
            //listSrvToLoad.Add(new SrvToLoad() { N134 = new[] { "5074039918" }, Tree = "Налоговое администрирование\\Централизованный учет налогоплательщиков\\01. ЕГРН - российские организации\\1.20. Сведения об объектах собственности российской организации – транспорт" });
            //listSrvToLoad.Add(new SrvToLoad() { N134 = new[] { "5074039918" }, Tree = "Налоговое администрирование\\Предпроверочный анализ\\ППА-отбор\\7. Индивидуальные карточки налогоплательщиков" });
            //listSrvToLoad.Add(new SrvToLoad() { N134 = new[] { "5074039918" }, Tree = "Налоговое администрирование\\Анализ Банковских Документов\\Банковские выписки, справки" });
        //    listSrvToLoad.Add(new SrvToLoad() { N134 = new[] { }, Tree = "Налоговое администрирование\\Контрольная работа(налоговые проверки)\\101. Мониторинг и обработка документов\\Реестр документов НБО" });

            
            listSrvToLoad.Add(new SrvToLoad() { N134 = new[] { "7727280875", "7751524258", "7751032094", "7705011597" }, Tree = "Налоговое администрирование\\Контрольная работа (налоговые проверки)\\124. Миграция НП в части КНП\\1. Реестр документов НБО" });
            
            s20.Click29(statusButton, listSrvToLoad, "http://i7751-app196.regions.tax.nalog.ru/DataInterchange/api/Ais", "C:/Users/7751-00-099/AppData/Local/Temp/", "D:\\");
        }
        [TestMethod]
        public void TestTableIkn()
        {
         //  var tt = "LocalizedControlType:панель\\Name:Data Area";var kbk = "18210803010011000110";
            var libraryAutomation = new LibaryAutomations(WindowsAis3.AisNalog3);
      //    var t =  libraryAutomation.FindFirstElement(RashetBudElementName.SendKbk,null,true);
            var t = libraryAutomation.FindFirstElement(RashetBudElementName.SendStatus, null, true);
            libraryAutomation.SetValuePattern("01");
            
           // var pattern = t.GetSupportedPatterns();


            //SetSelectedComboBoxItem(t, "ТП");
           //  var par = t.GetSupportedPatterns();
          //  libraryAutomation.SetValuePattern("ТП");

            //var file = PublicGlobalFunction.ReturnNameLastFileTemp("C:/Users/7751-00-099/AppData/Local/Temp/", "*.xml");
            //var xml = LibaryXMLAuto.ReadOrWrite.LogicaXml.LogicaXml.Document(file.NamePath);
            //XmlNamespaceManager nsmgr = new XmlNamespaceManager(xml.NameTable);
            //nsmgr.AddNamespace("ss", "urn:schemas-microsoft-com:office:spreadsheet");
            //int Count = xml.SelectNodes("/ss:Workbook/ss:Worksheet", nsmgr).Count;

            //for (int i = 1; i < 10; i++)
            //{
            //    XmlNode node = xml.SelectSingleNode("/ss:Workbook/ss:Worksheet["+i+"]/ss:Table/ss:Row", nsmgr);
            //    var val = node.SelectSingleNode("ss:Cell[1]/ss:Data[1]", nsmgr);

            //}


            //var connectionString = string.Format($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={"C:\\Users\\7751_svc_admin\\Desktop\\ikn_245926312.xml"}; Extended Properties=Excel 12.0;");
            //var adapter = new OleDbDataAdapter("Select * From [Общая информация$]", connectionString);
            //var ds = new DataSet();
            //adapter.Fill(ds, "Declaration");
            //DataTable data = ds.Tables["Declaration"];
            //foreach (DataRow row in data.Rows)
            //{ 

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
}
