using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoIt;
using LibaryXMLAuto.XsdModelAutoGenerate;
using LibraryAIS3Windows.AutomationsUI.LibaryAutomations;
using LibraryAIS3Windows.AutomationsUI.Otdels.Uregulirovanie;
using LibraryAIS3Windows.AutomationsUI.PublicElement;
using LibraryAIS3Windows.ButtonFullFunction.Okp3Function;
using LibraryAIS3Windows.ButtonsClikcs;
using LibraryAIS3Windows.Window;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace LibraryAIS3Windows.ButtonFullFunction.UregulirovanieAllFunction
{



    public class UregulirovanieStartProcess
    {
        /// <summary>
        /// Путь ветки Налоговое администрирование\Урегулирование задолженности (ЕНС)\Взыскание задолженности за счет ДС и ЭДС\Запуск БП
        /// </summary>
        public string TreeCollection = "Налоговое администрирование\\Урегулирование задолженности (ЕНС)\\Взыскание задолженности за счет ДС и ЭДС\\Запуск БП";

        /// <summary>
        /// Путь ветки Налоговое администрирование\Урегулирование задолженности (ЕНС)\Требования об уплате\Запуск БП
        /// </summary>
        public string TreeRequirement = "Налоговое администрирование\\Урегулирование задолженности (ЕНС)\\Требования об уплате\\Запуск БП";


        /// <summary>
        /// Запуск БП
        /// Налоговое администрирование\Урегулирование задолженности (ЕНС)\Взыскание задолженности за счет ДС и ЭДС\Запуск БП
        /// </summary>
        /// <param name="statusButton"></param>
        /// <param name="pathList">Полный путь к списку с ИНН</param>
        public void StartProcessCollection(StatusButtonMethod statusButton, string pathList)
        {
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            LibaryXMLAuto.ReadOrWrite.XmlReadOrWrite read = new LibaryXMLAuto.ReadOrWrite.XmlReadOrWrite();
            AutoGenerateSchemes modelListIncomeJournal = (AutoGenerateSchemes)read.ReadXml(pathList, typeof(AutoGenerateSchemes));
            var sw = TreeCollection.Split('\\').Last();
            var fullTree = string.Concat(PublicElementName.FullTree, $"Name:{sw}");
            libraryAutomation.InvokePattern(libraryAutomation.FindFirstElement(PublicElementName.ShowAll));
            libraryAutomation.IsEnableExpandTree(TreeCollection);
            libraryAutomation.FindFirstElement(fullTree, null, true);
            libraryAutomation.FindElement.SetFocus();
            libraryAutomation.ClickElements(fullTree, null, false, 25, 0, 0, 2);
            if (modelListIncomeJournal.InnFace != null)
            {
                foreach (var inn in modelListIncomeJournal.InnFace)
                {
                    if (statusButton.Iswork)
                    {
                        if (libraryAutomation.IsEnableElement(UregulirovanieCollection.ButtonStart))
                        {
                            if (libraryAutomation.IsEnableElements(UregulirovanieCollection.SendInn)!=null)
                            {
                                libraryAutomation.FindElement.SetFocus();
                                libraryAutomation.FindElement = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindElement)[0];
                                libraryAutomation.FindElement.SetFocus();
                                libraryAutomation.IsEnableElements(UregulirovanieCollection.SendInn);
                                libraryAutomation.FindElement = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindElement)[0];
                                libraryAutomation.SetValuePattern(inn.Inn);
                                libraryAutomation.IsEnableElements(UregulirovanieCollection.ButtonStart);
                                libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                                read.DeleteAtributXml(pathList, LibaryXMLAuto.GenerateAtribyte.GeneratorAtribute.GenerateAtrAutoGenerateSchemesDeleteIdDocInn(inn.Inn));
                            }
                        } 
                    }

                }
            }
            MouseCloseFormRsb(1);
        }

        /// <summary>
        /// Запуск БП
        /// Налоговое администрирование\Урегулирование задолженности (ЕНС)\Требования об уплате\Запуск БП
        /// </summary>
        /// <param name="statusButton"></param>
        /// <param name="pathList">Полный путь к списку с ИНН</param>
        public void StartProcessRequirement(StatusButtonMethod statusButton, string pathList)
        {
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            LibaryXMLAuto.ReadOrWrite.XmlReadOrWrite read = new LibaryXMLAuto.ReadOrWrite.XmlReadOrWrite();
            AutoGenerateSchemes modelListIncomeJournal = (AutoGenerateSchemes)read.ReadXml(pathList, typeof(AutoGenerateSchemes));
            var sw = TreeRequirement.Split('\\').Last();
            var fullTree = string.Concat(PublicElementName.FullTree, $"Name:{sw}");
            libraryAutomation.InvokePattern(libraryAutomation.FindFirstElement(PublicElementName.ShowAll));
            libraryAutomation.IsEnableExpandTree(TreeRequirement);
            libraryAutomation.FindFirstElement(fullTree, null, true);
            libraryAutomation.FindElement.SetFocus();
            libraryAutomation.ClickElements(fullTree, null, false, 25, 0, 0, 2);
            if (modelListIncomeJournal.InnFace != null)
            {
                foreach (var inn in modelListIncomeJournal.InnFace)
                {
                    if (statusButton.Iswork)
                    {
                        if (libraryAutomation.IsEnableElement(UregulirovanieRequirement.ButtonStart))
                        {
                            if (libraryAutomation.IsEnableElements(UregulirovanieRequirement.SendInn) != null)
                            {
                                libraryAutomation.FindElement.SetFocus();
                                libraryAutomation.FindElement = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindElement)[0];
                                libraryAutomation.FindElement.SetFocus();
                                libraryAutomation.IsEnableElements(UregulirovanieRequirement.SendInn);
                                libraryAutomation.FindElement = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindElement)[0];
                                libraryAutomation.SetValuePattern(inn.Inn);
                                libraryAutomation.IsEnableElements(UregulirovanieRequirement.ButtonStart);
                                libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, UregulirovanieRequirement.WinInfo);
                                read.DeleteAtributXml(pathList, LibaryXMLAuto.GenerateAtribyte.GeneratorAtribute.GenerateAtrAutoGenerateSchemesDeleteIdDocInn(inn.Inn));
                            }
                        }
                    }
                }
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
