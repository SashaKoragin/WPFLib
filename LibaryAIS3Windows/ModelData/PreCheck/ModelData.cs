using LibaryXMLAuto.ReadOrWrite.SerializationJson;
using System;
using System.IO;
using System.Net;
using System.Text;
using EfDatabaseAutomation.Automation.BaseLogica.SqlSelect.PreCheckLog;

namespace LibraryAIS3Windows.ModelData.PreCheck
{
    public class HttpGetAndPost
    {

        /// <summary>
        /// Отправка запроса на сервер
        /// </summary>
        /// <param name="serviceAddress">Сервисный адрес</param>
        /// <param name="requestType">Тип объекта класса</param>
        /// <returns></returns>
        public string ResultPost(string serviceAddress, object requestType)
        {
            try
            {
                var json = new SerializeJson();
                var js = json.JsonLibary(requestType);
                var body = Encoding.UTF8.GetBytes(js);
                var request = (HttpWebRequest)WebRequest.Create(serviceAddress);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = body.Length;
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(body, 0, body.Length);
                    stream.Close();
                }
                var response = (HttpWebResponse)request.GetResponse();
                response.Close();
                if (response.StatusCode == HttpStatusCode.Gone)
                {
                    var log = new SqlPreCheckLog();
                    log.AddTaxJournal(Environment.UserName, "POST", HttpStatusCode.Gone.ToString(), "Возникла фатальная ошибка 410!");
                }
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var log = new SqlPreCheckLog();
                    log.AddTaxJournal(Environment.UserName, "POST", HttpStatusCode.OK.ToString(), "Все хорошо!");
                    return "ОК!";
                }
                if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    var log = new SqlPreCheckLog();
                    log.AddTaxJournal(Environment.UserName, "POST", HttpStatusCode.BadRequest.ToString(), "Данные не проходят проверку!");
                    return "ОК!";
                }
                return null;
            }
            catch (Exception e)
            {
                //Лог ошибки
                var log = new SqlPreCheckLog();
                log.AddTaxJournal(Environment.UserName, "POST", "Ошибка", e.ToString());
                return null;
            }
        }
    }
}
