using AutoIt;
using Ifns51.FromAis;
using System.Windows.Forms;
using Ifns51.ToAis;
using LibaryAIS3Windows.AutomationsUI.LibaryAutomations;
using LibaryAIS3Windows.AutomationsUI.Otdels.PreCheck;
using LibaryAIS3Windows.ButtonsClikcs;
using LibaryAIS3Windows.ModelData.PreCheck;
using LibaryAIS3Windows.Window;
using System.Linq;
using System.Windows.Automation;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using System;
using System.IO;

namespace LibaryAIS3Windows.ButtonFullFunction.PreCheck
{
   public class PreCheckFunction
    {
        /// <summary>
        ///Обработка ветки для данных для общей логики
        /// </summary>
        /// <param name="statusButton">Кнопка стоп</param>
        /// <param name="libraryAutomation">Библиотека</param>
        /// <param name="model">Модель Поля ИНН Ветка</param>
        /// <param name="tree">Веска для поиска</param>
        /// <param name="gridElement">Grid для значений</param>
        /// <param name="treeInnDataArea">Ветка условий</param>
        /// <param name="update">Обновить кнопка</param>
        /// <param name="filters">Фильтр кнопка</param>
        /// <param name="serviceGetOrPost">Адрес ответа с клиента</param>
        /// <param name="isType">Дополнительный параметр по Сведениям об учете</param>
        public void ParseDataBase(StatusButtonMethod statusButton,LibaryAutomations libraryAutomation, SrvToLoad model, string tree,string gridElement, string treeInnDataArea,string update,string filters, string serviceGetOrPost,bool isType = false)
        {
            var rowNumber = 1;
            DataBaseElementAdd dataBaseAdd = new DataBaseElementAdd();
            var sw = model.Tree.Split('\\').Last();
            var post = new HttpGetAndPost();
            libraryAutomation.FindFirstElement(tree, null, true);
            libraryAutomation.FindElement.SetFocus();
            libraryAutomation.ClickElements(tree, null, false, 25, 0, 0, 2);
            foreach(var inn in model.N134)
            {
                if (statusButton.Iswork)
                {
                    while (true)
                    {
                        if (libraryAutomation.FindFirstElement(treeInnDataArea, null, true) != null)
                        {
                            libraryAutomation.FindFirstElement(PreCheckElementName.Memo, libraryAutomation.FindElement,true);
                            libraryAutomation.FindElement.SetFocus();
                            SendKeys.SendWait("{ENTER}");
                            SendKeys.SendWait(inn);
                            break;
                        }
                    }
                    if (isType)
                    {
                        while (true)
                        {
                            if (libraryAutomation.FindFirstElement(string.Concat(PreCheckElementName.TreeInnDataArea, 7), null, true) != null)
                            {
                                libraryAutomation.FindFirstElement(PreCheckElementName.Memo, libraryAutomation.FindElement, true);
                                libraryAutomation.FindElement.SetFocus();
                                SendKeys.SendWait("{ENTER}");
                                SendKeys.SendWait("1");
                                break;
                            }
                        }
                    }
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, update);
                    PublicGlobalFunction.PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation, gridElement);
                    var modelPost = new AisParsedData() { N134 = inn, Tree = model.Tree };
                    AutomationElement automationElement;
                    
                    while ((automationElement =libraryAutomation.IsEnableElements(string.Concat(gridElement, "\\Name:select0 row ", rowNumber), null, true, 5)) != null)
                    {
                        switch (sw)
                        {
                            case "1.01. Идентификационные характеристики организации":
                                dataBaseAdd.AddUlFace(libraryAutomation, automationElement, ref modelPost, model.Fields);
                                break;
                            case "1.03. Сведения об учете организации в НО":
                                dataBaseAdd.AddSvedAccoutingUlFace(libraryAutomation, automationElement,ref modelPost , inn, model.Fields);
                                break;
                            case "1.12. Сведения о филиалах, представительствах, иных обособленных подразделениях":
                                dataBaseAdd.AddBranchUlFace(libraryAutomation, automationElement, inn);
                                break;
                            case "1.18. Сведения об объектах собственности российской организации – имущество":
                                dataBaseAdd.AddObjectUl(libraryAutomation, automationElement, inn, "Имущество");
                                break;
                            case "1.19. Сведения об объектах собственности российской организации – земля":
                                dataBaseAdd.AddObjectUl(libraryAutomation, automationElement, inn, "Земля");
                                break;
                            case "1.20. Сведения об объектах собственности российской организации – транспорт":
                                dataBaseAdd.AddObjectUl(libraryAutomation, automationElement, inn, "Транспорт");
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
                            case "1.18. Сведения об объектах собственности физического лица – имущество":
                                dataBaseAdd.AddObjectFl(libraryAutomation, automationElement, inn, "Имущество");
                                break;
                            case "1.19. Сведения об объектах собственности физического лица – земля":
                                dataBaseAdd.AddObjectFl(libraryAutomation, automationElement, inn, "Земля");
                                break;
                            case "1.20. Сведения об объектах собственности физического лица – транспорт":
                                dataBaseAdd.AddObjectFl(libraryAutomation, automationElement, inn, "Транспорт");
                                break;
                        }
                        rowNumber++;
                    }
                    //Статусы записывать в Log
                    var result = post.ResultPost(serviceGetOrPost, modelPost);
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
        /// <param name="model">Модель сервера</param>
        /// <param name="tree">Веска для поиска</param>
        /// <param name="gridElement">Grid для значений</param>
        /// <param name="treeInnDataArea">Ветка условий</param>
        /// <param name="update">Обновить кнопка</param>
        /// <param name="filters">Фильтр кнопка</param>
        /// <param name="serviceGetOrPost">Адрес ответа с клиента</param>
        /// <param name="pathTemp">Путь к папке Temp сохранения</param>
        public void IndividualCards(StatusButtonMethod statusButton, LibaryAutomations libraryAutomation, SrvToLoad model, string tree, string gridElement, string treeInnDataArea, string update, string filters, string serviceGetOrPost, string pathTemp)
        {
            DataBaseElementAdd dataBaseAdd = new DataBaseElementAdd();
            var post = new HttpGetAndPost();
            WindowsAis3 win;
            libraryAutomation.FindFirstElement(tree, null, true);
            libraryAutomation.FindElement.SetFocus();
            libraryAutomation.ClickElements(tree, null, false, 25, 0, 0, 2);
            foreach (var inn in model.N134)
            {
              if (statusButton.Iswork)
              {
                    while (true)
                    {
                        if (libraryAutomation.FindFirstElement(treeInnDataArea, null, true) != null)
                        {
                            libraryAutomation.FindFirstElement(PreCheckElementName.Memo, libraryAutomation.FindElement, true);
                            libraryAutomation.FindElement.SetFocus();
                            SendKeys.SendWait("{ENTER}");
                            SendKeys.SendWait(inn);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, update);
                            break;
                        }
                    }
                    PublicGlobalFunction.PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation, gridElement);
                    var modelPost = new AisParsedData() { N134 = inn, Tree = model.Tree };
                    while (true)
                    {
                       if (libraryAutomation.IsEnableElements(string.Concat(gridElement, "\\Name:select0 row 1"), null, true) != null)
                       {
                           PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, PreCheckElementNameIndividualCards.OpenFaceCard);
                           while (true)
                           {
                              if (libraryAutomation.IsEnableElements(PreCheckElementNameIndividualCards.PeriodEnd, null, true) != null)
                              {
                                libraryAutomation.SelectItemComboboxMaxYear(libraryAutomation.IsEnableElements(PreCheckElementNameIndividualCards.PeriodEnd));
                                var minYear = DateTime.Now.Year - 3;
                                libraryAutomation.SelectItemCombobox(libraryAutomation.IsEnableElements(PreCheckElementNameIndividualCards.PeriodBegin), minYear.ToString());
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, PreCheckElementNameIndividualCards.TotalCards);
                                AutoItX.ProcessWait("EXCEL.EXE", 60000);
                                PublicGlobalFunction.PublicGlobalFunction.CloseProcessProgram("EXCEL");
                                var file = PublicGlobalFunction.PublicGlobalFunction.ReturnNameLastFileTemp(pathTemp, "*.xml");
                                dataBaseAdd.AddIndividualCardsUlFace(file.NamePath, inn);
                                win = new WindowsAis3();
                                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                                break;
                              }
                           }
                       }
                       break;
                    }
                    var result = post.ResultPost(serviceGetOrPost, modelPost);
                    if (result == null)
                    {
                        statusButton.Iswork = false;
                    }
                    libraryAutomation.IsEnableElements(filters);
                    libraryAutomation.InvokePattern(libraryAutomation.FindElement);
              }
              else
              {
                  statusButton.Iswork = false;
              }
            }
            win = new WindowsAis3();
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
        }

        /// <summary>
        /// Данные ветки 
        /// Налоговое администрирование\Контрольная работа (налоговые проверки)\101. Мониторинг и обработка документов\Реестр документов НБО
        /// </summary>
        /// <param name="statusButton">Кнопка запуска</param>
        /// <param name="libraryAutomation">Библиотека Автоматизации</param>
        /// <param name="model">Модель загрузки данных</param>
        /// <param name="tree">Дерево</param>
        /// <param name="serviceGetOrPost">Сервис ответов</param>
        /// <param name="pathSaveBank">Путь сохранения банковских выписок</param>
        public void BankSpr(StatusButtonMethod statusButton, LibaryAutomations libraryAutomation, SrvToLoad model, string tree, string serviceGetOrPost, string pathSaveBank)
        {
            var numberFile = 1;
            DataBaseElementAdd dataBaseAdd = new DataBaseElementAdd();
            var post = new HttpGetAndPost();
            libraryAutomation.FindFirstElement(tree, null, true);
            libraryAutomation.FindElement.SetFocus();
            libraryAutomation.ClickElements(tree, null, false, 25, 0, 0, 2);
            foreach (var inn in model.N134)
            {
                if (statusButton.Iswork)
                {
                    var elementRadExpanderList = libraryAutomation.SelectAutomationColrction(libraryAutomation.IsEnableElements(PreCheckElementNameBank.FullTaxpayerListControl)).Cast<AutomationElement>().Where(elem => elem.Current.ClassName == "RadExpander").ToList();
                    while (true)
                    {
                        if (libraryAutomation.FindFirstElement(PreCheckElementNameBank.InputInn, null, true) != null)
                        {
                            libraryAutomation.SetValuePattern(inn);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, PreCheckElementNameBank.PeriodSelect);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, PreCheckElementNameBank.FindButton);
                            while (true)
                            {
                                if (libraryAutomation.IsEnableElements(PreCheckElementNameBank.SelectItem, elementRadExpanderList[0], true, 500) != null)
                                {
                                   libraryAutomation.ClickElements(PreCheckElementNameBank.SelectItem, elementRadExpanderList[0]);
                                   PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, PreCheckElementNameBank.ViewSpravki);
                                    while (true)
                                    {
                                        if (libraryAutomation.IsEnableElements(PreCheckElementNameBank.ElementSpr, elementRadExpanderList[1], true, 3000) != null)
                                        {
                                            var listGr = libraryAutomation.SelectAutomationColrction(libraryAutomation.IsEnableElements(PreCheckElementNameBank.DonloadFileXlxsSave, elementRadExpanderList[1])).Cast<AutomationElement>().Where(elem => elem.Current.ClassName == "RadDropDownButton").ToList();
                                            var buttonList = libraryAutomation.SelectAutomationColrction(listGr[2]);
                                            libraryAutomation.ClickElement(buttonList[1]);
                                            if (libraryAutomation.IsEnableElements(PreCheckElementNameBank.SaveDialogNameFileWin10, null, false, 3) != null)
                                            {
                                                libraryAutomation.SetValuePattern("Name" + numberFile);
                                                libraryAutomation.IsEnableElements(PreCheckElementNameBank.PathSaveWin10);
                                                libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                                            }
                                            if (libraryAutomation.IsEnableElements(PreCheckElementNameBank.SaveDialogNameFileWin7, null, false, 3) != null)
                                            {
                                                libraryAutomation.SetValuePattern("Name" + numberFile);
                                                libraryAutomation.IsEnableElements(PreCheckElementNameBank.PathSaveWin7);
                                                libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                                            }
                                            while (true)
                                            {
                                                if (libraryAutomation.IsEnableElements(PreCheckElementNameBank.ElementSpr, elementRadExpanderList[1], true) != null)
                                                {
                                                    var file = PublicGlobalFunction.PublicGlobalFunction.ReturnNameLastFileTemp(pathSaveBank, "*.xlsx");
                                                    dataBaseAdd.AddCashBankAllUlFace(file.NamePath, inn);
                                                    File.Delete(file.NamePath);
                                                    break;
                                                }
                                            }
                            
                                        }
                                        break;
                                    }
                                }
                                break;
                            }
                            break;
                        }
                    }
                    var modelPost = new AisParsedData() { N134 = inn, Tree = model.Tree };
                    numberFile++;
                    var result = post.ResultPost(serviceGetOrPost, modelPost);
                    if (result == null)
                    {
                        statusButton.Iswork = false;
                    }
                }
                else
                {
                    statusButton.Iswork = false;
                }
            }
            var win = new WindowsAis3();
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
        }
        /// <summary>
        /// Обработка ветки Налоговое администрирование\Контрольная работа (налоговые проверки)\101. Мониторинг и обработка документов\Реестр документов НБО
        /// Обработка ветки Налоговое администрирование\Контрольная работа (налоговые проверки)\124. Миграция НП в части КНП\1. Реестр документов НБО
        /// </summary>
        /// <param name="statusButton">Кнопка стоп</param>
        /// <param name="libraryAutomation">Библиотека</param>
        /// <param name="model">Модель Поля ИНН Ветка</param>
        /// <param name="tree">Веска для поиска</param>
        /// <param name="gridElement">Grid для значений</param>
        /// <param name="treeInnDataArea">Ветка условий</param>
        /// <param name="update">Обновить кнопка</param>
        /// <param name="filters">Фильтр кнопка</param>
        /// <param name="serviceGetOrPost">Адрес ответа с клиента</param>
        /// <param name="pathTemp">Путь к сохранению документа</param>
        public void DeclarationIntelligenceUl(StatusButtonMethod statusButton, LibaryAutomations libraryAutomation, SrvToLoad model, string tree, string gridElement,  string treeInnDataArea, string update, string filters, string serviceGetOrPost, string pathTemp)
        {
            DataBaseElementAdd dataBaseAdd = new DataBaseElementAdd();
            var post = new HttpGetAndPost();
            WindowsAis3 win;
            libraryAutomation.FindFirstElement(tree, null, true);
            libraryAutomation.FindElement.SetFocus();
            libraryAutomation.ClickElements(tree, null, false, 25, 0, 0, 2);
            foreach (var inn in model.N134)
            {
                if (statusButton.Iswork)
                {
                    while (true)
                    {
                        if (libraryAutomation.FindFirstElement(treeInnDataArea, null, true) != null)
                        {
                            libraryAutomation.FindFirstElement(PreCheckElementName.Memo, libraryAutomation.FindElement, true);
                            libraryAutomation.FindElement.SetFocus();
                            SendKeys.SendWait("{ENTER}");
                            SendKeys.SendWait(inn);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, update);
                            break;
                        }
                    }
                    PublicGlobalFunction.PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation, gridElement);
                    var declList = new[]  { "Бухгалтерская (финансовая) отчетность", "Налоговая декларация по налогу на прибыль организаций", "Налоговая декларация по налогу на добавленную стоимость" };
                    var controlYears = DateTime.Now.Year - 3;
                    if(PublicGlobalFunction.PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation, gridElement) !="Данные, удовлетворяющие заданным условиям не найдены.")
                    {
                        var allReport = libraryAutomation.SelectAutomationColrction(libraryAutomation.IsEnableElements(gridElement)).Cast<AutomationElement>().Where(elem => elem.Current.Name != "Data Area").Distinct().Where(doc =>
                                    declList.Any(decl => decl.Equals(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                        libraryAutomation.SelectAutomationColrction(doc).Cast<AutomationElement>()
                                            .First(elem => elem.Current.Name.Contains("Документ")))))
                                    &&
                                    Convert.ToInt32(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                        libraryAutomation.SelectAutomationColrction(doc).Cast<AutomationElement>()
                                            .First(elem => elem.Current.Name.Contains("Отчетный год")))) >= controlYears 
                                    && 
                                    dataBaseAdd.DeclarationDataExists(Convert.ToInt64(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                        libraryAutomation.SelectAutomationColrction(doc).Cast<AutomationElement>()
                                            .First(elem => elem.Current.Name.Contains("РегНомер"))))) ==false
                                ).ToList();

                            foreach (var element in allReport)
                            {
                                var declarationUl = dataBaseAdd.AddDeclaration(libraryAutomation, element);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, PreCheckElementNameDeclaration.ReestrNbo);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, PreCheckElementNameDeclaration.ViewDeclaretion);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, PreCheckElementNameDeclaration.ExportFile);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, PreCheckElementNameDeclaration.ExportFileOk);
                                AutoItX.ProcessWait("EXCEL.EXE", 60000);
                                PublicGlobalFunction.PublicGlobalFunction.CloseProcessProgram("EXCEL");
                                var file = PublicGlobalFunction.PublicGlobalFunction.ReturnNameLastFileTemp(pathTemp, "*.xlsx");
                                dataBaseAdd.AddDeclarationData(file.NamePath, declarationUl, inn);
                                win = new WindowsAis3();
                                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                            }
                    }
                    var modelPost = new AisParsedData() { N134 = inn, Tree = model.Tree };
                    libraryAutomation.IsEnableElements(filters);
                    libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                    var result = post.ResultPost(serviceGetOrPost, modelPost);
                    if (result == null)
                    {
                        statusButton.Iswork = false;
                    }
                }
                else
                {
                    statusButton.Iswork = false;
                }
            }
            win = new WindowsAis3();
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
        }

        /// <summary>
        /// Поиск ЮЛ Выписок ЮЛ и раскладка их В БД
        /// </summary>
        public void FindUlStatement(StatusButtonMethod statusButton, LibaryAutomations libraryAutomation, SrvToLoad model, string tree, string gridElement, string treeInnDataArea, string update, string filters, string serviceGetOrPost, string pathTemp)
        {
            DataBaseElementAdd dataBaseAdd = new DataBaseElementAdd();
          
            var post = new HttpGetAndPost();
            WindowsAis3 win;
            libraryAutomation.FindFirstElement(tree, null, true);
            libraryAutomation.FindElement.SetFocus();
            libraryAutomation.ClickElements(tree, null, false, 25, 0, 0, 2);
            foreach (var inn in model.N134)
            {
                if (statusButton.Iswork)
                {
                    while (true)
                    {
                        if (libraryAutomation.FindFirstElement(treeInnDataArea, null, true) != null)
                        {
                            libraryAutomation.FindFirstElement(PreCheckElementName.Memo, libraryAutomation.FindElement, true);
                            libraryAutomation.FindElement.SetFocus();
                            SendKeys.SendWait("{ENTER}");
                            SendKeys.SendWait(inn);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, update);
                            break;
                        }
                    }
                    if (PublicGlobalFunction.PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation, gridElement) != "Данные, удовлетворяющие заданным условиям не найдены.")
                    {
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, PreCheckFindUl.PrintStatement);
                        AutoItX.ProcessWait("WINWORD.EXE", 60000);
                        PublicGlobalFunction.PublicGlobalFunction.KillProcessProgram("WINWORD");
                        var file = PublicGlobalFunction.PublicGlobalFunction.ReturnNameLastFileTemp(pathTemp, "*.rtf");
                        dataBaseAdd.AddDbStatement(file.NamePath, inn);
                    }
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, filters);
                    //var modelPost = new AisParsedData() { N134 = inn, Tree = model.Tree };
                    //var result = post.ResultPost(serviceGetOrPost, modelPost);
                    //if (result == null)
                    //{
                    //    statusButton.Iswork = false;
                    //}
                }
                else
                {
                    statusButton.Iswork = false;
                }
            }
            win = new WindowsAis3();
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
        } 
   }
}
