using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Text;
using EfDatabaseAutomation.Automation.BaseLogica.SqlSelect.XsdDTOSheme;
using EfDatabaseAutomation.Automation.SelectParametrSheme;
using LibaryXMLAuto.ReadOrWrite;
using LibaryXMLAuto.ReadOrWrite.SerializationJson;

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
                model.ResultSelectProcedureWeb = serializeJson.JsonLibary(expand);
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
                model.ResultSelectProcedureWeb = serializeJson.JsonLibary(resultServer);
                return model;
            }
            catch (Exception e)
            {
                Loggers.Log4NetLogger.Error(e);
                return null;
            }
        }


        /// <summary>
        /// Выборка модели для манипуляции
        /// </summary>
        /// <param name="id">Параметр индекса в таблицы</param>
        /// <returns></returns>
        private LogicsSelectAutomation SqlSelectModel(int id)
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
