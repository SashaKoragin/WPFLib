using System;
using System.IO;
using System.Threading.Tasks;
using EfDatabaseAutomation.Automation.BaseLogica.SqlSelect.SelectAll;
using EfDatabaseAutomation.Automation.BaseLogica.SqlSelect.ProcedureParametr;
using EfDatabaseAutomation.Automation.SelectParametrSheme;
using ServiceAutomation.LoginAD.XsdShemeLogin;
using LogicsSelectAutomation = EfDatabaseAutomation.Automation.SelectParametrSheme.LogicsSelectAutomation;
using EfDatabaseAutomation.Automation.BaseLogica.ModelGetPost;
using Ifns51.ToAis;
using System.Collections.Generic;
using System.Reflection;
using EfDatabaseAutomation.Automation.BaseLogica.SqlSelect.XsdDTOSheme;
using Ifns51.FromAis;
using LibaryDocumentGenerator.Documents.Template;

namespace ServiceAutomation.Service
{
    public class ServiceAuto : IServiceAuto
    {
        /// <summary>
        /// Параметры глобальной конфигурации 
        /// </summary>
           private readonly ParametrConfig.ParametrConfig ParametrConfig = new ParametrConfig.ParametrConfig();

        /// <summary>
        /// Авторизация через домен и роли
        /// </summary>
        /// <param name="identification">Класс идентификации</param>
        /// <returns></returns>
        public async Task<Identification> Identification(Identification identification)
        {
            return await Task.Factory.StartNew(() =>
            {
                var login = new LoginAD.Login.LoginIdentificationUser();
                return login.AuthUserService(identification);
            });
        }

        /// <summary>
        /// Генерация выборки на клиенте 
        /// </summary>
        /// <param name="model">Модель</param>
        /// <returns></returns>
        public async Task<ModelSelect> GenerateSqlSelect(ModelSelect model)
        {
           var select = new SqlSelect();
           return await Task.Factory.StartNew(() => select.SelectSql(model));
        }
        /// <summary>
        /// Выборка
        /// </summary>
        /// <param name="sqlSelect">Запрос</param>
        /// <returns></returns>
        public async Task<string> Select(LogicsSelectAutomation sqlSelect)
        {
            var selectAll = new SelectAll();
            return await Task.Factory.StartNew(() => selectAll.SelectSqlAll(sqlSelect));
        }
        /// <summary>
        /// Динамическое создание моделей для сайта (Пред проверка)
        /// </summary>
        /// <param name="model">Модель параметров заступление с сайта</param>
        /// <returns></returns>
        public async Task<ModelSelect> ResultSelectProcedure(ModelSelect model)
        {
            return await Task.Factory.StartNew(() =>
            {
                model = (ModelSelect)typeof(SqlSelect).GetMethod("ParameterSelect")?.Invoke(new SqlSelect(), new object[] { model });
                Assembly db = typeof(DataBaseUlSelect).Assembly;
                if (model != null)
                {
                    var type = db.GetType($"EfDatabaseAutomation.Automation.BaseLogica.SqlSelect.XsdDTOSheme.{model.ParameterProcedureWeb.ModelClassFind}");
                    return (ModelSelect)typeof(SqlSelect).GetMethod("ResultSelectProcedure")?.MakeGenericMethod(type).Invoke(new SqlSelect(), new object[] { model });
                }
                return model;
            });
        }

        /// <summary>
        /// Выгрузка 129 файла из БД
        /// </summary>
        /// <param name="numberElement"></param>
        /// <returns></returns>
        public async Task<Stream> LoadFileTaxJournal(int numberElement)
        {
            var selectAll = new SelectAll();
            return await Task.Factory.StartNew(() => selectAll.LoadFilePdf(numberElement));
        }

        public async Task<Stream> LoadFileTax121(int numberElement)
        {
            var selectAll = new SelectAll();
            return await Task.Factory.StartNew(() => selectAll.LoadFile121(numberElement));
        }
        /// <summary>
        /// Метод добавление ИНН для ввода
        /// </summary>
        /// <param name="inn">ИНН</param>
        /// <returns></returns>
        public string AddInnToModel(string inn)
        {
            var model = new ModelGetPost();
            return model.AddInnModel(inn);
        }
        /// <summary>
        /// Подгрудка ИНН для отработки значений
        /// </summary>
        /// <returns></returns>
        public List<SrvToLoad> LoadModelPreCheck()
        {
            var model = new ModelGetPost();
            return model.LoadModelPreCheck();
        }
        /// <summary>
        /// Ответ от клиента что отработал не завис если не пришел ответ значит завис клиент
        /// </summary>
        /// <param name="model">Модель ответа</param>
        /// <returns></returns>
        public string LoadModelPreCheckModel(AisParsedData model)
        {
            var modelLoad = new ModelGetPost();
            return modelLoad.LoadModelPreCheck(model);
        }
        /// <summary>
        /// Снятие статуса повторной отработки
        /// </summary>
        /// <param name="idModel"></param>
        public void CheckStatus(int idModel,string status = null)
        {
            var modelLoad = new ModelGetPost();
            modelLoad.CheckStatus(idModel, status);
        }
        /// <summary>
        /// Генерация докладной записки ЮЛ
        /// </summary>
        /// <param name="innUl">ИНН ЮЛ</param>
        /// <returns></returns>
        public async Task<Stream> GenerateNoteReportUl(string innUl)
        {
            return await Task.Factory.StartNew(() =>
            {
                try
                {
                    var model = new ModelGetPost();
                    var card = model.CardUi(innUl);
                    if (card != null)
                    {
                        ReportNote report = new ReportNote();
                        report.CreateDocum(ParametrConfig.PathSaveTemplate, card, null);
                        return report.FileArray();
                    }
                }
                catch (Exception ex)
                {
                   Loggers.Log4NetLogger.Error(ex);
                }
                return null;
            });
        }
    }
}