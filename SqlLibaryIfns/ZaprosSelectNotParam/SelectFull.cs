using LibaryXMLAuto.ModelServiceWcfCommand.AngularModel;
using LibaryXMLAuto.ModelXmlSql.Model.FullSetting;
using LibaryXMLAuto.ReadOrWrite.SerializationJson;
using LibaryXMLAutoModelServiceWcfCommand.TestIfnsService;
using LibaryXMLAutoModelXmlSql.Model.Bdk.BdkIt;
using LibaryXMLAutoModelXmlSql.Model.FaceError;
using LibaryXMLAutoModelXmlSql.Model.ModelMail;
using LibaryXMLAutoModelXmlSql.Model.Predproverka;
using LibaryXMLAutoModelXmlSql.Model.Trebovanie;
using LibaryXMLAutoReports.AnalizNo;
using LibaryXMLAutoReports.FullTemplateSheme;
using SqlLibaryIfns.SqlSelect.ModelSqlFullService;
using SqlLibaryIfns.SqlZapros.SqlConnections;

namespace SqlLibaryIfns.ZaprosSelectNotParam
{
   public class SelectFull
    {
        /// <summary>
        /// Данный блок относится к слиянию лиц
        /// </summary>
        /// <param name="conectionstring">Строка соединения</param>
        /// <param name="select">Параметры выборки</param>
        /// <returns>Модель Face</returns>
        public Face FaceError(string conectionstring, string select)
        {
            var sqlconnect = new SqlConnectionType();
           return (Face)sqlconnect.SelectFullParametrSqlReader<string,string>(conectionstring, select, typeof(Face));
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
            return serializeJson.JsonLibary((AnalisBdkFull)sqlconnect.SelectFullParametrSqlReader<string,string>(conectionstring, select,typeof(AnalisBdkFull)));
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

        public string SqlSelect(string conectionstring, AngularModel command)
        {
            var sqlconnect = new SqlConnectionType();
            SerializeJson serializeJson = new SerializeJson();
            switch (command.Id)
            {
                case 1:
                    return serializeJson.JsonLibary((SysNum)sqlconnect.SelectFullParametrSqlReader<string, string>(conectionstring, command.Command, typeof(SysNum)));
                case 12:
                    return serializeJson.JsonLibary((Mail)sqlconnect.SelectFullParametrSqlReader<string, string>(conectionstring, command.Command, typeof(Mail)));
                case 13:
                    return serializeJson.JsonLibary((ModelFull)sqlconnect.SelectFullParametrSqlReader<string, string>(conectionstring, command.Command, typeof(ModelFull)));
                case 14:
                    return
                        serializeJson.JsonLibary(
                            (Soprovod)
                            sqlconnect.SelectFullParametrSqlReader<string, string>(conectionstring, command.Command,
                                typeof(Soprovod)));
                case 21: return serializeJson.JsonLibary((No)sqlconnect.SelectFullParametrSqlReader<string, string>(conectionstring, command.Command,typeof(No)));
                default:
                    return "Данная комманда не определена!!!";
            }
        }

    }
}