using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryAIS3Windows.AutomationsUI.Otdels.Uregulirovanie
{
   public class UregulirovanieElementName
    {

        ///Данные о подписании справки
        /// <summary>
        /// Журнал пользовательских заданий по справки
        /// </summary>
        public static string JurnalsUserOperationSpravki = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:UserOperationsView\\AutomationId:ultraPanel1\\AutomationId:splitContainer1\\Name:user_operation row 1";
        /// <summary>
        /// Номер
        /// </summary>
        public static string Number = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:HopelessDebtDecisionAddInquirySigningStep1View\\AutomationId:ResumptionClaimDocAddSelectWithdrawalDocView_Fill_Panel\\AutomationId:grpBig\\AutomationId:hopelessDebtDecisionInquiryDetailControl1\\AutomationId:ultraGroupBox4\\AutomationId:txtInquiryNum";
        /// <summary>
        /// ИНН
        /// </summary>
        public static string Inn = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:HopelessDebtDecisionAddInquirySigningStep1View\\AutomationId:ResumptionClaimDocAddSelectWithdrawalDocView_Fill_Panel\\AutomationId:grpBig\\AutomationId:hopelessDebtDecisionInquiryDetailControl1\\AutomationId:ultraGroupBox3\\AutomationId:ultraTextEditor6";
        /// <summary>
        /// ФИО
        /// </summary>
        public static string Fio = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:HopelessDebtDecisionAddInquirySigningStep1View\\AutomationId:ResumptionClaimDocAddSelectWithdrawalDocView_Fill_Panel\\AutomationId:grpBig\\AutomationId:hopelessDebtDecisionInquiryDetailControl1\\AutomationId:ultraGroupBox3\\AutomationId:ultraTextEditor7";
        /// <summary>
        /// ИНН Решения
        /// </summary>
        public static string InnResh = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:HopelessDebtDecisionDocSigningView\\AutomationId:ResumptionClaimDocAddSelectWithdrawalDocView_Fill_Panel\\AutomationId:grpBig\\AutomationId:hopelessDebtDecisionDocDetailControl1\\AutomationId:ultraTabControl1\\AutomationId:ultraTabPageControl1\\AutomationId:grpBig\\AutomationId:ultraGroupBox1\\AutomationId:ultraTextEditor6";
        /// <summary>
        /// ФИО Решения
        /// </summary>
        public static string FioResh = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:HopelessDebtDecisionDocSigningView\\AutomationId:ResumptionClaimDocAddSelectWithdrawalDocView_Fill_Panel\\AutomationId:grpBig\\AutomationId:hopelessDebtDecisionDocDetailControl1\\AutomationId:ultraTabControl1\\AutomationId:ultraTabPageControl1\\AutomationId:grpBig\\AutomationId:ultraGroupBox1\\AutomationId:ultraTextEditor7";
        /// <summary>
        /// Сумма решения
        /// </summary>
        public static string SummResh = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:HopelessDebtDecisionDocSigningView\\AutomationId:ResumptionClaimDocAddSelectWithdrawalDocView_Fill_Panel\\AutomationId:grpBig\\AutomationId:hopelessDebtDecisionDocDetailControl1\\AutomationId:ultraTabControl1\\AutomationId:ultraTabPageControl1\\AutomationId:grpBig\\AutomationId:ultraGroupBox5\\AutomationId:numOverallSum";
        /// <summary>
        /// Сохранить документ
        /// </summary>
        public static string SaveUser = "Name:DockTop\\Name:Ribbon\\Name:Данные о недоимках\\Name:Документ\\Name:Сохранить документ";
        /// <summary>
        /// Проект решения о списания задолженности
        /// </summary>
        public static string SaveProject = "Name:DockTop\\Name:Ribbon\\Name:Данные о недоимках\\Name:Документ\\Name:Создать проект решения о списании задолженности";
        /// <summary>
        /// Передать на подписание
        /// </summary>
        public static string SendSender = "Name:DockTop\\Name:Ribbon\\Name:Данные о недоимках\\Name:Документ\\Name:Передать на подписание";
        /// <summary>
        /// Произвести списание недоимок и задолженностей
        /// </summary>
        public static string SendSenderZadoljenost = "Name:DockTop\\Name:Ribbon\\Name:Данные о недоимках\\Name:Документ\\Name:Произвести списание недоимок и задолженностей";
        /// <summary>
        /// Завершение подписи
        /// </summary>
        public static string WinOk = "Name:Завершение работы\\AutomationId:MessageBoxView\\AutomationId:grpBackground\\AutomationId:grpBottom\\AutomationId:btnOK";
        /// <summary>
        /// Окно исключения
        /// </summary>
        public static string WinOkExeptions = "Name:Внимание\\AutomationId:MessageBoxView\\AutomationId:grpBackground\\AutomationId:grpBottom\\AutomationId:btnOK";

    }
    /// <summary>
    /// Описание по журналу по требованию об уплате
    /// </summary>
    public class Trebovanie
    {
        ///Данные о подписании справки
        /// <summary>
        /// Журнал пользовательских заданий по справки
        /// </summary>
        public static string JurnalsTrebovanie = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:NavigatorViewBase2\\AutomationId:NavigatorViewBase_Fill_Panel\\AutomationId:grpBig\\AutomationId:ctlNavigator\\AutomationId:splitContainer\\AutomationId:gridData";
        /// <summary>
        /// Вкладка информация о вручении
        /// </summary>
        public static string TabIfo = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:RequirementDocDetailView\\AutomationId:grpBig\\AutomationId:tab\\Name:Информация о вручении";
        /// <summary>
        /// Признак вручения
        /// </summary>
        public static string ComboBoxSelect = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:RequirementDocDetailView\\AutomationId:grpBig\\AutomationId:tab\\AutomationId:ultraTabPageControl2\\AutomationId:ultraGroupBox1\\AutomationId:ctrlDocDeliveryInfoControl\\AutomationId:grpDeliveryInfo\\AutomationId:cmbDeliverySign";
        /// <summary>
        /// Способ вручения
        /// </summary>
        public static string ComboboxSend = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:RequirementDocDetailView\\AutomationId:grpBig\\AutomationId:tab\\AutomationId:ultraTabPageControl2\\AutomationId:ultraGroupBox1\\AutomationId:ctrlDocDeliveryInfoControl\\AutomationId:grpDeliveryInfo\\AutomationId:cmbDeliveryWay";
        /// <summary>
        /// Дата вручения
        /// </summary>
        public static string Date = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:RequirementDocDetailView\\AutomationId:grpBig\\AutomationId:tab\\AutomationId:ultraTabPageControl2\\AutomationId:ultraGroupBox1\\AutomationId:ctrlDocDeliveryInfoControl\\AutomationId:grpDeliveryInfo\\AutomationId:dtDeliveryDate";
        /// <summary>
        /// Панель список требований
        /// </summary>
        public static string ListPanel = "Name:DockTop\\Name:Ribbon\\Name:Ribbon Tabs\\Name:Список требований";
        /// <summary>
        /// Кнопка открыть на панели список требований открыть
        /// </summary>
        public static string Open = "Name:DockTop\\Name:Ribbon\\Name:Список требований\\Name:Документ\\Name:Открыть";
        /// <summary>
        /// Панель сохранить
        /// </summary>
        public static string Save = "Name:DockTop\\Name:Ribbon\\Name:Требование\\Name:Документ\\Name:Сохранить";
        /// <summary>
        /// Панель назад
        /// </summary>
        public static string Back = "Name:DockTop\\Name:Ribbon\\Name:Требование\\Name:Вернуться";
    }
}
