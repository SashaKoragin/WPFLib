using AutoIt;
using LibaryAIS3Windows.Mode.Reg.ZemlyFpd;
using LibaryAIS3Windows.Window.Otdel.Reg.Fpd;

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

       private const string ModeBranchUserRegZemla = @"Налоговое администрирование\Собственность\05. Взаимодействие с органами Росреестра – Земельные участки\03. Обработка ФПД  от РР - ФЛ - Анализ результатов обработки документов";

        /// <summary>
        /// Созданный блок для автоматизации Создание заявки на формирование СНУ ФЛ
        /// Ветка Налоговое администрирование\Физические лица\1.06. Формирование и печать CНУ\1. Создание заявки на формирование СНУ для единичной печати
        /// </summary>
        public void Click1(string pathjurnalerror,string pathjurnalok,string inn)
       {
           while (true)
           {
            AutoItX.MouseClick(ButtonConstant.MouseLeft, Window.WindowsAis3.WindowsAis.X + Window.WindowsAis3.WinRequest.X + 180, Window.WindowsAis3.WindowsAis.Y + Window.WindowsAis3.WinRequest.Y + 120, 1);
            AutoItX.WinWait(Window.WindowsAis3.Text, Window.WindowsAis3.WinWait, 3);
            if (AutoItX.WinExists(Window.WindowsAis3.Text, Window.WindowsAis3.WinWait) == 1)
                 {
                    break;
                 }           
           }
           AutoItX.Sleep(1000);
           AutoItX.WinActivate(Window.WindowsAis3.Text, Window.WindowsAis3.WinWait);
           AutoItX.ClipPut(inn);
           AutoItX.Send(ButtonConstant.Down2);
           AutoItX.Send(ButtonConstant.Right5);
           AutoItX.Send(ButtonConstant.Enter);
           AutoItX.Send(ButtonConstant.CtrlV);
           AutoItX.ControlClick(Window.WindowsAis3.Text, Mode.Okp4.SnuFormirovanie.SnuForm.ButUpdate[0], Mode.Okp4.SnuFormirovanie.SnuForm.ButUpdate[1],ButtonConstant.MouseLeft, 1);
           AutoItX.Sleep(3000);
           while (true)
           {
               if (AutoItX.WinExists(Window.WindowsAis3.Text, Window.WindowsAis3.DataNotFound) == 1)
               {
                   AutoItX.ControlClick(Window.WindowsAis3.Text, Mode.Okp4.SnuFormirovanie.SnuForm.ButCancel[0], Mode.Okp4.SnuFormirovanie.SnuForm.ButCancel[1],ButtonConstant.MouseLeft, 1);
                   LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror,inn, ModeBranch, Window.WindowsAis3.DataNotFound);
                   break;
               }
               if (AutoItX.WinExists(Window.WindowsAis3.Text, Window.WindowsAis3.UpdateDataSource) == 1)
               {
                   AutoItX.Send(ButtonConstant.CtrlA);
                   AutoItX.ControlClick(Window.WindowsAis3.Text, Mode.Okp4.SnuFormirovanie.SnuForm.ButNext[0], Mode.Okp4.SnuFormirovanie.SnuForm.ButNext[1],ButtonConstant.MouseLeft, 1);
                   AutoItX.WinActivate(Window.WindowsAis3.AisNalog3, Window.WindowsAis3.Text);
                   AutoItX.ControlClick(Window.WindowsAis3.AisNalog3, Mode.Okp4.SnuFormirovanie.SnuForm.ButCreateZ[0], Mode.Okp4.SnuFormirovanie.SnuForm.ButCreateZ[1],ButtonConstant.MouseLeft, 1);
                   AutoItX.WinWait(Window.WindowsAis3.DialogWin);
                   AutoItX.WinActivate(Window.WindowsAis3.DialogWin);
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
                AutoItX.MouseClick(ButtonConstant.MouseLeft, Window.WindowsAis3.WindowsAis.X + Window.WindowsAis3.WinRequest.X + 355, Window.WindowsAis3.WindowsAis.Y + Window.WindowsAis3.WinRequest.Y + 80, 1);
                AutoItX.WinWait(Window.WindowsAis3.Text, Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.TextFid, 10);
                if (AutoItX.WinExists(Window.WindowsAis3.Text, Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.TextFid) == 1)
                {
                    break;
                }
            }
            var fid = ReadWindow.Read.Reades.ReadForm(Mode.Reg.Yvedomlenie.Yvedomlenia.FidText);
            while (true)
            {
                AutoItX.ControlClick(Window.WindowsAis3.Text, Mode.Reg.Yvedomlenie.Yvedomlenia.Visual[0], Mode.Reg.Yvedomlenie.Yvedomlenia.Visual[1], ButtonConstant.MouseLeft, 1);
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
                if (AutoItX.WinExists(Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.VisualVindow, Window.WindowsAis3.DataNotFound) == 1)
                {
                      AutoItX.ControlClick(Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.VisualVindow, Mode.Reg.Yvedomlenie.Yvedomlenia.Select[0], Mode.Reg.Yvedomlenie.Yvedomlenia.Select[1], ButtonConstant.MouseLeft, 1);
                      LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, fid, ModeBranchUser, Window.WindowsAis3.DataNotFound);
                      AutoItX.ControlClick(Window.WindowsAis3.Text, Mode.Reg.Yvedomlenie.Yvedomlenia.Close[0], Mode.Reg.Yvedomlenie.Yvedomlenia.Close[1], ButtonConstant.MouseLeft, 1);
                      break;
                }
                if (AutoItX.WinExists(Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.VisualVindow, Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.TextFidUser) == 1)
                {
                    AutoItX.ControlClick(Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.VisualVindow, Mode.Reg.Yvedomlenie.Yvedomlenia.Select[0], Mode.Reg.Yvedomlenie.Yvedomlenia.Select[1], ButtonConstant.MouseLeft, 1);
                    AutoItX.MouseWheel(ButtonConstant.Wheel,1);
                    AutoItX.ControlClick(Window.WindowsAis3.Text, Mode.Reg.Yvedomlenie.Yvedomlenia.ComboboxSelect[0], Mode.Reg.Yvedomlenie.Yvedomlenia.ComboboxSelect[1], ButtonConstant.MouseLeft, 1);
                    AutoItX.Send(ButtonConstant.Down2);
                    AutoItX.Send(ButtonConstant.Enter);
                    AutoItX.ControlClick(Window.WindowsAis3.Text, Mode.Reg.Yvedomlenie.Yvedomlenia.Close[0], Mode.Reg.Yvedomlenie.Yvedomlenia.Close[1], ButtonConstant.MouseLeft, 1);
                    LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathjurnalok, fid, "Отработали");
                    break;
                }
            }
        }
        /// <summary>
        /// Созданный блок для автоматизации Уточнение сведений о ФЛ Отдел регистрации
        /// Налоговое администрирование\Собственность\05. Взаимодействие с органами Росреестра – Земельные участки\03. Обработка ФПД  от РР - ФЛ - Анализ результатов обработки документов
        /// </summary>
        /// <param name="pathjurnalerror">Журнал ошибок</param>
        /// <param name="pathjurnalok">Журнал сделаных</param>
        /// <param name="fpd">ФПД значение</param>
        public void Click3(string fpd, string pathjurnalerror, string pathjurnalok, bool isCheked)
        {
            string copyfio = null;
            AutoItX.MouseClick(ButtonConstant.MouseLeft, Window.WindowsAis3.WindowsAis.X + Window.WindowsAis3.WinGrid.X + 70, Window.WindowsAis3.WindowsAis.Y + Window.WindowsAis3.WinGrid.Y + 35, 1);
            AutoItX.ClipPut(fpd);
            AutoItX.Send(ButtonConstant.Down9);
            AutoItX.Send(ButtonConstant.Right5);
            AutoItX.Send(ButtonConstant.Enter);
            AutoItX.Send(ButtonConstant.CtrlV);
            AutoItX.Send(ButtonConstant.F5);
            while (true)
            {
                if (AutoItX.WinExists(Window.WindowsAis3.Text, Window.WindowsAis3.DataNotFound) == 1)
                {
                    AutoItX.Send(ButtonConstant.F3);
                    LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, fpd, ModeBranchUserRegZemla, Window.WindowsAis3.DataNotFound);
                    break;
                }
                if (AutoItX.WinExists(Window.WindowsAis3.Text, Window.Otdel.Reg.Fpd.FpdText.TextFidUser) == 1)
                {
                    while (true)
                    {
                        string fio = ReadWindow.Read.Reades.ReadForm(Mode.Reg.ZemlyFpd.Zemly.FioUser);
                        string id = ReadWindow.Read.Reades.ReadForm(Mode.Reg.ZemlyFpd.Zemly.FidText);
                        if (fio.Equals(copyfio))
                        {
                            AutoItX.WinActivate(Window.WindowsAis3.AisNalog3, Window.WindowsAis3.Text);
                            AutoItX.Send(ButtonConstant.F3);
                            break;
                        }
                        if (id.Equals(FpdText.TextUslovie))
                        {
                            while (true)
                            {
                                AutoItX.MouseClick(ButtonConstant.MouseLeft, Window.WindowsAis3.WindowsAis.X + 330, Window.WindowsAis3.WindowsAis.Y + 90);
                                AutoItX.Send(ButtonConstant.Down1);
                                AutoItX.Send(ButtonConstant.Enter);
                                AutoItX.WinWait(Window.WindowsAis3.Text, FpdText.TextCun, 5);
                                if (AutoItX.WinExists(Window.WindowsAis3.Text, FpdText.TextCun) == 1)
                                {
                                    AutoItX.ControlClick(Window.WindowsAis3.Text, Mode.Reg.ZemlyFpd.Zemly.SpisokCun[0], Mode.Reg.ZemlyFpd.Zemly.SpisokCun[1], ButtonConstant.MouseLeft);
                                    AutoItX.Send(ButtonConstant.Enter);
                                    AutoItX.Sleep(1000);
                                    FpdText fpdtext = new FpdText();
                                    AutoItX.MouseClick(ButtonConstant.MouseLeft, Window.WindowsAis3.WindowsAis.X + fpdtext.WinVisualPageControl.X + 600, Window.WindowsAis3.WindowsAis.Y + fpdtext.WinVisualPageControl.Y + 110);
                                    AutoItX.MouseClick(ButtonConstant.MouseLeft, Window.WindowsAis3.WindowsAis.X + fpdtext.WinVisualPageControl.X + 40, Window.WindowsAis3.WindowsAis.Y + fpdtext.WinVisualPageControl.Y + 90);
                                    AutoItX.Send(ButtonConstant.Down13);
                                    AutoItX.Send(ButtonConstant.Right5);
                                    AutoItX.Send(ButtonConstant.Enter);
                                    AutoItX.Send(ButtonConstant.Delete);
                                    AutoItX.Send(ButtonConstant.Enter);
                                    AutoItX.Send(ButtonConstant.Down1);
                                    AutoItX.Send(ButtonConstant.Enter);
                                    AutoItX.Send(ButtonConstant.Delete);
                                    AutoItX.Send(ButtonConstant.Enter);
                                    AutoItX.MouseClick(ButtonConstant.MouseLeft, Window.WindowsAis3.WindowsAis.X + fpdtext.WinVisualTool.X + 80, Window.WindowsAis3.WindowsAis.Y + fpdtext.WinVisualTool.Y + 10);
                                    while (true)
                                    {
                                        if (AutoItX.WinExists(Window.WindowsAis3.Text, FpdText.TextUnfl) == 1)
                                        {
                                            while (true)
                                            {
                                                FpdText fpdtextnew = new FpdText();
                                                AutoItX.MouseClick(ButtonConstant.MouseLeft, Window.WindowsAis3.WindowsAis.X + fpdtextnew.WinVisualTool.X + 150, Window.WindowsAis3.WindowsAis.Y + fpdtextnew.WinVisualTool.Y + 10);
                                                AutoItX.WinWait(FpdText.TextVnimanie, FpdText.TextOk, 5);
                                                if (AutoItX.WinExists(FpdText.TextVnimanie, FpdText.TextOk) == 1)
                                                {
                                                    AutoItX.WinActivate(FpdText.TextVnimanie, FpdText.TextOk);
                                                    AutoItX.Send(ButtonConstant.Enter);
                                                    LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathjurnalok, fpd, "Отработали");
                                                    AutoItX.MouseClick(ButtonConstant.MouseLeft, fpdtext.WinCoordinat.X + fpdtext.WinCoordinat.Width - 15, fpdtext.WinCoordinat.Y + 160);
                                                    break;
                                                }
                                            }

                                            break;
                                        }
                                        if (AutoItX.WinExists(Window.WindowsAis3.Text, Window.WindowsAis3.DataNotFound) == 1)
                                        {
                                            LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, fpd +"/"+ fio, "Витрина ЦУН при выборе плательщика", Window.WindowsAis3.DataNotFound);
                                            AutoItX.MouseClick(ButtonConstant.MouseLeft, fpdtext.WinCoordinat.X + fpdtext.WinCoordinat.Width - 15, fpdtext.WinCoordinat.Y + 160);
                                            break;
                                        }
                                    }
                                    break;
                                }
                                if (AutoItX.WinExists(FpdText.TextVnimanie, FpdText.TextIdent) == 1)
                                {
                                    AutoItX.WinActivate(FpdText.TextVnimanie, FpdText.TextIdent);
                                    AutoItX.Send(ButtonConstant.Enter);
                                    LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, fpd + "/" + fio, ModeBranchUserRegZemla, FpdText.TextIdent);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, fpd+"/"+fio, ModeBranchUserRegZemla, id);
                        }
                        AutoItX.Sleep(1000);
                        AutoItX.ControlFocus(Window.WindowsAis3.AisNalog3, Window.WindowsAis3.Text,Window.WindowsAis3.GridWinAis3);
                        AutoItX.Send(ButtonConstant.Tab);
                        copyfio = fio;
                        fio = null;
                        id = null;
                    }
                    break;
                }
            }
        }
    }
}
