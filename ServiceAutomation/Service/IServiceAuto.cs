using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Threading.Tasks;
using AisPoco.Ifns51.FromAis;
using AisPoco.Ifns51.ToAis;
using EfDatabaseAutomation.Automation.Base;
using EfDatabaseAutomation.Automation.BaseLogica.IdentificationFace;
using EfDatabaseAutomation.Automation.BaseLogica.UploadFile;
using EfDatabaseAutomation.Automation.SelectParametrSheme;
using ServiceAutomation.LoginAD.XsdShemeLogin;
using LogicsSelectAutomation = EfDatabaseAutomation.Automation.SelectParametrSheme.LogicsSelectAutomation;

namespace ServiceAutomation.Service
{
    [ServiceContract]
    interface IServiceAuto
    {
        /// <summary>
        /// http://localhost:8050/ServiceAutomation/Identification
        /// Авторизация на сайте статистики
        /// </summary>
        /// <returns>Авторизация на сайте статистики</returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/Identification", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<Identification> Identification(Identification identification);

        /// <summary>
        /// http://localhost:8050/ServiceAutomation/GenerateSqlSelect
        /// Генерация запросов на клиент
        /// </summary>
        /// <returns></returns>
        /// <param name="model">Модель</param>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/GenerateSqlSelect", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<ModelSelect> GenerateSqlSelect(ModelSelect model);

        /// <summary>
        /// Запрос на получение данных
        /// http://localhost:8050/ServiceAutomation/Select
        /// </summary>
        /// <param name="sqlSelect">Запрос</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/Select", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<string> Select(LogicsSelectAutomation sqlSelect);
        /// <summary>
        /// Запрос на вытягивание данных по процедуре выборке
        /// http://localhost:8050/ServiceAutomation/ResultSelectProcedure
        /// </summary>
        /// <param name="model">Модель запроса по процедуре</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/ResultSelectProcedure", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<ModelSelect> ResultSelectProcedure(ModelSelect model);
        /// <summary>
        /// Выгрузка файла для ОКП 2
        /// http://localhost:8050/ServiceAutomation/LoadFileTaxJournal
        /// </summary>
        /// <param name="numberElement">Запрос</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/LoadFileTaxJournal", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<Stream> LoadFileTaxJournal(int numberElement);
        /// <summary>
        /// Выгрузка файла для ОКП 2 121 статья
        /// http://localhost:8050/ServiceAutomation/LoadFileTax121
        /// </summary>
        /// <param name="numberElement">Запрос</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/LoadFileTax121", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<Stream> LoadFileTax121(int numberElement);
        /// <summary>
        /// Выгрузка файла для ОКП 1 ЕАЭС-обмен
        /// http://localhost:8050/ServiceAutomation/LoadFileEasJournal
        /// </summary>
        /// <param name="numberElement">Ун записи</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/LoadFileEasJournal", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<Stream> LoadFileEasJournal(int numberElement);
        /// <summary>
        /// Добавление ИНН для ввода
        /// http://localhost:8050/ServiceAutomation/AddInnToModel
        /// </summary>
        /// <param name="templateModel">Шаблон для добавления</param>
        /// <param name="userIdGuid">GUID Пользователя</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AddInnToModel?userIdGuid={userIdGuid}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task AddInnToModel(TemplateProcedure templateModel, string userIdGuid);
        /// <summary>
        /// Получение всех шаблонов в БД
        /// http://localhost:8050/ServiceAutomation/LoadAllTemplateDb
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, UriTemplate = "/LoadAllTemplateDb", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<TemplateModel> LoadAllTemplateDb();
        /// <summary>
        /// Получение данных что отрабатывать
        /// http://localhost:8050/ServiceAutomation/LoadModelPreCheck
        /// </summary>
        /// <param name="idTemplate">Уникальные номера шаблонов в виде строки 1,2,3,4</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, UriTemplate = "/LoadModelPreCheck?idTemplate={idTemplate}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<LibaryXMLAutoModelXmlSql.PreCheck.Ifns51.FromAis.SrvToLoad> LoadModelPreCheck(string idTemplate);
        /// <summary>
        /// Постановка статуса что данные отработаны
        /// http://localhost:8050/ServiceAutomation/LoadModelPreCheck
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/LoadModelPreCheck", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string LoadModelPreCheckModel(AisParsedData model);

        /// <summary>
        /// Снять статус для повторения отработки
        /// http://localhost:8050/ServiceAutomation/CheckStatusNone
        /// </summary>
        /// <param name="idModels">Уникальные номера моделей</param>
        /// <param name="status">Статус обработки ветки</param>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/CheckStatusNone?status={status}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task CheckStatus(List<int> idModels, string status=null);
        /// <summary>
        /// Генерация докладной записки Юридического лица
        /// </summary>
        /// <param name="innUl">ИНН ЮЛ</param>
        /// <param name="year">Год отчета выгрузки</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/GenerateNoteReportUl?year={year}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<Stream> GenerateNoteReportUl(string innUl, int year);

        /// <summary>
        /// Генерация доходов и расходов по банку книги покупок продаж
        /// </summary>
        /// <param name="innUl">ИНН ЮЛ</param>
        /// <param name="year">Год отчета выгрузки</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/GenerateBookSales?year={year}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<Stream> GenerateBookSales(string innUl, int year);
        /// <summary>
        /// Генерация отчета по АСК НДС ИНН и ГОД отсчета периода 3 последних года от текущего
        /// </summary>
        /// <param name="innUl">ИНН ЮЛ</param>
        /// <param name="year">Год отчета выгрузки</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/GenerateReportAskNds?year={year}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<Stream> GenerateReportAskNds(string innUl, int year);
        /// <summary>
        /// Формирование выписки данных в БД
        /// </summary>
        /// <param name="model">Модель выписки</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/GenerateStatement", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<Stream> GenerateStatement(ModelSelect model);

        /// <summary>
        /// Генерация отчета документа на сервере
        /// </summary>
        /// <param name="sqlSelect">С генерированный запрос с клиента</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/GenerateFileXlsxSqlView", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<Stream> GenerateFileXlsxSqlView(LogicsSelectAutomation sqlSelect);
        /// <summary>
        /// Добавление файлов для обработки на автомате
        /// </summary>
        /// <param name="listIdFile">УН файлов</param>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AddFileId", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<ServiceAddFile> AddFileId(List<long> listIdFile);
        /// <summary>
        /// Снятие статуса ошибки на документе
        /// </summary>
        /// <param name="idDocument">Документ</param>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/CheckStatusError", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task CheckStatusError(List<long> idDocument);
        /// <summary>
        /// Все подписанты в БД
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AllSender", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<string> AllSender();
        /// <summary>
        /// Таблица с подписантами Акты Извещение Решения
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AllSenderTaxJournal", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<string> AllSenderTaxJournal();

        /// <summary>
        /// Добавление или редактирование Отдела и подписанта к нему
        /// </summary>
        /// <param name="department">Отдел и подписант</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AddAndEditDepartment", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<DepartamentOtdel> AddAndEditDepartment(DepartamentOtdel department);

        /// <summary>
        /// Выгрузка сводной таблицы по книгам продаж
        /// http://localhost:8050/ServiceAutomation/LoadFileSummarySales
        /// </summary>
        /// <param name="inn">Запрос</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/LoadFileSummarySales",
            ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<Stream> LoadFileSummarySales(string inn);
        /// <summary>
        /// Добавление регистрационных номеров патента для отработки
        /// http://localhost:8050/ServiceAutomation/AddRegNumberPatent
        /// </summary>
        /// <param name="templatePatent">Шаблон для добавления</param>
        /// <param name="userIdGuid">GUID Пользователя</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AddRegNumberPatent?userIdGuid={userIdGuid}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task AddRegNumberPatent(TemplatePatent templatePatent, string userIdGuid);
        /// <summary>
        /// Добавление ИНН для регистрации учетных действий
        /// http://localhost:8050/ServiceAutomation/AddFlFaceMainRegistration
        /// </summary>
        /// <param name="templateInnPattern">Шаблон для добавления</param>
        /// <param name="userIdGuid">GUID Пользователя</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AddFlFaceMainRegistration?userIdGuid={userIdGuid}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task AddFlFaceMainRegistration(TemplateInnPattern templateInnPattern, string userIdGuid);
        /// <summary>
        /// Принудительное завершение обработки!
        /// http://localhost:8050/ServiceAutomation/CheckStatusFl
        /// </summary>
        /// <param name="inn">ИНН</param>
        /// <param name="isExecute">Id ошибки</param>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/CheckStatusFl?isExecute={isExecute}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task CheckStatusFl(string inn, bool isExecute);
        /// <summary>
        /// Выгрузка файла для ОКП 6 Требования
        /// http://localhost:8050/ServiceAutomation/LoadFile3NdflRequirements
        /// </summary>
        /// <param name="numberElement">Ун записи</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/LoadFile3NdflRequirements", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<Stream> LoadFile3NdflRequirements(int numberElement);

        /// <summary>
        /// Добавление регистрационных номеров патента для отработки
        /// http://localhost:8050/ServiceAutomation/AddInnFaceRegistryReference
        /// </summary>
        /// <param name="templateInnPattern">Шаблон для добавления</param>
        /// <param name="userIdGuid">GUID Пользователя</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AddInnFaceRegistryReference?userIdGuid={userIdGuid}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task AddInnFaceRegistryReference(TemplateInnPattern templateInnPattern, string userIdGuid);
        /// <summary>
        /// Удаление записи из реестра документов
        /// http://localhost:8050/ServiceAutomation/DeleteRegistryReference
        /// </summary>
        /// <param name="inn">Ун записи</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/DeleteRegistryReference", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<string> DeleteRegistryReference(string inn);


        /// <summary>
        /// Прием файла Excel допрос свидетелей с сайта 
        /// http://localhost:8050/ServiceAutomation/AddFileModel
        /// </summary>
        /// <param name="uploadFileModel">Модель с файлами Excel</param>
        /// <param name="userIdGuid">GUID Пользователя</param>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AddFileModel?userIdGuid={userIdGuid}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<string> AddFileModel(UploadFile uploadFileModel, string userIdGuid);
        /// <summary>
        /// Все сотрудники организации
        /// http://localhost:8050/ServiceAutomation/AllUsersOrg
        /// </summary>
        /// <param name="inn">ИНН организации</param>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AllUsersOrg?inn={inn}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<string> AllUsersOrg(string inn);

        /// <summary>
        /// Все вопросы сотруднику 
        /// http://localhost:8050/ServiceAutomation/SelectQuestions?idUsers=2
        /// </summary>
        /// <param name="idUsers">Ун пользователя</param>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, UriTemplate = "/SelectQuestions?idUsers={idUsers}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]

        Task<string> SelectQuestions(int idUsers);
    }
}