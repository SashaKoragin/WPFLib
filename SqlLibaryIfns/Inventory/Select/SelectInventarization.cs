using LibaryXMLAuto.ReadOrWrite.SerializationJson;
using LibaryXMLAutoInventarization.Model.ModelSelectAll;
using LibaryXMLAutoInventarization.Model.ModelProcedure;
using SqlLibaryIfns.SqlZapros.SqlConnections;

namespace SqlLibaryIfns.Inventory.Select
{
   public class SelectInventory
    {
        public string Connection  {get;set;}
        public InventarizationCommandWcfToSql Command  {get; set; }
        /// <summary>
        /// Конструктор выполнения процедуры на сервере
        /// </summary>
        /// <param name="connectin"></param>
        public SelectInventory(string connectin)
        {
            Connection = connectin;
            var sqlconnect = new SqlConnectionType();
            Command =
                (InventarizationCommandWcfToSql)
                sqlconnect.SelectFullParametrSqlReader(Connection, ModelProcedure.ModelProcedure.ProcedureSelect,
                    typeof(InventarizationCommandWcfToSql), ModelProcedure.ModelProcedure.ParamCommand("1"));
        }

        /// <summary>
        /// Выборка Всех из БД B зависимости от номера 1: Пользователи 2: Отделы и т д
        /// </summary>
        /// <returns></returns>
        public  string SelectFull(ModelParametr.ModelParametr parametr)
        {
            var sqlconnect = new SqlConnectionType();
            SerializeJson serializeJson = new SerializeJson();
            switch (parametr.IdParamSelect)
            {
                case 1:
                    return
                                serializeJson.JsonLibary(
                                    (AllUsers)
                                    sqlconnect.SelectFullParametrSqlReader(Connection, Command.InfoLogic.NameProcedure,
                                        typeof(AllUsers), ModelProcedure.ModelProcedure.ParamCommand(parametr.IdParamSelect.ToString())));
                default:
                    return null;

            }
        }
    }
}
