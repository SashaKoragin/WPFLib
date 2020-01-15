using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryAIS3Windows.AutomationsUI.Otdels.Registration
{
   public class RegistrationElementName
    {
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
        /// <summary>
        /// Кнопка признать документ ошибочно зарегистрированным "Кнопка"
        /// </summary>
        public static string IsErrorDocument = "Name:DockTop\\Name:Ribbon\\Name:Журнал поступивших документов ФЛ\\Name:Работа с документами\\Name:Признать документ ошибочно зарегистрированным";
    }

    public class RegistrationElementNameVisualBank
    {
        /// <summary>
        /// Вернутся к списку
        /// </summary>
        public static string ReturnList = "Name:DockTop\\Name:Ribbon\\Name:Документ\\Name:Вернуться к списку";
        /// <summary>
        /// Вернутся к поиску
        /// </summary>
        public static string Return = "Name:DockTop\\Name:Ribbon\\Name:Документ\\Name:Вернуться к поиску";
        /// <summary>
        /// Кнопка обновить элемент на панеле Ribiorn
        /// </summary>
        public static string UpdateButton = "Name:DockTop\\Name:Ribbon\\Name:Документ\\Name:Обновить";
        /// <summary>
        /// Приступить к идентификации
        /// </summary>
        public static string Identification = "Name:DockTop\\Name:Ribbon\\Name:Документ\\Name:Приступить к идентификации";
        /// <summary>
        /// Идентифицировать лицо
        /// </summary>
        public static string StartIdentification = "Name:DockTop\\Name:Ribbon\\Name:Документ\\Name:Идентифицировать лицо";
        /// <summary>
        /// Not Found Grid
        /// </summary>
        public static string JurnalsDocumentsFirstElementBank = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:ViewUT_BankSoobDefFID\\AutomationId:utcTab\\AutomationId:ultraTabPageControl1\\AutomationId:navigatorQueue\\AutomationId:splitContainer\\AutomationId:gridData\\Name:select0 row 1";
        //Окна
        /// <summary>
        /// Нажать Ок
        /// </summary>
        public static string WinOk = "Name:Завершение визуального анализа\\Name:Да";
        /// <summary>
        /// Завершение анализа
        /// </summary>
        public static string WinOkEnd = "Name:Завершение визуального анализа\\Name:ОК";

    }

    public class SettlementDebts
    {
        /// <summary>
        /// Общий журнал утверждений
        /// </summary>
        public static string JournalDocuments = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:UserOperationsView\\AutomationId:ultraPanel1\\AutomationId:splitContainer1\\AutomationId:mainGrid\\Name:user_operation row 1";
        /// <summary>
        /// Журнал для проверки
        /// </summary>
        public static string JournalSum = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:RequirementDocListApprovingView\\AutomationId:grpBig\\AutomationId:grdList\\Name:List`1 row 1";
        /// <summary>
        /// Галочка
        /// </summary>
        public static string IsCheck = "Name:Утвердить";

        /// <summary>
        ///Поиск документа в журнале Наведение фокуса на сумму
        /// </summary>
        public static string SumT = "Name:Сумма ТУ";
        /// <summary>
        /// Запуск очередного задания по требованиям
        /// </summary>
        public static string StartBeforeQ = "Name:DockTop\\Name:Ribbon\\Name:Пользовательские задания\\Name:Управление заданиями\\Name:Запустить очередное задание";
        /// <summary>
        /// Кнопка утвердить все
        /// </summary>
        public static string ButtonSettlement = "Name:DockTop\\Name:Ribbon\\Name:Список требований об уплате\\Name:Отметки\\Name:Утвердить все";
        /// <summary>
        /// Кнопка передать на обработку
        /// </summary>
        public static string ButtonSend = "Name:DockTop\\Name:Ribbon\\Name:Список требований об уплате\\Name:Действия\\Name:Передать на обработку";
    }
}
