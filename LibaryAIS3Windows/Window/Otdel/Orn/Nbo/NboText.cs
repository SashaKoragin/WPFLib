namespace LibraryAIS3Windows.Window.Otdel.Orn.Nbo
{
    public class NboText
    {
        /// <summary>
        /// Титульный лист
        /// </summary>
        public static string TitelList = "Титульный лист";

        /// <summary>
        /// Подстрока для поиска
        /// </summary>
        public static string Strfind = "Сведения о";

        /// <summary>
        /// Подстрока для поиска 2
        /// </summary>
        public static string Strfind2 = "Подписант";

        /// <summary>
        /// Окно если все хорошо
        /// </summary>
        public static string[] TitleOk =
        {
            "Готов к переносу в КРСБ",
            "Документ переведен в состояние"
        };

        /// <summary>
        /// Окно если все плохо
        /// </summary>
        public static string[] TitleError =
        {
            "Сохранение документа",
            "При сохранении документа были обнаружены ошибки."
        };

        /// <summary>
        /// Окно если все плохо
        /// </summary>
        public static string[] TitleError2 =
        {
            "Расчет документа",
            "При расчете документа были обнаружены ошибки."
        };


        /// <summary>
        /// Протакол разногласий
        /// </summary>
        public static string[] Protokol =
        {
            "Протокол разногласий",
            "Данные не найдены"
        };

    }

    public class FaceRegistryReferenceTextClass
    {
        /// <summary>
        /// Логика вкладки ФЛ или ЮЛ
        /// </summary>
        public static string PanelFace = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:InitiativeTaxOrganBelongingNavView\\AutomationId:InitiativeTaxOrganBelongingNavView_Fill_Panel\\AutomationId:taxpayerSearchingControl1\\AutomationId:grpSearchTaxpayer\\AutomationId:pnlSearchNtaxpayer\\AutomationId:tabTaxpayer\\Name:{0}";
        /// <summary>
        /// Ввести заявление
        /// </summary>
        public static string SendWay = "Name:DockTop\\Name:Ribbon\\Name:Выбор налогоплательщика \\Name:Налогоплательщик\\Name:Ввести заявление";
        /// <summary>
        /// Галочка
        /// </summary>
        public static string Check = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:InitiativeTaxOrganBelongingQueryView\\AutomationId:InitiativeTaxOrganBelongingQueryView_Fill_Panel\\AutomationId:ultraGroupBox1\\AutomationId:gbRecord\\AutomationId:chkInfoMess\\Name:Признак информационного сообщения";
        /// <summary>
        /// Вставка текста причины
        /// </summary>
        public static string SendText = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:InitiativeTaxOrganBelongingQueryView\\AutomationId:InitiativeTaxOrganBelongingQueryView_Fill_Panel\\AutomationId:ultraGroupBox1\\AutomationId:gbRecord\\AutomationId:txtReason";
        /// <summary>
        /// Регистрация
        /// </summary>
        public static string Registration = "Name:DockTop\\Name:Ribbon\\Name:Документы\\Name:Действия\\Name:Регистрация";
        /// <summary>
        /// Окно Ок
        /// </summary>
        public static string Ok = "Name:Информация\\AutomationId:MessageBoxView\\AutomationId:grpBackground\\AutomationId:grpBottom\\AutomationId:btnOK";
        /// <summary>
        /// Сформировать общее сальдо 
        /// </summary>
        public static string ReportForm = "Name:DockTop\\Name:Ribbon\\Name:Журнал\\Name:Общие\\Name:Сформировать сообщение о сальдо";
        /// <summary>
        /// Error
        /// </summary>
        public static string Error = "Name:Ошибка на сервере\\AutomationId:MessageBoxView\\AutomationId:grpBackground\\AutomationId:grpBottom\\Name:ОК";
        /// <summary>
        /// Error
        /// </summary>
        public static string ErrorMessage = "Name:Ошибка на сервере\\AutomationId:MessageBoxView\\AutomationId:grpBackground\\AutomationId:grpTop\\AutomationId:lblMessage";
        /// <summary>
        /// Вверх
        /// </summary>
        public static string Up = "Name:DockTop\\Name:Ribbon\\Name:Сервис\\Name:Навигация по окнам\\Name:Вверх";
        /// <summary>
        /// Направить сообщение НП
        /// </summary>
        public static string SendNp = "Name:DockTop\\Name:Ribbon\\Name:Журнал\\Name:Общие\\Name:Направить сообщение НП";
        /// <summary>
        /// Журнал
        /// </summary>
        public static string Journal = "Name:DockTop\\Name:Ribbon\\Name:Ribbon Tabs\\Name:Журнал";
        /// <summary>
        /// Сервис
        /// </summary>
        public static string Service = "Name:DockTop\\Name:Ribbon\\Name:Ribbon Tabs\\Name:Сервис";
        /// <summary>
        /// Вперед
        /// </summary>
        public static string Right = "Name:DockTop\\Name:Ribbon\\Name:Сервис\\Name:Навигация по окнам\\Name:Вперед";
    }
}
