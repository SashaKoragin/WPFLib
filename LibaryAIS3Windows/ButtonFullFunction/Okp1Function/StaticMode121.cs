using AutoIt;
using LibraryAIS3Windows.AutomationsUI.LibaryAutomations;
using LibraryAIS3Windows.AutomationsUI.Otdels.PublicJournal129And121;
using LibraryAIS3Windows.ButtonsClikcs;
using LibraryAIS3Windows.Window;
using System.Linq;
using System.Windows.Automation;

namespace LibraryAIS3Windows.ButtonFullFunction.Okp1Function
{
   public class StaticMode121
    {

        /// <summary>
        /// Режим проставки статистики по КНД 1151001 и КНД 1151006
        /// </summary>
        /// <param name="libraryAutomation">Библиотека автоматизации</param>
        /// <param name="listDocError">Список ошибок</param>
        public void StaticMode1Nk1151001And1151006(LibraryAutomations libraryAutomation, AutomationElement[] listDocError)
        {
            LibraryAutomations libraryAutomationDoc = new LibraryAutomations(WindowsAis3.AisNalog3);
            var numHelp = new[] {"3","6","9"};
            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ModeStatic);
            AutoItX.Send(ButtonConstant.Tab);
            AutoItX.Send(ButtonConstant.Enter);
            while (true)
            {
                if (libraryAutomation.IsEnableElements(Journal129AndJournal121.WinTableError, null, true) != null)
                {
                    var listModeDocument = libraryAutomationDoc.SelectAutomationColrction(libraryAutomationDoc.FindFirstElement(Journal129AndJournal121.WinTableError)).Cast<AutomationElement>().Distinct().Where(elem => elem.Current.Name.Contains("Band 0 row"));
                    //Надо искать проставленна ли галочка или нет если проставлена закрываем если нет проставляем idObject
                    var isCheck = listModeDocument.FirstOrDefault(doc =>
                                     libraryAutomationDoc.ParseElementLegacyIAccessiblePatternIdentifiers(
                                       libraryAutomationDoc.SelectAutomationColrction(doc).Cast<AutomationElement>()
                                           .First(elem => elem.Current.Name.Contains("Выбрать"))) == "True");
                    var isNum = listModeDocument.FirstOrDefault(doc =>  numHelp.Any(num =>num.Equals(
                                                              libraryAutomationDoc.ParseElementLegacyIAccessiblePatternIdentifiers(
                                                              libraryAutomationDoc.SelectAutomationColrction(doc).Cast<AutomationElement>()
                                                              .First(elem => elem.Current.Name.Contains("Ун записи"))))));
                    var idObject = libraryAutomationDoc.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.FindFirstElement("Name:Ун записи", isNum, true));
                    if (isCheck == null)
                    {
                        var selectRow = listModeDocument.FirstOrDefault(doc =>
                                     libraryAutomationDoc.ParseElementLegacyIAccessiblePatternIdentifiers(
                                       libraryAutomationDoc.SelectAutomationColrction(doc).Cast<AutomationElement>()
                                           .First(elem => elem.Current.Name.Contains("Ун записи"))) == idObject);
                        libraryAutomation.FindFirstElement("Name:Выбрать", selectRow, true);
                        libraryAutomation.ClickElement(libraryAutomation.FindElement);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SaveUdError);
                        break;
                    }
                    else
                    {
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.CloseWinError);
                        break;
                    }
                }
            }
        }

    }
}
