using System.Linq;
using System.Windows.Automation;
using System.Windows.Forms;
using AutoIt;
using LibaryXMLAuto.XsdModelAutoGenerate;
using LibraryAIS3Windows.AutomationsUI.LibaryAutomations;
using LibraryAIS3Windows.AutomationsUI.Otdels.Okp4;
using LibraryAIS3Windows.AutomationsUI.PublicElement;
using LibraryAIS3Windows.ButtonsClikcs;
using LibraryAIS3Windows.Window;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace LibraryAIS3Windows.ButtonFullFunction.Okp4Function
{
    public class RealEstateInquiries
    {
        /// <summary>
        /// Путь ветки Налоговое администрирование\Собственность\08. Взаимодействие с органами Росреестра – Объекты недвижимости\09. Уточняющие запросы - Витрина запросов для уточнения сведений
        /// </summary>
        public string TreeSender = "Налоговое администрирование\\Собственность\\08. Взаимодействие с органами Росреестра – Объекты недвижимости\\09. Уточняющие запросы - Витрина запросов для уточнения сведений";

        /// <summary>
        /// Запуск запросов для витрины ЦУН права владения
        /// Налоговое администрирование\Собственность\08. Взаимодействие с органами Росреестра – Объекты недвижимости\09. Уточняющие запросы - Витрина запросов для уточнения сведений
        /// </summary>
        /// <param name="statusButton"></param>
        /// <param name="pathList">Полный путь к списку с ИНН</param>
        public void StartRealEstateInquiries(StatusButtonMethod statusButton, string pathList)
        {
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            LibaryXMLAuto.ReadOrWrite.XmlReadOrWrite read = new LibaryXMLAuto.ReadOrWrite.XmlReadOrWrite();
            AutoGenerateSchemes modelListIncomeJournal = (AutoGenerateSchemes)read.ReadXml(pathList, typeof(AutoGenerateSchemes));
            var sw = TreeSender.Split('\\').Last();
            var fullTree = string.Concat(PublicElementName.FullTree, $"Name:{sw}");
            libraryAutomation.InvokePattern(libraryAutomation.FindFirstElement(PublicElementName.ShowAll));
            libraryAutomation.IsEnableExpandTree(TreeSender);
            libraryAutomation.FindFirstElement(fullTree, null, true);
            libraryAutomation.FindElement.SetFocus();
            libraryAutomation.ClickElements(fullTree, null, false, 25, 0, 0, 2);
            if (modelListIncomeJournal.RealEstate != null)
            {
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, PublicElementName.UpdateButton);
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, RealEstateInquiriesModel.StartProcess);
                SendKeys.SendWait(ButtonConstant.Down4);
                SendKeys.SendWait(ButtonConstant.Enter);
                foreach (var elementNumber in modelListIncomeJournal.RealEstate)
                {
                    if (statusButton.Iswork)
                    {
                        if (libraryAutomation.IsEnableElements(RealEstateInquiriesModel.MemoNumber) != null)
                        {
                            libraryAutomation.SetValuePattern(elementNumber.CadastralNumber);
                            libraryAutomation.InvokePattern(libraryAutomation.IsEnableElements(RealEstateInquiriesModel.ComboBox, null, true));
                            var memo = libraryAutomation.SelectAutomationColrction(libraryAutomation.IsEnableElements(RealEstateInquiriesModel.List, null, true));
                            var elemClick = memo.Cast<AutomationElement>().FirstOrDefault(x => x.Current.Name.ToLower().Contains(elementNumber.ObjectType));
                            libraryAutomation.ClickElement(elemClick);
                            libraryAutomation.TogglePatternInputAndStatus(libraryAutomation.IsEnableElements(RealEstateInquiriesModel.CheckPassport));
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, RealEstateInquiriesModel.ButtonStartSender);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, RealEstateInquiriesModel.WinOk);
                            read.DeleteAtributXml(pathList, LibaryXMLAuto.GenerateAtribyte.GeneratorAtribute.GenerateAtrAutoGenerateSchemesDeleteRealEstate(elementNumber.CadastralNumber));
                        }
                    }
                }
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, RealEstateInquiriesModel.Closed);
            }
            MouseCloseFormRsb(1);
        }


        /// <summary>
        /// Закрыть подчиненные формы
        /// </summary>
        private void MouseCloseFormRsb(int countClose)
        {
            var win = new WindowsAis3();
            while (countClose > 0)
            {
                AutoItX.Sleep(1000);
                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                countClose--;
            }
        }
    }
}
