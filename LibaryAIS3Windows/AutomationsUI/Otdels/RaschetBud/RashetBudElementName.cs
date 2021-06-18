namespace LibraryAIS3Windows.AutomationsUI.Otdels.RaschetBud
{
   public class RashetBudElementName
   {

       public static string MainView = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\";

    
        /// <summary>
        /// Кнопка начать выяснения
        /// </summary>
        public static string StartUtoch = "Name:DockTop\\Name:Ribbon\\Name:Уточнение невыясненных поступлений\\Name:Выяснение\\Name:Начать выяснение";
        /// <summary>
        /// Навигация по окнам назад
        /// </summary>
        public static string Back = "Name:DockTop\\Name:Ribbon\\Name:Сервис\\Name:Навигация по окнам\\Name:Назад";
        /// <summary>
        /// Передать на утверждение
        /// </summary>
        public static string Utverjdenie = "Name:DockTop\\Name:Ribbon\\Name:Формирование решения\\Name:Задание\\Name:Передать на утверждение";
        /// <summary>
        /// Все данные Grid Платежи
        /// </summary>
        public static string DateGridAllListExit = $"{MainView}AutomationId:UncertainJournalNavView\\AutomationId:ctlUncertainJournal_R1\\AutomationId:grdUncertainJournal";
        /// <summary>
        /// Все данные Grid Платежи
        /// </summary>
        public static string DateGrid = $"{MainView}AutomationId:UncertainJournalNavView\\AutomationId:ctlUncertainJournal_R1\\AutomationId:grdUncertainJournal\\Name:List`1 row ";
        /// <summary>
        /// Загрузка
        /// </summary>
       public static string Load = "AutomationId:ultraStatusBar";
       /// <summary>
       /// Начинаем выяснение платежа
       /// </summary>
       public static string WindowsStartYes = "Name:Выяснение платежа\\AutomationId:MessageBoxView\\AutomationId:grpBackground\\AutomationId:grpBottom\\AutomationId:btnYes";
       /// <summary>
       /// Подстановка нового КБК
       /// </summary>
        public static string SendKbk = $"{MainView}AutomationId:UncertainDecisionNewView\\AutomationId:grpMain\\AutomationId:ctlDecision\\AutomationId:grpMain\\AutomationId:grpPayment\\AutomationId:ltbKBK\\AutomationId:utbLike\\AutomationId:umeUniversal";
       /// <summary>
       /// Подстановка статуса КБК
       /// </summary>
       public static string SendStatus = $"{MainView}AutomationId:UncertainDecisionNewView\\AutomationId:grpMain\\AutomationId:ctlDecision\\AutomationId:grpMain\\AutomationId:grpPayment\\AutomationId:grpPayer\\AutomationId:taddDecisionFormerPersonStatus\\LocalizedControlType:поле";
       /// <summary>
       /// Подстановка статуса ТП
       /// </summary>
       public static string SendTp = $"{MainView}AutomationId:UncertainDecisionNewView\\AutomationId:grpMain\\AutomationId:ctlDecision\\AutomationId:grpMain\\AutomationId:grpPayment\\AutomationId:taddDecisionTaxPaymentReason\\LocalizedControlType:поле";
        /// <summary>
        /// Создание решения об уточнении
        /// </summary>
       public static string WinUtoch = "Name:Создание решения об уточнении\\AutomationId:MessageBoxView\\AutomationId:grpBackground\\AutomationId:grpBottom\\AutomationId:btnYes";
        /// <summary>
        /// Отмена решения об уточнении
        /// </summary>
       public static string ButtonNotUtoch = "Name:DockTop\\Name:Ribbon\\Name:Формирование решения\\Name:Задание\\Name:Отмена Решения об уточнении";
        /// <summary>
        /// Окно отмена решения об уточнении
        /// </summary>
       public static string WinNotUtoch = "Name:Ввод уточненных реквизитов платежа\\AutomationId:MessageBoxView\\AutomationId:grpBackground\\AutomationId:btnYes";
        /// <summary>
        /// Сформировать уведомление НП
        /// </summary>
        public static string ButtonUvedNp = "Name:DockTop\\Name:Ribbon\\Name:Уточнение невыясненных поступлений\\Name:Выяснение\\Name:Сформировать уведомление НП";
        /// <summary>
        /// Окно выбор налогоплательщика
        /// </summary>
        public static string WinSelect = "Name:Выбор налогоплательщика";
        /// <summary>
        /// Найти налогоплательщика ЮЛ
        /// </summary>
        public static string WinFind = "Name:Выбор налогоплательщика\\AutomationId:SearchTaxpayerView\\AutomationId:grbSearchTaxpayer\\AutomationId:tbcSearchTaxpayer\\Name:Найти";

        /// <summary>
        /// Grid Выбора плательщика
        /// </summary>
        public static string SelectGrid = "Name:Выбор налогоплательщика\\AutomationId:SearchTaxpayerView\\AutomationId:grbSearchTaxpayer\\AutomationId:grdTaxpayers";
        /// <summary>
        /// Поле КПП
        /// </summary>
        public static string KppMemo = "Name:Выбор налогоплательщика\\AutomationId:SearchTaxpayerView\\AutomationId:grbSearchTaxpayer\\AutomationId:tbcSearchTaxpayer\\AutomationId:ultraTabPageControl2\\AutomationId:txtKPP";
        /// <summary>
        /// Ошибка поиска
        /// </summary>
        public static string ErrorWin = "Name:Выбор налогоплательщика\\Name:Ошибка при отборе налогоплательщиков.\\AutomationId:MessageBoxView\\AutomationId:grpBackground\\AutomationId:grpBottom\\AutomationId:btnOK";
        /// <summary>
        /// Закрыть окно выбора
        /// </summary>
        public static string CloseButton = "Name:Выбор налогоплательщика\\AutomationId:SearchTaxpayerView\\AutomationId:grbSearchTaxpayer\\AutomationId:btnCancel";
        /// <summary>
        /// Выбрать налогоплательщика
        /// </summary>
        public static string SelectButton = "Name:Выбор налогоплательщика\\AutomationId:SearchTaxpayerView\\AutomationId:grbSearchTaxpayer\\AutomationId:btnOk";
        /// <summary>
        /// Отправить уведомление
        /// </summary>
        public static string FormWin = "Name:Формирование уведомления налогоплательщику\\AutomationId:NotificationTpView\\AutomationId:grpMain\\AutomationId:btnSave";
        /// <summary>
        /// Сохранить результат
        /// </summary>
        public static string SaveWin = "Name:Формирование уведомления налогоплательщику\\Name:Сохранение уведомления НП\\AutomationId:MessageBoxView\\AutomationId:grpBackground\\AutomationId:grpBottom\\AutomationId:btnYes";
        /// <summary>
        /// Ок
        /// </summary>
        public static string Ok = "Name:Формирование уведомления налогоплательщику\\Name:Уведомление НП\\AutomationId:MessageBoxView\\AutomationId:grpBackground\\AutomationId:grpBottom\\AutomationId:btnOK";
    }
}
