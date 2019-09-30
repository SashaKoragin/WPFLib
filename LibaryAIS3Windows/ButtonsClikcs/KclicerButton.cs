using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Windows.Automation;
using SqlLibaryIfns.AutoItSelect.Sql;
using LibaryAIS3Windows.Window.Otdel.Analitic.TeskText;
using AutoIt;
using LibaryAIS3Windows.AutomationsUI.LibaryAutomations;
using LibaryAIS3Windows.ExitLogica.ExitTaskFull;
using LibaryAIS3Windows.Function.PublicFunc;
using LibaryAIS3Windows.Mode.Okp4.PravoZorI;
using LibaryAIS3Windows.Mode.Okp4.SnuFormirovanie;
using LibaryAIS3Windows.Mode.RaschetBudg.Migration;
using LibaryAIS3Windows.Mode.Reg.StatusReg;
using LibaryAIS3Windows.RegxFull.RaschetBudg;
using LibaryAIS3Windows.Window;
using LibaryAIS3Windows.Window.Otdel.It.RuleParse;
using LibaryAIS3Windows.Window.Otdel.Okp3.Usn;
using LibaryAIS3Windows.Window.Otdel.Okp4.PravoZorI;
using LibaryAIS3Windows.Window.Otdel.Okp4.Print;
using LibaryAIS3Windows.Window.Otdel.Okp4.Snu;
using LibaryAIS3Windows.Window.Otdel.Orn.Nbo;
using LibaryAIS3Windows.Window.Otdel.RaschetBudg.Migration;
using LibaryAIS3Windows.Window.Otdel.RaschetBudg.Vedomost1;
using LibaryAIS3Windows.Window.Otdel.Reg.ActualStatus;
using LibaryAIS3Windows.Window.Otdel.Reg.Fpd;
using LibaryAIS3Windows.Window.Otdel.Reg.IdFace;
using LibaryAIS3Windows.Window.Otdel.Uregulirovanie.UtverzdenieSz;
using LibaryXMLAutoModelXmlAuto.MigrationReport;


namespace LibaryAIS3Windows.ButtonsClikcs
{
    public class KclicerButton
    {
        private const string ModeBranchVedomost1 = @"Налоговое администрирование\Расчеты с бюджетом\Ведомость невыясненных поступлений\Ведомость невыясненных поступлений. Раздел 1";

        /// <summary>
        /// Константа название ветки которую обрабатываем Основная
        /// </summary>
        private const string ModeBranch = @"Ветка Налоговое администрирование\Физические лица\1.06. Формирование и печать CНУ\1. Создание заявки на формирование СНУ для единичной печати";

        /// <summary>
        /// Ветка которую обрабатываем Пользовательзкое задание
        /// </summary>
        private const string ModeBranchUser = @"Физические лица/1.08. Сообщение ФЛ об объектах собственности\Уточнение сведений о ФЛ";

        /// <summary>
        /// Корректировка сведений о правах
        /// </summary>
        private const string Okp4Pravo = @"Налоговое администрирование\Собственность\02. Доопределение данных об объектах собственности\14. КС – Корректировка сведений о правах не зарегистрированных  в органах Росреестра и правах наследования на ОН и ЗУ";

        private const string ModeBranchUserRegZemla = @"Налоговое администрирование\Собственность\05. Взаимодействие с органами Росреестра – Земельные участки\03. Обработка ФПД  от РР - ФЛ - Анализ результатов обработки документов";

        /// <summary>
        /// Создание заявки на формирования СНУ
        /// </summary>
        private const string SnuZayvki = @"Налоговое администрирование\Физические лица\1.06. Формирование и печать CНУ\1. Создание заявки на формирование СНУ для единичной печати";

        /// <summary>
        /// Печать уведомлений
        /// </summary>
        private const string PrintBranch = @"Налоговое администрирование\Физические лица\1.06. Формирование и печать CНУ\2. Просмотр СНУ";

        /// <summary>
        /// Актуальный статус
        /// </summary>
        private const string ActualStatus = @"Налоговое администрирование\ПОН ИЛ\1. ПОН ИЛ (ПЭ). Организации и физические лица, внесенные в ПОН ИЛ\2.01. ФЛ. Актуальное состояние";

        /// <summary>
        /// Техническое исправление
        /// </summary>
        private const string TechnicalUpdate = @"Налоговое администрирование\Централизованный учет налогоплательщиков\15.02.02. Служебные. Технические исправления\ Физические лица\15.02.02.01. Служебные. Технические исправления. Физические лица";

        /// <summary>
        /// Росреестр Визуальная идентификация
        /// </summary>
        private const string FaceRosreestr = @"Налоговое администрирование\Собственность\14. Работа с лицами – правообладателями объектов, по которым требуется визуальная обработка";

        private const string Usn = @"Общие задания\Контрольная работа налоговые проверки\Применение упрощенной системы налогооблажения\Применение УСН";

        /// <summary>
        /// Созданный блок для автоматизации Создание заявки на формирование СНУ ФЛ
        /// Ветка Налоговое администрирование\Физические лица\1.06. Формирование и печать CНУ\1. Создание заявки на формирование СНУ для единичной печати
        /// </summary>
        public void Click1(string pathjurnalerror, string pathjurnalok, string inn)
        {
            while (true)
            {
                WindowsAis3 win = new WindowsAis3();
                win.ControlGetPos1(WindowsAis3.WinRequest[0], WindowsAis3.WinRequest[1], WindowsAis3.WinRequest[2]);
                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 180, win.WindowsAis.Y + win.Y1 + 120);
                AutoItX.WinWait(WindowsAis3.Text, WindowsAis3.WinWait, 3);
                if (AutoItX.WinExists(WindowsAis3.Text, WindowsAis3.WinWait) == 1)
                {
                    break;
                }
            }
            AutoItX.Sleep(1000);
            AutoItX.WinActivate(WindowsAis3.Text, WindowsAis3.WinWait);
            AutoItX.ClipPut(inn);
            AutoItX.Send(ButtonConstant.Down2);
            AutoItX.Send(ButtonConstant.Right5);
            AutoItX.Send(ButtonConstant.Enter);
            AutoItX.Send(ButtonConstant.CtrlV);
            AutoItX.ControlClick(WindowsAis3.Text, SnuForm.ButUpdate[0], SnuForm.ButUpdate[1], ButtonConstant.MouseLeft);
            AutoItX.Sleep(3000);
            while (true)
            {
                if (AutoItX.WinExists(WindowsAis3.Text, WindowsAis3.DataNotFound) == 1)
                {
                    AutoItX.ControlClick(WindowsAis3.Text, SnuForm.ButCancel[0], SnuForm.ButCancel[1], ButtonConstant.MouseLeft);
                    LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, inn, ModeBranch, WindowsAis3.DataNotFound);
                    break;
                }
                if (AutoItX.WinExists(WindowsAis3.Text, WindowsAis3.UpdateDataSource) == 1)
                {
                    AutoItX.Send(ButtonConstant.CtrlA);
                    AutoItX.ControlClick(WindowsAis3.Text, SnuForm.ButNext[0], SnuForm.ButNext[1], ButtonConstant.MouseLeft);
                    AutoItX.WinActivate(WindowsAis3.AisNalog3, WindowsAis3.Text);
                    AutoItX.ControlClick(WindowsAis3.AisNalog3, SnuForm.ButCreateZ[0], SnuForm.ButCreateZ[1], ButtonConstant.MouseLeft);
                    AutoItX.WinWait(SnuText.DialogWin);
                    AutoItX.WinActivate(SnuText.DialogWin);
                    AutoItX.Send(ButtonConstant.Enter);
                    LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathjurnalok, inn, "Отработали");
                    break;
                }
            }
        }

        /// <summary>
        /// Созданный блок для автоматизации Уточнение сведений о ФЛ Отдел регистрации
        /// Пользовательские задания
        /// Ветка Физические лица/1.08. Сообщение ФЛ об объектах собственности\Уточнение сведений о ФЛ
        /// </summary>
        /// <param name="pathjurnalerror">Путь к журналу с ошибками</param>
        /// <param name="pathjurnalok">Путь к отработаным записям</param>
        /// <param name="usefilter">Переключатель если ложь делаем как обычно если правда то на вторую строку</param>
        public void Click2(string pathjurnalerror, string pathjurnalok, bool usefilter)
        {
            try
            {
                while (true)
                {
                    WindowsAis3 win = new WindowsAis3();
                    if (usefilter)
                    {
                        win.ControlGetPos1(WindowsAis3.GridMain[0], WindowsAis3.GridMain[1], WindowsAis3.GridMain[2]);
                        AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 7, win.WindowsAis.Y + win.Y1 + 55, 2);
                        AutoItX.WinWait(WindowsAis3.Text, Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.TextFid, 30);
                    }
                    else
                    {
                        win.ControlGetPos1(WindowsAis3.WinRequest[0], WindowsAis3.WinRequest[1], WindowsAis3.WinRequest[2]);
                        AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 355, win.WindowsAis.Y + win.Y1 + 80);
                        AutoItX.WinWait(WindowsAis3.Text, Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.TextFid, 30);
                    }
                    if (AutoItX.WinExists(WindowsAis3.Text, Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.TextFid) == 1)
                    {
                        break;
                    }
                }
                var fid = ReadWindow.Read.Reades.ReadForm(Mode.Reg.Yvedomlenie.Yvedomlenia.FidText);
                while (true)
                {
                    AutoItX.ControlClick(WindowsAis3.Text, Mode.Reg.Yvedomlenie.Yvedomlenia.Visual[0], Mode.Reg.Yvedomlenie.Yvedomlenia.Visual[1], ButtonConstant.MouseLeft);
                    AutoItX.WinWait(Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.VisualVindow, Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.UpdateText, 10);
                    if (
                        AutoItX.WinExists(Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.VisualVindow, Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.UpdateText) == 1)
                    {
                        break;
                    }
                }
                AutoItX.Sleep(2000);
                ClikcCheker.Cheker.Chekerfid();
                AutoItX.ControlClick(Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.VisualVindow, Mode.Reg.Yvedomlenie.Yvedomlenia.Update[0], Mode.Reg.Yvedomlenie.Yvedomlenia.Update[1], ButtonConstant.MouseLeft);
                while (true)
                {
                    if (
                        AutoItX.WinExists(Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.VisualVindow, WindowsAis3.DataNotFound) == 1)
                    {
                        AutoItX.ControlClick(Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.VisualVindow,Mode.Reg.Yvedomlenie.Yvedomlenia.Select[0], Mode.Reg.Yvedomlenie.Yvedomlenia.Select[1], ButtonConstant.MouseLeft);
                        LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, fid, ModeBranchUser,  WindowsAis3.DataNotFound);
                        AutoItX.ControlClick(WindowsAis3.Text, Mode.Reg.Yvedomlenie.Yvedomlenia.Close[0], Mode.Reg.Yvedomlenie.Yvedomlenia.Close[1], ButtonConstant.MouseLeft);
                        break;
                    }
                    if (
                        AutoItX.WinExists(Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.VisualVindow, Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.TextFidUser) == 1)
                    {
                        AutoItX.ControlClick(Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.VisualVindow, Mode.Reg.Yvedomlenie.Yvedomlenia.Select[0], Mode.Reg.Yvedomlenie.Yvedomlenia.Select[1], ButtonConstant.MouseLeft);
                        AutoItX.MouseWheel(ButtonConstant.Wheel, 2);
                        AutoItX.ControlClick(WindowsAis3.Text, Mode.Reg.Yvedomlenie.Yvedomlenia.ComboboxSelect[0], Mode.Reg.Yvedomlenie.Yvedomlenia.ComboboxSelect[1], ButtonConstant.MouseLeft);
                        AutoItX.Send(ButtonConstant.Down2);
                        AutoItX.Send(ButtonConstant.Enter);
                        AutoItX.ControlClick(WindowsAis3.Text, Mode.Reg.Yvedomlenie.Yvedomlenia.Save[0], Mode.Reg.Yvedomlenie.Yvedomlenia.Save[1], ButtonConstant.MouseLeft);
                        AutoItX.Sleep(500);
                        AutoItX.Send(ButtonConstant.Enter);
                        AutoItX.ControlClick(WindowsAis3.Text, Mode.Reg.Yvedomlenie.Yvedomlenia.Close[0], Mode.Reg.Yvedomlenie.Yvedomlenia.Close[1], ButtonConstant.MouseLeft);
                        LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathjurnalok, fid, "Отработали");
                        break;
                    }
                }

            }
            catch (Exception e)
            {
                LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, "Ошибка исключения надо смотреть!!!", ModeBranchUser, e.Message);
            }
        }

        /// <summary>
        /// Созданный блок для автоматизации Уточнение сведений о ФЛ Отдел регистрации
        /// Налоговое администрирование\Собственность\05. Взаимодействие с органами Росреестра – Земельные участки\03. Обработка ФПД  от РР - ФЛ - Анализ результатов обработки документов
        /// а так-же данная функция работает для ветки
        /// Налоговое администрирование\Собственность\06. Взаимодействие с органами Росреестра – Объекты недвижимости\03. Обработка ФПД  от РР - ФЛ - Анализ результатов обработки документов
        /// </summary>
        /// <param name="pathjurnalerror">Журнал ошибок</param>
        /// <param name="pathjurnalok">Журнал сделаных</param>
        /// <param name="fpd">ФПД значение</param>
        public void Click3(string fpd, string pathjurnalerror, string pathjurnalok)
        {
            string copyfio = null;
            WindowsAis3 win = new WindowsAis3();
            win.ControlGetPos1(WindowsAis3.WinGrid[0], WindowsAis3.WinGrid[1], WindowsAis3.WinGrid[2]);
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 70, win.WindowsAis.Y + win.Y1 + 35);
            AutoItX.ClipPut(fpd);
            AutoItX.Send(ButtonConstant.Down9);
            AutoItX.Send(ButtonConstant.Right5);
            AutoItX.Send(ButtonConstant.Enter);
            AutoItX.Send(ButtonConstant.CtrlV);
            AutoItX.Send(ButtonConstant.F5);
            while (true)
            {
                if (AutoItX.WinExists(WindowsAis3.Text, WindowsAis3.DataNotFound) == 1)
                {
                    AutoItX.Send(ButtonConstant.F3);
                    LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, fpd, ModeBranchUserRegZemla, WindowsAis3.DataNotFound);
                    break;
                }
                if (AutoItX.WinExists(WindowsAis3.Text, FpdText.TextFidUser) == 1)
                {
                    while (true)
                    {
                        string fio = ReadWindow.Read.Reades.ReadForm(Mode.Reg.ZemlyFpd.Zemly.FioUser);
                        string id = ReadWindow.Read.Reades.ReadForm(Mode.Reg.ZemlyFpd.Zemly.FidText);
                        if (fio.Equals(copyfio))
                        {
                            AutoItX.WinActivate(WindowsAis3.AisNalog3, WindowsAis3.Text);
                            AutoItX.Send(ButtonConstant.F3);
                            break;
                        }
                        if (id.Equals(FpdText.TextUslovie) || id.Equals(FpdText.Text4) || id.Equals(FpdText.Text11))
                            //Для транспорта нужно условие которое мы ищем !!!!!!!!!!!!!!!!
                        {
                            while (true)
                            {
                                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + 330, win.WindowsAis.Y + 90);
                                AutoItX.Send(ButtonConstant.Down1);
                                AutoItX.Send(ButtonConstant.Enter);
                                AutoItX.WinWait(WindowsAis3.Text, FpdText.TextCun, 5);
                                if (AutoItX.WinExists(WindowsAis3.Text, FpdText.TextCun) == 1)
                                {
                                    AutoItX.ControlClick(WindowsAis3.Text, Mode.Reg.ZemlyFpd.Zemly.SpisokCun[0], Mode.Reg.ZemlyFpd.Zemly.SpisokCun[1], ButtonConstant.MouseLeft);
                                    AutoItX.Send(ButtonConstant.Enter);
                                    AutoItX.Sleep(1000);
                                    FpdText fpdtext = new FpdText();
                                    AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + fpdtext.WinVisualPageControl.X + 675, win.WindowsAis.Y + fpdtext.WinVisualPageControl.Y + 110);
                                    AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + fpdtext.WinVisualPageControl.X + 40, win.WindowsAis.Y + fpdtext.WinVisualPageControl.Y + 90);
                                    AutoItX.Send(ButtonConstant.Down13);
                                    AutoItX.Send(ButtonConstant.Right5);
                                    AutoItX.Send(ButtonConstant.Enter);
                                    AutoItX.Send(ButtonConstant.Delete);
                                    AutoItX.Send(ButtonConstant.Enter);
                                    AutoItX.Send(ButtonConstant.Down1);
                                    AutoItX.Send(ButtonConstant.Enter);
                                    AutoItX.Send(ButtonConstant.Delete);
                                    AutoItX.Send(ButtonConstant.Enter);
                                    AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + fpdtext.WinVisualTool.X + 80, win.WindowsAis.Y + fpdtext.WinVisualTool.Y + 10);
                                    while (true)
                                    {
                                        if (AutoItX.WinExists(WindowsAis3.Text, FpdText.TextUnfl) == 1)
                                        {
                                            while (true)
                                            {
                                                FpdText fpdtextnew = new FpdText();
                                                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + fpdtextnew.WinVisualTool.X + 150, win.WindowsAis.Y + fpdtextnew.WinVisualTool.Y + 10);
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
                                        if (AutoItX.WinExists(WindowsAis3.Text, WindowsAis3.DataNotFound) == 1)
                                        {
                                            LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, fpd + "/" + fio, "Витрина ЦУН при выборе плательщика", WindowsAis3.DataNotFound);
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
                            LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, fpd + "/" + fio, ModeBranchUserRegZemla, id);
                        }
                        AutoItX.Sleep(1000);
                        AutoItX.ControlFocus(WindowsAis3.AisNalog3, WindowsAis3.Text, WindowsAis3.GridWinAis3);
                        AutoItX.Send(ButtonConstant.Tab);
                        copyfio = fio;
                        fio = null;
                        id = null;
                    }
                    break;
                }
            }
        }


        /// <summary>
        /// Атоматизация ветки 
        /// Налоговое администрирование\Физические лица\1.06. Формирование и печать CНУ\1. Создание заявки на формирование СНУ для единичной печати
        /// </summary>
        /// <param name="pathjurnalerror">Путь к журналу с ошибками</param>
        /// <param name="pathjurnalok">Путь к отработаным Инн</param>
        /// <param name="massinn">Массовые ИНН</param>
        public void Click4(string pathjurnalerror, string pathjurnalok, string massinn)
        {
            while (true)
            {
                AutoItX.WinActivate(WindowsAis3.AisNalog3);
                AutoItX.ControlClick(WindowsAis3.AisNalog3, SnuForm.ButSrtnal[0], SnuForm.ButSrtnal[1], ButtonConstant.MouseLeft);
                AutoItX.WinWait(WindowsAis3.Text, WindowsAis3.WinWait, 5);
                if (AutoItX.WinExists(WindowsAis3.Text, WindowsAis3.WinWait) == 1)
                {
                    AutoItX.WinActivate(WindowsAis3.Text, WindowsAis3.WinWait);
                    break;
                }
            }
            AutoItX.ClipPut(massinn);
            AutoItX.Send(ButtonConstant.Down2);
            AutoItX.Send(ButtonConstant.Right5);
            AutoItX.Send(ButtonConstant.Enter);
            AutoItX.Send(ButtonConstant.CtrlV);
            AutoItX.ControlClick(WindowsAis3.Text, SnuForm.ButUpdate[0], SnuForm.ButUpdate[1], ButtonConstant.MouseLeft);
            AutoItX.Sleep(5000);
            AutoItX.Send(ButtonConstant.CtrlA);
            AutoItX.ControlClick(WindowsAis3.Text, SnuForm.ButNext[0], SnuForm.ButNext[1], ButtonConstant.MouseLeft);
            AutoItX.Sleep(500);
            AutoItX.WinActivate(WindowsAis3.AisNalog3);
            AutoItX.ControlClick(WindowsAis3.AisNalog3, SnuForm.ButClose[0], SnuForm.ButClose[1], ButtonConstant.MouseLeft);
            AutoItX.ControlClick(WindowsAis3.AisNalog3, SnuForm.ButCreateZ[0], SnuForm.ButCreateZ[1], ButtonConstant.MouseLeft);
            AutoItX.WinWait(SnuText.DialogWin, SnuText.Snu, 10);
            if (AutoItX.WinExists(SnuText.DialogWin, SnuText.Snu) != 0)
            {
                AutoItX.Send(ButtonConstant.Enter);
            }
            AutoItX.WinWait(WindowsAis3.Text, SnuText.Null, 3);
            if (AutoItX.WinExists(WindowsAis3.Text, SnuText.Null) != 0)
            {
                AutoItX.Send(ButtonConstant.Enter);
                LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, massinn, SnuZayvki, "Список налогоплательщиков пуст!!!");
            }
        }

        /// <summary>
        /// Атоматизация ветки 
        /// Налоговое администрирование\Собственность\07. Взаимодействие с органами ГИБДД, Гостехнадзора – Наземные ТС
        /// </summary>
        /// <param name="pathjurnalerror">Путь к журналу с ошибками</param>
        /// <param name="pathjurnalok">Путь к журналу отработаных</param>
        /// <param name="fid">Значение ФИД</param>
        public void Click5(string pathjurnalerror, string pathjurnalok, string fid)
        {
            WindowsAis3 win = new WindowsAis3();
            win.ControlGetPos1(WindowsAis3.WinGrid[0], WindowsAis3.WinGrid[1], WindowsAis3.WinGrid[2]);
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 70, win.WindowsAis.Y + win.Y1 + 35);
            AutoItX.ClipPut(fid);
            AutoItX.Send(ButtonConstant.Right5);
            AutoItX.Send(ButtonConstant.Enter);
            AutoItX.Send(ButtonConstant.CtrlV);
            AutoItX.Send(ButtonConstant.F5);
            while (true)
            {
                if (AutoItX.WinExists(WindowsAis3.Text, WindowsAis3.DataNotFound) == 1)
                {
                    AutoItX.Send(ButtonConstant.F3);
                    LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, fid, Okp4Pravo, WindowsAis3.DataNotFound);
                    break;
                }
                if (AutoItX.WinExists(WindowsAis3.Text, PravoZorI.Fid) == 1)
                {
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + 395, win.WindowsAis.Y + 90);
                    AutoItX.Send(ButtonConstant.Down3);
                    AutoItX.Send(ButtonConstant.Enter);
                    while (true)
                    {
                        if (AutoItX.WinExists(PravoZorI.WinTitle) == 1)
                        {
                            AutoItX.WinActivate(PravoZorI.WinTitle);
                            AutoItX.Send(ButtonConstant.Enter);
                            LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, fid, Okp4Pravo, PravoZorI.ErrorText);
                            AutoItX.Send(ButtonConstant.F3);
                            break;
                        }
                        if (AutoItX.WinExists(PravoZorI.WinRemoveSved) == 1)
                        {
                            AutoItX.ControlSend(PravoZorI.WinRemoveSved, PravoZorI.Exlusive, Pravo.EditDate, DateTime.Now.ToString("d"));
                            AutoItX.ControlFocus(PravoZorI.WinRemoveSved, Pravo.EditNum[0], Pravo.EditNum[1]);
                            AutoItX.Send(PravoZorI.EditString, 1);
                            AutoItX.ControlClick(PravoZorI.WinRemoveSved, Pravo.ComboboxEdit[0], Pravo.ComboboxEdit[1], ButtonConstant.MouseLeft);
                            AutoItX.Send(ButtonConstant.Down3);
                            AutoItX.Send(ButtonConstant.Enter);
                            AutoItX.ControlClick(PravoZorI.WinRemoveSved, Pravo.ButtonOk[0], Pravo.ButtonOk[1], ButtonConstant.MouseLeft);
                            while (true)
                            {
                                if (AutoItX.WinExists(PravoZorI.WinTitle, PravoZorI.ErrorText2) == 1)
                                {
                                    AutoItX.WinActivate(PravoZorI.WinTitle);
                                    AutoItX.Send(ButtonConstant.Enter);
                                    LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, fid, Okp4Pravo, PravoZorI.ErrorText2);
                                    AutoItX.Send(ButtonConstant.F3);
                                    break;
                                }
                                if (AutoItX.WinExists(PravoZorI.WinTitle, PravoZorI.OkDelete) == 1)
                                {
                                    AutoItX.Sleep(1000);
                                    AutoItX.WinActivate(PravoZorI.WinTitle);
                                    AutoItX.Send(ButtonConstant.Enter);
                                    LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathjurnalok, fid, "Отработали фид права");
                                    AutoItX.Send(ButtonConstant.F3);
                                    break;
                                }
                            }
                            break;
                        }
                    }
                    break;
                }
            }
        }

        ///  <summary>
        /// Атоматизация ветки 
        /// Общие задания\Урегулирование задолженности\05.09 Ручное формирование решений на зачет/возврат/возврат процентов\05.09 Подпись проектов решений на зачет/возврат/возврат процентов\Подпись начальником аналитического отдела
        /// а также ветка 
        /// Общие задания\Урегулирование задолженности\05.09.01(06.01) Формирование сообщения о факте излишней уплаты (излишнего взыскания)\05.09.01(06.01) Формирование сообщения об излишней уплате (взыскании)\05.09.01(06.01) Формирование решений о зачете по инициативе НО\Подпись начальником аналитического отдела
        /// </summary>
        public string Click6()
        {
            int i = 0;
            WindowsAis3 win = new WindowsAis3();
            while (true)
            {
                win.ControlGetPos1(WindowsAis3.WinRequest[0], WindowsAis3.WinRequest[1], WindowsAis3.WinRequest[2]);
                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 355, win.WindowsAis.Y + win.Y1 + 80);
                AutoItX.WinWait(WindowsAis3.AisNalog3, ZachetVozvrat.Nachalnic, 5);
                if (AutoItX.WinExists(WindowsAis3.AisNalog3, ZachetVozvrat.Nachalnic) == 1)
                {
                    break;
                }
                if (i == Proverka.Controlnumer)
                {
                    return Status.StatusAis.Status6;
                }
                i++;
            }
            //Подписываем проверяем если Ок сохраняем
            var countdocstring = ReadWindow.Read.Reades.ReadFormNotActiv(Mode.Analitic.Task.TaskZn.Signature);
            while (true)
            {
                win.ControlGetPos1(WindowsAis3.WinRequest[0], WindowsAis3.WinRequest[1], WindowsAis3.WinRequest[2]);
                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 550, win.WindowsAis.Y + win.Y1 + 75);
                var countdocstringcontrol = ReadWindow.Read.Reades.ReadFormNotActiv(Mode.Analitic.Task.TaskZn.Signature);
                if (!countdocstring.Equals(countdocstringcontrol))
                {
                    break;
                }
            }
            while (true)
            {
                win.ControlGetPos1(WindowsAis3.WinRequest[0], WindowsAis3.WinRequest[1], WindowsAis3.WinRequest[2]);
                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 205, win.WindowsAis.Y + win.Y1 + 85);
                AutoItX.WinWait(ZachetVozvrat.TitleClose, ZachetVozvrat.TextWin, 10);
                if (AutoItX.WinExists(ZachetVozvrat.TitleClose, ZachetVozvrat.TextWin) == 1)
                {
                    AutoItX.WinActivate(ZachetVozvrat.TitleClose);
                    AutoItX.Send(ButtonConstant.Enter);
                    AutoItX.WinWait(ZachetVozvrat.TitleExit, ZachetVozvrat.WorkOk, 10);
                    AutoItX.Send(ButtonConstant.Enter);
                    break;
                }
            }
            return Status.StatusAis.Status3;
        }

        /// <summary>
        /// Печать уведомлений с анализом в ЛК2
        /// Ветка : Налоговое администрирование\Физические лица\1.06. Формирование и печать CНУ\2. Просмотр СНУ
        /// </summary>
        /// <param name="date">Дата уведомления</param>
        /// <param name="pathjurnalerror">Путь к журналу с ошибками</param>
        /// <param name="pathjurnalok">Распечатанные уведомления</param>
        /// <param name="inn">Список ИНН</param>
        /// <param name="conectionstring">Строка соединения с БД</param>
        /// <param name="ischec">Простановка даты true ,false</param>
        /// <param name="islk2">Проверять ли ЛК2 или нет?</param>
        public void Click7(DateTime date, string pathjurnalerror, string pathjurnalok, string inn, string conectionstring, bool ischec, bool islk2)
        {
            var listinn = new List<string>();
            string copyinn = null;
            ReadWindow.Read.Reades.ClearBuffer();
            WindowsAis3 win = new WindowsAis3();
            if (ischec)
            {
                win.ControlGetPos1(WindowsAis3.WinGrid[0], WindowsAis3.WinGrid[1], WindowsAis3.WinGrid[2]);
                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 70, win.WindowsAis.Y + win.Y1 + 35);
                AutoItX.ClipPut(date.ToString("dd.MM.yyyy"));
                AutoItX.Send(ButtonConstant.Down10);
                AutoItX.Send(ButtonConstant.Right5);
                AutoItX.Send(ButtonConstant.Enter);
                AutoItX.Send(ButtonConstant.CtrlV);
            }
            win.ControlGetPos1(WindowsAis3.WinGrid[0], WindowsAis3.WinGrid[1], WindowsAis3.WinGrid[2]);
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 70, win.WindowsAis.Y + win.Y1 + 35);
            AutoItX.ClipPut(inn);
            AutoItX.Send(ButtonConstant.Down20);
            AutoItX.Send(ButtonConstant.Right5);
            AutoItX.Send(ButtonConstant.Enter);
            AutoItX.Send(ButtonConstant.CtrlV);
            AutoItX.Send(ButtonConstant.F5);
            while (true)
            {
                if (AutoItX.WinExists(WindowsAis3.Text, WindowsAis3.DataNotFound) == 1)
                {
                    AutoItX.Send(ButtonConstant.F3);
                    LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, inn, PrintBranch, WindowsAis3.DataNotFound);
                    break;
                }
                if (AutoItX.WinExists(WindowsAis3.AisNalog3, PrintSnu.Inn) == 1)
                {
                    string innais = ReadWindow.Read.Reades.ReadForm(Mode.Okp4.PrintSnu.PrintSnuControl.InnText);
                    if (innais.Equals(copyinn))
                    {
                        LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, PublicFunc.NotArray(listinn, inn), PrintBranch, PrintSnu.InnNotSnu);
                        AutoItX.WinActivate(WindowsAis3.AisNalog3, WindowsAis3.Text);
                        AutoItX.Send(ButtonConstant.F3);
                        break;
                    }
                    if (islk2)
                    {
                        Lk2 lk2 = new Lk2();
                        if (lk2.SqlLk(conectionstring, innais))
                        {
                            LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, innais, PrintBranch, PrintSnu.NotLk2);
                        }
                        else
                        {
                            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + 180, win.WindowsAis.Y + 90);
                            AutoItX.WinWait(PrintSnu.ErrorElectronSys[0], PrintSnu.ErrorElectronSys[1], 2);
                            if (AutoItX.WinExists(PrintSnu.ErrorElectronSys[0], PrintSnu.ErrorElectronSys[1]) == 1)
                            {
                                LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, innais, PrintBranch, PrintSnu.ErrorElectronSys[1]);
                                AutoItX.Send(ButtonConstant.Enter);
                            }
                            else
                            {
                                LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathjurnalok, innais, PrintSnu.Woked);
                                Process.ProcessLibary.Process("FoxitPhantom.exe", 12000);
                            }
                        }
                    }
                    else
                    {
                        AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + 180, win.WindowsAis.Y + 90);
                        AutoItX.WinWait(PrintSnu.ErrorElectronSys[0], PrintSnu.ErrorElectronSys[1], 2);
                        if (AutoItX.WinExists(PrintSnu.ErrorElectronSys[0], PrintSnu.ErrorElectronSys[1]) == 1)
                        {
                            LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, innais, PrintBranch, PrintSnu.ErrorElectronSys[1]);
                            AutoItX.Send(ButtonConstant.Enter);
                        }
                        else
                        {
                            LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathjurnalok, innais, PrintSnu.Woked);
                            Process.ProcessLibary.Process("FoxitPhantom.exe", 12000);
                        }
                    }
                    AutoItX.ControlFocus(Mode.Okp4.PrintSnu.PrintSnuControl.GridText[0], "", Mode.Okp4.PrintSnu.PrintSnuControl.GridText[1]);
                    AutoItX.Send(ButtonConstant.Tab);
                    listinn.Add(innais); //Добавление елемента в массив
                    copyinn = innais;
                }
            }
        }

        /// <summary>
        /// Автоматизация ветки 
        /// Налоговое администрирование\ПОН ИЛ\1. ПОН ИЛ (ПЭ). Организации и физические лица, внесенные в ПОН ИЛ\2.01. ФЛ. Актуальное состояние
        /// </summary>
        /// <param name="pathjurnalerror">Путь к журналу с ошибками</param>
        /// <param name="pathjurnalok">Путь к отработаным</param>
        /// <param name="fid">Фид значения</param>
        public void Click8(string pathjurnalerror, string pathjurnalok, string fid)
        {
            AutoItX.WinActivate(WindowsAis3.AisNalog3);
            ReadWindow.Read.Reades.ClearBuffer();
            WindowsAis3 win = new WindowsAis3();
            win.ControlGetPos1(WindowsAis3.WinGrid[0], WindowsAis3.WinGrid[1], WindowsAis3.WinGrid[2]);
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 70, win.WindowsAis.Y + win.Y1 + 35);
            AutoItX.ClipPut(fid);
            AutoItX.Send(ButtonConstant.Right6);
            AutoItX.Send(ButtonConstant.Enter);
            AutoItX.Send(ButtonConstant.CtrlV);
            AutoItX.Send(ButtonConstant.Enter);
            AutoItX.Send(ButtonConstant.F5);
            AutoItX.WinWait(WindowsAis3.AisNalog3, StatusText.FidText, 5000);
            while (true)
            {
                if (AutoItX.WinExists(WindowsAis3.Text, WindowsAis3.DataNotFound) == 1)
                {
                    AutoItX.Send(ButtonConstant.F3);
                    LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, fid, ActualStatus,
                        WindowsAis3.DataNotFound);
                    break;
                }
                if (AutoItX.WinExists(WindowsAis3.AisNalog3, StatusText.FidText) == 1)
                {
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + 435, win.WindowsAis.Y + 95);
                    AutoItX.WinWait(WindowsAis3.AisNalog3, StatusText.StateSved);
                    if (AutoItX.WinExists(WindowsAis3.AisNalog3, StatusText.StateSved) == 1)
                    {
                        AutoItX.WinActivate(WindowsAis3.AisNalog3);
                        AutoItX.ControlFocus(WindowsAis3.Text, StatusReg.ComboBox[0], StatusReg.ComboBox[1]);
                        AutoItX.Send(StatusText.IsklFl);
                        AutoItX.ControlFocus(WindowsAis3.Text, StatusReg.ComboBox1[0], StatusReg.ComboBox1[1]);
                        AutoItX.Send(StatusText.IsklFlError);
                        AutoItX.ControlClick(WindowsAis3.Text, StatusReg.DateStatus[0], StatusReg.DateStatus[1]);
                        AutoItX.ControlSend(WindowsAis3.Text, StatusReg.DateStatus[0], StatusReg.DateStatus[1], DateTime.Now.ToString("d"));
                        AutoItX.ControlClick(WindowsAis3.Text, StatusReg.DateActual[0], StatusReg.DateActual[1]);
                        AutoItX.ControlSend(WindowsAis3.Text, StatusReg.DateActual[0], StatusReg.DateActual[1], DateTime.Now.ToString("d"));
                        AutoItX.ControlClick(WindowsAis3.AisNalog3, StatusReg.ButtonSelect[0], StatusReg.ButtonSelect[1]);
                        while (true)
                        {
                            if (AutoItX.WinExists(StatusText.DialogWin[0], StatusText.DialogWin[1]) == 1)
                            {
                                AutoItX.Send(ButtonConstant.Enter);
                                AutoItX.Sleep(2000);
                                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + 435, win.WindowsAis.Y + 95);
                                AutoItX.WinWait(WindowsAis3.AisNalog3, StatusText.StateSved);
                                if (AutoItX.WinExists(WindowsAis3.AisNalog3, StatusText.StateSved) == 1)
                                {
                                    AutoItX.WinActivate(WindowsAis3.AisNalog3);
                                    AutoItX.ControlFocus(WindowsAis3.Text, StatusReg.ComboBox[0], StatusReg.ComboBox[1]);
                                    AutoItX.Send(StatusText.VkllFl);
                                    AutoItX.ControlClick(WindowsAis3.Text, StatusReg.DateStatus[0], StatusReg.DateStatus[1]);
                                    AutoItX.ControlSend(WindowsAis3.Text, StatusReg.DateStatus[0], StatusReg.DateStatus[1], DateTime.Now.ToString("d"));
                                    AutoItX.ControlClick(WindowsAis3.Text, StatusReg.DateActual[0], StatusReg.DateActual[1]);
                                    AutoItX.ControlSend(WindowsAis3.Text, StatusReg.DateActual[0], StatusReg.DateActual[1], DateTime.Now.ToString("d"));
                                    AutoItX.ControlClick(WindowsAis3.AisNalog3, StatusReg.ButtonSelect[0], StatusReg.ButtonSelect[1]);
                                    AutoItX.WinWait(StatusText.DialogWin[0], StatusText.DialogWin[1], 5000);
                                    if (AutoItX.WinExists(StatusText.DialogWin[0], StatusText.DialogWin[1]) == 1)
                                    {
                                        AutoItX.Send(ButtonConstant.Enter);
                                        LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathjurnalok, fid, StatusText.FidOk);
                                        AutoItX.Sleep(2000);
                                        win.ControlGetPos1(WindowsAis3.ControlPanel[0], WindowsAis3.ControlPanel[1], WindowsAis3.ControlPanel[2]);
                                        AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 85, win.WindowsAis.Y + win.Y1 + 10, 2);
                                        break;
                                    }
                                }
                            }
                            if (AutoItX.WinExists(StatusText.ErrorStateWin[0], StatusText.ErrorStateWin[1]) == 1)
                            {
                                AutoItX.Send(ButtonConstant.Enter);
                                AutoItX.Sleep(2000);
                                LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, fid, ActualStatus, StatusText.FidError);
                                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                                break;
                            }
                        }
                    }
                }
                break;
            }
        }

        /// <summary>
        /// Автоматизация ветки 
        /// Налоговое администрирование\Централизованный учет налогоплательщиков\15.02.02. Служебные. Технические исправления\ Физические лица\15.02.02.01. Служебные. Технические исправления. Физические лица
        /// </summary>
        /// <param name="pathjurnalerror">Путь к журналу с ошибками</param>
        /// <param name="pathjurnalok">Путь к отработаным</param>
        /// <param name="fid">Фид значения</param>
        public void Click9(string pathjurnalerror, string pathjurnalok, string fid)
        {
            ReadWindow.Read.Reades.ClearBuffer();
            WindowsAis3 win = new WindowsAis3();
            win.ControlGetPos1(WindowsAis3.WinGrid[0], WindowsAis3.WinGrid[1], WindowsAis3.WinGrid[2]);
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 70, win.WindowsAis.Y + win.Y1 + 35);
            AutoItX.ClipPut(fid);
            AutoItX.Send(ButtonConstant.Down1);
            AutoItX.Send(ButtonConstant.Right6);
            AutoItX.Send(ButtonConstant.Enter);
            AutoItX.Send(ButtonConstant.CtrlV);
            AutoItX.Send(ButtonConstant.Enter);
            AutoItX.Send(ButtonConstant.F5);
            AutoItX.WinWait(WindowsAis3.AisNalog3, StatusText.FidTextFace, 5000);
            while (true)
            {
                if (AutoItX.WinExists(WindowsAis3.Text, WindowsAis3.DataNotFound) == 1)
                {
                    AutoItX.Send(ButtonConstant.F3);
                    LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, fid, TechnicalUpdate, WindowsAis3.DataNotFound);
                    break;
                }
                if (AutoItX.WinExists(WindowsAis3.AisNalog3, StatusText.FidTextFace) == 1)
                {
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + 540, win.WindowsAis.Y + 100);
                    AutoItX.WinWait(StatusText.DialogWin[0], StatusText.DialogWin[1], 5000);
                    if (AutoItX.WinExists(StatusText.DialogWin[0], StatusText.DialogWin[1]) == 1)
                    {
                        AutoItX.Send(ButtonConstant.Enter);
                        LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathjurnalok, fid, StatusText.FidOk);
                        AutoItX.Sleep(3000);
                        win.ControlGetPos1(WindowsAis3.ControlPanel[0], WindowsAis3.ControlPanel[1], WindowsAis3.ControlPanel[2]);
                        AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 85, win.WindowsAis.Y + win.Y1 + 10, 2);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Уточнение платежей
        /// </summary>
        /// <param name="pathjurnalerror">Путь к журналу ошибок</param>
        /// <param name="pathjurnalok">Путь к журналу Ок</param>
        /// <param name="logica">Логика анализа</param>
        /// <param name="isTp">Проставлять ТП</param>
        public bool Click10(string pathjurnalerror, string pathjurnalok, int logica, bool isTp)
        {
            WindowsAis3 win = new WindowsAis3();
            RegxStart regxstart = new RegxStart();
            while (true)
            {
                var fulltext = ReadWindow.Read.Reades.HidenTextReturn(WindowsAis3.AisNalog3);
                regxstart.Parse(fulltext);
                if (regxstart.IsNulable)
                {
                    LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, regxstart.RaschDoc, ModeBranchVedomost1, regxstart.Error);
                    break;
                }
                if (string.Equals(regxstart.IsMathRegx("(0{6})", regxstart.Oktmo), "000000"))
                {
                    LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, regxstart.RaschDoc, ModeBranchVedomost1, "Не опознано ОКТМО надо проверять");
                    AutoItX.Send(ButtonConstant.Tab);
                    break;
                }
                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + 45, win.WindowsAis.Y + 95);
                AutoItX.WinWait(Vedomost1Win.ViesneniePl[0], Vedomost1Win.ViesneniePl[1]);
                AutoItX.Send(ButtonConstant.Enter);
                regxstart.UseNalog(logica, isTp);
                AutoItX.Sleep(1000);
                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + 120, win.WindowsAis.Y + 80);
                if ((AutoItX.WinWait(Vedomost1Win.Utoch[0], Vedomost1Win.Utoch[1], 1) == 1) ||
                    (AutoItX.WinWait(Vedomost1Win.Utoch2[0], Vedomost1Win.Utoch2[0], 1) == 1))
                {
                    AutoItX.Sleep(500);
                    AutoItX.Send(ButtonConstant.Enter);
                }
                if (regxstart.Platelsik.Length != 10)
                {
                    AutoItX.WinWait(Vedomost1Win.IsData[0], Vedomost1Win.IsData[1], 2);
                    AutoItX.Sleep(500);
                    AutoItX.Send(ButtonConstant.Enter);
                }
                AutoItX.WinWaitClose("АИС Налог-3 ПРОМ ", "Проведение уточнения");
                AutoItX.Send(ButtonConstant.Tab);
                LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathjurnalok, regxstart.RaschDoc + " Подставили КБК: " + regxstart.KbkIfns + " вместо " + regxstart.Kbk100, "Удалось спарсить");
                AutoItX.Sleep(1000);
                break;
            }
            return regxstart.IsNulable;
        }

        /// <summary>
        /// Функция обработку миграции НП
        /// </summary>
        /// <param name="isparse">Смена направления кода </param>
        /// <param name="reportMigration">Путь к файлу с миграцией</param>
        /// <param name="copyid">Ун миграции условие выхода</param>
        /// <param name="collectionExeption">Коллекция ИНН исключения</param>
        public string Click11(bool isparse, string reportMigration, string copyid,
            ObservableCollection<string> collectionExeption)
        {
            string ident = copyid;
            WindowsAis3 win = new WindowsAis3();
            MigrationParse model = new MigrationParse() {ReportMigration = new ReportMigration[1]};
            ReportMigration report = new ReportMigration();
            copyid = null;
            copyid = ReadWindow.Read.Reades.ReadForm(Migration.Identity);
            if (copyid.Equals(ident))
            {
                return copyid;
            }
            report.NameOrg = ReadWindow.Read.Reades.ReadForm(Migration.NameOrganization);
            report.CodeIfns = ReadWindow.Read.Reades.ReadForm(AutoItX.WinExists(Migration.PeredachaOrPriem[0], Migration.PeredachaOrPriem[1]) == 1 ? Migration.CodeIfnsPeredacha : Migration.CodeIfnsPriem);
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + 180, win.WindowsAis.Y + 75);
            AutoItX.WinWait(WindowsAis3.AisNalog3, Migration.MigrationNp, 2);
            if (!isparse)
            {
                while (true)
                {
                   AutoItX.Sleep(5000);
                   var isEnable = AutoItX.ControlCommand(AutoItX.WinGetHandle(Migration.Button[0]),
                   AutoItX.ControlGetHandle(AutoItX.WinGetHandle(Migration.Button[0]), Migration.Button[2]),"IsEnabled", "");
                    if (isEnable == "1")
                    {
                        AutoItX.ControlClick(Migration.Button[0], Migration.Button[1], Migration.Button[2]);
                        break;
                    }
                    win.ControlGetPos1(WindowsAis3.UltraGridDataMigration[0], WindowsAis3.UltraGridDataMigration[1],WindowsAis3.UltraGridDataMigration[2]);
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 45,win.WindowsAis.Y + win.Y1 + 35);
                }
                AutoItX.WinWait(TextMigration.WindiwWarning[0], TextMigration.WindiwWarning[1]);
                AutoItX.Send(ButtonConstant.Enter);
                AutoItX.WinWait(TextMigration.WindiwInfo[0], TextMigration.WindiwInfo[1]);
                AutoItX.Send(ButtonConstant.Enter);
                AutoItX.WinWait(WindowsAis3.AisNalog3, WindowsAis3.UpdateDataSource);
                AutoItX.WinActivate(WindowsAis3.AisNalog3, WindowsAis3.UpdateDataSource);
                AutoItX.Send(ButtonConstant.Tab2);
                return copyid;
            }
            report.Fid = ReadWindow.Read.Reades.ReadForm(Migration.FidMemo);
            report.Inn = ReadWindow.Read.Reades.ReadForm(Migration.InnMemo);
            var find = collectionExeption.Where(i => i == report.Inn);
            if (!find.Any())
            {
                AutoItX.Send(ButtonConstant.Tab);
                report.Kpp = ReadWindow.Read.Reades.ReadCtrlCno();
                win.ControlGetPos1(WindowsAis3.UltraGridDataMigration[0], WindowsAis3.UltraGridDataMigration[1],WindowsAis3.UltraGridDataMigration[2]);
                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 90, win.WindowsAis.Y + win.Y1 + 35, 2);
                report.Date = ReadWindow.Read.Reades.ReadCtrlC();
                AutoItX.Send(ButtonConstant.Tab2);
                report.Stage = ReadWindow.Read.Reades.ReadCtrlC();
                AutoItX.Send(ButtonConstant.Tab2);
                report.Problem = ReadWindow.Read.Reades.ReadCtrlC();
                model.ReportMigration[0] = report;
                LibaryXMLAuto.ErrorJurnal.ReportMigration.CreateReportMigration(reportMigration, model);
            }
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20,win.WindowsAis.Y + 160);
            AutoItX.Sleep(500);
            AutoItX.Send(ButtonConstant.Tab4);
            return copyid;
        }

        /// <summary>
        /// Обработка ветоки Налоговое администрирование\Собственность\14. Работа с лицами – правообладателями объектов, по которым требуется визуальная обработка\01. Росреестр - ФЛ, по которым требуется  визуальная  идентификация с витриной лиц ЦУН
        /// Налоговое администрирование\Собственность\14. Работа с лицами – правообладателями объектов, по которым требуется визуальная обработка\11. Росреестр – Запросы на обработку ФЛ, по которым переданы сведения об отчуждении существующих в ПОН КС прав на ОН
        /// </summary>
        /// <param name="idvisual">УН параметра</param>
        /// <param name="pathjurnalerror">Путь к журналу с ошибками</param>
        /// <param name="pathjurnalok">Путь к журналу с обработанными</param>
        /// <param name="ischeked">Проставить галочку</param>
        /// <param name="isbranch">Обработка ветки 11</param>
        public void Click12(string idvisual, string pathjurnalerror, string pathjurnalok, bool ischeked, bool isbranch)
        {

            WindowsAis3 win = new WindowsAis3();
            win.ControlGetPos1(WindowsAis3.WinGrid[0], WindowsAis3.WinGrid[1], WindowsAis3.WinGrid[2]);
            if (ischeked)
            {
                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 362,
                    win.WindowsAis.Y + win.Y1 + 50);
            }
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 70, win.WindowsAis.Y + win.Y1 + 35);
            AutoItX.ClipPut(idvisual);
            AutoItX.Send(ButtonConstant.Down1);
            AutoItX.Send(ButtonConstant.Right5);
            AutoItX.Send(ButtonConstant.Enter);
            AutoItX.Send(ButtonConstant.CtrlV);
            AutoItX.Send(ButtonConstant.F5);
            while (true)
            {
                if (AutoItX.WinExists(WindowsAis3.Text, WindowsAis3.DataNotFound) == 1)
                {
                    AutoItX.Send(ButtonConstant.F3);
                    LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, idvisual, FaceRosreestr, WindowsAis3.DataNotFound);
                    break;
                }
                if ((AutoItX.WinExists(WindowsAis3.AisNalog3, IdFace.IdVisual) == 1) ||
                    (AutoItX.WinExists(WindowsAis3.AisNalog3, IdFace.IdVisualTs) == 1))
                {
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + 330, win.WindowsAis.Y + 90);
                    AutoItX.Send(ButtonConstant.Down1);
                    AutoItX.Send(ButtonConstant.Enter);
                    AutoItX.WinWait(WindowsAis3.AisNalog3, WindowsAis3.WinWait, 10);
                    if (AutoItX.WinExists(WindowsAis3.AisNalog3, WindowsAis3.WinWait) == 1)
                    {
                        AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 655, win.WindowsAis.Y + win.Y1 + 55);
                        AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 70, win.WindowsAis.Y + win.Y1 + 35);
                        if (!isbranch)
                        {
                            AutoItX.Send(ButtonConstant.Down13);
                            AutoItX.Send(ButtonConstant.Right5);
                            AutoItX.Send(ButtonConstant.Enter);
                            AutoItX.Send(ButtonConstant.Delete);
                            AutoItX.Send(ButtonConstant.Enter);
                            AutoItX.Send(ButtonConstant.Down1);
                            AutoItX.Send(ButtonConstant.Enter);
                            AutoItX.Send(ButtonConstant.Delete);
                            AutoItX.Send(ButtonConstant.Enter);
                        }
                        AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + 95, win.WindowsAis.Y + 40);
                        AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + 240, win.WindowsAis.Y + 80);
                        while (true)
                        {
                            if (AutoItX.WinExists(WindowsAis3.Text, WindowsAis3.DataNotFound) == 1)
                            {

                                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                                LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, idvisual, FaceRosreestr, WindowsAis3.DataNotFound);
                                break;
                            }
                            if (AutoItX.WinExists(WindowsAis3.AisNalog3, IdFace.IdFl) == 1)
                            {
                                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + 330, win.WindowsAis.Y + 80);
                                AutoItX.Send(ButtonConstant.Down1);
                                AutoItX.Send(ButtonConstant.Enter);
                                AutoItX.WinWait(IdFace.WinInfo[0], IdFace.WinInfo[1]);
                                if (AutoItX.WinExists(IdFace.WinInfo[0], IdFace.WinInfo[1]) == 1)
                                {
                                    AutoItX.Send(ButtonConstant.Enter);
                                    AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                                    break;
                                }
                            }
                        }
                        AutoItX.Send(ButtonConstant.F3);
                        break;
                    }
                }
            }

        }

        ///  <summary>
        /// Атоматизация ветки 
        /// Общие задания\Контрольная работа (налоговые проверки)\Обработка документов НБО\Подтверждение ввода документов
        /// </summary>
        public string Click13()
        {
            int i = 0;
            WindowsAis3 win = new WindowsAis3();
            AutoItX.Sleep(2000);
            while (true)
            {
                win.ControlGetPos1(WindowsAis3.WinRequest[0], WindowsAis3.WinRequest[1], WindowsAis3.WinRequest[2]);
                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 355, win.WindowsAis.Y + win.Y1 + 80);
                AutoItX.WinWait(WindowsAis3.AisNalog3, NboText.TitelList, 15);
                if (AutoItX.WinExists(WindowsAis3.AisNalog3, NboText.TitelList) == 1)
                {
                    break;
                }
                if (i == Proverka.Controlnumer)
                {
                    return Status.StatusAis.Status6;
                }
                i++;
            }
            //Расчитываем
            win.ControlGetPos1(WindowsAis3.WinRequest[0], WindowsAis3.WinRequest[1], WindowsAis3.WinRequest[2]);
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 45, win.WindowsAis.Y + win.Y1 + 80);
            AutoItX.WinWait(WindowsAis3.AisNalog3, NboText.TitelList, 15);
            while (true)
            {
                AutoItX.WinWait(NboText.Protokol[0], NboText.Protokol[1], 2);
                var texthieden = ReadWindow.Read.Reades.HidenTextReturn(WindowsAis3.AisNalog3);
                if (AutoItX.WinExists(NboText.Protokol[0], NboText.Protokol[1]) == 1)
                {
                    AutoItX.Send(ButtonConstant.Enter);
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                    break;
                }
                if (AutoItX.WinExists(NboText.TitleError2[0], NboText.TitleError2[1]) == 1)
                {
                    AutoItX.Send(ButtonConstant.Enter);
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                    break;
                }
                if (texthieden.Contains(NboText.Strfind) || texthieden.Contains(NboText.Strfind2))
                {
                    win.ControlGetPos1(WindowsAis3.WinRequest[0], WindowsAis3.WinRequest[1], WindowsAis3.WinRequest[2]);
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 815,win.WindowsAis.Y + win.Y1 + 80);
                    while (true)
                    {

                        if (AutoItX.WinExists(NboText.TitleOk[0], NboText.TitleOk[1]) == 1)
                        {
                            AutoItX.WinActivate(NboText.TitleOk[0]);
                            AutoItX.Send(ButtonConstant.Enter);
                            break;
                        }
                        if (AutoItX.WinExists(NboText.TitleError[0], NboText.TitleError[1]) == 1)
                        {
                            AutoItX.Send(ButtonConstant.Enter);
                            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                            break;
                        }
                    }
                    break;
                }
            }
            //Перенос в КРСБ
            return Status.StatusAis.Status3;
        }

        ///  <summary>
        /// Атоматизация ветки 
        /// Общие задания\Контрольная работа налоговые проверки\Применение упрощенной системы налогооблажения\Применение УСН
        /// </summary>
        public string Click14(bool coordinete, string pathjurnalerror, string pathjurnalok)
        {
            int i = 0;
            UsnText usn = new UsnText();
            usn.Coordinate(coordinete);
            WindowsAis3 win = new WindowsAis3();
            CardDeclr card = new CardDeclr();
            AutoItX.Sleep(2000);
            while (true)
            {
                win.ControlGetPos1(WindowsAis3.WinRequest[0], WindowsAis3.WinRequest[1], WindowsAis3.WinRequest[2]);
                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 355, win.WindowsAis.Y + win.Y1 + 80);
                AutoItX.WinWait(WindowsAis3.AisNalog3, UsnText.ElemHost, 15);
                if (AutoItX.WinExists(WindowsAis3.AisNalog3, UsnText.ElemHost) == 1)
                {
                    break;
                }
                if (i == Proverka.Controlnumer)
                {
                    return Status.StatusAis.Status6;
                }
                i++;
            }
            while (true)
            {

                win.ControlGetPos1(UsnText.WinSnr[0], UsnText.WinSnr[1], UsnText.WinSnr[2]);
                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 790, win.WindowsAis.Y + win.Y1 + usn.IsOpen);
                AutoItX.WinWait(WindowsAis3.AisNalog3, UsnText.TitleUsn, 15);
                if (AutoItX.WinExists(WindowsAis3.AisNalog3, UsnText.TitleUsn) == 1)
                {
                    AutoItX.Send(ButtonConstant.Down1);
                    card.Id = ReadWindow.Read.Reades.ReadCtrlC();
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + 45, win.WindowsAis.Y + 86);
                    AutoItX.Sleep(2000);
                    AutoItX.Send(ButtonConstant.Right1);
                    card.Error = ReadWindow.Read.Reades.ReadCtrlCno();
                    AutoItX.Send(ButtonConstant.Right1);
                    card.DescriptionError = ReadWindow.Read.Reades.ReadCtrlCno();
                    if (card.Error == "Ошибка")
                    {
                        LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, card.Id, Usn, card.DescriptionError);
                        AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                        AutoItX.Sleep(1000);
                        AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                        AutoItX.WinWait(UsnText.UserWork[0], UsnText.UserWork[1], 5);
                        AutoItX.Send(ButtonConstant.Enter);
                        break;
                    }
                    else
                    {
                        AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + 120, win.WindowsAis.Y + 80);
                        AutoItX.WinWaitClose(WindowsAis3.AisNalog3, UsnText.TitleUsn, 15);
                        AutoItX.Sleep(1000);
                        AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 170, win.WindowsAis.Y + win.Y1 + usn.Sender);
                        AutoItX.WinWait(UsnText.VvodVxod[0], UsnText.VvodVxod[1], 15);
                        AutoItX.Send(ButtonConstant.Enter);
                        AutoItX.Sleep(3000);
                        AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 160, win.WindowsAis.Y + win.Y1 + usn.Finish);
                        AutoItX.Sleep(3000);
                        LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathjurnalok, card.Id, "Обработали без ошибок!!!");
                        break;
                    }
                }
            }
            return Status.StatusAis.Status3;
        }

        ///  <summary>
        /// Автоматизация ветки
        /// Общие задания\Урегулирование задолженности\05.09 Уведомление о необходимости выгрузки документов в ЛК\05.09 Сообщения о принятом решении о зачете (возврате) подлежащие выгрузке в ЛК
        /// </summary>
        public string Click16(string pathjurnalerror, string pathjurnalok)
        {
            int i = 0;
            WindowsAis3 win = new WindowsAis3();
            while (true)
            {
                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + 355, win.WindowsAis.Y + 80);
                AutoItX.WinWait(WindowsAis3.AisNalog3, SluzZ.WinLk, 10);
                if (AutoItX.WinExists(WindowsAis3.AisNalog3, SluzZ.WinLk) == 1)
                {
                    break;
                }
                if (i == Proverka.Controlnumer)
                {
                    return Status.StatusAis.Status6;
                }
                i++;
            }
            if (AutoItX.WinExists(WindowsAis3.AisNalog3, SluzZ.WinLk) == 1)
            {
                AutoItX.Sleep(500);
                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + 250, win.WindowsAis.Y + 80);
                AutoItX.Sleep(1000);
                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + 580, win.WindowsAis.Y + 80);
                AutoItX.WinWait(SluzZ.WinClose[0], SluzZ.WinClose[1]);
                AutoItX.Send(ButtonConstant.Enter);
                AutoItX.Sleep(1000);
            }
            return "Обработали!!!";
        }
        /// <summary>
        /// Обработка задания требований
        /// 05.08.03.0X.03. Утверждение требований об уплате
        /// </summary>
        /// <returns></returns>
        public string Click17()
        {
            int num = 0;
            WindowsAis3 windowsAis = new WindowsAis3();
            while (true)
            {
                AutoItX.MouseClick(ButtonConstant.MouseLeft, windowsAis.WindowsAis.X + 355, windowsAis.WindowsAis.Y + 80);
                AutoItX.WinWait(WindowsAis3.AisNalog3, SluzZ.Utb, 10);
                if (AutoItX.WinExists(WindowsAis3.AisNalog3, SluzZ.Utb) != 1)
                {
                    if (num == Proverka.Controlnumer)
                    {
                        return Status.StatusAis.Status6;
                    }
                    num++;
                    continue;
                }
                break;
            }
            if (AutoItX.WinExists(WindowsAis3.AisNalog3, SluzZ.Utb) == 1)
            {
                AutoItX.MouseClick(ButtonConstant.MouseLeft, windowsAis.WindowsAis.X + 330, windowsAis.WindowsAis.Y + 60);
                AutoItX.Sleep(500);
                AutoItX.MouseClick(ButtonConstant.MouseLeft, windowsAis.WindowsAis.X + 240, windowsAis.WindowsAis.Y + 78);
                AutoItX.WinWait(SluzZ.WinCloseNalog[0], SluzZ.WinCloseNalog[1]);
                AutoItX.Sleep(500);
                AutoItX.Send(ButtonConstant.Enter);
            }
            return "Обработали!!!";
        }

        /// <summary>
        /// Автоматизация парсинга данных заявок для ролей
        /// </summary>
        /// <param name="pathjurnalok">Путь к сохранению</param>
        /// <param name="countvalue">Количество записей</param>
        /// <param name="datestart">Дата начала периода</param>
        /// <param name="datefinish">Дата конца периода</param>
        public string Click15(string pathjurnalok,string countvalue,DateTime datestart, DateTime datefinish)
        {
            string dates = null;
            UserRule userRule = new UserRule();
            int j = 0;
            WindowsAis3 windowsAis = new WindowsAis3();
            LibaryAutomations libaryAutomations = new LibaryAutomations(WindowsAis3.AisNalog3);
            libaryAutomations.FindFirstElement(TextRuleParse.PanelDocksCountRow);
            libaryAutomations.SetValuePattern(countvalue);
            libaryAutomations.FindFirstElement(TextRuleParse.PanelDocksDbStart);
            libaryAutomations.SetValuePattern(datestart.ToString("dd.MM.yyyy"));
            libaryAutomations.FindFirstElement(TextRuleParse.PanelDocksDbFinish);
            libaryAutomations.SetValuePattern(datefinish.ToString("dd.MM.yyyy"));
            AutoItX.WinActivate(WindowsAis3.AisNalog3);
            AutoItX.MouseClick(ButtonConstant.MouseLeft, windowsAis.WindowsAis.X + 35, windowsAis.WindowsAis.Y + 75);
            libaryAutomations.IsEnableElements(TextRuleParse.GridJournal);
            var listelementgrid = libaryAutomations.SelectAutomationColrction(libaryAutomations.FindElement).Cast<AutomationElement>().Where(elem => elem.Current.Name.Contains("List")).GroupBy(x=>x.Current.Name).Select(g=>g.First());
            foreach (AutomationElement automationElement in listelementgrid)
            {
                var listmemo = libaryAutomations.SelectAutomationColrction(automationElement);
                foreach (AutomationElement element in listmemo)
                {
                    if (element.Current.Name == "Дата")
                    {
                        dates = libaryAutomations.ParseElement(element);
                    }
                    if (element.Current.Name == "Номер")
                    {
                        libaryAutomations.InvekePattern(element);
                        AutoItX.Sleep(1000);
                        AutoItX.Send(ButtonConstant.F3);
                        libaryAutomations.IsEnableElements(TextRuleParse.HistoryJournal);
                        var historyjurnals = libaryAutomations.SelectAutomationColrction(libaryAutomations.FindElement);
                        foreach (var history in historyjurnals.Cast<AutomationElement>().Where(elem => elem.Current.Name.Contains("List")))
                        {
                            var historyrule = libaryAutomations.SelectAutomationColrction(history);
                            if (historyrule.Cast<AutomationElement>().Any(elem => elem.Current.Name.Contains("Appointments")))
                            {
                                userRule.User = new User[1];
                                userRule.User[0] = new User
                                {
                                    Dolj = libaryAutomations.ParseElement(libaryAutomations.FindFirstElement(TextRuleParse.Doljnost)),
                                    Fio = libaryAutomations.ParseElement(libaryAutomations.FindFirstElement(TextRuleParse.Name)),
                                    Otdel = libaryAutomations.ParseElement(libaryAutomations.FindFirstElement(TextRuleParse.Department)),
                                    SysName = libaryAutomations.ParseElement(libaryAutomations.FindFirstElement(TextRuleParse.Logon)),
                                    Number = libaryAutomations.ParseElement(element),
                                    Dates = dates
                                    
                                };
                                var listhistory = historyrule.Cast<AutomationElement>().Where(elem => elem.Current.Name.Contains("Appointments"));
                                foreach (AutomationElement rule in listhistory)
                                {
                                    //Формируем заявку поиск пользователя
                                    var allelements = libaryAutomations.SelectAutomationColrction(rule);
                                    foreach (var rules in allelements.Cast<AutomationElement>())
                                    {
                                        if (userRule.User[0].Rule == null)
                                        {
                                            userRule.User[0].Rule = new Rule[listhistory.Count()];
                                        }
                                        if (userRule.User[0].Rule[j] == null)
                                        {
                                            userRule.User[0].Rule[j] = new Rule();
                                        }
                                        //Разбор ролей
                                        var valueruele = libaryAutomations.ParseElement(rules);
                                        switch (rules.Current.Name)
                                        {
                                            case "Наименование":
                                                userRule.User[0].Rule[j].Name = valueruele;
                                                break;
                                            case "Тип":
                                                userRule.User[0].Rule[j].Types = valueruele;
                                                break;
                                            case "Действие":
                                                userRule.User[0].Rule[j].Pushed = valueruele;
                                                break;
                                            case "Дата начала":
                                                userRule.User[0].Rule[j].DateStart = valueruele;
                                                break;
                                            case "Дата окончания":
                                                userRule.User[0].Rule[j].DateFinish = valueruele;
                                                break;
                                            case "Контекст":
                                                userRule.User[0].Rule[j].Context = valueruele;
                                                break;
                                        }
                                    }
                                    j++;
                                }
                            }
                            AutoItX.MouseClick(ButtonConstant.MouseLeft, windowsAis.WindowsAis.X + 25, windowsAis.WindowsAis.Y + 70);
                            break;
                        }
                        j = 0;
                        break;
                    }
                }
                LibaryXMLAuto.ErrorJurnal.ReportMigration.CreateFileRule(pathjurnalok, userRule);
                userRule.User = null;
                //Переключаем запись Tab повторяем процессс и так до конца
            }
            //Закончили
            return Status.StatusAis.Status6;
        }
    }
    
}