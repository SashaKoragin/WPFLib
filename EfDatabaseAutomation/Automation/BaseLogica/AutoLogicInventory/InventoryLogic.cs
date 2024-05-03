using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using EfDatabaseAutomation.Automation.Base;
using EfDatabaseAutomation.BaseLogica.AutoLogicInventory;
using LibaryXMLAuto.ReadOrWrite;


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
        /// Создание таблицы в виде параметра
        /// </summary>
        /// <param name="tModelParameterArray"></param>
        /// <param name="nameColumns">Наименование колонки для таблицы</param>
        /// <param name="type">Тип колонки</param>
        /// <returns></returns>
        private DataTable CreteParameterTableSql<T>(T[] tModelParameterArray, string nameColumns, Type type)
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn(nameColumns, type));
            foreach (var parameter in tModelParameterArray)
            {
                table.Rows.Add(parameter);
            }
            return table;
        }

        /// <summary>
        /// Отбор всех данных по ГРН нужно отбирать все ГРН которые StatusFinish не равен 1 это признак что все ГРН документы в ГРН отработаны (IdStatus при этом не важен это логика принятия решения)
        /// </summary>
        /// <returns></returns>
        /// <param name="userName">Имена пользователей</param>
        public ModelStartProcess SelectStartProcessInventory(string[] userName)
        {
            var xml = new XmlReadOrWrite();
            var selectParameters = AutomationContext.LogicsSelectAutomations.FirstOrDefault(x => x.Id == 41);
            var result = AutomationContext.Database.SqlQuery<string>(selectParameters.SelectUser,
                new SqlParameter
                {
                    ParameterName = selectParameters.SelectedParametr.Split(',')[0],
                    Value = CreteParameterTableSql(userName, "UserLogin", typeof(string)),
                    TypeName = "dbo.ModelUser",
                    SqlDbType = SqlDbType.Structured
                }).ToArray();
            return (ModelStartProcess)xml.ReadXmlText(string.Join("", (string[])result), typeof(ModelStartProcess));
        }
        /// <summary>
        /// Выбор документов инвентаризации готовых к формирования тары
        /// </summary>
        /// <returns></returns>
        public Base.DocumentInventory[] SelectAllDocumentInventory()
        {
           return (from doc in AutomationContext.DocumentInventories
                join grn in AutomationContext.GrnInventories on doc.IdDocGrn equals grn.IdDocGrn
                join grnError in AutomationContext.GrnInventoryAndEventProcessErrors on grn.IdDocGrn equals grnError.IdDocGrn
                join eventEr in AutomationContext.EventProcessErrors on grnError.IdProcess equals eventEr.IdProcess
                where doc.IdStatusDocument == 3 && eventEr.IdStatusEvent == 2
                select doc ).Distinct().OrderBy(x => x.IdDocGrn).ToArray();
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
