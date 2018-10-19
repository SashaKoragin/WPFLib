using System.Collections.Generic;
using System.Threading.Tasks;
using LibaryXMLAuto.ModelXmlSql.Model.FullSetting;
using LibaryXMLAutoModelServiceWcfCommand.TestIfnsService;
using SqlLibaryIfns.SqlSelect.ModelSqlFullService;
using SqlLibaryIfns.SqlZapros.SqlConnections;

namespace SqlLibaryIfns.SqlEntytiCommand.TaskUse
{
   public class TaskResult
    {
        /// <summary>
        /// Выбор процедуры в зависимости от настроек:
        /// 1 - Процедура добавления значения на добавления а название под ун 3
        /// 2 - Процедура запуска процесса решений а название под ун 4
        /// 3 - Процедура запуска инкассовых поручений а название под ун 5
        /// Процесс генерации параметров для процедуры нужно улучшить!!!!
        /// </summary>
        /// <param name="connection">Строка соединения</param>
        /// <param name="seting">Настойки</param>
        /// <returns>Строка с ответа с сервера</returns>
        public async Task<string> TaskSqlProcedure(string connection, FullSetting seting)
        {
            var sqlconnect = new SqlConnectionType();
            Dictionary<string, int> listparametr = null;
            if (seting.ParametrReshen.D270!=0)
            {
                listparametr = new Dictionary<string, int>();
                listparametr.Add("@D270", seting.ParametrReshen.D270);
            }
            switch (seting.Id)
            {
                case 1:
                    return await Task.Factory.StartNew(()=> sqlconnect.StartingProcedure(connection, ((ServiceWcf)sqlconnect.SelectFullParametrSqlReader(connection, ModelSqlFullService.ProcedureSelectParametr, typeof(ServiceWcf), ModelSqlFullService.ParamCommand("3"))).ServiceWcfCommand.Command, listparametr));
                case 2:
                    return await Task.Factory.StartNew(() => sqlconnect.StartingProcedure(connection, ((ServiceWcf)sqlconnect.SelectFullParametrSqlReader(connection, ModelSqlFullService.ProcedureSelectParametr, typeof(ServiceWcf), ModelSqlFullService.ParamCommand("4"))).ServiceWcfCommand.Command, listparametr));
                case 3:
                    return await Task.Factory.StartNew(() => sqlconnect.StartingProcedure(connection, ((ServiceWcf)sqlconnect.SelectFullParametrSqlReader(connection, ModelSqlFullService.ProcedureSelectParametr, typeof(ServiceWcf), ModelSqlFullService.ParamCommand("5"))).ServiceWcfCommand.Command, listparametr));
                default:
                    return null;
            }
        }
        /// <summary>
        /// Выбор процедуры в зависимости от настроек:
        /// 1 - Процедура предварительного анализа
        /// 2 - Процедура запуска процесса BDK
        /// Процесс генерации параметров для процедуры нужно улучшить!!!!
        /// </summary>
        /// <param name="connection">Строка соединения</param>
        /// <param name="seting">Настройка</param>
        /// <returns></returns>
        public async Task<string> TaskSqlProcedureBdk(string connection, FullSetting seting)
        {
            var sqlconnect = new SqlConnectionType();
            GenerateParametrSql.GenerateParametrSql sql = new GenerateParametrSql.GenerateParametrSql();
            Dictionary<string, string> listparametr = null;
            if (seting.ParametrBdk.N269 != 0)
            {
                sql.CreateParamert(ref listparametr, seting.ParametrBdk.GetType(), seting.ParametrBdk);
            }
            switch (seting.Id)
            {
                case 1:
                    return await Task.Factory.StartNew(() => sqlconnect.StartingProcedure(connection, ((ServiceWcf)sqlconnect.SelectFullParametrSqlReader(connection, ModelSqlFullService.ProcedureSelectParametr, typeof(ServiceWcf), ModelSqlFullService.ParamCommand("8"))).ServiceWcfCommand.Command, listparametr));
                case 2:
                    return await Task.Factory.StartNew(() => sqlconnect.StartingProcedure(connection, ((ServiceWcf)sqlconnect.SelectFullParametrSqlReader(connection, ModelSqlFullService.ProcedureSelectParametr, typeof(ServiceWcf), ModelSqlFullService.ParamCommand("9"))).ServiceWcfCommand.Command, listparametr));
               default:
                    return null;
            }
        }
        /// <summary>
        /// Процедуры предпроверки
        /// </summary>
        /// <param name="connection">Строка соединения</param>
        /// <param name="seting">Настройки</param>
        /// <returns></returns>
        public async Task<string> TaskSqlProcedureSoprovod(string connection, FullSetting seting)
        {
            var sqlconnect = new SqlConnectionType();
            GenerateParametrSql.GenerateParametrSql sql = new GenerateParametrSql.GenerateParametrSql();
            Dictionary<string, string> listparametr = null;
            if (seting.ParamPredproverka.N441 != 0)
            {
                sql.CreateParamert(ref listparametr, seting.ParamPredproverka.GetType(), seting.ParamPredproverka);
            }
            switch (seting.Id)
            {
                case 1:
                    return await Task.Factory.StartNew(() => sqlconnect.StartingProcedure(connection, ((ServiceWcf)sqlconnect.SelectFullParametrSqlReader(connection, ModelSqlFullService.ProcedureSelectParametr, typeof(ServiceWcf), ModelSqlFullService.ParamCommand("15"))).ServiceWcfCommand.Command, listparametr));
                case 2:
                    return await Task.Factory.StartNew(() => sqlconnect.StartingProcedure(connection, ((ServiceWcf)sqlconnect.SelectFullParametrSqlReader(connection, ModelSqlFullService.ProcedureSelectParametr, typeof(ServiceWcf), ModelSqlFullService.ParamCommand("16"))).ServiceWcfCommand.Command, listparametr));
                case 3:
                    return await Task.Factory.StartNew(() => sqlconnect.StartingProcedure(connection, ((ServiceWcf)sqlconnect.SelectFullParametrSqlReader(connection, ModelSqlFullService.ProcedureSelectParametr, typeof(ServiceWcf), ModelSqlFullService.ParamCommand("17"))).ServiceWcfCommand.Command, listparametr));
                default:
                    return null;
            }
        }


    }
}
