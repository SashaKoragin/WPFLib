using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestAutoit.Form.Automat.WpfPage;
using TestAutoit.Start;

namespace TestAutoit.Form
{
    public partial class AutoForm : System.Windows.Forms.Form
    {
        internal  Form.FormSpisok.WpfForm.FormSpisok Form = new FormSpisok.WpfForm.FormSpisok();
        internal  FormSnuAuto AutoSnu = new FormSnuAuto();
        public AutoForm()
        {
            InitializeComponent();
            Forvirovanie.Child = Form;
            AutoOneSnu.Child = AutoSnu;
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
    }
}
