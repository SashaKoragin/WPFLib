namespace LibraryAIS3Windows.Mode.RaschetBudg.Migration
{
   public class Migration
   {
        /// <summary>
        /// Полный путь к панелям
        /// </summary>
        public static string PathFull = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:MigrationLogView\\AutomationId:navigatorControl1\\AutomationId:splitContainer\\";
        /// <summary>
        /// Журнал с ошибкой
        /// </summary>
        public static string PathFullError = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:MigrationLocks\\AutomationId:ultraTabControl1\\AutomationId:ultraTabPageControl1\\AutomationId:ultraGrid1\\Name:List`1 row 1";
        /// <summary>
        /// Панель с условиями
        /// </summary>
        public static string GridPanel = $"{PathFull}AutomationId:gridConditions\\Name:List`1 row ";
        /// <summary>
        /// панель данных
        /// </summary>
        public static string GridData = $"{PathFull}AutomationId:gridData";
        /// <summary>
        /// Данные после обновления
        /// </summary>
        public static string GridDataRow = $"{PathFull}AutomationId:gridData\\Name:select0 row ";
        /// <summary>
        /// Обновить данные
        /// </summary>
        public static string UpdateGrid = "Name:DockTop\\Name:Ribbon\\Name:Журнал миграции НП\\Name:Операции\\Name:Обновить";
        /// <summary>
        /// Кнопка просмотр прерываний процесса
        /// </summary>
        public static string ViewProcess = "Name:DockTop\\Name:Ribbon\\Name:Журнал миграции НП\\Name:Операции\\Name:Просмотр прерываний процесса и причин прерываний";


        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        internal static string[] Identity =
        {
            "АИС Налог-3 ПРОМ ",
            "[NAME:txtID]"
        };

        /// <summary>
        /// Команда ControlCommand Работает по Handle
        /// </summary>
        public static string[] Button =
       {
            "АИС Налог-3 ПРОМ ",
            "Разблокировать",
            "[NAME:unlockButton]"
       };
   }
}
