using System;
using System.Windows.Forms;
using TestAutoit.Start;
namespace TestAutoit.Form
{
    public partial class AutoForm : System.Windows.Forms.Form
    {
        public AutoForm()
        {
            InitializeComponent();
            Forvirovanie.Child = new FormSpisok.WpfForm.FormSpisok();
            registrationHost.Child = new Automat.Reg.WpfPage.YtochnenieSved();
            AutoOneSnu.Child = new TestAutoit.Form.Automat.Okp4.WpfPage.FormSnuAuto();
            Report.Child = new Report.Form.Report();

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
