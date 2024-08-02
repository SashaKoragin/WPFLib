
namespace LibraryAIS3Windows.AutomationsUI.Otdels.Kao
{
    public class ElementNameWitnesses
    {
        /// <summary>
        /// Глобальное поле 
        /// </summary>
        public static string GlobalView = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1";
        /// <summary>
        /// Глобальное поле данные о свидетеле
        /// </summary>
        public static string GlobalDataUsers = "Name:_layoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:QuestProcView\\AutomationId:ultraGroupBox1\\AutomationId:DosvidGroupBox\\AutomationId:Speak_Ask\\Name:Данные о свидетеле";
        /// <summary>
        /// Кнопка выбора
        /// </summary>
        public static string SelectFace = $"{GlobalView}\\AutomationId:InitQuestioningOperationView\\AutomationId:InitProcGroupBox\\AutomationId:NPGroupBox\\AutomationId:NPButton";
        /// <summary>
        /// Выбрать ФЛ 
        /// </summary>
        public static string SelectFaceFl = "AutomationId:FindFaceAll\\AutomationId:ultraPanelFormFill\\AutomationId:ultraPanelForNavigator\\AutomationId:ultraTabFace\\Name:ФЛ";
        /// <summary>
        /// Наименование иного МНК
        /// </summary>
        public static string NameMnk = $"{GlobalView}\\AutomationId:InitQuestioningOperationView\\AutomationId:InitProcGroupBox\\AutomationId:ultraGroupBox2\\AutomationId:ultraTextEditor1";
        /// <summary>
        /// Документ, которым оформлено мероприятие 
        /// </summary>
        public static string DocMail = $"{GlobalView}\\AutomationId:InitQuestioningOperationView\\AutomationId:InitProcGroupBox\\AutomationId:ultraGroupBox2\\AutomationId:ultraTextEditor2";
        /// <summary>
        /// Номер документа
        /// </summary>
        public static string NumberDoc = $"{GlobalView}\\AutomationId:InitQuestioningOperationView\\AutomationId:InitProcGroupBox\\AutomationId:ultraGroupBox2\\AutomationId:ultraTextEditor3";
        /// <summary>
        /// Дата документа
        /// </summary>
        public static string DataDoc = $"{GlobalView}\\AutomationId:InitQuestioningOperationView\\AutomationId:InitProcGroupBox\\AutomationId:ultraGroupBox2\\AutomationId:DAT_ASSIGN";
        /// <summary>
        /// Наименование организации
        /// </summary>
        public static string NameOrg = $"{GlobalView}\\AutomationId:InitQuestioningOperationView\\AutomationId:InitProcGroupBox\\Name:Данные проверяемого лица\\AutomationId:NaimNPText";
        /// <summary>
        /// Создать процедуру
        /// </summary>
        public static string StartProcedure = "Name:DockTop\\Name:Ribbon\\Name:Операции\\Name:Создать процедуру";
        /// <summary>
        /// Сообщение номер процедуры
        /// </summary>
        public static string NumberProcedure = "Name:Информация\\AutomationId:MessageBoxView\\AutomationId:grpBackground\\AutomationId:grpTop\\AutomationId:lblMessage";
        /// <summary>
        /// Кнопка Ок
        /// </summary>
        public static string OkProcedure = "Name:Информация\\AutomationId:MessageBoxView\\AutomationId:grpBackground\\AutomationId:grpBottom\\AutomationId:btnOK";
        /// <summary>
        /// Навигатор
        /// </summary>
        public static string Navigator = "Name:DockTop\\Name:Ribbon\\Name:Ribbon Tabs\\Name:Навигатор";
        /// <summary>
        /// Поиск свидетеля
        /// </summary>
        public static string Find = $"{GlobalDataUsers}\\AutomationId:ultraButton3";
        /// <summary>
        /// Сообщение о коде НО
        /// </summary>
        public static string MessageCodeNo = "Name:Предупреждение\\AutomationId:MessageBoxView\\AutomationId:grpBackground\\AutomationId:grpTop\\AutomationId:lblMessage";
        /// <summary>
        /// Предупреждение что в другом регионе
        /// </summary>
        public static string YesNo = "Name:Предупреждение\\AutomationId:MessageBoxView\\AutomationId:grpBackground\\AutomationId:grpBottom\\AutomationId:btnYes";

        /// <summary>
        /// Внимание по лицу приостановленны выездные проверки
        /// </summary>
        public static string Warning = "Name:Внимание\\AutomationId:MessageBoxView\\AutomationId:grpBackground\\AutomationId:grpBottom\\AutomationId:btnOK";
        /// <summary>
        /// Парсим код налогового органа
        /// </summary>
        public static string CodeNo = $"{GlobalView}\\AutomationId:QuestProcView\\AutomationId:ultraGroupBox1\\AutomationId:ultraGroupBox2\\AutomationId:ultraLabel6";
        ///UserData
        /// <summary>
        /// Фамилия свидетеля
        /// </summary>
        public static string Family = $"{GlobalDataUsers}\\AutomationId:ultraTextEditor1";
        /// <summary>
        /// Имя свидетеля
        /// </summary>
        public static string Name = $"{GlobalDataUsers}\\AutomationId:ultraTextEditor2";
        /// <summary>
        /// Отчество
        /// </summary>
        public static string Surname = $"{GlobalDataUsers}\\AutomationId:ultraTextEditor3";
        /// <summary>
        /// Дата рождения
        /// </summary>
        public static string DateOfBirth = $"{GlobalDataUsers}\\AutomationId:DATE_BEGIN_LOOK";
        /// <summary>
        /// Вид документа
        /// </summary>
        public static string VidDoc = $"{GlobalDataUsers}\\AutomationId:ultraGroupBox4\\AutomationId:ultraComboEditor1";
        /// <summary>
        /// Серия
        /// </summary>
        public static string Serial = $"{GlobalDataUsers}\\AutomationId:ultraGroupBox4\\AutomationId:ultraTextEditor15";
        /// <summary>
        /// Номер
        /// </summary>
        public static string Number = $"{GlobalDataUsers}\\AutomationId:ultraGroupBox4\\AutomationId:ultraTextEditor16";
        /// <summary>
        /// Дата выдачи
        /// </summary>
        public static string DateIn = $"{GlobalDataUsers}\\AutomationId:ultraGroupBox4\\AutomationId:ultraDateTimeEditor1";
        /// <summary>
        /// Код подразделения
        /// </summary>
        public static string Code = $"{GlobalDataUsers}\\AutomationId:ultraGroupBox4\\AutomationId:ultraTextEditor18";
        /// <summary>
        /// Кем выдан
        /// </summary>
        public static string WhoIn = $"{GlobalDataUsers}\\AutomationId:ultraGroupBox4\\AutomationId:ultraTextEditor19";
        /// <summary>
        /// Место жительства
        /// </summary>
        public static string Location = $"{GlobalDataUsers}\\AutomationId:ultraTextEditor6";
        /// <summary>
        /// Сохранить
        /// </summary>
        public static string Save = "Name:DockTop\\Name:Ribbon\\Name:Процедура допроса свидетеля\\Name:Процедура\\Name:Сохранить";
        /// <summary>
        /// Сохранить Да
        /// </summary>
        public static string SaveYes = "Name:Информация\\AutomationId:MessageBoxView\\AutomationId:grpBackground\\AutomationId:grpBottom\\AutomationId:btnOK";
        /// <summary>
        /// Поручение
        /// </summary>
        public static string Senders = "Name:DockTop\\Name:Ribbon\\Name:Процедура допроса свидетеля\\Name:Документы\\Name:Поручение";
        /// <summary>
        /// Зарегистрировать
        /// </summary>
        public static string Registration = "Name:DockTop\\Name:Ribbon\\Name:Процедура допроса свидетеля\\Name:Процедура\\Name:Зарегистрировать";
        /// <summary>
        /// Уведомление о вызове свидетеля
        /// </summary>
        public static string Uved = "Name:DockTop\\Name:Ribbon\\Name:Процедура допроса свидетеля\\Name:Документы\\Name:Уведомление о вызове свидетеля";
        /// <summary>
        /// Дата
        /// </summary>
        public static string Date = $"{GlobalView}\\AutomationId:QuestSummon126View\\AutomationId:ultraGroupBox1\\AutomationId:ultraGroupBox2\\AutomationId:ultraDateTimeEditor1";
        /// <summary>
        /// Время
        /// </summary>
        public static string Time = $"{GlobalView}\\AutomationId:QuestSummon126View\\AutomationId:ultraGroupBox1\\AutomationId:ultraGroupBox2\\AutomationId:DATE_BEGIN_LOOK_TIME";
        /// <summary>
        /// Кабинет
        /// </summary>
        public static string Office = $"{GlobalView}\\AutomationId:QuestSummon126View\\AutomationId:ultraGroupBox1\\AutomationId:ultraGroupBox2\\AutomationId:ultraTextEditor1\\LocalizedControlType:поле";
        /// <summary>
        /// Предупреждения процедуры регистрации
        /// </summary>
        public static string RegistrationYes = "Name:Предупреждение\\AutomationId:MessageBoxView\\AutomationId:grpBackground\\AutomationId:grpBottom\\Name:Да";
        /// <summary>
        /// Ок процедуры регистрации
        /// </summary>
        public static string RegistrationOk = "Name:Информация\\AutomationId:MessageBoxView\\AutomationId:grpBackground\\AutomationId:grpBottom\\Name:ОК";
       /// <summary>
        /// Показания свидетеля
        /// </summary>
        public static string InformationFace = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:OrderOperationView2018\\Name:Лица, в отношении которых вопросы";
        /// <summary>
        /// Добавить лицо 
        /// </summary>
        public static string AddFace = $"{InformationFace}\\AutomationId:ultraExpandableGroupBox3\\AutomationId:ultraExpandableGroupBoxPanel1\\Name:Добавить лицо";
        /// <summary>
        /// Выбор ЮЛ 
        /// </summary>
        public static string FaceUl = "AutomationId:FindFaceNew\\AutomationId:ultraPanelFormFill\\AutomationId:ultraPanelForNavigator\\AutomationId:ultraTabFace\\Name:ЮЛ";
        /// <summary>
        /// Выбор ФЛ
        /// </summary>
        public static string FaceFl = "AutomationId:FindFaceNew\\AutomationId:ultraPanelFormFill\\AutomationId:ultraPanelForNavigator\\AutomationId:ultraTabFace\\Name:ФЛ";
        /// <summary>
        /// Показание свидетелей
        /// </summary>
        public static string Question = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:OrderOperationView2018\\Name:Вопросы свидетелю";
        /// <summary>
        /// Добавить вопрос
        /// </summary>
        public static string AddQuestion = $"{Question}\\AutomationId:ultraExpandableGroupBoxPanel3\\AutomationId:ultraGroupBox10\\Name:Добавить";
        /// <summary>
        /// Добавить текст вопроса
        /// </summary>
        public static string AddTextQuestion = $"{Question}\\AutomationId:ultraExpandableGroupBoxPanel3\\AutomationId:ultraGroupBox11\\AutomationId:ultraTextEditorEdit";
        /// <summary>
        /// Кнопка Ok
        /// </summary>
        public static string OkQuestion = $"{Question}\\AutomationId:ultraExpandableGroupBoxPanel3\\AutomationId:ultraGroupBox13\\AutomationId:ultraButton13";
        /// <summary>
        /// Выбрать подписанта
        /// </summary>
        public static string FaceSender = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:OrderOperationView2018\\AutomationId:regControl1\\Name:Регистрационные данные\\AutomationId:ultraButton1";
        /// <summary>
        /// Сохранить документ
        /// </summary>
        public static string SaveDocument = "Name:DockTop\\Name:Ribbon\\Name:Операции\\Name:Регистрационные данные\\Name:Сохранить";
        /// <summary>
        /// Ок документ сохранен
        /// </summary>
        public static string DocumentOk = "Name:Сообщение\\AutomationId:MessageBoxView\\AutomationId:grpBackground\\AutomationId:grpBottom\\AutomationId:btnOK";
        /// <summary>
        /// Зарегистрировать документ
        /// </summary>
        public static string DocumentRegistration = "Name:DockTop\\Name:Ribbon\\Name:Операции\\Name:Регистрационные данные\\Name:Зарегистрировать";
        /// <summary>
        /// Да
        /// </summary>
        public static string DocumentYes = "Name:Предупреждение\\AutomationId:MessageBoxView\\AutomationId:grpBackground\\AutomationId:grpBottom\\Name:Да";
        /// <summary>
        /// Отправка в другое НО
        /// </summary>
        public static string DocYesToSend = "Name:Информация\\AutomationId:MessageBoxView\\AutomationId:grpBackground\\AutomationId:grpBottom\\AutomationId:btnOK";
        /// <summary>
        /// Отправить
        /// </summary>
        public static string SendMessage = "Name:DockTop\\Name:Ribbon\\Name:Операции\\Name:Регистрационные данные\\Name:Отправить";
        /// <summary>
        /// Ок сообщение
        /// </summary>
        public static string SendInfo = "Name:Информация\\AutomationId:MessageBoxView\\AutomationId:grpBackground\\AutomationId:grpBottom\\AutomationId:btnOK";
        /// <summary>
        /// Закрыть
        /// </summary>
        public static string Closed = "Name:DockTop\\Name:Ribbon\\Name:Процедура допроса свидетеля\\Name:Процедура\\Name:Закрыть";

        ////Аннулирование процедуры 
        /// <summary>
        /// Аннулировать процедуру
        /// </summary>
        public static string Delete = "Name:DockTop\\Name:Ribbon\\Name:Процедура допроса свидетеля\\Name:Процедура\\Name:Аннулировать";
        /// <summary>
        /// Аннулировать Да
        /// </summary>
        public static string DeleteYes = "Name:Предупреждение\\AutomationId:MessageBoxView\\AutomationId:grpBackground\\AutomationId:grpBottom\\AutomationId:btnYes";
        /// <summary>
        /// Сообщение об ошибке
        /// </summary>
        public static string MessageError = "AutomationId:LayoutWorkspace\\AutomationId:ShellLayoutView\\AutomationId:ShellLayoutView_Fill_Panel\\AutomationId:taskWindowWorkspaceView1\\AutomationId:AnnulmentProcedureView\\Name:Аннулирование процедуры\\AutomationId:AnnulmentProcedureReasonTextEditor";
        /// <summary>
        /// Точно аннулировать
        /// </summary>
        public static string DeleteProcedure = "Name:DockTop\\Name:Ribbon\\Name:Аннулирование процедуры МНК\\Name:Аннулирование\\Name:Аннулировать";
            
    }
}
