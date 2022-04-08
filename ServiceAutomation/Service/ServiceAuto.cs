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
using AisPoco.Ifns51.ToAis;
using EfDatabaseAutomation.Automation.BaseLogica.IdentificationFace;
using EfDatabaseAutomation.Automation.BaseLogica.SelectObjectDbAndAddObjectDb;
using LibaryDocumentGenerator.Documents.Template;
using LibaryXMLAuto.ReadOrWrite.SerializationJson;
using SqlLibaryIfns.ZaprosSelectNotParam;
using EfDatabaseAutomation.Automation.Base;
using LibaryDocumentGenerator.Documents.TemplateExcel;

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
            var selectFull = new SelectFull(_parameterConfig.ConnectionString);
            return await Task.Factory.StartNew(() => selectFull.GenerateStreamToSqlViewFile( sqlSelect.SelectUser, "REPORTSQLSERVER", sqlSelect.SelectInfo, _parameterConfig.PathSaveTemplate));
        }

        /// <summary>
        /// Выборка
        /// </summary>
        /// <param name="sqlSelect">Запрос</param>
        /// <returns></returns>
        public async Task<string> Select(LogicsSelectAutomation sqlSelect)
        {
            return await Task.Factory.StartNew(() =>
            {
                string model = null;
                if (sqlSelect.SelectUser != null)
                {
                    Type type = Type.GetType($"{sqlSelect.FindNameSpace}, {sqlSelect.NameDll}");
                    model = (string)typeof(SelectAll).GetMethod("SqlModelAutomation")?.MakeGenericMethod(type).Invoke(new SelectAll(), new object[] { sqlSelect });
                }
                return model;
            });
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
                if (model != null)
                {
                    var type = Type.GetType($"{model.ParameterProcedureWeb.ModelClassFind}, EfDatabaseAutomation");
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
        /// Выгрузка файла для ОКП 1 ЕАЭС-обмен
        /// </summary>
        /// <param name="numberElement">Ун записи</param>
        /// <returns></returns>
        public async Task<Stream> LoadFileEasJournal(int numberElement)
        {
            var selectAll = new SelectAll();
            return await Task.Factory.StartNew(() => selectAll.LoadFileEasJournal(numberElement));
        }

        /// <summary>
        /// Метод добавление ИНН для ввода
        /// </summary>
        /// <param name="templateModel">Шаблон для добавления</param>
        /// <param name="userIdGuid">GUID Пользователя</param>
        /// <returns></returns>
        public async Task AddInnToModel(TemplateProcedure templateModel, string userIdGuid)
        {
            await Task.Factory.StartNew(() =>
            {
                var model = new ModelGetPost();
                model.AddInnModel(templateModel, userIdGuid);
                model.Dispose();
            });
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
        public List<LibaryXMLAutoModelXmlSql.PreCheck.Ifns51.FromAis.SrvToLoad> LoadModelPreCheck(string idTemplate)
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
        public string LoadModelPreCheckModel(AisPoco.Ifns51.FromAis.AisParsedData model)
        {
            var modelLoad = new ModelGetPost();
            var modelReturn = modelLoad.LoadModelPreCheck(model);
            modelLoad.Dispose();
            return modelReturn;
        }

        /// <summary>
        /// Снятие статуса повторной отработки
        /// </summary>
        /// <param name="idModels">Уникальные номера моделей</param>
        /// <param name="status">Статус обработки ветки</param>
        public async Task CheckStatus(List<int> idModels, string status = null)
        {
            await Task.Factory.StartNew(() =>{
                var modelLoad = new ModelGetPost();
                modelLoad.CheckStatus(idModels, status);
                modelLoad.Dispose();
            });
        }

        /// <summary>
        /// Генерация докладной записки ЮЛ
        /// </summary>
        /// <param name="innUl">ИНН ЮЛ</param>
        /// <param name="year">Год отчета выгрузки</param>
        /// <returns></returns>
        public async Task<Stream> GenerateNoteReportUl(string innUl, int year)
        {
            return await Task.Factory.StartNew(() =>
            {
                try
                {
                    var model = new ModelGetPost();
                    var card = model.CardUi(innUl, year);
                    model.Dispose();
                    if (card != null)
                    {
                        ReportNote report = new ReportNote();
                        report.CreateDocument(_parameterConfig.PathSaveTemplate, card, year);
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
        /// Генерация отчета по АСК НДС ИНН и ГОД отсчета периода 3 последних года от текущего
        /// </summary>
        /// <param name="innUl">ИНН ЮЛ</param>
        /// <param name="year">Год отчета выгрузки</param>
        /// <returns></returns>
        public async Task<Stream> GenerateReportAskNds(string innUl, int year)
        {
            return await Task.Factory.StartNew(() =>
            {
                try
                {
                    var model = new ModelGetPost();
                    var card = model.CardUiAskNds(innUl, year);
                    model.Dispose();
                    if (card != null)
                    {
                        ReportAskNds report = new ReportAskNds();
                        report.CreateDocument(_parameterConfig.PathSaveTemplate, card, year);
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
        /// Генерация документа книги покупок продаж шаблон
        /// </summary>
        /// <param name="innUl"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public async Task<Stream> GenerateBookSales(string innUl, int year)
        {
            return await Task.Factory.StartNew(() =>
            {
                try
                {
                    var model = new ModelGetPost();
                    var card = model.CardUiBookSales(innUl, year);
                    model.Dispose();
                    if (card != null)
                    {
                        TemplateBookSalesBank report = new TemplateBookSalesBank();
                        report.CreateDocument(_parameterConfig.PathSaveTemplate, card, year);
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
                        var type = Type.GetType($"{model.ParameterProcedureWeb.ModelClassFind}, EfDatabaseAutomation");
                        model = (ModelSelect)typeof(SqlSelect).GetMethod("ResultSelectProcedureString")?.MakeGenericMethod(type).Invoke(new SqlSelect(), new object[] {model});
                        EfDatabaseAutomation.Automation.BaseLogica.SqlSelect.XsdDTOSheme.Statement statement = (EfDatabaseAutomation.Automation.BaseLogica.SqlSelect.XsdDTOSheme.Statement)serializeJson.JsonDeserializeObjectClass<EfDatabaseAutomation.Automation.BaseLogica.SqlSelect.XsdDTOSheme.Statement>(model.ResultSelectProcedureWeb);
                        if (statement != null)
                        {
                            ReportStatement reportStatement = new ReportStatement();
                            reportStatement.CreateDocument(_parameterConfig.PathSaveTemplate, statement);
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
        public async Task CheckStatusError(List<long> idDocument)
        {
            await Task.Factory.StartNew(() => {
                IdentificationAddorEditFace identification = new IdentificationAddorEditFace();
                identification.IsCheckError(idDocument);
            });
        }

        /// <summary>
        /// Все подписанты в БД
        /// </summary>
        /// <returns></returns>
        public async Task<string> AllSender()
        {
            SelectAllObjectDb select = new SelectAllObjectDb();
            return await Task.Factory.StartNew(() =>
            {
                var sender = select.AllSender();
                select.Dispose();
                return sender;
            });
        }

        /// <summary>
        /// Справочник подписантов Акты Извещения Решения
        /// </summary>
        /// <returns></returns>
        public async Task<string> AllSenderTaxJournal()
        {
            SelectAllObjectDb select = new SelectAllObjectDb();
            return await Task.Factory.StartNew(() =>
            {
                var senderDepartment = select.AllSenderDepartment();
                select.Dispose();
                return senderDepartment;
            });
        }
        /// <summary>
        /// Добавление и редактирование Отделов и подписантов к ним
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public async Task<DepartamentOtdel> AddAndEditDepartment(DepartamentOtdel department)
        {
            return await Task.Factory.StartNew(() =>
            {
                AddAllObjectDb add = new AddAllObjectDb();
                var model = add.AddAndEditDepartment(department);
                add.Dispose();
                if (model == null) return null;
                SerializeJson json = new SerializeJson();
                SignalRLibraryAutomations.ConnectAutomations.HubAutomations.SubscribeDepartmentSender(json.JsonLibaryIgnoreDate(model));
                return model;
            });
        }
        /// <summary>
        /// Выгрузка сводной таблицы
        /// </summary>
        /// <param name="inn">ИНН</param>
        /// <returns></returns>
        public async Task<Stream> LoadFileSummarySales(string inn)
        {
            return await Task.Factory.StartNew(() =>
            {
                var selectFull = new SelectFull(_parameterConfig.ConnectionString);
                return selectFull.GenerateSummarySales(_parameterConfig.PathSaveTemplate, inn);
            });
        }
        /// <summary>
        /// Добавление регистрационных номеров патента для отработки
        /// 
        /// </summary>
        /// <param name="templatePatent">Шаблон для добавления</param>
        /// <param name="userIdGuid">GUID Пользователя</param>
        /// <returns></returns>
        public async Task AddRegNumberPatent(TemplatePatent templatePatent, string userIdGuid)
        {
            await Task.Factory.StartNew(() =>
            {
                var model = new ModelGetPost();
                model.AddRegNumPatentModel(templatePatent, userIdGuid);
                model.Dispose();
            });
        }
        /// <summary>
        /// Добавление ИНН для регистрации учетных действий
        /// </summary>
        /// <param name="templateInnPattern">Шаблон для добавления</param>
        /// <param name="userIdGuid">GUID Пользователя</param>
        /// <returns></returns>
        public async Task AddFlFaceMainRegistration(TemplateInnPattern templateInnPattern, string userIdGuid)
        {
            await Task.Factory.StartNew(() =>
            {
                var model = new ModelGetPost();
                model.AddFlFaceMainRegistration(templateInnPattern, userIdGuid);
                model.Dispose();
            });
        }

        /// <summary>
        /// Подстановка статуса принудительно обработан
        /// </summary>
        /// <param name="inn">ИНН</param>
        /// <param name="isExecute">Ун принудительного статуса</param>
        /// <returns></returns>
        public async Task CheckStatusFl(string inn, bool isExecute)
        {
            await Task.Factory.StartNew(() =>
            {
                IdentificationAddorEditFace identification = new IdentificationAddorEditFace();
                identification.IsCheckErrorRegInn(inn, isExecute);
                identification.Dispose();
            });
        }
    }
}