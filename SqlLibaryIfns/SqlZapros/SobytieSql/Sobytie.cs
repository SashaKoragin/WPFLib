using System.Data.SqlClient;

namespace SqlLibaryIfns.SqlZapros.SobytieSql
{
   public class Sobytie
    {
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
    }
}
