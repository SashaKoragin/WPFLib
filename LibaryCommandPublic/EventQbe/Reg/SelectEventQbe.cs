using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAIS3Windows.ButtonsClikcs.SelectQbe;
using ViewModelLib.ModelTestAutoit.PublicModel.SelectBranch;
using ViewModelLib.ModelTestAutoit.PublicModel.QbeSelect;

namespace LibraryCommandPublic.EventQbe.Reg
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
        /// <param name="branch">Ветка для принятия решения</param>
        /// <param name="eventQbe">Класс с событиями</param>
        public void AddEvent(QbeClass qbeselect,Branch branch, SelectQbe eventQbe)
        {
            switch (branch.Select.NumBranch)
            {
                case 100:
                  eventQbe.Start += eventQbe.QbeZemlyOnImushestvo;
                  break;
                case 101:
                  eventQbe.Start += eventQbe.QbeTransport;
                  break;
            }
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
        /// <param name="branch">Ветка для определения отписи от собития</param>
        /// <param name="eventQbe">Класс с событиями</param>
        public void RemoveEvent(Branch branch, SelectQbe eventQbe)
        {
            switch (branch.Select.NumBranch)
            {
                case 100:
                    eventQbe.Start -= eventQbe.QbeZemlyOnImushestvo;
                    break;
                case 101:
                    eventQbe.Start -= eventQbe.QbeTransport;
                    break;
            }
            eventQbe.C -= eventQbe.SelectC;
            eventQbe.F -= eventQbe.SelectF;
        }

    }
}
