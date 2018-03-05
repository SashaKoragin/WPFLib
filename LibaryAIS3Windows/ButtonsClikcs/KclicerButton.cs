using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoIt;

namespace LibaryAIS3Windows.ButtonsClikcs
{
   public class KclicerButton
   {
        /// <summary>
        /// Константа название ветки которую обрабатываем
        /// </summary>
       private const string ModeBranch = @"Ветка Налоговое администрирование\Физические лица\1.06. Формирование и печать CНУ\1. Создание заявки на формирование СНУ для единичной печати";

       /// <summary>
       /// Созданный блок для автоматизации Создание заявки на формирование СНУ ФЛ
       /// Ветка Налоговое администрирование\Физические лица\1.06. Формирование и печать CНУ\1. Создание заявки на формирование СНУ для единичной печати
       /// </summary>
        public void Click1(string pathjurnalerror,string pathjurnalok,string inn)
       {
           while (true)
           {
            AutoItX.MouseClick(ButtonConstant.MouseLeft, Window.Windows.WindowsAis.X + Window.Windows.WinRequest.X + 180, Window.Windows.WindowsAis.Y + Window.Windows.WinRequest.Y + 120, 1);
            AutoItX.WinWait(Window.Windows.Text, Window.Windows.WinWait, 3);
            if (AutoItX.WinExists(Window.Windows.Text, Window.Windows.WinWait) == 1)
                 {
                    break;
                 }           
           }
           AutoItX.Sleep(1000);
           AutoItX.WinActivate(Window.Windows.Text, Window.Windows.WinWait);
           AutoItX.ClipPut(inn);
           AutoItX.Send(ButtonConstant.Down2);
           AutoItX.Send(ButtonConstant.Right5);
           AutoItX.Send(ButtonConstant.Enter);
           AutoItX.Send(ButtonConstant.CtrlV);
           AutoItX.ControlClick(Window.Windows.Text, Mode.SnuForm.ButUpdate[0], Mode.SnuForm.ButUpdate[1],ButtonConstant.MouseLeft, 1);
           AutoItX.Sleep(3000);
           while (true)
           {
               if (AutoItX.WinExists(Window.Windows.Text, Window.Windows.DataNotFound) == 1)
               {
                   AutoItX.ControlClick(Window.Windows.Text, Mode.SnuForm.ButCancel[0], Mode.SnuForm.ButCancel[1],ButtonConstant.MouseLeft, 1);
                   LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror,inn, ModeBranch, Window.Windows.DataNotFound);
                   break;
               }
               if (AutoItX.WinExists(Window.Windows.Text, Window.Windows.UpdateDataSource) == 1)
               {
                   AutoItX.Send(ButtonConstant.CtrlA);
                   AutoItX.ControlClick(Window.Windows.Text, Mode.SnuForm.ButNext[0], Mode.SnuForm.ButNext[1],ButtonConstant.MouseLeft, 1);
                   AutoItX.WinActivate(Window.Windows.AisNalog3, Window.Windows.Text);
                   AutoItX.ControlClick(Window.Windows.AisNalog3, Mode.SnuForm.ButCreateZ[0], Mode.SnuForm.ButCreateZ[1],ButtonConstant.MouseLeft, 1);
                   AutoItX.WinWait(Window.Windows.DialogWin);
                   AutoItX.WinActivate(Window.Windows.DialogWin);
                   AutoItX.Send(ButtonConstant.Enter);
                   LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathjurnalok,inn,"Отработали");
                   break;
               }
           }
       }
   }
}
