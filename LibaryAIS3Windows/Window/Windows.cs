using AutoIt;
using System.Drawing;
using LibaryAIS3Windows.ButtonsClikcs;

namespace LibaryAIS3Windows.Window
{
    /// <summary>
    /// Класс констант текста АИС 3
    /// </summary>
    public class WindowsAis3
    {
        /// <summary>
        /// Координата X1
        /// </summary>
        internal int X1 { get; set; }
        /// <summary>
        /// Координата Y1
        /// </summary>
        internal int Y1 { get; set; }
        /// <summary>
        /// Координата X2
        /// </summary>
        internal int X2 { get; set; }
        /// <summary>
        /// Координата Y2
        /// </summary>
        internal int Y2 { get; set; }
        /// <summary>
        /// Для наведения фокуса на Аиз 3
        /// </summary>
        internal static string GridWinAis3 = "[NAME:gridData]";

        /// <summary>
        /// Переменная для второго параметра Text 
        /// </summary>
        internal static string Text = "";

        /// <summary>
        /// Константа символизирует окно АИС 3 Title
        /// </summary>
        internal static string AisNalog3 = "АИС Налог-3 ПРОМ ";

        /// <summary>
        /// Переменная для подготовки условия Пожалйста подождите
        /// </summary>
        internal static string WinWait = "Подготовка условий. Пожалуйста подождите...";

        /// <summary>
        /// Нет Данных при отборе
        /// </summary>
        internal static string DataNotFound = "Данные, удовлетворяющие заданным условиям не найдены.";

        /// <summary>
        /// Обновление Данных пожалуйста подождите
        /// </summary>
        internal static string UpdateDataSource = "Обновление данных. Пожалуйста подождите...";
        /// <summary>
        /// Считать позицию Общего окна АИС 3
        /// </summary>
        internal Rectangle WindowsAis = AutoItX.WinGetPos(AisNalog3, Text);
        /// <summary>
        /// Окно Диалоговое Налог
        /// </summary>
        internal Rectangle WinNalog = AutoItX.WinGetPos("Налог", "");
        /// <summary>
        /// Считать позицию создание заявки на формирование СНУ
        /// Так- же данная функция работае для пользовательских заданий
        /// </summary>
        internal static string[] WinRequest = 
         {
            "АИС Налог-3 ПРОМ ",
            "", 
            "[NAME:CreateRequestImplView]"
         };
        /// <summary>
        /// Grid контроль полей для вычисления
        /// </summary>
        internal static string[] WinGrid =
        {
            "АИС Налог-3 ПРОМ ",
            "",
            "[Name:gridConditions]"
        };
        /// <summary>
        /// Выборка ведомости 1
        /// </summary>
        internal static string[] ConditionsVed1 =
        {
            "АИС Налог-3 ПРОМ ",
            "",
            "[NAME:Conditions]"
        };
        /// <summary>
        /// Журнал ведомости 1
        /// </summary>
        internal static string[] Journal =
        {
            "АИС Налог-3 ПРОМ ",
            "",
            "[NAME:grdUncertainJournal]"
        };
        /// <summary>
        /// Журнал ведомости 1
        /// </summary>
        internal static string[] JournalStatusBar =
        {
            "АИС Налог-3 ПРОМ ",
            "",
            "[NAME:_UncertainJournalR1ViewUnpinnedTabAreaBottom]"
        };

        /// <summary>
        /// Ведомость 1 Окно Налог
        /// </summary>
        internal static string[] Nalog =
        {
            "Налог",
            "Выбрать",
            "[NAME:_thesGrid]"
        };
        /// <summary>
        /// Уточнение платежа
        /// </summary>
        internal static string[] PlatejYt =
        {
            "АИС Налог-3 ПРОМ ",
            "",
            "[NAME:grpPayment]"
        };
        /// <summary>
        /// Контроль поле для пользовательских заданий
        /// </summary>
        internal static string[] GridMain =
        {
            "АИС Налог-3 ПРОМ ",
            "",
            "[NAME:Conditions]"
        };
        /// <summary>
        /// Контрольная панель
        /// </summary>
        internal static string[] ControlPanel =
        {
            "АИС Налог-3 ПРОМ ",
            "",
            "[NAME:tsControlPanel]"
        };
        /// <summary>
        /// Grid Дата Миграции
        /// </summary>
        internal static string[] GridDataMigration =
        {
            "АИС Налог-3 ПРОМ ",
            "",
            "[NAME:gridData]"
        };

        /// <summary>
        /// Grid Внутри Ultra Дата Миграции
        /// </summary>
        internal static string[] UltraGridDataMigration =
        {
            "АИС Налог-3 ПРОМ ",
            "",
            "[NAME:ultraGrid1]"
        };

        /// <summary>
        /// Проверка наличия окна АИС налог 3 
        /// если вернет 1 то окно существует если 0 то не существует!!!
        /// </summary>
        /// <returns>Возвращает 1 или 0 </returns>
        public int WinexistsAis3()
        {
           
            return AutoItX.WinExists(AisNalog3, Text);
        }
        /// <summary>
        /// Считывание позиции первого класса
        /// </summary>
        /// <param name="title">Заголовок</param>
        /// <param name="text">Текст если есть</param>
        /// <param name="classing">Классы</param>
        /// <returns></returns>
        public void ControlGetPos1(string title, string text, string classing)
        {
            var param = AutoItX.ControlGetPos(title, text, classing);
            X1 = param.X;
            Y1 = param.Y;
        }
        /// <summary>
        /// Считывание позиции первого 2 класса
        /// </summary>
        /// <param name="title">Заголовок</param>
        /// <param name="text">Текст если есть</param>
        /// <param name="classing">Классы</param>
        /// <returns></returns>
        public void ControlGetPos2(string title, string text, string classing)
        {
            var param = AutoItX.ControlGetPos(title, text, classing);
            X2 = param.X;
            Y2 = param.Y;
        }
        /// <summary>
        /// Первоначальная навигация для уточнение 100 "Расчеты с бюджетом"
        /// </summary>
        public void StartNavigate()
        {
            ControlGetPos1(JournalStatusBar[0], JournalStatusBar[1], JournalStatusBar[2]);
            AutoItX.MouseMove(WindowsAis.X + X1 + 40, WindowsAis.Y + Y1 + 15);
            ControlGetPos1(WindowsAis3.Journal[0], WindowsAis3.Journal[1], WindowsAis3.Journal[2]);
            AutoItX.MouseClick(ButtonConstant.MouseLeft, WindowsAis.X + X1 + 30, WindowsAis.Y + Y1 + 285, 2);
            AutoItX.Sleep(1000);
        }

        /// <summary>
        /// Первоначальная навигация для миграции"
        /// </summary>
        public void StartNMigration()
        {
            ControlGetPos1(GridDataMigration[0], GridDataMigration[1], GridDataMigration[2]);
            AutoItX.MouseClick(ButtonConstant.MouseLeft, WindowsAis.X + X1 + 62, WindowsAis.Y + Y1 + 93);
            AutoItX.Sleep(1000);
        }

        public void SendParametrsPriem()
        {
            ControlGetPos1(WinGrid[0], WinGrid[1], WinGrid[2]);
            AutoItX.MouseClick(ButtonConstant.MouseLeft, WindowsAis.X + X1 + 40, WindowsAis.Y + Y1 + 35);
            AutoItX.Send(ButtonConstant.Right5);
            AutoItX.Send(ButtonConstant.Enter);
            AutoItX.Send("10");
            AutoItX.Send(ButtonConstant.Enter);
            AutoItX.Send(ButtonConstant.Down16);
            AutoItX.Send(ButtonConstant.Enter);
            AutoItX.Send("7751");
            AutoItX.Send(ButtonConstant.Enter);
            AutoItX.MouseClick(ButtonConstant.MouseLeft, WindowsAis.X + X1 + 1011, WindowsAis.Y + Y1 + 55);
            AutoItX.MouseClick(ButtonConstant.MouseLeft, WindowsAis.X + X1 + 1011, WindowsAis.Y + Y1 + 101);
            AutoItX.MouseClick(ButtonConstant.MouseLeft, WindowsAis.X + X1 + 1011, WindowsAis.Y + Y1 + 366);
        }

        public void SendParametrsPeredahca()
        {
            ControlGetPos1(WinGrid[0], WinGrid[1], WinGrid[2]);
            AutoItX.MouseClick(ButtonConstant.MouseLeft, WindowsAis.X + X1 + 40, WindowsAis.Y + Y1 + 35);
            AutoItX.Send(ButtonConstant.Right5);
            AutoItX.Send(ButtonConstant.Enter);
            AutoItX.Send("10");
            AutoItX.Send(ButtonConstant.Enter);
            AutoItX.Send(ButtonConstant.Down15);
            AutoItX.Send(ButtonConstant.Enter);
            AutoItX.Send("7751");
            AutoItX.Send(ButtonConstant.Enter);
            AutoItX.MouseClick(ButtonConstant.MouseLeft, WindowsAis.X + X1 + 1011, WindowsAis.Y + Y1 + 55);
            AutoItX.MouseClick(ButtonConstant.MouseLeft, WindowsAis.X + X1 + 1011, WindowsAis.Y + Y1 + 101);
            AutoItX.MouseClick(ButtonConstant.MouseLeft, WindowsAis.X + X1 + 1011, WindowsAis.Y + Y1 + 366);
        }
    }
}
