// <copyright file="KclicerButtonTest.cs">Copyright ©  2018</copyright>

using System;
using LibaryAIS3Windows.ButtonsClikcs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibaryAIS3Windows.AutomationsUI.LibaryAutomations;
using LibaryAIS3Windows.Window;
using LibaryAIS3Windows.AutomationsUI.Otdels.Okp2;
using System.Linq;
using AutoIt;

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
             s0.Click15(null,null,null);
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
                libraryAutomation.SelectItemCombobox(libraryAutomation.IsEnableElements(ComboBoxSelect, null, true),"По каналам ТКС");
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

            LibaryAutomations libaryAutomationsSign = new LibaryAutomations(Okp2ElementName.ViewName);

            if (libaryAutomationsSign.IsEnableElements(Okp2ElementName.ViewPrint, null, true) != null)
            {
                //libaryAutomationsSign.CliksElements(Okp2ElementName.ViewPrint);
                while (true)
                {
                    libaryAutomationsSign.IsEnableElements(Okp2ElementName.ViewCheks);
                     libaryAutomationsSign.FindElement.SetFocus();
                    var t = libaryAutomationsSign.FindElement.Current.HasKeyboardFocus;
                    libaryAutomationsSign.InvekePattern(libaryAutomationsSign.FindElement);
//var ss = libaryAutomationsSign.TogglePattern(libaryAutomationsSign.FindElement);
//                   var status = libaryAutomationsSign.FindElement.Current.LiveSetting;
//                   var value = libaryAutomationsSign.ParseElementLegacyIAccessiblePatternIdentifiers(libaryAutomationsSign.IsEnableElements(Okp2ElementName.ViewCheks));
                    break;
                    //if (libaryAutomationsSign.IsEnableElements(Okp2ElementName.ViewCheks, null, true) != null)
                    //{
                    //    libaryAutomationsSign.FindElement.SetFocus();
                    //    libaryAutomationsSign.CliksElements(Okp2ElementName.ViewCheks);
                    //    libaryAutomationsSign.CliksElements(Okp2ElementName.Sign);
                    //}
                }
            }
     

            //if (libraryAutomation.IsEnableElements(Okp2ElementName.SendDocument, null, true) != null)
            //{
            //    auto = libraryAutomation.FindElement;
            //    libraryAutomation.IsEnableElements(Okp2ElementName.Tks, auto);
            //   var isTks = libraryAutomation.FindElement.Current.IsEnabled;
            //    libraryAutomation.IsEnableElements(Okp2ElementName.Mail, auto);
            //    var isMail = libraryAutomation.FindElement.Current.IsEnabled;
            //    libraryAutomation.IsEnableElements(Okp2ElementName.Lk3, auto);
            //    var isLk3 = libraryAutomation.FindElement.Current.IsEnabled;

            //}
        }

    }
}
