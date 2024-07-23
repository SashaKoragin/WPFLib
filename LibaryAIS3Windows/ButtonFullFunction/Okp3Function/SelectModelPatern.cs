
namespace LibraryAIS3Windows.ButtonFullFunction.Okp3Function
{
    public class ModelDataArea
    {
        /// <summary>
        /// Модель печати документов
        /// Налоговое администрирование\Направление документов налогоплательщику\2. Единичная печать и отправка в ОПС\Печать и отправка\2 - Документы к отправке
        /// </summary>
        public DataArea PrintDocumentSend = new DataArea()
        {
            FullPathDataArea = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:CDocToSendNavigatorStepView\\AutomationId:ncMain\\AutomationId:splitContainer\\AutomationId:conditionsPanel\\AutomationId:gridConditions\\",
            FullPathGrid = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:CDocToSendNavigatorStepView\\AutomationId:ncMain\\AutomationId:splitContainer\\AutomationId:gridData",
            ListRowDataArea = "Name:List`1 row ",
            ListRowDataGrid = "\\Name:select0 row ",
            Update = "Name:DockTop\\Name:Ribbon\\Name:Просмотр\\Name:Общие\\Name:Обновить",
            Riborn = "Name:DockTop\\Name:Ribbon\\Name:Просмотр\\Name:Документ\\Name:Просмотр",
            Parameters = new Parameters[]
            {
                new Parameters() { NameParameters = "КНД", FindNameMemo = "Name:Значение", FindSelectParameter = "Равно",IndexParameters = "1" },
                new Parameters() { NameParameters = "Дата документа", FindNameMemo = "Name:Значение", FindSelectParameter = "Равно", IndexParameters = "7" }
            }
        };


        /// <summary>
        /// Модель Grid Налоговое администрирование\Контрольная работа\Допрос свидетелей\1. Инициализация процедуры допроса свидетеля
        /// </summary>
        public DataArea[] DataAreaInterrogationOfWitnesses = new DataArea[]
        {

            new DataArea()
            {
                FullPathDataArea = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:navigatorMDIControl\\AutomationId:splitContainer\\AutomationId:MasterNavigator\\AutomationId:splitContainer\\AutomationId:conditionsPanel\\AutomationId:gridConditions\\",
                FullPathGrid = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:navigatorMDIControl\\AutomationId:splitContainer\\AutomationId:MasterNavigator\\AutomationId:splitContainer\\AutomationId:gridData",
                ListRowDataGrid = "\\Name:select0 row ",
                ListRowDataArea = "Name:List`1 row ",
                Riborn = "Name:DockTop\\Name:Ribbon\\Name:Навигатор\\Name:Процедура допроса свидетеля\\Name:Открыть процедуру",
                Update = "Name:DockTop\\Name:Ribbon\\Name:Навигатор\\Name:Основное\\Name:Обновить",
                Parameters = new Parameters[]
                {
                    new Parameters() { NameParameters = "УН процедуры", FindNameMemo = "Name:Значение", FindSelectParameter = "Равно", IndexParameters = "4" },
                    new Parameters() { NameParameters = "ИНН", FindNameMemo = "Name:Значение", FindSelectParameter = "Равно", IndexParameters = "12" },

                }
            },
            new DataArea()
            {
                FullPathDataArea = "AutomationId:FindFaceAll\\AutomationId:ultraPanelFormFill\\AutomationId:ultraPanelForNavigator\\AutomationId:ultraTabFace\\AutomationId:ultraTabPageControl1\\AutomationId:navigatorControlYL\\AutomationId:splitContainer\\AutomationId:conditionsPanel\\AutomationId:gridConditions\\",
                FullPathGrid = "AutomationId:FindFaceAll\\AutomationId:ultraPanelFormFill\\AutomationId:ultraPanelForNavigator\\AutomationId:ultraTabFace\\AutomationId:ultraTabPageControl1\\AutomationId:navigatorControlYL\\AutomationId:splitContainer\\AutomationId:gridData",
                ListRowDataGrid = "\\Name:select0 row ",
                ListRowDataArea = "Name:List`1 row ",
                Riborn = "Name:Выбор Налогоплательщика\\Name:DockTop\\Name:Ribbon\\Name:Налогоплательщик\\Name:Действия с навигатором\\Name:Выбрать",
                Update = "Name:Выбор Налогоплательщика\\Name:DockTop\\Name:Ribbon\\Name:Налогоплательщик\\Name:Действия с навигатором\\Name:Обновить",
                Parameters = new Parameters[]
                {
                    new Parameters() { NameParameters = "ИНН", FindNameMemo = "Name:Значение", FindSelectParameter = "Равно", IndexParameters = "3" }
                }
            },
            new DataArea()
            {
                FullPathDataArea = "Name:_layoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:NavigatorControlView\\AutomationId:navigatorMDI\\AutomationId:splitContainer\\AutomationId:conditionsPanel\\AutomationId:gridConditions\\",
                FullPathGrid = "Name:_layoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:NavigatorControlView\\AutomationId:navigatorMDI\\AutomationId:splitContainer\\AutomationId:gridData",
                ListRowDataGrid = "\\Name:select0 row ",
                ListRowDataArea = "Name:List`1 row ",
                Riborn = "Name:DockTop\\Name:Ribbon\\Name:Выбрать лицо\\LocalizedControlType:панель инструментов\\Name:Выбрать лицо",
                Update = "Name:DockTop\\Name:Ribbon\\Name:Выбрать лицо\\Name:Обновить",
                Parameters = new Parameters[]
                {
                    new Parameters() { NameParameters = "ИНН", FindNameMemo = "Name:Значение", FindSelectParameter = "Равно", IndexParameters = "3" },

                }
            },
            new DataArea()
            {
                FullPathDataArea = "AutomationId:FindFaceNew\\AutomationId:ultraPanelFormFill\\AutomationId:ultraPanelForNavigator\\AutomationId:ultraTabFace\\AutomationId:ultraTabPageControl1\\AutomationId:navigatorControlYL\\AutomationId:splitContainer\\AutomationId:conditionsPanel\\AutomationId:gridConditions\\",
                FullPathGrid = "AutomationId:FindFaceNew\\AutomationId:ultraPanelFormFill\\AutomationId:ultraPanelForNavigator\\AutomationId:ultraTabFace\\AutomationId:ultraTabPageControl1\\AutomationId:navigatorControlYL\\AutomationId:splitContainer\\AutomationId:gridData",
                ListRowDataGrid = "\\Name:select0 row ",
                ListRowDataArea = "Name:List`1 row ",
                Riborn = "Name:Выбор Налогоплательщика\\Name:DockTop\\Name:Ribbon\\Name:Налогоплательщик\\Name:Действия с навигатором\\Name:Выбрать",
                Update = "Name:Выбор Налогоплательщика\\Name:DockTop\\Name:Ribbon\\Name:Налогоплательщик\\Name:Действия с навигатором\\Name:Обновить",
                Parameters = new Parameters[]
                {
                    new Parameters() { NameParameters = "ИНН", FindNameMemo = "Name:Значение", FindSelectParameter = "Равно", IndexParameters = "3" }
                }
            },
            new DataArea()
            {
                FullPathDataArea = "AutomationId:FindFaceNew\\AutomationId:ultraPanelFormFill\\AutomationId:ultraPanelForNavigator\\AutomationId:ultraTabFace\\AutomationId:ultraTabPageControl2\\AutomationId:navigatorControlFL\\AutomationId:splitContainer\\AutomationId:conditionsPanel\\AutomationId:gridConditions\\",
                FullPathGrid = "AutomationId:FindFaceNew\\AutomationId:ultraPanelFormFill\\AutomationId:ultraPanelForNavigator\\AutomationId:ultraTabFace\\AutomationId:ultraTabPageControl2\\AutomationId:navigatorControlFL\\AutomationId:splitContainer\\AutomationId:gridData",
                ListRowDataGrid = "\\Name:select0 row ",
                ListRowDataArea = "Name:List`1 row ",
                Riborn = "Name:Выбор Налогоплательщика\\Name:DockTop\\Name:Ribbon\\Name:Налогоплательщик\\Name:Действия с навигатором\\Name:Выбрать",
                Update = "Name:Выбор Налогоплательщика\\Name:DockTop\\Name:Ribbon\\Name:Налогоплательщик\\Name:Действия с навигатором\\Name:Обновить",
                Parameters = new Parameters[]
                {
                    new Parameters() { NameParameters = "ИНН", FindNameMemo = "Name:Значение", FindSelectParameter = "Равно", IndexParameters = "3" }
                }
            },
            new DataArea()
            {
                FullPathDataArea = "AutomationId:FindInspector\\AutomationId:ultraPanelFormFill\\AutomationId:ultraPanelForNavigator\\AutomationId:navigatorControl1\\AutomationId:splitContainer\\AutomationId:conditionsPanel\\AutomationId:gridConditions\\",
                FullPathGrid = "AutomationId:FindInspector\\AutomationId:ultraPanelFormFill\\AutomationId:ultraPanelForNavigator\\AutomationId:navigatorControl1\\AutomationId:splitContainer\\AutomationId:gridData",
                ListRowDataGrid = "\\Name:select0 row ",
                ListRowDataArea = "Name:List`1 row ",
                Riborn = "Name:Выбор Должностного лица\\Name:DockTop\\Name:Ribbon\\Name:Должностное лицо\\Name:Действия с навигатором\\Name:Выбрать",
                Update = "Name:Выбор Должностного лица\\Name:DockTop\\Name:Ribbon\\Name:Должностное лицо\\Name:Действия с навигатором\\Name:Обновить",
                Parameters = new Parameters[]
                {
                    new Parameters() { NameParameters = "УН инспектора", FindNameMemo = "Name:Значение", FindSelectParameter = "Равно", IndexParameters = "1" } //Подписант 02.11.2023 17019218-Юрковский!  17019220-Чукалкин!
                }
            },
            new DataArea()
            {
                FullPathDataArea = "AutomationId:FindFaceAll\\AutomationId:ultraPanelFormFill\\AutomationId:ultraPanelForNavigator\\AutomationId:ultraTabFace\\AutomationId:ultraTabPageControl2\\AutomationId:navigatorControlFL\\AutomationId:splitContainer\\AutomationId:conditionsPanel\\AutomationId:gridConditions\\",
                FullPathGrid = "AutomationId:FindFaceAll\\AutomationId:ultraPanelFormFill\\AutomationId:ultraPanelForNavigator\\AutomationId:ultraTabFace\\AutomationId:ultraTabPageControl2\\AutomationId:navigatorControlFL\\AutomationId:splitContainer\\AutomationId:gridData",
                ListRowDataGrid = "\\Name:select0 row ",
                ListRowDataArea = "Name:List`1 row ",
                Riborn = "Name:Выбор Налогоплательщика\\Name:DockTop\\Name:Ribbon\\Name:Налогоплательщик\\Name:Действия с навигатором\\Name:Выбрать",
                Update = "Name:Выбор Налогоплательщика\\Name:DockTop\\Name:Ribbon\\Name:Налогоплательщик\\Name:Действия с навигатором\\Name:Обновить",
                Parameters = new Parameters[]
                {
                    new Parameters() { NameParameters = "ИНН", FindNameMemo = "Name:Значение", FindSelectParameter = "Равно", IndexParameters = "3" }
                }
            },

        };

        public DataArea DataAreaFaceRegistryReferenceSend = new DataArea()
        {
            FullPathDataArea = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:RegistrationJournalView\\AutomationId:navigatorControl1\\AutomationId:splitContainer\\AutomationId:conditionsPanel\\AutomationId:gridConditions\\",
            FullPathGrid = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:RegistrationJournalView\\AutomationId:navigatorControl1\\AutomationId:splitContainer\\AutomationId:gridData",
            ListRowDataGrid = "\\Name:select0 row ",
            ListRowDataArea = "Name:List`1 row ",
            Headers = "Name:Column Headers",
            Filters = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:RegistrationJournalView\\AutomationId:navigatorControl1\\AutomationId:tsControlPanel\\Name:Фильтр",
            Update = "Name:DockTop\\Name:Ribbon\\Name:Журнал\\Name:Общие\\Name:Обновить",
            Parameters = new Parameters[]
            {
                new Parameters() { NameParameters = "ИНН", FindNameMemo = "Name:Значение", FindSelectParameter = "Равно", IndexParameters = "12" }
            }
        };

        public DataArea DataAreaFaceRegistryReference = new DataArea()
        {
            FullPathDataArea = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:InitiativeTaxOrganBelongingNavView\\AutomationId:InitiativeTaxOrganBelongingNavView_Fill_Panel\\AutomationId:taxpayerSearchingControl1\\AutomationId:grpSearchTaxpayer\\AutomationId:pnlSearchNtaxpayer\\AutomationId:tabTaxpayer\\AutomationId:splitContainer\\AutomationId:conditionsPanel\\AutomationId:gridConditions\\",
            FullPathGrid = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:InitiativeTaxOrganBelongingNavView\\AutomationId:InitiativeTaxOrganBelongingNavView_Fill_Panel\\AutomationId:taxpayerSearchingControl1\\AutomationId:grpSearchTaxpayer\\AutomationId:pnlSearchNtaxpayer\\AutomationId:tabTaxpayer\\AutomationId:splitContainer\\AutomationId:gridData",
            ListRowDataGrid = "\\Name:select0 row ",
            ListRowDataArea = "Name:List`1 row ",
            Headers = "Name:Column Headers",
            Filters = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:InitiativeTaxOrganBelongingNavView\\AutomationId:InitiativeTaxOrganBelongingNavView_Fill_Panel\\AutomationId:taxpayerSearchingControl1\\AutomationId:grpSearchTaxpayer\\AutomationId:pnlSearchNtaxpayer\\AutomationId:tabTaxpayer\\AutomationId:splitContainer\\AutomationId:tsControlPanel\\Name:Фильтр",
            Update = "Name:DockTop\\Name:Ribbon\\Name:Выбор налогоплательщика \\Name:Налогоплательщик\\Name:Поиск",
            Parameters = new Parameters[]
            {
                new Parameters() { NameParameters = "ИНН", FindNameMemo = "Name:Значение", FindSelectParameter = "Равно", IndexParameters = "1" }
            }
        };
        public DataArea DataAreaIdentificationFl = new DataArea()
        {
            FullPathDataArea = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:NavigatorView\\AutomationId:splitContainer\\AutomationId:navigatorControl\\AutomationId:splitContainer\\AutomationId:conditionsPanel\\AutomationId:gridConditions\\",
            FullPathGrid = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:NavigatorView\\AutomationId:splitContainer\\AutomationId:navigatorControl\\AutomationId:splitContainer\\AutomationId:gridData",
            ListRowDataGrid = "select0 row 1",
            ListRowDataArea = "Name:List`1 row ",
            Headers = "Name:Column Headers",
            Filters = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:NavigatorView\\AutomationId:splitContainer\\AutomationId:navigatorControl\\AutomationId:tsControlPanel\\Name:Фильтр",
            Update = "Name:DockTop\\Name:Ribbon\\Name:Ручная идентификация физического лица\\Name:Навигатор\\Name:Обновить",
            Parameters = new Parameters[]
            {
                new Parameters() { NameParameters = "УН входящего документа", FindNameMemo = "Name:Значение", FindSelectParameter = "Равно", IndexParameters = "3" }
            }
        };


        public DataArea DataAreaRegFl = new DataArea()
        {
            FullPathDataArea = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:NavigatorMdiView\\AutomationId:splitContainer\\AutomationId:navigatorMDI\\AutomationId:splitContainer\\AutomationId:MasterNavigator\\AutomationId:splitContainer\\AutomationId:conditionsPanel\\AutomationId:gridConditions\\",
            FullPathGrid = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:NavigatorMdiView\\AutomationId:splitContainer\\AutomationId:navigatorMDI\\AutomationId:splitContainer\\AutomationId:MasterNavigator\\AutomationId:splitContainer\\AutomationId:gridData",
            ListRowDataArea = "Name:List`1 row ",
            ListRowDataGrid = "\\Name:select0 row ",
            Headers = "Name:Column Headers",
            Update = "Name:DockTop\\Name:Ribbon\\Name:Идентификационные характеристики физического лица\\Name:Навигатор\\Name:Обновить",
            Parameters = new Parameters[]
            {
                new Parameters() { NameParameters = "ИНН", FindNameMemo = "Name:Значение", FindSelectParameter = "Равно", IndexParameters = "14" }
            }
        };
        /// <summary>
        /// Регистрация ФЛ
        /// </summary>
        public DataArea DataAreaRegistrationFl = new DataArea()
        {
            FullPathDataArea = "Name:Данные из справочника ЕГРН\\AutomationId:navigatorControl\\AutomationId:splitContainer\\AutomationId:conditionsPanel\\AutomationId:gridConditions\\",
            FullPathGrid = "Name:Данные из справочника ЕГРН\\AutomationId:navigatorControl\\AutomationId:splitContainer\\AutomationId:gridData",
            ListRowDataArea = "Name:List`1 row ",
            ListRowDataGrid = "\\Name:select0 row ",
            Headers = "Name:Column Headers",
            Update = "Name:Данные из справочника ЕГРН\\AutomationId:toolStrip\\Name:Обновить",
            Riborn = "Name:Данные из справочника ЕГРН\\AutomationId:toolStrip\\Name:Выбрать",
            Parameters = new Parameters[]
            {
                new Parameters() { NameParameters = "ИНН",FindNameMemo = "Name:Значение",FindSelectParameter = "Равно",IndexParameters = "3" }
            }
        };
        /// <summary>
        /// Ввод данных ФЛ
        /// </summary>
        public DataArea DataAreaSendFl = new DataArea()
        {
            FullPathDataArea = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:NavigatorView\\AutomationId:splitContainer\\AutomationId:navigatorControl\\AutomationId:splitContainer\\AutomationId:conditionsPanel\\AutomationId:gridConditions\\",
            FullPathGrid = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:NavigatorView\\AutomationId:splitContainer\\AutomationId:navigatorControl\\AutomationId:splitContainer\\AutomationId:gridData",
            ListRowDataArea = "Name:List`1 row ",
            ListRowDataGrid = "\\Name:select0 row ",
            Update = "Name:DockTop\\Name:Ribbon\\Name:Ввод поступивших документов ФЛ\\Name:Навигатор\\Name:Обновить",
            Riborn = "Name:Данные из справочника ЕГРН\\AutomationId:toolStrip\\Name:Выбрать",
            Parameters = new Parameters[]
            {
                new Parameters() { NameParameters = "ИНН",FindNameMemo = "Name:Значение",FindSelectParameter = "Равно",IndexParameters = "19" }
            }
        };


        public DataArea DataArea = new DataArea()
        {
            FullPathDataArea = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:MasterNavigator\\AutomationId:splitContainer\\AutomationId:conditionsPanel\\AutomationId:gridConditions\\",
            FullPathGrid = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:MasterNavigator\\AutomationId:splitContainer\\AutomationId:gridData",
            ListRowDataArea = "Name:List`1 row ",
            Headers = "Name:Column Headers",
            Update = "Name:DockTop\\Name:Ribbon\\Name:Журнал учета и формирования документов, связанных с применением ПСН\\Name:Документ\\Name:Обновить данные",
            Riborn = "Name:DockTop\\Name:Ribbon\\Name:Документы объекта ПСН\\Name:Документ\\Name:Обновить данные",
            Parameters = new Parameters[]
            {
                new Parameters() {NameParameters = "РегНомер патента",FindNameMemo = "Name:Значение",FindSelectParameter = "Из перечня",IndexParameters = "24"}
            }
        };

        /// <summary>
        /// Заявления анулированние
        /// </summary>
        public DataArea DataAreaStatement = new DataArea()
        {
            FullPathDataArea = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:TransferClaimDocNavListView\\AutomationId:grpBig\\AutomationId:navControl\\AutomationId:ctlNavigator\\AutomationId:splitContainer\\AutomationId:conditionsPanel\\AutomationId:gridConditions\\",
            FullPathGrid = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:TransferClaimDocNavListView\\AutomationId:grpBig\\AutomationId:navControl\\AutomationId:ctlNavigator\\AutomationId:splitContainer\\AutomationId:gridData",
            ListRowDataArea = "Name:List`1 row ",
            Headers = "Name:Column Headers",
            Update = "Name:DockTop\\Name:Ribbon\\Name:Список заявлений\\Name:Действия\\Name:Обновить",
            Filters = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:TransferClaimDocNavListView\\AutomationId:grpBig\\AutomationId:navControl\\AutomationId:ctlNavigator\\AutomationId:tsControlPanel\\Name:Фильтр",
            Parameters = new Parameters[]
            {
                new Parameters() {NameParameters = "ИНН",FindNameMemo = "Name:Значение",FindSelectParameter = "Равно",IndexParameters = "4"},
                new Parameters() {NameParameters = "Номер заявления",FindNameMemo = "Name:Значение",FindSelectParameter = "Из перечня (без учета регистра)",IndexParameters = "7"},
            }
        };

        /// <summary>
        /// Акты для отработки данных Налоговое администрирование\Контрольная работа(налоговые проверки)\101. Мониторинг и обработка документов\Реестр документов НБО
        /// </summary>
        public DataArea DataAreaStatementAct = new DataArea()
        {
            FullPathDataArea = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:GenericNavigatorViewBase\\AutomationId:NavigatorViewBase_Fill_Panel\\AutomationId:grpBig\\AutomationId:ctlNavigator\\AutomationId:splitContainer\\AutomationId:conditionsPanel\\AutomationId:gridConditions\\",
            FullPathGrid = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:GenericNavigatorViewBase\\AutomationId:NavigatorViewBase_Fill_Panel\\AutomationId:grpBig\\AutomationId:ctlNavigator\\AutomationId:splitContainer\\AutomationId:gridData",
            ListRowDataArea = "Name:List`1 row ",
            Headers = "Name:Column Headers",
            Update = "Name:DockTop\\Name:Ribbon\\Name:Журнал документов взыскания\\Name:Навигатор\\Name:Обновить",
            Filters = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:GenericNavigatorViewBase\\AutomationId:NavigatorViewBase_Fill_Panel\\AutomationId:grpBig\\AutomationId:ctlNavigator\\AutomationId:tsControlPanel\\Name:Фильтр",
            Parameters = new Parameters[]
            {
                new Parameters() {NameParameters = "ИНН",FindNameMemo = "Name:Значение",FindSelectParameter = "Равно",IndexParameters = "2"},
                new Parameters() {NameParameters = "Номер заявления",FindNameMemo = "Name:Значение",FindSelectParameter = "Равно (без учета регистра)",IndexParameters = "18"},
            }
        };

        ///// <summary>
        /////  Налоговое администрирование\Контрольная работа(налоговые проверки)\101. Мониторинг и обработка документов\Реестр документов НБО
        ///// </summary>
        //public DataArea DataAreaDeclaration = new DataArea()
        //{
        //    FullPathDataArea = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:MasterNavigator\\AutomationId:splitContainer\\AutomationId:conditionsPanel\\AutomationId:gridConditions\\",
        //    FullPathGrid = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:MasterNavigator\\AutomationId:splitContainer\\AutomationId:gridData",
        //    ListRowDataArea = "Name:List`1 row ",
        //    Headers = "Name:Column Headers",
        //    Update = "Name:DockTop\\Name:Ribbon\\Name:Реестр документов НБО\\Name:Документ\\Name:Обновить данные",
        //    Filters = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:MasterNavigator\\AutomationId:tsControlPanel\\Name:Фильтр",
        //    Parameters = new Parameters[]
        //    {
        //        new Parameters() {NameParameters = "РегНомер",FindNameMemo = "Name:Значение",FindSelectParameter = "Равно",IndexParameters = "9"}
        //    }
        //};
        /// <summary>
        ///  Налоговое администрирование\Контрольная работа(налоговые проверки)\101. Мониторинг и обработка документов\Реестр документов НБО
        /// </summary>
        public DataArea DataAreaDeclarationFace = new DataArea()
        {
            FullPathDataArea = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:MasterNavigator\\AutomationId:splitContainer\\AutomationId:conditionsPanel\\AutomationId:gridConditions\\",
            FullPathGrid = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:MasterNavigator\\AutomationId:splitContainer\\AutomationId:gridData",
            ListRowDataArea = "Name:List`1 row ",
            Headers = "Name:Column Headers",
            Update = "Name:DockTop\\Name:Ribbon\\Name:Реестр документов НБО\\Name:Документ\\Name:Обновить данные",
            Filters = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:MasterNavigator\\AutomationId:tsControlPanel\\Name:Фильтр",
            Parameters = new Parameters[]
            {
                new Parameters() {NameParameters = "Отчетный год",FindNameMemo = "Name:Значение",FindSelectParameter = "Равно",IndexParameters = "14"},
                new Parameters() {NameParameters = "ИНН",FindNameMemo = "Name:Значение",FindSelectParameter = "Равно",IndexParameters = "18"}
            }
        };
        /// <summary>
        /// Налоговое администрирование\Контрольная работа (налоговые проверки)\121. Камеральная налоговая проверка\04. Журнал документов, выписанных в ходе налоговой проверки
        /// </summary>
        public DataArea DataAreaAllDeclarationDocument = new DataArea()
        {
            FullPathDataArea = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:MasterNavigator\\AutomationId:splitContainer\\AutomationId:conditionsPanel\\AutomationId:gridConditions\\",
            FullPathGrid = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:MasterNavigator\\AutomationId:splitContainer\\AutomationId:gridData",
            ListRowDataArea = "Name:List`1 row ",
            Headers = "Name:Column Headers",
            Update = "Name:DockTop\\Name:Ribbon\\Name:Журнал документов, выписанных в ходе налоговой проверки\\Name:Документ\\Name:Обновить данные",
            Filters = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:MasterNavigator\\AutomationId:tsControlPanel\\Name:Фильтр",
            Parameters = new Parameters[]
            {
                new Parameters() {NameParameters = "ИНН",FindNameMemo = "Name:Значение",FindSelectParameter = "Равно",IndexParameters = "11"},
                new Parameters() {NameParameters = "КНД декларации",FindNameMemo = "Name:Значение",FindSelectParameter = "Равно",IndexParameters = "27"}
            }
        };


        public DataArea[] DataAreaModel = new DataArea[] {

            new DataArea()
            {
                FullPathGrid = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:MasterNavigator\\AutomationId:splitContainer\\AutomationId:gridData",
                Export =  "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:MasterNavigator\\AutomationId:tsControlPanel\\LocalizedControlType:кнопка",
                Riborn = "Name:DockTop\\Name:Ribbon\\Name:Журнал учета и формирования документов, связанных с применением ПСН\\Name:Действия\\Name:Документы объекта ПСН",
                Update = "Name:DockTop\\Name:Ribbon\\Name:Документы объекта ПСН\\Name:Документ\\Name:Обновить данные",
                Headers = "Документы объекта ПСН"
            },
            new DataArea()
            {
                FullPathGrid = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:MasterNavigator\\AutomationId:splitContainer\\AutomationId:gridData",
                Export =  "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:MasterNavigator\\AutomationId:tsControlPanel\\LocalizedControlType:кнопка",
                Riborn = "Name:DockTop\\Name:Ribbon\\Name:Журнал учета и формирования документов, связанных с применением ПСН\\Name:Действия\\Name:Сведения об обособленных объектах",
                Update = "Name:DockTop\\Name:Ribbon\\Name:Сведения об обособленных объектах\\Name:Документ\\Name:Обновить данные",
                Headers = "Сведения об обособленных объектах"
            },
            new DataArea()
            {
                FullPathGrid = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:MasterNavigator\\AutomationId:splitContainer\\AutomationId:gridData",
                Export =  "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:MasterNavigator\\AutomationId:tsControlPanel\\LocalizedControlType:кнопка",
                Riborn = "Name:DockTop\\Name:Ribbon\\Name:Журнал учета и формирования документов, связанных с применением ПСН\\Name:Действия\\Name:Сведения о месте осуществления деятельности",
                Update = "Name:DockTop\\Name:Ribbon\\Name:Сведения о месте осуществления деятельности\\Name:Документ\\Name:Обновить данные",
                Headers = "Сведения о месте осуществления деятельности"
            },
            new DataArea()
            {
                FullPathGrid = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:MasterNavigator\\AutomationId:splitContainer\\AutomationId:gridData",
                Export =  "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:MasterNavigator\\AutomationId:tsControlPanel\\LocalizedControlType:кнопка",
                Riborn = "Name:DockTop\\Name:Ribbon\\Name:Журнал учета и формирования документов, связанных с применением ПСН\\Name:Действия\\Name:Параметры расчета налога",
                Update = "Name:DockTop\\Name:Ribbon\\Name:Параметры расчета налога\\Name:Документ\\Name:Обновить данные",
                Headers = "Параметры расчета налога"
            },
            new DataArea()
            {
                FullPathGrid = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:MasterNavigator\\AutomationId:splitContainer\\AutomationId:gridData",
                Export =  "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:MasterNavigator\\AutomationId:tsControlPanel\\LocalizedControlType:кнопка",
                Riborn = "Name:DockTop\\Name:Ribbon\\Name:Журнал учета и формирования документов, связанных с применением ПСН\\Name:Действия\\Name:Сведения о транспортных средствах",
                Update = "Name:DockTop\\Name:Ribbon\\Name:Сведения о транспортных средствах\\Name:Документ\\Name:Обновить данные",
                Headers = "Сведения о транспортных средствах"
            },
            new DataArea()
            {
                FullPathGrid = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:MasterNavigator\\AutomationId:splitContainer\\AutomationId:gridData",
                Export =  "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:MasterNavigator\\AutomationId:tsControlPanel\\LocalizedControlType:кнопка",
                Riborn = "Name:DockTop\\Name:Ribbon\\Name:Журнал учета и формирования документов, связанных с применением ПСН\\Name:Действия\\Name:Сведения по фактическому действию патента",
                Update = "Name:DockTop\\Name:Ribbon\\Name:Сведения по фактическому действию патента\\Name:Документ\\Name:Обновить данные",
                Headers = "Сведения по фактическому действию патента"
            }
        };

        public DataArea DataAreaTechAdjustmentStatement = new DataArea()
        {
            FullPathDataArea = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:TechCorrClaimNavView\\AutomationId:_ControlAndStatisticsView_Fill_Panel\\AutomationId:grpBig\\Name:Редактирование даты заявления по зачетам (возвратам)\\AutomationId:ctlNavigator\\AutomationId:splitContainer\\AutomationId:conditionsPanel\\AutomationId:gridConditions\\",
            FullPathGrid = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:TechCorrClaimNavView\\AutomationId:_ControlAndStatisticsView_Fill_Panel\\AutomationId:grpBig\\Name:Редактирование даты заявления по зачетам (возвратам)\\AutomationId:ctlNavigator\\AutomationId:splitContainer\\AutomationId:gridData",
            ListRowDataArea = "Name:List`1 row ",
            Headers = "Name:Column Headers",
            Update = "Name:DockTop\\Name:Ribbon\\Name:Создание заявки на техническую корректировку\\Name:Навигатор\\Name:Обновить",
            Filters = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:TechCorrClaimNavView\\AutomationId:_ControlAndStatisticsView_Fill_Panel\\AutomationId:grpBig\\Name:Редактирование даты заявления по зачетам (возвратам)\\AutomationId:ctlNavigator\\AutomationId:tsControlPanel\\Name:Фильтр",
            Parameters = new Parameters[]
            {
                new Parameters() {NameParameters = "Номер заявления", FindNameMemo = "Name:Значение", FindSelectParameter = "Равно", IndexParameters = "2"},
                new Parameters() {NameParameters = "ИНН", FindNameMemo = "Name:Значение", FindSelectParameter = "Равно", IndexParameters = "7"},
            }
        };

        public DataArea DataAreaIncomeJournal = new DataArea()
        {
            FullPathDataArea = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:NTR_JournalSection2View\\AutomationId:windowDockingArea2\\AutomationId:dockableWindow1\\AutomationId:ctlNavCondition\\AutomationId:grpMain\\AutomationId:Conditions\\",
            ListRowDataArea = "Name:List`1 row ",
            FullPathGrid = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:NTR_JournalSection2View\\AutomationId:NTR_JournalSection2View_Fill_Panel\\AutomationId:ultraGroupBox1\\AutomationId:grdNTR_JournalSection2View",
            Update = "Name:DockTop\\Name:Ribbon\\Name:Журнал\\Name:Обновить",
            Filters = null,
            Parameters = new Parameters[]
            {
                new Parameters() {NameParameters = "КБК УФК", FindNameMemo = "Name:Значение", FindSelectParameter = "Равно", IndexParameters = "1"},
                new Parameters() {NameParameters = "ИНН", FindNameMemo = "Name:Значение", FindSelectParameter = "Равно", IndexParameters = "9"},
            }
        };
        /// <summary>
        /// Ветка выборка Налоговое администрирование\Собственность\01. Картотека собственности ФБД\07. КС – ЗУ – Факты владения на земельные участки – ФЛ
        /// </summary>
        public DataArea DataAreaFactOwnerZm = new DataArea()
        {
            FullPathDataArea = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:OperationWithNavigatorSimpleView\\AutomationId:navigatorControl\\AutomationId:splitContainer\\AutomationId:conditionsPanel\\AutomationId:gridConditions\\",
            FullPathGrid = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:OperationWithNavigatorSimpleView\\AutomationId:navigatorControl\\AutomationId:splitContainer\\AutomationId:gridData",
            ListRowDataArea = "Name:List`1 row ",
            Headers = "Name:Column Headers",
            ListRowDataGrid = "\\Name:DynamicSelect row ",
            Update = "Name:DockTop\\Name:Ribbon\\Name:Собственность\\Name:Основное\\Name:Обновить",
            Filters = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:OperationWithNavigatorSimpleView\\AutomationId:navigatorControl\\AutomationId:tsControlPanel\\Name:Фильтр",
            Export = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:LandView_2\\AutomationId:splitContainer1\\AutomationId:ultraTabControl1\\AutomationId:ultraTabPageControl5\\Name:Сведения о зарегистрированных правах от органов Росреестра\\Name:Сведения о правоустанавливающих документах \\AutomationId:navigatorControl4\\AutomationId:tsControlPanel\\LocalizedControlType:кнопка",
            Parameters = new Parameters[]
            {
                new Parameters() {NameParameters = "ИНН", FindNameMemo = "Name:Значение", FindSelectParameter = "Равно", IndexParameters = "16"},
            }
        };
        /// <summary>
        /// Ветка выборка Налоговое администрирование\Собственность\01. Картотека собственности ФБД\23. КС – ОН – Факты владения на объекты недвижимости – ФЛ
        /// </summary>
        public DataArea DataAreaFactOwnerIm = new DataArea()
        {
            FullPathDataArea = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:OperationWithNavigatorSimpleView\\AutomationId:navigatorControl\\AutomationId:splitContainer\\AutomationId:conditionsPanel\\AutomationId:gridConditions\\",
            FullPathGrid = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:OperationWithNavigatorSimpleView\\AutomationId:navigatorControl\\AutomationId:splitContainer\\AutomationId:gridData",
            ListRowDataArea = "Name:List`1 row ",
            Headers = "Name:Column Headers",
            ListRowDataGrid = "\\Name:DynamicSelect row ",
            Update = "Name:DockTop\\Name:Ribbon\\Name:Собственность\\Name:Основное\\Name:Обновить",
            Filters = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:OperationWithNavigatorSimpleView\\AutomationId:navigatorControl\\AutomationId:tsControlPanel\\Name:Фильтр",
            Export = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:BuildingView_2\\AutomationId:splitContainer1\\AutomationId:ultraTabControl1\\AutomationId:ultraTabPageControl5\\Name:Сведения о зарегистрированных правах от органов Росреестра\\Name:Сведения о правоустанавливающих документах \\AutomationId:navigatorControl4\\AutomationId:tsControlPanel\\LocalizedControlType:кнопка",
            Parameters = new Parameters[]
            {
                new Parameters() {NameParameters = "ИНН", FindNameMemo = "Name:Значение", FindSelectParameter = "Равно", IndexParameters = "17"},
            }
        };
    }

    public class DataArea
    {
        /// <summary>
        /// Полный путь до параметров
        /// </summary>
        public string FullPathDataArea { get; set; }
        /// <summary>
        /// Grid
        /// </summary>
        public string FullPathGrid { get; set; }
        /// <summary>
        /// Строки условия
        /// </summary>
        public string ListRowDataArea { get; set; }
        /// <summary>
        /// Строки данных
        /// </summary>
        public string ListRowDataGrid { get; set; }

        /// <summary>
        /// Колонки
        /// </summary>
        public string Headers { get; set; }
        /// <summary>
        /// Кнопка обновить
        /// </summary>
        public string Update { get; set; }
        /// <summary>
        /// Riborn
        /// </summary>
        public string Riborn { get; set; }
        /// <summary>
        /// Экспорт
        /// </summary>
        public string Export { get; set; }
        /// <summary>
        /// Фильтр
        /// </summary>
        public string Filters { get; set; }

        public bool IsParseModel { get; set; }
        /// <summary>
        /// Параметры
        /// </summary>
        public Parameters[] Parameters { get; set; }

    }
    public class Parameters
    {
        /// <summary>
        /// Наименование параметра
        /// </summary>
        public string NameParameters { get; set; }
        /// <summary>
        /// Поиск поля
        /// </summary>
        public string FindNameMemo { get; set; }
        /// <summary>
        /// Условие которое подставляем
        /// </summary>
        public string FindSelectParameter { get; set; }
        /// <summary>
        /// Индекс поля
        /// </summary>
        public string IndexParameters { get; set; }
        /// <summary>
        /// Подстановка параметра
        /// </summary>
        public string ParametersGrid { get; set; }
    }

}
