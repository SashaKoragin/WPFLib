using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAIS3Windows.AutomationsUI.Otdels.Okp1
{
    public class ModelElementName
    {
        /// <summary>
        /// Grid Data
        /// </summary>
        public static string Grid = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:SvedPoNDSView\\AutomationId:NavigatorMDIControl\\AutomationId:splitContainer\\AutomationId:masterNavigator\\AutomationId:splitContainer\\AutomationId:gridData";

        /// <summary>
        /// Row
        /// </summary>
        public static string SelectRow = $"{Grid}\\Name:select0 row ";

        /// <summary>
        /// Подписать
        /// </summary>
        public static string Subscribe = "Name:DockTop\\Name:Ribbon\\Name:Реестр исходящих документов для обработки и отправки\\Name:Подписать";
        /// <summary>
        /// Окно подписать
        /// </summary>
        public static string WinSubscribe = "Name:Подписание\\AutomationId:ultraCombo1";
        /// <summary>
        /// Ок окно
        /// </summary>
        public static string OkSubscribe = "Name:Подписание\\Name:Ок";
        /// <summary>
        /// Печать
        /// </summary>
        public static string Print = "Name:DockTop\\Name:Ribbon\\Name:Реестр исходящих документов для обработки и отправки\\Name:Печать документа";
        /// <summary>
        /// Отправить
        /// </summary>
        public static string Send = "Name:DockTop\\Name:Ribbon\\Name:Реестр исходящих документов для обработки и отправки\\Name:Отправить";
        /// <summary>
        /// Отправить документ
        /// </summary>
        public static string SendDocument = "Name:Отправка документов\\AutomationId:ViewA01Host\\AutomationId:elementHost1\\Name:elementHost1\\ClassName:CamA01ClaimView\\AutomationId:SendCommand\\Name:Отправить";
        /// <summary>
        /// Окно Ок
        /// </summary>
        public static string WinOk = "Name:Информация\\AutomationId:MessageBoxView\\AutomationId:grpBackground\\AutomationId:grpBottom\\AutomationId:btnOK";
        /// <summary>
        /// Обновить данные
        /// </summary>
        public static string Update = "Name:DockTop\\Name:Ribbon\\Name:Реестр исходящих документов для обработки и отправки\\Name:Документ\\Name:Обновить данные";
    }
}
