using LibaryXMLAuto.ReadOrWrite.SerializationJson;
using System;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using EfDatabaseAutomation.Automation.Base;
using EfDatabaseAutomation.Automation.BaseLogica.AutoLogicInventory.ModelBarcode;
using EfDatabaseAutomation.Automation.BaseLogica.AutoLogicInventory.ModelFilter;
using EfDatabaseAutomation.Automation.BaseLogica.AutoLogicInventory.ModelWebSyteInventory;
using LibaryXMLAuto.ReadOrWrite;
using DirectoryDocument = EfDatabaseAutomation.Automation.Base.DirectoryDocument;
using GrnInventory = EfDatabaseAutomation.Automation.Base.GrnInventory;
using InfoDocument = EfDatabaseAutomation.Automation.Base.InfoDocument;


namespace EfDatabaseAutomation.Automation.BaseLogica.SelectObjectDbAndAddObjectDb
{
   public class SelectAllObjectDb : IDisposable
    {

        public Base.Automation AutomationContext { get; set; }

        public SelectAllObjectDb()
        {
            AutomationContext?.Dispose();
            AutomationContext = new Base.Automation();
        }


        /// <summary>
        /// Все подписанты БД
        /// </summary>
        /// <returns></returns>
        public string AllSender()
        {
            SerializeJson json = new SerializeJson();
            return json.JsonLibaryIgnoreDate(AutomationContext.SenderTaxJournalOkp2);
        }
        /// <summary>
        /// Сопоставление подписи отделу подписания Акты Решения Извещения
        /// </summary>
        /// <returns></returns>
        public string AllSenderDepartment()
        {
            SerializeJson json = new SerializeJson();
            return json.JsonLibaryIgnoreDate(AutomationContext.DepartamentOtdels.Include(x=>x.SenderTaxJournalOkp2));
        }
        /// <summary>
        /// Все сотрудники организации
        /// </summary>
        /// <param name="inn">ИНН организации</param>
        /// <returns></returns>
        public string AllUsersOrg(string inn)
        {
            SerializeJson json = new SerializeJson();
            var selectOrg = AutomationContext.MainOrgs.FirstOrDefault(x => x.Inn == inn);
            return json.JsonLibaryIgnoreDate(AutomationContext.UserOrgs.Where(x=>x.IdOrg == selectOrg.IdOrg));
        }

        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsers">Ун пользователя</param>
        /// <returns></returns>
        public string AllQuestions(int idUsers)
        {
            SerializeJson json = new SerializeJson();
            return json.JsonLibaryIgnoreDate(AutomationContext.QuestionsAndUsers.Where(x => x.IdUser == idUsers).Select(x=>new 
            {
                x.IdQuestions, 
                x.IdUser,
                x.ModelQuestions
            }));
        }
        /// <summary>
        /// Выгрузка всех документов реестра 
        /// </summary>
        /// <returns></returns>
        /// <param name="virtualFilter">Виртуальный фильтр коллекции</param>
        public string AllOgrnInventory(VirtualFilterToServer virtualFilter)
        {
            SerializeJson json = new SerializeJson();
            var xml = new XmlReadOrWrite();
            var selectParameters = AutomationContext.LogicsSelectAutomations.FirstOrDefault(x => x.Id == 43);
            var result = AutomationContext.Database.SqlQuery<string>(selectParameters.SelectUser,
                new SqlParameter(selectParameters.SelectedParametr.Split(',')[0], virtualFilter.IdFilter),
                new SqlParameter(selectParameters.SelectedParametr.Split(',')[1], virtualFilter.NameFilter),
                new SqlParameter(selectParameters.SelectedParametr.Split(',')[2], virtualFilter.LoginUser),
                new SqlParameter(selectParameters.SelectedParametr.Split(',')[3], virtualFilter.IsHiddenWeb)).ToArray();
            var modelWebSyte = (ModelWebSyte)xml.ReadXmlText(string.Join("", (string[])result), typeof(ModelWebSyte));
            return json.JsonLibaryIgnoreDate(modelWebSyte);
        }
        /// <summary>
        /// Выгрузка всех документов справочник АИС 3
        /// </summary>
        /// <returns></returns>
        public string AllDirectoryDocument()
        {
            SerializeJson json = new SerializeJson();
            var modelSelect = AutomationContext.Database.SqlQuery<DirectoryDocument>("Select IdDocumentDirectory, NameDocumentDataBase, DateCreate From DirectoryDocument").ToArray();
            return json.JsonLibaryIgnoreDate(modelSelect);
        }
        /// <summary>
        /// Справочник пользовательской информации
        /// </summary>
        /// <returns></returns>
        public string AllInfoDocument()
        {
            SerializeJson json = new SerializeJson();
            var modelSelect = AutomationContext.Database.SqlQuery<InfoDocument>("Select IdInfo, NameDocumentInfo, DateCreate From InfoDocument").ToArray();
            return json.JsonLibaryIgnoreDate(modelSelect);
        }
        /// <summary>
        /// Запрос всех контейнеров ФКУ
        /// </summary>
        /// <returns></returns>
        public string AllDocumentContainer()
        {
            SerializeJson json = new SerializeJson();
            var modelSelect = AutomationContext.Database.SqlQuery<DocumentContainer>("Select IdContainer, BarcodeContainer, CountCurrent, CountDocumentMin, CountDocumentMax, IsFinishContainer, DateCreate  From DocumentContainer").ToArray();
            return json.JsonLibaryIgnoreDate(modelSelect);
        }
        /// <summary>
        /// Все процессы и их статусы
        /// </summary>
        /// <returns></returns>
        public string AllEventProcessError()
        {
            SerializeJson json = new SerializeJson();
            return json.JsonLibaryIgnoreDate(AutomationContext.EventProcessErrors.Include(x=>x.StatusEvent).ToArray());
        }
        /// <summary>
        /// Детализация ошибок по процессу
        /// </summary>
        /// <param name="idProcess">Ун процесса</param>
        /// <returns></returns>
        public string AllDetailingEventError(int idProcess)
        {
            SerializeJson json = new SerializeJson();
            return json.JsonLibaryIgnoreDate(AutomationContext.GrnInventoryAndEventProcessErrors.Include(x => x.GrnInventory).Include(xx=>xx.GrnInventory.AisGrnDocument)
                .Where(model=>model.IdProcess ==idProcess).Select(m=>new
                {
                    m.GrnInventory.NumberOgrnGrn,
                    m.GrnInventory.AisGrnDocument
                }).ToArray());
        }

        /// <summary>
        /// Отбор всех штрих-кодов для генерации документа 
        /// </summary>
        /// <param name="grnInventory">ГРН документ</param>
        /// <returns></returns>
        public Barcode[] SelectAllBarcode(GrnInventory grnInventory)
        {
            var idStatus = new int[] {1, 3};
            var isError = from grn in AutomationContext.GrnInventories
                join ev in AutomationContext.GrnInventoryAndEventProcessErrors on grn.IdDocGrn equals ev.IdDocGrn
                join eventProcess in AutomationContext.EventProcessErrors on ev.IdProcess equals eventProcess.IdProcess
                where grn.NumberOgrnGrn == grnInventory.NumberOgrnGrn & idStatus.Contains(eventProcess.IdStatusEvent)
                          select new
                          {
                              grn, ev, eventProcess
                          };
            if (isError.FirstOrDefault() != null)
            {
                return null;
            }
            return AutomationContext.DocumentInventories.Where(doc => doc.IdDocGrn == grnInventory.IdDocGrn & doc.GuidDocument!=null).Select(doc =>
                new Barcode()
                {
                    IdDocument = doc.IdDocument,
                    GuidDocument = doc.GuidDocument,
                    FullPathPng = null
                }).ToArray();
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
