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
using System.Linq;
using AisPoco.Ifns51.ToAis;
using AisPoco.UserLoginScan;
using EfDatabaseAutomation.Automation.BaseLogica.IdentificationFace;
using EfDatabaseAutomation.Automation.BaseLogica.SelectObjectDbAndAddObjectDb;
using LibaryDocumentGenerator.Documents.Template;
using LibaryXMLAuto.ReadOrWrite.SerializationJson;
using EfDatabaseAutomation.Automation.Base;
using EfDatabaseAutomation.Automation.BaseLogica.AutoLogicInventory.ModelFilter;
using EfDatabaseAutomation.Automation.BaseLogica.AutoLogicInventory.ModelMessageServer;
using EfDatabaseAutomation.Automation.BaseLogica.AutoLogicInventory.ModelReportContainer;
using EfDatabaseAutomation.Automation.BaseLogica.FaceRegistryReference;
using EfDatabaseAutomation.Automation.BaseLogica.SaveAndLoadInterrogationOfWitnesses;
using EfDatabaseAutomation.Automation.BaseLogica.UploadFile;
using LibaryDocumentGenerator.Barcode;
using LibaryDocumentGenerator.Documents.TemplateExcel;
using SqlLibaryIfns.ZaprosSelectNotParam;
using DocumentInventory = EfDatabaseAutomation.Automation.Base.DocumentInventory;

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
            return await Task.Factory.StartNew(() => selectFull.GenerateStreamToSqlViewFileAutomation( sqlSelect, _parameterConfig.PathSaveTemplate));
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
        /// Выгрузка файла для ОКП 1 ЕАЭС-обмен
        /// </summary>
        /// <param name="numberElement">Ун записи</param>
        /// <returns></returns>
        public async Task<Stream> LoadFile3NdflRequirements(int numberElement)
        {
            var selectAll = new SelectAll();
            return await Task.Factory.StartNew(() => selectAll.LoadFile3NdflRequirements(numberElement));
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
        /// <summary>
        /// Добавление ИНН в БД для отработки сообщений
        /// </summary>
        /// <param name="templateInnPattern">Шаблон ИНН</param>
        /// <param name="userIdGuid">GUID Пользователя</param>
        /// <returns></returns>
        public async Task AddInnFaceRegistryReference(TemplateInnPattern templateInnPattern, string userIdGuid)
        {
            await Task.Factory.StartNew(() =>
            {
                var model = new ModelGetPost();
                model.AddRegistryReference(templateInnPattern, userIdGuid);
                model.Dispose();
            });
        }
        /// <summary>
        /// Удаление записи по ИНН
        /// </summary>
        /// <param name="inn">ИНН</param>
        /// <returns></returns>
        public async Task<string> DeleteRegistryReference(string inn)
        {
          return await Task.Factory.StartNew(() =>
            {
                var faceRegistryReference = new SelectAndAddFaceRegistryReference();
                var message = faceRegistryReference.Delete(inn);
                faceRegistryReference.Dispose();
                return message;
            });
        }
        /// <summary>
        /// Загрузка файла в БД 
        /// </summary>
        /// <param name="uploadFileModel">Модель файла Excel</param>
        /// <param name="typeDepartment">Тип отдела</param>
        /// <param name="userIdGuid">Guid пользователя</param>
        /// <returns></returns>
        public async Task<string> AddFileModel(UploadFile uploadFileModel, string typeDepartment, string userIdGuid)
        {
            return await Task.Factory.StartNew(() =>
            {
                SaveAndLoadInterrogationOfWitnesses saveAndLoadInterrogationOfWitnesses = new SaveAndLoadInterrogationOfWitnesses(_parameterConfig.PathSaveTemplate);
                return saveAndLoadInterrogationOfWitnesses.LoadAndSaveModel(uploadFileModel, typeDepartment, userIdGuid);
            });
        }
        /// <summary>
        /// Все сотрудники организации
        /// </summary>
        /// <param name="inn"></param>
        /// <returns></returns>
        public async Task<string> AllUsersOrg(string inn)
        {
            SelectAllObjectDb select = new SelectAllObjectDb();
            return await Task.Factory.StartNew(() =>
            {
                var allUsersOrg = select.AllUsersOrg(inn);
                select.Dispose();
                return allUsersOrg;
            });
        }
        /// <summary>
        /// Проставить признак по организации не отрабатываем допросы свидетелей
        /// </summary>
        /// <param name="inn">ИНН организации</param>
        /// <returns></returns>
        public async Task<string> ClosedMainOrg(string inn)
        {
            return await Task.Factory.StartNew(() =>
            {
                AddAllObjectDb add = new AddAllObjectDb();
                var model = add.ClosedMainOrg(inn);
                add.Dispose();
                return model;
            });
        }
        /// <summary>
        /// Аннулировать плательщика для автомата
        /// </summary>
        /// <param name="userOrg">Плательщик</param>
        /// <returns></returns>
        public async Task<string> ClosedUserOrg(UserOrg userOrg)
        {
            return await Task.Factory.StartNew(() =>
            {
                AddAllObjectDb add = new AddAllObjectDb();
                var model = add.ClosedUserOrg(userOrg);
                add.Dispose();
                return model;
            });
        }
        /// <summary>
        /// Запрос всех вопросов заданных сотруднику
        /// </summary>
        /// <param name="idUsers">Ун сотрудника</param>
        /// <returns></returns>
        public async Task<string> SelectQuestions(int idUsers)
        {
            SelectAllObjectDb select = new SelectAllObjectDb();
            return await Task.Factory.StartNew(() =>
            {
                var allQuestions = select.AllQuestions(idUsers);
                select.Dispose();
                return allQuestions;
            });
        }
        /// <summary>
        /// Все документы описи реестра
        /// </summary>
        /// <returns></returns>
        /// <param name="virtualFilter">Виртуальный фильтр коллекции</param>
        public async Task<string> SelectAllOgrnInventory(VirtualFilterToServer virtualFilter)
        {
            SelectAllObjectDb select = new SelectAllObjectDb();
            return await Task.Factory.StartNew(() =>
            {
                var allQuestions = select.AllOgrnInventory(virtualFilter);
                select.Dispose();
                return allQuestions;
            });
        }
        /// <summary>
        /// Выгрузка всех документов справочник АИС 3
        /// </summary>
        /// <returns></returns>
        public async Task<string> SelectAllDirectoryDocument()
        {
            SelectAllObjectDb select = new SelectAllObjectDb();
            return await Task.Factory.StartNew(() =>
            {
                var allQuestions = select.AllDirectoryDocument();
                select.Dispose();
                return allQuestions;
            });
        }
        /// <summary>
        /// Запрос справочника пользовательской информации о документе
        /// </summary>
        /// <returns></returns>
        public async Task<string> SelectAllInfoDocument()
        {
            SelectAllObjectDb select = new SelectAllObjectDb();
            return await Task.Factory.StartNew(() =>
            {
                var allQuestions = select.AllInfoDocument();
                select.Dispose();
                return allQuestions;
            });
        }



        /// <summary>
        /// Добавление и редактирование дела ОГРН
        /// </summary>
        /// <param name="organizationOgrnInventory">Дело ОГРН</param>
        /// <param name="connectionId">Ун соединения пользователя</param>
        /// <returns></returns>
        public async Task<OrganizationOgrnInventory> AddAndEditOrganizationOgrnInventory(OrganizationOgrnInventory organizationOgrnInventory, string connectionId)
        {
            return await Task.Factory.StartNew(() =>
            {
                AddAllObjectDb add = new AddAllObjectDb();
                var model = add.AddAndEditOrganizationOgrnInventory(organizationOgrnInventory);
                add.Dispose();
                if (model == null) return null;
                SerializeJson json = new SerializeJson();
                SignalRLibraryAutomations.ConnectAutomations.HubAutomations.SubscribeOrganizationOgrnInventory(json.JsonLibaryIgnoreDate(model), connectionId);
                return model;
            });
        }
        /// <summary>
        /// Добавление или редактирование ГРН Документа
        /// </summary>
        /// <param name="grnInventory">ГРН Документа</param>
        /// <param name="connectionId">Ун соединения пользователя</param>
        /// <returns></returns>
        public async Task<GrnInventory> AddAndEditGrnInventory(GrnInventory grnInventory, string connectionId)
        {
            
            return await Task.Factory.StartNew(() =>
            {
                AddAllObjectDb add = new AddAllObjectDb();
                var model = add.AddAndEditGrnInventory(grnInventory);
                add.Dispose();
                if (model == null) return null;
                SerializeJson json = new SerializeJson();
                SignalRLibraryAutomations.ConnectAutomations.HubAutomations.SubscribeGrnInventory(json.JsonLibaryIgnoreDate(model), connectionId);
                return model;
            });
        }
        /// <summary>
        /// Добавление или Редактирование Документа под ГРН
        /// </summary>
        /// <param name="documentInventory">Дело ОГРН</param>
        /// <param name="connectionId">Ун соединения пользователя</param>
        /// <returns></returns>
        public async Task<DocumentInventory> AddAndEditDocumentInventory(DocumentInventory documentInventory, string connectionId)
        {
            return await Task.Factory.StartNew(() =>
            {
                AddAllObjectDb add = new AddAllObjectDb();
                var model = add.AddAndEditDocumentInventory(documentInventory);
                add.Dispose();
                if (model == null) return null;
                SerializeJson json = new SerializeJson();
                SignalRLibraryAutomations.ConnectAutomations.HubAutomations.SubscribeDocumentInventory(json.JsonLibaryIgnoreDate(model), connectionId);
                return model;
            });
        }
        /// <summary>
        /// Сохранение краткой информации о документе
        /// </summary>
        /// <param name="infoDocument">Краткая информация о документе</param>
        /// <returns></returns>
        public async Task<InfoDocument> AddAndEditAllInfoDocument(InfoDocument infoDocument)
        {
            
            return await Task.Factory.StartNew(() =>
            {
                AddAllObjectDb add = new AddAllObjectDb();
                var model = add.AddAndEditAllInfoDocument(infoDocument);
                add.Dispose();
                if (model == null) return null;
                SerializeJson json = new SerializeJson();
                SignalRLibraryAutomations.ConnectAutomations.HubAutomations.SubscribeInfoDocument(json.JsonLibaryIgnoreDate(model));
                return model;
            });

        }
        /// <summary>
        /// Массовая генерация штрих-кодов 
        /// </summary>
        /// <param name="grnInventory">ГРН документ</param>
        /// <returns></returns>
        public async Task<Stream> PrintBarcode(GrnInventory grnInventory)
        {
            try
            {
                return await Task.Factory.StartNew(() =>
                {
                    SelectAllObjectDb select = new SelectAllObjectDb();
                    var allQuestions = select.SelectAllBarcode(grnInventory); //Здесь ошибка проверка на NULL
                    if (allQuestions != null)
                    {
                        var generateWord = new DocCodePdf417();
                        var barcode = new GenerateBarcode();
                        allQuestions.Select(docs => docs).ToList().ForEach(doc =>
                            doc.FullPathPng = barcode.GeneratePdf417(_parameterConfig.PathSaveTemplate, doc.GuidDocument));
                        generateWord.CreateDocument(_parameterConfig.PathSaveTemplate + "BarCode", allQuestions);
                        allQuestions.Select(x => x.FullPathPng).ToList().ForEach(File.Delete);
                        select.Dispose();
                        return generateWord.FileArray();
                    }
                    return null;
                });
            }
            catch (Exception e)
            {
                Loggers.Log4NetLogger.Error(e);
            }
            return null;
        }

        /// <summary>
        /// Запрос для выгрузки всех внесенных контейнеров для Тар
        /// </summary>
        /// <returns></returns>
        public async Task<string> SelectAllDocumentContainer()
        {
            SelectAllObjectDb select = new SelectAllObjectDb();
            return await Task.Factory.StartNew(() =>
            {
                var allQuestions = select.AllDocumentContainer();
                select.Dispose();
                return allQuestions;
            });
        }
        /// <summary>
        /// Добавление контейнера для формирования Тар
        /// </summary>
        /// <param name="documentContainer">Контейнер ФКУ</param>
        /// <returns></returns>
        public async Task<DocumentContainer> AddDocumentContainer(DocumentContainer documentContainer)
        {
            return await Task.Factory.StartNew(() =>
            {
                AddAllObjectDb add = new AddAllObjectDb();
                var model = add.AddDocumentContainer(documentContainer);
                add.Dispose();
                if (model == null) return null;
                SerializeJson json = new SerializeJson();
                SignalRLibraryAutomations.ConnectAutomations.HubAutomations.SubscribeDocumentContainer(json.JsonLibaryIgnoreDate(model));
                return model;
            });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="grnInventory">ГРН документ</param>
        /// <returns></returns>
        public async Task<Stream> ReportSynchronization(GrnInventory grnInventory)
        {
            try
            {
                return await Task.Factory.StartNew(() =>
                {
                    var select = new SqlSelect();
                    var logicSelect = select.SqlSelectModel(42);
                    logicSelect.SelectUser = logicSelect.SelectUser.Replace("@IdDocGrn", grnInventory.IdDocGrn.ToString()); 
                    var selectFull = new SelectFull(_parameterConfig.ConnectionString);
                    return selectFull.GenerateStreamToSqlViewFileAutomation(logicSelect, _parameterConfig.PathSaveTemplate);
                });
            }
            catch (Exception e)
            {
                Loggers.Log4NetLogger.Error(e);
            }
            return null;
        }
        /// <summary>
        /// Отчет о статистики количества листов документов
        /// </summary>
        /// <returns></returns>
        public async Task<Stream> ReportStatisticsDocumentInventory()
        {
            try
            {
                return await Task.Factory.StartNew(() =>
                {
                    var select = new SqlSelect();
                    var logicSelect = select.SqlSelectModel(44);
                    var selectFull = new SelectFull(_parameterConfig.ConnectionString);
                    return selectFull.GenerateStreamToSqlViewFileAutomation(logicSelect, _parameterConfig.PathSaveTemplate);
                });
            }
            catch (Exception e)
            {
                Loggers.Log4NetLogger.Error(e);
            }
            return null;
        }
        /// <summary>
        /// Отчет по контейнеру с документами 
        /// </summary>
        /// <param name="documentContainer">Контейнер по которому запрашивается отчет</param>
        /// <returns></returns>
        public async Task<Stream> ReportDocumentContainer(DocumentContainer documentContainer)
        {
            try
            {
                return await Task.Factory.StartNew(() =>
                {
                    var select = new SqlSelect();
                    var generateExcelReport = new ReportDocumentContainerInventory();
                    var modelContainer = select.SelectReportDocumentContainer<ReportDocumentContainer>(documentContainer);
                    generateExcelReport.CreateDocument(_parameterConfig.PathSaveTemplate, modelContainer);
                    select.Dispose();
                    return generateExcelReport.FileArray();
                });
            }
            catch (Exception e)
            {
                Loggers.Log4NetLogger.Error(e);
            }
            return null;
        }
        /// <summary>
        /// Детализированный отчет по контейнеру
        /// </summary>
        /// <param name="documentContainer">Контейнер для детализации</param>
        /// <returns></returns>
        public async Task<Stream> ReportDetailingContainer(DocumentContainer documentContainer)
        {
            try
            {
                return await Task.Factory.StartNew(() =>
                {
                    var select = new SqlSelect();
                    var logicSelect = select.SqlSelectModel(46);
                    var selectFull = new SelectFull(_parameterConfig.ConnectionString);
                    logicSelect.SelectUser = logicSelect.SelectUser.Replace("@IdContainer", documentContainer.IdContainer.ToString());
                    return selectFull.GenerateStreamToSqlViewFileAutomation(logicSelect, _parameterConfig.PathSaveTemplate);
                });
            }
            catch (Exception e)
            {
                Loggers.Log4NetLogger.Error(e);
            }
            return null;
        }
        /// <summary>
        /// Все процессы и их статусы
        /// </summary>
        /// <returns></returns>
        public async Task<string> SelectAllEventError()
        {
            SelectAllObjectDb select = new SelectAllObjectDb();
            return await Task.Factory.StartNew(() =>
            {
                var allProcessEvent = select.AllEventProcessError();
                select.Dispose();
                return allProcessEvent;
            });
        }
        /// <summary>
        /// Детализация ошибок по ГРН
        /// </summary>
        /// <param name="idProcess">Ун процесса для детализации</param>
        /// <returns></returns>
        public async Task<string> SelectDetailingEventError(int idProcess)
        {
            SelectAllObjectDb select = new SelectAllObjectDb();
            return await Task.Factory.StartNew(() =>
            {
                var allDetailingProcessEvent = select.AllDetailingEventError(idProcess);
                select.Dispose();
                return allDetailingProcessEvent;
            });
        }
        /// <summary>
        /// Процедура присваивание процессу статуса готово в случае жонглирования ГРН
        /// </summary>
        /// <param name="idProcess">Ун процесса</param>
        /// <returns></returns>
        public async Task<string> SetStatusReadyProcess(int idProcess)
        {
            try
            {
                return await Task.Factory.StartNew(() =>
                {
                    var select = new SqlSelect();
                    var messageServer = select.SetStatusReadyProcess(idProcess);
                    select.Dispose();
                    return messageServer;
                });
            }
            catch (Exception e)
            {
                Loggers.Log4NetLogger.Error(e);
            }
            return null;
        }
        /// <summary>
        /// Фильтр для сайта автоматизации
        /// </summary>
        /// <param name="userLogin">Логин пользователя</param>
        /// <returns></returns>
        public async Task<string> SelectModelFilter(string userLogin)
        {
            try
            {
                return await Task.Factory.StartNew(() =>
                {
                    var select = new SqlSelect();
                    var modelFilter = select.SelectModelFilter(userLogin);
                    select.Dispose();
                    return modelFilter;
                });
            }
            catch (Exception e)
            {
                Loggers.Log4NetLogger.Error(e);
            }
            return null;
        }
        /// <summary>
        /// Удаление документа инвентаризации со статусом 1 и 5
        /// </summary>
        /// <param name="documentInventory">Документ инвентаризации</param>
        /// <returns></returns>
        public async Task<DeleteDocumentInventory> DeleteDocumentInventory(DocumentInventory documentInventory)
        {
            try
            {
                return await Task.Factory.StartNew(() =>
                {
                    var select = new SqlSelect();
                    var messageServer = select.DeleteDeleteDocumentInventory(documentInventory.IdDocument);
                    select.Dispose();
                    return messageServer;
                });
            }
            catch (Exception e)
            {
                Loggers.Log4NetLogger.Error(e);
            }
            return null;
        }
        /// <summary>
        /// Получение пользователей для моделей ретросканирования
        /// </summary>
        /// <returns></returns>
        public async Task<UserLoginDatabaseModel[]> SelectUserScan()
        {
            try
            {
                return await Task.Factory.StartNew(() =>
                {
                    var select = new SqlSelect();
                    var modelFilter = select.SelectUserModelScan();
                    select.Dispose();
                    return modelFilter;
                });
            }
            catch (Exception e)
            {
                Loggers.Log4NetLogger.Error(e);
            }
            return null;
        }
        /// <summary>
        /// Все подписанты в БД для Допроса свидетелей
        /// </summary>
        /// <returns></returns>
        public async Task<string> AllSenderResponse()
        {
            SelectAllObjectDb select = new SelectAllObjectDb();
            return await Task.Factory.StartNew(() =>
            {
                var senderDepartment = select.AllSenderResponse();
                select.Dispose();
                return senderDepartment;
            });
        }
        /// <summary>
        /// Все шаблоны для Допроса свидетелей
        /// </summary>
        /// <returns></returns>
        public async Task<string> AllTemplateModelResponse()
        {
            SelectAllObjectDb select = new SelectAllObjectDb();
            return await Task.Factory.StartNew(() =>
            {
                var senderDepartment = select.AllTemplateModelResponse();
                select.Dispose();
                return senderDepartment;
            });
        }
        /// <summary>
        /// Все зарегистрированные отделы для Допроса свидетелей
        /// </summary>
        /// <returns></returns>
        public async Task<string> AllDepartmentOtdelResponse()
        {
            SelectAllObjectDb select = new SelectAllObjectDb();
            return await Task.Factory.StartNew(() =>
            {
                var senderDepartment = select.AllDepartmentOtdelResponse();
                select.Dispose();
                return senderDepartment;
            });
        }
        /// <summary>
        /// Добавление или редактирование Отдела подписанта и шаблона для допроса свидетелей
        /// </summary>
        /// <param name="departmentOtdelResponse">Отдел и подписант</param>
        /// <returns></returns>
        public async Task<DepartmentOtdelResponse> AddAndEditDepartmentOtdelResponse(DepartmentOtdelResponse departmentOtdelResponse)
        {
            return await Task.Factory.StartNew(() =>
            {
                AddAllObjectDb add = new AddAllObjectDb();
                var model = add.AddAndEditDepartmentOtdelResponse(departmentOtdelResponse);
                add.Dispose();
                if (model == null) return null;
                SerializeJson json = new SerializeJson();
                SignalRLibraryAutomations.ConnectAutomations.HubAutomations.SubscribeDepartmentOtdelResponse(json.JsonLibaryIgnoreDate(model));
                return model;
            });
        }
        /// <summary>
        /// Все вопросы сотруднику в области регистрации
        /// </summary>
        /// <param name="idUserRegistrationFl">Ун пользователя</param>
        public async Task<string> SelectQuestionsRegistration(int idUserRegistrationFl)
        {
            SelectAllObjectDb select = new SelectAllObjectDb();
            return await Task.Factory.StartNew(() =>
            {
                var allQuestions = select.SelectQuestionsRegistration(idUserRegistrationFl);
                select.Dispose();
                return allQuestions;
            });
        }
    }
}