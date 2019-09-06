using System.Runtime.InteropServices;
using EfDatabaseErrorInventory;
using EfDatabaseInvoice;
using EfDatabaseParametrsModel;
using LibaryXMLAuto.ModelServiceWcfCommand.AngularModel;
using LibaryXMLAuto.ModelXmlSql.Model.FullSetting;
using LibaryXMLAuto.ReadOrWrite.SerializationJson;
using LibaryXMLAutoModelXmlSql.Model.Bdk.BdkIt;
using LibaryXMLAutoModelXmlSql.Model.FaceError;
using LibaryXMLAutoModelXmlSql.Model.ModelMail;
using LibaryXMLAutoModelXmlSql.Model.Predproverka;
using LibaryXMLAutoModelXmlSql.Model.Trebovanie;
using LibaryXMLAutoReports.AnalizNo;
using LibaryXMLAutoReports.FullTemplateSheme;
using SqlLibaryIfns.SqlSelect.ModelSqlFullService;
using SqlLibaryIfns.SqlZapros.SqlConnections;
using LibaryXMLAutoModelXmlSql.Model.ServerAndComputer;
using ServiceWcf = LibaryXMLAutoModelServiceWcfCommand.TestIfnsService.ServiceWcf;

namespace SqlLibaryIfns.ZaprosSelectNotParam
{
    public class SelectFull
    {
        /// <summary>
        /// Вытаскиваем внутреннею команду с сайта
        /// </summary>
        /// <param name="conectionstring">Строка соединения</param>
        /// <param name="setting">Параметры</param>
        /// <returns></returns>
        private ServiceWcf Service(string conectionstring, FullSetting setting)
        {
            var sqlconnect = new SqlConnectionType();
            return
                (ServiceWcf)
                sqlconnect.SelectFullParametrSqlReader(conectionstring, ModelSqlFullService.ProcedureSelectParametr,
                    typeof(ServiceWcf), ModelSqlFullService.ParamCommand(setting.Id.ToString()));
        }


        /// <summary>
        /// Данный блок относится к слиянию лиц
        /// </summary>
        /// <param name="conectionstring">Строка соединения</param>
        /// <param name="select">Параметры выборки</param>
        /// <returns>Модель Face</returns>
        public Face FaceError(string conectionstring, string select)
        {
            var sqlconnect = new SqlConnectionType();
            return (Face) sqlconnect.SelectFullParametrSqlReader<string, string>(conectionstring, select, typeof(Face));
        }

        /// <summary>
        /// Данный блок относится к БДК
        /// </summary>
        /// <param name="conectionstring">Строка соединения</param>
        /// <param name="select">Команда Select</param>
        /// <returns>Возвращаем модель JSON в виде строки</returns>
        public string BdkSqlSelect(string conectionstring, string select)
        {
            var sqlconnect = new SqlConnectionType();
            SerializeJson serializeJson = new SerializeJson();
            return
                serializeJson.JsonLibary(
                    (AnalisBdkFull)
                    sqlconnect.SelectFullParametrSqlReader<string, string>(conectionstring, select,
                        typeof(AnalisBdkFull)));
        }

        /// <summary>
        /// Вытягивание выборки на сайт для подставления в нее параметров данных
        /// </summary>
        /// <param name="conectionstring">Строка соединения</param>
        /// <param name="setting">Параметры настройки</param>
        /// <returns></returns>
        public string ServiceCommand(string conectionstring, FullSetting setting)
        {
            var sqlconnect = new SqlConnectionType();
            SerializeJson serializeJson = new SerializeJson();
            return serializeJson.JsonLibary(
                (ServiceWcf)
                sqlconnect.SelectFullParametrSqlReader(conectionstring, ModelSqlFullService.ProcedureSelectParametr,
                    typeof(ServiceWcf), ModelSqlFullService.ParamCommand(setting.ParamService.IdCommand.ToString())));
        }

        /// <summary>
        /// Выполнение команд с генерацией параметров на ФРОНТЕ
        /// </summary>
        /// <param name="conectionstring">Строка соединения</param>
        /// <param name="command">Команда</param>
        /// <returns></returns>
        public string SqlSelect(string conectionstring, AngularModel command)
        {
            var sqlconnect = new SqlConnectionType();
            SerializeJson serializeJson = new SerializeJson();
            switch (command.Id)
            {
                case 1:
                    return
                        serializeJson.JsonLibary(
                            (SysNum)
                            sqlconnect.SelectFullParametrSqlReader<string, string>(conectionstring, command.Command,
                                typeof(SysNum)));
                case 12:
                    return
                        serializeJson.JsonLibary(
                            (Mail)
                            sqlconnect.SelectFullParametrSqlReader<string, string>(conectionstring, command.Command,
                                typeof(Mail)));
                case 13:
                    return
                        serializeJson.JsonLibary(
                            (ModelFull)
                            sqlconnect.SelectFullParametrSqlReader<string, string>(conectionstring, command.Command,
                                typeof(ModelFull)));
                case 14:
                    return
                        serializeJson.JsonLibary(
                            (Soprovod)
                            sqlconnect.SelectFullParametrSqlReader<string, string>(conectionstring, command.Command,
                                typeof(Soprovod)));
                case 21:
                    return
                        serializeJson.JsonLibary(
                            (No)
                            sqlconnect.SelectFullParametrSqlReader<string, string>(conectionstring, command.Command,
                                typeof(No)));
                case 29:
                    return
                        serializeJson.JsonLibary(
                            (ServerAndComputer)
                            sqlconnect.SelectFullParametrSqlReader<string, string>(conectionstring, command.Command,
                                typeof(ServerAndComputer)));
                default:
                    return "Данная комманда не определена!!!";
            }
        }

        /// <summary>
        /// Выполнение команды на сервере под номером
        /// </summary>
        /// <param name="conectionstring">Строка соединения</param>
        /// <param name="setting">Параметры</param>
        /// <returns></returns>
        public string SqlSelect(string conectionstring, FullSetting setting)
        {
            var sqlconnect = new SqlConnectionType();
            SerializeJson serializeJson = new SerializeJson();
            var ping = new PingIp.PingIp();
            switch (setting.Id)
            {
                case 29:
                    var server =
                        ping.Ping(
                            (ServerAndComputer)
                            sqlconnect.SelectFullParametrSqlReader<string, string>(conectionstring,
                                Service(conectionstring, setting).ServiceWcfCommand.Command, typeof(ServerAndComputer)));
                    return serializeJson.JsonLibary(server);
                default:
                    return "Данная комманда не определена!!!";
            }
        }
        /// <summary>
        /// Это для инвенторизации выборка
        /// </summary>
        /// <param name="conectionstring">Строка соединения</param>
        /// <param name="logica">Логика</param>
        /// <returns></returns>
        public string SqlModelInventory(string conectionstring, LogicaSelect logica)
        {
            var sqlconnect = new SqlConnectionType();
            SerializeJson serializeJson = new SerializeJson();
            switch (logica.Id)
            {
                case 1:
                    return
                        serializeJson.JsonLibary(
                            (AllTechnicalUsersAndOtdel)
                            sqlconnect.SelectFullParametrSqlReader<string, string>(conectionstring, logica.SelectUser,
                                typeof(AllTechnicalUsersAndOtdel)));
                case 2:
                    return
                        serializeJson.JsonLibary(
                            (AllTechnicalUsersAndOtdel)
                            sqlconnect.SelectFullParametrSqlReader<string, string>(conectionstring, logica.SelectUser,
                                typeof(AllTechnicalUsersAndOtdel)));
                case 4:
                    return
                        serializeJson.JsonLibary(
                            (Documents)
                            sqlconnect.SelectFullParametrSqlReader<string, string>(conectionstring, logica.SelectUser,
                                typeof(Documents)));
                case 6:
                    return serializeJson.JsonLibary(
                            (FullError)
                            sqlconnect.SelectFullParametrSqlReader<string, string>(conectionstring, logica.SelectUser,
                                typeof(FullError)));
                case 7:
                    return
                        serializeJson.JsonLibary(
                            (FullError)
                            sqlconnect.SelectFullParametrSqlReader<string, string>(conectionstring, logica.SelectUser,
                                typeof(FullError)));
                case 8:
                    return
                        serializeJson.JsonLibary(
                            (FullError)
                            sqlconnect.SelectFullParametrSqlReader<string, string>(conectionstring, logica.SelectUser,
                                typeof(FullError)));
                case 9:
                    return
                        serializeJson.JsonLibary(
                            (FullError)
                            sqlconnect.SelectFullParametrSqlReader<string, string>(conectionstring, logica.SelectUser,
                                typeof(FullError)));
                default:
                    return "Дагнная комманда не определена!!!";
            }
        }
    }
}