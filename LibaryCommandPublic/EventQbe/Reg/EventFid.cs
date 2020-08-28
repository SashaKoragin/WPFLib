using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCommandPublic.EventQbe.Reg
{
   public class EventFid
    {
        /// <summary>
        /// Подписываемся на событие проставить галочку
        /// </summary>
        /// <param name="eventReg">Класс с событием</param>
        public void AddEvent(LibraryAIS3Windows.ButtonsClikcs.SelectQbe.EventReg.EventReg eventReg)
        {
            eventReg.Check += eventReg.Chekerfid;
            eventReg.InvokeEvent();
        }
        /// <summary>
        /// Отписка от события проставки галочки
        /// </summary>
        /// <param name="eventReg">Класс с событием</param>
        public void RemoveEvent(LibraryAIS3Windows.ButtonsClikcs.SelectQbe.EventReg.EventReg eventReg)
        {
            eventReg.Check -= eventReg.Chekerfid;
        }
    }
}
