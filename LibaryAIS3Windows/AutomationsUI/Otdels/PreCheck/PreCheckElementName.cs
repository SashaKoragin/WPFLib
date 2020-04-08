using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryAIS3Windows.AutomationsUI.Otdels.PreCheck
{
   public class PreCheckElementName
   {
        /// <summary>
        /// Дерево элементов
        /// </summary>
        public static string FullTree = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskpaneWorkspace\\AutomationId:ScenarioView\\AutomationId:scenarioTree\\";
        /// <summary>
        /// Подстановка условий
        /// </summary>
        public static string FullDataArea = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:NavigatorView\\AutomationId:splitContainer\\AutomationId:navigatorControl\\AutomationId:splitContainer\\";
        /// <summary>
        /// Подстановка условий Имущество
        /// </summary>
        public static string DataAreaIm = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:NavigatorMdiView\\AutomationId:splitContainer\\AutomationId:navigatorMDI\\AutomationId:splitContainer\\AutomationId:masterNavigator\\AutomationId:splitContainer\\";
        /// <summary>
        /// Подстановка условий 01. Картотека счетов РО, ИО, ИП
        /// </summary>
        public static string DataAreaCash = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:ViewIRView3\\AutomationId:navigatorSc\\AutomationId:splitContainer\\";
        /// <summary>
        /// Подстановка условий Сведения о среднесписочной численности работников
        /// </summary>
        public static string DataAreaSvedFace = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:masterNavigator\\AutomationId:splitContainer\\";
        /// <summary>
        /// Налоговое администрирование
        /// </summary>
        public static string TreeInnExpand1 = $"{FullTree}Name:Налоговое администрирование";
        /// <summary>
        /// Централизованный учет налогоплательщиков
        /// </summary>
        public static string TreeInnExpand2 = $"{FullTree}Name:Централизованный учет налогоплательщиков";
        /// <summary>
        /// 01. ЕГРН - российские организации
        /// </summary>
        public static string TreeInnExpand3 = $"{FullTree}Name:01. ЕГРН - российские организации";
        /// <summary>
        /// Контрольная работа (налоговые проверки)
        /// </summary>
        public static string TreeInnExpand4 = $"{FullTree}Name:Контрольная работа (налоговые проверки)";
        /// <summary>
        /// 109. Прочие документы
        /// </summary>
        public static string TreeInnExpand5 = $"{FullTree}Name:109. Прочие документы";
        /// <summary>
        /// Банковские и лицевые счета
        /// </summary>
        public static string TreeInnExpand6 = $"{FullTree}Name:Банковские и лицевые счета";
        /// <summary>
        /// 09. Картотека счетов
        /// </summary>
        public static string TreeInnExpand7 = $"{FullTree}Name:09. Картотека счетов";
        /// <summary>
        /// Анализ Банковских Документов
        /// </summary>
        public static string TreeInnExpand8 = $"{FullTree}Name:Анализ Банковских Документов";
        /// <summary>
        /// Предпроверочный анализ
        /// </summary>
        public static string TreeInnExpand9 = $"{FullTree}Name:Предпроверочный анализ";
        /// <summary>
        /// ППА-отбор
        /// </summary>
        public static string TreeInnExpand10 = $"{FullTree}Name:ППА-отбор";
        /// <summary>
        /// 1.01. Идентификационные характеристики организации
        /// </summary>
        public static string TreeNoUl = $"{FullTree}Name:1.01. Идентификационные характеристики организации";
        /// <summary>
        /// 1.03. Сведения об учете организации в НО
        /// </summary>
        public static string TreeInnKey = $"{FullTree}Name:1.03. Сведения об учете организации в НО";
        /// <summary>
        /// 2.02. История изменений сведений об учете организации в НО
        /// </summary>
        public static string History = $"{FullTree}Name:2.02. История изменений сведений об учете организации в НО";
        /// <summary>
        /// 01. Картотека счетов РО, ИО, ИП
        /// </summary>
        public static string CashUl = $"{FullTree}Name:01. Картотека счетов РО, ИО, ИП";
        /// <summary>
        /// Сведения о среднесписочной численности работников
        /// </summary>
        public static string UlYerFace = $"{FullTree}Name:Сведения о среднесписочной численности работников";
        /// <summary>
        /// 1.12. Сведения о филиалах, представительствах, иных обособленных подразделениях
        /// </summary>
        public static string DataFil = $"{FullTree}Name:1.12. Сведения о филиалах, представительствах, иных обособленных подразделениях";
        /// <summary>
        /// 1.18. Сведения об объектах собственности российской организации – имущество
        /// </summary>
        public static string UlIm = $"{FullTree}Name:1.18. Сведения об объектах собственности российской организации – имущество";
        /// <summary>
        /// 1.19. Сведения об объектах собственности российской организации – земля
        /// </summary>
        public static string UlZm = $"{FullTree}Name:1.19. Сведения об объектах собственности российской организации – земля";
        /// <summary>
        /// 1.20. Сведения об объектах собственности российской организации – транспорт
        /// </summary>
        public static string UlTr = $"{FullTree}Name:1.20. Сведения об объектах собственности российской организации – транспорт";
        /// <summary>
        /// 7. Индивидуальные карточки налогоплательщиков
        /// </summary>
        public static string CardPpa = $"{FullTree}Name:7. Индивидуальные карточки налогоплательщиков";
        /// <summary>
        /// Поиск условия куда подставлять ИНН
        /// </summary>
        public static string TreeInnDataArea = $"{FullDataArea}AutomationId:gridConditions\\Name:List`1 row ";
        /// <summary>
        /// Условие Имущество
        /// </summary>
        public static string DataAreaImFull = $"{DataAreaIm}AutomationId:gridConditions\\Name:List`1 row ";
        /// <summary>
        /// Поиск условия куда подставлять ИНН  01. Картотека счетов РО, ИО, ИП
        /// </summary>
        public static string DataAreaCashFull = $"{DataAreaCash}AutomationId:gridConditions\\Name:List`1 row ";
        /// <summary>
        /// Условие куда подставить Сведения о среднесписочной численности работников
        /// </summary>
        public static string DataAreaSvedFaceFull = $"{DataAreaSvedFace}AutomationId:gridConditions\\Name:List`1 row ";
        /// <summary>
        /// Общий журнал для данных
        /// </summary>
        public static string GridJournal = $"{FullDataArea}AutomationId:gridData\\Name:select0 row ";
        /// <summary>
        /// Журнал для Имущества
        /// </summary>
        public static string GridJournalIm = $"{DataAreaIm}AutomationId:gridData\\Name:select0 row ";
        /// <summary>
        /// Grid Картотеки счетов
        /// </summary>
        public static string GridJournalCash = $"{DataAreaCash}AutomationId:gridData\\Name:select0 row ";
        /// <summary>
        /// GRID Сведения о среднесписычной численности
        /// </summary>
        public static string GridJournalSvedFace = $"{DataAreaSvedFace}AutomationId:gridData\\Name:select0 row ";
        /// <summary>
        /// Значение
        /// </summary>
        public static string Memo = "Name:Значение";
        /// <summary>
        /// фильтр Grid
        /// </summary>
        public static string FiltersGrid = $"AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:NavigatorView\\AutomationId:splitContainer\\AutomationId:navigatorControl\\AutomationId:tsControlPanel\\Name:Фильтр";
        /// <summary>
        /// фильтр Grid Имущество
        /// </summary>
        public static string FiltersIm = $"AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:NavigatorMdiView\\AutomationId:splitContainer\\AutomationId:navigatorMDI\\AutomationId:splitContainer\\AutomationId:masterNavigator\\AutomationId:tsControlPanel\\Name:Фильтр";
        /// <summary>
        /// фильтр Grid Картотеки счетов
        /// </summary>
        public static string FiltersCash = $"AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:ViewIRView3\\AutomationId:navigatorSc\\AutomationId:tsControlPanel\\Name:Фильтр";
        /// <summary>
        /// фильтр Grid Сведения о среднесписычной численности
        /// </summary>
        public static string FiltersGridSvedFace = $"AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:masterNavigator\\AutomationId:tsControlPanel\\Name:Фильтр";
        /// <summary>
        /// Обновить Идентификационные характеристики организации
        /// </summary>
        public static string UpdateIdentUl = "Name:DockTop\\Name:Ribbon\\Name:Идентификационные характеристики организации\\Name:Навигатор\\Name:Обновить";
        /// <summary>
        /// Обновить
        /// </summary>
        public static string Update = "Name:DockTop\\Name:Ribbon\\Name:Сведения об учете организации в НО\\Name:Навигатор\\Name:Обновить";
        /// <summary>
        /// Обновить историю
        /// </summary>
        public static string UpdateHistory = "Name:DockTop\\Name:Ribbon\\Name:История изменений сведений об учете организации в НО\\Name:Навигатор\\Name:Обновить";
        /// <summary>
        /// Обновить сведения о филиалах
        /// </summary>
        public static string UpdateHistoryFil = "Name:DockTop\\Name:Ribbon\\Name:Сведения о филиалах, представительствах, иных обособленных подразделениях\\Name:Навигатор\\Name:Обновить";
        /// <summary>
        /// Обновить имущество
        /// </summary>
        public static string UpdateDataUlIm = "Name:DockTop\\Name:Ribbon\\Name:Сведения об объектах собственности российской организации – имущество\\Name:Навигатор\\Name:Обновить";
        /// <summary>
        /// Обновить земля
        /// </summary>
        public static string UpdateDataUlZm = "Name:DockTop\\Name:Ribbon\\Name:Сведения об объектах собственности российской организации – земля\\Name:Навигатор\\Name:Обновить";
        /// <summary>
        /// Обновить Транспорт
        /// </summary>
        public static string UpdateDataUlTr = "Name:DockTop\\Name:Ribbon\\Name:Сведения об объектах собственности российской организации – транспорт\\Name:Навигатор\\Name:Обновить";
        /// <summary>
        /// Обновить средне численную численность
        /// </summary>
        public static string UpdateYerFace = "Name:DockTop\\Name:Ribbon\\Name:Сведения о среднесписочной численности работников\\Name:Документ\\Name:Обновить данные";
        /// <summary>
        /// Обновить Картотека счетов РО ИО ИП
        /// </summary>
        public static string UpdateCashFace = "Name:DockTop\\Name:Ribbon\\Name:Документ\\Name:Документ\\Name:Обновить";
    }
    /// <summary>
    /// Данные ППА
    /// </summary>
    public class PreCheckElementNameIndividualCards
    {
        /// <summary>
        /// Путь к Grid индивидуальных карточек
        /// </summary>
        public static string FullTreeCard = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:PpaNavigatorView\\AutomationId:uxNavigator\\";
        /// <summary>
        /// Условие куда подставить ИНН ППА Отбор
        /// </summary>
        public static string DataAreaCard = $"{FullTreeCard}AutomationId:splitContainer\\AutomationId:gridConditions\\Name:List`1 row ";
        /// <summary>
        /// Журнал данных Карт
        /// </summary>
        public static string GridJournalCard = $"{FullTreeCard}AutomationId:splitContainer\\AutomationId:gridData\\Name:select0 row ";
        /// <summary>
        /// Фильтр обратно
        /// </summary>
        public static string GridFiltersCard = $"{FullTreeCard}AutomationId:tsControlPanel\\Name:Фильтр";
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
        ///  Номер ОКВЭД
        /// </summary>
        public static string PanelElementOkvedCode = $"{PanelElement}AutomationId:taxpayerTabControl\\AutomationId:ultraTabPageControl1\\AutomationId:txtOkvedCode";
        /// <summary>
        ///  Имя ОКВЭД
        /// </summary>
        public static string PanelElementOkvedName = $"{PanelElement}AutomationId:taxpayerTabControl\\AutomationId:ultraTabPageControl1\\AutomationId:txtOkvedName";
        /// <summary>
        /// Группа по маштабам придприятия
        /// </summary>
        public static string PanelElementOrgScale = $"{PanelElement}AutomationId:taxpayerTabControl\\AutomationId:ultraTabPageControl1\\AutomationId:txtOrgScale";
        /// <summary>
        /// Сегмент предприятия
        /// </summary>
        public static string PanelElementtxtOsn = $"{PanelElement}AutomationId:taxpayerTabControl\\AutomationId:ultraTabPageControl1\\AutomationId:txtOsn";
        /// <summary>
        /// Панель с показателями
        /// </summary>
        public static string PanelDataGrid = $"{PanelElement}AutomationId:taxpayerTabControl\\AutomationId:ultraTabPageControl3\\AutomationId:ultraGridCalculated\\Name:BindingList`1 row ";
        /// <summary>
        /// Расчатные показатели
        /// </summary>
        public static string RaschetCard = $"{PanelElement}AutomationId:taxpayerTabControl\\Name:Расчетные показатели";
        /// <summary>
        /// Обновить Индивидуальные карточки ППА
        /// </summary>
        public static string UpdateCashFaceCard = "Name:DockTop\\Name:Ribbon\\Name:Поиск\\Name:Управление\\Name:Обновить";
        /// <summary>
        /// Открыть ИКН
        /// </summary>
        public static string OpenFaceCard = "Name:DockTop\\Name:Ribbon\\Name:Данные\\Name:Управление\\Name:Открыть ИКН";
    }
 }
