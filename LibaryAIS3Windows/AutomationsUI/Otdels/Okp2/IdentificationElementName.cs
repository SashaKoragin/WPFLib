using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAIS3Windows.AutomationsUI.Otdels.Okp2
{
    public class IdentificationElementName
    {
        /// <summary>
        /// Ветка на обработку неидентифицированных лиц
        /// </summary>
        public static string TreeIdentification = "Налоговое администрирование\\Физические лица\\2.01. Сведения о доходах ФЛ\\5.01. Неидентифицированные получатели дохода";
        /// <summary>
        /// Grid Неидентифицированные получатели дохода
        /// </summary>
        public static string GridIdentification = $"AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:OperationWithNavigatorSimpleView\\AutomationId:navigatorControl\\AutomationId:splitContainer\\AutomationId:gridConditions\\Name:List`1 row ";
        /// <summary>
        /// Просто Grid
        /// </summary>
        public static string Grid = $"AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:OperationWithNavigatorSimpleView\\AutomationId:navigatorControl\\AutomationId:splitContainer\\AutomationId:gridData";
        /// <summary>
        /// Grid Неидентифицированные получатели дохода
        /// </summary>
        public static string GridData = $"AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:OperationWithNavigatorSimpleView\\AutomationId:navigatorControl\\AutomationId:splitContainer\\AutomationId:gridData\\Name:DynamicSelect row ";
        /// <summary>
        /// фильтр Grid
        /// </summary>
        public static string GridFilter = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:OperationWithNavigatorSimpleView\\AutomationId:navigatorControl\\AutomationId:tsControlPanel\\Name:Фильтр";
        /// <summary>
        /// Значение
        /// </summary>
        public static string Memo = "Name:Значение";
        /// <summary>
        /// Обновить ветку для сведений
        /// </summary>
        public static string Update2NDFL = "Name:DockTop\\Name:Ribbon\\Name:Сведения о доходах 2-НДФЛ\\Name:Основное\\Name:Обновить";
        /// <summary>
        /// Режимы
        /// </summary>
        public static string Setting = "Name:DockTop\\Name:Ribbon\\Name:Сведения о доходах 2-НДФЛ\\Name:Дополнительно\\Name:Режимы";
        /// <summary>
        /// Окно идентификации
        /// </summary>
        public static string WinIdentification = "Name:Визуальная идентификация ФЛ по ЦУН";
        /// <summary>
        /// Обновить данные
        /// </summary>
        public static string WinUpdete = "Name:Визуальная идентификация ФЛ по ЦУН\\Name:Обновить";
        /// <summary>
        /// Отменить закрыть
        /// </summary>
        public static string WinCancel = "Name:Визуальная идентификация ФЛ по ЦУН\\Name:Отмена";
        /// <summary>
        /// Отменить закрыть
        /// </summary>
        public static string WinSelect = "Name:Визуальная идентификация ФЛ по ЦУН\\Name:Выбрать";
        /// <summary>
        /// Grid в окне 
        /// </summary>
        public static string GridWin = "Name:Визуальная идентификация ФЛ по ЦУН\\AutomationId:NavigatorControl1\\AutomationId:splitContainer\\AutomationId:gridConditions";
        /// <summary>
        /// Grid в окне 
        /// </summary>
        public static string GridWinList = "Name:Визуальная идентификация ФЛ по ЦУН\\AutomationId:NavigatorControl1\\AutomationId:splitContainer\\AutomationId:gridConditions\\Name:List`1 row ";
        /// <summary>
        /// Данные по Идентификации
        /// </summary>
        public static string GridDataWin = "Name:Визуальная идентификация ФЛ по ЦУН\\AutomationId:NavigatorControl1\\AutomationId:splitContainer\\AutomationId:gridData";
        /// <summary>
        /// Перебор найденных лиц
        /// </summary>
        public static string GridDataFaceWin = "Name:Визуальная идентификация ФЛ по ЦУН\\AutomationId:NavigatorControl1\\AutomationId:splitContainer\\AutomationId:gridData\\Name:select0 row ";
    }
}
