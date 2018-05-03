using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryCommandPublic.EventQbe.OKp4
{
   public class EventOkp
    {
        /// <summary>
        /// Подписываемся на событие проставить галочку
        /// </summary>
        /// <param name="eventOkp">Класс с событием</param>
        public void AddEvent(LibaryAIS3Windows.ButtonsClikcs.SelectQbe.EventOkp.EventOkp eventOkp)
        {
            eventOkp.Check += eventOkp.Checking;
            eventOkp.InvokeEvent();
        }
        /// <summary>
        /// Отписка от события проставки галочки
        /// </summary>
        /// <param name="eventOkp">Класс с событием</param>
        public void RemoveEvent(LibaryAIS3Windows.ButtonsClikcs.SelectQbe.EventOkp.EventOkp eventOkp)
        {
            eventOkp.Check -= eventOkp.Checking;
        }
    }
}
