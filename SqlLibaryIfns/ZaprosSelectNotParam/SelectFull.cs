using System.Collections.Generic;
using System.Data;
using System.IO;
using EfDatabaseErrorInventory;
using EfDatabaseInvoice;
using EfDatabaseParametrsModel;
using EfDatabaseTelephoneHelp;
using EfDatabaseXsdBookAccounting;
using LibaryXMLAuto.ModelServiceWcfCommand.AngularModel;
using LibaryXMLAuto.ModelXmlSql.Model.FullSetting;
using LibaryXMLAuto.ReadOrWrite.SerializationJson;
using LibaryXMLAutoModelXmlSql.Model.Bdk.BdkIt;
using LibaryXMLAutoModelXmlSql.Model.FaceError;
using LibaryXMLAutoModelXmlSql.Model.Predproverka;
using LibaryXMLAutoModelXmlSql.Model.Trebovanie;
using LibaryXMLAutoReports.AnalizNo;
using LibaryXMLAutoReports.FullTemplateSheme;
using SqlLibaryIfns.SqlSelect.ModelSqlFullService;
using SqlLibaryIfns.SqlZapros.SqlConnections;
using LibaryXMLAutoModelXmlSql.Model.ServerAndComputer;
using SqlLibaryIfns.ExcelReport.Report;
using ServiceWcf = LibaryXMLAutoModelServiceWcfCommand.TestIfnsService.ServiceWcf;
using LogicaSelect = EfDatabaseParametrsModel.LogicaSelect;
using EfDatabaseXsdMail;
using Mail = LibaryXMLAutoModelXmlSql.Model.ModelMail.Mail;
using EfDatabaseAutomation.Automation.BaseLogica.SqlSelect.SelectAll;

namespace SqlLibaryIfns.ZaprosSelectNotParam
{
    public class SelectFull
    {
        /// <summary>
        /// Вытаскиваем внутреннею команду с сайта
        /// </summary>
        /// <param name="connectionString">Строка соединения</param>
        /// <param name="setting">Параметры</param>
        /// <returns></returns>
        private ServiceWcf Service(string connectionString, FullSetting setting)
        {
            var sqlConnect = new SqlConnectionType();
            return
                (ServiceWcf)
                sqlConnect.SelectFullParametrSqlReader(connectionString, ModelSqlFullService.ProcedureSelectParametr,
                    typeof(ServiceWcf), ModelSqlFullService.ParamCommand(setting.Id.ToString()));
        }


        /// <summary>
        /// Данный блок относится к слиянию лиц
        /// </summary>
        /// <param name="connectionString">Строка соединения</param>
        /// <param name="select">Параметры выборки</param>
        /// <returns>Модель Face</returns>
        public Face FaceError(string connectionString, string select)
        {
            var sqlConnect = new SqlConnectionType();
            return (Face)sqlConnect.SelectFullParametrSqlReader<string, string>(connectionString, select, typeof(Face));
        }

        /// <summary>
        /// Данный блок относится к БДК
        /// </summary>
        /// <param name="connectionString">Строка соединения</param>
        /// <param name="select">Команда Select</param>
        /// <returns>Возвращаем модель JSON в виде строки</returns>
        public string BdkSqlSelect(string connectionString, string select)
        {
            var sqlConnect = new SqlConnectionType();
            SerializeJson serializeJson = new SerializeJson();
            return
                serializeJson.JsonLibary(
                    (AnalisBdkFull)
                    sqlConnect.SelectFullParametrSqlReader<string, string>(connectionString, select,
                        typeof(AnalisBdkFull)));
        }

        /// <summary>
        /// Вытягивание выборки на сайт для поставления в нее параметров данных
        /// </summary>
        /// <param name="connectionString">Строка соединения</param>
        /// <param name="setting">Параметры настройки</param>
        /// <returns></returns>
        public string ServiceCommand(string connectionString, FullSetting setting)
        {
            var sqlConnect = new SqlConnectionType();
            SerializeJson serializeJson = new SerializeJson();
            return serializeJson.JsonLibary(
                (ServiceWcf)
                sqlConnect.SelectFullParametrSqlReader(connectionString, ModelSqlFullService.ProcedureSelectParametr,
                    typeof(ServiceWcf), ModelSqlFullService.ParamCommand(setting.ParamService.IdCommand.ToString())));
        }

        /// <summary>
        /// Выполнение команд с генерацией параметров на ФРОНТЕ
        /// </summary>
        /// <param name="connectionString">Строка соединения</param>
        /// <param name="command">Команда</param>
        /// <returns></returns>
        public string SqlSelect(string connectionString, AngularModel command)
        {
            var sqlConnect = new SqlConnectionType();
            SerializeJson serializeJson = new SerializeJson();
            switch (command.Id)
            {
                case 1:
                    return
                        serializeJson.JsonLibary(
                            (SysNum)
                            sqlConnect.SelectFullParametrSqlReader<string, string>(connectionString, command.Command,
                                typeof(SysNum)));
                case 12:
                    return
                        serializeJson.JsonLibary(
                            (Mail)
                            sqlConnect.SelectFullParametrSqlReader<string, string>(connectionString, command.Command,
                                typeof(Mail)));
                case 13:
                    return
                        serializeJson.JsonLibary(
                            (ModelFull)
                            sqlConnect.SelectFullParametrSqlReader<string, string>(connectionString, command.Command,
                                typeof(ModelFull)));
                case 14:
                    return
                        serializeJson.JsonLibary(
                            (Soprovod)
                            sqlConnect.SelectFullParametrSqlReader<string, string>(connectionString, command.Command,
                                typeof(Soprovod)));
                case 21:
                    return
                        serializeJson.JsonLibary(
                            (No)
                            sqlConnect.SelectFullParametrSqlReader<string, string>(connectionString, command.Command,
                                typeof(No)));
                case 29:
                    return
                        serializeJson.JsonLibary(
                            (ServerAndComputer)
                            sqlConnect.SelectFullParametrSqlReader<string, string>(connectionString, command.Command,
                                typeof(ServerAndComputer)));
                default:
                    return "Данная команда не определена!!!";
            }
        }

        /// <summary>
        /// Выполнение команды на сервере под номером
        /// </summary>
        /// <param name="connectionString">Строка соединения</param>
        /// <param name="setting">Параметры</param>
        /// <returns></returns>
        public string SqlSelect(string connectionString, FullSetting setting)
        {
            var sqlConnect = new SqlConnectionType();
            SerializeJson serializeJson = new SerializeJson();
            var ping = new PingIp.PingIp();
            switch (setting.Id)
            {
                case 29:
                    var server =
                        ping.Ping(
                            (ServerAndComputer)
                            sqlConnect.SelectFullParametrSqlReader<string, string>(connectionString,
                                Service(connectionString, setting).ServiceWcfCommand.Command, typeof(ServerAndComputer)));
                    return serializeJson.JsonLibary(server);
                default:
                    return "Данная команда не определена!!!";
            }
        }

        /// <summary>
        /// Это для инвентаризации выборка
        /// </summary>
        /// <param name="connectionString">Строка соединения</param>
        /// <param name="logic">Логика</param>
        /// <returns></returns>
        public string SqlModelInventory(string connectionString, LogicaSelect logic)
        {
            var sqlConnect = new SqlConnectionType();
            SerializeJson serializeJson = new SerializeJson();
            switch (logic.Id)
            {
                case 1:
                    return
                        serializeJson.JsonLibary(
                            (AllTechnicalUsersAndOtdelAndTreeAis3)
                            sqlConnect.SelectFullParametrSqlReader<string, string>(connectionString, logic.SelectUser,
                                typeof(AllTechnicalUsersAndOtdelAndTreeAis3)));
                case 2:
                    return
                        serializeJson.JsonLibary(
                            (AllTechnicalUsersAndOtdelAndTreeAis3)
                            sqlConnect.SelectFullParametrSqlReader<string, string>(connectionString, logic.SelectUser,
                                typeof(AllTechnicalUsersAndOtdelAndTreeAis3)));
                case 4:
                    return
                        serializeJson.JsonLibary(
                            (Documents)
                            sqlConnect.SelectFullParametrSqlReader<string, string>(connectionString, logic.SelectUser,
                                typeof(Documents)));
                case 6:
                    return serializeJson.JsonLibary(
                        (FullError)
                        sqlConnect.SelectFullParametrSqlReader<string, string>(connectionString, logic.SelectUser,
                            typeof(FullError)));
                case 7:
                    return
                        serializeJson.JsonLibary(
                            (FullError)
                            sqlConnect.SelectFullParametrSqlReader<string, string>(connectionString, logic.SelectUser,
                                typeof(FullError)));
                case 8:
                    return
                        serializeJson.JsonLibary(
                            (FullError)
                            sqlConnect.SelectFullParametrSqlReader<string, string>(connectionString, logic.SelectUser,
                                typeof(FullError)));
                case 9:
                    return
                        serializeJson.JsonLibary(
                            (FullError)
                            sqlConnect.SelectFullParametrSqlReader<string, string>(connectionString, logic.SelectUser,
                                typeof(FullError)));
                case 11:
                    return
                        serializeJson.JsonLibary(
                            (Book)
                            sqlConnect.SelectFullParametrSqlReader<string, string>(connectionString, logic.SelectUser,
                                typeof(Book)));
                case 14:
                    return
                        serializeJson.JsonLibraryVks(
                            (FullError)
                            sqlConnect.SelectFullParametrSqlReader<string, string>(connectionString, logic.SelectUser,
                                typeof(FullError)));
                case 15:
                    return
                        serializeJson.JsonLibary(
                            (FullError)
                            sqlConnect.SelectFullParametrSqlReader<string, string>(connectionString, logic.SelectUser,
                                typeof(FullError)));
                case 16:
                    return
                        serializeJson.JsonLibary(
                            (FullError)
                            sqlConnect.SelectFullParametrSqlReader<string, string>(connectionString, logic.SelectUser,
                                typeof(FullError)));
                case 17:
                    return
                        serializeJson.JsonLibary(
                            (FullError)
                            sqlConnect.SelectFullParametrSqlReader<string, string>(connectionString, logic.SelectUser,
                                typeof(FullError)));
                case 18:
                    return
                        serializeJson.JsonLibary(
                            (FullError)
                            sqlConnect.SelectFullParametrSqlReader<string, string>(connectionString, logic.SelectUser,
                                typeof(FullError)));
                case 20:
                    return
                        serializeJson.JsonLibary(
                            (FullError)
                            sqlConnect.SelectFullParametrSqlReader<string, string>(connectionString, logic.SelectUser,
                                typeof(FullError)));
                case 21:
                    return
                        serializeJson.JsonLibary(
                            (FullError)
                            sqlConnect.SelectFullParametrSqlReader<string, string>(connectionString, logic.SelectUser,
                                typeof(FullError)));
                case 22:
                    return
                        serializeJson.JsonLibary(
                            (FullError)
                            sqlConnect.SelectFullParametrSqlReader<string, string>(connectionString, logic.SelectUser,
                                typeof(FullError)));
                case 25:
                    return serializeJson.JsonLibary(
                            (MailSheme)
                            sqlConnect.SelectFullParametrSqlReader<string, string>(connectionString, logic.SelectUser,
                                typeof(MailSheme)));
                case 27:
                    return serializeJson.JsonLibary(
                        (MailSheme)
                        sqlConnect.SelectFullParametrSqlReader<string, string>(connectionString, logic.SelectUser,
                            typeof(MailSheme)));
                case 29:
                    return serializeJson.JsonLibary((
                        FullError) sqlConnect.SelectFullParametrSqlReader<string, string>(connectionString,
                        logic.SelectUser, typeof(FullError)));
                case 31:
                    return serializeJson.JsonLibary((
                        FullError)sqlConnect.SelectFullParametrSqlReader<string, string>(connectionString,
                        logic.SelectUser, typeof(FullError)));
                case 33:
                    return serializeJson.JsonLibraryVks((
                        MailSheme)sqlConnect.SelectFullParametrSqlReader<string,string>(connectionString,
                        logic.SelectUser,typeof(MailSheme)));
                case 36:
                    return serializeJson.JsonLibary((FullError) sqlConnect.SelectFullParametrSqlReader<string, string>(
                        connectionString,
                        logic.SelectUser, typeof(FullError)));
                case 38:
                   return serializeJson.JsonLibary(
                        (AllTechnicalUsersAndOtdelAndTreeAis3)
                        sqlConnect.SelectFullParametrSqlReader<string, string>(connectionString, logic.SelectUser,
                            typeof(AllTechnicalUsersAndOtdelAndTreeAis3)));
                default:
                    return "Данная команда не определена!!!";
            }
        }

        /// <summary>
        /// Выгрузка модели телефонного справочника
        /// </summary>
        /// <param name="connectionString">Строка соединения с БД</param>
        /// <param name="logic">Логика выборки</param>
        /// <param name="listparametr">Параметры</param>
        /// <returns>Возвращает объект для превращения его в схему</returns>
        public object GenerateSchemeXsdSql<TKey, TValue>(string connectionString, LogicaSelect logic, Dictionary<TKey, TValue> listparametr = null)
        {
            var sqlConnect = new SqlConnectionType();
            switch (logic.Id)
            {
                case 10:
                    TelephoneHelp telephoneHelp = new TelephoneHelp
                    {
                        TelephonHeaders =
                            ((TelephoneHelp)sqlConnect.SelectFullParametrSqlReader(connectionString, logic.SelectUser,
                                typeof(TelephoneHelp), ModelSqlFullService.ParamCommand("1"))).TelephonHeaders,
                        TelephonBody =
                            ((TelephoneHelp)
                                sqlConnect.SelectFullParametrSqlReader(connectionString, logic.SelectUser,
                                typeof(TelephoneHelp), ModelSqlFullService.ParamCommand("2"))).TelephonBody
                    };
                    return telephoneHelp;
                case 12:
                    Book book = new Book
                    {
                        BareCodeBook = new BareCodeBook(),
                        Organization = ((Book)sqlConnect.SelectFullParametrSqlReader(connectionString, logic.SelectUser,typeof(Book),listparametr)).Organization
                    };
                    return book;
                default:
                    return null;
            }
        }
        /// <summary>
        /// Запрос на выгрузку данных в таблицу XLSX
        /// </summary>
        /// <param name="connectionString">Строка соединения с сервером</param>
        /// <param name="sqlSelect">Sql запрос</param>
        /// <param name="nameFile">Наименование файла</param>
        /// <param name="nameReport">Наименование отчета</param>
        /// <param name="pathSaveReport">Путь сохранения отчета</param>
        /// <returns></returns>
        public Stream GenerateStreamToSqlViewFile(string connectionString, string sqlSelect, string nameFile, string nameReport, string pathSaveReport)
        {
            var sqlConnect = new SqlConnectionType();
            var xlsx = new ReportExcel();
            var tableTelephone = sqlConnect.ReportQbe(connectionString, sqlSelect);
            xlsx.ReportSave(pathSaveReport, nameFile, nameReport, tableTelephone);
            return DownloadFile(Path.Combine(pathSaveReport, $"{nameFile}.xlsx"));
        }
        /// <summary>
        /// Выгрузка сводной таблицы по покупкам из таблицы ReportXlsx
        /// </summary>
        /// <param name="pathSaveReport">Путь сохранения</param>
        /// <param name="inn">ИНН</param>
        /// <returns></returns>
        public Stream GenerateSummarySales(string pathSaveReport, string inn)
        {
            DataSet dataReport = new DataSet();
            var selectProcedureReport = new SelectAll();
            var reportModel = selectProcedureReport.ReturnReportModelXlsx(1);
            var fullPath = Path.Combine(pathSaveReport, reportModel.NameFile);
            dataReport.Tables.Add(selectProcedureReport.ReturnModelReport(reportModel, inn));
            selectProcedureReport.Dispose();
            if (dataReport.Tables[0] != null)
            {
                var xlsx = new ReportExcel();
                xlsx.ReportSaveFullDataSet(fullPath, dataReport);
                xlsx.Dispose();
                return DownloadFile(fullPath);
            }
            return null;
        }

        /// <summary>
        /// Функция преобразования View в Файл
        /// </summary>
        /// <param name="connectionString">Строка соединения</param>
        /// <param name="logic">Логика</param>
        /// <param name="pathSaveReport">Путь сохранения</param>
        /// <returns></returns>
        public Stream GenerateStreamToSqlViewFile(string connectionString, LogicaSelect logic, string pathSaveReport)
        {
            var sqlConnect = new SqlConnectionType();
            var xlsx = new ReportExcel();
            switch (logic.Id)
            {
                case 23:
                    var tableTelephone = sqlConnect.ReportQbe(connectionString, logic.SelectUser);
                    xlsx.ReportSave(pathSaveReport, "Все телефоны", "Телефоны и пользователи", tableTelephone);
                    return  DownloadFile(Path.Combine(pathSaveReport, "Все телефоны.xlsx"));
                case 30:
                    var tableAllTechnics = sqlConnect.ReportQbe(connectionString, logic.SelectUser);
                    xlsx.ReportSave(pathSaveReport, "Вся техника в БД", "Техника", tableAllTechnics);
                    return DownloadFile(Path.Combine(pathSaveReport, "Вся техника в БД.xlsx"));
                default:
                    return null;
            }
        }

        /// <summary>
        /// Конвертация файла в массив данных
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns></returns>
        private Stream DownloadFile(string path)
        {
            return File.OpenRead(path);
        }
    }
}