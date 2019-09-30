using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryAIS3Windows.Window.Otdel.It.RuleParse
{
   public class TextRuleParse
    {
        /// <summary>
        /// Колличество строк
        /// </summary>
        public static string PanelDocksCountRow = "Name:DockTop\\AutomationId:gbFilter\\AutomationId:rowCount";
        /// <summary>
        /// Дата финиш
        /// </summary>
        public static string PanelDocksDbFinish = "Name:DockTop\\AutomationId:gbFilter\\AutomationId:dtFinish";
        /// <summary>
        /// Дата старт
        /// </summary>
        public static string PanelDocksDbStart = "Name:DockTop\\AutomationId:gbFilter\\AutomationId:dtStart";

        public static string GridJurnal = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:DemandJrnlView\\AutomationId:gbAll\\AutomationId:grdJournal";
        /// <summary>
        /// Журнал
        /// </summary>
        public static string GridJournal = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:DemandJrnlView\\AutomationId:gbAll\\AutomationId:grdJournal";
        /// <summary>
        /// История ролей
        /// </summary>
        public static string HistoryJournal = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:DemandHistoryView\\AutomationId:grdDemands";
        /// <summary>
        /// Имя
        /// </summary>
        public static string Name = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:DemandHistoryView\\AutomationId:gbUser\\AutomationId:ultraExpandableGroupBoxPanel1\\AutomationId:userInfoCtrl\\AutomationId:groupBox\\AutomationId:txtFIO";
        /// <summary>
        /// Должность
        /// </summary>
        public static string Doljnost = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:DemandHistoryView\\AutomationId:gbUser\\AutomationId:ultraExpandableGroupBoxPanel1\\AutomationId:userInfoCtrl\\AutomationId:groupBox\\AutomationId:txtTitle";
        /// <summary>
        /// Отдел
        /// </summary>
        public static string Department = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:DemandHistoryView\\AutomationId:gbUser\\AutomationId:ultraExpandableGroupBoxPanel1\\AutomationId:userInfoCtrl\\AutomationId:groupBox\\AutomationId:txtDepartment";
        /// <summary>
        /// Логин
        /// </summary>
        public static string Logon = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:DemandHistoryView\\AutomationId:gbUser\\AutomationId:ultraExpandableGroupBoxPanel1\\AutomationId:userInfoCtrl\\AutomationId:groupBox\\AutomationId:txtLogon";

    }
}
