using System;
using System.Collections.Generic;
using System.Linq;
using EfDatabaseAutomation.Automation.Base;
using EfDatabaseAutomation.Automation.BaseLogica.AutoLogicInventory;
using EfDatabaseAutomation.Automation.BaseLogica.SelectObjectDbAndAddObjectDb;
using LibraryAIS3Windows.AutomationsUI.LibaryAutomations;
using LibraryAIS3Windows.AutomationsUI.PublicElement;
using LibraryAIS3Windows.Window;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using LibraryAIS3Windows.AutomationsUI.Otdels.Registration;
using AutoIt;
using LibraryAIS3Windows.ButtonsClikcs;
using System.Windows.Automation;
using System.Windows.Forms;
using AisPoco.UserLoginScan;
using EfDatabaseAutomation.BaseLogica.AutoLogicInventory;
using ViewModelLib.ModelTestAutoit.PublicModel.PublicModelCollectionSelect;
using DocumentInventory = EfDatabaseAutomation.Automation.Base.DocumentInventory;
using GrnInventory = EfDatabaseAutomation.Automation.Base.GrnInventory;


namespace LibraryAIS3Windows.ButtonFullFunction.RegistrationFunction
{
    public class ScanDocument
    {
        /// <summary>
        /// Ветка Налоговое администрирование\Централизованный учет налогоплательщиков\18. Действия к выполнению\2.09. Ручная идентификация физического лица
        /// </summary>
        private string TreeScanDocumentsStartProcess = "Налоговое администрирование\\Централизованная система регистрации\\Электронный архив\\Запросить электронные образы документов дела из архива(преобразование)";
        /// <summary>
        /// Относительный путь к системе ретро-сканирования
        /// </summary>
        private string TreeUseTask = "Общие задания\\Централизованная система регистрации\\Электронный архив\\Ретросканирование";
        /// <summary>
        /// Ветка комплектования тары
        /// </summary>
        private string TreeContainer = "Налоговое администрирование\\Документооборот\\Передача документов\\Комплектование тары";
        /// <summary>
        /// Метод автоматизации ретро-сканирования
        /// </summary>
        /// <param name="statusButton">Кнопка старт автомат</param>
        /// <param name="modelUser">Модель пользователей</param>
        public void StartScanDocument(StatusButtonMethod statusButton, PublicModelCollectionSelect<UserLoginDatabaseModel> modelUser)
        {
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            var inventoryLogicSelect = new InventoryLogic();
            var selectUser = modelUser.ModelCollection.Where(x => modelUser.SelectModelCollection.Contains(x.IdUser)).Select(user => user.UserLogin).ToArray();
            var modelDocument = inventoryLogicSelect.SelectStartProcessInventory(selectUser);
            if (modelDocument?.TemplateOgrn != null) {
                foreach (var organizationOgrnInventory in modelDocument.TemplateOgrn)
                {
                    var findGroup = organizationOgrnInventory.GrnInventory.GroupBy(grn => grn.NumberOgrnGrn)
                        .Select(grp => new {Country = grp.Key, Count = grp.Select(x => x.NumberOgrnGrn).Count()}).FirstOrDefault(x => x.Count > 1);
                    if (findGroup != null)
                    {
                        MessageBox.Show("В модуле содержатся дубли ГРН запуск не возможен! Отредактируйте ГРН!!!");
                        break;
                    }
                    if (statusButton.Iswork)
                    {
                        switch (organizationOgrnInventory.IdStatus)
                        {
                            //Создаем процесс и обрабатываем его в дальнейшем case
                            case 1:
                                StartProcessInventory(libraryAutomation, organizationOgrnInventory);
                                AnalysisProcess(libraryAutomation, organizationOgrnInventory);
                                break;
                            //Только обрабатываем процесс в заданиях
                            case 2:
                                AnalysisProcess(libraryAutomation, organizationOgrnInventory);
                                break;
                            //Возвращаем статус 2 Мне кажется код избыточный так как работаем по процессам и откатываем в процедуре
                            case 3:
                                BreakStatus(organizationOgrnInventory, 2);
                                break;
                            //Возвращаем статус 1 Мне кажется код избыточный так как работаем по процессам и откатываем в процедуре 
                            case 4:
                                BreakStatus(organizationOgrnInventory, 1);
                                break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Процесс по комплектованию тары
        /// Налоговое администрирование\Документооборот\Передача документов\Комплектование тары
        /// </summary>
        /// <param name="statusButton">Кнопка старт автомат</param>
        public void ScanAddContainer(StatusButtonMethod statusButton)
        {
            LibraryAutomations libraryAutomation = new LibraryAutomations(WindowsAis3.AisNalog3);
            var inventoryLogicSelect = new InventoryLogic();
            var container = inventoryLogicSelect.SelectFirstDocumentContainer();
            var documentInventory = inventoryLogicSelect.SelectAllDocumentInventory();
            var sum = documentInventory.Select(x => x.CountPage).Sum();
            if (sum < 500)
            {
                MessageBox.Show("Нет нужного количества документов Всего: " + sum);
                return;
            }
            if (container != null && documentInventory.Length > 0) //Условие должно быть что положить и куда положить одно без другого не может 
            {
                var sw = TreeContainer.Split('\\').Last();
                var fullTree = string.Concat(PublicElementName.FullTree, $"Name:{sw}");
                libraryAutomation.IsEnableExpandTree(TreeContainer);
                if (libraryAutomation.IsEnableElement(InventoryName.ContanerAdd))
                {
                    libraryAutomation.InvokePattern(libraryAutomation.IsEnableElements(InventoryName.ContanerAdd));
                    if (libraryAutomation.IsEnableElements(InventoryName.AddTextContaner) != null)
                    {
                        libraryAutomation.SetValuePattern(container.BarcodeContainer);
                        SendKeys.SendWait(ButtonConstant.Enter);
                        AutoItX.Sleep(1000);
                        SendKeys.SendWait(" ");
                    }
                    var countPageSum = container.CountCurrent;
                    var counterModel = 0;
                    foreach (var inventory in documentInventory)
                    {
                       
                        if (countPageSum + inventory.CountPage <= container.CountDocumentMin || countPageSum + inventory.CountPage <= container.CountDocumentMax)
                        {
                            while (true)
                            {
                                libraryAutomation.InvokePattern(libraryAutomation.IsEnableElements(InventoryName.AddBarcode));
                                if (libraryAutomation.IsEnableElement(InventoryName.AddTextBarcode)) //Если AIS зависает то документ не ложится только следующий за ним проблемная тара 1770006700561 как образец есть вариант заменить эту строку "if (libraryAutomation.IsEnableElements(InventoryName.AddTextBarcode) != null)"  на  "if(libraryAutomation.IsEnableElement(InventoryName.AddTextBarcode))" бесконечное ожидание элемента
                                {
                                    SendKeys.SendWait("");
                                    libraryAutomation.SetValuePattern(inventory.GuidDocument);
                                    AutoItX.Sleep(1000);
                                    SendKeys.SendWait(ButtonConstant.Enter);
                                    AutoItX.Sleep(500);
                                }
                                if (libraryAutomation.IsEnableElements(InventoryName.WinWarning, null, false, 5) != null)
                                {
                                    libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                                }
                                else
                                {
                                    break;
                                }
                            }
                            inventory.IdStatusDocument = 4;
                            countPageSum += inventory.CountPage;
                            container.CountCurrent = countPageSum;
                            counterModel += 1;
                            AddAndEditDocumentInventoryContainer(inventory);
                            UpdateDocumentContainer(container);
                            AddAddDocumentToContainer(container.IdContainer, inventory.IdDocument, counterModel);
                            if (countPageSum >= container.CountDocumentMin)
                            {
                                //Сохранение и печать реестра
                                container.IsFinishContainer = true;
                                UpdateDocumentContainer(container);
                                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, InventoryName.Save);
                                MouseCloseForm(1);
                                return;
                            }
                            
                        }
                    }
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, InventoryName.Save);
                    MouseCloseForm(1);
                    //Сохранение и выход ждем 2 прогона
                }
            }
        }

        /// <summary>
        /// Запускаем процесс если признак IdStatus = 1
        /// </summary>
        /// <param name="libraryAutomation">Библиотека автоматизации</param>
        /// <param name="organizationOgrnInventory">ОГРН документ</param>
        private void StartProcessInventory(LibraryAutomations libraryAutomation, TemplateOgrn organizationOgrnInventory)
        {
            libraryAutomation.GarantInvokePattern(InventoryName.TaskAll);
            var sw = TreeScanDocumentsStartProcess.Split('\\').Last();
            var fullTree = string.Concat(PublicElementName.FullTree, $"Name:{sw}");
            libraryAutomation.IsEnableExpandTree(TreeScanDocumentsStartProcess);
            while (true)
            {
                if (libraryAutomation.IsEnableElements(InventoryName.SendValueOgrn) != null)
                {
                    libraryAutomation.SetValuePattern(organizationOgrnInventory.NumberOgrn.ToString());
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, InventoryName.SendButonOgrn);
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, InventoryName.OgrnOk);
                    break;
                }
            }
               
            //Автоматизация создания процесса
            organizationOgrnInventory.IdStatus = 2;
            UpdateOrganizationOgrnInventory(organizationOgrnInventory);
            MouseCloseForm(1);
        }

        /// <summary>
        /// Запуск задания для анализа процесса!
        /// </summary>
        /// <param name="libraryAutomation">Библиотека автоматизации</param>
        /// <param name="organizationOgrnInventory">ОГРН документ</param>
        private void AnalysisProcess(LibraryAutomations libraryAutomation, TemplateOgrn organizationOgrnInventory)
        {
            var countUpdate = 0;
            var isError = false;
            var fullKey = organizationOgrnInventory.GrnInventory.OrderBy(x => x.IdDocGrn).Select(x => x.NumberOgrnGrn.ToString()).Aggregate((element, next) => element.ToString() + (string.IsNullOrWhiteSpace(element.ToString()) ? string.Empty : ", ") + next.ToString()).Trim();
            AddAndUpdateEventErrorIsError(fullKey, 3, organizationOgrnInventory.GrnInventory);
            libraryAutomation.GarantInvokePattern(InventoryName.TaskUser); //Гарантированно открыть пользовательские задания
            libraryAutomation.GarantInvokePattern(InventoryName.ButtonShow); //Свернуть все для поиска нужной ветки
            libraryAutomation.IsEnableExpandTreeTaskUsers(TreeUseTask);
            while (true) //Фильтрация
            {
                libraryAutomation.GarantInvokePattern(InventoryName.ButtonUpdate); //Обновить задания
                libraryAutomation.IsEnableElement(PublicElementName.FullTreeTaskUser); //Ждем доступность Tree
                if (libraryAutomation.IsEnableElements(string.Concat(InventoryName.TableTaskRow1, 1), null, true) != null)
                {
                    libraryAutomation.SelectAutomationColrction(libraryAutomation.FindElement)
                             .Cast<AutomationElement>()
                             .First(elem => elem.Current.Name.Contains("ОГРН/ОГРНИП")).SetFocus();
                    AutoItX.Send(string.Format(ButtonConstant.UpCountClick, 1));
                    if (libraryAutomation.IsEnableElements(string.Concat(InventoryName.TableTask, "\\Name:ОГРН/ОГРНИП"), null, true) != null)
                    {
                        libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                        if (libraryAutomation.IsEnableElements(string.Concat(InventoryName.TableTask, "\\LocalizedControlType:поле"), null, true) != null)
                        {
                            libraryAutomation.SetValuePattern(organizationOgrnInventory.NumberOgrn.ToString());
                            break;
                        }
                    }
                }
                if (countUpdate >= 5)
                {
                    return;
                }
                countUpdate++;
            }
            AutomationElement automationElement;
            while ((automationElement = libraryAutomation.IsEnableElements(InventoryName.TableTaskRow, null, true, 5)) != null)
            {
                var reportGrn = libraryAutomation.SelectAutomationColrction(libraryAutomation.IsEnableElements(InventoryName.TableTaskRow))
                          .Cast<AutomationElement>().Where(elem => elem.Current.Name.Contains("user_operation row")).Distinct();
                if (reportGrn.Count() <= 0)
                {
                    break;
                }
                libraryAutomation.SelectStateLegacyIAccessiblePatternIdentifiersState(reportGrn.FirstOrDefault(), 0x200042);
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, PublicElementName.StartUser);
                foreach(var grn in organizationOgrnInventory.GrnInventory)
                {
                    if (libraryAutomation.IsEnableElement(InventoryName.ComboBoxListGrnMemo))
                    {
                        libraryAutomation.SetValuePattern(string.Empty);
                    }
                    if (libraryAutomation.IsEnableElement(InventoryName.ComboBoxListGrnMemo))
                    {
                        SendKeys.SendWait(grn.NumberOgrnGrn.ToString());
                        AutoItX.Sleep(1000);
                        SendKeys.SendWait(ButtonConstant.Down1);
                        var valueText = libraryAutomation.ParseValuePattern(libraryAutomation.FindElement);
                        if (valueText.Contains(grn.NumberOgrnGrn.ToString()))
                        {
                            grn.IdGrnAis3 = AddAndUpdateAisGrnDocument(valueText, grn.NumberOgrnGrn);
                            grn.IsFindGrnDataBase = true;
                            UpdateGrnInventory(grn);
                            if (libraryAutomation.IsEnableElements(InventoryName.PanelListDocument, null, true, 5) != null)
                            {
                                var listAisDocument = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindElement).Cast<AutomationElement>().Where(doc=>doc.Current.AutomationId!= "NonClientVerticalScrollBar");
                                foreach(AutomationElement document in listAisDocument)
                                {
                                    libraryAutomation.InvokePattern(document);
                                    var newAisDocument = ParseAisDocument(libraryAutomation); //Возможно при сохранении сохраняются GUID и тогда если они есть то пропускаем его!!!
                                    newAisDocument.IdGrnAis3 = grn.IdGrnAis3;
                                    var firstUserDocument = grn.DocumentInventory.FirstOrDefault(doc => doc.DirectoryDocument.NameDocumentDataBase == newAisDocument.DirectoryDocument.NameDocumentDataBase);
                                        
                                    if (firstUserDocument != null)  //Если совпало синхронизируем от пользователя
                                    {
                                        grn.DocumentInventory.Remove(firstUserDocument);
                                        if (firstUserDocument.DirectoryDocument.NameDocumentDataBase == "Иной докум. в соотв.с законодательством РФ")
                                        {
                                            AddNameDocument(libraryAutomation, firstUserDocument);
                                        }
                                        AddCountPage(libraryAutomation, firstUserDocument.CountPage);
                                        PrintCode(libraryAutomation);
                                        var guid = ParseAisDocumentGuid(libraryAutomation).ToLower();
                                        firstUserDocument.GuidDocument = guid;
                                        firstUserDocument.IdStatusDocument = 3;
                                        firstUserDocument.StateDocument = true;
                                        newAisDocument.GuidDocument = guid;
                                        newAisDocument.IsFinndRegDelo = true;
                                        var idDoc = AddAndUpdateAisDocument(newAisDocument);
                                        AddAndEditDocumentInventory(firstUserDocument);
                                        AddAndUpdateSynchronization(grn.IdDocGrn, firstUserDocument.IdDocument, idDoc);
                                    }
                                    else //В противном случае не совпало ставим одну страницу и галочку "Не найдено в Регистрационном деле"
                                    {
                                        AddCountPage(libraryAutomation, 1); //Вопрос??? Ставим одну страницу
                                        if (libraryAutomation.IsEnableElements(InventoryName.CheckNotFound) != null)
                                        {
                                            libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                                        }
                                        //Нужен запрос который будет проверять есть ли запись в синхронизации элемент догрузки документа
                                        if (!IsVisualAisDocument(newAisDocument))
                                        {
                                            var idDoc = AddAndUpdateAisDocument(newAisDocument);
                                            AddAndUpdateSynchronization(grn.IdDocGrn, null, idDoc, false, true);
                                        }
                                    }
                                }
                                foreach(var documentUser in grn.DocumentInventory)
                                {
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, InventoryName.AddList);
                                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, InventoryName.ErrorAdd);
                                    if (libraryAutomation.IsEnableElements(InventoryName.PanelListDocument, null, true, 5) != null)
                                    {
                                        var listAisDocumentAdd = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindElement);
                                        var lastDocumentAdd = listAisDocumentAdd[listAisDocumentAdd.Count - 1];
                                        libraryAutomation.InvokePattern(lastDocumentAdd);
                                        AddNewDocument(libraryAutomation, documentUser);
                                        PrintCode(libraryAutomation);
                                        var guid = ParseAisDocumentGuid(libraryAutomation).ToLower();
                                        var isErrorParse = ParseAisDocumentNameDocumentDataBase(libraryAutomation); //Пар-сим документ если ошибка проставляем в справочники ставим 4
                                        if (documentUser.DirectoryDocument.NameDocumentDataBase != isErrorParse)
                                        {
                                            isError = true;
                                            documentUser.GuidDocument = "Ошибка не правильно выбрано в справочнике АИС 3";
                                            documentUser.IdStatusDocument = 5;
                                            documentUser.StateDocument = false;
                                            grn.NameDocument = "Ошибка в Деле ГРН";
                                            UpdateGrnInventory(grn);
                                        }
                                        else
                                        {
                                            documentUser.GuidDocument = guid;
                                            documentUser.IdStatusDocument = 3;
                                            documentUser.StateDocument = true;
                                        }
                                        AddAndEditDocumentInventory(documentUser);
                                        AddAndUpdateSynchronization(grn.IdDocGrn, documentUser.IdDocument, null, true);
                                    }
                                }
                                //PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, InventoryName.SaveDoc);
                                //Сохранение!!! 
                                grn.StatusFinish = true;
                                UpdateGrnInventory(grn);
                            }
                        }
                        else
                        {
                            if (libraryAutomation.IsEnableElements(InventoryName.PanelListDocument, null, true, 5) != null)
                            {
                                grn.IsFindGrnDataBase = false;
                                UpdateGrnInventory(grn);
                                var listAisDocument = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindElement).Cast<AutomationElement>().Where(doc => doc.Current.AutomationId != "NonClientVerticalScrollBar");
                                foreach (AutomationElement document in listAisDocument)
                                {
                                    libraryAutomation.InvokePattern(document);
                                    AddCountPageIsNotGrn(libraryAutomation, 1); //В случае не нахождения ставим 1 страницу
                                }
                            }
                            //PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, InventoryName.Closed);
                            //Документ не найден либо дубликаты записи!!!
                        }
                    }
                }
                //Блок принятия решения если в документе есть ошибка то мы присваиваем процессу ошибок в противном случае завершаем без ошибки 
                AddAndUpdateEventErrorIsError(fullKey, isError ? 1 : 2, organizationOgrnInventory.GrnInventory);
                PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, InventoryName.SaveDoc);
                //Сохранение!!! 
                //Либо здесь сохранение когда все ГРН пройдены
                organizationOgrnInventory.IdStatus = 4;
                UpdateOrganizationOgrnInventory(organizationOgrnInventory);
                return;
            }
            organizationOgrnInventory.IdStatus = 3;
            UpdateOrganizationOgrnInventory(organizationOgrnInventory);
            MouseCloseForm(1);
        }

        /// <summary>
        /// Добавление нового документа
        /// </summary>
        /// <param name="libraryAutomation">Библиотека автоматизации</param>
        /// <param name="documentInventory">Пользовательский документ</param>
        private void AddNewDocument(LibraryAutomations libraryAutomation, EfDatabaseAutomation.BaseLogica.AutoLogicInventory.DocumentInventory documentInventory)
        {
            AddNameDocument(libraryAutomation, documentInventory);
            if (libraryAutomation.IsEnableElements(InventoryName.VidDocument) != null)
            {
                libraryAutomation.SetLegacyIAccessibleValuePattern(documentInventory.DirectoryDocument.NameDocumentDataBase);
            }
            AddCountPage(libraryAutomation, documentInventory.CountPage);
        }
        /// <summary>
        /// Добавить вид документа
        /// </summary>
        /// <param name="libraryAutomation">Библиотека автоматизации</param>
        /// <param name="documentInventory">Пользовательский документ</param>
        private void AddNameDocument(LibraryAutomations libraryAutomation, EfDatabaseAutomation.BaseLogica.AutoLogicInventory.DocumentInventory documentInventory)
        {
            if (libraryAutomation.IsEnableElements(InventoryName.NameDocument) != null)
            {
                libraryAutomation.SetLegacyIAccessibleValuePattern(documentInventory.InfoDocument.NameDocumentInfo);
            }
        }

        /// <summary>
        /// Проставить количество листов
        /// </summary>
        /// <param name="libraryAutomation">Библиотека автоматизации</param>
        /// <param name="countPage">Количество листов</param>
        private void AddCountPage(LibraryAutomations libraryAutomation, int countPage)
        {
            if (libraryAutomation.IsEnableElements(InventoryName.CountPageAdd) != null)
            {
                
                libraryAutomation.SetLegacyIAccessibleValuePattern(countPage.ToString());
            }
        }

        /// <summary>
        /// Проставить количество листов
        /// </summary>
        /// <param name="libraryAutomation">Библиотека автоматизации</param>
        /// <param name="countPage">Количество листов</param>
        private void AddCountPageIsNotGrn(LibraryAutomations libraryAutomation, int countPage)
        {
            if (libraryAutomation.IsEnableElements(InventoryName.CountPageAdd) != null)
            {
                var countPageAis3 = libraryAutomation.ParseValuePattern(libraryAutomation.FindElement);
                if (string.IsNullOrWhiteSpace(countPageAis3))
                {
                    libraryAutomation.SetLegacyIAccessibleValuePattern(countPage.ToString());
                }
            }
        }

        /// <summary>
        /// Пар сер документа 
        /// </summary>
        /// <param name="libraryAutomation">Библиотека автоматизации</param>
        /// <returns></returns>
        private AisDocument ParseAisDocument(LibraryAutomations libraryAutomation)
        {
            var aisDocument = new AisDocument
            {
                DirectoryDocument = new EfDatabaseAutomation.Automation.Base.DirectoryDocument()
                {
                    NameDocumentDataBase = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(InventoryName.VidDocument))
                },
                SmallNameDocument = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(InventoryName.NameDocument)),
                NumberDocument = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(InventoryName.NumberDocument)),
                DateDocument = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(InventoryName.DateDocument)),
                GuidDocument = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(InventoryName.GuidPanel))
            };
            var countPage = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(InventoryName.CountPage));
            aisDocument.CountPage = string.IsNullOrWhiteSpace(countPage) ? 1 : Convert.ToInt32(countPage);
            return aisDocument;
        }
        /// <summary>
        /// Печать этикетки присвоение GUID
        /// </summary>
        /// <param name="libraryAutomation">Библиотека автоматизации</param>
        /// <returns></returns>
        private void PrintCode(LibraryAutomations libraryAutomation)
        {
            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, InventoryName.PrintCode);
            while(true)
            {
                AutoItX.Sleep(1000);
                var libraryAutomationDialogPrevious = new LibraryAutomations(TreeWalker.RawViewWalker.GetPreviousSibling(libraryAutomation.RootAutomationElements));
                if (libraryAutomationDialogPrevious.IsEnableElement(InventoryName.CklosedPrint))
                {
                    PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomationDialogPrevious, InventoryName.CklosedPrint);
                    AutoItX.Sleep(2000); //Опасный участок надо проверить 
                    libraryAutomationDialogPrevious = new LibraryAutomations(TreeWalker.RawViewWalker.GetPreviousSibling(libraryAutomation.RootAutomationElements));
                    if (libraryAutomationDialogPrevious.IsEnableElements(InventoryName.OkClosed)!=null)
                    {
                        PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomationDialogPrevious, InventoryName.OkClosed);
                    }
                    break;
                }
            }
        }
        /// <summary>
        /// В случае ошибки вернуть NULL
        /// </summary>
        /// <param name="libraryAutomation">Библиотека автоматизации</param>
        /// <returns></returns>
        private string ParseAisDocumentNameDocumentDataBase(LibraryAutomations libraryAutomation)
        {
            var stringVidDoc = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(InventoryName.VidDocument));
            return stringVidDoc;
        }

        /// <summary>
        /// Пар сер GUID документа 
        /// </summary>
        /// <param name="libraryAutomation">Библиотека автоматизации</param>
        /// <returns></returns>
        private string ParseAisDocumentGuid(LibraryAutomations libraryAutomation)
        {
            var stringGuid = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(InventoryName.GuidPanel));
            return stringGuid;
        }

        /// <summary>
        /// Возврат статуса на процесс не создан!!!!
        /// </summary>
        /// <param name="organizationOgrnInventory">ОГРН документ</param>
        /// <param name="idStatus">Ун статуса процесса</param>
        private void BreakStatus(TemplateOgrn organizationOgrnInventory, int idStatus)
        {
            organizationOgrnInventory.IdStatus = idStatus;
            UpdateOrganizationOgrnInventory(organizationOgrnInventory);
        }


        /// <summary>
        /// Обновление статуса OrganizationOgrnInventory
        /// </summary>
        /// <param name="organizationOgrnInventory">ОГРН документ</param>
        private void UpdateOrganizationOgrnInventory(TemplateOgrn organizationOgrnInventory)
        {
            var saveAndUpdateInventory = new AddAllObjectDb();
            var organization = new OrganizationOgrnInventory()
            {
                IdOgrn = organizationOgrnInventory.IdOgrn,
                UserLogin = organizationOgrnInventory.UserLogin,
                NumberOgrn = organizationOgrnInventory.NumberOgrn,
                IdStatus = organizationOgrnInventory.IdStatus
            };
            saveAndUpdateInventory.AddAndEditOrganizationOgrnInventory(organization);
        }

        /// <summary>
        /// Обновление статуса GrnInventory
        /// </summary>
        /// <param name="grnInventory">ОГРН документ</param>
        private void UpdateGrnInventory(EfDatabaseAutomation.BaseLogica.AutoLogicInventory.GrnInventory grnInventory)
        {
            var grnInventorDataBase = new GrnInventory()
            {
                IdDocGrn = grnInventory.IdDocGrn,
                IdGrnAis3 = grnInventory.IdGrnAis3,
                IdOgrn = grnInventory.IdOgrn,
                NumberOgrnGrn = grnInventory.NumberOgrnGrn,
                NameDocument = grnInventory.NameDocument,
                IsStartProcess = grnInventory.IsStartProcess,
                IsFindGrnDataBase = grnInventory.IsFindGrnDataBase,
                StatusFinish = grnInventory.StatusFinish
            };
            var saveAndUpdateInventory = new AddAllObjectDb();
            saveAndUpdateInventory.AddAndEditGrnInventory(grnInventorDataBase);
        }
        /// <summary>
        /// Сохранение или обновление сведение об инвентаризированном документе
        /// </summary>
        /// <param name="documentInventory">Документ пользовательской инвентаризации</param>
        private void AddAndEditDocumentInventory(EfDatabaseAutomation.BaseLogica.AutoLogicInventory.DocumentInventory documentInventory)
        {
            var documentInventoryDataBase = new DocumentInventory()
            {
                IdDocument = documentInventory.IdDocument,
                IdDocGrn = documentInventory.IdDocGrn,
                IdDocumentDirectory = documentInventory.IdDocumentDirectory,
                IdInfo = documentInventory.IdInfo,
                CountPage = documentInventory.CountPage,
                GuidDocument = documentInventory.GuidDocument,
                StateDocument = documentInventory.StateDocument,
                IdStatusDocument = documentInventory.IdStatusDocument
            };
            var saveAndUpdateInventory = new AddAllObjectDb();
            saveAndUpdateInventory.AddAndEditDocumentInventory(documentInventoryDataBase);
        }

        /// <summary>
        /// Добавление или обновление полного наименования ГРН из АИС 3
        /// </summary>
        /// <param name="fullNameGrn">Полное наименование документа ГРН</param>
        /// <param name="numberOgrnGrn">Номер документа ГРН</param>
        private int AddAndUpdateAisGrnDocument(string fullNameGrn, long numberOgrnGrn)
        {
            var saveAndUpdateInventory = new AddAllObjectDb();
            return saveAndUpdateInventory.AddAndUpdateAisGrnDocument(fullNameGrn, numberOgrnGrn);
        }
        /// <summary>
        /// Проверка есть ли в БД документ что бы не вносить его при догрузки документов
        /// </summary>
        /// <param name="aisDocument"></param>
        /// <returns></returns>
        private bool IsVisualAisDocument(AisDocument aisDocument)
        {
            var saveAndUpdateInventory = new AddAllObjectDb();
            if (saveAndUpdateInventory.IsVisualAisDocument(aisDocument) != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Добавление документа из АИС 3 в БД
        /// </summary>
        /// <param name="aisDocument">Документ АИС 3</param>
        /// <returns></returns>
        private int AddAndUpdateAisDocument(AisDocument aisDocument)
        {
            var saveAndUpdateInventory = new AddAllObjectDb();
            return saveAndUpdateInventory.AddAndUpdateAisDocument(aisDocument);
        }
        /// <summary>
        /// Запись о синхронизации или не синхронизации с документом АИС 3
        /// </summary>
        /// <param name="idDocGrn">Ун отрабатываемого ГРН</param>
        /// <param name="idUserDocument">Ун пользовательского документа</param>
        /// <param name="idAisDocument">Ун документа АИС 3</param>
        /// <param name="isAdd">Признак добавление</param>
        /// <param name="isEmpty">Признак отсутствия синхронизации</param>
        private void AddAndUpdateSynchronization(int idDocGrn, int? idUserDocument = null, int? idAisDocument = null, bool isAdd = false, bool isEmpty = false)
        {
            var saveAndUpdateInventory = new AddAllObjectDb();
            saveAndUpdateInventory.AddAndUpdateSynchronization(idDocGrn, idUserDocument, idAisDocument, isAdd, isEmpty);
        }
        /// <summary>
        /// Контейнер обновление 
        /// </summary>
        ///<param name="documentContainer">Контейнер для обновления</param>
        private void UpdateDocumentContainer(DocumentContainer documentContainer)
        {
            var saveAndUpdateInventory = new AddAllObjectDb();
            saveAndUpdateInventory.UpdateDocumentContainer(documentContainer);
        }

        /// <summary>
        /// Добавление документа в контейнер
        /// </summary>
        /// <param name="idContainer">Ун контейнера</param>
        /// <param name="idDocument">Ун документа</param>
        /// <param name="countModel">Счетчик</param>
        private void AddAddDocumentToContainer(int idContainer, int idDocument, int countModel)
        {
            var saveAndUpdateInventory = new AddAllObjectDb();
            saveAndUpdateInventory.AddAddDocumentToContainer(idContainer, idDocument, countModel);
        }


        /// <summary>
        /// Сохранение или обновление сведение об инвентаризированном документе
        /// </summary>
        /// <param name="documentInventory">Документ инвентаризации</param>
        private void AddAndEditDocumentInventoryContainer(DocumentInventory documentInventory)
        {
            var saveAndUpdateInventory = new AddAllObjectDb();
            saveAndUpdateInventory.AddAndEditDocumentInventory(documentInventory);
        }
        /// <summary>
        /// GRN ошибка по процессу
        /// </summary>
        /// <param name="fullKey">Ключ процесса</param>
        /// <param name="statusProcess">Статус процесса 1</param>
        /// <param name="grnInventory">ГРН в процессе</param>
        private void AddAndUpdateEventErrorIsError(string fullKey, int statusProcess, List<EfDatabaseAutomation.BaseLogica.AutoLogicInventory.GrnInventory> grnInventory)
        {
            var saveAndUpdateInventory = new AddAllObjectDb();
            saveAndUpdateInventory.FullSaveAddAndEditEventProcessError(fullKey, statusProcess, grnInventory);
        }

        /// <summary>
        /// Закрыть подчиненные формы
        /// </summary>
        private void MouseCloseForm(int countClose)
        {
            WindowsAis3 win = new WindowsAis3();
            while (countClose > 0)
            {
                AutoItX.Sleep(1000);
                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                countClose--;
            }
        }
    }
}
