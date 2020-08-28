using System;
using System.IO;
using System.Net;
using LibaryXMLAuto.Converts.ConvettToXml;
using ViewModelLib.ModelTestAutoit.ModelSnuOneAuto.DataXml;
using ViewModelLib.ModelTestAutoit.PublicModel.ReportXlsx;
using ViewModelLib.ModelTestAutoit.PublicModel.ReportXml;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using LibaryXMLAuto.ModelServiceWcfCommand.ModelPathReport;
using LibaryXMLAuto.ReadOrWrite.SerializationJson;
using LibaryXMLAutoModelXmlAuto.MigrationReport;
using ViewModelLib.ModelTestAutoit.PublicModel.LableAndErrorModel;

namespace LibraryCommandPublic.TestAutoit.PublicCommand
{
    public class CommandSnuOneAuto
    {
        /// <summary>
        /// Команда Update вынесена в отдельный клас чтобы не загромождать логику MVVM
        /// </summary>
        /// <param name="xmlusemethod">XmlUseMethod Метод файла xml</param>
        /// <param name="reportjurnalmethod">ReportJurnalMethod метод журнала файла xml</param>
        /// <param name="pathfileinn">Путь к файлу FullName</param>
        /// <param name="pathjurnal">Просто путь к журналу</param>
        /// <param name="pathinn">Просто путь к ИНН</param>
        public void UpdateModel(XmlUseMethod xmlusemethod, ReportJurnalMethod reportjurnalmethod, string pathfileinn,string pathjurnal, string pathinn)
        {
            xmlusemethod.UpdateFileXml(pathfileinn);
            reportjurnalmethod.AddFileXml(pathinn);
            reportjurnalmethod.AddJurnal(pathjurnal);
        }

        /// <summary>
        /// Коммонда конвертации xml в Excel и открытия файла Excel
        /// </summary>
        /// <param name="reportexcel">отч</param>
        /// <param name="reportjurnal"></param>
        /// <param name="pathreport"></param>
        public void ConvertXslToXmlAndOpen(ReportXlsxMethod reportexcel, ReportJurnalMethod reportjurnal,
            string pathreport)
        {
            var filefullpath =
                LibaryXMLAuto.Converts.ConvertXmlToXslx.ConvertXmltoXlsx.ConvertXmlToXls(reportjurnal.XmlFile.Path,
                    pathreport);
            reportexcel.UpdateColectFile(filefullpath.DirectoryName);
            reportjurnal.OpenFile(filefullpath.FullName);
        }

        /// <summary>
        /// Отправка письм
        /// </summary>
        /// <param name="model">Модель сообщения</param>
        /// <param name="serverReport">Конечная точка</param>
        /// <param name="reportjurnal">Журнал ошибок по миграции НП</param>
        public void SenderServerReport(LableModel model, string serverReport,ReportJurnalMethod reportjurnal)
        {
            if (reportjurnal.XmlFile.Name == "ReportMigration.xml")
            {
                try
                {
                    XmlConvert xmlconverter = new XmlConvert();
                    var reports =(MigrationParse)xmlconverter.DeserializationXmlToClass(reportjurnal.XmlFile.Path, typeof(MigrationParse));
                    var report =  (ModelPathReport)ResultPost(serverReport, reports);
                    model.MessageReport = report.Note;
                    model.Url = report.Url;
                    model.Color = Brushes.Green;
                    return;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
            model.MessageReport = $"Для формирования писем возможно отправить только ReportMigration.xml";
            model.Color = Brushes.Red;
        }
        /// <summary>
        /// Отправка файла xml UserRule.xml для формирования Формуляров доступа
        /// </summary>
        /// <param name="model">Модель xaml MVVM</param>
        /// <param name="serverReport">Конечный адресс службы</param>
        /// <param name="reportjurnal">Модель журнала</param>
        public async void DepartmentDocumentSenders(LableModel model, string serverReport,ReportJurnalMethod reportjurnal)
        {
           await Task.Factory.StartNew(() =>
                {
                    try
                    {
                        if (reportjurnal.XmlFile.Name == "UserRule.xml")
                        {
                            XmlConvert converter = new XmlConvert();
                                var reports =
                                    (UserRules) converter.DeserializationXmlToClass(reportjurnal.XmlFile.Path,
                                        typeof(UserRules));
                                var report = (ModelPathReport) ResultPost(serverReport, reports);
                                model.MessageReport = report.Note;
                                model.Url = report.Url;
                                model.Color = Brushes.Green;
                                return;
                        }
                        model.MessageReport = $"Для формирования писем возможно отправить только UserRule.xml";
                        model.Color = Brushes.Red;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString());
                    }
                }
            );
        }

        /// <summary>
        /// Отправка запроса на сервер
        /// </summary>
        /// <param name="serviceadress">Сервисный адресс</param>
        /// <param name="requesttype">Тип объекта класса</param>
        /// <returns></returns>
        private object ResultPost(string serviceadress, object requesttype)
        {
            string resultServer;
            var json = new SerializeJson();
            var js = json.JsonLibary(requesttype);
            var body = Encoding.UTF8.GetBytes(js);
            var request = (HttpWebRequest) WebRequest.Create(serviceadress);
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
