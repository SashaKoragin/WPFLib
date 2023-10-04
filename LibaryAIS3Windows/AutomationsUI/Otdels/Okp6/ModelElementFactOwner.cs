using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAIS3Windows.AutomationsUI.Otdels.Okp6
{
    public class ModelElementFactOwner
    {
        /// <summary>
        /// Кнопка режимы
        /// </summary>
        public static string SartViewSender = "Name:DockTop\\Name:Ribbon\\Name:Собственность\\Name:Дополнительно\\Name:Режимы";
        /// <summary>
        /// Кнопка сведения о праве 
        /// </summary>
        public static string RightFaceZm = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:LandView_2\\AutomationId:splitContainer1\\Name:Сведения о зарегистрированных правах от органов Росреестра";

        /// <summary>
        /// Кнопка сведения о праве 
        /// </summary>
        public static string RightFaceIm = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:BuildingView_2\\AutomationId:splitContainer1\\Name:Сведения о зарегистрированных правах от органов Росреестра";

        /// <summary>
        /// Идентификация Права земля
        /// </summary>
        public static string PanelIsRightFaceZmIdent = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:LandView_2\\AutomationId:splitContainer1\\AutomationId:ultraTabControl1\\AutomationId:ultraTabPageControl1\\Name:Идентификационные сведения ";
        /// <summary>
        /// Сведения о правах Панель имущество
        /// </summary>
        public static string PanelIsRightFaceZmSved = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:LandView_2\\AutomationId:splitContainer1\\AutomationId:ultraTabControl1\\AutomationId:ultraTabPageControl5\\Name:Сведения о зарегистрированных правах от органов Росреестра";
        /// <summary>
        /// Идентификация Права имущество
        /// </summary>
        public static string PanelIsRightFaceImIdent = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:BuildingView_2\\AutomationId:splitContainer1\\AutomationId:ultraTabControl1\\AutomationId:ultraTabPageControl1\\Name:Идентификационные сведения ";
        /// <summary>
        /// Сведения о правах Панель имущество
        /// </summary>
        public static string PanelIsRightFaceImSved = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:BuildingView_2\\AutomationId:splitContainer1\\AutomationId:ultraTabControl1\\AutomationId:ultraTabPageControl5\\Name:Сведения о зарегистрированных правах от органов Росреестра";
        /// <summary>
        /// Проверка на внутреннюю ошибку
        /// </summary>
        public static string IsErrorIm = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:BuildingView_2\\AutomationId:splitContainer1\\AutomationId:ultraTabControl1\\AutomationId:ultraTabPageControl5\\AutomationId:ultraGroupBox44\\AutomationId:ultraGroupBox45\\AutomationId:navigatorControl4\\AutomationId:splitContainer\\AutomationId:gridData";

        /// <summary>
        /// Проверка на внутреннюю ошибку
        /// </summary>
        public static string IsErrorZm = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:LandView_2\\AutomationId:splitContainer1\\AutomationId:ultraTabControl1\\AutomationId:ultraTabPageControl5\\AutomationId:ultraGroupBox33\\AutomationId:ultraGroupBox34\\AutomationId:navigatorControl4\\AutomationId:splitContainer\\AutomationId:gridData";
        /// <summary>
        /// Обновить если ошибка
        /// </summary>
        public static string IsErrorUpdateIm = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:BuildingView_2\\AutomationId:splitContainer1\\AutomationId:ultraTabControl1\\AutomationId:ultraTabPageControl5\\Name:Сведения о зарегистрированных правах от органов Росреестра\\AutomationId:toolStrip3\\Name:Обновить";
        /// <summary>
        /// Обновить если ошибка
        /// </summary>
        public static string IsErrorUpdateZm = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:LandView_2\\AutomationId:splitContainer1\\AutomationId:ultraTabControl1\\AutomationId:ultraTabPageControl5\\AutomationId:ultraGroupBox33\\AutomationId:toolStrip3\\Name:Обновить";
        /// <summary>
        /// Колонки для Экспорта данных
        /// </summary>
        public static string WinExport = "Name:Экспорт данных\\AutomationId:lblColumns\\LocalizedControlType:кнопка";
        /// <summary>
        /// Экспортировать в Excel Меню
        /// </summary>
        public static string ExportMenuXlsx = "Name:Экспорт данных\\Name:DropDown\\Name:Выбрать все";
        /// <summary>
        /// Проставить наименование листа
        /// </summary>
        public static string ExportNameList = "Name:Экспорт данных\\AutomationId:txtWorksheetName";
        /// <summary>
        /// Экспорт
        /// </summary>
        public static string Export = "Name:Экспорт данных\\Name:Экспорт";
        /// <summary>
        /// Собственность
        /// </summary>
        public static string RiboonZmIm = "Name:DockTop\\Name:Ribbon\\Name:Ribbon Tabs\\Name:Собственность";
        /// <summary>
        /// Диалоговое окно ошибка
        /// </summary>
        public static string WinErrorFull = "LocalizedControlType:диалоговое окно\\Name:ОК";
    }
}
