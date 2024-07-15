using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using AttributeHelperModelXml;
using EfDatabaseAutomation.Automation.BaseLogica.SaveAndLoadInterrogationOfWitnesses.ModelInterrogationOfWitnesses;

namespace EfDatabaseAutomation.Automation.BaseLogica.SaveAndLoadInterrogationOfWitnesses
{
    public class SaveAndLoadInterrogationOfWitnesses
    {

        private string PathSaveExcel { get; set; }

        public Base.Automation Automation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pathSaveExcel">Путь сохранения документа</param>
        public SaveAndLoadInterrogationOfWitnesses(string pathSaveExcel)
        {
            Automation = new Base.Automation();
            Automation.Database.CommandTimeout = 120000;
            PathSaveExcel = pathSaveExcel;
        }
        /// <summary>
        /// Загрузка списков для отработки свидетелей организации 
        /// </summary>
        /// <param name="uploadFileModel">Загружаемый файл</param>
        /// <param name="typeDepartment">Тип отдела</param>
        /// <param name="userIdGuid">Guid пользователя</param>
        public string LoadAndSaveModel(UploadFile.UploadFile uploadFileModel, string typeDepartment, string userIdGuid)
        {
            KoograXlsxToDataTable.KoograXlsxToDataTable koograXlsxToDataTable = new KoograXlsxToDataTable.KoograXlsxToDataTable();
            foreach (var modelFile in uploadFileModel.Upload)
            {
                var fullPathFile = string.Concat(PathSaveExcel, modelFile.NameFile);
                File.WriteAllBytes(fullPathFile, modelFile.BlobFile);
                switch (typeDepartment)
                {
                    case "ОКП":
                        DataNamesMapper<Organization> mapperOrganization = new DataNamesMapper<Organization>();
                        DataNamesMapper<Counterpart> mapperCounterpart = new DataNamesMapper<Counterpart>();
                        var dataListOrganization = koograXlsxToDataTable.GetDateTableXslx(fullPathFile, "Лист1"); //Заменил
                        var dataListCounterpart = koograXlsxToDataTable.GetDateTableXslx(fullPathFile, "Лист2"); //Заменил
                        var allModelFileKp7 = new ModelInterrogationOfWitnesses.ModelInterrogationOfWitnesses()
                        {
                            Organization = mapperOrganization.Map(dataListOrganization).ToArray(),
                            Counterpart = mapperCounterpart.Map(dataListCounterpart).ToArray()
                        };
                        AddInterrogationOfWitnesses(allModelFileKp7,38, userIdGuid);
                        break;
                    case "Регистрация":
                        DataNamesMapper<CeoManager> mapperCeoManager = new DataNamesMapper<CeoManager>();
                        var dataListCeoManager = koograXlsxToDataTable.GetDateTableXslx(fullPathFile, "Лист1"); //Заменил
                        var allModelFileR = new ModelInterrogationOfWitnesses.ModelInterrogationOfWitnesses()
                        {
                            CeoManager = mapperCeoManager.Map(dataListCeoManager).ToArray()
                        };
                        AddInterrogationOfWitnesses(allModelFileR, 52, userIdGuid);
                        break;
                }
            }
            return "Файл успешно загружен!!!";
        }

        /// <summary>
        /// Добавление регистрационных номеров в систему для отработки
        /// </summary>
        /// <param name="modelInterrogationOfWitnesses">Список сотрудников</param>
        /// <param name="indexProcedure">Ун процедуры в выборке</param>
        /// <param name="userIdGuid">GUID Пользователя</param>
        private void AddInterrogationOfWitnesses(ModelInterrogationOfWitnesses.ModelInterrogationOfWitnesses modelInterrogationOfWitnesses, int indexProcedure, string userIdGuid)
        {
            try
            {
                var logicModel = Automation.LogicsSelectAutomations.FirstOrDefault(logic => logic.Id == indexProcedure);
                if (logicModel != null)
                {
                    EventSqlEf.EventSqlEf eventMessage = new EventSqlEf.EventSqlEf() { UserNameGuid = userIdGuid };
                    var con = (SqlConnection)Automation.Database.Connection;
                    con.FireInfoMessageEventOnUserErrors = true;
                    Automation.Database.CommandTimeout = 120000;
                    con.InfoMessage += eventMessage.Con_InfoMessageSignalR;
                    using (var buffer = new MemoryStream())
                    {
                        var serializer = new XmlSerializer(typeof(ModelInterrogationOfWitnesses.ModelInterrogationOfWitnesses));
                        serializer.Serialize(buffer, modelInterrogationOfWitnesses);
                        buffer.Seek(0, SeekOrigin.Begin);
                        using (XmlReader reader = XmlReader.Create(buffer))
                        {
                            Automation.Database.ExecuteSqlCommand(logicModel.SelectUser, new SqlParameter(logicModel.SelectedParametr.Split(',')[0], SqlDbType.Xml) {Value = new SqlXml(reader)});
                            reader.Close();
                            reader.Dispose();
                        }
                        buffer.Close();
                        buffer.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                Loggers.Log4NetLogger.Error(ex);
            }
        }
    }
}
