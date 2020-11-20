using System.Data.SqlClient;
using SignalRLibraryAutomations.ConnectAutomations;

namespace EfDatabaseAutomation.Automation.BaseLogica.EventSqlEf
{
    //Класс для обработки сообщений с сервера SQL с событием Con_InfoMessageSignalR
    public class EventSqlEf
    {
        public string UserNameGuid { get; set; }
        public string Messages { get; set; }
        public EventSqlEf()
        {

        }
        /// <summary>
        /// Закидывание пользователя
        /// </summary>
        /// <param name="userNameGuid">GUID Пользователя</param>
        public EventSqlEf(string userNameGuid)
        {
            UserNameGuid = userNameGuid;
        }

        /// <summary>
        /// Подпись на событие и переправка его в SignalR
        /// SignalR - Вынесено в отдельную библиотеку
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Con_InfoMessageSignalR(object sender, SqlInfoMessageEventArgs e)
        {
            Messages = e.Message;
            await HubAutomations.SqlServer(UserNameGuid, Messages);
        }
    }
}
