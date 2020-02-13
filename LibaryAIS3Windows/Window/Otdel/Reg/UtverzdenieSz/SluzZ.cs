using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryAIS3Windows.Window.Otdel.Uregulirovanie.UtverzdenieSz
{
   public class SluzZ
   {
       /// <summary>
       /// Отправка заявлений в ЛК2
       /// </summary>
       public static string WinLk = "Телефон исполнителя";

       public static string[] WinClose = 
        {
             "Завершение пользовательского задания",
            "Вы уверены, что хотите завершить пользовательское задание?"
        };



        /// <summary>
        /// Total
        /// </summary>
        public static string Total = "ВСЕГО:";
        

        public static string WinCloseNalog = "Name:Завершение работы\\AutomationId:MessageBoxView\\AutomationId:grpBackground\\AutomationId:grpBottom\\AutomationId:btnOK";
        public static string WinErrorNalog = "Name:Информация\\AutomationId:MessageBoxView\\AutomationId:grpBackground\\AutomationId:grpBottom\\AutomationId:btnOK";

    }
}
