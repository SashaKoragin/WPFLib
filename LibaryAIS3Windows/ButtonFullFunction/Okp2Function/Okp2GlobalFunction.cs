using System;
using AutoIt;
using System.Windows.Automation;
using EfDatabaseAutomation.Automation.Base;
using LibraryAIS3Windows.AutomationsUI.LibaryAutomations;
using LibraryAIS3Windows.AutomationsUI.Otdels.PublicJournal129And121;
using LibraryAIS3Windows.ButtonsClikcs;
using LibraryAIS3Windows.Window;
using System.IO;
using System.Linq;

namespace LibraryAIS3Windows.ButtonFullFunction.Okp2Function
{
   public class Okp2GlobalFunction
    {
        /// <summary>
        /// Ткс
        /// </summary>
        public bool IsTks { get; set; }
        /// <summary>
        /// Mail
        /// </summary>
        public bool IsMail { get; set; }
        /// <summary>
        /// Лк3
        /// </summary>
        public bool IsLk3 { get; set; }

        /// <summary>
        /// Функция добавления обстоятельства в АКТ
        /// Новое 12.07.2023
        /// </summary>
        /// <param name="libraryAutomation">Библиотека автоматизации</param>
        public void AddCircumstance(LibraryAutomations libraryAutomation)
        {
            if (libraryAutomation.IsEnableElements(Journal129AndJournal121.ListCashFaceGr3, null, true) != null)
            {
                AutomationElement cashAdd;
                while ((cashAdd = libraryAutomation.IsEnableElements(Journal129AndJournal121.ListCashFaceGr3, null, false, 10)) != null)
                {
                    var elem = libraryAutomation.SelectAutomationColrction(cashAdd).Cast<AutomationElement>().Where(elems => elems.Current.ClassName == "Button").ToArray();
                        libraryAutomation.ClickElement(elem[2]);
                        if (libraryAutomation.IsEnableElements(Journal129AndJournal121.ButtonGroup3Add2Add, null,true) == null) continue;
                        libraryAutomation.ClickElement(libraryAutomation.IsEnableElements(Journal129AndJournal121.ButtonGroup3Add2Add));
                        break;
                }
                LibraryAutomations libraryAutomationDialog = new LibraryAutomations(WindowsAis3.AisNalog3);
                AutoItX.Sleep(2000);
                LibraryAutomations libraryAutomationAddObject = new LibraryAutomations(TreeWalker.RawViewWalker.GetPreviousSibling(libraryAutomationDialog.RootAutomationElements));
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomationAddObject, Journal129AndJournal121.WinSelect1);
                AutomationElement listView;

                while ((listView = libraryAutomationAddObject.IsEnableElements(Journal129AndJournal121.WinSelect1Select, null,false, 10)) != null)
                {
                    while (true)
                    {
                        var elem = libraryAutomationAddObject.SelectAutomationColrction(listView).Cast<AutomationElement>().Where(elems => elems.Current.Name == "Rnivc.Cam.Nsi.Business.TaxKindCircumstanceEntity").ToArray();
                        libraryAutomationAddObject.SelectionComboBoxPattern(elem[4]);
                        break;
                    }
                    break;
                }
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomationAddObject, Journal129AndJournal121.WinSelect2);
                while ((listView = libraryAutomationAddObject.IsEnableElements(Journal129AndJournal121.WinSelect2Select, null, false, 10)) != null)
                {
                    while (true)
                    {
                        var elem = libraryAutomationAddObject.SelectAutomationColrction(listView).Cast<AutomationElement>().Where(elems => elems.Current.Name == "Rnivc.Cam.Nsi.Business.TaxCircumstanceEntity").ToArray();
                        libraryAutomationAddObject.SelectionComboBoxPattern(elem[0]);
                        break;
                    }
                    break;
                }
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomationAddObject, Journal129AndJournal121.WinSelectCircumstanceOk);
            }
        }
        /// <summary>
        /// Добавление даты и места вызова плательщика
        /// Новое 12.07.2023
        /// </summary>
        /// <param name="libraryAutomation"></param>
        /// <param name="office">Номер кабинета</param>
        /// <param name="date">Дата вызова плательщика</param>
        /// <param name="hours">Час вызова</param>
        /// <param name="minute">Минуты вызова</param>
        public void AddDataAndTimeInvoke(LibraryAutomations libraryAutomation, string office, DateTime date, string hours, string minute)
        {
            while (true)
            {
                if (libraryAutomation.IsEnableElements(Journal129AndJournal121.NumKabinet, null, true) != null)
                {
                    AutomationElement setValue;
                    while ((setValue = libraryAutomation.IsEnableElements(Journal129AndJournal121.NumKabinet, null, false, 10)) != null)
                    {
                        var elem = libraryAutomation.SelectAutomationColrction(setValue).Cast<AutomationElement>().Where(elems => elems.Current.LocalizedControlType == "поле").ToArray();
                        libraryAutomation.FindElement = elem[1];
                        libraryAutomation.SetValuePattern(office);
                        break;
                    }
                    libraryAutomation.ClickElements(Journal129AndJournal121.AddButton);
                    LibraryAutomations libraryAutomationDiaolog = new LibraryAutomations(WindowsAis3.AisNalog3);
                    AutoItX.Sleep(2000);
                    var libraryAutomationAddObject = new LibraryAutomations(TreeWalker.RawViewWalker.GetPreviousSibling(libraryAutomationDiaolog.RootAutomationElements));
                    while (true)
                    {
                        if (libraryAutomationAddObject.IsEnableElements(Journal129AndJournal121.WindowDateTime, null, true) != null)
                        {
                            libraryAutomationAddObject.SetValuePattern(date.ToString("dd.MM.yy"));
                            while ((setValue = libraryAutomationAddObject.IsEnableElements(Journal129AndJournal121.WindowHoursAndMinutes, null, false, 10)) != null)
                            {
                                var elem = libraryAutomationAddObject.SelectAutomationColrction(setValue).Cast<AutomationElement>().Where(elems => elems.Current.LocalizedControlType == "поле").ToArray();
                                libraryAutomationAddObject.FindElement = elem[0];
                                libraryAutomationAddObject.SetValuePattern(hours);
                                libraryAutomationAddObject.FindElement = elem[1];
                                libraryAutomationAddObject.SetValuePattern(minute);
                                break;
                            }
                            libraryAutomationAddObject.FindFirstElement(Journal129AndJournal121.WindowsOk);
                            libraryAutomationAddObject.InvokePattern(libraryAutomationAddObject.FindElement);
                            break;
                        }
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// Автоматизация глобального блока надо добавить сохранение
        /// </summary>
        /// <param name="libraryAutomation">Библиотека автоматизации</param>
        /// <param name="isClose">Координата смещения x для отправки</param>
        /// <param name="sender">Подписант на форме документа</param>
        public void SignAndSendDoc(LibraryAutomations libraryAutomation, bool isClose = false, string sender = null)
        {
            while (true)
            {
                LibraryAutomations libraryAutomationDiaolog = new LibraryAutomations(WindowsAis3.AisNalog3);
                AutoItX.Sleep(2000);
                LibraryAutomations libraryAutomationSign = new LibraryAutomations(TreeWalker.RawViewWalker.GetPreviousSibling(libraryAutomationDiaolog.RootAutomationElements));
                if (!string.IsNullOrEmpty(sender))
                {
                    if (libraryAutomationSign.IsEnableElements(Journal129AndJournal121.SenderSign, null, true) != null)
                    {
                        libraryAutomationSign.SetValuePattern(sender);
                    }
                }
                if (libraryAutomationSign.IsEnableElements(Journal129AndJournal121.ViewPrint, null, true) != null)
                {
                    libraryAutomationSign.ClickElement(libraryAutomationSign.FindElement);
                    AutoItX.Sleep(10000);
                    PublicGlobalFunction.PublicGlobalFunction.CloseProcessProgram("AcroRd32", true);
                    PublicGlobalFunction.PublicGlobalFunction.CloseProcessProgram("FoxitPhantom",true);
                    while (true)
                    {
                        var toggle = libraryAutomationSign.TogglePattern(libraryAutomationSign.IsEnableElements(Journal129AndJournal121.ViewCheks));
                        if (toggle == "Off" || toggle == null)
                        {
                            while (true)
                            {
                                if (libraryAutomationSign.IsEnableElements(Journal129AndJournal121.ViewCheksText, null, true) != null)
                                {
                                    libraryAutomationSign.ClickElement(libraryAutomationSign.FindElement);
                                    break;
                                }
                            }
                        }
                        if (toggle == "On")
                        {
                            while (true)
                            {
                                if (libraryAutomationSign.IsEnableElements(Journal129AndJournal121.Sign, null, true) != null)
                                {
                                    libraryAutomationSign.ClickElement(libraryAutomationSign.FindElement);
                                    break;
                                }
                            }
                            break;
                        }
                    }
                    break;
                }
            }
            var isSend = false;
            while (true)
            {
                if (isSend == false)
                {
                    PublicGlobalFunction.PublicGlobalFunction.CloseProcessProgram("AcroRd32", true);
                    PublicGlobalFunction.PublicGlobalFunction.CloseProcessProgram("FoxitPhantom");
                    AutoItX.WinActivate(WindowsAis3.AisNalog3);
                    if (libraryAutomation.IsEnableElements(Journal129AndJournal121.SendAll, null, true) != null)
                    {
                        libraryAutomation.ClickElements(Journal129AndJournal121.SendAll);
                        isSend = true;
                    }
                }
                if(libraryAutomation.IsEnableElements(Journal129AndJournal121.SendDocument, null, true) != null)
                {
                    var auto = libraryAutomation.FindElement;
                    libraryAutomation.IsEnableElements(Journal129AndJournal121.Tks, auto);
                    var statusTks = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiersState(libraryAutomation.FindElement);
                    libraryAutomation.IsEnableElements(Journal129AndJournal121.Mail, auto);
                    var statusMail = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiersState(libraryAutomation.FindElement);
                    libraryAutomation.IsEnableElements(Journal129AndJournal121.Lk3, auto);
                    var statusLk3 = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiersState(libraryAutomation.FindElement);
                    if (statusTks == 0)
                    {
                        IsTks = true;
                    }
                    if (statusMail == 0)
                    {
                        IsMail = true;
                    }
                    if (statusLk3 == 0)
                    {
                        IsLk3 = true;
                    }
                    while (true)
                    {
                        if (isClose)
                        {
                            if (libraryAutomation.IsEnableElements(Journal129AndJournal121.Close, null, true) != null)
                            {
                                libraryAutomation.ClickElements(Journal129AndJournal121.Close);
                                break;
                            }
                        }
                        else
                        {
                            if (libraryAutomation.IsEnableElements(Journal129AndJournal121.SendMail, null, true) != null)
                            {
                                libraryAutomation.ClickElements(Journal129AndJournal121.SendMail);
                                break;
                            }
                        }
                    }
                    break;
                }
                try
                {
                    LibraryAutomations libraryAutomationWindows = new LibraryAutomations(Journal129AndJournal121.WindowSend);
                    if (libraryAutomationWindows.RootAutomationElements != null)
                    {
                        var auto = libraryAutomationWindows.RootAutomationElements;
                        libraryAutomationWindows.IsEnableElements(Journal129AndJournal121.Tks, auto);
                        var statusTks = libraryAutomationWindows.ParseElementLegacyIAccessiblePatternIdentifiersState(libraryAutomationWindows.FindElement);
                        libraryAutomationWindows.IsEnableElements(Journal129AndJournal121.Mail, auto);
                        var statusMail = libraryAutomationWindows.ParseElementLegacyIAccessiblePatternIdentifiersState(libraryAutomationWindows.FindElement);
                        libraryAutomationWindows.IsEnableElements(Journal129AndJournal121.Lk3, auto);
                        var statusLk3 = libraryAutomationWindows.ParseElementLegacyIAccessiblePatternIdentifiersState(libraryAutomationWindows.FindElement);
                        if (statusTks == 0)
                        {
                            IsTks = true;
                        }
                        if (statusMail == 0)
                        {
                            IsMail = true;
                        }
                        if (statusLk3 == 0)
                        {
                            IsLk3 = true;
                        }
                        while (true)
                        {
                            if (isClose)
                            {
                                if (libraryAutomationWindows.IsEnableElements(Journal129AndJournal121.CloseWin, null, true) != null)
                                {
                                    libraryAutomationWindows.ClickElements(Journal129AndJournal121.CloseWin);
                                    break;
                                }
                            }
                            else
                            {
                                if (libraryAutomationWindows.IsEnableElements(Journal129AndJournal121.SendMailWin, null, true) != null)
                                {
                                    libraryAutomationWindows.ClickElements(Journal129AndJournal121.SendMailWin);
                                    break;
                                }
                            }
                        }
                        break;
                    }
                }
                catch
                {
                    // ignored
                }
            }
        }
        /// <summary>
        /// Автоматизация глобального блока на утверждение требований
        /// </summary>
        /// <param name="libraryAutomation">Библиотека автоматизации</param>
        /// <param name="isClose">Координата смещения x для отправки</param>
        public void ApproveRequirements(LibraryAutomations libraryAutomation, bool isClose = false)
        {
            while (true)
            {
                LibraryAutomations libraryAutomationDialog = new LibraryAutomations(WindowsAis3.AisNalog3);
                AutoItX.Sleep(2000);
                LibraryAutomations libraryAutomationSign = new LibraryAutomations(TreeWalker.RawViewWalker.GetPreviousSibling(libraryAutomationDialog.RootAutomationElements));
                if (libraryAutomationSign.IsEnableElements(JournalSolutionCalculations.ViewPrint, null, true) != null)
                {
                    libraryAutomationSign.ClickElement(libraryAutomationSign.FindElement);
                    AutoItX.Sleep(10000);
                    PublicGlobalFunction.PublicGlobalFunction.CloseProcessProgram("AcroRd32", true);
                    PublicGlobalFunction.PublicGlobalFunction.CloseProcessProgram("FoxitPhantom", true);
                    while (true)
                    {
                        var toggle = libraryAutomationSign.TogglePattern(libraryAutomationSign.IsEnableElements(JournalSolutionCalculations.ViewCheks));
                        if (toggle == "Off" || toggle == null)
                        {
                            while (true)
                            {
                                if (libraryAutomationSign.IsEnableElements(JournalSolutionCalculations.ViewCheksText, null, true) != null)
                                {
                                    libraryAutomationSign.ClickElement(libraryAutomationSign.FindElement);
                                    break;
                                }
                            }
                        }
                        if (toggle == "On")
                        {
                            while (true)
                            {
                                if (libraryAutomationSign.IsEnableElements(JournalSolutionCalculations.UtvDoc, null, true) != null)
                                {
                                    libraryAutomationSign.ClickElement(libraryAutomationSign.FindElement);
                                    break;
                                }
                            }
                            break;
                        }
                    }
                    break;
                }
            }
            var isSend = false;
            while (true)
            {
                if (isSend == false)
                {
                    PublicGlobalFunction.PublicGlobalFunction.CloseProcessProgram("AcroRd32", true);
                    PublicGlobalFunction.PublicGlobalFunction.CloseProcessProgram("FoxitPhantom");
                    AutoItX.WinActivate(WindowsAis3.AisNalog3);
                    if (libraryAutomation.IsEnableElements(Journal129AndJournal121.SendAll, null, true) != null)
                    {
                        libraryAutomation.ClickElements(Journal129AndJournal121.SendAll);
                        isSend = true;
                    }
                }
                if (libraryAutomation.IsEnableElements(Journal129AndJournal121.SendDocument, null, true) != null)
                {
                    var auto = libraryAutomation.FindElement;
                    libraryAutomation.IsEnableElements(Journal129AndJournal121.Tks, auto);
                    var statusTks = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiersState(libraryAutomation.FindElement);
                    libraryAutomation.IsEnableElements(Journal129AndJournal121.Mail, auto);
                    var statusMail = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiersState(libraryAutomation.FindElement);
                    libraryAutomation.IsEnableElements(Journal129AndJournal121.Lk3, auto);
                    var statusLk3 = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiersState(libraryAutomation.FindElement);
                    if (statusTks == 0)
                    {
                        IsTks = true;
                    }
                    if (statusMail == 0)
                    {
                        IsMail = true;
                    }
                    if (statusLk3 == 0)
                    {
                        IsLk3 = true;
                    }
                    while (true)
                    {
                        if (isClose)
                        {
                            if (libraryAutomation.IsEnableElements(Journal129AndJournal121.Close, null, true) != null)
                            {
                                libraryAutomation.ClickElements(Journal129AndJournal121.Close);
                                break;
                            }
                        }
                        else
                        {
                            if (libraryAutomation.IsEnableElements(Journal129AndJournal121.SendMail, null, true) != null)
                            {
                                libraryAutomation.ClickElements(Journal129AndJournal121.SendMail);
                                break;
                            }
                        }
                    }
                    break;
                }
                try
                {
                    LibraryAutomations libraryAutomationWindows = new LibraryAutomations(Journal129AndJournal121.WindowSend);
                    if (libraryAutomationWindows.RootAutomationElements != null)
                    {
                        var auto = libraryAutomationWindows.RootAutomationElements;
                        libraryAutomationWindows.IsEnableElements(Journal129AndJournal121.Tks, auto);
                        var statusTks = libraryAutomationWindows.ParseElementLegacyIAccessiblePatternIdentifiersState(libraryAutomationWindows.FindElement);
                        libraryAutomationWindows.IsEnableElements(Journal129AndJournal121.Mail, auto);
                        var statusMail = libraryAutomationWindows.ParseElementLegacyIAccessiblePatternIdentifiersState(libraryAutomationWindows.FindElement);
                        libraryAutomationWindows.IsEnableElements(Journal129AndJournal121.Lk3, auto);
                        var statusLk3 = libraryAutomationWindows.ParseElementLegacyIAccessiblePatternIdentifiersState(libraryAutomationWindows.FindElement);
                        if (statusTks == 0)
                        {
                            IsTks = true;
                        }
                        if (statusMail == 0)
                        {
                            IsMail = true;
                        }
                        if (statusLk3 == 0)
                        {
                            IsLk3 = true;
                        }
                        while (true)
                        {
                            if (isClose)
                            {
                                if (libraryAutomationWindows.IsEnableElements(Journal129AndJournal121.CloseWin, null, true) != null)
                                {
                                    libraryAutomationWindows.ClickElements(Journal129AndJournal121.CloseWin);
                                    break;
                                }
                            }
                            else
                            {
                                if (libraryAutomationWindows.IsEnableElements(Journal129AndJournal121.SendMailWin, null, true) != null)
                                {
                                    libraryAutomationWindows.ClickElements(Journal129AndJournal121.SendMailWin);
                                    break;
                                }
                            }
                        }
                        break;
                    }
                }
                catch
                {
                    // ignored
                }
            }
        }

        /// <summary>
        /// Завершение закрыть окна
        /// </summary>
        public void SendJournalClose()
        {
            WindowsAis3 win = new WindowsAis3();
            AutoItX.Sleep(1000);
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
            AutoItX.Sleep(1000);
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
        }
        /// <summary>
        /// Добавление файлов в Журнал
        /// </summary>
        /// <param name="taxJournal">Журнал</param>
        /// <param name="pathPdfTemp">Путь к файлу</param>
        public void AddFile(ref TaxJournal taxJournal,string pathPdfTemp)
        {
            var file = PublicGlobalFunction.PublicGlobalFunction.ReturnNameLastFileTemp(pathPdfTemp, "*.pdf");
             taxJournal.FullPath = file.NamePath;
             taxJournal.NameFile = file.NameFile;
             taxJournal.Mime = "application/pdf";
             taxJournal.Extensions = file.ExtensionsFile;
             byte[] byteFile;
             using (FileStream stream = new FileStream(file.NamePath, FileMode.Open))
             {
                 byteFile = new byte[stream.Length];
                stream.Read(byteFile, 0, byteFile.Length);
             }
             taxJournal.Document = byteFile;
        }

        /// <summary>
        /// Добавление файлов в Журнал
        /// </summary>
        /// <param name="taxJournal121">Журнал</param>
        /// <param name="pathPdfTemp">Путь к файлу</param>
        public void AddFile(ref TaxJournal121 taxJournal121, string pathPdfTemp)
        {
            var file = PublicGlobalFunction.PublicGlobalFunction.ReturnNameLastFileTemp(pathPdfTemp, "*.pdf");
            taxJournal121.Mime = "application/pdf";
            taxJournal121.Extensions = file.ExtensionsFile;
            byte[] byteFile;
            using (FileStream stream = new FileStream(file.NamePath, FileMode.Open))
            {
                byteFile = new byte[stream.Length];
                stream.Read(byteFile, 0, byteFile.Length);
            }
            taxJournal121.Document = byteFile;
        }
        /// <summary>
        /// Добавление файлов в журнал 3 НДФЛ
        /// </summary>
        /// <param name="journal3NdflFl">Журнал</param>
        /// <param name="pathPdfTemp">Путь к файлу</param>
        public void AddFileRequirements(ref Declaration3NdflFl journal3NdflFl, string pathPdfTemp)
        {
            var file = PublicGlobalFunction.PublicGlobalFunction.ReturnNameLastFileTemp(pathPdfTemp, "*.pdf");
            journal3NdflFl.Mime = "application/pdf";
            journal3NdflFl.Extensions = file.ExtensionsFile;
            byte[] byteFile;
            using (FileStream stream = new FileStream(file.NamePath, FileMode.Open))
            {
                byteFile = new byte[stream.Length];
                stream.Read(byteFile, 0, byteFile.Length);
            }
            journal3NdflFl.Document = byteFile;
        }
    }
}
