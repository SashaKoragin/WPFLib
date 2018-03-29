using AutoIt;

namespace LibaryAIS3Windows.ButtonsClikcs
{
   public class KclicerButton
   {
        /// <summary>
        /// Константа название ветки которую обрабатываем Основная
        /// </summary>
        private const string ModeBranch = @"Ветка Налоговое администрирование\Физические лица\1.06. Формирование и печать CНУ\1. Создание заявки на формирование СНУ для единичной печати";

        /// <summary>
        /// Ветка которую обрабатываем Пользовательзкое задание
        /// </summary>
        private const string ModeBranchUser = @"Физические лица/1.08. Сообщение ФЛ об объектах собственности\Уточнение сведений о ФЛ";

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
           AutoItX.ControlClick(Window.Windows.Text, Mode.Okp4.SnuFormirovanie.SnuForm.ButUpdate[0], Mode.Okp4.SnuFormirovanie.SnuForm.ButUpdate[1],ButtonConstant.MouseLeft, 1);
           AutoItX.Sleep(3000);
           while (true)
           {
               if (AutoItX.WinExists(Window.Windows.Text, Window.Windows.DataNotFound) == 1)
               {
                   AutoItX.ControlClick(Window.Windows.Text, Mode.Okp4.SnuFormirovanie.SnuForm.ButCancel[0], Mode.Okp4.SnuFormirovanie.SnuForm.ButCancel[1],ButtonConstant.MouseLeft, 1);
                   LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror,inn, ModeBranch, Window.Windows.DataNotFound);
                   break;
               }
               if (AutoItX.WinExists(Window.Windows.Text, Window.Windows.UpdateDataSource) == 1)
               {
                   AutoItX.Send(ButtonConstant.CtrlA);
                   AutoItX.ControlClick(Window.Windows.Text, Mode.Okp4.SnuFormirovanie.SnuForm.ButNext[0], Mode.Okp4.SnuFormirovanie.SnuForm.ButNext[1],ButtonConstant.MouseLeft, 1);
                   AutoItX.WinActivate(Window.Windows.AisNalog3, Window.Windows.Text);
                   AutoItX.ControlClick(Window.Windows.AisNalog3, Mode.Okp4.SnuFormirovanie.SnuForm.ButCreateZ[0], Mode.Okp4.SnuFormirovanie.SnuForm.ButCreateZ[1],ButtonConstant.MouseLeft, 1);
                   AutoItX.WinWait(Window.Windows.DialogWin);
                   AutoItX.WinActivate(Window.Windows.DialogWin);
                   AutoItX.Send(ButtonConstant.Enter);
                   LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathjurnalok,inn,"Отработали");
                   break;
               }
           }
       }
        /// <summary>
        /// Созданный блок для автоматизации Уточнение сведений о ФЛ Отдел регистрации
        /// Пользовательские задания
        /// Ветка Физические лица/1.08. Сообщение ФЛ об объектах собственности\Уточнение сведений о ФЛ
        /// </summary>
        public void Click2(string pathjurnalerror, string pathjurnalok)
       {
            while (true)
            {
                AutoItX.MouseClick(ButtonConstant.MouseLeft, Window.Windows.WindowsAis.X + Window.Windows.WinRequest.X + 355, Window.Windows.WindowsAis.Y + Window.Windows.WinRequest.Y + 80, 1);
                AutoItX.WinWait(Window.Windows.Text, Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.TextFid, 10);
                if (AutoItX.WinExists(Window.Windows.Text, Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.TextFid) == 1)
                {
                    break;
                }
            }
            var fid = ReadWindow.Read.Reades.ReadForm(Mode.Reg.Yvedomlenie.Yvedomlenia.FidText);
            while (true)
            {
                AutoItX.ControlClick(Window.Windows.Text, Mode.Reg.Yvedomlenie.Yvedomlenia.Visual[0], Mode.Reg.Yvedomlenie.Yvedomlenia.Visual[1], ButtonConstant.MouseLeft, 1);
                AutoItX.WinWait(Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.VisualVindow, Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.UpdateText, 10);
                if (AutoItX.WinExists(Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.VisualVindow, Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.UpdateText) == 1)
                {
                    break;
                }
            }
            AutoItX.Sleep(1000);
            ClikcCheker.Cheker.Chekerfid();
            AutoItX.ControlClick(Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.VisualVindow, Mode.Reg.Yvedomlenie.Yvedomlenia.Update[0], Mode.Reg.Yvedomlenie.Yvedomlenia.Update[1], ButtonConstant.MouseLeft, 1);
            while (true)
            {
                if (AutoItX.WinExists(Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.VisualVindow, Window.Windows.DataNotFound) == 1)
                {
                      AutoItX.ControlClick(Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.VisualVindow, Mode.Reg.Yvedomlenie.Yvedomlenia.Select[0], Mode.Reg.Yvedomlenie.Yvedomlenia.Select[1], ButtonConstant.MouseLeft, 1);
                      LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, fid, ModeBranchUser, Window.Windows.DataNotFound);
                      AutoItX.ControlClick(Window.Windows.Text, Mode.Reg.Yvedomlenie.Yvedomlenia.Close[0], Mode.Reg.Yvedomlenie.Yvedomlenia.Close[1], ButtonConstant.MouseLeft, 1);
                      break;
                }
                if (AutoItX.WinExists(Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.VisualVindow, Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.TextFidUser) == 1)
                {
                    AutoItX.ControlClick(Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.VisualVindow, Mode.Reg.Yvedomlenie.Yvedomlenia.Select[0], Mode.Reg.Yvedomlenie.Yvedomlenia.Select[1], ButtonConstant.MouseLeft, 1);
                    AutoItX.MouseWheel(ButtonConstant.Wheel,1);
                    AutoItX.ControlClick(Window.Windows.Text, Mode.Reg.Yvedomlenie.Yvedomlenia.ComboboxSelect[0], Mode.Reg.Yvedomlenie.Yvedomlenia.ComboboxSelect[1], ButtonConstant.MouseLeft, 1);
                    AutoItX.Send(ButtonConstant.Down2);
                    AutoItX.Send(ButtonConstant.Enter);
                    AutoItX.ControlClick(Window.Windows.Text, Mode.Reg.Yvedomlenie.Yvedomlenia.Close[0], Mode.Reg.Yvedomlenie.Yvedomlenia.Close[1], ButtonConstant.MouseLeft, 1);
                    LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathjurnalok, fid, "Отработали");
                    break;
                }
            }
        }
   }
}
