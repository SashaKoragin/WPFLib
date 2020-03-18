using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Threading.Tasks;
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
        /// Выгрузка файла для ОКП 2
        /// http://localhost:8050/ServiceAutomation/LoadFileTaxJournal
        /// </summary>
        /// <param name="numberElement">Запрос</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/LoadFileTaxJournal", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<Stream> LoadFileTaxJournal(int numberElement);
    }
}
