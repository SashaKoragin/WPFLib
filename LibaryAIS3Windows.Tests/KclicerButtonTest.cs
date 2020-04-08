// <copyright file="KclicerButtonTest.cs">Copyright ©  2018</copyright>

using System;
using LibaryAIS3Windows.ButtonsClikcs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibaryAIS3Windows.AutomationsUI.LibaryAutomations;
using LibaryAIS3Windows.Window;
using LibaryAIS3Windows.AutomationsUI.Otdels.Okp2;
using System.Linq;
using AutoIt;
using System.Windows.Automation;
using System.IO;
using System.Collections.Generic;
using LibaryAIS3Windows.ButtonFullFunction.PublicGlobalFunction;
using System.Runtime.InteropServices;
using LibaryAIS3Windows.ButtonFullFunction.Okp2Function;
using Ifns51.ToAis;

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

            KclicerButton s20 = new KclicerButton();
            var listSrvToLoad = new List<SrvToLoad>();
            listSrvToLoad.Add(new SrvToLoad() { N134 = new[] { "7701734690", "7751033429" }, Tree = "Налоговое администрирование\\Централизованный учет налогоплательщиков\\01. ЕГРН - российские организации\\1.01. Идентификационные характеристики организации" });
            listSrvToLoad.Add(new SrvToLoad() { N134 = new[] { "7701734690", "7751033429" }, Tree = "Налоговое администрирование\\Централизованный учет налогоплательщиков\\01. ЕГРН - российские организации\\1.03. Сведения об учете организации в НО" });
            listSrvToLoad.Add(new SrvToLoad() { N134 = new[] { "7701734690", "7751033429" }, Tree = "Налоговое администрирование\\Централизованный учет налогоплательщиков\\01. ЕГРН - российские организации\\2.02. История изменений сведений об учете организации в НО" });
            listSrvToLoad.Add(new SrvToLoad() { N134 = new[] { "7701734690", "7751033429" }, Tree = "Налоговое администрирование\\Централизованный учет налогоплательщиков\\01. ЕГРН - российские организации\\1.12. Сведения о филиалах, представительствах, иных обособленных подразделениях" });
            listSrvToLoad.Add(new SrvToLoad() { N134 = new[] { "7701734690", "7751033429" }, Tree = "Налоговое администрирование\\Банковские и лицевые счета\\09. Картотека счетов\\01. Картотека счетов РО, ИО, ИП" });
            listSrvToLoad.Add(new SrvToLoad() { N134 = new[] { "7701734690", "7751033429" }, Tree = "Налоговое администрирование\\Контрольная работа (налоговые проверки)\\109. Прочие документы\\Сведения о среднесписочной численности работников" });
            listSrvToLoad.Add(new SrvToLoad() { N134 = new[] { "7701734690", "7751033429" }, Tree = "Налоговое администрирование\\Централизованный учет налогоплательщиков\\01. ЕГРН - российские организации\\1.18. Сведения об объектах собственности российской организации – имущество" });
            listSrvToLoad.Add(new SrvToLoad() { N134 = new[] { "7701734690", "7751033429" }, Tree = "Налоговое администрирование\\Централизованный учет налогоплательщиков\\01. ЕГРН - российские организации\\1.19. Сведения об объектах собственности российской организации – земля" });
            listSrvToLoad.Add(new SrvToLoad() { N134 = new[] { "7701734690", "7751033429" }, Tree = "Налоговое администрирование\\Централизованный учет налогоплательщиков\\01. ЕГРН - российские организации\\1.20. Сведения об объектах собственности российской организации – транспорт" });
            listSrvToLoad.Add(new SrvToLoad() { N134 = new[] { "7701734690", "7751033429" }, Tree = "Налоговое администрирование\\Предпроверочный анализ\\ППА-отбор\\7. Индивидуальные карточки налогоплательщиков" });
            //   t.Tree = "Налоговое администрирование\\Централизованный учет налогоплательщиков\\01. ЕГРН - российские организации\\1.01. Идентификационные характеристики организации";
            //   t.Tree = "Налоговое администрирование\\Централизованный учет налогоплательщиков\\01. ЕГРН - российские организации\\1.03. Сведения об учете организации в НО";
            //   t.Tree = "Налоговое администрирование\\Централизованный учет налогоплательщиков\\01. ЕГРН - российские организации\\2.02. История изменений сведений об учете организации в НО";
            //   t.Tree = "Налоговое администрирование\\Централизованный учет налогоплательщиков\\01. ЕГРН - российские организации\\1.12. Сведения о филиалах, представительствах, иных обособленных подразделениях";
            //   t.Tree = "Налоговое администрирование\\Банковские и лицевые счета\\09. Картотека счетов\\01. Картотека счетов РО, ИО, ИП";
            //   t.Tree = "Налоговое администрирование\\Контрольная работа (налоговые проверки)\\109. Прочие документы\\Сведения о среднесписочной численности работников";
            //   t.Tree = "Налоговое администрирование\\Централизованный учет налогоплательщиков\\01. ЕГРН - российские организации\\1.18. Сведения об объектах собственности российской организации – имущество";
            //   t.Tree = "Налоговое администрирование\\Централизованный учет налогоплательщиков\\01. ЕГРН - российские организации\\1.19. Сведения об объектах собственности российской организации – земля";
            //   t.Tree = "Налоговое администрирование\\Централизованный учет налогоплательщиков\\01. ЕГРН - российские организации\\1.20. Сведения об объектах собственности российской организации – транспорт";
            //   t.Tree = "Налоговое администрирование\\Предпроверочный анализ\\ППА-отбор\\7. Индивидуальные карточки налогоплательщиков";
           // t.N134 = new[] { "7701734690" };
            s20.Click29(null, listSrvToLoad, "http://i7751-app196.regions.tax.nalog.ru/DataInterchange/api/Ais");
        }

        public class GetFile
        {
            public string namePath { get; set; }
            public DateTime DateWrite { get; set; }
        }
    }
}
