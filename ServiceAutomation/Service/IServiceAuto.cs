using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Threading.Tasks;
using EfDatabaseAutomation.Automation.BaseLogica.XsdAuto.FullShemeModel;
using EfDatabaseAutomation.Automation.SelectParametrSheme;
using Ifns51.FromAis;
using Ifns51.ToAis;
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
        /// Добавление ИНН для ввода
        /// http://localhost:8050/ServiceAutomation/AddInnToModel
        /// </summary>
        /// <param name="inn">ИНН для ввода</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/AddInnToModel", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string AddInnToModel(string inn);
        /// <summary>
        /// Получение данных что отрабатывать
        /// http://localhost:8050/ServiceAutomation/LoadModelPreCheck
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, UriTemplate = "/LoadModelPreCheck", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        List<SrvToLoad> LoadModelPreCheck();
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
        /// <param name="idModel">Ун модели</param>
        /// <param name="status">Статус обработки ветки</param>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/CheckStatusNone?status={status}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        void CheckStatus(int idModel, string status=null);
        /// <summary>
        /// Генерация докладной записки Юридического лица
        /// </summary>
        /// <param name="innUl">ИНН ЮЛ</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/GenerateNoteReportUl", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<Stream> GenerateNoteReportUl(string innUl);
        /// <summary>
        /// Формирование выписки данных в БД
        /// </summary>
        /// <param name="model">Модель выписки</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/GenerateStatement", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<Stream> GenerateStatement(ModelSelect model);
        /// <summary>
        /// Формирование выписки данных в БД
        /// </summary>
        /// <param name="signatureSenderTaxJournalOkp2">Ун подписи</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/ActualizationSignature", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<bool> ActualizationSignature(int signatureSenderTaxJournalOkp2);
    }
}
