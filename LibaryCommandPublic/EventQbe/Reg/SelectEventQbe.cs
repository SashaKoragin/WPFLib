using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibaryAIS3Windows.ButtonsClikcs.SelectQbe;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using ViewModelLib.ModelTestAutoit.PublicModel.QbeSelect;

namespace LibaryCommandPublic.EventQbe.Reg
{
    /// <summary>
    /// Класс для принятия решений на какие события подписываться а на какие нет
    /// </summary>
   public class SelectEventQbe
    {
        /// <summary>
        /// Добавление событий если удовлетворяет условиям пользователя
        /// </summary>
        /// <param name="qbeselect">Класс с нашей выборкой оттуда тянем условия</param>
        /// <param name="eventQbe">Класс с событиями</param>
        public void AddEvent(QbeClass qbeselect, SelectQbe eventQbe)
        {
            eventQbe.Start += eventQbe.QbeZemlyOnImushestvo;
            if (qbeselect.C.Count != 0)
            {
                eventQbe.C += eventQbe.SelectC;
            }
            if (qbeselect.F.Count != 0)
            {
                eventQbe.F += eventQbe.SelectF;
            }
            eventQbe.InvokeEvent(string.Join("/", qbeselect.C.Select(x => x.Num).ToArray()), string.Join("/", qbeselect.F.Select(x => x.Num).ToArray()));
        }
        /// <summary>
        /// Класс отписки от событий на которые подписан пользователь
        /// </summary>
        /// <param name="eventQbe">Класс с событиями</param>
        public void RemoveEvent(SelectQbe eventQbe)
        {
            eventQbe.Start -= eventQbe.QbeZemlyOnImushestvo;
            eventQbe.C -= eventQbe.SelectC;
            eventQbe.F -= eventQbe.SelectF;
        }

    }
}
