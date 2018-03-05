using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoIt;
using TestAutoit.Form;
using TestAutoit.Start;

namespace TestAutoit.ButtonsClikcs
{
   public class ButtonsCliks
   {
        public AutoForm Formr;

        public ButtonsCliks(AutoForm form)
        {
            Formr = form;

        }

        public static void ButtonFormZayv(string inn)
        {
            AutoItX.ClipPut(inn);
            AutoItX.Send("{Down 2}");
            AutoItX.Send("{right 5}");
            AutoItX.Send("{Enter}");
            AutoItX.Send("^v");
            AutoItX.ControlClick("", "Обновить", "[NAME:button1]", "Left");
            AutoItX.Sleep(5000);
            AutoItX.Send("^A");
            AutoItX.ControlClick("", "Далее", "[NAME:btnOk]", "Left");
        }

        public void ButtonPrint(string inn,string date)
        {
            
            if (Formr.checkBox1.Checked)
            {
               AutoItX.ClipPut(date);
               AutoItX.MouseClick("Left", SysForm.Status.WindowsAis.X + SysForm.Status.WinGrid.X + 30, SysForm.Status.WindowsAis.Y + SysForm.Status.WinGrid.Y + 30);
               AutoItX.Send("{Down 10}");
               AutoItX.Send("{right 5}");
               AutoItX.Send("{Enter}");
               AutoItX.Send("^v");
               AutoItX.Send("{Enter}");
               AutoItX.Send("{left 1}");
               AutoItX.Send("{Enter}");
               AutoItX.Send("{Down 3}");
               AutoItX.Send("{Enter}");
               Formr.checkBox1.BeginInvoke(new MethodInvoker(delegate { Formr.checkBox1.Checked = false; }));
            }
            AutoItX.ClipPut(inn);
            AutoItX.MouseClick("Left", SysForm.Status.WindowsAis.X + SysForm.Status.WinGrid.X + 30, SysForm.Status.WindowsAis.Y + SysForm.Status.WinGrid.Y + 30);
            AutoItX.Send("{Down 20}");
            AutoItX.Send("{right 5}");
            AutoItX.Send("{Enter}");
            AutoItX.Send("^v");
            AutoItX.Send("{Enter}");
            AutoItX.Send("{F5}");

        }
    }
}
