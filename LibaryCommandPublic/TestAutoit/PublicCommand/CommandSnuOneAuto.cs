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
using GalaSoft.MvvmLight.Threading;
using LibaryXMLAuto.ModelServiceWcfCommand.ModelPathReport;
using LibaryXMLAuto.ReadOrWrite.SerializationJson;
using LibaryXMLAutoModelXmlAuto.MigrationReport;
using ViewModelLib.ModelTestAutoit.PublicModel.LabelAndErrorModel;

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
        /// <param name="reportJournal"></param>
        /// <param name="pathreport"></param>
        public void ConvertXslToXmlAndOpen(ReportXlsxMethod reportexcel, ReportJurnalMethod reportJournal,
            string pathreport)
        {
            var filefullpath =
                LibaryXMLAuto.Converts.ConvertXmlToXslx.ConvertXmltoXlsx.ConvertXmlToXls(reportJournal.XmlFile.Path,
                    pathreport);
            reportexcel.UpdateColectFile(filefullpath.DirectoryName);
            reportJournal.OpenFile(filefullpath.FullName);
        }

        /// <summary>
        /// Отправка письм
        /// </summary>
        /// <param name="model">Модель сообщения</param>
        /// <param name="serverReport">Конечная точка</param>
        /// <param name="reportJournal">Журнал ошибок по миграции НП</param>
        public void SenderServerReport(LabelModel model, string serverReport,ReportJurnalMethod reportJournal)
        {
            if (reportJournal.XmlFile.Name == "ReportMigration.xml")
            {
                try
                {
                    XmlConvert xmlconverter = new XmlConvert();
                    var reports =(MigrationParse)xmlconverter.DeserializationXmlToClass(reportJournal.XmlFile.Path, typeof(MigrationParse));
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
        /// <param name="serverReport">Конечный адрес службы</param>
        /// <param name="reportJournal">Модель журнала</param>
        public async void DepartmentDocumentSenders(LabelModel model, string serverReport,ReportJurnalMethod reportJournal)
        {
            DispatcherHelper.Initialize();
            await Task.Factory.StartNew(() =>
                {
                    try
                    {
                        if (reportJournal.XmlFile.Name == "UserRule.xml")
                        {
                            XmlConvert converter = new XmlConvert();
                                var reports =
                                    (UserRules) converter.DeserializationXmlToClass(reportJournal.XmlFile.Path,
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
        /// Отправка файла xml UserRule.xml для формирования Формуляров доступа
        /// </summary>
        /// <param name="model">Модель xaml MVVM</param>
        /// <param name="serverReport">Конечный адрес службы</param>
        /// <param name="reportJournal">Модель журнала</param>
        public async void LoadInfoTemplate(LabelModel model, string serverReport, ReportJurnalMethod reportJournal)
        {
            await Task.Factory.StartNew(() =>
                {
                    try
                    {
                        if (reportJournal.XmlFile.Name == "InfoRuleTemplate.xml")
                        {
                            XmlConvert converter = new XmlConvert();
                            var reports = (InfoRuleTemplate)converter.DeserializationXmlToClass(reportJournal.XmlFile.Path, typeof(InfoRuleTemplate));
                            var report = (ModelPathReport)ResultPost(serverReport, reports);
                            model.MessageReport = report.Note;
                            model.Color = Brushes.Green;
                            return;
                        }
                        model.MessageReport = $"Для загрузки ролей доступен только файл InfoRuleTemplate.xml";
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
