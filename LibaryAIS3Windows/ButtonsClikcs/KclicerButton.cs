using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows.Automation;
using LibaryAIS3Windows.Window.Otdel.Analitic.TeskText;
using AutoIt;
using LibaryAIS3Windows.AutomationsUI.LibaryAutomations;
using LibaryAIS3Windows.AutomationsUI.Otdels.It;
using LibaryAIS3Windows.AutomationsUI.Otdels.RaschetBud;
using LibaryAIS3Windows.AutomationsUI.Otdels.Registration;
using LibaryAIS3Windows.AutomationsUI.Otdels.Uregulirovanie;
using LibaryAIS3Windows.AutomationsUI.PublicElement;
using LibaryAIS3Windows.ExitLogica.ExitTaskFull;
using LibaryAIS3Windows.Function.PublicFunc;
using LibaryAIS3Windows.Mode.Okp4.PravoZorI;
using LibaryAIS3Windows.Mode.Okp4.SnuFormirovanie;
using LibaryAIS3Windows.Mode.RaschetBudg.Migration;
using LibaryAIS3Windows.Mode.Reg.StatusReg;
using LibaryAIS3Windows.RegxFull.RaschetBudg;
using LibaryAIS3Windows.SqlModel.SqlLk2;
using LibaryAIS3Windows.Window;
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
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using ViewModelLib.ModelTestAutoit.PublicModel.DataPickerItRule;


namespace LibaryAIS3Windows.ButtonsClikcs
{
    public class KclicerButton
    {
        private const string ModeBranchVedomost1 = @"Налоговое администрирование\Расчеты с бюджетом\Ведомость невыясненных поступлений\Ведомость невыясненных поступлений. Раздел 1";


        private const string LogTreb = @"Налоговое администрирование\Урегулирование задолженности\Требования об уплате\Журнал требований об уплате";
        /// <summary>
        /// Ветка идентификации банковских счетов
        /// </summary>
        private const string VisualBank = @"Налоговое администрирование\Банковские и лицевые счета\06. Журналы принятых файлов БС\01. Визуальный анализ сообщений банка";
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
        /// <param name="statusButton">Кнопка</param>
        /// <param name="pathjurnalerror">Путь к журналу ошибок</param>
        /// <param name="pathjurnalok">Путь к журналу Ок</param>
        /// <param name="logica">Логика анализа</param>
        /// <param name="isTp">Проставлять ТП</param>
        public void Click10(StatusButtonMethod statusButton, string pathjurnalerror, string pathjurnalok, int logica, bool isTp)
        {
            var libaryAutomations = new LibaryAutomations(WindowsAis3.AisNalog3);
            libaryAutomations.FindFirstElement(RashetBudElementName.DateGrid);
            var listmemo = libaryAutomations.SelectAutomationColrction(libaryAutomations.FindElement).Cast<AutomationElement>().Where(elem => elem.Current.Name.Contains("List"));
            foreach (var automationElement in listmemo)
            {
                if (statusButton.Iswork)
                {
                    automationElement.SetFocus();
                    RegxStart regxstart = new RegxStart();
                    regxstart.RaschDoc = libaryAutomations.ParseElementLegacyIAccessiblePatternIdentifiers(libaryAutomations
                                     .SelectAutomationColrction(automationElement)
                                     .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Расчетный документ")));
                    regxstart.RaspredPl = libaryAutomations.ParseElementLegacyIAccessiblePatternIdentifiers(libaryAutomations
                                     .SelectAutomationColrction(automationElement)
                                     .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("КБК")));
                    regxstart.InnPlatel = libaryAutomations.ParseElementLegacyIAccessiblePatternIdentifiers(libaryAutomations
                                   .SelectAutomationColrction(automationElement)
                                   .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("ИНН плательщика (60)")));
                    regxstart.Inn = libaryAutomations.ParseElementLegacyIAccessiblePatternIdentifiers(libaryAutomations
                                     .SelectAutomationColrction(automationElement)
                                     .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("ИНН получателя (61)")));
                    regxstart.Kpp = libaryAutomations.ParseElementLegacyIAccessiblePatternIdentifiers(libaryAutomations
                                     .SelectAutomationColrction(automationElement)
                                     .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("КПП получателя (103)")));
                    regxstart.Platej = libaryAutomations.ParseElementLegacyIAccessiblePatternIdentifiers(libaryAutomations
                                     .SelectAutomationColrction(automationElement)
                                     .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Сумма (7)")));
                    regxstart.Kbk100 = libaryAutomations.ParseElementLegacyIAccessiblePatternIdentifiers(libaryAutomations
                                       .SelectAutomationColrction(automationElement)
                                       .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("КБК")));
                    regxstart.KbkIfns = libaryAutomations.ParseElementLegacyIAccessiblePatternIdentifiers(libaryAutomations
                                      .SelectAutomationColrction(automationElement)
                                      .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("КБК (104)")));
                    regxstart.Oktmo = libaryAutomations.ParseElementLegacyIAccessiblePatternIdentifiers(libaryAutomations
                                     .SelectAutomationColrction(automationElement)
                                     .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("ОКТМО (ОКАТО) (105)")));
                    if (String.IsNullOrWhiteSpace(regxstart.Oktmo) || string.Equals(regxstart.IsMathRegx("(0{6})", regxstart.Oktmo), "000000"))
                    {
                        LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, regxstart.RaschDoc,ModeBranchVedomost1, "Не опознано ОКТМО надо проверять");
                    }
                    else
                    {
                        while (true)
                        {
                            if (libaryAutomations.IsEnableElements(RashetBudElementName.StartUtoch) == null) continue;
                            libaryAutomations.CliksElements(RashetBudElementName.StartUtoch);
                            break;
                        }
                        AutoItX.WinWait(Vedomost1Win.ViesneniePl[0], Vedomost1Win.ViesneniePl[1]);
                        AutoItX.Send(ButtonConstant.Enter);
                        regxstart.UseNalog(logica, isTp);
                        while (true)
                        {
                            if (libaryAutomations.IsEnableElements(RashetBudElementName.Utverjdenie) == null) continue;
                            libaryAutomations.CliksElements(RashetBudElementName.Utverjdenie);
                            break;
                        }
                        if ((AutoItX.WinWait(Vedomost1Win.Utoch[0], Vedomost1Win.Utoch[1], 1) == 1) || (AutoItX.WinWait(Vedomost1Win.Utoch2[0], Vedomost1Win.Utoch2[0], 1) == 1))
                        {
                            AutoItX.Sleep(500);
                            AutoItX.Send(ButtonConstant.Enter);
                        }
                        if (regxstart.InnPlatel.Length != 10)
                        {
                            AutoItX.WinWait(Vedomost1Win.IsData[0], Vedomost1Win.IsData[1], 2);
                            AutoItX.Sleep(500);
                            AutoItX.Send(ButtonConstant.Enter);
                        }
                        AutoItX.WinWaitClose("АИС Налог-3 ПРОМ ", "Проведение уточнения");
                        LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathjurnalok, regxstart.RaschDoc + " Подставили КБК: " + regxstart.KbkIfns + " вместо " + regxstart.Kbk100, "Удалось спарсить");
                    }
                }
            }
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
        /// <summary>
        /// Автоматизация парсинга данных заявок для ролей
        /// </summary>
        /// <param name="statusButton">Статус для преостановки</param>
        /// <param name="pathjurnalok">Путь к сохранению</param>
        /// <param name="dataPickerSettings">Параметры для автомата</param>
        public void Click15(StatusButtonMethod statusButton, string pathjurnalok, DataPickerRuleItModel dataPickerSettings)
        {
            string dates = null;
            UserRules userRule = new UserRules();
            int j = 0;
            LibaryAutomations libaryAutomations = new LibaryAutomations(WindowsAis3.AisNalog3);
            libaryAutomations.FindFirstElement(ItElementName.PanelDocksCountRow);
            libaryAutomations.SetValuePattern(dataPickerSettings.CountRow);
            libaryAutomations.FindFirstElement(ItElementName.PanelDocksDbStart);
            libaryAutomations.SetValuePattern(dataPickerSettings.DateStart.ToString("dd.MM.yyyy"));
            libaryAutomations.FindFirstElement(ItElementName.PanelDocksDbFinish);
            libaryAutomations.SetValuePattern(dataPickerSettings.DateFinish.ToString("dd.MM.yyyy"));
            libaryAutomations.FindFirstElement(PublicElementName.UpdateButton);
            libaryAutomations.InvekePattern(libaryAutomations.FindElement);
            libaryAutomations.IsEnableElements(ItElementName.GridJournal);
            var i = 1;
            while (libaryAutomations.FindFirstElement(string.Format(ItElementName.GridJournalRows,i))!=null)
            {
                i++;
                if (statusButton.Iswork)
                {
                    var listmemo = libaryAutomations.SelectAutomationColrction(libaryAutomations.FindElement);
                    foreach (AutomationElement element in listmemo)
                    {
                        if (element.Current.Name == "Дата")
                        {
                            dates = libaryAutomations.ParseElementLegacyIAccessiblePatternIdentifiers(element);
                        }
                        if (element.Current.Name == "Номер")
                        {
                            libaryAutomations.FindFirstElement(PublicElementName.ViewButton);
                            libaryAutomations.InvekePattern(libaryAutomations.FindElement);
                            libaryAutomations.IsEnableElements(ItElementName.HistoryJournal);
                            var historyjurnals = libaryAutomations.SelectAutomationColrction(libaryAutomations.FindElement).Cast<AutomationElement>().Where(elem => elem.Current.Name.Contains("List"));
                            foreach (var history in historyjurnals)
                            {
                                var historyrule = libaryAutomations.SelectAutomationColrction(history);
                                if (historyrule.Cast<AutomationElement>().Any(elem => elem.Current.Name.Contains("Appointments")))
                                {
                                    userRule.User = new User[1];
                                    userRule.User[0] = new User
                                    {
                                        Dolj = libaryAutomations.ParseElementLegacyIAccessiblePatternIdentifiers(libaryAutomations.FindFirstElement(ItElementName.Doljnost)),
                                        Fio = libaryAutomations.ParseElementLegacyIAccessiblePatternIdentifiers(libaryAutomations.FindFirstElement(ItElementName.Name)),
                                        Otdel = libaryAutomations.ParseElementLegacyIAccessiblePatternIdentifiers(libaryAutomations.FindFirstElement(ItElementName.Department)),
                                        SysName = libaryAutomations.ParseElementLegacyIAccessiblePatternIdentifiers(libaryAutomations.FindFirstElement(ItElementName.Logon)),
                                        Number = libaryAutomations.ParseElementLegacyIAccessiblePatternIdentifiers(element),
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
                                            var valueruele = libaryAutomations.ParseElementLegacyIAccessiblePatternIdentifiers(rules);
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
                                libaryAutomations.FindFirstElement(PublicElementName.BackButton);
                                libaryAutomations.InvekePattern(libaryAutomations.FindElement);
                                break;
                            }
                            j = 0;
                            break;
                        }
                    }
                    LibaryXMLAuto.ErrorJurnal.ReportMigration.CreateFileRule(pathjurnalok, userRule);
                    userRule.User = null;
                }
                else
                {
                    break;
                }
                AutoItX.Send(ButtonConstant.Tab);
            }
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
        /// <param name="statusButton">Кнопка статуса чтобы остановить</param>
        /// <returns></returns>
        public void Click17(StatusButtonMethod statusButton)
        {
            LibaryAutomations libraryAutomation = new LibaryAutomations(WindowsAis3.AisNalog3);
            LibaryAutomations libraryAutomationCheck = new LibaryAutomations(WindowsAis3.AisNalog3);
            AutomationElement elemental;
            while ((elemental =libraryAutomation.IsEnableElements(SettlementDebts.JournalDocuments, null,true)) != null)
            {
                if (statusButton.Iswork)
                {
                    libraryAutomation.IsEnableElements(SettlementDebts.SumT, elemental);
                    libraryAutomation.FindElement.SetFocus();
                    libraryAutomation.FindFirstElement(PublicElementName.StartBeforeQ);
                    var climbablePoint = libraryAutomation.FindElement.GetClickablePoint();
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, (int)climbablePoint.X, (int)climbablePoint.Y);
                    libraryAutomationCheck.IsEnableElements(SettlementDebts.JournalSum, null, true);
                    var ischeck = "False";
                    while (true)
                    {
                        if(ischeck == "False" || string.IsNullOrWhiteSpace(ischeck))
                        {
                            ischeck = libraryAutomationCheck.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomationCheck.IsEnableElements(SettlementDebts.IsCheck, libraryAutomationCheck.FindElement));
                            if (ischeck == "True") break;
                        }
                        if (libraryAutomation.IsEnableElements(SettlementDebts.ButtonSettlement) == null) continue;
                        libraryAutomation.CliksElements(SettlementDebts.ButtonSettlement);
                    }
                    while (true)
                    {
                        if (AutoIt.AutoItX.WinExists(SluzZ.WinCloseNalog[0], SluzZ.WinCloseNalog[1]) > 0)
                        {
                            AutoItX.WinActivate(SluzZ.WinCloseNalog[0], SluzZ.WinCloseNalog[1]);
                            AutoItX.Send(ButtonConstant.Enter);
                            break;
                        }
                            if (libraryAutomation.IsEnableElements(SettlementDebts.ButtonSend) == null) continue;
                            libraryAutomation.CliksElements(SettlementDebts.ButtonSend);

                    }
                }
                else
                {
                    break;
                }
            }
        }
        /// <summary>
        /// Отработка документов поступивших документов
        /// </summary>
        /// <param name="statusButton">Кнопка статуса чтобы остановить</param>
        /// <param name="pathjurnalok">Путь сохранения отработтаных</param>
        public void Click18(StatusButtonMethod statusButton, string pathjurnalok)
        {
            LibaryAutomations libaryAutomations = new LibaryAutomations(WindowsAis3.AisNalog3);
            AutomationElement elementauto;
            while ((elementauto = libaryAutomations.IsEnableElements(RegistrationElementName.JurnalsDocumentsFirstElement,null,true)) != null)
            {
                        if (statusButton.Iswork)
                        {
                            libaryAutomations.IsEnableElements(RegistrationElementName.Doc, elementauto);
                            libaryAutomations.FindElement.SetFocus();
                            var id = libaryAutomations.ParseElementLegacyIAccessiblePatternIdentifiers(libaryAutomations.FindElement);
                            libaryAutomations.FindFirstElement(RegistrationElementName.IsErrorDocument);
                            var clickablePoint = libaryAutomations.FindElement.GetClickablePoint();
                            AutoItX.MouseClick(ButtonConstant.MouseLeft, (int)clickablePoint.X, (int)clickablePoint.Y);
                            libaryAutomations.IsEnableElements(RegistrationElementName.Qweshions);
                            libaryAutomations.InvekePattern(libaryAutomations.FindElement);
                            libaryAutomations.IsEnableElements(RegistrationElementName.ErrorsCreate);
                            libaryAutomations.InvekePattern(libaryAutomations.FindElement);
                            libaryAutomations.IsEnableElements(RegistrationElementName.ErrorsOk);
                            libaryAutomations.InvekePattern(libaryAutomations.FindElement);
                            libaryAutomations.IsEnableElements(RegistrationElementName.ErrorsCancel);
                            libaryAutomations.InvekePattern(libaryAutomations.FindElement);
                            libaryAutomations.IsEnableElements(RegistrationElementName.Qweshions);
                            libaryAutomations.InvekePattern(libaryAutomations.FindElement);
                            libaryAutomations.IsEnableElements(RegistrationElementName.WinOk);
                            libaryAutomations.InvekePattern(libaryAutomations.FindElement);
                            LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathjurnalok, id, "Отработали Ун входящего без ошибок");
                        }
                        else
                        {
                            break;
                        }
            }
        }
        /// <summary>
        /// Подписание решения урегулирование задолженности 05.08.10.01.0X.02 Подписание решения.
        /// </summary>
        /// <param name="statusButton">Кнопка статуса</param>
        /// <param name="pathjurnalok">Путь к отработанным значениям</param>
        public void Click19(StatusButtonMethod statusButton, string pathjurnalok)
        {
            var libaryAutomations = new LibaryAutomations(WindowsAis3.AisNalog3);
            while (libaryAutomations.IsEnableElements(UregulirovanieElementName.JurnalsUserOperationSpravki) !=null)
            {
                if (statusButton.Iswork)
                {
                    var clickablerows = libaryAutomations.SelectAutomationColrction(libaryAutomations.FindElement).Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Имя задания")).GetClickablePoint();
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, (int)clickablerows.X, (int)clickablerows.Y);
                    libaryAutomations.FindFirstElement(PublicElementName.StartUser);
                    var clickablePoint = libaryAutomations.FindElement.GetClickablePoint();
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, (int)clickablePoint.X, (int)clickablePoint.Y);
                    AutoItX.WinWait("АИС Налог-3 ПРОМ ", "ИНН:");
                    var inn = libaryAutomations.ParseElementLegacyIAccessiblePatternIdentifiers(libaryAutomations.IsEnableElements(UregulirovanieElementName.InnResh));
                    var fio = libaryAutomations.ParseElementLegacyIAccessiblePatternIdentifiers(libaryAutomations.IsEnableElements(UregulirovanieElementName.FioResh));
                    var summ = libaryAutomations.ParseElementLegacyIAccessiblePatternIdentifiers(libaryAutomations.IsEnableElements(UregulirovanieElementName.SummResh));
                    libaryAutomations.IsEnableElements(UregulirovanieElementName.SaveUser);
                    var clickablePoint1 = libaryAutomations.FindElement.GetClickablePoint();
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, (int)clickablePoint1.X, (int)clickablePoint1.Y);
                    while (true)
                    {
                        if (libaryAutomations.IsEnableElements(UregulirovanieElementName.WinOk, null, true, 1) != null)
                        {
                            libaryAutomations.InvekePattern(libaryAutomations.FindElement);
                            break;
                        }
                        if (libaryAutomations.IsEnableElements(UregulirovanieElementName.SendSenderZadoljenost, null,true, 1) != null)
                        {
                            var clickablePoint2 = libaryAutomations.FindElement.GetClickablePoint();
                            AutoItX.MouseClick(ButtonConstant.MouseLeft, (int) clickablePoint2.X,(int) clickablePoint2.Y);
                        }
                    }
                    LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathjurnalok, $"{summ} {inn} {fio}", "Отработали Подписание решения о признании недоимки и задолжености безнадежными к взысканию");
                }
                else
                {
                    break;
                }
            }
        }


        /// <summary>
        /// Подписание справки урегулирование задолженности 05.08.10.01.0X.02 Подписание справок.
        /// </summary>
        /// <param name="statusButton">Кнопка статуса</param>
        /// <param name="pathjurnalok">Путь к отработанным значениям</param>
        public void Click20(StatusButtonMethod statusButton,string pathjurnalok )
        {
            var libaryAutomations = new LibaryAutomations(WindowsAis3.AisNalog3);
   
            while (libaryAutomations.IsEnableElements(UregulirovanieElementName.JurnalsUserOperationSpravki) != null)
            {
                if (statusButton.Iswork)
                {
                    var clickablerows = libaryAutomations.SelectAutomationColrction(libaryAutomations.FindElement).Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Имя задания")).GetClickablePoint();
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, (int)clickablerows.X, (int)clickablerows.Y);
                    libaryAutomations.FindFirstElement(PublicElementName.StartUser);
                    var clickablePoint = libaryAutomations.FindElement.GetClickablePoint();
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, (int)clickablePoint.X, (int)clickablePoint.Y);
                    AutoItX.WinWait("АИС Налог-3 ПРОМ ", "ИНН:");
                    var num = libaryAutomations.ParseElementLegacyIAccessiblePatternIdentifiers(libaryAutomations.IsEnableElements(UregulirovanieElementName.Number));
                    var inn = libaryAutomations.ParseElementLegacyIAccessiblePatternIdentifiers(libaryAutomations.IsEnableElements(UregulirovanieElementName.Inn));
                    var fio = libaryAutomations.ParseElementLegacyIAccessiblePatternIdentifiers(libaryAutomations.IsEnableElements(UregulirovanieElementName.Fio));
                    libaryAutomations.IsEnableElements(UregulirovanieElementName.SaveUser);
                    AutoItX.Sleep(500);
                    var clickablePoint1 = libaryAutomations.FindElement.GetClickablePoint();
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, (int)clickablePoint1.X, (int)clickablePoint1.Y);
                    while (true)
                    {
                        if (libaryAutomations.IsEnableElements(UregulirovanieElementName.SendSender,null,true,1) != null)
                        {
                            break;
                        }
                        if (libaryAutomations.IsEnableElements(UregulirovanieElementName.SaveProject, null, true,1) != null)
                        {
                            var clickablePoint2 = libaryAutomations.FindElement.GetClickablePoint();
                            AutoItX.MouseClick(ButtonConstant.MouseLeft, (int)clickablePoint2.X, (int)clickablePoint2.Y);
                        }
                    }
                    while (true)
                    {
                        if (libaryAutomations.IsEnableElements(UregulirovanieElementName.WinOkExeptions, null, true, 1) != null)
                        {
                            libaryAutomations.InvekePattern(libaryAutomations.FindElement);
                        }
                        if (libaryAutomations.IsEnableElements(UregulirovanieElementName.WinOk, null, true, 1) != null)
                        {
                            libaryAutomations.InvekePattern(libaryAutomations.FindElement);
                            break;
                        }
                        if (libaryAutomations.IsEnableElements(UregulirovanieElementName.SendSender, null, true,1) != null)
                        {
                            var clickablePoint3 = libaryAutomations.FindElement.GetClickablePoint();
                            AutoItX.MouseClick(ButtonConstant.MouseLeft, (int)clickablePoint3.X, (int)clickablePoint3.Y);
                        }
                    }
                    LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathjurnalok, $"{num} {inn} {fio}", "Отработали Подписание справки о суммах недоимки");
                }
                else
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Налоговое администрирование\Банковские и лицевые счета\06. Журналы принятых файлов БС\01. Визуальный анализ сообщений банка
        /// </summary>
        /// <param name="id">ФПД значение</param>
        /// <param name="pathjurnalerror">Журнал ошибок</param>
        /// <param name="pathjurnalok">Журнал сделаных</param>
        public void Click21(string id, string pathjurnalerror, string pathjurnalok)
        {
            WindowsAis3 win = new WindowsAis3();
            var libaryAutomations = new LibaryAutomations(WindowsAis3.AisNalog3);
            win.ControlGetPos1(WindowsAis3.WinGrid[0], WindowsAis3.WinGrid[1], WindowsAis3.WinGrid[2]);
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 70, win.WindowsAis.Y + win.Y1 + 35);
            AutoItX.ClipPut(id);
            AutoItX.Send(ButtonConstant.Down3);
            AutoItX.Send(ButtonConstant.Right5);
            AutoItX.Send(ButtonConstant.Enter);
            AutoItX.Send(ButtonConstant.CtrlV);
            while (true)
            {
                if (libaryAutomations.CliksElements(RegistrationElementNameVisualBank.UpdateButton, null, false, 1))
                {
                    if (libaryAutomations.IsEnableElements(RegistrationElementNameVisualBank.JurnalsDocumentsFirstElementBank, null, true) != null)
                    {
                        libaryAutomations.FindElement.SetFocus();
                        if (libaryAutomations.CliksElements(RegistrationElementNameVisualBank.Identification, null, false, 5))
                        {
                            while (true)
                            {
                                if (libaryAutomations.CliksElements(RegistrationElementNameVisualBank.StartIdentification))
                                {
                                    while (true)
                                    {
                                        if (libaryAutomations.IsEnableElements(RegistrationElementNameVisualBank.WinOk, null, true, 1) != null)
                                        {
                                            libaryAutomations.InvekePattern(libaryAutomations.FindElement);
                                        }
                                        if (libaryAutomations.IsEnableElements(RegistrationElementNameVisualBank.WinOkEnd, null, true, 1) != null)
                                        {
                                            libaryAutomations.InvekePattern(libaryAutomations.FindElement);
                                            if (libaryAutomations.CliksElements(RegistrationElementNameVisualBank.Return))
                                            {
                                                break;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, id, VisualBank, "Не удаётся идентифицировать лицо. Лицо не найдено!");
                                    libaryAutomations.CliksElements(RegistrationElementNameVisualBank.ReturnList, null, false, 10);
                                    if (libaryAutomations.CliksElements(RegistrationElementNameVisualBank.Return, null,false, 10))
                                    {
                                        return;
                                    }
                                }
                                break;
                            }
                            break;
                        }
                    }
                    else
                    {
                        LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, id, VisualBank, "Не найдено значение для идентификации");
                        if (libaryAutomations.CliksElements(RegistrationElementNameVisualBank.Return, null, false, 10))
                        {
                            return;
                        }
                    }
                }
            }
            LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathjurnalok, id, "Отработали идентификацию успешно!");
        }
        /// <summary>
        /// Налоговое администрирование\Урегулирование задолженности\Требования об уплате\Журнал требований об уплате
        /// Проставление информации о вручкении +3 дня от подачи
        /// </summary>
        /// <param name="statusButton">Запуск остановка</param>
        /// <param name="pathjurnalerror">Журнал ошибок</param>
        /// <param name="pathjurnalok">Журнал отработанных</param>
        /// string pathjurnalerror, string pathjurnalok, StatusButtonMethod statusButton
        public void Click22(StatusButtonMethod statusButton, string pathjurnalerror,string pathjurnalok )
        {
            var libaryAutomations = new LibaryAutomations(WindowsAis3.AisNalog3);
            libaryAutomations.FindFirstElement(Trebovanie.JurnalsTrebovanie);
            var listmemo = libaryAutomations.SelectAutomationColrction(libaryAutomations.FindElement).Cast<AutomationElement>().Where(elem => elem.Current.Name.Contains("select0 row"));
            foreach (var automationElement in listmemo)
            {
                if (statusButton.Iswork)
                {
                    automationElement.SetFocus();
                    var valuesdate = libaryAutomations.ParseElementLegacyIAccessiblePatternIdentifiers(libaryAutomations
                                     .SelectAutomationColrction(automationElement)
                                     .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Дата ТУ")));

                    var valuesnumber = libaryAutomations.ParseElementLegacyIAccessiblePatternIdentifiers(libaryAutomations
                                       .SelectAutomationColrction(automationElement)
                                       .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Номер ТУ")));

                    var valuesinn = libaryAutomations.ParseElementLegacyIAccessiblePatternIdentifiers(libaryAutomations
                                    .SelectAutomationColrction(automationElement)
                                    .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("ИНН")));

                    var valuetypenp = libaryAutomations.ParseElementLegacyIAccessiblePatternIdentifiers(libaryAutomations
                                     .SelectAutomationColrction(automationElement)
                                     .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Тип НП")));

                    var valuestatussend = libaryAutomations.ParseElementLegacyIAccessiblePatternIdentifiers(libaryAutomations
                                          .SelectAutomationColrction(automationElement)
                                          .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Способ вручения")));

                    libaryAutomations.CliksElements(Trebovanie.ListPanel);
                    if (libaryAutomations.CliksElements(Trebovanie.Open, null, false, 5))
                    {
                        while (true)
                        {
                            if (libaryAutomations.IsEnableElements(Trebovanie.Save) != null)
                            {
                                libaryAutomations.CliksElements(Trebovanie.TabIfo, null, false, 10);
                                libaryAutomations.IsEnableElements(Trebovanie.ComboBoxSelect);
                                libaryAutomations.ComboBoxPatternDown(1);
                                var datevruch = Convert.ToDateTime(valuesdate).AddDays(valuetypenp == "ФЛ" ? 5 : 3);
                                if (datevruch.DayOfWeek == DayOfWeek.Saturday)
                                    datevruch = datevruch.AddDays(2);
                                if (datevruch.DayOfWeek == DayOfWeek.Sunday)
                                    datevruch = datevruch.AddDays(1);
                                while (true)
                                {
                                    if (libaryAutomations.IsEnableElements(Trebovanie.Date) == null) continue;
                                    libaryAutomations.SetValuePattern(datevruch.ToString("dd.MM.yy"));
                                    break;
                                }
                                if (valuestatussend == "Массовая печать и рассылка" & valuetypenp == "ФЛ")
                                {
                                  libaryAutomations.IsEnableElements(Trebovanie.ComboboxSend);
                                  libaryAutomations.ComboBoxPatternUp(3);
                                }
                                while (true)
                                {
                                    if (libaryAutomations.IsEnableElements(Trebovanie.Save) == null) continue;
                                    libaryAutomations.CliksElements(Trebovanie.Save);
                                    break;
                                }
                                while (true)
                                {
                                    if (libaryAutomations.IsEnableElements(Trebovanie.Back) == null) continue;
                                    libaryAutomations.CliksElements(Trebovanie.Back);
                                    break;
                                }
                                LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathjurnalok,$"Номер ТУ: {valuesnumber}; Тип лица:{valuetypenp} Дата ТУ: {valuesdate}; Дата вручения: {datevruch}; ИНН Налогоплательщика: {valuesinn}","Проставили врчение успешно!");
                                // Debug.WriteLine(valuesdate + " " + datevruch + "  " + valuesnumber + "  " + valuesinn);
                                break;
                            }
                            if (libaryAutomations.IsEnableElements(Trebovanie.Back) != null)
                            {
                                //Запись лога что сохранили не достуно
                                //Debug.WriteLine(valuesdate + "  " + valuesnumber + "  " + valuesinn);
                                LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, valuesnumber, LogTreb, "Не активна кнопка сохранить!");
                                libaryAutomations.CliksElements(Trebovanie.Back, null, false, 10);
                                break;
                            }
                        }
                    }
                }
                //  Debug.WriteLine(valuesdate + "  "+ valuesnumber + "  " + valuesinn);
            }
        }
        /// <summary>
        /// Урегулирование задолженности/05.09 Уведомление о необходимости выгрузки документов в ЛК\
        /// 05.09 Сообщения о принятом решении об отказе  подлежащие выгрузке в ЛК
        /// </summary>
        /// <param name="statusButton">Запуск остановка</param>
        /// <param name="pathjurnalerror">Журнал ошибок</param>
        /// <param name="pathjurnalok">Журнал отработанных</param>
        public void Click23(StatusButtonMethod statusButton, string pathjurnalerror, string pathjurnalok)
        {
            LibaryAutomations libraryAutomation = new LibaryAutomations(WindowsAis3.AisNalog3);
            LibaryAutomations libraryAutomationCheck = new LibaryAutomations(WindowsAis3.AisNalog3);
            AutomationElement elemental;
            while ((elemental = libraryAutomation.IsEnableElements(RecouncementLk.JurnalsRecouncement, null, true)) != null)
            {
                if (statusButton.Iswork)
                {
                    var inn = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.IsEnableElements(RecouncementLk.RowInn, elemental));
                    libraryAutomation.FindElement.SetFocus();
                    libraryAutomation.FindFirstElement(PublicElementName.StartUser);
                    var climbablePoint = libraryAutomation.FindElement.GetClickablePoint();
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, (int)climbablePoint.X, (int)climbablePoint.Y);
                    var ischeck = "";
                    while (true)
                    {
                        if (ischeck == "" || string.IsNullOrWhiteSpace(ischeck))
                        {
                            ischeck = libraryAutomationCheck.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomationCheck.IsEnableElements(RecouncementLk.CheckDataLk2));
                            if (ischeck != "") break;
                        }
                        if (libraryAutomation.IsEnableElements(RecouncementLk.CheckStatusLk2) == null) continue;
                        libraryAutomation.CliksElements(RecouncementLk.CheckStatusLk2);
                    }
                    while (true)
                    {
                        if (libraryAutomation.IsEnableElements(RecouncementLk.WinOkEndUser, null, true, 1) != null)
                        {
                            libraryAutomation.InvekePattern(libraryAutomation.FindElement);
                            break;
                        }
                        if (libraryAutomation.IsEnableElements(RecouncementLk.CheckExit,null,true) == null) continue;
                        libraryAutomation.CliksElements(RecouncementLk.CheckExit);
                    }
                   LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathjurnalok, $"ИНН Налогоплательщика: {inn}; Дата вручения: {ischeck}", "Проставили признак отправки в ЛК успешно!");
                }
                else
                {
                    break;
                }
            }

        }
        /// <summary>
        /// Общие задания\Урегулирование задолженности\05.08.09.02. Взыскание задолженности за счет имущества НП ФЛ. Формирование 
        /// Служебной записки и Заявлений о взыскании за счет имущества ФЛ
        /// \05.08.09.02.03 Утверждение и подписание Заявлений о взыскании за счет имущества ФЛ
        /// \05.08.09.02.03.06. Подпись руководителями Заявлений о взыскании за счет имущества ФЛ
        /// </summary>
        /// <param name="statusButton">Запуск остановка</param>
        /// <param name="pathjurnalerror">Журнал ошибок</param>
        /// <param name="pathjurnalok">Журнал отработанных</param>
        public void Click24(StatusButtonMethod statusButton, string pathjurnalerror, string pathjurnalok)
        {
            LibaryAutomations libraryAutomation = new LibaryAutomations(WindowsAis3.AisNalog3);
            LibaryAutomations libraryAutomationCheck = new LibaryAutomations(WindowsAis3.AisNalog3);
            AutomationElement elemental;
            while ((elemental = libraryAutomation.IsEnableElements(SignatureHeadProperty.JournalSignature, null, true)) != null)
            {
                if (statusButton.Iswork)
                {
                    libraryAutomation.FindFirstElement(PublicElementName.StartUser);
                    var climbablePoint = libraryAutomation.FindElement.GetClickablePoint();
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, (int)climbablePoint.X, (int)climbablePoint.Y);
                    libraryAutomationCheck.IsEnableElements(SignatureHeadProperty.JoirnalControl, null, true);
                    var ischeck = "False";

                    while (true)
                    {
                        if (ischeck == "False" || string.IsNullOrWhiteSpace(ischeck))
                        {
                            ischeck = libraryAutomationCheck.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomationCheck.IsEnableElements(SignatureHeadProperty.IsSignatureAll, libraryAutomationCheck.FindElement));
                            if (ischeck == "True") break;
                        }
                        if (libraryAutomation.IsEnableElements(SignatureHeadProperty.ButtonSignatureAll) == null) continue;
                        libraryAutomation.CliksElements(SignatureHeadProperty.ButtonSignatureAll);
                    }
                    while (true)
                    {
                        if (libraryAutomation.IsEnableElements(SignatureHeadProperty.WinExit, null, true, 1) != null)
                        {
                            libraryAutomation.InvekePattern(libraryAutomation.FindElement);
                            break;
                        }
                        if (libraryAutomation.IsEnableElements(SignatureHeadProperty.EndSignature, null, true) == null) continue;

                        var listmemo = libraryAutomation.SelectAutomationColrction(libraryAutomationCheck.IsEnableElements(SignatureHeadProperty.JoirnalAllSignature)).Cast<AutomationElement>().Where(elem => elem.Current.Name.Contains("List"));
                        foreach (var data in listmemo)
                        {
                            var valuesinn = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                               .SelectAutomationColrction(data).Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("ИНН")));
                            var valuesadress = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                               .SelectAutomationColrction(data).Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Адрес")));
                            var valuesscore = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                               .SelectAutomationColrction(data).Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Всего")));
                            var valuesfio = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                                               .SelectAutomationColrction(data).Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("ФИО налогоплательщика")));
                            
                            LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathjurnalok, $"ИНН Налогоплательщика: {valuesinn}; ФИО НО: {valuesfio} Адрес: {valuesadress}; Сумма: {valuesscore} ", "Подписали руководителем успешно успешно!");
                        }
                        libraryAutomation.CliksElements(SignatureHeadProperty.EndSignature);
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }
}