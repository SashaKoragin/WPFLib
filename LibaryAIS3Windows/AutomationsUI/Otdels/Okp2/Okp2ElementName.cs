using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryAIS3Windows.AutomationsUI.Otdels.Okp2
{
   public class Okp2ElementName
   {
       public static string PublicName = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\";
       /// <summary>
       /// Обновить данные перед автоматом
       /// </summary>
        public static string UpdateData = "Name:DockTop\\Name:Ribbon\\Name:2. Журнал налоговых правонарушений\\Name:Документ\\Name:Обновить данные";
      
        /// <summary>
        /// Журнал для отработки
        /// </summary>
       public static string AllTaxJournal = PublicName+ "AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:masterNavigator\\AutomationId:splitContainer\\AutomationId:gridData";

        public static string ElementJournal = "\\Name:select0 row 0";
        /// <summary>
        /// Открыть комплекс мероприятий
        /// </summary>
        public static string OpenComplex = "Name:DockTop\\Name:Ribbon\\Name:2. Журнал налоговых правонарушений\\Name:Открыть комплекс мероприятий";
       /// <summary>
       /// Редактировать
       /// </summary>
       public static string EditTask = PublicName + "AutomationId:DfMainWorkspaceBase\\AutomationId:WorkspaceMain\\AutomationId:viewContainer\\AutomationId:DfProcessView1\\AutomationId:elementHost1\\Name:elementHost1\\ClassName:ProcessViewWpf1\\AutomationId:_this\\AutomationId:treeView1\\Name:Материалы для рассмотрения\\Name:Rnivc.Cam.Knp.Client.PfTemp.CustomOperations.OperationCustomEntity.DfCEXamlViewSingle\\AutomationId:Header\\ClassName:DfCEXamlViewSingle\\AutomationId:propControl\\AutomationId:btnDefaultCommand";

        /// <summary>
        /// Подписать все
        /// </summary>
        public static string SignAll = "Name:DockTop\\Name:Ribbon\\Name:Документ\\Name:Общие\\Name:Подписать";
        /// <summary>
        /// Отправить
        /// </summary>
        public static string SendAll = "Name:DockTop\\Name:Ribbon\\Name:Документ\\Name:Общие\\Name:Отправить";
        /// <summary>
        /// Ловим окно
        /// </summary>
        public static string ViewName = "Подписание документа";
        /// <summary>
        /// Просмотреть форму
        /// </summary>
        public static string ViewPrint = "AutomationId:ubtShowPrintForm";
        /// <summary>
        /// Ознакомится
        /// </summary>
        public static string ViewCheks = "AutomationId:groupBox1\\AutomationId:checkBox1";
        /// <summary>
        /// Подписать
        /// </summary>
        public static string Sign = "AutomationId:ubtSign";

        /// <summary>
        /// Окно отправки документа
        /// </summary>
        public static string SendDocument = "Name:Отправка документов";
        /// <summary>
        /// ТКС
        /// </summary>
        public static string Tks = "AutomationId:ViewA01Host\\AutomationId:elementHost1\\Name:elementHost1\\ClassName:CamA01MainView\\ClassName:TabControl\\ClassName:ScrollViewer\\Name:ТКС";
        /// <summary>
        /// ЛК 3
        /// </summary>
        public static string Lk3 = "AutomationId:ViewA01Host\\AutomationId:elementHost1\\Name:elementHost1\\ClassName:CamA01MainView\\ClassName:TabControl\\ClassName:ScrollViewer\\Name:ЛК3";
        /// <summary>
        /// Почта
        /// </summary>
        public static string Mail = "AutomationId:ViewA01Host\\AutomationId:elementHost1\\Name:elementHost1\\ClassName:CamA01MainView\\ClassName:TabControl\\ClassName:ScrollViewer\\Name:Почта";

        public static string Close = "AutomationId:TitleBar\\Name:Закрыть";
    }
}
