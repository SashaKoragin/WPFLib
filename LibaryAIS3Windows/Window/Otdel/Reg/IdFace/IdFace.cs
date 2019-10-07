using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryAIS3Windows.Window.Otdel.Reg.IdFace
{
   public class IdFace
    {
        /// <summary>
        /// Текст УН запроса на визуальную идентификацию
        /// </summary>
        internal static string IdVisual = "УН запроса на визуальную идентификацию";
        /// <summary>
        /// Обработка Транспорта
        /// </summary>
        internal static string IdVisualTs = "УН запроса на виз идент";
        /// <summary>
        /// Текст ун фл
        /// </summary>
        internal static string IdFl = "УН ФЛ в ЕГРН";
        /// <summary>
        /// Окно Внимание Идентификация завершина
        /// </summary>
        public static string[] WinInfo =
       {
           "Внимание",
           "Идентификация выполнена."
       };
        /// <summary>
        /// Поиск конечного журнала
        /// </summary>
        public static string JurnalsDocumentsFirstElement = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:NavigatorView\\AutomationId:splitContainer\\AutomationId:navigatorControl\\AutomationId:splitContainer\\AutomationId:gridData\\Name:select0 row 1";
        /// <summary>
        /// Поиск конечного журнала
        /// </summary>
        public static string JurnalsDocumentsCaption = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:NavigatorView\\AutomationId:splitContainer\\AutomationId:navigatorControl\\AutomationId:splitContainer\\AutomationId:gridData\\Name:Caption";
        /// <summary>
        ///Поиск документа в журнале
        /// </summary>
        public static string Doc = "Name:УН входящего документа";
        /// <summary>
        /// Диалоговое окно Для нажатия Да
        /// </summary>
        public static string Qweshions = "Name:Вопрос\\AutomationId:MessageBoxView\\AutomationId:grpBackground\\AutomationId:grpBottom\\AutomationId:btnYes";
        /// <summary>
        /// Окно с выбором создать
        /// </summary>
        public static string ErrorsCreate = "Name:Выберите ошибку КОФО\\AutomationId:ChooseErrCodeForAnnulDocFormView\\AutomationId:ubApply";
        /// <summary>
        /// Окно с выбором закрыть
        /// </summary>
        public static string ErrorsCancel = "Name:Выберите ошибку КОФО\\AutomationId:ChooseErrCodeForAnnulDocFormView\\AutomationId:ubCancel";
        /// <summary>
        /// Окно с выбором Ок
        /// </summary>
        public static string ErrorsOk = "Name:Выберите ошибку КОФО\\Name:Предупреждение\\AutomationId:MessageBoxView\\AutomationId:grpBackground\\AutomationId:grpBottom\\AutomationId:btnOK";
        /// <summary>
        /// Окно Ok
        /// </summary>
        public static string WinOk = "Name:Информация\\AutomationId:MessageBoxView\\AutomationId:grpBackground\\AutomationId:grpBottom\\AutomationId:btnOK";

    }
}
