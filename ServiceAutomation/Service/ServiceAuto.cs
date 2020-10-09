using System;
using System.IO;
using System.Threading.Tasks;
using EfDatabaseAutomation.Automation.BaseLogica.SqlSelect.SelectAll;
using EfDatabaseAutomation.Automation.BaseLogica.SqlSelect.ProcedureParametr;
using EfDatabaseAutomation.Automation.SelectParametrSheme;
using ServiceAutomation.LoginAD.XsdShemeLogin;
using LogicsSelectAutomation = EfDatabaseAutomation.Automation.SelectParametrSheme.LogicsSelectAutomation;
using EfDatabaseAutomation.Automation.BaseLogica.ModelGetPost;
using System.Collections.Generic;
using System.Reflection;
using AisPoco.Ifns51.ToAis;
using EfDatabaseAutomation.Automation.BaseLogica.AddObjectDb;
using EfDatabaseAutomation.Automation.BaseLogica.IdentificationFace;
using EfDatabaseAutomation.Automation.BaseLogica.SqlSelect.XsdDTOSheme;
using LibaryDocumentGenerator.Documents.Template;
using Ifns51.ToAis;
using LibaryXMLAuto.ReadOrWrite.SerializationJson;
using EfDatabaseAutomation.Automation.BaseLogica.XsdAuto.FullShemeModel;
using SqlLibaryIfns.ZaprosSelectNotParam;

namespace ServiceAutomation.Service
{
    public class ServiceAuto : IServiceAuto
    {
        /// <summary>
        /// Параметры глобальной конфигурации 
        /// </summary>
        private readonly ParametrConfig.ParameterConfig _parameterConfig = new ParametrConfig.ParameterConfig();

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
        /// Создание отчета на сервере
        /// </summary>
        /// <param name="sqlSelect">С генерированный запрос с клиента</param>
        /// <returns></returns>
        public async Task<Stream> GenerateFileXlsxSqlView(LogicsSelectAutomation sqlSelect)
        {
            var selectFull = new SelectFull();
            return await Task.Factory.StartNew(() => selectFull.GenerateStreamToSqlViewFile(_parameterConfig.ConnectionString, sqlSelect.SelectUser, "REPORTSQLSERVER", sqlSelect.SelectInfo, _parameterConfig.PathSaveTemplate));
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
                model = (ModelSelect) typeof(SqlSelect).GetMethod("ParameterSelect")
                    ?.Invoke(new SqlSelect(), new object[] {model});
                Assembly db = typeof(DataBaseUlSelect).Assembly;
                if (model != null)
                {
                    var type = db.GetType(
                        $"EfDatabaseAutomation.Automation.BaseLogica.SqlSelect.XsdDTOSheme.{model.ParameterProcedureWeb.ModelClassFind}");
                    if (model.ParametrsSelect.Id == 12)
                    {
                        return (ModelSelect) typeof(SqlSelect).GetMethod("ResultSelectProcedureString")
                            ?.MakeGenericMethod(type).Invoke(new SqlSelect(), new object[] {model});
                    }
                    return (ModelSelect) typeof(SqlSelect).GetMethod("ResultSelectProcedure")?.MakeGenericMethod(type)
                        .Invoke(new SqlSelect(), new object[] {model});
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
            var modelReturn = model.AddInnModel(inn);
            model.Dispose();
            return modelReturn;
        }
        /// <summary>
        /// Выгрузка всех шаблонов в БД
        /// </summary>
        /// <returns></returns>
        public List<TemplateModel> LoadAllTemplateDb()
        {
            var model = new ModelGetPost();
            var modelReturn = model.LoadAllTemplateDb();
            model.Dispose();
            return modelReturn;
        }
        /// <summary>
        /// Подгрудка ИНН для отработки значений
        /// </summary>
        /// <param name="idTemplate">Уникальные номера шаблонов</param>
        /// <returns></returns>
        public List<SrvToLoad> LoadModelPreCheck(int[] idTemplate)
        {
            var model = new ModelGetPost();
            var modelReturn = model.LoadModelPreCheck(idTemplate);
            model.Dispose();
            return modelReturn;
        }

        /// <summary>
        /// Ответ от клиента что отработал не завис если не пришел ответ значит завис клиент
        /// </summary>
        /// <param name="model">Модель ответа</param>
        /// <returns></returns>
        public string LoadModelPreCheckModel(Ifns51.FromAis.AisParsedData model)
        {
            var modelLoad = new ModelGetPost();
            var modelReturn = modelLoad.LoadModelPreCheck(model);
            modelLoad.Dispose();
            return modelReturn;
        }

        /// <summary>
        /// Снятие статуса повторной отработки
        /// </summary>
        /// <param name="idModel">Ун модели</param>
        /// <param name="status">Статус обработки ветки</param>
        public void CheckStatus(int idModel, string status = null)
        {
            var modelLoad = new ModelGetPost();
            modelLoad.CheckStatus(idModel, status);
            modelLoad.Dispose();
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
                    model.Dispose();
                    if (card != null)
                    {
                        ReportNote report = new ReportNote();
                        report.CreateDocum(_parameterConfig.PathSaveTemplate, card, null);
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
        /// <summary>
        /// Генерация Выписки в docx
        /// </summary>
        /// <param name="model">Модель для генерации выписки</param>
        /// <returns></returns>
        public async Task<Stream> GenerateStatement(ModelSelect model)
        {
            return await Task.Factory.StartNew(() =>
                {
                    try
                    {
                        SerializeJson serializeJson = new SerializeJson();
                        model = (ModelSelect) typeof(SqlSelect).GetMethod("ParameterSelect")?.Invoke(new SqlSelect(), new object[] {model});
                        Assembly db = typeof(DataBaseUlSelect).Assembly;
                        var type = db.GetType($"EfDatabaseAutomation.Automation.BaseLogica.SqlSelect.XsdDTOSheme.{model.ParameterProcedureWeb.ModelClassFind}");
                        model = (ModelSelect)typeof(SqlSelect).GetMethod("ResultSelectProcedureString")?.MakeGenericMethod(type).Invoke(new SqlSelect(), new object[] {model});
                        Statement statement = (Statement)serializeJson.JsonDeserializeObjectClass<Statement>(model.ResultSelectProcedureWeb);
                        if (statement != null)
                        {
                            ReportStatement reportStatement = new ReportStatement();
                            reportStatement.CreateDocum(_parameterConfig.PathSaveTemplate, statement);
                            return reportStatement.FileArray();
                        }
                    }
                    catch (Exception ex)
                    {
                        Loggers.Log4NetLogger.Error(ex);
                    }
                    return null;
        });
        }
        /// <summary>
        /// Изменение статуса подписывающего лица
        /// </summary>
        /// <param name="signatureSenderTaxJournalOkp2">Ун подписи</param>
        /// <returns></returns>
        public async Task<bool> ActualizationSignature(int signatureSenderTaxJournalOkp2)
        {
            return await Task.Factory.StartNew(() =>
            {
                try
                {
                    AddObjectDb taxJournalSignature = new AddObjectDb();
                    taxJournalSignature.IsActualStatus(signatureSenderTaxJournalOkp2);
                    return true;
                }
                catch (Exception ex)
                {
                    Loggers.Log4NetLogger.Error(ex);
                }
                return false;
            });
        }
        /// <summary>
        /// Добавление УН файлов для отработки на автомате
        /// </summary>
        /// <param name="listIdFile">УН файлов</param>
        public async Task<ServiceAddFile> AddFileId(List<long> listIdFile)
        {
            return await Task.Factory.StartNew(() =>
            {
                IdentificationAddorEditFace identification = new IdentificationAddorEditFace();
                var errorOrNull = identification.AddNewIdDocument(listIdFile);
                identification.Dispose();
                return errorOrNull;
            });
        }
        /// <summary>
        /// Снятие статуса на документе
        /// </summary>
        /// <param name="idDocument">Документ</param>
        /// <returns></returns>
        public async Task CheckStatusError(long idDocument)
        {
            await Task.Factory.StartNew(() => {
                IdentificationAddorEditFace identification = new IdentificationAddorEditFace();
                identification.IsCheckError(idDocument);
            });
        }
    }
}