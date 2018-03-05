using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryAIS3Windows.Status
{
    /// <summary>
    /// Константы для сообщений что бы не загромождать
    /// </summary>
   public class StatusAis
   {
       /// <summary>
       /// Символизирует Status Аис3 не открыт!!!
       /// </summary>
       public const string Status1 = "Аис3 не открыт!!!";
       /// <summary>
       /// Символизирует Status Обработка приостановлена!!!
       /// </summary>
       public const string Status2 = "Обработка приостановлена!!!";
       /// <summary>
       /// Символизирует Status Обработка завершена!!!
       /// </summary>
       public const string Status3 = "Обработка завершена!!!";
       /// <summary>
       /// Символизирует Status Автомат находится в состоянии не готов работать нажмите клавишу {Tab}!!!
       /// </summary>
       public const string Status4 = "Автомат находится в состоянии не готов работать нажмите клавишу {Tab}!!!";
   }
}
