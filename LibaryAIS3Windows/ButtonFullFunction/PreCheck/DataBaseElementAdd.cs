using System;
using System.Linq;
using System.Windows.Automation;
using EfDatabaseAutomation.Automation.Base;
using EfDatabaseAutomation.Automation.BaseLogica.PreCheck;
using LibaryAIS3Windows.AutomationsUI.LibaryAutomations;
using System.Text.RegularExpressions;
using LibaryAIS3Windows.AutomationsUI.Otdels.PreCheck;

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
        public void AddUlFace(LibaryAutomations libraryAutomation, AutomationElement automationElement)
        {
            UlFace uiFace = new UlFace();
            PreCheckAddObject preCheck = new PreCheckAddObject();

            uiFace.IdNum = Convert.ToInt64(Regex.Replace(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                    .SelectAutomationColrction(automationElement)
                    .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("УН ЮЛ в ЕГРН"))), @"\s+", ""));
            uiFace.Inn = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                    .SelectAutomationColrction(automationElement)
                    .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("ИНН")));

            uiFace.NameFull = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Полное наименование ЮЛ")));

            uiFace.Kpp = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("КПП ЮЛ")));


            uiFace.NameSmall = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Сокращенное наименование ЮЛ")));

            uiFace.Address = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Адрес МН ЮЛ")));

           var dateResh = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Дата принятия решения о ликвидации")));
           uiFace.DateResh = string.IsNullOrWhiteSpace(dateResh) ? null : (DateTime?)Convert.ToDateTime(dateResh);

           var dateResRegor = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>()
                .First(elem => elem.Current.Name.Contains("Дата принятия решения о реорганизации")));
           uiFace.DateReshReorg = string.IsNullOrWhiteSpace(dateResRegor) ? null : (DateTime?)Convert.ToDateTime(dateResRegor);

            preCheck.AddUlFace(uiFace);
        }
        /// <summary>
        /// Сведения об учете организации
        /// Для ветки Налоговое администрирование\Централизованный учет налогоплательщиков\01. ЕГРН - российские организации\1.03. Сведения об учете организации в НО
        /// </summary>
        /// <param name="libraryAutomation">Библиотека Автоматизации</param>
        /// <param name="automationElement">Автоматизированный элемент</param>
        /// <param name="innUl">Инн ЮЛ</param>
        public void AddSvedAccoutingUlFace(LibaryAutomations libraryAutomation, AutomationElement automationElement, string innUl)
        {
            SvedAccoutingUlFace svedAccoutingUlFace = new SvedAccoutingUlFace();
            PreCheckAddObject preCheck = new PreCheckAddObject();

            svedAccoutingUlFace.IdNum = Convert.ToInt64(Regex.Replace(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                    .SelectAutomationColrction(automationElement)
                    .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("УН записи об учете ЮЛ в НО"))), @"\s+", ""));

            svedAccoutingUlFace.TypeObject = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Тип объекта учета")));

            svedAccoutingUlFace.Kpp = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("КПП")));

            svedAccoutingUlFace.NameObject = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Наименование объекта учета")));

            svedAccoutingUlFace.AddressObject = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                 .SelectAutomationColrction(automationElement)
                 .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Адрес объекта учета")));

            svedAccoutingUlFace.CodeNalog = Convert.ToInt32(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                 .SelectAutomationColrction(automationElement)
                 .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Код НО по месту учета"))));

            var dateBegin = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                 .SelectAutomationColrction(automationElement)
                 .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Дата постановки на учет")));
            svedAccoutingUlFace.DateBegin = string.IsNullOrWhiteSpace(dateBegin) ? null : (DateTime?)Convert.ToDateTime(dateBegin);

            var dateFactBegin = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                 .SelectAutomationColrction(automationElement)
                 .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Дата фактической постановки на учет")));
            svedAccoutingUlFace.DateFactBegin = string.IsNullOrWhiteSpace(dateFactBegin) ? null : (DateTime?)Convert.ToDateTime(dateFactBegin);

            svedAccoutingUlFace.CodeSppuno = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                 .SelectAutomationColrction(automationElement)
                 .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Код по СППУНО")));

            svedAccoutingUlFace.CauseBegin = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                  .SelectAutomationColrction(automationElement)
                  .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Причина постановки на учет")));

            var dateEnd = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                  .SelectAutomationColrction(automationElement)
                  .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Дата снятия с учета")));
            svedAccoutingUlFace.DateEnd = string.IsNullOrWhiteSpace(dateEnd) ? null : (DateTime?)Convert.ToDateTime(dateEnd);

            var dateFactEnd = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                  .SelectAutomationColrction(automationElement)
                  .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Дата фактического снятия с учета")));
            svedAccoutingUlFace.DateFactEnd = string.IsNullOrWhiteSpace(dateFactEnd) ? null : (DateTime?)Convert.ToDateTime(dateFactEnd);

            svedAccoutingUlFace.CodeSppunoEnd = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                  .SelectAutomationColrction(automationElement)
                  .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Код по СПСУНО")));

            svedAccoutingUlFace.CauseEnd = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                  .SelectAutomationColrction(automationElement)
                  .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Причина снятия с учета")));

            preCheck.AddSvedAccoutingUlFace(svedAccoutingUlFace, innUl);
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
        }

        /// <summary>
        /// Добавление имущества ЮЛ
        /// Налоговое администрирование\Централизованный учет налогоплательщиков\01. ЕГРН - российские организации\1.18. Сведения об объектах собственности российской организации – имущество
        /// </summary>
        /// <param name="libraryAutomation">Библиотека Автоматизации</param>
        /// <param name="automationElement">Автоматизированный элемент</param>
        /// <param name="innUl">Инн ЮЛ</param>
        public void AddPropertyUlFace(LibaryAutomations libraryAutomation, AutomationElement automationElement, string innUl)
        {
            PropertyUlFace propertyUlFace = new PropertyUlFace();
            PreCheckAddObject preCheck = new PreCheckAddObject();

            propertyUlFace.IdNum = Convert.ToInt64(Regex.Replace(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                    .SelectAutomationColrction(automationElement)
                    .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("УН объекта учета ЮЛ"))), @"\s+", ""));

            propertyUlFace.TypeObject = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Наименование объекта учета")));

            var dateStartStaging = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Наименование объекта учета")));
            propertyUlFace.DateStartStaging = string.IsNullOrWhiteSpace(dateStartStaging) ? null : (DateTime?)Convert.ToDateTime(dateStartStaging);

            var dateFinishStaging = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Дата окончательного снятия с учета")));
            propertyUlFace.DateFinishStaging = string.IsNullOrWhiteSpace(dateFinishStaging) ? null : (DateTime?)Convert.ToDateTime(dateFinishStaging);

            propertyUlFace.AddressObject = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Адрес места нахождения объекта собственности")));

            preCheck.AddPropertyUlFace(propertyUlFace, innUl);
        }

        /// <summary>
        /// Добавление земля ЮЛ
        /// Налоговое администрирование\Централизованный учет налогоплательщиков\01. ЕГРН - российские организации\1.19. Сведения об объектах собственности российской организации – земля
        /// </summary>
        /// <param name="libraryAutomation">Библиотека Автоматизации</param>
        /// <param name="automationElement">Автоматизированный элемент</param>
        /// <param name="innUl">Инн ЮЛ</param>
        public void AddLandUlFace(LibaryAutomations libraryAutomation, AutomationElement automationElement, string innUl)
        {
            LandUlFace landUlFace = new LandUlFace();
            PreCheckAddObject preCheck = new PreCheckAddObject();

            landUlFace.IdNum = Convert.ToInt64(Regex.Replace(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("УН объекта учета ЮЛ"))), @"\s+", ""));

            landUlFace.TypeObject = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Наименование объекта учета")));

            var dateStartStaging = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Дата первичной постановки на учет")));
            landUlFace.DateStartStaging = string.IsNullOrWhiteSpace(dateStartStaging) ? null : (DateTime?)Convert.ToDateTime(dateStartStaging);

            var dateFinishStaging = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Дата окончательного снятия с учета")));
            landUlFace.DateFinishStaging = string.IsNullOrWhiteSpace(dateFinishStaging) ? null : (DateTime?)Convert.ToDateTime(dateFinishStaging);

            landUlFace.AddressObject = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Адрес места нахождения объекта собственности")));

            preCheck.AddLandUlFace(landUlFace, innUl);

        }

        /// <summary>
        /// Добавление земля ЮЛ
        /// Налоговое администрирование\Централизованный учет налогоплательщиков\01. ЕГРН - российские организации\1.20. Сведения об объектах собственности российской организации – транспорт
        /// </summary>
        /// <param name="libraryAutomation">Библиотека Автоматизации</param>
        /// <param name="automationElement">Автоматизированный элемент</param>
        /// <param name="innUl">Инн ЮЛ</param>
        public void AddTransportUlFace(LibaryAutomations libraryAutomation, AutomationElement automationElement, string innUl)
        {
            TransportUlFace transportUlFace = new TransportUlFace();
            PreCheckAddObject preCheck = new PreCheckAddObject();

            transportUlFace.IdNum = Convert.ToInt64(Regex.Replace(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("УН объекта учета ЮЛ"))), @"\s+", ""));

            transportUlFace.TypeObject = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Наименование объекта учета")));

            var dateStartStaging = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Дата первичной постановки на учет")));
            transportUlFace.DateStartStaging = string.IsNullOrWhiteSpace(dateStartStaging) ? null : (DateTime?)Convert.ToDateTime(dateStartStaging);

            var dateFinishStaging = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Дата окончательного снятия с учета")));
            transportUlFace.DateFinishStaging = string.IsNullOrWhiteSpace(dateFinishStaging) ? null : (DateTime?)Convert.ToDateTime(dateFinishStaging);


            transportUlFace.AddressObject = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Адрес места нахождения объекта собственности")));

            preCheck.AddTransportUlFace(transportUlFace, innUl);

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
            CashUlFace cashUlFace = new CashUlFace();
            PreCheckAddObject preCheck = new PreCheckAddObject();

            cashUlFace.IdNum = Convert.ToInt64(Regex.Replace(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Счет: Регномер"))), @"\s+", ""));

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


            cashUlFace.TypeCash =libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                .SelectAutomationColrction(automationElement)
                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Счет: Вид")));

            preCheck.AddCashUlFace(cashUlFace, innUl);

        }
        /// <summary>
        /// 7. Индивидуальные карточки налогоплательщиков АКВЕД
        /// </summary>
        /// <param name="libraryAutomation">Библиотека Автоматизации</param>
        /// <param name="innUl">ИНН</param>
        public void AddIndividualCardsUlFace(LibaryAutomations libraryAutomation, string innUl)
        {
            IndividualCardsUlFace cardsUlFace = new IndividualCardsUlFace();
            PreCheckAddObject preCheck = new PreCheckAddObject();
            var acvedCode = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(PreCheckElementNameIndividualCards.PanelElementOkvedCode));
            var acvedName = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(PreCheckElementNameIndividualCards.PanelElementOkvedName));
            cardsUlFace.Acved = string.Concat(acvedCode, " - ", acvedName);
            cardsUlFace.GroupOrg = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(PreCheckElementNameIndividualCards.PanelElementOrgScale));
            cardsUlFace.Segment = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(PreCheckElementNameIndividualCards.PanelElementtxtOsn));
            preCheck.AddIndividualCardsUlFace(cardsUlFace, innUl);
        }

        public void AddRaschetCard(LibaryAutomations libraryAutomation, AutomationElement automationElement, string innUl)
        {
            
            PreCheckAddObject preCheck = new PreCheckAddObject();
            double doubleNum;
            var cardParametr = libraryAutomation.SelectAutomationColrction(automationElement).Cast<AutomationElement>().Where(automationElemenst => automationElemenst.Current.Name != "Column Headers" && automationElemenst.Current.Name != "Наименование показателя").ToList();
            foreach(var param in cardParametr)
            {
                if (Double.TryParse(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(param),out doubleNum))
                {
                   IndividualNameParametr raschetCard = new IndividualNameParametr();
                   raschetCard.NameParametr = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                           .SelectAutomationColrction(automationElement)
                                           .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Наименование показателя")));
                   raschetCard.Years = Convert.ToInt32(param.Current.Name);
                   raschetCard.Parametr = doubleNum;
                   preCheck.AddIndividualNameParametr(raschetCard, innUl);
                }
            }
        }

        ///// <summary>
        ///// Добавление Банковские выписки, справки ЮЛ
        ///// </summary>
        ///// <param name="libraryAutomation">Библиотека Автоматизации</param>
        ///// <param name="automationElement">Автоматизированный элемент</param>
        ///// <param name="innUl">Инн ЮЛ</param>
        //public void AddCashBankAllUlFace(LibaryAutomations libraryAutomation, AutomationElement automationElement, string innUl)
        //{
        //    CashBankAllUlFace cashBankAllUlFace = new CashBankAllUlFace();
        //    PreCheckAddObject preCheck = new PreCheckAddObject();

        //    cashBankAllUlFace.NumberCash

        //    cashBankAllUlFace.DateWay

        //    cashBankAllUlFace.CodeNo

        //    cashBankAllUlFace.DateGetting

        //    cashBankAllUlFace.NameBank

        //    cashBankAllUlFace.CashNumber

        //    cashBankAllUlFace.DateStartPeriod

        //    cashBankAllUlFace.DateFinishPeriod


        //}
    }
}
