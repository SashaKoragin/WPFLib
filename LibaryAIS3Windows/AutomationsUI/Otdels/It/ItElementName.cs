namespace LibraryAIS3Windows.AutomationsUI.Otdels.It
{
   public class ItElementName
   {

       public static string FullPath = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1";
        /// <summary>
        /// Количество строк
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
        /// <summary>
        /// GRID
        /// </summary>
        public static string Grid = $"{FullPath}\\AutomationId:DemandJrnlView\\AutomationId:gbAll\\AutomationId:grdJournal";
        /// <summary>
        /// Журнал Дата
        /// </summary>
        public static string GridJournalRows = $"{FullPath}\\AutomationId:DemandJrnlView\\AutomationId:gbAll\\AutomationId:grdJournal\\Name:List`1 row ";
        /// <summary>
        /// История ролей
        /// </summary>
        public static string HistoryJournal = $"{FullPath}\\AutomationId:DemandHistoryView\\AutomationId:grdDemands";
        /// <summary>
        /// Имя
        /// </summary>
        public static string Name = $"{FullPath}\\AutomationId:DemandHistoryView\\AutomationId:gbUser\\AutomationId:ultraExpandableGroupBoxPanel1\\AutomationId:userInfoCtrl\\AutomationId:groupBox\\AutomationId:txtFIO";
        /// <summary>
        /// Должность
        /// </summary>
        public static string Doljnost = $"{FullPath}\\AutomationId:DemandHistoryView\\AutomationId:gbUser\\AutomationId:ultraExpandableGroupBoxPanel1\\AutomationId:userInfoCtrl\\AutomationId:groupBox\\AutomationId:txtTitle";
        /// <summary>
        /// Отдел
        /// </summary>
        public static string Department = $"{FullPath}\\AutomationId:DemandHistoryView\\AutomationId:gbUser\\AutomationId:ultraExpandableGroupBoxPanel1\\AutomationId:userInfoCtrl\\AutomationId:groupBox\\AutomationId:txtDepartment";
        /// <summary>
        /// Логин
        /// </summary>
        public static string Logon = $"{FullPath}\\AutomationId:DemandHistoryView\\AutomationId:gbUser\\AutomationId:ultraExpandableGroupBoxPanel1\\AutomationId:userInfoCtrl\\AutomationId:groupBox\\AutomationId:txtLogon";

        ///Сбор информации о ролях папках и т.п.
        /// <summary>
        /// Кнопка заявки
        /// </summary>
        public static string ApplicationTab = $"{FullPath}\\AutomationId:RoleListView\\AutomationId:gbAll\\AutomationId:userRolesCtrl\\AutomationId:tabCtrl\\Name:Заявки";

        /// <summary>
        /// Вкладка По ролям в ветке (Просмотр ролей)
        /// </summary>
        public static string ApplicationTabRules = $"{FullPath}\\AutomationId:RoleViewerView\\AutomationId:gbAll\\AutomationId:utcRoleViewer\\Name:По ролям";
        /// <summary>
        /// Вкладка По пользователям в ветке (Просмотр ролей)
        /// </summary>
        public static string ApplicationTabUsers = $"{FullPath}\\AutomationId:RoleViewerView\\AutomationId:gbAll\\AutomationId:utcRoleViewer\\Name:По пользователям";
        /// <summary>
        /// Контейнер для поиска вкладок
        /// </summary>
        public static string ApplicationContainerTab = $"{FullPath}\\AutomationId:RoleViewerView\\AutomationId:gbAll\\AutomationId:utcRoleViewer\\AutomationId:ultraTabPageControl2\\AutomationId:gbAll1\\AutomationId:listUserRolesCtrl\\AutomationId:splitContainer1";
        /// <summary>
        /// Шаблоны вкладка в ветке (Просмотр ролей)
        /// </summary>
        public static string ApplicationTabTemplate = "AutomationId:userRolesCtrl\\AutomationId:tabCtrl\\Name:Шаблоны";
        /// <summary>
        /// Роли вкладка в ветке (Просмотр ролей)
        /// </summary>
        public static string ApplicationTabRule = "AutomationId:userRolesCtrl\\AutomationId:tabCtrl\\Name:Роли";

        /// <summary>
        /// Кнопка Применить в Ролях
        /// </summary>
        public static string SendRulesTemplate = $"{FullPath}\\AutomationId:RoleViewerView\\AutomationId:gbAll\\AutomationId:utcRoleViewer\\AutomationId:ultraTabPageControl1\\AutomationId:gbTaxCode\\AutomationId:btnApply";
        /// <summary>
        /// Найти пользователя в ветке (Просмотр ролей)
        /// </summary>
        public static string FindUsers = $"{FullPath}\\AutomationId:RoleViewerView\\AutomationId:gbAll\\AutomationId:utcRoleViewer\\AutomationId:ultraTabPageControl2\\AutomationId:gbAll1\\AutomationId:listUserRolesCtrl\\AutomationId:splitContainer1\\AutomationId:userFindCtrl\\AutomationId:grbParams\\AutomationId:ultraExpandableGroupBoxPanel1\\AutomationId:paramCtrl\\AutomationId:ultraGroupBox1\\AutomationId:btnFind";

        /// <summary>
        /// Grid List Row Rules
        /// </summary>
        public static string ListRowRulesGrid = $"{FullPath}\\AutomationId:RoleViewerView\\AutomationId:gbAll\\AutomationId:utcRoleViewer\\AutomationId:ultraTabPageControl1\\AutomationId:roleUserListCtrl\\AutomationId:groupBox\\AutomationId:splitContainer1\\AutomationId:utcRoles\\AutomationId:upcSRoles\\AutomationId:grdTemplates";
        /// <summary>
        /// Grid List Row User
        /// </summary>
        public static string ListRowUsersGrid = $"{FullPath}\\AutomationId:RoleViewerView\\AutomationId:gbAll\\AutomationId:utcRoleViewer\\AutomationId:ultraTabPageControl2\\AutomationId:gbAll1\\AutomationId:listUserRolesCtrl\\AutomationId:splitContainer1\\AutomationId:userFindCtrl\\AutomationId:grdUsers";
        /// <summary>
        /// Строка Роли Шаблоны
        /// </summary>
        public static string ListRowRules = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:RoleViewerView\\AutomationId:gbAll\\AutomationId:utcRoleViewer\\AutomationId:ultraTabPageControl1\\AutomationId:roleUserListCtrl\\AutomationId:groupBox\\AutomationId:splitContainer1\\AutomationId:utcRoles\\AutomationId:upcSRoles\\AutomationId:grdTemplates\\Name:List`1 row {0}";
        /// <summary>
        /// Строка
        /// </summary>
        public static string ListRowUsers = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:RoleViewerView\\AutomationId:gbAll\\AutomationId:utcRoleViewer\\AutomationId:ultraTabPageControl2\\AutomationId:gbAll1\\AutomationId:listUserRolesCtrl\\AutomationId:splitContainer1\\AutomationId:userFindCtrl\\AutomationId:grdUsers\\Name:List`1 row {0}";
        /// <summary>
        /// Общее количество шаблонов
        /// </summary>
        public static string ListAllTemplatesUsers = "AutomationId:userRolesCtrl\\AutomationId:tabCtrl\\AutomationId:ultraTabPageControl2\\AutomationId:grdTemplates";
        /// <summary>
        /// Общее количество сигментов
        /// </summary>
        public static string ListAllRulesUsers = "AutomationId:userRolesCtrl\\AutomationId:tabCtrl\\AutomationId:ultraTabPageControl1\\AutomationId:grdRoles";
        /// <summary>
        /// Шаблоны пользователей
        /// </summary>
        public static string ListTemplatesUsers = "AutomationId:userRolesCtrl\\AutomationId:tabCtrl\\AutomationId:ultraTabPageControl2\\AutomationId:grdTemplates\\Name:List`1 row {0}";
        /// <summary>
        /// Шаблоны пользователей
        /// </summary>
        public static string ListRulesUsers = "AutomationId:userRolesCtrl\\AutomationId:tabCtrl\\AutomationId:ultraTabPageControl1\\AutomationId:grdRoles\\Name:List`1 row {0}";
        /// <summary>
        /// Приложение в сегменте
        /// </summary>
        public static string ListRulesAppUsers = "AutomationId:userRolesCtrl\\AutomationId:tabCtrl\\AutomationId:ultraTabPageControl1\\AutomationId:grdRoles\\Name:List`1 row {0}\\Name:Apps row {1}";
        /// <summary>
        /// Роль в приложении в сегменте
        /// </summary>
        public static string ListRulesAppRuleUsers = "AutomationId:userRolesCtrl\\AutomationId:tabCtrl\\AutomationId:ultraTabPageControl1\\AutomationId:grdRoles\\Name:List`1 row {0}\\Name:Apps row {1}\\Name:RoleList row {2}";

        /// <summary>
        /// Кнопка добавить
        /// </summary>
        public static string ButtonAdd = "Name:DockTop\\Name:Ribbon\\Name:Мои роли\\Name:Заявки\\Name:Добавить";
        /// <summary>
        /// Автоматическая информация
        /// </summary>
        public static string AutoInfo = "Name:DockTop\\Name:Ribbon\\Name:Ввод данных заявки\\Name:Общие действия\\Name:Авт. информация";

        /// <summary>
        /// Grid Ролей шаблонов
        /// </summary>
        public static string GridRule = $"{FullPath}\\AutomationId:AuthorizationPropsView\\AutomationId:AuthorizationPropsView_Fill_Panel\\AutomationId:grdProps";
        /// <summary>
        /// Строка
        /// </summary>
        public static string ListRow = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:AuthorizationPropsView\\AutomationId:AuthorizationPropsView_Fill_Panel\\AutomationId:grdProps\\Name:List`1 row {0}";
        /// <summary>
        /// Папка
        /// </summary>
        public static string ListFolders = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:AuthorizationPropsView\\AutomationId:AuthorizationPropsView_Fill_Panel\\AutomationId:grdProps\\Name:List`1 row {0}\\Name:Folders row {1}";

        /// <summary>
        /// Задача
        /// </summary>
        public static string ListTasks = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:AuthorizationPropsView\\AutomationId:AuthorizationPropsView_Fill_Panel\\AutomationId:grdProps\\Name:List`1 row {0}\\Name:Folders row {1}\\Name:Tasks row {2}";
        /// <summary>
        /// Роли
        /// </summary>
        public static string ListRoles = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:AuthorizationPropsView\\AutomationId:AuthorizationPropsView_Fill_Panel\\AutomationId:grdProps\\Name:List`1 row {0}\\Name:Folders row {1}\\Name:Tasks row {2}\\Name:Roles row {3}";
        /// <summary>
        /// Шаблон задачи
        /// </summary>
        public static string ListTaskTemplates = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:AuthorizationPropsView\\AutomationId:AuthorizationPropsView_Fill_Panel\\AutomationId:grdProps\\Name:List`1 row {0}\\Name:Folders row {1}\\Name:Tasks row {2}\\Name:Roles row {3}\\Name:TaskTemplates row {4}";
        /// <summary>
        /// Окно Шаблонов
        /// </summary>
        public static string WinAll = "LocalizedControlType:окно";
        /// <summary>
        /// Шаблон Сигмента
        /// </summary>
        public static string WinSigment = "LocalizedControlType:окно\\AutomationId:RolesView\\AutomationId:roleListCtrl\\AutomationId:gbAll\\AutomationId:pnList\\AutomationId:ugRoles";

    }
}
