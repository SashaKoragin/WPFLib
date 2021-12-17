using System;
using System.Linq;
using System.Windows.Automation;
using EfDatabaseAutomation.Automation.Base;
using EfDatabaseAutomation.Automation.BaseLogica.PreCheck;
using EfDatabaseAutomation.Automation.BaseLogica.XsdShemeSqlLoad.XsdAllBodyData;
using LibraryAIS3Windows.AutomationsUI.LibaryAutomations;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using System.Globalization;
using AisPoco.Ifns51.FromAis;
using AttributeHelperModelXml;
using LibraryAIS3Windows.AutomationsUI.Otdels.PreCheck;
using LibraryAIS3Windows.ButtonsClikcs;

namespace LibraryAIS3Windows.ButtonFullFunction.PreCheck
{
   public class DataBaseElementAdd
    {
        /// <summary>
        /// Добавление в БД ЮЛ
        /// Для ветки Налоговое администрирование\Централизованный учет налогоплательщиков\01. ЕГРН - российские организации\1.01. Идентификационные характеристики организации
        /// </summary>
        /// <param name="aisData">Модель для сервера</param>
        /// <param name="memos">Поля</param>
        /// <param name="pathXlsx">Путь к Temp</param>
        /// <param name="sheetName">Наименование Листа</param>
        public void AddUlFace(ref AisParsedData aisData, string[] memos,string pathXlsx, string sheetName)
        {
            PreCheckAddObject preCheck = new PreCheckAddObject();
            XlsxToDataTable.XlsxToDataTable xlsxToDataTable = new XlsxToDataTable.XlsxToDataTable();
            var dataTable = xlsxToDataTable.GetDateTableXslxFormatNodDouble(pathXlsx, sheetName);
            foreach (DataRow row in dataTable.Rows)
            {
                var dictionary = new Dictionary<string, string>();
                UlFace uiFace = new UlFace();
                foreach (var memo in memos)
                {
                    var value = row[memo].ToString();
                    dictionary.Add(memo, value);
                    switch (memo)
                    {
                        case "УН ЮЛ в ЕГРН":
                            uiFace.IdNum = Convert.ToInt64(value);
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
                        case "Адрес МН ЮЛ по КЛАДР":
                            uiFace.Address = value;
                            break;
                        case "Дата принятия решения о ликвидации":
                            uiFace.DateResh = ConvertDateTimeXlsxToUser(value);
                            break;
                        case "Дата принятия решения о реорганизации":
                            uiFace.DateReshReorg = ConvertDateTimeXlsxToUser(value);
                            break;
                        case "ОГРН":
                            uiFace.Ogrn = value;
                            break;
                        case "Статус ЮЛ в ЦСР":
                            uiFace.StatusUl = value;
                            break;
                        case "Дата присвоения ОГРН":
                            uiFace.DateOgrn = ConvertDateTimeXlsxToUser(value);
                            break;
                        case "ФИД лица":
                            uiFace.Fid = Convert.ToInt64(value);
                            break;
                    }
                    
                }
                aisData.Data.Add(dictionary);
                preCheck.AddUlFace(uiFace);
                break;
            }
            preCheck.Dispose();
        }
        /// <summary>
        /// Сведения об учете организации
        /// Для ветки Налоговое администрирование\Централизованный учет налогоплательщиков\01. ЕГРН - российские организации\1.03. Сведения об учете организации в НО
        /// </summary>
        /// <param name="aisData">Модель для сервера</param>
        /// <param name="innUl">Инн ЮЛ</param>
        /// <param name="memos">Поля для парсинга АИС 3</param>
        /// <param name="pathXlsx">Путь к Temp</param>
        /// <param name="sheetName">Наименование Листа</param>
        public void AddSvedAccoutingUlFace(ref AisParsedData aisData, string innUl, string[] memos, string pathXlsx, string sheetName)
        {
            PreCheckAddObject preCheck = new PreCheckAddObject();
            XlsxToDataTable.XlsxToDataTable xlsxToDataTable = new XlsxToDataTable.XlsxToDataTable();
            var dataTable = xlsxToDataTable.GetDateTableXslxFormatNodDouble(pathXlsx, sheetName);
            foreach (DataRow row in dataTable.Rows)
            {
                var dictionary = new Dictionary<string, string>();
                SvedAccoutingUlFace savedAccountingUlFace = new SvedAccoutingUlFace();
                foreach (var memo in memos)
                {
                    var value = row[memo].ToString();
                    dictionary.Add(memo, value);
                    switch (memo)
                    {
                        case "УН записи об учете ЮЛ в НО":
                            savedAccountingUlFace.IdNum = Convert.ToInt64(value);
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
                        case "Адрес объекта учета по КЛАДР":
                            savedAccountingUlFace.AddressObject = value;
                            break;
                        case "Код НО по месту учета":
                            savedAccountingUlFace.CodeNalog = Convert.ToInt32(value);
                            break;
                        case "Дата постановки на учет":
                            savedAccountingUlFace.DateBegin = ConvertDateTimeXlsxToUser(value);
                            break;
                        case "Дата фактической постановки на учет":
                            savedAccountingUlFace.DateFactBegin = ConvertDateTimeXlsxToUser(value);
                            break;
                        case "Код по СППУНО":
                            savedAccountingUlFace.CodeSppuno = value;
                            break;
                        case "Причина постановки на учет":
                            savedAccountingUlFace.CauseBegin = value;
                            break;
                        case "Дата снятия с учета":
                            savedAccountingUlFace.DateEnd = ConvertDateTimeXlsxToUser(value);
                            break;
                        case "Дата фактического снятия с учета":
                            savedAccountingUlFace.DateFactEnd = ConvertDateTimeXlsxToUser(value);
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
            }
            preCheck.Dispose();
        }
        /// <summary>
        /// Добавление в БД Истории ЮЛ
        /// Для ветки Налоговое администрирование\Централизованный учет налогоплательщиков\01. ЕГРН - российские организации\2.02. История изменений сведений об учете организации в НО
        /// </summary>
        /// <param name="aisData">Модель для сервера</param>
        /// <param name="innUl">Инн ЮЛ</param>
        /// <param name="memos">Поля</param>
        /// <param name="pathXlsx">Путь к Temp</param>
        /// <param name="sheetName">Наименование Листа</param>
        public void AddHistory(ref AisParsedData aisData, string innUl, string[] memos,  string pathXlsx, string sheetName)
        {
            PreCheckAddObject preCheck = new PreCheckAddObject();
            XlsxToDataTable.XlsxToDataTable xlsxToDataTable = new XlsxToDataTable.XlsxToDataTable();
            var dataTable = xlsxToDataTable.GetDateTableXslxFormatNodDouble(pathXlsx, sheetName);
            foreach (DataRow row in dataTable.Rows)
            {
                var dictionary = new Dictionary<string, string>();
                HistoriUlFace historyUiFace = new HistoriUlFace();
                foreach (var memo in memos)
                {
                    var value = row[memo].ToString();
                    dictionary.Add(memo, value);
                    switch (memo)
                    {
                        case "Тип объекта учета":
                            historyUiFace.TypeObject = value;
                            break;
                        case "КПП":
                            historyUiFace.KppObject = value;
                            break;
                        case "Наименование объекта учета":
                            historyUiFace.NameObject = value;
                            break;
                        case "Адрес объекта учета по КЛАДР":
                            historyUiFace.AddressObject = value;
                            break;
                        case "УН записи об учете ЮЛ в НО":
                            historyUiFace.IdNum = Convert.ToInt64(value);
                            break;
                        case "Код НО по месту учета":
                            historyUiFace.KodeNo = Convert.ToInt32(value);
                            break;
                        case "Дата постановки на учет":
                            historyUiFace.DateNoStart = ConvertDateTimeXlsxToUser(value);
                            break;
                        case "Дата снятия с учета":
                            historyUiFace.DateNoFinish = ConvertDateTimeXlsxToUser(value);
                            break;
                    }
                }
                aisData.Data.Add(dictionary);
                preCheck.AddHistoryUlFace(historyUiFace, innUl);
            }
            preCheck.Dispose();
        }

        /// <summary>
        /// Добавление обособленного подразделения 
        /// </summary>
        /// <param name="aisData">Модель для сервера</param>
        /// <param name="innUl">Инн ЮЛ</param>
        /// <param name="memos">Поля</param>
        /// <param name="pathXlsx">Путь к Temp</param>
        /// <param name="sheetName">Наименование Листа</param>
        public void AddBranchUlFace(ref AisParsedData aisData, string innUl, string[] memos, string pathXlsx, string sheetName)
        {
            PreCheckAddObject preCheck = new PreCheckAddObject();
            XlsxToDataTable.XlsxToDataTable xlsxToDataTable = new XlsxToDataTable.XlsxToDataTable();
            var dataTable = xlsxToDataTable.GetDateTableXslxFormatNodDouble(pathXlsx, sheetName);  // GeteDateTableXslx(pathXlsx, sheetName);
            foreach (DataRow row in dataTable.Rows)
            {
                var dictionary = new Dictionary<string, string>();
                BranchUlFace branchUlFace = new BranchUlFace();
                foreach (var memo in memos)
                {
                    var value = row[memo].ToString();
                    dictionary.Add(memo, value);
                    switch (memo)
                    {
                        case "КПП":
                            branchUlFace.IdNum = Convert.ToInt64(value);
                            break;
                        case "Дата создания":
                            branchUlFace.DataCreateBranch = ConvertDateTimeXlsxToUser(value);
                            break;
                        case "Дата принятия решения о прекращении деятельности (закрытии)":
                            branchUlFace.DataCloseBranch = ConvertDateTimeXlsxToUser(value);
                            break;
                        case "Индекс":
                            branchUlFace.IndexAddress = value;
                            break;
                        case "Адрес по КЛАДР":
                            branchUlFace.RegionAddress = value;
                            break;
                    }
                }
                aisData.Data.Add(dictionary);
                preCheck.AddBranchUlFace(branchUlFace, innUl);
            }
            preCheck.Dispose();
        }

        /// <summary>
        /// Добавление объектов собственности Руководителей и учередителей
        /// </summary>
        /// <param name="aisData">Модель для сервера</param>
        /// <param name="innUl">Инн ЮЛ</param>
        /// <param name="memos">Поля</param>
        /// <param name="pathXlsx">Путь к Temp</param>
        /// <param name="sheetName">Наименование Листа</param>
        /// <param name="typeObject">Тип объекта (имущество,земля,транспорт)</param>
        public void AddObjectUl(ref AisParsedData aisData, string innUl, string[] memos, string pathXlsx, string sheetName, string typeObject)
        {
            PreCheckAddObject preCheck = new PreCheckAddObject();
            XlsxToDataTable.XlsxToDataTable xlsxToDataTable = new XlsxToDataTable.XlsxToDataTable();
            var dataTable = xlsxToDataTable.GetDateTableXslxFormatNodDouble(pathXlsx, sheetName);
            foreach (DataRow row in dataTable.Rows)
            {
                var dictionary = new Dictionary<string, string>();
                ImZmTrUl imZmTrUl = new ImZmTrUl();
                foreach (var memo in memos)
                {
                    var value = row[memo].ToString();
                    dictionary.Add(memo, value);
                    switch (memo)
                    {
                        case "УН объекта учета ЮЛ":
                            imZmTrUl.IdNum = Convert.ToInt64(value);
                            break;
                        case "Наименование объекта учета":
                            imZmTrUl.NameObject = value;
                            break;
                        case "Причина постановки на учет":
                            imZmTrUl.ReasonSettingStart = value;
                            break;
                        case "Дата первичной постановки на учет":
                            imZmTrUl.DateOne = ConvertDateTimeXlsxToUser(value);
                            break;
                        case "Дата постановки на учет в данном НО":
                            imZmTrUl.DateStart = ConvertDateTimeXlsxToUser(value);
                            break;
                        case "Дата фактической постановки на учет":
                            imZmTrUl.DateFactStart = ConvertDateTimeXlsxToUser(value);
                            break;
                        case "Причина снятия с учета":
                            imZmTrUl.ReasonSettingFinish = value;
                            break;
                        case "Дата окончательного снятия с учета":
                            imZmTrUl.DateFinish = ConvertDateTimeXlsxToUser(value);
                            break;
                        case "Дата снятия с учета в данном НО":
                            imZmTrUl.DateFinishNo = ConvertDateTimeXlsxToUser(value);
                            break;
                        case "Дата фактического снятия с учета в данном НО":
                            imZmTrUl.DateFactFinish = ConvertDateTimeXlsxToUser(value);
                            break;
                        case "Адрес места нахождения объекта собственности":
                            imZmTrUl.AddresObject = value;
                            break;
                    }
                }
                aisData.Data.Add(dictionary);
                preCheck.AddImZmTrUl(imZmTrUl, innUl, typeObject);
            }
            preCheck.Dispose();
        }
        /// <summary>
        /// Добавление Сведения о среднесписочной численности работников ЮЛ
        /// Налоговое администрирование\Контрольная работа (налоговые проверки)\109. Прочие документы\Сведения о среднесписочной численности работников
        /// </summary>
        /// <param name="aisData">Модель для сервера</param>
        /// <param name="innUl">Инн ЮЛ</param>
        /// <param name="memos">Поля</param>
        /// <param name="pathXlsx">Путь к Temp</param>
        /// <param name="sheetName">Наименование Листа</param>
        public void AddStrngthUlFace(ref AisParsedData aisData, string innUl, string[] memos, string pathXlsx, string sheetName)
        {
            PreCheckAddObject preCheck = new PreCheckAddObject();
            XlsxToDataTable.XlsxToDataTable xlsxToDataTable = new XlsxToDataTable.XlsxToDataTable();
            var dataTable = xlsxToDataTable.GetDateTableXslxFormatNodDouble(pathXlsx, sheetName);
            foreach (DataRow row in dataTable.Rows)
            {
                var dictionary = new Dictionary<string, string>();
                StrngthUlFace strngthUlFace = new StrngthUlFace();
                foreach (var memo in memos)
                {
                    var value = row[memo].ToString();
                    dictionary.Add(memo, value);
                    switch (memo)
                    {
                        case "РегНомер":
                            strngthUlFace.IdNum = Convert.ToInt64(value);
                            break;

                        case "Дата документа":
                            strngthUlFace.DataDocument = ConvertDateTimeXlsxToUser(value);
                            break;
                        case "Среднегодовая численнось работников (чел)":
                            strngthUlFace.StrngthFace = Convert.ToInt32(value);
                            break;
                    }
                }
                aisData.Data.Add(dictionary);
                preCheck.AddStrngthUlFace(strngthUlFace, innUl);
            }
            preCheck.Dispose();
        }

        /// <summary>
        /// Добавление Сведений о счетах ЮЛ
        /// Налоговое администрирование\Банковские и лицевые счета\09. Картотека счетов\01. Картотека счетов РО, ИО, ИП
        /// </summary>
        /// <param name="innUl">Инн ЮЛ</param>
        /// <param name="pathXlsx">Путь к Temp</param>
        /// <param name="sheetName">Наименование Листа</param>
        public void AddCashUlFace(string innUl, string pathXlsx, string sheetName)
        {
            PreCheckAddObject preCheck = new PreCheckAddObject();
            XlsxToDataTable.XlsxToDataTable xlsxToDataTable = new XlsxToDataTable.XlsxToDataTable();
            var dataTable = xlsxToDataTable.GetDateTableXslxFormatNodDouble(pathXlsx, sheetName);
            DataNamesMapper<EfDatabaseAutomation.Automation.BaseLogica.XsdShemeSqlLoad.XsdAllBodyData.CashUlFace> mapper = new DataNamesMapper<EfDatabaseAutomation.Automation.BaseLogica.XsdShemeSqlLoad.XsdAllBodyData.CashUlFace>();
            var listCashUl = new ArrayBodyDoc() { CashUlFace = mapper.Map(dataTable).ToArray() };
            preCheck.AddCashUlFace(listCashUl, innUl);
            preCheck.Dispose();
        }
        /// <summary>
        /// Добавление доходов 2НДФЛ в БД по организациям
        /// </summary>
        /// <param name="innUl">Инн ЮЛ</param>
        /// <param name="pathXlsx">Путь к Temp</param>
        /// <param name="sheetName">Наименование Листа</param>
        public void AddNdFl(string innUl, string pathXlsx, string sheetName)
        {
            PreCheckAddObject preCheck = new PreCheckAddObject();
            XlsxToDataTable.XlsxToDataTable xlsxToDataTable = new XlsxToDataTable.XlsxToDataTable();
            var dataTable = xlsxToDataTable.GetDateTableXslx(pathXlsx, sheetName);
            DataNamesMapper<EfDatabaseAutomation.Automation.BaseLogica.XsdShemeSqlLoad.XsdAllBodyData.NdflFl> mapper = new DataNamesMapper<EfDatabaseAutomation.Automation.BaseLogica.XsdShemeSqlLoad.XsdAllBodyData.NdflFl>();
            var listNdFl = new ArrayBodyDoc() { NdflFl = mapper.Map(dataTable).ToArray() };
            preCheck.AddNdflDataBase(listNdFl, innUl);
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
        /// <param name="innUl">Инн ЮЛ</param>
        /// <param name="pathXlsx">Путь к Temp</param>
        /// <param name="sheetName">Наименование Листа</param>
        public void AddCashBankAllUlFace( string innUl, string pathXlsx, string sheetName)
        {
            var preCheck = new PreCheckAddObject();
            var connectionString = string.Format($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={pathXlsx}; Extended Properties=Excel 12.0;");
            var adapter = new OleDbDataAdapter($"Select * From [{sheetName}$]", connectionString);
            var ds = new DataSet();
            adapter.Fill(ds, "CashBank");
            DataTable dataTable = ds.Tables["CashBank"];
            var indexColumn = 0;
            var indexName = 1;
            List<string> nameColumns = new List<string>();
            foreach (DataColumn col in dataTable.Columns)
            {
                var memo = dataTable.Rows[0][indexColumn].ToString();
                if (nameColumns.Contains(memo) || string.IsNullOrWhiteSpace(memo))
                {
                    memo = $"{memo}{indexName}";
                    nameColumns.Add(memo);
                    indexName++;
                }
                else
                {
                    nameColumns.Add(memo);
                }
                dataTable.Columns[indexColumn].ColumnName = memo;
                indexColumn++;
            }
            dataTable.Rows.Remove(dataTable.Rows[0]);
            DataNamesMapper<EfDatabaseAutomation.Automation.BaseLogica.XsdShemeSqlLoad.XsdAllBodyData.CashBankAllUlFace> mapper = new DataNamesMapper<EfDatabaseAutomation.Automation.BaseLogica.XsdShemeSqlLoad.XsdAllBodyData.CashBankAllUlFace>();
            var listCashUl = new ArrayBodyDoc() { CashBankAllUlFace = mapper.Map(dataTable).ToArray() };
            preCheck.AddCashBankAllUlFace(listCashUl, innUl);
            preCheck.Dispose();
        }

        /// <summary>
        /// Добавление Банковские выписки, справки ЮЛ
        /// </summary>
        /// <param name="innUl">Инн ЮЛ</param>
        /// <param name="pathXlsx">Путь к Temp</param>
        /// <param name="sheetName">Наименование Листа</param>
        public void AddCashBankCounterparty(string innUl, string pathXlsx, string sheetName)
        {
            var preCheck = new PreCheckAddObject();
            var connectionString = string.Format($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={pathXlsx}; Extended Properties=Excel 12.0;");
            var adapter = new OleDbDataAdapter($"Select * From [{sheetName}$]", connectionString);
            var ds = new DataSet();
            adapter.Fill(ds, "CashBankCounterparty");
            DataTable dataTable = ds.Tables["CashBankCounterparty"];
            var indexColumn = 0;
            var indexName = 1;
            List<string> nameColumns = new List<string>();
            foreach (DataColumn col in dataTable.Columns)
            {
                var memo = dataTable.Rows[0][indexColumn].ToString();
                if (nameColumns.Contains(memo) || string.IsNullOrWhiteSpace(memo))
                {
                    memo = $"{memo}{indexName}";
                    nameColumns.Add(memo);
                    indexName++;
                    if (memo == "5") { memo = "Расход д/c, в валюте счета"; }
                    if (memo == "6") { memo = "Расход д/c, в рублях"; }
                    if (memo == "7") { memo = "Приход д/c, в валюте счета"; }
                    if (memo == "8") { memo = "Приход д/c, в рублях"; }
                }
                else
                {
                    nameColumns.Add(memo);
                }
                dataTable.Columns[indexColumn].ColumnName = memo;
                indexColumn++;
            }
            dataTable.Rows.Remove(dataTable.Rows[0]);
            DataNamesMapper<EfDatabaseAutomation.Automation.BaseLogica.XsdShemeSqlLoad.XsdAllBodyData.CounterpartyCashBank> mapper = new DataNamesMapper<EfDatabaseAutomation.Automation.BaseLogica.XsdShemeSqlLoad.XsdAllBodyData.CounterpartyCashBank>();
            var counterpartyCashBank = new ArrayBodyDoc() { CounterpartyCashBank = mapper.Map(dataTable).ToArray() };
            preCheck.AddCounterpartyCashBankModel(counterpartyCashBank, innUl);
            preCheck.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="libraryAutomation">Библиотека Автоматизации</param>
        /// <param name="automationElement">Автоматизированный элемент</param>
        /// <returns>Возврат Рег номера декларации</returns>
        public DeclarationUl AddDeclaration(LibraryAutomations libraryAutomation, AutomationElement automationElement)
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

        /// <summary>
        /// Данные декларации всей
        /// </summary>
        /// <param name="libraryAutomation">Библиотека Автоматизации</param>
        /// <param name="automationElement">Автоматизированный элемент</param>
        /// <returns>Возврат Рег номера декларации</returns>
        public DeclarationAll AddDeclarationAll(LibraryAutomations libraryAutomation, AutomationElement automationElement)
        {
            DeclarationAll declarationAll = new DeclarationAll
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
            return declarationAll;
        }

        /// <summary>
        /// Проверка есть ли декларация в БД
        /// </summary>
        /// <param name="regNumberDeclaration">Регистрационный номер декларации</param>
        /// <returns></returns>
        public bool DeclarationDataExists(long regNumberDeclaration)
        {
            PreCheckAddObject preCheck = new PreCheckAddObject();
            var isExist = preCheck.IsExistsDeclaration(regNumberDeclaration);
            preCheck.Dispose();
            return isExist;
        }

        /// <summary>
        /// Проверка есть ли книга покупок продаж в БД
        /// </summary>
        /// <param name="idBook">Регистрационный номер книги</param>
        /// <returns></returns>
        public bool BookExists(long idBook)
        {
            PreCheckAddObject preCheck = new PreCheckAddObject();
            var isExist = preCheck.IsExistsBook(idBook);
            preCheck.Dispose();
            return isExist;
        }


        /// <summary>
        /// Парсим или создаем Регистрационный номер зашита
        /// </summary>
        /// <param name="libraryAutomation">Библиотека Автоматизации</param>
        /// <param name="automationElement">Автоматизированный элемент книги</param>
        /// <param name="innUl">ИНН ЮЛ</param>
        /// <returns></returns>
        public long ParseAndCreateRegNumberBook(LibraryAutomations libraryAutomation, AutomationElement automationElement, string innUl)
        {
            long idBookRegNum;
            var period = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                      .SelectAutomationColrction(automationElement)
                      .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Отчетный период")));
            var idBook = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                  .SelectAutomationColrction(automationElement)
                                  .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Регистрационный №")));
            idBookRegNum = string.IsNullOrEmpty(idBook) ? Convert.ToInt64(Convert.ToInt64(innUl.Substring(innUl.Length - 4)) * Convert.ToInt64(period.Substring(period.Length - 4)) * Convert.ToInt64(period.Substring(0, 1))) : Convert.ToInt64(idBook);
            return idBookRegNum;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="libraryAutomation">Библиотека Автоматизации</param>
        /// <param name="automationElement">Автоматизированный элемент книги</param>
        /// <param name="innUl">ИНН ЮЛ</param>
        /// <returns>Возврат книги заполненной</returns>
        public Book AddBook(LibraryAutomations libraryAutomation, AutomationElement automationElement, string innUl)
        {
            var preCheck = new PreCheckAddObject();

            var period = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                  .SelectAutomationColrction(automationElement)
                                  .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Отчетный период")));
            var dateStart = Convert.ToDateTime(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                  .SelectAutomationColrction(automationElement)
                                  .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Дата представления"))));
            var summBookPurchase = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                  .SelectAutomationColrction(automationElement)
                                  .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Раздел 8")));
            var summBookSales = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                  .SelectAutomationColrction(automationElement)
                                  .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Раздел 9")));
            var summNds = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                  .SelectAutomationColrction(automationElement)
                                  .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Сумма НДС")));
            var summTotal = "0";
            var weightProduct = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                    .SelectAutomationColrction(automationElement)
                    .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Удельный вес")));

            Book book = new Book
            {
                IdBook = ParseAndCreateRegNumberBook(libraryAutomation, automationElement, innUl),
                Period = period,
                DateStart = dateStart,
                SummBookPurchase = string.IsNullOrEmpty(summBookPurchase) ? 0.00 : double.Parse(summBookPurchase),
                SummBookSales = string.IsNullOrEmpty(summBookSales) ? 0.00 : double.Parse(summBookSales),
                SummNds = string.IsNullOrEmpty(summNds) ? 0.00 : double.Parse(summNds),
                SummTotal = string.IsNullOrEmpty(summTotal) ? 0.00 : double.Parse(summTotal),
                WeightProduct = string.IsNullOrEmpty(weightProduct) ? 0 : int.Parse(weightProduct),
            };

            //Установка фокуса на ИНН
            libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("ИНН")));

            PublicGlobalFunction.PublicGlobalFunction.WindowElementClick(libraryAutomation, ModelBookShopping.StartJournal);
            while (true)
            {
                if (libraryAutomation.IsEnableElements(ModelBookShopping.DocumentContainer, null, true) != null)
                {
                    SendKeys.SendWait(ButtonConstant.Down13);
                    libraryAutomation.FindFirstElement(ModelBookShopping.DocumentContainer, null, true);
                    var elements = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindElement);
                    if (elements.Count >= 2)
                    {
                        book.Telephone = libraryAutomation.SelectAutomationColrction(elements[1])[0].Current.Name;
                    }
                    if (libraryAutomation.IsEnableElements(ModelBookShopping.Code, null, true) != null)
                    {
                        elements = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindElement);
                        if (elements.Count >= 2)
                        {
                            book.CodeTaxCom = elements[1].Current.Name;
                        }
                        if (libraryAutomation.IsEnableElements(ModelBookShopping.IpAdress, null, true) != null)
                        {
                            elements = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindElement);
                            if (elements.Count >= 2)
                            {
                                book.IpAdres = elements[1].Current.Name;
                            }
                        }
                        if (libraryAutomation.IsEnableElements(ModelBookShopping.NameOperator, null, true) != null)
                        {
                            elements = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindElement);
                            if (elements.Count >= 2)
                            {
                                book.NameOperator = elements[1].Current.Name;
                            }
                        }
                    }
                    break;
                }
            }
            return preCheck.AddBook(book, innUl); ;
        }


        /// <summary>
        /// Обновление Книн=ги покупок
        /// </summary>
        /// <param name="book">Обновление книги покупок</param>
        public void UpdeteBookSalesParse(ref Book book)
        {
            var preCheck = new PreCheckAddObject();
            preCheck.UpdeteBookSalesParse(ref book);
            preCheck.Dispose();
        }
        /// <summary>
        /// Обновление книги продаж
        /// </summary>
        /// <param name="book">Обновление книги продаж</param>
        public void UpdeteBookPurchase(ref Book book)
        {
            var preCheck = new PreCheckAddObject();
            preCheck.UpdeteBookPurchase(ref book);
            preCheck.Dispose();
        }
        /// <summary>
        /// Книга покупок 
        /// </summary>
        /// <param name="book">Главная книга</param>
        /// <param name="pathXlsx">Путь к файлу</param>
        /// <param name="sheetName">Наименование листа</param>
        public void AddBookSales(ref Book book, string pathXlsx, string sheetName)
        {
            var preCheck = new PreCheckAddObject();
            XlsxToDataTable.XlsxToDataTable xlsxToDataTable = new XlsxToDataTable.XlsxToDataTable();
            var dataTable = xlsxToDataTable.GetDateTableXslx(pathXlsx, sheetName, 1, 3);
            dataTable.Columns.Remove(dataTable.Columns[0]);
            DataNamesMapper<BookSales> mapper = new DataNamesMapper<BookSales>();
            var bookSales = new ArrayBodyDoc() { BookSales = mapper.Map(dataTable).ToArray() };
            preCheck.AddBookSales(ref book, bookSales);
            preCheck.Dispose();
        }
        /// <summary>
        /// Книга продажи
        /// </summary>
        /// <param name="book">Главная книга</param>
        /// <param name="pathXlsx">Путь к файлу</param>
        /// <param name="sheetName">Наименование листа</param>
        public void AddBookPurchase(ref Book book, string pathXlsx, string sheetName)
        {
            var preCheck = new PreCheckAddObject();
            XlsxToDataTable.XlsxToDataTable xlsxToDataTable = new XlsxToDataTable.XlsxToDataTable();
            var dataTable = xlsxToDataTable.GetDateTableXslx(pathXlsx, sheetName, 1, 3);
            dataTable.Columns.Remove(dataTable.Columns[0]);
            DataNamesMapper<EfDatabaseAutomation.Automation.BaseLogica.XsdShemeSqlLoad.XsdAllBodyData.BookPurchase> mapper = new DataNamesMapper<EfDatabaseAutomation.Automation.BaseLogica.XsdShemeSqlLoad.XsdAllBodyData.BookPurchase>();
            var bookPurchase = new ArrayBodyDoc() { BookPurchase = mapper.Map(dataTable).ToArray() };
            preCheck.AddBookPurchase(ref book, bookPurchase);
            preCheck.Dispose();
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
            var listDeclarationDataFace = new ArrayBodyDoc() {DeclarationData = new EfDatabaseAutomation.Automation.BaseLogica.XsdShemeSqlLoad.XsdAllBodyData.DeclarationData[data.Rows.Count] };
            var i = 0;
            foreach (DataRow row in data.Rows)
            {
                listDeclarationDataFace.DeclarationData[i] = new EfDatabaseAutomation.Automation.BaseLogica.XsdShemeSqlLoad.XsdAllBodyData.DeclarationData()
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
        /// Раскладка деклараций по другой модели
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        /// <param name="declarationAll">Декларация</param>
        public void AddDeclarationDataAll(string fileName, DeclarationAll declarationAll)
        {
            PreCheckAddObject preCheck = new PreCheckAddObject();
            var connectionString = string.Format($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={fileName}; Extended Properties=Excel 12.0;");
            var adapter = new OleDbDataAdapter("Select * From [Sheet0$]", connectionString);
            var ds = new DataSet();
            adapter.Fill(ds, "DeclarationAll");
            DataTable data = ds.Tables["DeclarationAll"];
            var listDeclarationDataFace = new ArrayBodyDoc() { DeclarationDataAll = new EfDatabaseAutomation.Automation.BaseLogica.XsdShemeSqlLoad.XsdAllBodyData.DeclarationDataAll[data.Rows.Count] };
            var i = 0;
            foreach (DataRow row in data.Rows)
            {
                listDeclarationDataFace.DeclarationDataAll[i] = new EfDatabaseAutomation.Automation.BaseLogica.XsdShemeSqlLoad.XsdAllBodyData.DeclarationDataAll()
                {
                    RegNumDecl = declarationAll.RegNumDecl,
                    CodeString = row.Field<string>("Код строки"),
                    NameParametr = row.Field<string>("Наименование показателя"),
                    CodeParametr = row.Field<string>("Код показателя"),
                    DataFace = row.Field<string>("По данным плательщика"),
                    DataInspector = row.Field<string>("По данным инспектора"),
                    Error = row.Field<string>("Отклонение")
                };
                i++;
            }
            preCheck.AddDeclarationAllModel(declarationAll, listDeclarationDataFace);
            preCheck.Dispose();
        }
        /// <summary>
        /// Сумма расхождения
        /// </summary>
        /// <param name="regNumDecl">Регистрационный номер декларации</param>
        /// <returns></returns>
        public decimal DeclarationSumError(int regNumDecl)
        {
            PreCheckAddObject preCheck = new PreCheckAddObject();
            var sum = preCheck.SumDeclaration(regNumDecl);
            preCheck.Dispose();
            return sum;
        }
        /// <summary>
        /// Добавление объектов собственности Руководителей и учередителей
        /// </summary>
        /// <param name="aisData">Модель для сервера</param>
        /// <param name="innFl">Инн ЮЛ</param>
        /// <param name="memos">Поля</param>
        /// <param name="pathXlsx">Путь к Temp</param>
        /// <param name="sheetName">Наименование Листа</param>
        /// <param name="typeObject">Тип объекта (имущество,земля,транспорт)</param>
        public void AddObjectFl(ref AisParsedData aisData, string innFl, string[] memos, string pathXlsx, string sheetName, string typeObject)
        {
            PreCheckAddObject preCheck = new PreCheckAddObject();
            XlsxToDataTable.XlsxToDataTable xlsxToDataTable = new XlsxToDataTable.XlsxToDataTable();
            var dataTable = xlsxToDataTable.GetDateTableXslxFormatNodDouble(pathXlsx, sheetName);
            foreach (DataRow row in dataTable.Rows)
            {
                var dictionary = new Dictionary<string, string>();
                ImZmTrFl imZmTrFl = new ImZmTrFl();
                foreach (var memo in memos)
                {
                    var value = row[memo].ToString();
                    dictionary.Add(memo, value);
                    switch (memo)
                    {
                        case "УН объекта учета ФЛ":
                            imZmTrFl.IdNum = Convert.ToInt64(value);
                            break;
                        case "Наименование объекта учета":
                            imZmTrFl.NameObject = value;
                            break;
                        case "Причина постановки на учет":
                            imZmTrFl.ReasonSettingStart = value;
                            break;
                        case "Дата первичной постановки на учет":
                            imZmTrFl.DateOne = ConvertDateTimeXlsxToUser(value);
                            break;
                        case "Дата постановки на учет в данном НО":
                            imZmTrFl.DateStart = ConvertDateTimeXlsxToUser(value);
                            break;
                        case "Дата фактической постановки на учет":
                            imZmTrFl.DateFactStart = ConvertDateTimeXlsxToUser(value);
                            break;
                        case "Причина снятия с учета":
                            imZmTrFl.ReasonSettingFinish = value;
                            break;
                        case "Дата окончательного снятия с учета":
                            imZmTrFl.DateFinish = ConvertDateTimeXlsxToUser(value);
                            break;
                        case "Дата снятия с учета в данном НО":
                            imZmTrFl.DateFinishNo = ConvertDateTimeXlsxToUser(value);
                            break;
                        case "Дата фактического снятия с учета в данном НО":
                            imZmTrFl.DateFactFinish = ConvertDateTimeXlsxToUser(value);
                            break;
                        case "Адрес места нахождения объекта собственности":
                            imZmTrFl.AddresObject = value;
                            break;
                    }
                }
                aisData.Data.Add(dictionary);
                preCheck.AddImZmTrFl(imZmTrFl, innFl, typeObject);
            }
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
            var listDeclarationDataFace = new ArrayBodyDoc() {StatementData = null};
            var listStatementFull = new List<StatementData>();
            foreach (string line in rtb.Lines)
            {
                if (isRead)
                {
                    var textSplit = line.Split('\t');
                    //Формирование заголовка выписки
                    if (textSplit.Length == 2)
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
                    if (textSplit.Length == 4)
                    {
                        if (!string.IsNullOrWhiteSpace(textSplit[0]))
                        {
                            //Собираем коллекцию с учетом  IdStatementHead и УН ЮЛ и записываем в БД
                            listStatementFull.Add(new StatementData()
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
                if (line.Equals("1\t2\t3\t"))
                    isRead = true;
            }
            listDeclarationDataFace.StatementData = listStatementFull.ToArray();
            preCheck.AddStatementFull(listDeclarationDataFace, innUl);
            preCheck.Dispose();
            rtb.Dispose();
        }


        public DataTable SelectXslx(string pathXlsx, string sheetName)
        {
            var connectionString = string.Format($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={pathXlsx}; Extended Properties=Excel 12.0;");
            var adapter = new OleDbDataAdapter($"Select * From [{sheetName}$]", connectionString);
            var ds = new DataSet();
            adapter.Fill(ds, "Declaration");
            DataTable data = ds.Tables["Declaration"];
            return data;
        }
        /// <summary>
        /// Конвертация Даты с XLSX
        /// </summary>
        /// <param name="value">Строка даты с xlsx</param>
        /// <returns>Дата</returns>
        public DateTime? ConvertDateTimeXlsxToUser(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            DateTime dateParse;
            try
            {
                var dateExtract = DateTime.ParseExact(value, "MM-dd-yy", CultureInfo.InvariantCulture).ToString("dd.MM.yyyy");
                if (DateTime.TryParse(dateExtract, out dateParse))
                {
                    return dateParse;
                }
            }
            catch
            {
                try
                {
                    if (DateTime.TryParse(value, out dateParse))
                    {
                        return dateParse;
                    }
                }
                catch
                {
                    IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
                    double date = double.Parse(value, formatter);
                    DateTime convDate = DateTime.FromOADate(date);
                    return convDate;
                }
            }
            return null;
        }
        /// <summary>
        /// Выгрузка первой 1000 для отработки
        /// </summary>
        /// <returns></returns>
        public IsPatentParse[] PatentExportFull()
        {
            PreCheckAddObject preCheck = new PreCheckAddObject();
            return preCheck.PatentExportFull();
        }

        /// <summary>
        /// Добавление патента и лица в БД
        /// </summary>
        /// <param name="face">Лицо</param>
        /// <param name="patent">Патент</param>
        public IsPatentParse AddFlFaceAndPatent(FlFaceMain face,ref Patent patent)
        {
            PreCheckAddObject preCheck = new PreCheckAddObject();
            return preCheck.AddFlFaceAndPatent(face, ref patent);
        }
        /// <summary>
        /// Обновление модели патента в работе
        /// </summary>
        /// <param name="isParseModel">Модель в работе</param>
        public void UpdateIsParseModel(IsPatentParse isParseModel)
        {
            PreCheckAddObject preCheck = new PreCheckAddObject();
            preCheck.UpdateIsParsePatent(isParseModel);
        }
        /// <summary>
        /// Загрузка документа патента
        /// </summary>
        /// <param name="patent">Патент</param>
        /// <param name="pathXlsx">Путь к xlsx</param>
        /// <param name="sheetName">Наименование листа</param>
        public void AddDocPatent(Patent patent, string pathXlsx, string sheetName)
        {
            PreCheckAddObject preCheckLoad = new PreCheckAddObject();
            var connectionString = string.Format($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={pathXlsx}; Extended Properties=Excel 12.0;");
            var adapter = new OleDbDataAdapter($"Select * From [{sheetName}$]", connectionString);
            var ds = new DataSet();
            adapter.Fill(ds, "DocPatent");
            DataTable dataTable = ds.Tables["DocPatent"];
            DataNamesMapper<EfDatabaseAutomation.Automation.BaseLogica.XsdShemeSqlLoad.XsdAllBodyData.DocPatent> mapper = new DataNamesMapper<EfDatabaseAutomation.Automation.BaseLogica.XsdShemeSqlLoad.XsdAllBodyData.DocPatent>();
            var listDoc = new ArrayBodyDoc() { DocPatent = mapper.Map(dataTable).ToArray() };
            listDoc.DocPatent.ToList().ForEach(doc => doc.IdPatent = patent.IdPatent);
            preCheckLoad.AddDocPatent(listDoc);
            preCheckLoad.Dispose();
        }
        /// <summary>
        /// Загрузка сведений о месте осуществления деятельности
        /// </summary>
        /// <param name="patent">Патент</param>
        /// <param name="pathXlsx">Путь к xlsx</param>
        /// <param name="sheetName">Наименование листа</param>
        public void AddPlaceOfBusiness(Patent patent, string pathXlsx, string sheetName)
        {
            PreCheckAddObject preCheckLoad = new PreCheckAddObject();
            XlsxToDataTable.XlsxToDataTable xlsxToDataTable = new XlsxToDataTable.XlsxToDataTable();
            var dataTable = xlsxToDataTable.GetDateTableXslx(pathXlsx, sheetName);
            DataNamesMapper<EfDatabaseAutomation.Automation.BaseLogica.XsdShemeSqlLoad.XsdAllBodyData.PlaceOfBusiness> mapper = new DataNamesMapper<EfDatabaseAutomation.Automation.BaseLogica.XsdShemeSqlLoad.XsdAllBodyData.PlaceOfBusiness>();
            var listDoc = new ArrayBodyDoc() { PlaceOfBusiness = mapper.Map(dataTable).ToArray() };
            listDoc.PlaceOfBusiness.ToList().ForEach(doc => doc.IdPatent = patent.IdPatent);
            preCheckLoad.AddPlaceOfBusiness(listDoc);
            preCheckLoad.Dispose();
        }
        /// <summary>
        /// Загрузка сведений о транспортных средствах
        /// </summary>
        /// <param name="patent">Патент</param>
        /// <param name="pathXlsx">Путь к xlsx</param>
        /// <param name="sheetName">Наименование листа</param>
        public void AddSvedTr(Patent patent, string pathXlsx, string sheetName)
        {
            PreCheckAddObject preCheckLoad = new PreCheckAddObject();
            XlsxToDataTable.XlsxToDataTable xlsxToDataTable = new XlsxToDataTable.XlsxToDataTable();
            var dataTable = xlsxToDataTable.GetDateTableXslx(pathXlsx, sheetName);
            DataNamesMapper<EfDatabaseAutomation.Automation.BaseLogica.XsdShemeSqlLoad.XsdAllBodyData.SvedTr> mapper = new DataNamesMapper<EfDatabaseAutomation.Automation.BaseLogica.XsdShemeSqlLoad.XsdAllBodyData.SvedTr>();
            var listDoc = new ArrayBodyDoc() { SvedTr = mapper.Map(dataTable).ToArray() };
            listDoc.SvedTr.ToList().ForEach(doc => doc.IdPatent = patent.IdPatent);
            preCheckLoad.AddSvedTr(listDoc);
            preCheckLoad.Dispose();
        }
        /// <summary>
        /// Загрузка сведений об обособленных объектах
        /// </summary>
        /// <param name="patent">Патент</param>
        /// <param name="pathXlsx">Путь к xlsx</param>
        /// <param name="sheetName">Наименование листа</param>
        public void AddSvedObject(Patent patent, string pathXlsx, string sheetName)
        {
            PreCheckAddObject preCheckLoad = new PreCheckAddObject();
            XlsxToDataTable.XlsxToDataTable xlsxToDataTable = new XlsxToDataTable.XlsxToDataTable();
            var dataTable = xlsxToDataTable.GetDateTableXslx(pathXlsx, sheetName);
            DataNamesMapper<EfDatabaseAutomation.Automation.BaseLogica.XsdShemeSqlLoad.XsdAllBodyData.SvedObject> mapper = new DataNamesMapper<EfDatabaseAutomation.Automation.BaseLogica.XsdShemeSqlLoad.XsdAllBodyData.SvedObject>();
            var listDoc = new ArrayBodyDoc() { SvedObject = mapper.Map(dataTable).ToArray() };
            listDoc.SvedObject.ToList().ForEach(doc => doc.IdPatent = patent.IdPatent);
            preCheckLoad.AddSvedObject(listDoc);
            preCheckLoad.Dispose();
        }
        /// <summary>
        /// Загрузка параметров расчета налога
        /// </summary>
        /// <param name="patent">Патент</param>
        /// <param name="pathXlsx">Путь к xlsx</param>
        /// <param name="sheetName">Наименование листа</param>
        public void AddParametrNalog(Patent patent, string pathXlsx, string sheetName)
        {
            PreCheckAddObject preCheckLoad = new PreCheckAddObject();
            XlsxToDataTable.XlsxToDataTable xlsxToDataTable = new XlsxToDataTable.XlsxToDataTable();
            var dataTable = xlsxToDataTable.GetDateTableXslx(pathXlsx, sheetName);
            DataNamesMapper<EfDatabaseAutomation.Automation.BaseLogica.XsdShemeSqlLoad.XsdAllBodyData.ParametrNalog> mapper = new DataNamesMapper<EfDatabaseAutomation.Automation.BaseLogica.XsdShemeSqlLoad.XsdAllBodyData.ParametrNalog>();
            var listDoc = new ArrayBodyDoc() { ParametrNalog = mapper.Map(dataTable).ToArray() };
            listDoc.ParametrNalog.ToList().ForEach(doc => doc.IdPatent = patent.IdPatent);
            preCheckLoad.AddParametrNalog(listDoc);
            preCheckLoad.Dispose();
        }
        /// <summary>
        /// Загрузка сведений по фактическому действию патента
        /// </summary>
        /// <param name="patent">Патент</param>
        /// <param name="pathXlsx">Путь к xlsx</param>
        /// <param name="sheetName">Наименование листа</param>
        public void AddSvedFactPatent(Patent patent, string pathXlsx, string sheetName)
        {
            PreCheckAddObject preCheckLoad = new PreCheckAddObject();
            XlsxToDataTable.XlsxToDataTable xlsxToDataTable = new XlsxToDataTable.XlsxToDataTable();
            var dataTable = xlsxToDataTable.GetDateTableXslx(pathXlsx, sheetName);
            DataNamesMapper<EfDatabaseAutomation.Automation.BaseLogica.XsdShemeSqlLoad.XsdAllBodyData.SvedFactPatent> mapper = new DataNamesMapper<EfDatabaseAutomation.Automation.BaseLogica.XsdShemeSqlLoad.XsdAllBodyData.SvedFactPatent>();
            var listDoc = new ArrayBodyDoc() { SvedFactPatent = mapper.Map(dataTable).ToArray() };
            listDoc.SvedFactPatent.ToList().ForEach(doc => doc.IdPatent = patent.IdPatent);
            preCheckLoad.AddSvedFactPatent(listDoc);
            preCheckLoad.Dispose();
        }
    }
}
