using System;
using System.IO;
using System.Net;
using LibaryXMLAuto.Converts.ConvettToXml;
using ViewModelLib.ModelTestAutoit.ModelSnuOneAuto.DataXml;
using ViewModelLib.ModelTestAutoit.PublicModel.ReportXlsx;
using ViewModelLib.ModelTestAutoit.PublicModel.ReportXml;
using System.ServiceProcess;
using System.Text;
using System.Windows;
using System.Windows.Media;
using LibaryXMLAuto.ReadOrWrite.SerializationJson;
using LibaryXMLAutoModelXmlAuto.MigrationReport;
using ViewModelLib.ModelTestAutoit.PublicModel.LableAndErrorModel;

namespace LibaryCommandPublic.TestAutoit.PublicCommand
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
        /// <param name="nameservice">Наименование сервиса и Ip</param>
        /// <param name="serverReport">Конечная точка</param>
        /// <param name="reportjurnal">Журнал ошибок по миграции НП</param>
        public void SenderServerReport(LableModel model, string nameservice, string serverReport,ReportJurnalMethod reportjurnal)
        {
            if (reportjurnal.XmlFile.Name == "ReportMigration.xml")
            {
                var service = nameservice.Split(',');
                ServiceController sc = new ServiceController(service[0], service[1]);
                if (sc.Status != ServiceControllerStatus.Stopped)
                {
                    try
                    {
                        XmlConvert xmlconverter = new XmlConvert();
                        var reports =(MigrationParse)xmlconverter.DeserializationXmlToClass(reportjurnal.XmlFile.Path, typeof(MigrationParse));
                        model.MessageReport = (string)ResultPost(serverReport, reports);
                        model.Color = Brushes.Green;
                        return;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString());
                    }
                }
                model.MessageReport = $"Служба: {service[0]} на компьютере {service[1]} остановлена!";
                model.Color = Brushes.Red;
                return;
            }
            model.MessageReport = $"Для формирования писем возможно отправить только ReportMigration.xml";
            model.Color = Brushes.Red;
        }
        /// <summary>
        /// Отправка файла xml UserRule.xml для формирования Формуляров доступа
        /// </summary>
        /// <param name="model">Модель xaml MVVM</param>
        /// <param name="nameservice">Имя службы</param>
        /// <param name="serverReport">Конечный адресс службы</param>
        /// <param name="reportjurnal">Модель журнала</param>
        public void DepartmentDocumentSenders(LableModel model, string nameservice, string serverReport,ReportJurnalMethod reportjurnal)
        {

            if (reportjurnal.XmlFile.Name == "UserRule.xml")
            {
                var service = nameservice.Split(',');
                ServiceController sc = new ServiceController(service[0], service[1]);
                if (sc.Status != ServiceControllerStatus.Stopped)
                {
                    try
                    {
                        XmlConvert xmlconverter = new XmlConvert();
                        var reports = (UserRules) xmlconverter.DeserializationXmlToClass(reportjurnal.XmlFile.Path, typeof(UserRules));
                        model.MessageReport = (string)ResultPost(serverReport,reports);
                        model.Color = Brushes.Green;
                        return;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString());
                    }
                }
                model.MessageReport = $"Служба: {service[0]} на компьютере {service[1]} остановлена!";
                model.Color = Brushes.Red;
                return;
            }
            model.MessageReport = $"Для формирования писем возможно отправить только UserRule.xml";
            model.Color = Brushes.Red;
        }

        /// <summary>
        /// Отправка запроса на сервер
        /// </summary>
        /// <param name="serviceadress">Сервисный адресс</param>
        /// <param name="requesttype">Тип объекта класса</param>
        /// <returns></returns>
        private object ResultPost(string serviceadress, object requesttype)
        {
            string resultserver = null;
            var js = new SerializeJson().JsonLibary(requesttype);
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
                resultserver = rdr.ReadToEnd();
            }
            return resultserver;
        }
    }
}
