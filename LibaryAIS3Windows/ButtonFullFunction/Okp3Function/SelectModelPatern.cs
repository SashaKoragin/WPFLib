using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAIS3Windows.ButtonFullFunction.Okp3Function
{
    public class ModelDataArea
    {

        public DataArea DataAreaRegFl = new DataArea()
        {
            FullPathDataArea = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:NavigatorMdiView\\AutomationId:splitContainer\\AutomationId:navigatorMDI\\AutomationId:splitContainer\\AutomationId:masterNavigator\\AutomationId:splitContainer\\AutomationId:conditionsPanel\\AutomationId:gridConditions\\",
            FullPathGrid = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:NavigatorMdiView\\AutomationId:splitContainer\\AutomationId:navigatorMDI\\AutomationId:splitContainer\\AutomationId:masterNavigator\\AutomationId:splitContainer\\AutomationId:gridData",
            ListRowDataArea = "Name:List`1 row ",
            ListRowDataGrid = "\\Name:select0 row ",
            Headers = "Name:Column Headers",
            Update = "Name:DockTop\\Name:Ribbon\\Name:Идентификационные характеристики физического лица\\Name:Навигатор\\Name:Обновить",
            Parameters = new Parameters[]
            {
                new Parameters() { NameParameters = "ИНН", FindNameMemo = "Name:Значение", FindSelectParameter = "Равно", IndexParameters = "8" }
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
                new Parameters() { NameParameters = "ИНН",FindNameMemo = "Name:Значение",FindSelectParameter = "Равно",IndexParameters = "16" }
            }
        };


        public DataArea DataArea = new DataArea()
        {
            FullPathDataArea = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:masterNavigator\\AutomationId:splitContainer\\AutomationId:conditionsPanel\\AutomationId:gridConditions\\",
            FullPathGrid = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:masterNavigator\\AutomationId:splitContainer\\AutomationId:gridData",
            ListRowDataArea = "Name:List`1 row ",
            Headers = "Name:Column Headers",
            Update = "Name:DockTop\\Name:Ribbon\\Name:Журнал учета и формирования документов, связанных с применением ПСН\\Name:Документ\\Name:Обновить данные",
            Riborn = "Name:DockTop\\Name:Ribbon\\Name:Документы объекта ПСН\\Name:Документ\\Name:Обновить данные",
            Parameters = new Parameters[]
            {
                new Parameters() {NameParameters = "РегНомер патента",FindNameMemo = "Name:Значение",FindSelectParameter = "Из перечня",IndexParameters = "25"}
            }
        };

        /// <summary>
        /// Заявления онулирование
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
        ///  Налоговое администрирование\Контрольная работа(налоговые проверки)\101. Мониторинг и обработка документов\Реестр документов НБО
        /// </summary>
        public DataArea DataAreaDeclaration = new DataArea()
        {
            FullPathDataArea = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:masterNavigator\\AutomationId:splitContainer\\AutomationId:conditionsPanel\\AutomationId:gridConditions\\",
            FullPathGrid = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:masterNavigator\\AutomationId:splitContainer\\AutomationId:gridData",
            ListRowDataArea = "Name:List`1 row ",
            Headers = "Name:Column Headers",
            Update = "Name:DockTop\\Name:Ribbon\\Name:Реестр документов НБО\\Name:Документ\\Name:Обновить данные",
            Filters = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:masterNavigator\\AutomationId:tsControlPanel\\Name:Фильтр",
            Parameters = new Parameters[]
            {
                new Parameters() {NameParameters = "РегНомер",FindNameMemo = "Name:Значение",FindSelectParameter = "Равно",IndexParameters = "9"}
            }
        };
        /// <summary>
        /// Налоговое администрирование\Контрольная работа (налоговые проверки)\121. Камеральная налоговая проверка\04. Журнал документов, выписанных в ходе налоговой проверки
        /// </summary>
        public DataArea DataAreaAllDeclarationDocument = new DataArea()
        {
            FullPathDataArea = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:masterNavigator\\AutomationId:splitContainer\\AutomationId:conditionsPanel\\AutomationId:gridConditions\\",
            FullPathGrid = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:masterNavigator\\AutomationId:splitContainer\\AutomationId:gridData",
            ListRowDataArea = "Name:List`1 row ",
            Headers = "Name:Column Headers",
            Update = "Name:DockTop\\Name:Ribbon\\Name:Журнал документов, выписанных в ходе налоговой проверки\\Name:Документ\\Name:Обновить данные",
            Filters = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:masterNavigator\\AutomationId:tsControlPanel\\Name:Фильтр",
            Parameters = new Parameters[]
            {
                new Parameters() {NameParameters = "ИНН",FindNameMemo = "Name:Значение",FindSelectParameter = "Равно",IndexParameters = "11"},
                new Parameters() {NameParameters = "КНД декларации",FindNameMemo = "Name:Значение",FindSelectParameter = "Равно",IndexParameters = "27"}
            }
        };


        public DataArea[] DataAreaModel = new DataArea[] {

            new DataArea()
            {
                FullPathGrid = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:masterNavigator\\AutomationId:splitContainer\\AutomationId:gridData",
                Export =  "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:masterNavigator\\AutomationId:tsControlPanel\\LocalizedControlType:кнопка",
                Riborn = "Name:DockTop\\Name:Ribbon\\Name:Журнал учета и формирования документов, связанных с применением ПСН\\Name:Действия\\Name:Документы объекта ПСН",
                Update = "Name:DockTop\\Name:Ribbon\\Name:Документы объекта ПСН\\Name:Документ\\Name:Обновить данные",
                Headers = "Документы объекта ПСН"
            },
            new DataArea()
            {
                FullPathGrid = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:masterNavigator\\AutomationId:splitContainer\\AutomationId:gridData",
                Export =  "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:masterNavigator\\AutomationId:tsControlPanel\\LocalizedControlType:кнопка",
                Riborn = "Name:DockTop\\Name:Ribbon\\Name:Журнал учета и формирования документов, связанных с применением ПСН\\Name:Действия\\Name:Сведения об обособленных объектах",
                Update = "Name:DockTop\\Name:Ribbon\\Name:Сведения об обособленных объектах\\Name:Документ\\Name:Обновить данные",
                Headers = "Сведения об обособленных объектах"
            },
            new DataArea()
            {
                FullPathGrid = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:masterNavigator\\AutomationId:splitContainer\\AutomationId:gridData",
                Export =  "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:masterNavigator\\AutomationId:tsControlPanel\\LocalizedControlType:кнопка",
                Riborn = "Name:DockTop\\Name:Ribbon\\Name:Журнал учета и формирования документов, связанных с применением ПСН\\Name:Действия\\Name:Сведения о месте осуществления деятельности",
                Update = "Name:DockTop\\Name:Ribbon\\Name:Сведения о месте осуществления деятельности\\Name:Документ\\Name:Обновить данные",
                Headers = "Сведения о месте осуществления деятельности"
            },
            new DataArea()
            {
                FullPathGrid = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:masterNavigator\\AutomationId:splitContainer\\AutomationId:gridData",
                Export =  "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:masterNavigator\\AutomationId:tsControlPanel\\LocalizedControlType:кнопка",
                Riborn = "Name:DockTop\\Name:Ribbon\\Name:Журнал учета и формирования документов, связанных с применением ПСН\\Name:Действия\\Name:Параметры расчета налога",
                Update = "Name:DockTop\\Name:Ribbon\\Name:Параметры расчета налога\\Name:Документ\\Name:Обновить данные",
                Headers = "Параметры расчета налога"
            },
            new DataArea()
            {
                FullPathGrid = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:masterNavigator\\AutomationId:splitContainer\\AutomationId:gridData",
                Export =  "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:masterNavigator\\AutomationId:tsControlPanel\\LocalizedControlType:кнопка",
                Riborn = "Name:DockTop\\Name:Ribbon\\Name:Журнал учета и формирования документов, связанных с применением ПСН\\Name:Действия\\Name:Сведения о транспортных средствах",
                Update = "Name:DockTop\\Name:Ribbon\\Name:Сведения о транспортных средствах\\Name:Документ\\Name:Обновить данные",
                Headers = "Сведения о транспортных средствах"
            },
            new DataArea()
            {
                FullPathGrid = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:masterNavigator\\AutomationId:splitContainer\\AutomationId:gridData",
                Export =  "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:masterNavigator\\AutomationId:tsControlPanel\\LocalizedControlType:кнопка",
                Riborn = "Name:DockTop\\Name:Ribbon\\Name:Журнал учета и формирования документов, связанных с применением ПСН\\Name:Действия\\Name:Сведения по фактическому действию патента",
                Update = "Name:DockTop\\Name:Ribbon\\Name:Сведения по фактическому действию патента\\Name:Документ\\Name:Обновить данные",
                Headers = "Сведения по фактическому действию патента"
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
