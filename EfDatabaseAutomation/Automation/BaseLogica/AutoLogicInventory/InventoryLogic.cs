using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfDatabaseAutomation.Automation.Base;
using EfDatabaseAutomation.BaseLogica.AutoLogicInventory;
using LibaryXMLAuto.ReadOrWrite;
using DocumentInventory = EfDatabaseAutomation.Automation.Base.DocumentInventory;

namespace EfDatabaseAutomation.Automation.BaseLogica.AutoLogicInventory
{
    public class InventoryLogic : IDisposable
    {
        public Base.Automation AutomationContext { get; set; }

        public InventoryLogic()
        {
            AutomationContext?.Dispose();
            AutomationContext = new Base.Automation();
        }


        /// <summary>
        /// Отбор всех данных по ГРН нужно отбирать все ГРН которые StatusFinish не равен 1 это признак что все ГРН документы в ГРН отработаны (IdStatus при этом не важен это логика принятия решения)
        /// </summary>
        /// <returns></returns>
        public ModelStartProcess SelectStartProcessInventory()
        {
            var xml = new XmlReadOrWrite();
            var selectParameters = AutomationContext.LogicsSelectAutomations.FirstOrDefault(x => x.Id == 41);
            var result = AutomationContext.Database.SqlQuery<string>(selectParameters.SelectUser).ToArray();
            return (ModelStartProcess)xml.ReadXmlText(string.Join("", (string[])result), typeof(ModelStartProcess));
        }
        /// <summary>
        /// Выбор документов инвентаризации готовых к формирования тары
        /// </summary>
        /// <returns></returns>
        public DocumentInventory[] SelectAllDocumentInventory()
        {
            return AutomationContext.DocumentInventories.Where(doc => doc.IdStatusDocument == 3).ToArray();
        }

        /// <summary>
        /// Контейнер который не заполнен и готов к заполнению
        /// </summary>
        /// <returns></returns>
        public DocumentContainer SelectFirstDocumentContainer()
        {
           return AutomationContext.DocumentContainers.FirstOrDefault(con => con.IsFinishContainer != true);
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
