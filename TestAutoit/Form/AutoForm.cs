using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestAutoit.ButtonsKey;
using TestAutoit.Start;
using TestAutoit.Window;

namespace TestAutoit.Form
{
    public partial class AutoForm : System.Windows.Forms.Form
    {
        public  Form.FormSpisok.WpfForm.FormSpisok Form = new FormSpisok.WpfForm.FormSpisok();
        public AutoForm()
        {
            InitializeComponent();
            Forvirovanie.Child = Form;
        }
        /// <summary>
        /// Идея данной штуки заключается в том что принимает значения от разных
        /// событий нажатия а в классе манипуляции состояния 
        /// там он разберется какая кнопка нажата
        /// Сдесь есть баг если ползователь выберет другую кнопку состояние первой не поменяется
        /// </summary>
        public static Button AllButtonControls { get; set; } 
        private void button1_Click(object sender, EventArgs e)
        {
            Start.StrartUse strart = new StrartUse(this);
            strart.Start();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Start.StrartUse start = new StrartUse(this);
            start.Ptrints();
        }

        private void SnuOneB(object sender, EventArgs e)
        {
            Window.TimeClass time = new TimeClass();
            time.Timeclass();
        }


        /// <summary>
        /// Горячая клавиша изменения состояния Bool Работает или не работает
        /// Реализуется в using TestAutoit.ButtonsKey
        /// </summary>
        /// <param name="sender">Не используется</param>
        /// <param name="e">Аргументы параметры</param>
        private void PressButon(object sender, KeyEventArgs e)
        {
           Task.Run(delegate
            {
                KeyButtons button = new KeyButtons();
                button.Button(e,AllButtonControls);
            });
        }
        /// <summary>
        /// Обработчик для формирования заявки СНУ ФЛ
        /// </summary>
        /// <param name="sender">Объукт конвертируем в кнопку</param>
        /// <param name="e">Аргументы</param>
        private void OneZayvkiSnu(object sender, EventArgs e)
        {
            AllButtonControls = (Button)sender;
            TimeClass time = new TimeClass();
            time.AutoClicerSnuOneForm(AllButtonControls);
        }
    }
}
