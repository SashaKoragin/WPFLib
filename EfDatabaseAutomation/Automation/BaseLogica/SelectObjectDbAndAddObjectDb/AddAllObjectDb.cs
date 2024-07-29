using EfDatabaseAutomation.Automation.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EfDatabaseAutomation.Automation.BaseLogica.SelectObjectDbAndAddObjectDb
{
   public class AddAllObjectDb : IDisposable
    {
        public Base.Automation AutomationContext { get; set; }

        public AddAllObjectDb()
        {
            AutomationContext?.Dispose();
            AutomationContext = new Base.Automation();
          
        }
        /// <summary>
        /// Добавление или редактирование подписанта на отделе
        /// </summary>
        /// <param name="department">Отдел и подписант</param>
        /// <returns></returns>
        public DepartamentOtdel AddAndEditDepartment(DepartamentOtdel department)
        {
            var departmentAddAndModified = new DepartamentOtdel()
            {
                Id = department.Id,
                IdSender = department.IdSender,
                NameDepartament = department.NameDepartament,
                NameDepartamentActiveDerectory = department.NameDepartamentActiveDerectory,
                StatusFace = department.StatusFace,
                Office = department.Office,
                Telephon = department.Telephon
            };
            try
            {
                using (var context = new Base.Automation())
                {
                    var modelDb = from dep in context.DepartamentOtdels where dep.Id == department.Id select new { DepartamentOtdel = dep };
                    if (modelDb.Any())
                    {
                        AutomationContext.Entry(departmentAddAndModified).State = System.Data.Entity.EntityState.Modified;
                        AutomationContext.SaveChanges();
                        return department;
                    }
                }
                AutomationContext.DepartamentOtdels.Add(departmentAddAndModified);
                AutomationContext.SaveChanges();
                department.Id = departmentAddAndModified.Id;
                return department;
            }
            catch (Exception e)
            {
                Loggers.Log4NetLogger.Error(e);
                return null;
            }
        }
        /// <summary>
        /// Добавление или редактирование Отдела подписанта и шаблона для допроса свидетелей
        /// </summary>
        /// <param name="departmentOtdelResponse">Отдел и подписант</param>
        /// <returns></returns>
        public DepartmentOtdelResponse AddAndEditDepartmentOtdelResponse(DepartmentOtdelResponse departmentOtdelResponse)
        {
            var departmentOtdelResponseAddAndModified = new DepartmentOtdelResponse()
            {
                IdDepartment = departmentOtdelResponse.IdDepartment,
                IdSenderResponse = departmentOtdelResponse.IdSenderResponse,
                IdTemplateResponse = departmentOtdelResponse.IdTemplateResponse,
                NameDepartment = departmentOtdelResponse.NameDepartment,
                NameDepartmentActiveDirectory = departmentOtdelResponse.NameDepartmentActiveDirectory,
                TemplateDepartment = departmentOtdelResponse.TemplateDepartment,
                Office = departmentOtdelResponse.Office,
                Phone = departmentOtdelResponse.Phone
            };
            try
            {
                using (var context = new Base.Automation())
                {
                    var modelDb = from dep in context.DepartmentOtdelResponses where dep.IdDepartment == departmentOtdelResponse.IdDepartment select new { DepartmentOtdelResponse = dep };
                    if (modelDb.Any())
                    {
                        AutomationContext.Entry(departmentOtdelResponseAddAndModified).State = System.Data.Entity.EntityState.Modified;
                        AutomationContext.SaveChanges();
                        return departmentOtdelResponse;
                    }
                }
                AutomationContext.DepartmentOtdelResponses.Add(departmentOtdelResponseAddAndModified);
                AutomationContext.SaveChanges();
                departmentOtdelResponse.IdDepartment = departmentOtdelResponseAddAndModified.IdDepartment;
                return departmentOtdelResponse;
            }
            catch (Exception e)
            {
                Loggers.Log4NetLogger.Error(e);
                return null;
            }
        }

        /// <summary>
        /// Добавление или редактирование документа дела ОГРН
        /// </summary>
        /// <param name="organizationOgrnInventory">Дело ОГРН</param>
        /// <returns></returns>
        public OrganizationOgrnInventory AddAndEditOrganizationOgrnInventory(OrganizationOgrnInventory organizationOgrnInventory)
        {
            var organizationOgrnInventoryAddAndModified = new OrganizationOgrnInventory()
            {
                IdOgrn = organizationOgrnInventory.IdOgrn,
                UserLogin = organizationOgrnInventory.UserLogin,
                NumberOgrn = organizationOgrnInventory.NumberOgrn,
                IsHiddenWeb = organizationOgrnInventory.IsHiddenWeb,
                IdStatus = organizationOgrnInventory.IdStatus
            };
            try
            {
                using (var context = new Base.Automation())
                {
                    var modelOrganization = from orgInv in context.OrganizationOgrnInventories where orgInv.NumberOgrn == organizationOgrnInventory.NumberOgrn select new { OrganizationOgrnInventory = orgInv };
                    if (modelOrganization.Any())
                    {
                        var modelDataBase = from orgInv in context.OrganizationOgrnInventories where orgInv.IdOgrn==organizationOgrnInventory.IdOgrn & orgInv.NumberOgrn == organizationOgrnInventory.NumberOgrn select new { OrganizationOgrnInventory = orgInv };
                        if (modelDataBase.Any())
                        {
                            AutomationContext.Entry(organizationOgrnInventoryAddAndModified).State = System.Data.Entity.EntityState.Modified;
                            AutomationContext.SaveChanges();
                            return organizationOgrnInventory;
                        }
                        return null;
                    }
                    else
                    {
                        if (organizationOgrnInventory.IdOgrn == 0)
                        {
                            AutomationContext.OrganizationOgrnInventories.Add(organizationOgrnInventoryAddAndModified);
                            AutomationContext.SaveChanges();
                            organizationOgrnInventory.IdOgrn = organizationOgrnInventoryAddAndModified.IdOgrn;
                            return organizationOgrnInventory;
                        }
                        var modelDataBase = from orgInv in context.OrganizationOgrnInventories where orgInv.IdOgrn == organizationOgrnInventory.IdOgrn select new { OrganizationOgrnInventory = orgInv };
                        if (modelDataBase.Any())
                        {
                            AutomationContext.Entry(organizationOgrnInventoryAddAndModified).State = System.Data.Entity.EntityState.Modified;
                            AutomationContext.SaveChanges();
                            return organizationOgrnInventory;
                        }
                        return null;
                    }

                }
            }
            catch (Exception e)
            {
                Loggers.Log4NetLogger.Error(e);
                return null;
            }
        }
        /// <summary>
        /// Добавление или редактирование ГРН Документа
        /// </summary>
        /// <param name="grnInventory">ГРН Документа</param>
        /// <returns></returns>
        public GrnInventory AddAndEditGrnInventory(GrnInventory grnInventory)
        {
            var grnInventoryAddAndModified = new GrnInventory()
            {
                IdDocGrn = grnInventory.IdDocGrn,
                IdGrnAis3 = grnInventory.IdGrnAis3,
                IdOgrn = grnInventory.IdOgrn,
                NumberOgrnGrn = grnInventory.NumberOgrnGrn,
                NameDocument = grnInventory.NameDocument,
                IsStartProcess = grnInventory.IsStartProcess,
                IsFindGrnDataBase = grnInventory.IsFindGrnDataBase,
                StatusFinish = grnInventory.StatusFinish
            };
            try
            {
                using (var context = new Base.Automation())
                {
                    var modelGrn = from grnInv in context.GrnInventories where grnInv.NumberOgrnGrn == grnInventory.NumberOgrnGrn select new { GrnInventory = grnInv };
                    if (modelGrn.Any())
                    {
                        var modelDataBase = from grnInv in context.GrnInventories where grnInv.IdDocGrn == grnInventory.IdDocGrn & grnInv.NumberOgrnGrn == grnInventory.NumberOgrnGrn select new { GrnInventory = grnInv };
                        if (modelDataBase.Any())
                        {
                            AutomationContext.Entry(grnInventoryAddAndModified).State = System.Data.Entity.EntityState.Modified;
                            AutomationContext.SaveChanges();
                            return grnInventory;
                        }
                        return null;
                    }
                    else
                    {
                        if (grnInventory.IdDocGrn == 0)
                        {
                            AutomationContext.GrnInventories.Add(grnInventoryAddAndModified);
                            AutomationContext.SaveChanges();
                            grnInventory.IdDocGrn = grnInventoryAddAndModified.IdDocGrn;
                            return grnInventory;
                        }
                        var modelDataBase = from grnInv in context.GrnInventories where grnInv.IdDocGrn == grnInventory.IdDocGrn select new { GrnInventory = grnInv };
                        if (modelDataBase.Any())
                        {
                            AutomationContext.Entry(grnInventoryAddAndModified).State = System.Data.Entity.EntityState.Modified;
                            AutomationContext.SaveChanges();
                            return grnInventory;
                        }
                        return null;
                    }

                }
            }
            catch (Exception e)
            {
                Loggers.Log4NetLogger.Error(e);
                return null;
            }
        }

        /// <summary>
        /// Добавление или Редактирование Документа под ГРН
        /// </summary>
        /// <param name="documentInventory">Документ под ГРН</param>
        /// <returns></returns>
        public DocumentInventory AddAndEditDocumentInventory(DocumentInventory documentInventory)
        {
            var documentInventoryAddAndModified = new DocumentInventory()
            {
                IdDocument = documentInventory.IdDocument,
                IdDocGrn = documentInventory.IdDocGrn,
                IdDocumentDirectory = documentInventory.IdDocumentDirectory,
                IdInfo = documentInventory.IdInfo,
                CountPage = documentInventory.CountPage,
                GuidDocument = documentInventory.GuidDocument,
                StateDocument = documentInventory.StateDocument,
                IdStatusDocument = documentInventory.IdStatusDocument
            };
            try
            {
                using (var context = new Base.Automation())
                {
                    var modelDb = from docInv in context.DocumentInventories where docInv.IdDocument == documentInventory.IdDocument select new { DocumentInventory = docInv };
                    if (modelDb.Any())
                    {
                        AutomationContext.Entry(documentInventoryAddAndModified).State = System.Data.Entity.EntityState.Modified;
                        AutomationContext.SaveChanges();
                        return documentInventory;
                    }
                }
                AutomationContext.DocumentInventories.Add(documentInventoryAddAndModified);
                AutomationContext.SaveChanges();
                documentInventory.IdDocument = documentInventoryAddAndModified.IdDocument;
                return documentInventory;
            }
            catch (Exception e)
            {
                Loggers.Log4NetLogger.Error(e);
                return null;
            }
        }
        /// <summary>
        ///  Добавление или Редактирование Краткой информации о документе
        /// </summary>
        /// <param name="infoDocument">Краткая информация о документе</param>
        /// <returns></returns>
        public InfoDocument AddAndEditAllInfoDocument(InfoDocument infoDocument)
        {
            var documentInfoAddAndModified = new InfoDocument()
            {
                IdInfo = infoDocument.IdInfo,
                NameDocumentInfo = infoDocument.NameDocumentInfo
            };
            try
            {
                using (var context = new Base.Automation())
                {
                    var modelDb = from docInfo in context.InfoDocuments where docInfo.IdInfo == infoDocument.IdInfo select new { DocumentInfo = docInfo };
                    if (modelDb.Any())
                    {
                        AutomationContext.Entry(documentInfoAddAndModified).State = System.Data.Entity.EntityState.Modified;
                        AutomationContext.SaveChanges();
                        return infoDocument;
                    }
                }
                AutomationContext.InfoDocuments.Add(documentInfoAddAndModified);
                AutomationContext.SaveChanges();
                infoDocument.IdInfo = documentInfoAddAndModified.IdInfo;
                return infoDocument;
            }
            catch (Exception e)
            {
                Loggers.Log4NetLogger.Error(e);
                return null;
            }
        }
        /// <summary>
        /// Добавление контейнера для тары ФКУ
        /// </summary>
        /// <param name="documentContainer">Документ контейнер ФКУ</param>
        /// <returns></returns>
        public DocumentContainer AddDocumentContainer(DocumentContainer documentContainer)
        {
            var documentContainerAddAndModified = new DocumentContainer()
            {
                IdContainer = documentContainer.IdContainer,
                BarcodeContainer = documentContainer.BarcodeContainer,
            };
            try
            {
                using (var context = new Base.Automation())
                {
                    var modelDb = from docContainer in context.DocumentContainers where docContainer.BarcodeContainer == documentContainer.BarcodeContainer select new { DocumentContainer = docContainer };
                    if (modelDb.Any())
                    {
                        var modelDataBase = from docContainer in context.DocumentContainers where docContainer.IdContainer == documentContainer.IdContainer & docContainer.BarcodeContainer == documentContainer.BarcodeContainer select new { DocumentContainer = docContainer };
                        if (modelDataBase.Any())
                        {
                            AutomationContext.Entry(documentContainerAddAndModified).State = System.Data.Entity.EntityState.Modified;
                            AutomationContext.SaveChanges();
                            return documentContainerAddAndModified;
                        }
                    }
                    else
                    {
                        if (documentContainer.IdContainer == 0)
                        {
                            AutomationContext.DocumentContainers.Add(documentContainerAddAndModified);
                            AutomationContext.SaveChanges();
                            documentContainer.IdContainer = documentContainerAddAndModified.IdContainer;
                            return documentContainer;
                        }
                        var modelDataBase = from docContainer in context.DocumentContainers where docContainer.IdContainer == documentContainer.IdContainer select new { DocumentContainer = docContainer };
                        if (modelDataBase.Any())
                        {
                            AutomationContext.Entry(documentContainerAddAndModified).State = System.Data.Entity.EntityState.Modified;
                            AutomationContext.SaveChanges();
                            return documentContainerAddAndModified;
                        }

                        return null;
                    }
                }
            }
            catch (Exception e)
            {
                Loggers.Log4NetLogger.Error(e);
                return null;
            }

            return null;
        }
        /// <summary>
        /// Добавление полной записи о ГРН согласно АИС 3
        /// </summary>
        /// <param name="fullNameGrn"></param>
        /// <param name="numberOgrnGrn"></param>
        /// <returns></returns>
        public int AddAndUpdateAisGrnDocument(string fullNameGrn, long numberOgrnGrn)
        {
            int idGrnAis;
            using (var context = new Base.Automation())
            {
                var docGrnInv = context.GrnInventories.First(doc => doc.NumberOgrnGrn == numberOgrnGrn);
                idGrnAis = docGrnInv.IdGrnAis3 ?? 0;
            }
            var aisGrnDocumentAddAndModified = new AisGrnDocument()
            {
                IdGrnAis3 = idGrnAis,
                FullNameGrnAis3 = fullNameGrn
            };
            try
            {
                using (var context = new Base.Automation())
                {
                    var modelDb = from docAis in context.AisGrnDocuments where docAis.IdGrnAis3 ==  idGrnAis select new { AisGrnDocuments = docAis };
                    if (modelDb.Any())
                    {
                        AutomationContext.Entry(aisGrnDocumentAddAndModified).State = System.Data.Entity.EntityState.Modified;
                        AutomationContext.SaveChanges();
                        return aisGrnDocumentAddAndModified.IdGrnAis3;
                    }
                }
                AutomationContext.AisGrnDocuments.Add(aisGrnDocumentAddAndModified);
                AutomationContext.SaveChanges();
                return aisGrnDocumentAddAndModified.IdGrnAis3;
            }
            catch (Exception e)
            {
                Loggers.Log4NetLogger.Error(e);
                return 0;
            }
        }

        public AisDocument IsVisualAisDocument(AisDocument aisDocument)
        {
            return AutomationContext.AisDocuments.FirstOrDefault(doc => doc.IdGrnAis3 == aisDocument.IdGrnAis3 && doc.DirectoryDocument.NameDocumentDataBase == aisDocument.DirectoryDocument.NameDocumentDataBase);
        }

        /// <summary>
        /// Сохранение или обновление документа АИС 3 в БД
        /// </summary>
        /// <param name="aisDocument">Документ реестра в БД АИС 3</param>
        /// <returns></returns>
        public int AddAndUpdateAisDocument(AisDocument aisDocument)
        {
            var idDirectoryDocument = AddAndUpdateDirectoryDocument(aisDocument.DirectoryDocument);
            int idAisDocument;
            using (var context = new Base.Automation())
            {
                var docDocumentInv = context.AisDocuments.FirstOrDefault(doc => doc.IdGrnAis3 == aisDocument.IdGrnAis3 && doc.DirectoryDocument.NameDocumentDataBase == aisDocument.DirectoryDocument.NameDocumentDataBase);
                idAisDocument = docDocumentInv?.IdAisDocument ?? 0;
            }
            var aisDocumentAddAndModified = new AisDocument()
            {
                IdAisDocument = idAisDocument,
                IdGrnAis3 = aisDocument.IdGrnAis3,
                IdDocumentDirectory = idDirectoryDocument,
                SmallNameDocument = aisDocument.SmallNameDocument,
                NumberDocument = aisDocument.NumberDocument,
                DateDocument = aisDocument.DateDocument,
                CountPage = aisDocument.CountPage,
                GuidDocument = aisDocument.GuidDocument,
                IsFinndRegDelo = aisDocument.IsFinndRegDelo,
            };
            try
            {
                using (var context = new Base.Automation())
                {
                    var modelDb = from docAis in context.AisDocuments where docAis.IdAisDocument == idAisDocument select new { AisDocuments = docAis };
                    if (modelDb.Any())
                    {
                        AutomationContext.Entry(aisDocumentAddAndModified).State = System.Data.Entity.EntityState.Modified;
                        AutomationContext.SaveChanges();
                        return aisDocumentAddAndModified.IdAisDocument;
                    }
                }
                AutomationContext.AisDocuments.Add(aisDocumentAddAndModified);
                AutomationContext.SaveChanges();
                return aisDocumentAddAndModified.IdAisDocument;
            }
            catch (Exception e)
            {
                Loggers.Log4NetLogger.Error(e);
                return 0;
            }
        }
        /// <summary>
        /// Обновление или добавление в справочник "Наименование документов"
        /// </summary>
        /// <param name="directoryDocument">Справочник документов АИС 3</param>
        public int AddAndUpdateDirectoryDocument(DirectoryDocument directoryDocument)
        {
            int idDirectoryDocument;
            using (var context = new Base.Automation())
            {
                var documentName = context.DirectoryDocuments.FirstOrDefault(docName => docName.NameDocumentDataBase == directoryDocument.NameDocumentDataBase);
                idDirectoryDocument = documentName?.IdDocumentDirectory ?? 0;
            }
            var directoryDocumentAddAndModified = new DirectoryDocument()
            {
                IdDocumentDirectory = idDirectoryDocument,
                NameDocumentDataBase = directoryDocument.NameDocumentDataBase
            };
            try
            {
                using (var context = new Base.Automation())
                {
                    var modelDb = from documentName in context.DirectoryDocuments where documentName.IdDocumentDirectory == idDirectoryDocument select new { DirectoryDocument = documentName };
                    if (modelDb.Any())
                    {
                        AutomationContext.Entry(directoryDocumentAddAndModified).State = System.Data.Entity.EntityState.Modified;
                        AutomationContext.SaveChanges();
                        return directoryDocumentAddAndModified.IdDocumentDirectory;
                    }
                }
                AutomationContext.DirectoryDocuments.Add(directoryDocumentAddAndModified);
                AutomationContext.SaveChanges();
                return directoryDocumentAddAndModified.IdDocumentDirectory;
            }
            catch (Exception e)
            {
                Loggers.Log4NetLogger.Error(e);
                return 0;
            }
        }
        /// <summary>
        /// Добавление или обновление записи синхронизации
        /// </summary>
        /// <param name="idDocGrn">Ун отрабатываемого ГРН</param>
        /// <param name="idUserDocument">Ун пользовательского документа</param>
        /// <param name="idAisDocument">Ун документа АИС 3</param>
        /// <param name="isAdd">Признак добавление</param>
        /// <param name="isEmpty">Признак отсутствия синхронизации</param>
        public void AddAndUpdateSynchronization(int idDocGrn, int? idUserDocument = null, int? idAisDocument = null, bool isAdd = false, bool isEmpty = false)
        {
            int idSync;
            using (var context = new Base.Automation())
            {
                var documentName = context.SynchronizationUserAndAis.FirstOrDefault(syncDoc => syncDoc.IdDocument == idUserDocument & syncDoc.IdAisDocument == idAisDocument & syncDoc.IdDocGrn==idDocGrn);
                idSync = documentName?.IdSync ?? 0;
            }
            var directoryDocumentAddAndModified = new SynchronizationUserAndAi()
            {
                IdSync = idSync,
                IdDocGrn = idDocGrn,
                IdDocument = idUserDocument,
                IdAisDocument = idAisDocument,
                IsAddDocument = isAdd,
                IsEmptyDocument = isEmpty
            };
            try
            {
                using (var context = new Base.Automation())
                {
                    var modelDb = from syncDocument in context.SynchronizationUserAndAis where syncDocument.IdSync == idSync select new { SyncDoc = syncDocument };
                    if (modelDb.Any())
                    {
                        AutomationContext.Entry(directoryDocumentAddAndModified).State = System.Data.Entity.EntityState.Modified;
                        AutomationContext.SaveChanges();
                    }
                    else
                    {
                        AutomationContext.SynchronizationUserAndAis.Add(directoryDocumentAddAndModified);
                        AutomationContext.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                Loggers.Log4NetLogger.Error(e);
            }
        }
        /// <summary>
        /// Полное сохранение задания для отработки
        /// </summary>
        /// <param name="fullKey">Ключ процесса</param>
        /// <param name="statusProcess">Статус процесса 1 ошибка 2 нет ошибки 3 создаем процесс</param>
        /// <param name="grnInventory">Список ГРН участвующих в процессе</param>
        public void FullSaveAddAndEditEventProcessError(string fullKey, int statusProcess, List<EfDatabaseAutomation.BaseLogica.AutoLogicInventory.GrnInventory> grnInventory)
        {
            var eventProcessError = AutomationContext.EventProcessErrors.Where(eventProcess => eventProcess.FullKeyProcess == fullKey).ToArray();
            if (eventProcessError.Any())
            {
                foreach (var processError in eventProcessError)
                {
                    SaveEvent(fullKey, statusProcess, grnInventory, processError.IdProcess);
                }
            }
            else
            {
                SaveEvent(fullKey, statusProcess, grnInventory, 0);
            }
        }

        /// <summary>
        /// Сохранение или обновление процессов системы
        /// </summary>
        /// <param name="fullKey">Полный ключ</param>
        /// <param name="statusProcess">Статус</param>
        /// <param name="grnInventory">Список ГРН участвующих в процессе</param>
        /// <param name="idProcess">Ун процесса если есть</param>
        private void SaveEvent(string fullKey, int statusProcess, List<EfDatabaseAutomation.BaseLogica.AutoLogicInventory.GrnInventory> grnInventory, int idProcess)
        {
            var eventProcessErrorAddAndModified = new EventProcessError()
            {
                IdProcess = idProcess,
                FullKeyProcess = fullKey,
                IdStatusEvent = statusProcess
            };
            try
            {
                using (var contextSave = new Base.Automation())
                {
                    var modelDb = from eventProcess in contextSave.EventProcessErrors where eventProcess.IdProcess == eventProcessErrorAddAndModified.IdProcess select new { EventProcess = eventProcess };

                    using (var saveAndAddEvent = new Base.Automation())
                    {
                        if (modelDb.Any())
                        {
                            saveAndAddEvent.Entry(eventProcessErrorAddAndModified).State = System.Data.Entity.EntityState.Modified;
                            saveAndAddEvent.SaveChanges();
                        }
                        else
                        {
                            saveAndAddEvent.EventProcessErrors.Add(eventProcessErrorAddAndModified);
                            saveAndAddEvent.SaveChanges();
                        }
                    }
                }
                foreach (var grn in grnInventory)
                {
                    var grnInventoryEventProcessErrorModified = new GrnInventoryAndEventProcessError()
                    {
                        Id = 0,
                        IdDocGrn = grn.IdDocGrn,
                        IdProcess = eventProcessErrorAddAndModified.IdProcess
                    };
                    using (var contextSaveGrn = new Base.Automation())
                    {
                        var grnInventoryAndEventProcessError = contextSaveGrn.GrnInventoryAndEventProcessErrors.FirstOrDefault(grnError => grnError.IdProcess == eventProcessErrorAddAndModified.IdProcess && grnError.IdDocGrn == grn.IdDocGrn);
                        using (var saveAndAddEventProcessError = new Base.Automation())
                        {
                            if (grnInventoryAndEventProcessError != null)
                            {
                                grnInventoryEventProcessErrorModified.Id = grnInventoryAndEventProcessError.Id;
                                saveAndAddEventProcessError.Entry(grnInventoryEventProcessErrorModified).State = System.Data.Entity.EntityState.Modified;
                                saveAndAddEventProcessError.SaveChanges();
                            }
                            else
                            {
                                saveAndAddEventProcessError.GrnInventoryAndEventProcessErrors.Add(grnInventoryEventProcessErrorModified);
                                saveAndAddEventProcessError.SaveChanges();
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Loggers.Log4NetLogger.Error(e);
            }
        }

        /// <summary>
        /// Обновление контейнера данными
        /// </summary>
        /// <param name="documentContainer">Контейнер для документа</param>
        public void UpdateDocumentContainer(DocumentContainer documentContainer)
        {
            var documentContainerAddAndModified = new DocumentContainer()
            {
                IdContainer = documentContainer.IdContainer,
                BarcodeContainer = documentContainer.BarcodeContainer,
                CountCurrent =  documentContainer.CountCurrent,
                CountDocumentMin = documentContainer.CountDocumentMin,
                CountDocumentMax = documentContainer.CountDocumentMax,
                IsFinishContainer = documentContainer.IsFinishContainer,
                DateCreate = documentContainer.DateCreate
            };

            AutomationContext.Entry(documentContainerAddAndModified).State = System.Data.Entity.EntityState.Modified;
            AutomationContext.SaveChanges();
        }
        /// <summary>
        /// Добавление документа в контейнер
        /// </summary>
        /// <param name="idContainer">Ун контейнера</param>
        /// <param name="idDocument">Ун документа</param>
        /// <param name="countModel">Счетчик</param>
        public void AddAddDocumentToContainer(int idContainer, int idDocument, int countModel)
        {
            var addDocumentToContainer = new AddDocumentToContainer()
            {
                Id = 0,
                IdContainer = idContainer,
                IdDocument = idDocument,
                CounterModel = countModel
            };
            AutomationContext.AddDocumentToContainers.Add(addDocumentToContainer);
            AutomationContext.SaveChanges();
        }

        /// <summary>
        /// Проставить статус организация обработана в случае ошибки
        /// </summary>
        /// <param name="inn">Инн организации</param>
        /// <returns></returns>
        public string ClosedMainOrg(string inn)
        {
            var selectMainOrg = AutomationContext.MainOrgs.FirstOrDefault(x => x.Inn == inn);
            if (selectMainOrg != null)
            {
                if (selectMainOrg.IsReady)
                {
                    return "Организация уже отработана!!!";
                }
                var mainOrgAddAndModified = new MainOrg()
                {
                    IdOrg = selectMainOrg.IdOrg,
                    IdType = selectMainOrg.IdType,
                    Inn = selectMainOrg.Inn,
                    NameOrg = selectMainOrg.NameOrg,
                    NoIn = "Не отрабатываем по условию!",
                    NoOut = "Не отрабатываем по условию!",
                    IsReady = true,
                    DateCreate = selectMainOrg.DateCreate
                };
                using (var context = new Base.Automation())
                {
                    context.Entry(mainOrgAddAndModified).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
                return "Признак не отрабатываем проставлен!!!";
            }
            return "Организация не найдена!!!";
        }
        /// <summary>
        /// Проставить статус плательщику обработана в случае ошибки
        /// </summary>
        /// <param name="userOrg"></param>
        /// <returns></returns>
        public string ClosedUserOrg(UserOrg userOrg)
        {
            var selectUserOrg = AutomationContext.UserOrgs.FirstOrDefault(x => x.IdUser == userOrg.IdUser);
            if (selectUserOrg != null)
            {
                if (selectUserOrg.IsError == false & selectUserOrg.IsGood == false)
                {
                    var userOrgAddAndModified = new UserOrg()
                    {
                        IdUser = userOrg.IdUser,
                        IdOrg = userOrg.IdOrg,
                        InnUser = userOrg.InnUser,
                        IdProcedure = userOrg.IdProcedure,
                        Family = userOrg.Family,
                        Name = userOrg.Name,
                        Surname = userOrg.Surname,
                        DateOfBirth = userOrg.DateOfBirth,
                        VidDoc = userOrg.VidDoc,
                        Seria = userOrg.Seria,
                        Number = userOrg.Number,
                        DateIn = userOrg.DateIn,
                        Code = userOrg.Code,
                        WhoIn = userOrg.WhoIn,
                        Location = userOrg.Location,
                        IsError = true,
                        IsGood = false,
                        MessageInfo = "Аннулировано в связи с ошибкой!!!"
                    };
                    using (var context = new Base.Automation())
                    {
                        context.Entry(userOrgAddAndModified).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();
                    }
                    return "Признак запись аннулирована проставлен!!!";
                }
                return "Плательщик уже отработан!!!";
            }
            return "Плательщик не найдена!!!";
        }
        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                AutomationContext?.Dispose();
                AutomationContext = null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
