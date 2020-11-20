namespace LibraryAIS3Windows.AutomationsUI.Otdels.PreCheck
{
    public class PreCheckElementName
    {
        /// <summary>
        /// Значение
        /// </summary>
        public static string Memo = "Name:Значение";
        /// <summary>
        /// фильтр Grid Имущество
        /// </summary>
        public static string FiltersIm = $"AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:NavigatorMdiView\\AutomationId:splitContainer\\AutomationId:navigatorMDI\\AutomationId:splitContainer\\AutomationId:masterNavigator\\AutomationId:tsControlPanel\\Name:Фильтр";
        /// <summary>
        /// Экспорт Grid Имущество
        /// </summary>
        public static string ExportIm = $"AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:NavigatorMdiView\\AutomationId:splitContainer\\AutomationId:navigatorMDI\\AutomationId:splitContainer\\AutomationId:masterNavigator\\AutomationId:tsControlPanel\\LocalizedControlType:кнопка";
        /// <summary>
        /// Обновить
        /// </summary>
        public static string Update = "Name:DockTop\\Name:Ribbon\\Name:Сведения об учете организации в НО\\Name:Навигатор\\Name:Обновить";
        /// <summary>
        /// Колонки для Экспорта данных
        /// </summary>
        public static string WinExport = "Name:Экспорт данных\\AutomationId:lblColumns\\LocalizedControlType:кнопка";
        /// <summary>
        /// Экспортировать в Excel Меню
        /// </summary>
        public static string ExportMenuXlsx = "Name:Экспорт данных\\Name:DropDown\\Name:Выбрать все";
        /// <summary>
        /// Экспорт
        /// </summary>
        public static string Export = "Name:Экспорт данных\\Name:Экспорт";
        /// <summary>
        /// Excel
        /// </summary>
        public static string Xlsx = "ClassName:XLMAIN";
        /// <summary>
        /// Проставить наименование листа
        /// </summary>
        public static string ExportNameList = "Name:Экспорт данных\\AutomationId:txtWorksheetName";
    }
    /// <summary>
    /// Данные ППА
    /// </summary>
    public class PreCheckElementNameIndividualCards
    {
        /// <summary>
        /// Панель ППА
        /// </summary>
        public static string PanelElement = $"AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:TaxpayerCardView\\";
        /// <summary>
        /// Старт период
        /// </summary>
        public static string PeriodEnd = $"{PanelElement}AutomationId:comboYearEnd";
        /// <summary>
        /// Период до какого
        /// </summary>
        public static string PeriodBegin = $"{PanelElement}AutomationId:comboYearBegin";
        /// <summary>
        /// Открыть ИКН
        /// </summary>
        public static string OpenFaceCard = "Name:DockTop\\Name:Ribbon\\Name:Данные\\Name:Управление\\Name:Открыть ИКН";
        /// <summary>
        /// Вывод индивидуальной карточки в xml
        /// </summary>
        public static string TotalCards = "Name:DockTop\\Name:Ribbon\\Name:Карточка налогоплательщика\\Name:Команды\\Name:Вывод в MS Excel";
        /// <summary>
        /// Ошибка нет более новых годов
        /// </summary>
        public static string ErrorYear = "Name:Ошибка при выполнении операции\\AutomationId:MessageBoxView\\AutomationId:grpBackground\\AutomationId:grpBottom\\AutomationId:btnOK";
        /// <summary>
        /// Ошибка в данных 
        /// </summary>
        public static string ErrorData = "Name:Ошибка в данных\\AutomationId:MessageBoxView\\AutomationId:grpBackground\\AutomationId:grpBottom\\AutomationId:btnOK";
    }
    /// <summary>
    /// Данные для банковских выписок из ветки
    /// Налоговое администрирование\Анализ Банковских Документов\Банковские выписки, справки
    /// </summary>
    public class PreCheckElementNameBank
    {
        /// <summary>
        /// Путь к TaxpayerListControl банковских справок и выписок
        /// </summary>
        public static string FullTaxpayerListControl = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:AbdListSmartPart\\ClassName:TaxpayerListControl\\";
        /// <summary>
        /// Вставка ИНН параметра
        /// </summary>
        public static string InputInn = $"{FullTaxpayerListControl}ClassName:RadExpander\\AutomationId:HeaderButton\\AutomationId:SearchTextBox";
        /// <summary>
        /// Выбор периода данных 3 года + текущий 
        /// </summary>
        public static string PeriodSelect = $"{FullTaxpayerListControl}ClassName:RadExpander\\AutomationId:HeaderButton\\AutomationId:PeriodPicker\\ClassName:RadToggleButton\\ClassName:TextBlock";
        /// <summary>
        /// Поиск данных выписки и справки банков по организации
        /// </summary>
        public static string FindButton = $"{FullTaxpayerListControl}ClassName:RadExpander\\AutomationId:HeaderButton\\ClassName:RadButton\\ClassName:TextBlock";
        /// <summary>
        /// Флажок выбора НП
        /// </summary>
        public static string SelectItem = $"AutomationId:PART_GridViewVirtualizingPanel\\AutomationId:Row_0\\AutomationId:Cell_0_0\\AutomationId:CellElement_0_0";
        /// <summary>
        /// Показать банковские документы выбранного НП
        /// </summary>
        public static string ViewSpravki = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:AbdListSmartPart\\ClassName:TaxpayerListControl\\AutomationId:ShowStatements\\ClassName:TextBlock";
        /// <summary>
        /// Первый элемент в Grid панеле выписок
        /// </summary>
        public static string ElementSpr = $"ClassName:RadTabControl\\ClassName:RadTabItem\\AutomationId:RadDocking\\ClassName:RadSplitContainer\\AutomationId:RadPaneGroup\\AutomationId:RadPane\\AutomationId:StatementsGrid\\{SelectItem}";
        /// <summary>
        /// Выгрузить все в xlsx
        /// </summary>
        public static string DonloadFileXlxsSave = "ClassName:RadTabControl\\ClassName:RadTabItem\\AutomationId:RadDocking\\ClassName:RadSplitContainer\\AutomationId:RadPaneGroup\\AutomationId:RadPane\\AutomationId:StatementsGrid";
        /// <summary>
        /// Ввод имени файла
        /// </summary>
        public static string SaveDialogNameFileWin10 = "Name:Сохранение\\ClassName:DUIViewWndClassName\\AutomationId:FileNameControlHost\\ClassName:Edit"; //\\AutomationId:FolderLayoutContainer\\AutomationId:BackgroundClear\\AutomationId:FileNameControlHost";
        /// <summary>
        /// Путь сохранения файла  Win 7 Сохранить как Win10 Сохранение
        /// </summary>
        public static string PathSaveWin10 = "Name:Сохранение\\Name:Сохранить"; //ClassName:WorkerW\\AutomationId:FolderLayoutContainer\\AutomationId:BackgroundClear\\AutomationId:FileNameControlHost";
        /// <summary>
        /// Ввод имени файла
        /// </summary>
        public static string SaveDialogNameFileWin7 = "Name:Сохранить как\\ClassName:DUIViewWndClassName\\AutomationId:FileNameControlHost\\ClassName:Edit"; //\\AutomationId:FolderLayoutContainer\\AutomationId:BackgroundClear\\AutomationId:FileNameControlHost";
        /// <summary>
        /// Путь сохранения файла  Win 7 Сохранить как Win10 Сохранение
        /// </summary>
        public static string PathSaveWin7 = "Name:Сохранить как\\Name:Сохранить"; //ClassName:WorkerW\\AutomationId:FolderLayoutContainer\\AutomationId:BackgroundClear\\AutomationId:FileNameControlHost";
    }
    /// <summary>
    /// Декларации реестр НБО
    /// </summary>
    public class PreCheckElementNameDeclaration
    {
        /// <summary>
        /// Вкладка НБО
        /// </summary>
        public static string ReestrNbo = "Name:DockTop\\Name:Ribbon\\Name:Ribbon Tabs\\Name:Реестр документов НБО";
        /// <summary>
        /// Просмотр декларации
        /// </summary>
        public static string ViewDeclaretion =  "Name:DockTop\\Name:Ribbon\\Name:Реестр документов НБО\\Name:Просмотр документа";
        /// <summary>
        /// Экспорт документа в xlsx
        /// </summary>
        public static string ExportFile = "Name:DockTop\\Name:Ribbon\\Name:Камеральные налоговые проверки\\Name:Документ\\Name:Экспорт в Excel";
        /// <summary>
        /// Ок экспорт
        /// </summary>
        public static string ExportFileOk = "Name:Экспорт документа\\Name:ОК";
    }

    public class PreCheckFindUl
    {
        /// <summary>
        /// Применить фильтр
        /// </summary>
        public static string UseFilter = "Name:DockTop\\Name:Ribbon\\Name:Навигатор\\Name:Основные действия\\Name:Применить фильтр";
        /// <summary>
        /// Изменить фильтр
        /// </summary>
        public static string ChangeFilter = "Name:DockTop\\Name:Ribbon\\Name:Навигатор\\Name:Основные действия\\Name:Изменить фильтр";
        /// <summary>
        /// Печать выписки (Новый формат)
        /// </summary>
        public static string PrintStatement = "Name:DockTop\\Name:Ribbon\\Name:Навигатор\\Name:Дополнительно\\Name:Печать выписки (Новый формат)";

    }
    /// <summary>
    /// АСК НДС выгрузка гниг учета
    /// </summary>
    public class ModelBookShopping
    {
        /// <summary>
        /// Все книги учета
        /// </summary>
        public static string AllBook = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:InspectorDeclarationsView\\AutomationId:preFilterControl\\AutomationId:mainPanel\\AutomationId:rbAll";
        /// <summary>
        /// Сбросить фильтр обязательно
        /// </summary>
        public static string ResetFilter = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:InspectorDeclarationsView\\AutomationId:grid\\AutomationId:pnlMain\\AutomationId:gridLayoutPanel\\AutomationId:topPanel\\AutomationId:aggregatePanel\\AutomationId:_resetSettingButton";

        /// <summary>
        /// Журнал Декларация Жупрнал
        /// </summary>
        public static string StartJournal = "Name:DockTop\\Name:Ribbon\\Name:Окно оперативной работы\\Name:Функции\\Name:Декларация/Журнал";
        /// <summary>
        /// Раздел 8
        /// </summary>
        public static string Section8 = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:View\\AutomationId:DeclarationParts\\Name:Раздел 8";
        /// <summary>
        /// Раздел 9
        /// </summary>
        public static string Section9 = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:View\\AutomationId:DeclarationParts\\Name:Раздел 9";
        /// <summary>
        /// Сохранить файл
        /// </summary>
        public static string Save = "Name:Сохранение\\Name:Сохранить";
        /// <summary>
        /// Экспорт в Xlsx
        /// </summary>
        public static string ExportXlsx = "Name:Экспорт в эксель\\AutomationId:MessageBoxView\\AutomationId:grpBackground\\AutomationId:grpBottom\\AutomationId:btnYes";
        /// <summary>
        /// IP Адресс отправителя
        /// </summary>
        public static string IpAdress = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:View\\AutomationId:grpHeader\\AutomationId:ultraExpandableGroupBoxPanel1\\AutomationId:commonInfoPanel\\AutomationId:tableLayoutPanel1\\AutomationId:flowLayoutPanel3";
        /// <summary>
        /// Код абонента
        /// </summary>
        public static string Code = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:View\\AutomationId:grpHeader\\AutomationId:ultraExpandableGroupBoxPanel1\\AutomationId:commonInfoPanel\\AutomationId:tableLayoutPanel1\\AutomationId:flowLayoutPanel4";
        /// <summary>
        /// Наименование оператора
        /// </summary>
        public static string NameOperator = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:View\\AutomationId:grpHeader\\AutomationId:ultraExpandableGroupBoxPanel1\\AutomationId:commonInfoPanel\\AutomationId:tableLayoutPanel1\\AutomationId:flowLayoutPanel12";
        /// <summary>
        /// Контейнер документов проверим
        /// </summary>
        public static string DocumentContainer = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:View\\AutomationId:DeclarationParts\\AutomationId:tabMain\\AutomationId:rnivcWrapperPanel\\AutomationId:declarationRnivcData\\AutomationId:globalContainer\\AutomationId:mainContainer\\AutomationId:tabsContainer\\AutomationId:documentContainer";
        /// <summary>
        /// Ок
        /// </summary>
        public static string WinOk = "AutomationId:CustomRowFiltersDialog\\Name:&OK";
    }

}
