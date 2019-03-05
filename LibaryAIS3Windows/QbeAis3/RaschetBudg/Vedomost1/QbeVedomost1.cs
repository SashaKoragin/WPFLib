using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoIt;
using LibaryAIS3Windows.ButtonsClikcs;
using LibaryAIS3Windows.Window;

namespace LibaryAIS3Windows.QbeAis3.RaschetBudg.Vedomost1
{
   public class QbeVedomost1
    {
        /// <summary>
        /// Подстановка в выборку 
        /// </summary>
        /// <param name="date">Дата зачисления на счет</param>
        /// <param name="summ">Сумма платежа</param>
        /// <param name="statusPl">Статус не выясненого платежа</param>
        /// <param name="kbk">КБК</param>
        /// <param name="kbkRaspr">КБК Распределения</param>
        public void UseQbeVedomost1(DateTime date,int summ, string statusPl,string kbk, string kbkRaspr)
        {
            ReadWindow.Read.Reades.ClearBuffer();
            WindowsAis3 win = new WindowsAis3();
            MouseClick(win);
            AutoItX.ClipPut(date.ToString(CultureInfo.InvariantCulture));
            AutoItX.Send(ButtonConstant.Right5);
            AutoItX.Send(ButtonConstant.Enter);
            AutoItX.Send(ButtonConstant.CtrlV);
            AutoItX.Send(ButtonConstant.Enter);
            MouseClick(win);
            ReadWindow.Read.Reades.ClearBuffer();
            AutoItX.ClipPut(summ.ToString());
            AutoItX.Send(ButtonConstant.Down6);
            AutoItX.Send(ButtonConstant.Right5);
            AutoItX.Send(ButtonConstant.Enter);
            AutoItX.Send(ButtonConstant.CtrlV);
            AutoItX.Send(ButtonConstant.Enter);
            MouseClick(win);
            ReadWindow.Read.Reades.ClearBuffer();
            AutoItX.ClipPut(statusPl);
            AutoItX.Send(ButtonConstant.Down11);
            AutoItX.Send(ButtonConstant.Right5);
            AutoItX.Send(ButtonConstant.Enter);
            AutoItX.Send(ButtonConstant.CtrlV);
            AutoItX.Send(ButtonConstant.Enter);
            MouseClick(win);
            ReadWindow.Read.Reades.ClearBuffer();
            AutoItX.ClipPut(kbk);
            AutoItX.Send(ButtonConstant.Down18);
            AutoItX.Send(ButtonConstant.Right5);
            AutoItX.Send(ButtonConstant.Enter);
            AutoItX.Send(ButtonConstant.CtrlV);
            AutoItX.Send(ButtonConstant.Enter);
            MouseClick(win);
            ReadWindow.Read.Reades.ClearBuffer();
            AutoItX.ClipPut(kbkRaspr);
            AutoItX.Send(ButtonConstant.Down20);
            AutoItX.Send(ButtonConstant.Right5);
            AutoItX.Send(ButtonConstant.Enter);
            AutoItX.Send(ButtonConstant.CtrlV);
            AutoItX.Send(ButtonConstant.Enter);
        }

        public void MouseClick(WindowsAis3 win)
        {
            win.ControlGetPos1(WindowsAis3.ConditionsVed1[0], WindowsAis3.ConditionsVed1[1], WindowsAis3.ConditionsVed1[2]);
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 60, win.WindowsAis.Y + win.Y1 + 30);
        }
    }
}
