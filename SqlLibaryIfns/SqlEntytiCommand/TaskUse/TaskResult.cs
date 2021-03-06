﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using EfDatabase.AddTable.AddKrsb;
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
            Dictionary<string, int> listparametr = new Dictionary<string, int>();
            if (seting.ParametrReshen.D270!=0)
            {
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
            Dictionary<string, string> listparametr = new Dictionary<string, string>();
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
            Dictionary<string, string> listparametr = new Dictionary<string, string>();
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
        /// <summary>
        /// Процедуры выполнения создания КРСБ
        /// </summary>
        /// <param name="connection">Строка соединения</param>
        /// <param name="seting">Настройки</param>
        /// <returns></returns>
        public async Task<string> TaskSqlProcedureKrsb(string connection, FullSetting seting)
        {
            var sqlconnect = new SqlConnectionType();
            Dictionary<string, dynamic> listparametr = new Dictionary<string, dynamic>();
            if (seting.DeloCreate.DateDelo != System.DateTime.MinValue)
            {
                listparametr.Add("@DateStart", seting.DeloCreate.DateDelo.Date);
            }
            if (seting.DeloCreate.D3979 != 0)
            {
                listparametr.Add("@D3979", seting.DeloCreate.D3979);
            }
            if (!String.IsNullOrWhiteSpace(seting.DeloCreate.Okato))
            {
                listparametr.Add("@Okato", seting.DeloCreate.Okato);
            }
            switch (seting.ParamService.IdCommand)
            {
                case 22:
                    if (seting.DeloPriem.DelaPriem.Count > 0)
                    {
                        //Добавляем в таблицу данные для дальнейшего анализа
                        AddKrsb krsb = new AddKrsb();
                        krsb.CreateDeloAnalizKrsb(seting.DeloPriem.DelaPriem);
                    }
                    return await Task.Factory.StartNew(() => sqlconnect.StartingProcedure(connection, ((ServiceWcf)sqlconnect.SelectFullParametrSqlReader(connection, ModelSqlFullService.ProcedureSelectParametr, typeof(ServiceWcf), ModelSqlFullService.ParamCommand(seting.ParamService.IdCommand.ToString()))).ServiceWcfCommand.Command, listparametr));
                case 23:
                    return await Task.Factory.StartNew(() => sqlconnect.StartingProcedure(connection, ((ServiceWcf)sqlconnect.SelectFullParametrSqlReader(connection, ModelSqlFullService.ProcedureSelectParametr, typeof(ServiceWcf), ModelSqlFullService.ParamCommand(seting.ParamService.IdCommand.ToString()))).ServiceWcfCommand.Command, listparametr));
                case 24:
                    return await Task.Factory.StartNew(() => sqlconnect.StartingProcedure(connection, ((ServiceWcf)sqlconnect.SelectFullParametrSqlReader(connection, ModelSqlFullService.ProcedureSelectParametr, typeof(ServiceWcf), ModelSqlFullService.ParamCommand(seting.ParamService.IdCommand.ToString()))).ServiceWcfCommand.Command, listparametr));
                case 25:
                    return await Task.Factory.StartNew(() => sqlconnect.StartingProcedure(connection, ((ServiceWcf)sqlconnect.SelectFullParametrSqlReader(connection, ModelSqlFullService.ProcedureSelectParametr, typeof(ServiceWcf), ModelSqlFullService.ParamCommand(seting.ParamService.IdCommand.ToString()))).ServiceWcfCommand.Command, listparametr));
                case 27:
                    return await Task.Factory.StartNew(() => sqlconnect.StartingProcedure(connection, ((ServiceWcf)sqlconnect.SelectFullParametrSqlReader(connection, ModelSqlFullService.ProcedureSelectParametr, typeof(ServiceWcf), ModelSqlFullService.ParamCommand(seting.ParamService.IdCommand.ToString()))).ServiceWcfCommand.Command, listparametr));
                default:
                    return null;
            }
        }

        public async Task<DataSet> TaskSqlProcedureKam5(string connection, FullSetting seting)
        {
            var sqlconnect = new SqlConnectionType();
            GenerateParametrSql.GenerateParametrSql sql = new GenerateParametrSql.GenerateParametrSql();
            Dictionary<string, string> listparametr = new Dictionary<string, string>();
            if (seting.ReportRvs.Qvartal != 0)
            {
                sql.CreateParamert(ref listparametr, seting.ReportRvs.GetType(), seting.ReportRvs);
            }
            switch (seting.ParamService.IdCommand)
            {
                case 28:
                    return await await Task.Factory.StartNew(() => sqlconnect.ProcedureReturnTable(connection, ((ServiceWcf)sqlconnect.SelectFullParametrSqlReader(connection, ModelSqlFullService.ProcedureSelectParametr, typeof(ServiceWcf), ModelSqlFullService.ParamCommand(seting.ParamService.IdCommand.ToString()))).ServiceWcfCommand.Command, seting.ModelUser.UserNameGuide, listparametr));
                default:
                    return null;
            }
        }
    }
}