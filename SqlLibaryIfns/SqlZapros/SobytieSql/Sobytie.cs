using System.Data.SqlClient;
using SignalRLibary.SignalR;
namespace SqlLibaryIfns.SqlZapros.SobytieSql
{
   public class Sobytie
    {
        public string UserNameGuid { get; set; }
        
        public Sobytie()
        {
            
        }

        public Sobytie(string userNameGuid)
        {
            UserNameGuid = userNameGuid;
        }
        /// <summary>
        /// Вывод сообщение пользователю на модель
        /// </summary>
        public string Messages { get; set; }
        /// <summary>
        /// Событие сообщения SQL Server 2008
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Con_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            Messages = e.Message;
        }

        /// <summary>
        /// Подпись на событие и переправка его в SignalR
        /// SignalR - Вынесено в отдельную библиотеку
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Con_InfoMessageSignalR(object sender, SqlInfoMessageEventArgs e)
        {
            Messages = e.Message;
            ServiceMessage.SqlServer(UserNameGuid, Messages);
        }
    }
}
