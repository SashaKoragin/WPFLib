using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Text;
using AisPoco.UserLoginScan;
using EfDatabaseAutomation.Automation.Base;
using EfDatabaseAutomation.Automation.BaseLogica.AutoLogicInventory.ModelFilter;
using EfDatabaseAutomation.Automation.BaseLogica.AutoLogicInventory.ModelMessageServer;
using EfDatabaseAutomation.Automation.BaseLogica.AutoLogicInventory.ModelReportContainer;
using EfDatabaseAutomation.Automation.SelectParametrSheme;
using LibaryXMLAuto.ReadOrWrite;
using LibaryXMLAuto.ReadOrWrite.SerializationJson;
using HeadingStatement = EfDatabaseAutomation.Automation.BaseLogica.SqlSelect.XsdDTOSheme.HeadingStatement;
using InfoViewAutomation = EfDatabaseAutomation.Automation.SelectParametrSheme.InfoViewAutomation;
using LogicsSelectAutomation = EfDatabaseAutomation.Automation.SelectParametrSheme.LogicsSelectAutomation;
using ParameterProcedureWeb = EfDatabaseAutomation.Automation.SelectParametrSheme.ParameterProcedureWeb;

namespace EfDatabaseAutomation.Automation.BaseLogica.SqlSelect.ProcedureParametr
{
    public class SqlSelect : IDisposable
    {
        /// <summary>
        /// Процедура параметров автоматизации
        /// </summary>
        private static string ProcedureSelect = "Exec [dbo].[AutomationCommandSelectWcfToSql] {0}";
        /// <summary>
        /// Процедура вытягивание логики динамических таблиц
        /// </summary>
        private static string ProcedureSelectParameterProcedureWeb = "Exec [dbo].[ProcedureSelectParameterProcedureWeb] {0}";
        public Base.Automation Automation { get; set; }

        public SqlSelect()
        {
            Automation?.Dispose();
            Automation = new Base.Automation();
        }

        /// <summary>
        /// Генерация модели с параметрами для пользовательских выборок
        /// </summary>
        /// <param name="model">Модель</param>
        /// <returns></returns>
        public ModelSelect SelectSql(ModelSelect model)
        {
            try
            {
                model.LogicsSelectAutomation = SqlSelectModel(model.ParametrsSelect.Id);
                model.InfoViewAutomation = Automation.Database.SqlQuery<InfoViewAutomation> (model.LogicsSelectAutomation.SelectedParametr).ToArray();
                return model;
            }
            catch (Exception e)
            {
                Loggers.Log4NetLogger.Error(e);
                return null;
            }

        }



        /// <summary>
        /// Запрос параметров для раз кладки и дальнейшей выборки Предпроверка генерация динамических таблиц
        /// </summary>
        /// <param name="model">Модель параметров с сайта</param>
        /// <returns></returns>
        public ModelSelect ParameterSelect(ModelSelect model)
        {
            try
            {
                model.ParameterProcedureWeb = SqlSelectParameterProcedureWeb(model.ParametrsSelect.Id);
                model.InfoViewAutomation = Automation.Database.SqlQuery<InfoViewAutomation>(model.ParameterProcedureWeb.SelectParameterTable).ToArray();
                return model;
            }
            catch (Exception e)
            {
                Loggers.Log4NetLogger.Error(e);
                return null;
            }
        }
        /// <summary>
        /// Запрос по процедурам лежащим в них выборок Предпроверка генерация динамических таблиц (сама таблица)
        /// </summary>
        /// <param name="model">С запроса</param>
        /// <returns></returns>
        public ModelSelect ResultSelectProcedure<T>(ModelSelect model)
        {
            try
            {
                SerializeJson serializeJson = new SerializeJson();
                var result =  Automation.Database.SqlQuery<T>(model.ParameterProcedureWeb.SelectUser,
                    new SqlParameter(model.ParameterProcedureWeb.ParameterProcedure.Split(',')[0], model.ParametrsSelect.IdCodeProcedure),
                                 new SqlParameter(model.ParameterProcedureWeb.ParameterProcedure.Split(',')[1], string.IsNullOrWhiteSpace(model.ParametrsSelect.Inn) ? (object)DBNull.Value : model.ParametrsSelect.Inn),
                                 new SqlParameter(model.ParameterProcedureWeb.ParameterProcedure.Split(',')[2], model.ParametrsSelect.RegNumber)).ToList();
                dynamic expand = new ExpandoObject();
                AddProperty(expand, model.ParameterProcedureWeb.ModelClassFind, result);
                model.ResultSelectProcedureWeb = serializeJson.JsonLibrary(expand);
                return model;
            }
            catch (Exception e)
            {
                Loggers.Log4NetLogger.Error(e);
                return null;
            }
        }
        /// <summary>
        /// Выгрузка выписки для формирования файла выписки
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void ResultStatement(ModelSelect model)
        {
            var result = Automation.Database.SqlQuery<HeadingStatement>(model.ParameterProcedureWeb.SelectUser,
                new SqlParameter(model.ParameterProcedureWeb.ParameterProcedure.Split(',')[0], model.ParametrsSelect.IdCodeProcedure),
                new SqlParameter(model.ParameterProcedureWeb.ParameterProcedure.Split(',')[1], string.IsNullOrWhiteSpace(model.ParametrsSelect.Inn) ? (object)DBNull.Value : model.ParametrsSelect.Inn),
                new SqlParameter(model.ParameterProcedureWeb.ParameterProcedure.Split(',')[2], model.ParametrsSelect.RegNumber)).ToList();
                //return result;
        }
        /// <summary>
        /// Выполнение процедуры возвращающая xml файл для разбора на web UI
        /// </summary>
        /// <param name="model">Модель выборки</param>
        /// <returns></returns>
        public ModelSelect ResultSelectProcedureString<T>(ModelSelect model)
        {
            try
            {
                var xml = new XmlReadOrWrite();
                SerializeJson serializeJson = new SerializeJson();
                var result = Automation.Database.SqlQuery<string>(model.ParameterProcedureWeb.SelectUser,
                new SqlParameter(model.ParameterProcedureWeb.ParameterProcedure.Split(',')[0], model.ParametrsSelect.IdCodeProcedure),
                             new SqlParameter(model.ParameterProcedureWeb.ParameterProcedure.Split(',')[1], string.IsNullOrWhiteSpace(model.ParametrsSelect.Inn) ? (object)DBNull.Value : model.ParametrsSelect.Inn),
                             new SqlParameter(model.ParameterProcedureWeb.ParameterProcedure.Split(',')[2], model.ParametrsSelect.RegNumber)).ToArray();
                var resultServer = (T)xml.ReadXmlText(string.Join("", result), typeof(T));
                model.ResultSelectProcedureWeb = serializeJson.JsonLibrary(resultServer);
                return model;
            }
            catch (Exception e)
            {
                Loggers.Log4NetLogger.Error(e);
                return null;
            }
        }
        /// <summary>
        /// Выгрузка контейнера из БД
        /// </summary>
        /// <param name="documentContainer">Контейнер документов</param>
        /// <returns></returns>
        public T SelectReportDocumentContainer<T>(DocumentContainer documentContainer)
        {
            var xml = new XmlReadOrWrite();
            var model = SqlSelectModel(45);
            var resultSql = Automation.Database.SqlQuery<string>(model.SelectUser,
                new SqlParameter(model.SelectedParametr, documentContainer.IdContainer)).ToArray();
            var resultModel = (T)xml.ReadXmlText(string.Join("", resultSql), typeof(T));
            return resultModel;
        }
        /// <summary>
        /// Процедура присваивание процессу статуса готово в случае жонглирования ГРН
        /// </summary>
        /// <param name="idProcess">Ун процесса для сброса ошибки</param>
        /// <returns></returns>
        public string SetStatusReadyProcess(int idProcess)
        {
            var model = SqlSelectModel(47);
            var resultCommandsOutput = new SqlParameter(model.SelectedParametr.Split(',')[1], DBNull.Value) {Direction = ParameterDirection.Output, Size = 8000};
            Automation.Database.ExecuteSqlCommand(model.SelectUser, new SqlParameter(model.SelectedParametr.Split(',')[0], idProcess), resultCommandsOutput );
            return (string)resultCommandsOutput.Value;
        }
        /// <summary>
        /// Удаление документа инвентаризации
        /// </summary>
        /// <param name="idDocument">Ун документа</param>
        /// <returns></returns>
        public DeleteDocumentInventory DeleteDeleteDocumentInventory(int idDocument)
        {
            var model = SqlSelectModel(49);
            var resultCommandsOutput = new SqlParameter(model.SelectedParametr.Split(',')[1], DBNull.Value) { Direction = ParameterDirection.Output, Size = 8000 };
            var statusDelete = new SqlParameter(model.SelectedParametr.Split(',')[2], DBNull.Value) { Direction = ParameterDirection.Output, Size = 8000, DbType = DbType.Int32};
            Loggers.Log4NetLogger.Info(new Exception($"Удаление документа за номером {idDocument} произведено!!!"));
            Automation.Database.ExecuteSqlCommand(model.SelectUser, new SqlParameter(model.SelectedParametr.Split(',')[0], idDocument), resultCommandsOutput, statusDelete);
            return new DeleteDocumentInventory() {MessageProcess = (string) resultCommandsOutput.Value, CodeStatus = (int) statusDelete.Value};
        }

        /// <summary>
        /// Фильтр для сайта автоматизации
        /// </summary>
        /// <param name="userLogin">Логин пользователя</param>
        /// <returns></returns>
        public string SelectModelFilter(string userLogin)
        {
            SerializeJson json = new SerializeJson();
            var model = SqlSelectModel(48);
            var filter = Automation.Database.SqlQuery<VirtualFilter>(model.SelectUser,
                new SqlParameter(model.SelectedParametr.Split(',')[0], userLogin)).ToArray();
            return json.JsonLibaryIgnoreDate(filter);
        }
        /// <summary>
        /// Запрос на пользователей все модели
        /// </summary>
        /// <returns></returns>
        public UserLoginDatabaseModel[] SelectUserModelScan()
        {
            var model = SqlSelectModel(50);
            var userLoginDatabase = Automation.Database.SqlQuery<UserLoginDatabaseModel>(model.SelectUser).ToArray();
            return userLoginDatabase;
        }

        /// <summary>
        /// Выборка модели для манипуляции
        /// </summary>
        /// <param name="id">Параметр индекса в таблицы</param>
        /// <returns></returns>
        public LogicsSelectAutomation SqlSelectModel(int id)
        {
            return Automation.Database.SqlQuery<LogicsSelectAutomation>(String.Format(ProcedureSelect, id)).ToList()[0];
        }
        /// <summary>
        /// Модель выбора процедур и параметров к ней для динамических таблиц
        /// </summary>
        /// <param name="id">Параметр индекса в таблицы</param>
        /// <returns></returns>
        private ParameterProcedureWeb SqlSelectParameterProcedureWeb(int id)
        {
            return Automation.Database.SqlQuery<ParameterProcedureWeb>(String.Format(ProcedureSelectParameterProcedureWeb, id)).FirstOrDefault();
        }

        /// <summary>
        /// Добавление в ExpandoObject динамического названия типа
        /// </summary>
        /// <param name="expando">Динамический объект ExpandoObject</param>
        /// <param name="propertyName">Наименование параметра </param>
        /// <param name="propertyValue">Объект прикрепляемый к модели</param>
        private void AddProperty(ExpandoObject expando, string propertyName, object propertyValue)
        {
            var expandoDict = expando as IDictionary<string, object>;
            if (expandoDict.ContainsKey(propertyName))
                expandoDict[propertyName] = propertyValue;
            else
                expandoDict.Add(propertyName, propertyValue);
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Automation?.Dispose();
                Automation = null;
            }
        }
        /// <summary>
        /// Метод освобождения ресурсов
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }
    }
}
