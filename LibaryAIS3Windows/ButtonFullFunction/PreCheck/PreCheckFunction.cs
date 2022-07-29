using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows.Automation;
using System.Windows.Forms;
using AisPoco.Ifns51.FromAis;
using AisPoco.Ifns51.ToAis;
using AutoIt;
using LibraryAIS3Windows.AutomationsUI.LibaryAutomations;
using LibraryAIS3Windows.AutomationsUI.Otdels.PreCheck;
using LibraryAIS3Windows.ButtonFullFunction.PublicGlobalFunction;
using LibraryAIS3Windows.ButtonsClikcs;
using LibraryAIS3Windows.ModelData.PreCheck;
using LibraryAIS3Windows.Window;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;

namespace LibraryAIS3Windows.ButtonFullFunction.PreCheck
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
        /// <param name="serviceGetOrPost">Адрес ответа с клиента</param>
        /// <param name="pathTemp">Путь выгрузки</param>
        public void ParseDataBase(StatusButtonMethod statusButton,LibraryAutomations libraryAutomation, SrvToLoad model, string tree, string serviceGetOrPost, string pathTemp)
        {
            if (!libraryAutomation.IsEnableExpandTree(model.Tree)) return;
            DataBaseElementAdd dataBaseAdd = new DataBaseElementAdd();
            var sw = model.Tree.Split('\\').Last();
            var post = new HttpGetAndPost();
            libraryAutomation.FindFirstElement(tree, null, true);
            libraryAutomation.FindElement.SetFocus();
            libraryAutomation.ClickElements(tree, null, false, 25, 0, 0, 2);
            foreach (var inn in model.INN)
            {
                model.TreeDataArea.DataAreaParameters.First(parameters => parameters.NameParameters == "ИНН").ParametersGrid = inn;
                if (statusButton.Iswork)
                {
                    foreach (var dataAreaParameters in model.TreeDataArea.DataAreaParameters)
                    {
                        while (true)
                        {
                            if (libraryAutomation.FindFirstElement(string.Concat(model.TreeDataArea.FullPathDataArea, dataAreaParameters.IndexParameters), null, true) != null)
                            {
                                libraryAutomation.FindFirstElement(dataAreaParameters.FindNameMemo, libraryAutomation.FindElement, true);
                                libraryAutomation.FindElement.SetFocus();
                                SendKeys.SendWait("{ENTER}");
                                AutoItX.Sleep(500);
                                SendKeys.SendWait(dataAreaParameters.ParametersGrid);
                                break;
                            }
                        }
                    }
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, model.TreeUpdate);
                    var modelPost = new AisParsedData() { N134 = inn, Tree = model.Tree };
                    AutomationElement automationElement;
                    //Поправил Баг
                    while (true)
                    {
                        var grid = PublicGlobalFunction.PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation, model.TreeGrid.FullPathGrid); //Здесь баг если ошибка обновляем данные нужно кидать на обновить кнопку до 3 раз
                        if (string.IsNullOrWhiteSpace(grid))
                        {
                            break;
                        }
                        if (grid == "Данные, удовлетворяющие заданным условиям не найдены.")
                        {
                            break;
                        }
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, model.TreeUpdate);
                    }
                    while ((automationElement =libraryAutomation.IsEnableElements(model.TreeGrid.GridToIndexParameter, null, true, 5)) != null)
                    {
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, model.TreeExport);
                        GetFile file;
                        var sheetName = "Sheet";
                        while (true)
                        {
                            if (libraryAutomation.IsEnableElements(PreCheckElementName.WinExport, null, true) != null)
                            {
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, PreCheckElementName.WinExport);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, PreCheckElementName.ExportMenuXlsx);
                                libraryAutomation.FindFirstElement(PreCheckElementName.ExportNameList);
                                libraryAutomation.SetValuePattern(sheetName);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, PreCheckElementName.Export);
                                PublicGlobalFunction.PublicGlobalFunction.ExcelSaveAndClose();
                                file = PublicGlobalFunction.PublicGlobalFunction.ReturnNameLastFileTemp(pathTemp, "*.xlsx");
                                break;
                            }
                        }
                        switch (sw)
                        {
                            case "1.01. Идентификационные характеристики организации":
                                dataBaseAdd.AddUlFace(ref modelPost, model.Memo, file.NamePath, sheetName);
                                break;
                            case "1.03. Сведения об учете организации в НО":
                                dataBaseAdd.AddSvedAccoutingUlFace(ref modelPost, inn, model.Memo, file.NamePath, sheetName);
                                break;
                            case "1.12. Сведения о филиалах, представительствах, иных обособленных подразделениях":
                                dataBaseAdd.AddBranchUlFace(ref modelPost, inn, model.Memo, file.NamePath, sheetName);
                                break;
                            case "1.18. Сведения об объектах собственности российской организации – имущество":
                                dataBaseAdd.AddObjectUl(ref modelPost, inn, model.Memo, file.NamePath, sheetName, "Имущество");
                                break;
                            case "1.19. Сведения об объектах собственности российской организации – земля":
                                dataBaseAdd.AddObjectUl(ref modelPost, inn, model.Memo, file.NamePath, sheetName, "Земля");
                                break;
                            case "1.20. Сведения об объектах собственности российской организации – транспорт":
                                dataBaseAdd.AddObjectUl(ref modelPost, inn, model.Memo, file.NamePath, sheetName, "Транспорт");
                                break;
                            case "2.02. История изменений сведений об учете организации в НО":
                                dataBaseAdd.AddHistory(ref modelPost, inn, model.Memo, file.NamePath, sheetName);
                                break;
                            case "Сведения о среднесписочной численности работников":
                                dataBaseAdd.AddStrngthUlFace(ref modelPost, inn, model.Memo, file.NamePath, sheetName);
                                break;
                            case "01. Картотека счетов РО, ИО, ИП":
                                dataBaseAdd.AddCashUlFace(inn, file.NamePath, sheetName);
                                break;
                            case "1.18. Сведения об объектах собственности физического лица – имущество":
                                dataBaseAdd.AddObjectFl(ref modelPost, inn, model.Memo, file.NamePath, sheetName, "Имущество");
                                break;
                            case "1.19. Сведения об объектах собственности физического лица – земля":
                                dataBaseAdd.AddObjectFl(ref modelPost, inn, model.Memo, file.NamePath, sheetName, "Земля");
                                break;
                            case "1.20. Сведения об объектах собственности физического лица – транспорт":
                                dataBaseAdd.AddObjectFl(ref modelPost, inn, model.Memo, file.NamePath, sheetName, "Транспорт");
                                break;
                            case "4.01. Доходы и вычеты по месяцам":
                                dataBaseAdd.AddNdFl(inn, file.NamePath, sheetName);
                                break;
                        }
                        break;
                    }
                    //Статусы записывать в Log
                    modelPost.IdTemplate = model.IdTemplate;
                    var result = post.ResultPost(serviceGetOrPost, modelPost);
                    if (result == null)
                    {
                        statusButton.Iswork = false;
                    }
                    libraryAutomation.IsEnableElements(model.TreeFilter);
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
        /// <param name="serviceGetOrPost">Адрес ответа с клиента</param>
        /// <param name="pathTemp">Путь к папке Temp сохранения</param>
        /// <param name="yearReport">Отчетный год</param>
        public void IndividualCards(StatusButtonMethod statusButton, LibraryAutomations libraryAutomation, SrvToLoad model, string tree, string serviceGetOrPost, string pathTemp, int yearReport)
        {
            if (!libraryAutomation.IsEnableExpandTree(model.Tree)) return;
            DataBaseElementAdd dataBaseAdd = new DataBaseElementAdd();
            var post = new HttpGetAndPost();
            WindowsAis3 win;
            libraryAutomation.FindFirstElement(tree, null, true);
            libraryAutomation.FindElement.SetFocus();
            libraryAutomation.ClickElements(tree, null, false, 25, 0, 0, 2);
            foreach (var inn in model.INN)
            {
                model.TreeDataArea.DataAreaParameters.First(parameters => parameters.NameParameters == "ИНН").ParametersGrid = inn;
                if (statusButton.Iswork)
                {
                    foreach (var dataAreaParameters in model.TreeDataArea.DataAreaParameters)
                    {
                        while (true)
                        {
                            if (libraryAutomation.FindFirstElement(string.Concat(model.TreeDataArea.FullPathDataArea, dataAreaParameters.IndexParameters), null, true) != null)
                            {
                                libraryAutomation.FindFirstElement(dataAreaParameters.FindNameMemo, libraryAutomation.FindElement, true);
                                libraryAutomation.FindElement.SetFocus();
                                SendKeys.SendWait("{ENTER}");
                                AutoItX.Sleep(500);
                                SendKeys.SendWait(dataAreaParameters.ParametersGrid);
                                break;
                            }
                        }
                    }
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, model.TreeUpdate);
                    PublicGlobalFunction.PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation, model.TreeGrid.FullPathGrid);
                    var modelPost = new AisParsedData() {N134 = inn, Tree = model.Tree};
                    while (true)
                    {
                        if (libraryAutomation.IsEnableElements(model.TreeGrid.GridToIndexParameter, null, true) != null)
                        {
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, PreCheckElementNameIndividualCards.OpenFaceCard);
                            while (true)
                            {
                                if (libraryAutomation.IsEnableElements(PreCheckElementNameIndividualCards.PeriodEnd, null, true)!= null)
                                {
                                    var selectYear = yearReport - 1; //Костыль - 1 год от входящего
                                    libraryAutomation.FindTextComboboxIsToFocusAndClickElement(PreCheckElementNameIndividualCards.PeriodEnd, selectYear.ToString());
                                    if (libraryAutomation.IsEnableElements(PreCheckElementNameIndividualCards.ErrorYear, null, true, 20) != null)
                                    {
                                        AutoItX.Sleep(1000);
                                        libraryAutomation.ClickElements(PreCheckElementNameIndividualCards.ErrorYear, null, true);
                                        if (libraryAutomation.IsEnableElements(PreCheckElementNameIndividualCards.ErrorData, null, true) != null)
                                        {
                                            libraryAutomation.ClickElements(PreCheckElementNameIndividualCards.ErrorData, null, true);
                                        }
                                    }

                                    var minYear = yearReport - 3;
                                    libraryAutomation.FindTextComboboxIsToFocusAndClickElement(PreCheckElementNameIndividualCards.PeriodBegin, minYear.ToString());

                                    if (libraryAutomation.IsEnableElements(PreCheckElementNameIndividualCards.ErrorYear, null, true, 20) != null)
                                    {
                                        AutoItX.Sleep(1000);
                                        libraryAutomation.ClickElements(PreCheckElementNameIndividualCards.ErrorYear, null, true);
                                        if (libraryAutomation.IsEnableElements(PreCheckElementNameIndividualCards.ErrorData, null, true) != null)
                                        {
                                            libraryAutomation.ClickElements(PreCheckElementNameIndividualCards.ErrorData, null, true);
                                        }
                                    }
                                    while (true)
                                    {
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, PreCheckElementNameIndividualCards.TotalCards);
                                        AutoItX.ProcessWait("EXCEL.EXE", 15000);
                                        if (AutoItX.ProcessExists("EXCEL.EXE") != 0)
                                        {
                                            PublicGlobalFunction.PublicGlobalFunction.CloseProcessProgram("EXCEL");
                                            break;
                                        }
                                    }
                                    var file = PublicGlobalFunction.PublicGlobalFunction.ReturnNameLastFileTemp(pathTemp,"*.xml");
                                    dataBaseAdd.AddIndividualCardsUlFace(file.NamePath, inn);
                                    win = new WindowsAis3();
                                    AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                                    break;
                                }
                            }
                        }
                        break;
                    }
                    modelPost.IdTemplate = model.IdTemplate;
                    var result = post.ResultPost(serviceGetOrPost, modelPost);
                    if (result == null)
                    {
                        statusButton.Iswork = false;
                    }
                    libraryAutomation.IsEnableElements(model.TreeFilter);
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
        /// <param name="pathDownLoads">Путь сохранения банковских выписок</param>
        public void BankSpr(StatusButtonMethod statusButton, LibraryAutomations libraryAutomation, SrvToLoad model, string tree, string serviceGetOrPost, string pathDownLoads)
        {
            if (!libraryAutomation.IsEnableExpandTree(model.Tree)) return;
            DataBaseElementAdd dataBaseAdd = new DataBaseElementAdd();
            var post = new HttpGetAndPost();
            WindowsAis3 win;
            libraryAutomation.FindFirstElement(tree, null, true);
            libraryAutomation.FindElement.SetFocus();
            libraryAutomation.ClickElements(tree, null, false, 25, 0, 0, 2);
            foreach (var inn in model.INN)
            {
                if (statusButton.Iswork)
                {
                    var elementRadExpanderList = libraryAutomation
                        .SelectAutomationColrction(libraryAutomation.IsEnableElements(PreCheckElementNameBank.FullTaxpayerListControl))
                        .Cast<AutomationElement>().Where(elem => elem.Current.ClassName == "RadExpander").ToList();
                    var modelPost = new AisParsedData() {N134 = inn, Tree = model.Tree};
                    if (libraryAutomation.FindFirstElement(PreCheckElementNameBank.InputInn, null, true) != null)
                    {
                        libraryAutomation.SetValuePattern(inn);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation,PreCheckElementNameBank.PeriodSelect);
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation,PreCheckElementNameBank.FindButton);
                        libraryAutomation.IsEnableElementTrue(PreCheckElementNameBank.TaxpayersProgressBar1);
                        AutoItX.Sleep(1000);
                        if (libraryAutomation.IsEnableElements(PreCheckElementNameBank.SelectItem, elementRadExpanderList[0]) != null)
                        {
                            libraryAutomation.ClickElements(PreCheckElementNameBank.SelectItem,elementRadExpanderList[0]);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation,PreCheckElementNameBank.ViewReference);
                            libraryAutomation.IsEnableElementTrue(PreCheckElementNameBank.TaxpayersProgressBar2);
                            if (libraryAutomation.IsEnableElements(PreCheckElementNameBank.ElementSpr, elementRadExpanderList[1]) != null)
                            {
                                var listGr = libraryAutomation
                                    .SelectAutomationColrction(
                                        libraryAutomation.IsEnableElements(
                                            PreCheckElementNameBank.DownloadFileXlsxSave,
                                            elementRadExpanderList[1])).Cast<AutomationElement>()
                                    .Where(elem => elem.Current.ClassName == "RadDropDownButton").ToList();
                                var buttonList = libraryAutomation.SelectAutomationColrction(listGr[2]);
                                libraryAutomation.ClickElement(buttonList[1]);
                                SendWinSave(libraryAutomation, pathDownLoads);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ModelBookShopping.Save);
                                libraryAutomation.IsEnableElementTrue(PreCheckElementNameBank.TaxpayersProgressBar2);
                                var file = PublicGlobalFunction.PublicGlobalFunction.ReturnNameLastFileTemp(pathDownLoads, "*.xlsx");
                                while (PublicGlobalFunction.PublicGlobalFunction.IsFileLocked(file)) { }
                                libraryAutomation.IsEnableElementTrue(PreCheckElementNameBank.TaxpayersProgressBar2);
                                dataBaseAdd.AddCashBankAllUlFace(inn, file.NamePath, "Sheet1");
                                File.Delete(file.NamePath);
                            }
                            //Перейти к списку счетов/операций выбранного НП
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, PreCheckElementNameBank.GoOperations);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, PreCheckElementNameBank.AllCash);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, PreCheckElementNameBank.AllCashPeriod);
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, PreCheckElementNameBank.SelectCash);
                            libraryAutomation.IsEnableElementTrue(PreCheckElementNameBank.TaxpayersProgressBar3);
                            if (libraryAutomation.IsEnableElements(PreCheckElementNameBank.CashElementFind, null, true) != null)
                            {
                                 // Ищем и проверяем (Новая доработка 07.07.2022)
                                 while (true)
                                 {
                                    var listGrMemo = libraryAutomation
                                        .SelectAutomationColrction(
                                            libraryAutomation.IsEnableElements(
                                                PreCheckElementNameBank.PathCashAllParameter.TrimEnd(new char[] { '\\' })
                                            )).Cast<AutomationElement>()
                                        .Where(elem => elem.Current.ClassName == "RadComboBox").ToList();
                                    if (listGrMemo.Count <= 0) continue;
                                    libraryAutomation.ClickElement(listGrMemo[1]);
                                    //Поле со списком
                                    var memo = libraryAutomation.SelectAutomationColrction(listGrMemo[1]);
                                    var elemClick = memo.Cast<AutomationElement>().FirstOrDefault(x => x.Current.Name == "Информация по операциям");
                                    libraryAutomation.ClickElement(elemClick);
                                    break;
                                 }
                                 //Сформировать
                                 if (libraryAutomation.IsEnableElements(PreCheckElementNameBank.FormReport) != null)
                                 {
                                      PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, PreCheckElementNameBank.FormReport);
                                      if (libraryAutomation.IsEnableElements(PreCheckElementNameBank.WarningForm, null, true, 2) != null)
                                      {
                                           libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                                      }
                                      libraryAutomation.IsEnableElementTrue(PreCheckElementNameBank.TaxpayersProgressBar4);
                                      if (libraryAutomation.IsEnableElements(PreCheckElementNameBank.CounterpartyRowFind, null, true) != null)
                                      {
                                        //Экспорт и ждем завершения (Новая доработка 07.07.2022)
                                        while (true)
                                        {
                                              var listGrButton = libraryAutomation.SelectAutomationColrction(
                                                      libraryAutomation.IsEnableElements(
                                                          PreCheckElementNameBank.DownloadFileXlsxSaveCounterparty)).Cast<AutomationElement>()
                                                  .Where(elem => elem.Current.ClassName == "RadDropDownButton").ToList();
                                              if (listGrButton.Count <= 0) continue;
                                              var buttonList = libraryAutomation.SelectAutomationColrction(listGrButton[2]);
                                              libraryAutomation.ClickElement(buttonList[1]);
                                              break;
                                        }
                                        SendWinSave(libraryAutomation, pathDownLoads);
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ModelBookShopping.Save);
                                        libraryAutomation.IsEnableElementTrue(PreCheckElementNameBank.TaxpayersProgressBar4);
                                        var file = PublicGlobalFunction.PublicGlobalFunction.ReturnNameLastFileTemp(pathDownLoads,"*.xlsx");
                                        while (PublicGlobalFunction.PublicGlobalFunction.IsFileLocked(file)){ }
                                        libraryAutomation.IsEnableElementTrue(PreCheckElementNameBank.TaxpayersProgressBar4);
                                        dataBaseAdd.AddCashBankCounterparty(inn, file.NamePath, "Sheet1");
                                        File.Delete(file.NamePath);
                                      }
                                      win = new WindowsAis3();
                                      AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                                      AutoItX.Sleep(1000);
                                 }
                                 win = new WindowsAis3();
                                 AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                                 AutoItX.Sleep(1000); 
                            }
                        }
                    }
                    modelPost.IdTemplate = model.IdTemplate;
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
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20,win.WindowsAis.Y + 160);
        }
        /// <summary>
        /// Обработка ветки Налоговое администрирование\Контрольная работа (налоговые проверки)\101. Мониторинг и обработка документов\Реестр документов НБО
        /// Обработка ветки Налоговое администрирование\Контрольная работа (налоговые проверки)\124. Миграция НП в части КНП\1. Реестр документов НБО
        /// </summary>
        /// <param name="statusButton">Кнопка стоп</param>
        /// <param name="libraryAutomation">Библиотека</param>
        /// <param name="model">Модель Поля ИНН Ветка</param>
        /// <param name="tree">Веска для поиска</param>
        /// <param name="serviceGetOrPost">Адрес ответа с клиента</param>
        /// <param name="pathTemp">Путь к сохранению документа</param>
        /// <param name="yearReport">Отчетный год</param>
        public void DeclarationIntelligenceUl(StatusButtonMethod statusButton, LibraryAutomations libraryAutomation, SrvToLoad model, string tree, string serviceGetOrPost, string pathTemp, int yearReport)
        {
            if (!libraryAutomation.IsEnableExpandTree(model.Tree)) return;
            DataBaseElementAdd dataBaseAdd = new DataBaseElementAdd();
            var post = new HttpGetAndPost();
            WindowsAis3 win;
            var y1 = (yearReport - 1).ToString();
            var y2 = (yearReport - 2).ToString();
            var y3 = (yearReport - 3).ToString();
            libraryAutomation.FindFirstElement(tree, null, true);
            libraryAutomation.FindElement.SetFocus();
            libraryAutomation.ClickElements(tree, null, false, 25, 0, 0, 2);
            foreach (var inn in model.INN)
            {
                model.TreeDataArea.DataAreaParameters.First(parameters => parameters.NameParameters == "ИНН").ParametersGrid = inn;
                model.TreeDataArea.DataAreaParameters.First(parameters => parameters.NameParameters == "Отчетный год").ParametersGrid = y1+"/"+y2+"/"+y3;
                if (statusButton.Iswork)
                {
                    foreach (var dataAreaParameters in model.TreeDataArea.DataAreaParameters)
                    {
                        while (true)
                        {
                            if (libraryAutomation.FindFirstElement(string.Concat(model.TreeDataArea.FullPathDataArea, dataAreaParameters.IndexParameters), null, true) != null)
                            {
                                libraryAutomation.FindFirstElement(dataAreaParameters.FindNameMemo, libraryAutomation.FindElement, true);
                                libraryAutomation.FindElement.SetFocus();
                                SendKeys.SendWait("{ENTER}");
                                AutoItX.Sleep(500);
                                SendKeys.SendWait(dataAreaParameters.ParametersGrid);
                                break;
                            }
                        }
                    }
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, model.TreeUpdate);
                    PublicGlobalFunction.PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation, model.TreeGrid.FullPathGrid);
                    var declList = new[]
                    {
                        "Бухгалтерская (финансовая) отчетность",
                        "Налоговая декларация по налогу на прибыль организаций",
                        "Налоговая декларация по налогу на добавленную стоимость"
                    };
                    var controlYears = yearReport - 3;
                    if (PublicGlobalFunction.PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation, model.TreeGrid.FullPathGrid) != "Данные, удовлетворяющие заданным условиям не найдены.")
                    {
                        var allReport = libraryAutomation
                            .SelectAutomationColrction(libraryAutomation.IsEnableElements(model.TreeGrid.FullPathGrid))
                            .Cast<AutomationElement>().Where(elem => elem.Current.Name != "Data Area").Distinct()
                            .Where(doc =>
                                declList.Any(decl =>
                                    decl.Equals(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                        libraryAutomation.SelectAutomationColrction(doc).Cast<AutomationElement>()
                                            .First(elem => elem.Current.Name.Contains("Документ")))))
                                &&
                                Convert.ToInt32(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                    libraryAutomation.SelectAutomationColrction(doc).Cast<AutomationElement>()
                                        .First(elem => elem.Current.Name.Contains("Отчетный год")))) >= controlYears
                                &&
                                dataBaseAdd.DeclarationDataExists(Convert.ToInt64(
                                    libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                        libraryAutomation.SelectAutomationColrction(doc).Cast<AutomationElement>()
                                            .First(elem => elem.Current.Name.Contains("РегНомер"))))) == false
                            ).ToList();

                        foreach (var element in allReport)
                        {
                            var declarationUl = dataBaseAdd.AddDeclaration(libraryAutomation, element);
                            while (true)
                            {
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, PreCheckElementNameDeclaration.ReestrNbo);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, PreCheckElementNameDeclaration.ViewDeclaretion);
                                AutoItX.Sleep(10000);
                                if (libraryAutomation.IsEnableElements(model.TreeExport) != null)
                                {
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, model.TreeExport);
                                    break;
                                }
                            }
                            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, PreCheckElementNameDeclaration.ExportFileOk);
                            AutoItX.ProcessWait("EXCEL.EXE", 60000);
                            AutoItX.Sleep(Convert.ToInt32(ConfigurationManager.AppSettings["Sleepeng"]));
                            PublicGlobalFunction.PublicGlobalFunction.CloseProcessProgram("EXCEL");
                            var file = PublicGlobalFunction.PublicGlobalFunction.ReturnNameLastFileTemp(pathTemp, "*.xlsx");
                            dataBaseAdd.AddDeclarationData(file.NamePath, declarationUl, inn);
                            win = new WindowsAis3();
                            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                        }
                    }
                    var modelPost = new AisParsedData() {N134 = inn, Tree = model.Tree, IdTemplate = model.IdTemplate};
                    libraryAutomation.IsEnableElements(model.TreeFilter);
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
        /// <param name="statusButton">Кнопка стоп</param>
        /// <param name="libraryAutomation">Библиотека</param>
        /// <param name="model">Модель Поля ИНН Ветка</param>
        /// <param name="tree">Веска для поиска</param>
        /// <param name="serviceGetOrPost">Адрес ответа с клиента</param>
        /// <param name="pathTemp">Путь к сохранению документа</param>
        public void FindUlStatement(StatusButtonMethod statusButton, LibraryAutomations libraryAutomation, SrvToLoad model, string tree, string serviceGetOrPost, string pathTemp)
        {
            if (!libraryAutomation.IsEnableExpandTree(model.Tree)) return;
            DataBaseElementAdd dataBaseAdd = new DataBaseElementAdd();
            var post = new HttpGetAndPost();
            libraryAutomation.FindFirstElement(tree, null, true);
            libraryAutomation.FindElement.SetFocus();
            libraryAutomation.ClickElements(tree, null, false, 25, 0, 0, 2);
            foreach (var inn in model.INN)
            {
                model.TreeDataArea.DataAreaParameters.First(parameters => parameters.NameParameters == "ИНН").ParametersGrid = inn;
                if (statusButton.Iswork)
                {
                    foreach (var dataAreaParameters in model.TreeDataArea.DataAreaParameters)
                    {
                        while (true)
                        {
                            if (libraryAutomation.FindFirstElement(string.Concat(model.TreeDataArea.FullPathDataArea, dataAreaParameters.IndexParameters), null, true) != null)
                            {
                                libraryAutomation.FindFirstElement(dataAreaParameters.FindNameMemo, libraryAutomation.FindElement, true);
                                libraryAutomation.FindElement.SetFocus();
                                SendKeys.SendWait("{ENTER}");
                                AutoItX.Sleep(500);
                                SendKeys.SendWait(dataAreaParameters.ParametersGrid);
                                break;
                            }
                        }
                    }
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, model.TreeUpdate);
                    if (PublicGlobalFunction.PublicGlobalFunction.GridNotDataIsWaitUpdate(libraryAutomation, model.TreeGrid.FullPathGrid) != "Данные, удовлетворяющие заданным условиям не найдены.")
                    {
                        while (true)
                        {
                            try
                            {
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, PreCheckFindUl.PrintStatement);
                            }
                            catch
                            {
                                //ignore
                            }
                            AutoItX.Sleep(10000);
                            if (AutoItX.ProcessExists("WINWORD.EXE") > 0)
                            {
                                break;
                            }
                        }
                        AutoItX.ProcessWait("WINWORD.EXE", 60000);
                        PublicGlobalFunction.PublicGlobalFunction.KillProcessProgram("WINWORD");
                        var fileDelete = PublicGlobalFunction.PublicGlobalFunction.ReturnNameLastFileTemp(pathTemp, "~$*.rtf");
                        PublicGlobalFunction.PublicGlobalFunction.DeleteFile(fileDelete.NamePath);
                        var file = PublicGlobalFunction.PublicGlobalFunction.ReturnNameLastFileTemp(pathTemp, "*.rtf");
                        dataBaseAdd.AddDbStatement(file.NamePath, inn);
                    }
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, model.TreeFilter);
                    var modelPost = new AisParsedData() {N134 = inn, Tree = model.Tree, IdTemplate = model.IdTemplate };
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
            WindowsAis3 win = new WindowsAis3();
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
        }
        /// <summary>
        /// Книга покупок продажи по НДС для мониторинга организации
        /// </summary>
        /// <param name="statusButton">Кнопка стоп</param>
        /// <param name="libraryAutomation">Библиотека</param>
        /// <param name="model">Модель Поля ИНН Ветка</param>
        /// <param name="tree">Веска для поиска</param>
        /// <param name="serviceGetOrPost">Адрес ответа с клиента</param>
        /// <param name="pathDownLoads">Путь к сохранению документа</param>
        public void ShoppingSaleBook(StatusButtonMethod statusButton, LibraryAutomations libraryAutomation, SrvToLoad model, string tree, string serviceGetOrPost, string pathDownLoads)
        {
            if (!libraryAutomation.IsEnableExpandTree(model.Tree)) return;
            DataBaseElementAdd dataBaseAdd = new DataBaseElementAdd();
            var post = new HttpGetAndPost();
            libraryAutomation.FindFirstElement(tree, null, true);
            libraryAutomation.FindElement.SetFocus();
            libraryAutomation.ClickElements(tree, null, false, 25, 0, 0, 2);
            foreach (var inn in model.INN)
            {
                if (statusButton.Iswork)
                {
                    while (true)
                    {
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ModelBookShopping.ResetFilter);
                        if (libraryAutomation.FindFirstElement(ModelBookShopping.AllBook, null, true) != null)
                        {
                            libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                            break;
                        }
                    }
                    if(libraryAutomation.IsEnableElements(ModelBookShopping.Loading, null, true) != null)
                    {
                        libraryAutomation.IsEnableElementTrue(ModelBookShopping.Loading, null, true);
                        AutoIt.AutoItX.Sleep(2000);
                    }
                    model.TreeDataArea.DataAreaParameters.First(parameters => parameters.NameParameters == "ИНН").ParametersGrid = inn;
                    while (true)
                    {

                        if (libraryAutomation.IsEnableElements(model.TreeFilter, null, true) != null)
                        {
                            foreach (var dataAreaParameters in model.TreeDataArea.DataAreaParameters)
                            {
                                while (true)
                                {
                                    if (libraryAutomation.FindFirstElement(string.Concat(model.TreeDataArea.FullPathDataArea, dataAreaParameters.IndexParameters), null, true) != null)
                                    {
                                        libraryAutomation.FindFirstElement(dataAreaParameters.FindNameMemo, libraryAutomation.FindElement, true);
                                        libraryAutomation.SetValuePattern(dataAreaParameters.ParametersGrid);
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ModelBookShopping.WinOk);
                                        if (libraryAutomation.IsEnableElements(ModelBookShopping.Loading, null, true) != null)
                                        {
                                            libraryAutomation.IsEnableElementTrue(ModelBookShopping.Loading, null, true);
                                        }
                                        break;
                                    }
                                    if (libraryAutomation.IsEnableElements(model.TreeFilter, null, true) != null)
                                    {
                                        libraryAutomation.ClickElement(libraryAutomation.FindElement, 50);
                                        SendKeys.SendWait(ButtonConstant.Down2);
                                        SendKeys.SendWait(ButtonConstant.Right1);
                                        SendKeys.SendWait(ButtonConstant.Enter);
                                    }
                                    AutoItX.Sleep(5000);
                                }
                            }
                            break;
                        }
                    }
                    if (libraryAutomation.IsEnableElements(model.TreeGrid.GridToIndexParameter, null, true, 10) != null)
                    {
                           var j = 1;
                           AutomationElement automationElement;
                           while ((automationElement = libraryAutomation.IsEnableElements(string.Concat(model.TreeGrid.FullPathGrid, "\\Name:DeclarationBrief row ", j, "\\Name:ИНН"), null, false)) != null)
                           {
                            automationElement = libraryAutomation.IsEnableElements(string.Concat(model.TreeGrid.FullPathGrid, "\\Name:DeclarationBrief row ", j), null, false);
                            if (dataBaseAdd.BookExists(Convert.ToInt64(dataBaseAdd.ParseAndCreateRegNumberBook(libraryAutomation, automationElement, inn))) == false)
                            {
                                var book = dataBaseAdd.AddBook(libraryAutomation, automationElement, inn);
                                if (book != null)
                                {
                                    if (!book.IsBookSalesParse & (libraryAutomation.IsEnableElements(ModelBookShopping.Section8, null, false, 1) != null))
                                    {
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ModelBookShopping.Section8);
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, string.Format(model.TreeExport, 8, 8));
                                        SendWinSave(libraryAutomation, pathDownLoads);
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ModelBookShopping.Save);
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ModelBookShopping.ExportXlsx);
                                        PublicGlobalFunction.PublicGlobalFunction.ExcelSaveAndClose();
                                        var file = PublicGlobalFunction.PublicGlobalFunction.ReturnNameLastFileTemp(pathDownLoads, $"{inn}*.xlsx");
                                        dataBaseAdd.AddBookSales(ref book, file.NamePath, "Раздел_8(1)");
                                        PublicGlobalFunction.PublicGlobalFunction.DeleteFile(file.NamePath);
                                    }
                                    else
                                    {
                                        dataBaseAdd.UpdeteBookSalesParse(ref book);
                                    }
                                    if (!book.IsBookPurchase & (libraryAutomation.IsEnableElements(ModelBookShopping.Section9, null, false, 1) != null))
                                    {
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ModelBookShopping.Section9);
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, string.Format(model.TreeExport, 9, 9));
                                        SendWinSave(libraryAutomation, pathDownLoads);
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ModelBookShopping.Save);
                                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ModelBookShopping.ExportXlsx);
                                        PublicGlobalFunction.PublicGlobalFunction.ExcelSaveAndClose();
                                        var file = PublicGlobalFunction.PublicGlobalFunction.ReturnNameLastFileTemp(pathDownLoads, $"{inn}*.xlsx");
                                        dataBaseAdd.AddBookPurchase(ref book, file.NamePath, "Раздел_9(1)");
                                        PublicGlobalFunction.PublicGlobalFunction.DeleteFile(file.NamePath);
                                        //Делаем таблицу закидываем в бд IsBookPurchase ==true
                                    }
                                    else
                                    {
                                        dataBaseAdd.UpdeteBookPurchase(ref book);
                                    }
                                    WindowsAis3 win = new WindowsAis3();
                                    AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                                }
                            }
                            j++;
                           }
                    }
                    var modelPost = new AisParsedData() { N134 = inn, Tree = model.Tree, IdTemplate = model.IdTemplate };
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
            WindowsAis3 winExit = new WindowsAis3();
            AutoItX.MouseClick(ButtonConstant.MouseLeft, winExit.WindowsAis.X + winExit.WindowsAis.Width - 20, winExit.WindowsAis.Y + 160);
        }

        /// <summary>
        /// Функция сохранения вроде работает
        /// </summary>
        /// <param name="libraryAutomation"></param>
        /// <param name="pathSave"></param>
        private void SendWinSave(LibraryAutomations libraryAutomation, string pathSave)
        {
            if (libraryAutomation.IsEnableElements("Name:Сохранение\\ClassName:ReBarWindow32", null, false, 3) != null)
            {
                if (libraryAutomation.IsEnableElements("ClassName:Address Band Root\\ClassName:msctls_progress32\\ClassName:Breadcrumb Parent\\ClassName:ToolbarWindow32", libraryAutomation.FindFirstElement("Name:Сохранение\\ClassName:ReBarWindow32"), true) != null)
                {
                    libraryAutomation.ClickElement(libraryAutomation.FindElement);
                    var listGrMemo = libraryAutomation.SelectAutomationColrction(libraryAutomation.IsEnableElements("ClassName:Address Band Root\\ClassName:msctls_progress32", 
                        libraryAutomation.FindFirstElement("Name:Сохранение\\ClassName:ReBarWindow32"), true)).Cast<AutomationElement>().FirstOrDefault(elem => elem.Current.ClassName == "ComboBox");
                    libraryAutomation.IsEnableElements("ClassName:Edit", listGrMemo);
                    libraryAutomation.SetValuePattern(pathSave);
                    AutoItX.Send(ButtonConstant.Enter);
                }
            }
        }
   }
}
