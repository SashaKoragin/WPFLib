using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using LibaryXMLAuto.Converts.ConvettToXml;
using ViewModelLib.ModelTestAutoit.ModelSnuOneAuto.DataXml;
using ViewModelLib.ModelTestAutoit.PublicModel.ReportXlsx;
using ViewModelLib.ModelTestAutoit.PublicModel.ReportXml;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media;
using AisPoco.ModelServiceDataBase;
using LibaryXMLAuto.ModelServiceWcfCommand.ModelPathReport;
using LibaryXMLAuto.ReadOrWrite.SerializationJson;
using ViewModelLib.ModelTestAutoit.PublicModel.LabelAndErrorModel;

namespace LibraryCommandPublic.TestAutoit.PublicCommand
{
    public class CommandSnuOneAuto
    {
        /// <summary>
        /// Команда Update вынесена в отдельный класс чтобы не загромождать логику MVVM
        /// </summary>
        /// <param name="xmlUseMethod">XmlUseMethod Метод файла xml</param>
        /// <param name="reportJournalMethod">ReportJournalMethod метод журнала файла xml</param>
        /// <param name="pathFileInn">Путь к файлу FullName</param>
        /// <param name="pathJournal">Просто путь к журналу</param>
        /// <param name="pathInn">Просто путь к ИНН</param>
        public void UpdateModel(XmlUseMethod xmlUseMethod, ReportJournalMethod reportJournalMethod, string pathFileInn, string pathJournal, string pathInn)
        {
            xmlUseMethod.UpdateFileXml(pathFileInn);
            reportJournalMethod.AddFileXml(pathInn);
            reportJournalMethod.AddJournal(pathJournal);
        }

        /// <summary>
        /// Команда конвертации xml в Excel и открытия файла Excel
        /// </summary>
        /// <param name="reportExcel">отч</param>
        /// <param name="reportJournal"></param>
        /// <param name="pathReport"></param>
        public void ConvertXslToXmlAndOpen(ReportXlsxMethod reportExcel, ReportJournalMethod reportJournal,
            string pathReport)
        {
            var fileFullPath =
                LibaryXMLAuto.Converts.ConvertXmlToXslx.ConvertXmltoXlsx.ConvertXmlToXls(reportJournal.XmlFile.Path,
                    pathReport);
            reportExcel.UpdateColectFile(fileFullPath.DirectoryName);
            reportJournal.OpenFile(fileFullPath.FullName);
        }

        /// <summary>
        /// Отправка файла на сервер для анализа или отчета
        /// </summary>
        /// <param name="model">Возвращаемая модель</param>
        /// <param name="serverApi">Моделька с api</param>
        /// <param name="reportJournal">Выбор файла в журнале</param>
        public void FileToServerApiReport(LabelModel model, List<ModelServiceDataBase>  serverApi, ReportJournalMethod reportJournal)
        {
            if (serverApi == null)
            {
                MessageBox.Show("Сервер АИСИ не доступен преобретите модуль 'Инвентаризации' или настройте его правильно!!!");
                return;
            }
            var modelFileApi = serverApi.FirstOrDefault(api => api.ModelNameFileXml == reportJournal.XmlFile.Name);
            if (modelFileApi != null)
            {
                XmlConvert xmlConverter = new XmlConvert();
                var type = Type.GetType($"{modelFileApi.TypeFileNameSpaceClass},{modelFileApi.FileNameDll}");
                var reports = xmlConverter.DeserializationXmlToClass(reportJournal.XmlFile.Path, type);
                var report = (ModelPathReport)ResultPost(modelFileApi.ApiService, reports);
                model.MessageReport = report.Note;
                model.Url = report.Url;
                model.Color = Brushes.Green;
            }
            else
            {
                model.MessageReport = $"Для данной команды выбран не тот файл!!!";
                model.Color = Brushes.Red;
            }
        }

        /// <summary>
        /// Отправка запроса на сервер
        /// </summary>
        /// <param name="service">Сервисный адрес</param>
        /// <param name="requestType">Тип объекта класса</param>
        /// <returns></returns>
        private object ResultPost(string service, object requestType)
        {
            string resultServer;
            var json = new SerializeJson();
            var js = json.JsonLibraryNullInclude(requestType);
            var body = Encoding.UTF8.GetBytes(js);
            var request = (HttpWebRequest) WebRequest.Create(service);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = body.Length;
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(body, 0, body.Length);
                stream.Close();
            }
            WebResponse response = request.GetResponse();
            using (StreamReader rdr = new StreamReader(response.GetResponseStream()))
            {
                resultServer = rdr.ReadToEnd();
            }
            response.Close();
            response.Dispose();
            return json.JsonDeserializeObjectClass<ModelPathReport>(resultServer);
        }
    }
}
