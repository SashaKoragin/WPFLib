using AutoIt;
using Ifns51.FromAis;
using LibaryAIS3Windows.AutomationsUI.LibaryAutomations;
using LibaryAIS3Windows.AutomationsUI.Otdels.PreCheck;
using LibaryAIS3Windows.ButtonsClikcs;
using LibaryAIS3Windows.ModelData.PreCheck;
using LibaryAIS3Windows.Window;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Automation;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace LibaryAIS3Windows.ButtonFullFunction.PreCheck
{
   public class PreCheckFunction
    {
        /// <summary>
        ///Обработка ветки для данных для общей логики
        /// </summary>
        /// <param name="statusButton">Кнопка стоп</param>
        /// <param name="libraryAutomation">Библиотека</param>
        /// <param name="inns">ИННЫ</param>
        /// <param name="tree">Веска для поиска</param>
        /// <param name="gridElement">Grid для парсинга значений</param>
        /// <param name="treeInnDataArea">Ветка условий</param>
        /// <param name="update">Обновить кнопка</param>
        /// <param name="filters">Фильтр кнопка</param>
        /// <param name="modelServerTree">Модель с сервера</param>
        /// <param name="serviceGetOrPost">Адрес ответа с клиента</param>
        public void ParseDataBase(StatusButtonMethod statusButton,LibaryAutomations libraryAutomation, string[] inns, string tree,string gridElement, string treeInnDataArea,string update,string filters,string modelServerTree, string serviceGetOrPost)
        {
            var rowNumber = 1;
            DataBaseElementAdd dataBaseAdd = new DataBaseElementAdd();
            var sw = modelServerTree.Split('\\').Last();
            var post = new HttpGetAndPost();
            libraryAutomation.FindFirstElement(tree, null, true);
            libraryAutomation.FindElement.SetFocus();
            libraryAutomation.ClickElements(tree, null, false, 25, 0, 0, 2);
            foreach(var inn in inns)
            {
                if (statusButton.Iswork)
                {
                    while (true)
                   {
                       if (libraryAutomation.FindFirstElement(treeInnDataArea, null, true) != null)
                       {
                           libraryAutomation.FindFirstElement(PreCheckElementName.Memo, libraryAutomation.FindElement,true);
                           libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                           AutoItX.Send(inn);
                           PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, update);
                           break;
                       }
                   }
                   var model = new AisParsedData() {N134 = inn, Tree = modelServerTree};
                   AutomationElement automationElement;
                   AutoItX.Sleep(500);
                   while ((automationElement =libraryAutomation.IsEnableElements(string.Concat(gridElement, rowNumber), null, true,20)) != null)
                   {
                       switch (sw)
                       {
                           case "1.01. Идентификационные характеристики организации":
                               dataBaseAdd.AddUlFace(libraryAutomation, automationElement);
                               break;
                           case "1.03. Сведения об учете организации в НО":
                               dataBaseAdd.AddSvedAccoutingUlFace(libraryAutomation, automationElement, inn);
                               break;
                           case "1.12. Сведения о филиалах, представительствах, иных обособленных подразделениях":
                                dataBaseAdd.AddBranchUlFace(libraryAutomation, automationElement, inn);
                                break;
                           case "1.18. Сведения об объектах собственности российской организации – имущество":
                               dataBaseAdd.AddPropertyUlFace(libraryAutomation, automationElement, inn);
                               break;
                           case "1.19. Сведения об объектах собственности российской организации – земля":
                               dataBaseAdd.AddLandUlFace(libraryAutomation, automationElement, inn);
                               break;
                           case "1.20. Сведения об объектах собственности российской организации – транспорт":
                               dataBaseAdd.AddTransportUlFace(libraryAutomation, automationElement, inn);
                               break;
                            case "2.02. История изменений сведений об учете организации в НО":
                                dataBaseAdd.AddHistory(libraryAutomation, automationElement, inn);
                                break;
                            case "Сведения о среднесписочной численности работников":
                                dataBaseAdd.AddStrngthUlFace(libraryAutomation, automationElement, inn);
                                break;
                            case "01. Картотека счетов РО, ИО, ИП":
                                dataBaseAdd.AddCashUlFace(libraryAutomation, automationElement, inn);
                                break;
                       }
                        var dictionary = new Dictionary<string, string>();
                        foreach (var elem in libraryAutomation.SelectAutomationColrction(automationElement).Cast<AutomationElement>())
                        {
                            var value = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(elem);
                            if (string.IsNullOrWhiteSpace(value))
                            {
                                value = libraryAutomation.ParseValuePattern(elem);
                            }
                            if (!string.IsNullOrWhiteSpace(elem.Current.Name)) { dictionary.Add(elem.Current.Name, value); }
                        }
                        model.Data.Add(dictionary);
                        rowNumber++;
                   }
                    //Статусы записывать в Log
                    var result = post.ResultPost(serviceGetOrPost, model);
                    if (result == null)
                    {
                        statusButton.Iswork = false;
                    }
                    rowNumber = 1;
                libraryAutomation.IsEnableElements(filters);
                libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                }
                else
                {
                    statusButton.Iswork = false;
                }
            }
            WindowsAis3 win = new WindowsAis3();
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
        }
        /// <summary>
        /// ППА индивидуальные карточки
        /// </summary>
        /// <param name="statusButton">Кнопка стоп</param>
        /// <param name="libraryAutomation">Библиотека</param>
        /// <param name="inns">ИННЫ</param>
        /// <param name="tree">Веска для поиска</param>
        /// <param name="gridElement">Grid для парсинга значений</param>
        /// <param name="treeInnDataArea">Ветка условий</param>
        /// <param name="update">Обновить кнопка</param>
        /// <param name="filters">Фильтр кнопка</param>
        /// <param name="modelServerTree">Модель с сервера</param>
        /// <param name="serviceGetOrPost">Адрес ответа с клиента</param>
        public void IndividualCards(StatusButtonMethod statusButton, LibaryAutomations libraryAutomation, string[] inns, string tree, string gridElement, string treeInnDataArea, string update, string filters, string modelServerTree, string serviceGetOrPost)
        {
            var rowNumber = 1;
            DataBaseElementAdd dataBaseAdd = new DataBaseElementAdd();
            var post = new HttpGetAndPost();
            WindowsAis3 win;
            libraryAutomation.FindFirstElement(tree, null, true);
            libraryAutomation.FindElement.SetFocus();
            libraryAutomation.ClickElements(tree, null, false, 25, 0, 0, 2);
            foreach (var inn in inns)
            {
                //    if (statusButton.Iswork)
                //     {
                while (true)
                {
                    if (libraryAutomation.FindFirstElement(treeInnDataArea, null, true) != null)
                    {
                        libraryAutomation.FindFirstElement(PreCheckElementName.Memo, libraryAutomation.FindElement, true);
                        libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                        AutoItX.Send(inn);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, update);
                        break;
                    }
                }
                var model = new AisParsedData() { N134 = inn, Tree = modelServerTree };
                while (true)
                {
                    if (libraryAutomation.IsEnableElements(string.Concat(gridElement, 1), null, true) != null)
                    {
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, PreCheckElementNameIndividualCards.OpenFaceCard);
                        while (true)
                        {
                            if (libraryAutomation.IsEnableElements(PreCheckElementNameIndividualCards.PeriodEnd, null, true) != null)
                            {
                                var MinYear = (libraryAutomation.SelectItemComboboxMaxYear(libraryAutomation.IsEnableElements(PreCheckElementNameIndividualCards.PeriodEnd)) - 2).ToString();
                                libraryAutomation.SelectItemCombobox(libraryAutomation.IsEnableElements(PreCheckElementNameIndividualCards.PeriodBegin), MinYear);
                                dataBaseAdd.AddIndividualCardsUlFace(libraryAutomation, inn);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, PreCheckElementNameIndividualCards.RaschetCard);
                                break;
                            }
                        }
                        break;
                    } 
                }
                AutomationElement automationElement;
                AutoItX.Sleep(500);
                while ((automationElement = libraryAutomation.IsEnableElements(string.Concat(PreCheckElementNameIndividualCards.PanelDataGrid, rowNumber), null, true, 5)) != null)
                {
                    dataBaseAdd.AddRaschetCard(libraryAutomation, automationElement, inn);
                    rowNumber++;
                }
                win = new WindowsAis3();
                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                rowNumber = 1;
                libraryAutomation.IsEnableElements(filters);
                libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                //}
                //else
                //{
                //    statusButton.Iswork = false;
                //}
            }
            win = new WindowsAis3();
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
        }
    }
}
