using System;
using System.Collections;
using System.Linq;
using System.Windows.Automation;
using EfDatabaseAutomation.Automation.Base;
using EfDatabaseAutomation.Automation.BaseLogica.PreCheck;
using EfDatabaseAutomation.Automation.BaseLogica.XsdShemeSqlLoad.LoadDeclarationData;
using LibaryAIS3Windows.AutomationsUI.LibaryAutomations;
using System.Text.RegularExpressions;
using Ifns51.FromAis;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace LibaryAIS3Windows.ButtonFullFunction.PreCheck
{
   public class DataBaseElementAdd
    {
        /// <summary>
        /// Добавление в БД ЮЛ
        /// Для ветки Налоговое администрирование\Централизованный учет налогоплательщиков\01. ЕГРН - российские организации\1.01. Идентификационные характеристики организации
        /// </summary>
        /// <param name="libraryAutomation">Библиотека Автоматизации</param>
        /// <param name="automationElement">Автоматизированный элемент</param>
        /// <param name="aisData">Модель для сервера</param>
        /// <param name="memos">Поля</param>
        public void AddUlFace(LibaryAutomations libraryAutomation, AutomationElement automationElement, ref AisParsedData aisData, string[] memos)
        {
            UlFace uiFace = new UlFace();
            PreCheckAddObject preCheck = new PreCheckAddObject();
            var dictionary = new Dictionary<string, string>();
            foreach (var memo in memos)
            {
                var value = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.SelectAutomationColrction(automationElement).Cast<AutomationElement>().First(elem => elem.Current.Name.Contains(memo)));
                dictionary.Add(memo, value);
                switch (memo)
                {
                    case "УН ЮЛ в ЕГРН":
                        uiFace.IdNum = Convert.ToInt64(Regex.Replace(value, @"\s+", ""));
                        break;
                    case "ИНН":
                        uiFace.Inn = value;
                        break;
                    case "Полное наименование ЮЛ":
                        uiFace.NameFull = value;
                        break;
                    case "КПП ЮЛ":
                        uiFace.Kpp = value;
                        break;
                    case "Сокращенное наименование ЮЛ":
                        uiFace.NameSmall = value;
                        break;
                    case "Адрес МН ЮЛ":
                        uiFace.Address = value;
                        break;
                    case "Дата принятия решения о ликвидации":
                        uiFace.DateResh = string.IsNullOrWhiteSpace(value) ? null : (DateTime?)Convert.ToDateTime(value);
                        break;
                    case "Дата принятия решения о реорганизации":
                        uiFace.DateReshReorg = string.IsNullOrWhiteSpace(value) ? null : (DateTime?)Convert.ToDateTime(value);
                        break;
                    case "ОГРН":
                        uiFace.Ogrn = value;
                        break;
                    case "Статус ЮЛ в ЦСР":
                        uiFace.StatusUl = value;
                        break;
                    case "Дата присвоения ОГРН":
                        uiFace.DateOgrn = string.IsNullOrWhiteSpace(value) ? null : (DateTime?)Convert.ToDateTime(value);
                        break;
                    case "ФИД лица":
                        uiFace.Fid = Convert.ToInt64(Regex.Replace(value, @"\s+", ""));
                        break;
                }
            }
            aisData.Data.Add(dictionary);
            preCheck.AddUlFace(uiFace);
            preCheck.Dispose();
        }
        /// <summary>
        /// Сведения об учете организации
        /// Для ветки Налоговое администрирование\Централизованный учет налогоплательщиков\01. ЕГРН - российские организации\1.03. Сведения об учете организации в НО
        /// </summary>
        /// <param name="libraryAutomation">Библиотека Автоматизации</param>
        /// <param name="automationElement">Автоматизированный элемент</param>
        /// <param name="aisData">Модель для сервера</param>
        /// <param name="innUl">Инн ЮЛ</param>
        /// <param name="memos">Поля для парсинга АИС 3</param>
        public void AddSvedAccoutingUlFace(LibaryAutomations libraryAutomation, AutomationElement automationElement,ref AisParsedData aisData, string innUl, string[] memos)
        {
            SvedAccoutingUlFace savedAccountingUlFace = new SvedAccoutingUlFace();
            PreCheckAddObject preCheck = new PreCheckAddObject();
            var dictionary = new Dictionary<string, string>();
            foreach (var memo in memos)
            {
                var value = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.SelectAutomationColrction(automationElement).Cast<AutomationElement>().First(elem => elem.Current.Name.Contains(memo)));
                dictionary.Add(memo, value);
                switch (memo)
                {
                    case "УН записи об учете ЮЛ в НО":
                        savedAccountingUlFace.IdNum = Convert.ToInt64(Regex.Replace(value, @"\s+", ""));
                        break;
                    case "Тип объекта учета":
                        savedAccountingUlFace.TypeObject = value;
                        break;
                    case "КПП":
                        savedAccountingUlFace.Kpp = value;
                        break;
                    case "Наименование объекта учета":
                        savedAccountingUlFace.NameObject = value;
                        break;
                    case "Адрес объекта учета":
                        savedAccountingUlFace.AddressObject = value;
                        break;
                    case "Код НО по месту учета":
                        savedAccountingUlFace.CodeNalog = Convert.ToInt32(value);
                        break;
                    case "Дата постановки на учет":
                        savedAccountingUlFace.DateBegin = string.IsNullOrWhiteSpace(value) ? null : (DateTime?)Convert.ToDateTime(value);
                        break;
                    case "Дата фактической постановки на учет":
                        savedAccountingUlFace.DateFactBegin = string.IsNullOrWhiteSpace(value) ? null : (DateTime?)Convert.ToDateTime(value);
                        break;
                    case "Код по СППУНО":
                        savedAccountingUlFace.CodeSppuno = value;
                        break;
                    case "Причина постановки на учет":
                        savedAccountingUlFace.CauseBegin = value;
                        break;
                    case "Дата снятия с учета":
                        savedAccountingUlFace.DateEnd = string.IsNullOrWhiteSpace(value) ? null : (DateTime?)Convert.ToDateTime(value);
                        break;
                    case "Дата фактического снятия с учета":
                        savedAccountingUlFace.DateFactEnd = string.IsNullOrWhiteSpace(value) ? null : (DateTime?)Convert.ToDateTime(value);
                        break;
                    case "Код по СПСУНО":
                        savedAccountingUlFace.CodeSppunoEnd = value;
                        break;
                    case "Причина снятия с учета":
                        savedAccountingUlFace.CauseEnd = value;
                        break;
                }
            }
            aisData.Data.Add(dictionary);
            preCheck.AddSvedAccoutingUlFace(savedAccountingUlFace, innUl);
            preCheck.Dispose();
        }
        /// <summary>
        /// Добавление в БД Истории ЮЛ
        /// Для ветки Налоговое администрирование\Централизованный учет налогоплательщиков\01. ЕГРН - российские организации\2.02. История изменений сведений об учете организации в НО
        /// </summary>
        /// <param name="libraryAutomation">Библиотека Автоматизации</param>
        /// <param name="automationElement">Автоматизированный элемент</param>
        /// <param name="innUl">Инн ЮЛ</param>
        public void AddHistory(LibaryAutomations libraryAutomation, AutomationElement automationElement,string innUl)
        {
            HistoriUlFace historyUiFace = new HistoriUlFace();
            PreCheckAddObject preCheck = new PreCheckAddObject();

            historyUiFace.TypeObject = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                  .SelectAutomationColrction(automationElement)
                  .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Тип объекта учета")));

            historyUiFace.KppObject = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                  .SelectAutomationColrction(automationElement)
                  .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("КПП")));

            historyUiFace.NameObject = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                  .SelectAutomationColrction(automationElement)
                  .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Наименование объекта учета")));

            historyUiFace.AddressObject = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                  .SelectAutomationColrction(automationElement)
                  .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Адрес объекта учета")));

            historyUiFace.IdNum = Convert.ToInt64(Regex.Replace(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("УН записи об учете ЮЛ в НО"))), @"\s+", ""));

            historyUiFace.KodeNo = Convert.ToInt32(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Код НО по месту учета"))));

            var dateNoStart = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Дата постановки на учет")));
            historyUiFace.DateNoStart = string.IsNullOrWhiteSpace(dateNoStart) ? null : (DateTime?)Convert.ToDateTime(dateNoStart);

           var dateNoFinish = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Дата снятия с учета")));
            historyUiFace.DateNoFinish = string.IsNullOrWhiteSpace(dateNoFinish) ? null : (DateTime?)Convert.ToDateTime(dateNoFinish);

            preCheck.AddHistoryUlFace(historyUiFace, innUl);
            preCheck.Dispose();
        }

        /// <summary>
        /// Добавление обособленного подразделения 
        /// </summary>
        /// <param name="libraryAutomation">Библиотека Автоматизации</param>
        /// <param name="automationElement">Автоматизированный элемент</param>
        /// <param name="innUl">Инн ЮЛ</param>
        public void AddBranchUlFace(LibaryAutomations libraryAutomation, AutomationElement automationElement, string innUl)
        {
            BranchUlFace branchUlFace = new BranchUlFace();
            PreCheckAddObject preCheck = new PreCheckAddObject();

            branchUlFace.IdNum = Convert.ToInt64(Regex.Replace(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("КПП"))), @"\s+", ""));

            var dataCreateBranch = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Дата создания")));
            branchUlFace.DataCreateBranch = string.IsNullOrWhiteSpace(dataCreateBranch) ? null : (DateTime?)Convert.ToDateTime(dataCreateBranch);

            var dataCloseBranch = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Дата принятия решения о прекращении деятельности (закрытии)")));
            branchUlFace.DataCloseBranch = string.IsNullOrWhiteSpace(dataCloseBranch) ? null : (DateTime?)Convert.ToDateTime(dataCloseBranch);

            branchUlFace.IndexAddress = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Индекс")));

            branchUlFace.RegionAddress = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Субъект РФ /регион/")));

            branchUlFace.DistrictAddress = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Район")));

            branchUlFace.TownAddress = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Город")));

            branchUlFace.LocalityAddress = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Населенный пункт")));

            branchUlFace.StreetAddress = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Улица")));

            branchUlFace.HouseAddress = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Дом /владение/")));

            branchUlFace.BodyAddress = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Корпус /строение/")));

            branchUlFace.ApartmentAddress = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Квартира /офис/")));

            preCheck.AddBranchUlFace(branchUlFace, innUl);
            preCheck.Dispose();
        }

        /// <summary>
        /// Добавление объектов собственности Руководителей и учередителей
        /// </summary>
        /// <param name="libraryAutomation">Библиотека Автоматизации</param>
        /// <param name="automationElement">Автоматизированный элемент</param>
        /// <param name="innUl">Инн ФЛ</param>
        /// <param name="typeObject">Тип объекта (имущество,земля,транспорт)</param>
        public void AddObjectUl(LibaryAutomations libraryAutomation, AutomationElement automationElement, string innUl, string typeObject)
        {
            ImZmTrUl imZmTrUl = new ImZmTrUl();
            PreCheckAddObject preCheck = new PreCheckAddObject();

            imZmTrUl.IdNum = Convert.ToInt64(Regex.Replace(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("УН объекта учета ЮЛ"))), @"\s+", ""));

            imZmTrUl.NameObject = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Наименование объекта учета")));

            imZmTrUl.ReasonSettingStart = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Причина постановки на учет")));

            var dateOne = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Дата первичной постановки на учет")));
            imZmTrUl.DateOne = string.IsNullOrWhiteSpace(dateOne) ? null : (DateTime?)Convert.ToDateTime(dateOne);

            var dateStart = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Дата постановки на учет в данном НО")));
            imZmTrUl.DateStart = string.IsNullOrWhiteSpace(dateStart) ? null : (DateTime?)Convert.ToDateTime(dateStart);

            var dateFactStart = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Дата фактической постановки на учет")));
            imZmTrUl.DateFactStart = string.IsNullOrWhiteSpace(dateFactStart) ? null : (DateTime?)Convert.ToDateTime(dateFactStart);

            imZmTrUl.ReasonSettingFinish = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Причина снятия с учета")));

            var dateFinish = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Дата окончательного снятия с учета")));
            imZmTrUl.DateFinish = string.IsNullOrWhiteSpace(dateFinish) ? null : (DateTime?)Convert.ToDateTime(dateFinish);

            var dateFinishNo = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Дата снятия с учета в данном НО")));
            imZmTrUl.DateFinishNo = string.IsNullOrWhiteSpace(dateFinishNo) ? null : (DateTime?)Convert.ToDateTime(dateFinishNo);

            var dateFactFinish = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Дата фактического снятия с учета в данном НО")));
            imZmTrUl.DateFactFinish = string.IsNullOrWhiteSpace(dateFactFinish) ? null : (DateTime?)Convert.ToDateTime(dateFactFinish);

            imZmTrUl.AddresObject = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Адрес места нахождения объекта собственности")));

            preCheck.AddImZmTrUl(imZmTrUl, innUl, typeObject);
            preCheck.Dispose();
        }
        /// <summary>
        /// Добавление Сведения о среднесписочной численности работников ЮЛ
        /// Налоговое администрирование\Контрольная работа (налоговые проверки)\109. Прочие документы\Сведения о среднесписочной численности работников
        /// </summary>
        /// <param name="libraryAutomation">Библиотека Автоматизации</param>
        /// <param name="automationElement">Автоматизированный элемент</param>
        /// <param name="innUl">Инн ЮЛ</param>
        public void AddStrngthUlFace(LibaryAutomations libraryAutomation, AutomationElement automationElement, string innUl)
        {
            StrngthUlFace strngthUlFace = new StrngthUlFace();
            PreCheckAddObject preCheck = new PreCheckAddObject();

            strngthUlFace.IdNum = Convert.ToInt64(Regex.Replace(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("РегНомер"))), @"\s+", ""));

            var dataDocument = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Дата документа")));
            strngthUlFace.DataDocument = string.IsNullOrWhiteSpace(dataDocument) ? null : (DateTime?)Convert.ToDateTime(dataDocument);

            strngthUlFace.StrngthFace = Convert.ToInt32(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Среднегодовая численнось работников (чел)"))));

            preCheck.AddStrngthUlFace(strngthUlFace, innUl);
            preCheck.Dispose();
        }

        /// <summary>
        /// Добавление Сведений о счетах ЮЛ
        /// Налоговое администрирование\Банковские и лицевые счета\09. Картотека счетов\01. Картотека счетов РО, ИО, ИП
        /// </summary>
        /// <param name="libraryAutomation">Библиотека Автоматизации</param>
        /// <param name="automationElement">Автоматизированный элемент</param>
        /// <param name="innUl">Инн ЮЛ</param>
        public void AddCashUlFace(LibaryAutomations libraryAutomation, AutomationElement automationElement, string innUl)
        {
            var idNum = Convert.ToInt64(Regex.Replace(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Счет: Регномер"))), @"\s+", ""));
            PreCheckAddObject preCheck = new PreCheckAddObject();
            if (!preCheck.IsExistsIdCash(idNum))
            {
                CashUlFace cashUlFace = new CashUlFace();

                cashUlFace.IdNum = idNum;

                cashUlFace.NameFull = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                    .SelectAutomationColrction(automationElement)
                    .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("КО: Наименование головной организации")));

                cashUlFace.CashNumber = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                    .SelectAutomationColrction(automationElement)
                    .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Счет: Номер")));

                var dataOpenCash = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                    .SelectAutomationColrction(automationElement)
                    .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Счет: Дата открытия")));
                cashUlFace.DataOpenCash = string.IsNullOrWhiteSpace(dataOpenCash) ? null : (DateTime?)Convert.ToDateTime(dataOpenCash);


                var dataClosedCash = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                    .SelectAutomationColrction(automationElement)
                    .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Счет: Дата закрытия")));
                cashUlFace.DataClosedCash = string.IsNullOrWhiteSpace(dataClosedCash) ? null : (DateTime?)Convert.ToDateTime(dataClosedCash);


                cashUlFace.TypeCash = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                    .SelectAutomationColrction(automationElement)
                    .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Счет: Вид")));

                preCheck.AddCashUlFace(cashUlFace, innUl);
            }
            preCheck.Dispose();
        }
        /// <summary>
        /// 7. Индивидуальные карточки налогоплательщиков сохранение в БД
        /// </summary>
        /// <param name="fileNameXml">Файл xml</param>
        /// <param name="innUl">ИНН</param>
        public void AddIndividualCardsUlFace(string fileNameXml, string innUl)
        {
            IndividualCardsUlFace cardsUlFace = new IndividualCardsUlFace();
            PreCheckAddObject preCheck = new PreCheckAddObject();
            cardsUlFace.ReportAll = LibaryXMLAuto.ReadOrWrite.LogicaXml.LogicaXml.Document(fileNameXml).InnerXml;
            preCheck.AddIndividualCardsUlFace(cardsUlFace, innUl);
            preCheck.Dispose();
        }

        /// <summary>
        /// Добавление Банковские выписки, справки ЮЛ
        /// </summary>
        /// <param name="fileName">Имя файла выписок</param>
        /// <param name="innUl">Инн ЮЛ</param>
        public void AddCashBankAllUlFace(string fileName, string innUl)
        {
            var preCheck = new PreCheckAddObject();
            var connectionString = string.Format($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={fileName}; Extended Properties=Excel 12.0;");
            var adapter = new OleDbDataAdapter("Select * From [Sheet1$]", connectionString);
            var ds = new DataSet();
            long result;
            adapter.Fill(ds, "Declaration");
            var data = ds.Tables["Declaration"];
            var countRow = 1;
            foreach (DataRow row in data.Rows)
            {
                if (countRow >= 2)
                {
                    if (Int64.TryParse(row.ItemArray[0].ToString(),out result))
                    {
                        CashBankAllUlFace cashBankAllUlFace = new CashBankAllUlFace
                        {
                            IdNum = Convert.ToInt64(row.ItemArray[0]),
                            DateWay = Convert.ToDateTime(row.ItemArray[1]),
                            CodeNo = Convert.ToInt32(row.ItemArray[2]),
                            DatePriem = Convert.ToDateTime(row.ItemArray[3]),
                            NameBank = Convert.ToString(row.ItemArray[4]),
                            Bik = Convert.ToString(row.ItemArray[5]),
                            InnBank = Convert.ToString(row.ItemArray[6]),
                            KppBank = Convert.ToString(row.ItemArray[7]),
                            NumberCash = Convert.ToString(row.ItemArray[8]),
                            Cash = Convert.ToString(row.ItemArray[9]),
                            DateStartPeriod = Convert.ToDateTime(row.ItemArray[10]),
                            DateFinishPeriod = Convert.ToDateTime(row.ItemArray[11]),
                            CashScoreStartPeriod = Convert.ToDouble(row.ItemArray[12]),
                            CashScoreFinishPeriod = Convert.ToDouble(row.ItemArray[13])
                        };
                        preCheck.AddCashBankAllUlFace(cashBankAllUlFace, innUl);
                    }
                  
                }
                countRow++;
            }
            preCheck.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="libraryAutomation">Библиотека Автоматизации</param>
        /// <param name="automationElement">Автоматизированный элемент</param>
        /// <returns>Возврат Рег номера декларации</returns>
        public DeclarationUl AddDeclaration(LibaryAutomations libraryAutomation, AutomationElement automationElement)
        {
            DeclarationUl declarationUlFace = new DeclarationUl
            {
                RegNumDecl = Convert.ToInt64(Regex.Replace(
                    libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                        .SelectAutomationColrction(automationElement)
                        .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("РегНомер"))), @"\s+", "")),
                Psumm = Convert.ToDouble(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                    libraryAutomation
                        .SelectAutomationColrction(automationElement)
                        .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("П-Сумма")))),
                Knd = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                    .SelectAutomationColrction(automationElement)
                    .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("КНД"))),
                NameDocument = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                    .SelectAutomationColrction(automationElement)
                    .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Документ"))),
                VidDoc = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                    .SelectAutomationColrction(automationElement)
                    .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Вид документа"))),
                NumberKor = Convert.ToInt32(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                    libraryAutomation
                        .SelectAutomationColrction(automationElement)
                        .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Номер корректировки")))),
                Period = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                    .SelectAutomationColrction(automationElement)
                    .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Отчетный период"))),
                God = Convert.ToInt32(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                    libraryAutomation
                        .SelectAutomationColrction(automationElement)
                        .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Отчетный год"))))
            };
            return declarationUlFace;
        }
        public bool DeclarationDataExists(long regNumberDeclaration)
        {
            PreCheckAddObject preCheck = new PreCheckAddObject();
            return preCheck.IsExistsDeclaration(regNumberDeclaration);
        }

        /// <summary>
        /// Наименование файла
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        /// <param name="declarationUl">Декларация</param>
        /// <param name="innUl">ИНН</param>
        public void AddDeclarationData(string fileName, DeclarationUl declarationUl, string innUl)
        {
            PreCheckAddObject preCheck = new PreCheckAddObject();
            var connectionString = string.Format($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={fileName}; Extended Properties=Excel 12.0;");
            var adapter = new OleDbDataAdapter("Select * From [Sheet0$]", connectionString);
            var ds = new DataSet();
            adapter.Fill(ds, "Declaration");
            DataTable data = ds.Tables["Declaration"];
            ArrayOfDeclarationData listDeclarationDataFace = new ArrayOfDeclarationData() {DeclarationData = new EfDatabaseAutomation.Automation.BaseLogica.XsdShemeSqlLoad.LoadDeclarationData.DeclarationData[data.Rows.Count] };
            var i = 0;
            foreach (DataRow row in data.Rows)
            {
                listDeclarationDataFace.DeclarationData[i] = new EfDatabaseAutomation.Automation.BaseLogica.XsdShemeSqlLoad.LoadDeclarationData.DeclarationData()
                {
                    RegNumDecl = declarationUl.RegNumDecl,
                    CodeString = row.Field<string>("Код строки"),
                    NameParametr = row.Field<string>("Наименование показателя"),
                    CodeParametr = row.Field<string>("Код показателя"),
                    DataFace = row.Field<string>("По данным плательщика"),
                    DataInspector = row.Field<string>("По данным инспектора"),
                    Error = row.Field<string>("Отклонение")
                };
                i++;
            }
            preCheck.AddDeclarationModel(declarationUl, listDeclarationDataFace, innUl);
            preCheck.Dispose();
        }

        /// <summary>
        /// Добавление объектов собственности Руководителей и учередителей
        /// </summary>
        /// <param name="libraryAutomation">Библиотека Автоматизации</param>
        /// <param name="automationElement">Автоматизированный элемент</param>
        /// <param name="innFl">Инн ФЛ</param>
        /// <param name="typeObject">Тип объекта (имущество,земля,транспорт)</param>
        public void AddObjectFl(LibaryAutomations libraryAutomation, AutomationElement automationElement, string innFl,string typeObject)
        {
            ImZmTrFl imZmTrFl = new ImZmTrFl();
            PreCheckAddObject preCheck = new PreCheckAddObject();

            imZmTrFl.IdNum = Convert.ToInt64(Regex.Replace(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("УН объекта учета ФЛ"))), @"\s+", ""));

            imZmTrFl.NameObject = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Наименование объекта учета")));

            imZmTrFl.ReasonSettingStart = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Причина постановки на учет")));

            var dateOne = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Дата первичной постановки на учет")));
            imZmTrFl.DateOne = string.IsNullOrWhiteSpace(dateOne) ? null : (DateTime?)Convert.ToDateTime(dateOne);

            var dateStart = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Дата постановки на учет в данном НО")));
            imZmTrFl.DateStart = string.IsNullOrWhiteSpace(dateStart) ? null : (DateTime?)Convert.ToDateTime(dateStart);

            var dateFactStart = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Дата фактической постановки на учет")));
            imZmTrFl.DateFactStart = string.IsNullOrWhiteSpace(dateFactStart) ? null : (DateTime?)Convert.ToDateTime(dateFactStart);

            imZmTrFl.ReasonSettingFinish = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Причина снятия с учета")));

            var dateFinish = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Дата окончательного снятия с учета")));
            imZmTrFl.DateFinish = string.IsNullOrWhiteSpace(dateFinish) ? null : (DateTime?)Convert.ToDateTime(dateFinish);

            var dateFinishNo = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Дата снятия с учета в данном НО")));
            imZmTrFl.DateFinishNo = string.IsNullOrWhiteSpace(dateFinishNo) ? null : (DateTime?)Convert.ToDateTime(dateFinishNo);

            var dateFactFinish = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Дата фактического снятия с учета в данном НО")));
            imZmTrFl.DateFactFinish = string.IsNullOrWhiteSpace(dateFactFinish) ? null : (DateTime?)Convert.ToDateTime(dateFactFinish);

            imZmTrFl.AddresObject = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Адрес места нахождения объекта собственности")));

            preCheck.AddImZmTrFl(imZmTrFl,innFl, typeObject);
            preCheck.Dispose();
        }
        /// <summary>
        /// Разбор файла выписок организации Пока такой алгоритм
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        /// <param name="innUl">ИНН ЮЛ</param>
        public void AddDbStatement(string fileName, string innUl)
        {
            PreCheckAddObject preCheck = new PreCheckAddObject();
            RichTextBox rtb = new RichTextBox();
            rtb.LoadFile(fileName);
            var isRead = false;
            string parameter = "";
            HeadingStatement statement = new HeadingStatement();
            var listStatementFull = new List<StatementFull>();
            foreach (string line in rtb.Lines)
            {
                if (isRead)
                {
                    var textSplit = line.Split('\t');
                    //Формирование заголовка выписки
                    if (textSplit.Length == 1)
                    {
                        bool isNum = int.TryParse(textSplit[0], out var num);
                        if (!string.IsNullOrWhiteSpace(textSplit[0]))
                        {
                            parameter = isNum ? string.Concat(parameter, $" - {num}").Replace($" - {num - 1}", "") : textSplit[0];
                            if (!string.IsNullOrWhiteSpace(parameter))
                            {
                                //Запись или проверка есть ли NameIndex в БД возврат IdStatementHead
                                statement = preCheck.AddHeadingStatement(new HeadingStatement() {NameIndex = parameter});
                            }
                        }
                    }
                    //Формирование тела Выписки
                    if (textSplit.Length == 3)
                    {
                        if (!string.IsNullOrWhiteSpace(textSplit[0]))
                        {
                            //Собираем коллекцию с учетом  IdStatementHead и УН ЮЛ и записываем в БД
                            listStatementFull.Add(new StatementFull()
                            {
                                    VarIndex = Convert.ToInt32(textSplit[0]),
                                    NameParametr = textSplit[1],
                                    ValuesStatement = textSplit[2],
                                    IdStatementHead = statement.IdStatementHead
                            });
                        }
                    }
                }
                //Условие нахождения начала выписки
                if (line.Equals("1\t2\t3"))
                    isRead = true;
            }
            preCheck.AddStatementFull(listStatementFull,innUl);
            preCheck.Dispose();
            rtb.Dispose();
        }
    }
}
