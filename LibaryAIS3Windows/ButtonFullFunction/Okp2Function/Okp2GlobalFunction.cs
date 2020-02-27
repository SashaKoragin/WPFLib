using AutoIt;
using EfDatabaseAutomation.Automation.Base;
using LibaryAIS3Windows.AutomationsUI.LibaryAutomations;
using LibaryAIS3Windows.AutomationsUI.Otdels.Okp2;
using LibaryAIS3Windows.ButtonsClikcs;
using LibaryAIS3Windows.Window;
using System.IO;

namespace LibaryAIS3Windows.ButtonFullFunction.Okp2Function
{
   public class Okp2GlobalFunction
    {
        /// <summary>
        /// Автоматизация глобального блока надо добавить сохранение
        /// </summary>
        /// <param name="libraryAutomation">Библиотека автоматизации</param>
        /// <param name="taxJournal">Журнал для ведения в БД</param>
        public void SignAndSendDoc(LibaryAutomations libraryAutomation, ref TaxJournal taxJournal)
        {
            AutoItX.WinWait(Okp2ElementName.ViewName);
            AutoItX.WinActivate(Okp2ElementName.ViewName);
            LibaryAutomations libraryAutomationSign = new LibaryAutomations(Okp2ElementName.ViewName);
            while (true)
            {
                if (libraryAutomationSign.IsEnableElements(Okp2ElementName.ViewPrint, null, true) != null)
                {
                    libraryAutomationSign.InvekePattern(libraryAutomationSign.IsEnableElements(Okp2ElementName.ViewPrint));
                    while (true)
                    {
                        var toggle = libraryAutomationSign.TogglePattern(libraryAutomationSign.FindElement);
                        if (toggle == "Off" || toggle == null)
                        {
                            if (libraryAutomationSign.IsEnableElements(Okp2ElementName.ViewCheks, null, true) != null)
                            {
                                libraryAutomationSign.FindElement.SetFocus();
                                libraryAutomationSign.InvekePattern(libraryAutomationSign.FindElement);
                            }
                        }
                        if (toggle == "On")
                        {
                            AutoItX.WinActivate(Okp2ElementName.ViewName);
                            libraryAutomationSign.InvekePattern(libraryAutomationSign.IsEnableElements(Okp2ElementName.Sign));
                            break;
                        }
                    }
                    break;
                }
            }
            while (true)
            {
                AutoItX.WinActivate(WindowsAis3.AisNalog3);
                if (libraryAutomation.IsEnableElements(Okp2ElementName.SendAll, null, true) != null)
                {
                    libraryAutomation.CliksElements(Okp2ElementName.SendAll);
                }
                if (libraryAutomation.IsEnableElements(Okp2ElementName.SendDocument, null, true) != null)
                {
                    var auto = libraryAutomation.FindElement;
                    libraryAutomation.IsEnableElements(Okp2ElementName.Tks, auto);
                    taxJournal.IsTks = libraryAutomation.FindElement.Current.IsEnabled;
                    libraryAutomation.IsEnableElements(Okp2ElementName.Mail, auto);
                    taxJournal.IsMail = libraryAutomation.FindElement.Current.IsEnabled;
                    libraryAutomation.IsEnableElements(Okp2ElementName.Lk3, auto);
                    taxJournal.IsLk3 = libraryAutomation.FindElement.Current.IsEnabled;
                    libraryAutomation.CliksElements(Okp2ElementName.Close, auto, false, 25, -30, 30);
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
             byte[] bytes;
                using (FileStream stream = new FileStream(file.NamePath, FileMode.Open))
                {
                     bytes = new byte[stream.Length];
                }
             taxJournal.Document = bytes;
        }

    }
}
