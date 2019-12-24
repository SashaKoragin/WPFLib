using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryAIS3Windows.AutomationsUI.Otdels.RaschetBud
{
   public class RashetBudElementName
   {
        /// <summary>
        /// Кнопка начать выяснения
        /// </summary>
       public static string StartUtoch = "Name:DockTop\\Name:Ribbon\\Name:Уточнение невыясненных поступлений\\Name:Выяснение\\Name:Начать выяснение";

        /// <summary>
        /// Передать на утверждение
        /// </summary>
       public static string Utverjdenie = "Name:DockTop\\Name:Ribbon\\Name:Формирование решения\\Name:Задание\\Name:Передать на утверждение";
        /// <summary>
        /// Все данные Grid Платежи
        /// </summary>
       public static string DateGrid ="AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:UncertainJournalNavView\\AutomationId:ctlUncertainJournal_R1\\AutomationId:grdUncertainJournal";

   }
}
