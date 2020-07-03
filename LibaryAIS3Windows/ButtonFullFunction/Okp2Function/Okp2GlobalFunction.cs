using AutoIt;
using EfDatabaseAutomation.Automation.Base;
using LibaryAIS3Windows.AutomationsUI.LibaryAutomations;
using LibaryAIS3Windows.AutomationsUI.Otdels.PublicJournal129And121;
using LibaryAIS3Windows.ButtonsClikcs;
using LibaryAIS3Windows.Window;
using System.IO;

namespace LibaryAIS3Windows.ButtonFullFunction.Okp2Function
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
        /// Автоматизация глобального блока надо добавить сохранение
        /// </summary>
        /// <param name="libraryAutomation">Библиотека автоматизации</param>
        public void SignAndSendDoc(LibaryAutomations libraryAutomation)
        {
            AutoItX.WinWait(Journal129AndJournal121.ViewName);
            AutoItX.WinActivate(Journal129AndJournal121.ViewName);
            LibaryAutomations libraryAutomationSign = new LibaryAutomations(Journal129AndJournal121.ViewName);
            while (true)
            {
                if (libraryAutomationSign.IsEnableElements(Journal129AndJournal121.ViewPrint, null, true) != null)
                {

                    libraryAutomationSign.InvokePattern(libraryAutomationSign.IsEnableElements(Journal129AndJournal121.ViewPrint));
                    while (true)
                    {
                        var toggle = libraryAutomationSign.TogglePattern(libraryAutomationSign.IsEnableElements(Journal129AndJournal121.ViewCheks));
                        if (toggle == "Off" || toggle == null)
                        {
                            while (true)
                            {
                                if (libraryAutomationSign.IsEnableElements(Journal129AndJournal121.ViewCheks, null, true) !=null)
                                {
                                    libraryAutomationSign.InvokePattern(libraryAutomationSign.FindElement);
                                    break;
                                }
                            }
                        }
                        if (toggle == "On")
                        {
                            while (true)
                            {
                                if (libraryAutomationSign.IsEnableElements(Journal129AndJournal121.Sign, null, true) !=null)
                                {
                                    AutoItX.WinActivate(Journal129AndJournal121.ViewName);
                                    libraryAutomationSign.InvokePattern(libraryAutomationSign.FindElement);
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
                    PublicGlobalFunction.PublicGlobalFunction.CloseProcessProgram("AcroRd32");
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
                    IsTks = libraryAutomation.FindElement.Current.IsEnabled;
                    libraryAutomation.IsEnableElements(Journal129AndJournal121.Mail, auto);
                    IsMail = libraryAutomation.FindElement.Current.IsEnabled;
                    libraryAutomation.IsEnableElements(Journal129AndJournal121.Lk3, auto);
                    IsLk3 = libraryAutomation.FindElement.Current.IsEnabled;
                    while (true)
                    {
                        if (libraryAutomation.IsEnableElements(Journal129AndJournal121.Close, null, true) != null)
                        {
                            libraryAutomation.ClickElements(Journal129AndJournal121.Close, null, false, 25, -30, 30);
                            break;
                        }
                    }
                    break;
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
    }
}
