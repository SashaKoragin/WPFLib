using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Automation;
using LibaryAIS3Windows.Window.Otdel.Analitic.TeskText;
using AutoIt;
using EfDatabaseAutomation.Automation.Base;
using EfDatabaseAutomation.Automation.BaseLogica.AddObjectDb;
using Ifns51.ToAis;
using LibaryAIS3Windows.AutomationsUI.LibaryAutomations;
using LibaryAIS3Windows.AutomationsUI.Otdels.It;
using LibaryAIS3Windows.AutomationsUI.Otdels.PreCheck;
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
using LibaryAIS3Windows.Window.Otdel.Reg.ActualStatus;
using LibaryAIS3Windows.Window.Otdel.Reg.Fpd;
using LibaryAIS3Windows.Window.Otdel.Reg.IdFace;
using LibaryAIS3Windows.Window.Otdel.Uregulirovanie.UtverzdenieSz;
using LibaryXMLAutoModelXmlAuto.MigrationReport;
using ViewModelLib.ModelTestAutoit.PublicModel.ButtonStartAutomat;
using ViewModelLib.ModelTestAutoit.PublicModel.DataPickerItRule;
using LibaryAIS3Windows.ButtonFullFunction.Okp2Function;
using LibaryAIS3Windows.ButtonFullFunction.PublicGlobalFunction;
using ViewModelLib.ModelTestAutoit.PublicModel.ModelDatePickerAdd;
using LibaryAIS3Windows.ButtonFullFunction.PreCheck;
using LibaryAIS3Windows.AutomationsUI.Otdels.PublicJournal129And121;

namespace LibaryAIS3Windows.ButtonsClikcs
{
    public class KclicerButton
    {


        private const string LogTreb =
            @"Налоговое администрирование\Урегулирование задолженности\Требования об уплате\Журнал требований об уплате";

        /// <summary>
        /// Ветка идентификации банковских счетов
        /// </summary>
        private const string VisualBank =
            @"Налоговое администрирование\Банковские и лицевые счета\06. Журналы принятых файлов БС\01. Визуальный анализ сообщений банка";

        /// <summary>
        /// Константа название ветки которую обрабатываем Основная
        /// </summary>
        private const string ModeBranch =
            @"Ветка Налоговое администрирование\Физические лица\1.06. Формирование и печать CНУ\1. Создание заявки на формирование СНУ для единичной печати";

        /// <summary>
        /// Ветка которую обрабатываем Пользовательзкое задание
        /// </summary>
        private const string ModeBranchUser =
            @"Физические лица/1.08. Сообщение ФЛ об объектах собственности\Уточнение сведений о ФЛ";

        /// <summary>
        /// Корректировка сведений о правах
        /// </summary>
        private const string Okp4Pravo =
            @"Налоговое администрирование\Собственность\02. Доопределение данных об объектах собственности\14. КС – Корректировка сведений о правах не зарегистрированных  в органах Росреестра и правах наследования на ОН и ЗУ";

        private const string ModeBranchUserRegZemla =
            @"Налоговое администрирование\Собственность\05. Взаимодействие с органами Росреестра – Земельные участки\03. Обработка ФПД  от РР - ФЛ - Анализ результатов обработки документов";

        /// <summary>
        /// Создание заявки на формирования СНУ
        /// </summary>
        private const string SnuZayvki =
            @"Налоговое администрирование\Физические лица\1.06. Формирование и печать CНУ\1. Создание заявки на формирование СНУ для единичной печати";

        /// <summary>
        /// Печать уведомлений
        /// </summary>
        private const string PrintBranch =
            @"Налоговое администрирование\Физические лица\1.06. Формирование и печать CНУ\2. Просмотр СНУ";

        /// <summary>
        /// Актуальный статус
        /// </summary>
        private const string ActualStatus =
            @"Налоговое администрирование\ПОН ИЛ\1. ПОН ИЛ (ПЭ). Организации и физические лица, внесенные в ПОН ИЛ\2.01. ФЛ. Актуальное состояние";

        /// <summary>
        /// Техническое исправление
        /// </summary>
        private const string TechnicalUpdate =
            @"Налоговое администрирование\Централизованный учет налогоплательщиков\15.02.02. Служебные. Технические исправления\ Физические лица\15.02.02.01. Служебные. Технические исправления. Физические лица";

        /// <summary>
        /// Росреестр Визуальная идентификация
        /// </summary>
        private const string FaceRosreestr =
            @"Налоговое администрирование\Собственность\14. Работа с лицами – правообладателями объектов, по которым требуется визуальная обработка";

        private const string Usn =
            @"Общие задания\Контрольная работа налоговые проверки\Применение упрощенной системы налогооблажения\Применение УСН";

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
                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 180,
                    win.WindowsAis.Y + win.Y1 + 120);
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
            AutoItX.ControlClick(WindowsAis3.Text, SnuForm.ButUpdate[0], SnuForm.ButUpdate[1],
                ButtonConstant.MouseLeft);
            AutoItX.Sleep(3000);
            while (true)
            {
                if (AutoItX.WinExists(WindowsAis3.Text, WindowsAis3.DataNotFound) == 1)
                {
                    AutoItX.ControlClick(WindowsAis3.Text, SnuForm.ButCancel[0], SnuForm.ButCancel[1],
                        ButtonConstant.MouseLeft);
                    LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, inn, ModeBranch,
                        WindowsAis3.DataNotFound);
                    break;
                }

                if (AutoItX.WinExists(WindowsAis3.Text, WindowsAis3.UpdateDataSource) == 1)
                {
                    AutoItX.Send(ButtonConstant.CtrlA);
                    AutoItX.ControlClick(WindowsAis3.Text, SnuForm.ButNext[0], SnuForm.ButNext[1],
                        ButtonConstant.MouseLeft);
                    AutoItX.WinActivate(WindowsAis3.AisNalog3, WindowsAis3.Text);
                    AutoItX.ControlClick(WindowsAis3.AisNalog3, SnuForm.ButCreateZ[0], SnuForm.ButCreateZ[1],
                        ButtonConstant.MouseLeft);
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
                        AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 7,
                            win.WindowsAis.Y + win.Y1 + 55, 2);
                        AutoItX.WinWait(WindowsAis3.Text, Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.TextFid, 30);
                    }
                    else
                    {
                        win.ControlGetPos1(WindowsAis3.WinRequest[0], WindowsAis3.WinRequest[1],
                            WindowsAis3.WinRequest[2]);
                        AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 355,
                            win.WindowsAis.Y + win.Y1 + 80);
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
                    AutoItX.ControlClick(WindowsAis3.Text, Mode.Reg.Yvedomlenie.Yvedomlenia.Visual[0],
                        Mode.Reg.Yvedomlenie.Yvedomlenia.Visual[1], ButtonConstant.MouseLeft);
                    AutoItX.WinWait(Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.VisualVindow,
                        Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.UpdateText, 10);
                    if (
                        AutoItX.WinExists(Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.VisualVindow,
                            Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.UpdateText) == 1)
                    {
                        break;
                    }
                }

                AutoItX.Sleep(2000);
                ClikcCheker.Cheker.Chekerfid();
                AutoItX.ControlClick(Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.VisualVindow,
                    Mode.Reg.Yvedomlenie.Yvedomlenia.Update[0], Mode.Reg.Yvedomlenie.Yvedomlenia.Update[1],
                    ButtonConstant.MouseLeft);
                while (true)
                {
                    if (
                        AutoItX.WinExists(Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.VisualVindow,
                            WindowsAis3.DataNotFound) == 1)
                    {
                        AutoItX.ControlClick(Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.VisualVindow,
                            Mode.Reg.Yvedomlenie.Yvedomlenia.Select[0], Mode.Reg.Yvedomlenie.Yvedomlenia.Select[1],
                            ButtonConstant.MouseLeft);
                        LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, fid, ModeBranchUser,
                            WindowsAis3.DataNotFound);
                        AutoItX.ControlClick(WindowsAis3.Text, Mode.Reg.Yvedomlenie.Yvedomlenia.Close[0],
                            Mode.Reg.Yvedomlenie.Yvedomlenia.Close[1], ButtonConstant.MouseLeft);
                        break;
                    }

                    if (
                        AutoItX.WinExists(Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.VisualVindow,
                            Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.TextFidUser) == 1)
                    {
                        AutoItX.ControlClick(Window.Otdel.Reg.Yvedomlenie.TextYvedomlenie.VisualVindow,
                            Mode.Reg.Yvedomlenie.Yvedomlenia.Select[0], Mode.Reg.Yvedomlenie.Yvedomlenia.Select[1],
                            ButtonConstant.MouseLeft);
                        AutoItX.MouseWheel(ButtonConstant.Wheel, 2);
                        AutoItX.ControlClick(WindowsAis3.Text, Mode.Reg.Yvedomlenie.Yvedomlenia.ComboboxSelect[0],
                            Mode.Reg.Yvedomlenie.Yvedomlenia.ComboboxSelect[1], ButtonConstant.MouseLeft);
                        AutoItX.Send(ButtonConstant.Down2);
                        AutoItX.Send(ButtonConstant.Enter);
                        AutoItX.ControlClick(WindowsAis3.Text, Mode.Reg.Yvedomlenie.Yvedomlenia.Save[0],
                            Mode.Reg.Yvedomlenie.Yvedomlenia.Save[1], ButtonConstant.MouseLeft);
                        AutoItX.Sleep(500);
                        AutoItX.Send(ButtonConstant.Enter);
                        AutoItX.ControlClick(WindowsAis3.Text, Mode.Reg.Yvedomlenie.Yvedomlenia.Close[0],
                            Mode.Reg.Yvedomlenie.Yvedomlenia.Close[1], ButtonConstant.MouseLeft);
                        LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathjurnalok, fid, "Отработали");
                        break;
                    }
                }

            }
            catch (Exception e)
            {
                LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, "Ошибка исключения надо смотреть!!!",
                    ModeBranchUser, e.Message);
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
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 70,
                win.WindowsAis.Y + win.Y1 + 35);
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
                    LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, fpd, ModeBranchUserRegZemla,
                        WindowsAis3.DataNotFound);
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
                                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + 330,
                                    win.WindowsAis.Y + 90);
                                AutoItX.Send(ButtonConstant.Down1);
                                AutoItX.Send(ButtonConstant.Enter);
                                AutoItX.WinWait(WindowsAis3.Text, FpdText.TextCun, 5);
                                if (AutoItX.WinExists(WindowsAis3.Text, FpdText.TextCun) == 1)
                                {
                                    AutoItX.ControlClick(WindowsAis3.Text, Mode.Reg.ZemlyFpd.Zemly.SpisokCun[0],
                                        Mode.Reg.ZemlyFpd.Zemly.SpisokCun[1], ButtonConstant.MouseLeft);
                                    AutoItX.Send(ButtonConstant.Enter);
                                    AutoItX.Sleep(1000);
                                    FpdText fpdtext = new FpdText();
                                    AutoItX.MouseClick(ButtonConstant.MouseLeft,
                                        win.WindowsAis.X + fpdtext.WinVisualPageControl.X + 675,
                                        win.WindowsAis.Y + fpdtext.WinVisualPageControl.Y + 110);
                                    AutoItX.MouseClick(ButtonConstant.MouseLeft,
                                        win.WindowsAis.X + fpdtext.WinVisualPageControl.X + 40,
                                        win.WindowsAis.Y + fpdtext.WinVisualPageControl.Y + 90);
                                    AutoItX.Send(ButtonConstant.Down13);
                                    AutoItX.Send(ButtonConstant.Right5);
                                    AutoItX.Send(ButtonConstant.Enter);
                                    AutoItX.Send(ButtonConstant.Delete);
                                    AutoItX.Send(ButtonConstant.Enter);
                                    AutoItX.Send(ButtonConstant.Down1);
                                    AutoItX.Send(ButtonConstant.Enter);
                                    AutoItX.Send(ButtonConstant.Delete);
                                    AutoItX.Send(ButtonConstant.Enter);
                                    AutoItX.MouseClick(ButtonConstant.MouseLeft,
                                        win.WindowsAis.X + fpdtext.WinVisualTool.X + 80,
                                        win.WindowsAis.Y + fpdtext.WinVisualTool.Y + 10);
                                    while (true)
                                    {
                                        if (AutoItX.WinExists(WindowsAis3.Text, FpdText.TextUnfl) == 1)
                                        {
                                            while (true)
                                            {
                                                FpdText fpdtextnew = new FpdText();
                                                AutoItX.MouseClick(ButtonConstant.MouseLeft,
                                                    win.WindowsAis.X + fpdtextnew.WinVisualTool.X + 150,
                                                    win.WindowsAis.Y + fpdtextnew.WinVisualTool.Y + 10);
                                                AutoItX.WinWait(FpdText.TextVnimanie, FpdText.TextOk, 5);
                                                if (AutoItX.WinExists(FpdText.TextVnimanie, FpdText.TextOk) == 1)
                                                {
                                                    AutoItX.WinActivate(FpdText.TextVnimanie, FpdText.TextOk);
                                                    AutoItX.Send(ButtonConstant.Enter);
                                                    LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathjurnalok, fpd,
                                                        "Отработали");
                                                    AutoItX.MouseClick(ButtonConstant.MouseLeft,
                                                        fpdtext.WinCoordinat.X + fpdtext.WinCoordinat.Width - 15,
                                                        fpdtext.WinCoordinat.Y + 160);
                                                    break;
                                                }
                                            }

                                            break;
                                        }

                                        if (AutoItX.WinExists(WindowsAis3.Text, WindowsAis3.DataNotFound) == 1)
                                        {
                                            LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror,
                                                fpd + "/" + fio, "Витрина ЦУН при выборе плательщика",
                                                WindowsAis3.DataNotFound);
                                            AutoItX.MouseClick(ButtonConstant.MouseLeft,
                                                fpdtext.WinCoordinat.X + fpdtext.WinCoordinat.Width - 15,
                                                fpdtext.WinCoordinat.Y + 160);
                                            break;
                                        }
                                    }

                                    break;
                                }

                                if (AutoItX.WinExists(FpdText.TextVnimanie, FpdText.TextIdent) == 1)
                                {
                                    AutoItX.WinActivate(FpdText.TextVnimanie, FpdText.TextIdent);
                                    AutoItX.Send(ButtonConstant.Enter);
                                    LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, fpd + "/" + fio,
                                        ModeBranchUserRegZemla, FpdText.TextIdent);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, fpd + "/" + fio,
                                ModeBranchUserRegZemla, id);
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
                AutoItX.ControlClick(WindowsAis3.AisNalog3, SnuForm.ButSrtnal[0], SnuForm.ButSrtnal[1],
                    ButtonConstant.MouseLeft);
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
            AutoItX.ControlClick(WindowsAis3.Text, SnuForm.ButUpdate[0], SnuForm.ButUpdate[1],
                ButtonConstant.MouseLeft);
            AutoItX.Sleep(5000);
            AutoItX.Send(ButtonConstant.CtrlA);
            AutoItX.ControlClick(WindowsAis3.Text, SnuForm.ButNext[0], SnuForm.ButNext[1], ButtonConstant.MouseLeft);
            AutoItX.Sleep(500);
            AutoItX.WinActivate(WindowsAis3.AisNalog3);
            AutoItX.ControlClick(WindowsAis3.AisNalog3, SnuForm.ButClose[0], SnuForm.ButClose[1],
                ButtonConstant.MouseLeft);
            AutoItX.ControlClick(WindowsAis3.AisNalog3, SnuForm.ButCreateZ[0], SnuForm.ButCreateZ[1],
                ButtonConstant.MouseLeft);
            AutoItX.WinWait(SnuText.DialogWin, SnuText.Snu, 10);
            if (AutoItX.WinExists(SnuText.DialogWin, SnuText.Snu) != 0)
            {
                AutoItX.Send(ButtonConstant.Enter);
            }

            AutoItX.WinWait(WindowsAis3.Text, SnuText.Null, 3);
            if (AutoItX.WinExists(WindowsAis3.Text, SnuText.Null) != 0)
            {
                AutoItX.Send(ButtonConstant.Enter);
                LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, massinn, SnuZayvki,
                    "Список налогоплательщиков пуст!!!");
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
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 70,
                win.WindowsAis.Y + win.Y1 + 35);
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
                    LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, fid, Okp4Pravo,
                        WindowsAis3.DataNotFound);
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
                            LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, fid, Okp4Pravo,
                                PravoZorI.ErrorText);
                            AutoItX.Send(ButtonConstant.F3);
                            break;
                        }

                        if (AutoItX.WinExists(PravoZorI.WinRemoveSved) == 1)
                        {
                            AutoItX.ControlSend(PravoZorI.WinRemoveSved, PravoZorI.Exlusive, Pravo.EditDate,
                                DateTime.Now.ToString("d"));
                            AutoItX.ControlFocus(PravoZorI.WinRemoveSved, Pravo.EditNum[0], Pravo.EditNum[1]);
                            AutoItX.Send(PravoZorI.EditString, 1);
                            AutoItX.ControlClick(PravoZorI.WinRemoveSved, Pravo.ComboboxEdit[0], Pravo.ComboboxEdit[1],
                                ButtonConstant.MouseLeft);
                            AutoItX.Send(ButtonConstant.Down3);
                            AutoItX.Send(ButtonConstant.Enter);
                            AutoItX.ControlClick(PravoZorI.WinRemoveSved, Pravo.ButtonOk[0], Pravo.ButtonOk[1],
                                ButtonConstant.MouseLeft);
                            while (true)
                            {
                                if (AutoItX.WinExists(PravoZorI.WinTitle, PravoZorI.ErrorText2) == 1)
                                {
                                    AutoItX.WinActivate(PravoZorI.WinTitle);
                                    AutoItX.Send(ButtonConstant.Enter);
                                    LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, fid, Okp4Pravo,
                                        PravoZorI.ErrorText2);
                                    AutoItX.Send(ButtonConstant.F3);
                                    break;
                                }

                                if (AutoItX.WinExists(PravoZorI.WinTitle, PravoZorI.OkDelete) == 1)
                                {
                                    AutoItX.Sleep(1000);
                                    AutoItX.WinActivate(PravoZorI.WinTitle);
                                    AutoItX.Send(ButtonConstant.Enter);
                                    LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathjurnalok, fid,
                                        "Отработали фид права");
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
                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 355,
                    win.WindowsAis.Y + win.Y1 + 80);
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
                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 550,
                    win.WindowsAis.Y + win.Y1 + 75);
                var countdocstringcontrol =
                    ReadWindow.Read.Reades.ReadFormNotActiv(Mode.Analitic.Task.TaskZn.Signature);
                if (!countdocstring.Equals(countdocstringcontrol))
                {
                    break;
                }
            }

            while (true)
            {
                win.ControlGetPos1(WindowsAis3.WinRequest[0], WindowsAis3.WinRequest[1], WindowsAis3.WinRequest[2]);
                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 205,
                    win.WindowsAis.Y + win.Y1 + 85);
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
        public void Click7(DateTime date, string pathjurnalerror, string pathjurnalok, string inn,
            string conectionstring, bool ischec, bool islk2)
        {
            var listinn = new List<string>();
            string copyinn = null;
            ReadWindow.Read.Reades.ClearBuffer();
            WindowsAis3 win = new WindowsAis3();
            if (ischec)
            {
                win.ControlGetPos1(WindowsAis3.WinGrid[0], WindowsAis3.WinGrid[1], WindowsAis3.WinGrid[2]);
                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 70,
                    win.WindowsAis.Y + win.Y1 + 35);
                AutoItX.ClipPut(date.ToString("dd.MM.yyyy"));
                AutoItX.Send(ButtonConstant.Down10);
                AutoItX.Send(ButtonConstant.Right5);
                AutoItX.Send(ButtonConstant.Enter);
                AutoItX.Send(ButtonConstant.CtrlV);
            }

            win.ControlGetPos1(WindowsAis3.WinGrid[0], WindowsAis3.WinGrid[1], WindowsAis3.WinGrid[2]);
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 70,
                win.WindowsAis.Y + win.Y1 + 35);
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
                    LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, inn, PrintBranch,
                        WindowsAis3.DataNotFound);
                    break;
                }

                if (AutoItX.WinExists(WindowsAis3.AisNalog3, PrintSnu.Inn) == 1)
                {
                    string innais = ReadWindow.Read.Reades.ReadForm(Mode.Okp4.PrintSnu.PrintSnuControl.InnText);
                    if (innais.Equals(copyinn))
                    {
                        LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror,
                            PublicFunc.NotArray(listinn, inn), PrintBranch, PrintSnu.InnNotSnu);
                        AutoItX.WinActivate(WindowsAis3.AisNalog3, WindowsAis3.Text);
                        AutoItX.Send(ButtonConstant.F3);
                        break;
                    }

                    if (islk2)
                    {
                        Lk2 lk2 = new Lk2();
                        if (lk2.SqlLk(conectionstring, innais))
                        {
                            LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, innais, PrintBranch,
                                PrintSnu.NotLk2);
                        }
                        else
                        {
                            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + 180, win.WindowsAis.Y + 90);
                            AutoItX.WinWait(PrintSnu.ErrorElectronSys[0], PrintSnu.ErrorElectronSys[1], 2);
                            if (AutoItX.WinExists(PrintSnu.ErrorElectronSys[0], PrintSnu.ErrorElectronSys[1]) == 1)
                            {
                                LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, innais, PrintBranch,
                                    PrintSnu.ErrorElectronSys[1]);
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
                            LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, innais, PrintBranch,
                                PrintSnu.ErrorElectronSys[1]);
                            AutoItX.Send(ButtonConstant.Enter);
                        }
                        else
                        {
                            LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathjurnalok, innais, PrintSnu.Woked);
                            Process.ProcessLibary.Process("FoxitPhantom.exe", 12000);
                        }
                    }

                    AutoItX.ControlFocus(Mode.Okp4.PrintSnu.PrintSnuControl.GridText[0], "",
                        Mode.Okp4.PrintSnu.PrintSnuControl.GridText[1]);
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
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 70,
                win.WindowsAis.Y + win.Y1 + 35);
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
                        AutoItX.ControlSend(WindowsAis3.Text, StatusReg.DateStatus[0], StatusReg.DateStatus[1],
                            DateTime.Now.ToString("d"));
                        AutoItX.ControlClick(WindowsAis3.Text, StatusReg.DateActual[0], StatusReg.DateActual[1]);
                        AutoItX.ControlSend(WindowsAis3.Text, StatusReg.DateActual[0], StatusReg.DateActual[1],
                            DateTime.Now.ToString("d"));
                        AutoItX.ControlClick(WindowsAis3.AisNalog3, StatusReg.ButtonSelect[0],
                            StatusReg.ButtonSelect[1]);
                        while (true)
                        {
                            if (AutoItX.WinExists(StatusText.DialogWin[0], StatusText.DialogWin[1]) == 1)
                            {
                                AutoItX.Send(ButtonConstant.Enter);
                                AutoItX.Sleep(2000);
                                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + 435,
                                    win.WindowsAis.Y + 95);
                                AutoItX.WinWait(WindowsAis3.AisNalog3, StatusText.StateSved);
                                if (AutoItX.WinExists(WindowsAis3.AisNalog3, StatusText.StateSved) == 1)
                                {
                                    AutoItX.WinActivate(WindowsAis3.AisNalog3);
                                    AutoItX.ControlFocus(WindowsAis3.Text, StatusReg.ComboBox[0],
                                        StatusReg.ComboBox[1]);
                                    AutoItX.Send(StatusText.VkllFl);
                                    AutoItX.ControlClick(WindowsAis3.Text, StatusReg.DateStatus[0],
                                        StatusReg.DateStatus[1]);
                                    AutoItX.ControlSend(WindowsAis3.Text, StatusReg.DateStatus[0],
                                        StatusReg.DateStatus[1], DateTime.Now.ToString("d"));
                                    AutoItX.ControlClick(WindowsAis3.Text, StatusReg.DateActual[0],
                                        StatusReg.DateActual[1]);
                                    AutoItX.ControlSend(WindowsAis3.Text, StatusReg.DateActual[0],
                                        StatusReg.DateActual[1], DateTime.Now.ToString("d"));
                                    AutoItX.ControlClick(WindowsAis3.AisNalog3, StatusReg.ButtonSelect[0],
                                        StatusReg.ButtonSelect[1]);
                                    AutoItX.WinWait(StatusText.DialogWin[0], StatusText.DialogWin[1], 5000);
                                    if (AutoItX.WinExists(StatusText.DialogWin[0], StatusText.DialogWin[1]) == 1)
                                    {
                                        AutoItX.Send(ButtonConstant.Enter);
                                        LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathjurnalok, fid,
                                            StatusText.FidOk);
                                        AutoItX.Sleep(2000);
                                        win.ControlGetPos1(WindowsAis3.ControlPanel[0], WindowsAis3.ControlPanel[1],
                                            WindowsAis3.ControlPanel[2]);
                                        AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 85,
                                            win.WindowsAis.Y + win.Y1 + 10, 2);
                                        break;
                                    }
                                }
                            }

                            if (AutoItX.WinExists(StatusText.ErrorStateWin[0], StatusText.ErrorStateWin[1]) == 1)
                            {
                                AutoItX.Send(ButtonConstant.Enter);
                                AutoItX.Sleep(2000);
                                LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, fid, ActualStatus,
                                    StatusText.FidError);
                                AutoItX.MouseClick(ButtonConstant.MouseLeft,
                                    win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
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
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 70,
                win.WindowsAis.Y + win.Y1 + 35);
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
                    LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, fid, TechnicalUpdate,
                        WindowsAis3.DataNotFound);
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
                        win.ControlGetPos1(WindowsAis3.ControlPanel[0], WindowsAis3.ControlPanel[1],
                            WindowsAis3.ControlPanel[2]);
                        AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 85,
                            win.WindowsAis.Y + win.Y1 + 10, 2);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Уточнение платежей
        /// </summary>
        /// <param name="statusButton">Кнопка</param>
        public void Click10(StatusButtonMethod statusButton)
        {
            var libraryAutomation = new LibaryAutomations(WindowsAis3.AisNalog3);
            libraryAutomation.FindFirstElement(RashetBudElementName.DateGrid);
            var addObjectPl = new AddObjectDb();
            RegxStart regStart = new RegxStart();
            var listMemo = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindElement).Cast<AutomationElement>().Distinct().Where(elem => elem.Current.Name.Contains("List"));
            var listNotNull = listMemo.Where(elem => libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation.SelectAutomationColrction(elem)
                                                     .Cast<AutomationElement>().First(elemMemo => elemMemo.Current.Name.Contains("Номер расчетного документа (3)"))) != ""
                                                     && libraryAutomation.GetColorPixel(libraryAutomation.SelectAutomationColrction(elem)
                                                     .Cast<AutomationElement>().First(elemMemo => elemMemo.Current.Name.Contains("Состояние уточнения")))!= "e79621").ToArray();
            foreach (var automationElement in listNotNull)
            {
                    if (statusButton.Iswork)
                    {
                        var kbkOnKbk = new ModelKbkOnKbk();
                        automationElement.SetFocus();

                        kbkOnKbk.IdDoc = Convert.ToInt64(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                            libraryAutomation.SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Номер расчетного документа (3)"))));

                        kbkOnKbk.InnPayer = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                            libraryAutomation.SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("ИНН плательщика (60)"))).Trim();
                    
                        kbkOnKbk.KbkIfns = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                            libraryAutomation.SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("КБК (104)")));

                        kbkOnKbk.Kbk100Before = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                            libraryAutomation.SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>().First(elem => elem.Current.Name=="КБК"));

                        kbkOnKbk.Oktmo105 = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                            libraryAutomation.SelectAutomationColrction(automationElement).Cast<AutomationElement>()
                                .First(elem => elem.Current.Name.Contains("ОКТМО (ОКАТО) (105)")));

                    kbkOnKbk.OktmoUfk = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                            libraryAutomation.SelectAutomationColrction(automationElement).Cast<AutomationElement>()
                                .First(elem => elem.Current.Name =="ОКТМО (ОКАТО)"));


                    kbkOnKbk.TpPayerBefore = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                            libraryAutomation.SelectAutomationColrction(automationElement).Cast<AutomationElement>()
                                .First(elem => elem.Current.Name.Contains("Основание платежа (106)")));

                        kbkOnKbk.StatusPayerBefore = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                            libraryAutomation.SelectAutomationColrction(automationElement).Cast<AutomationElement>()
                                .First(elem => elem.Current.Name.Contains("Тип платежа (110)")));

                        kbkOnKbk.Payment = Convert.ToDecimal(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                            libraryAutomation.SelectAutomationColrction(automationElement)
                                .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Сумма (7)"))));

                        kbkOnKbk.InnBank = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("ИНН получателя (61)")));

                        kbkOnKbk.KppBank = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("КПП получателя (103)")));

                        if ((String.IsNullOrWhiteSpace(kbkOnKbk.Oktmo105) || Regex.Matches(kbkOnKbk.Oktmo105, @"(0{6})").Count > 0)|| (String.IsNullOrWhiteSpace(kbkOnKbk.OktmoUfk) || Regex.Matches(kbkOnKbk.OktmoUfk, @"(0{6})").Count > 0))
                        {
                            kbkOnKbk.StatusError = "#E80A0A";
                            kbkOnKbk.Conclusion = "Провести уточнение не возможно надо проверять ОКТМО!!!";
                            addObjectPl.AddModelKbkOnKbk(kbkOnKbk);
                        }
                        else
                        {
                            PublicGlobalFunction.WindowElementClick(libraryAutomation, RashetBudElementName.StartUtoch);
                            while (true)
                            {
                                if (libraryAutomation.IsEnableElements(RashetBudElementName.WindowsStartYes, null, true) != null)
                                {
                                    libraryAutomation.ClickElements(RashetBudElementName.WindowsStartYes, null, true);
                                    while(true)
                                    {
                                        if (libraryAutomation.IsEnableElements(RashetBudElementName.SendKbk, null, true) != null)
                                        {
                                            break;
                                        }
                                    }
                                    break;
                                }
                            }
                            if (regStart.UseNalog(libraryAutomation, kbkOnKbk))
                            {
                                PublicGlobalFunction.WindowElementClick(libraryAutomation, RashetBudElementName.Utverjdenie);
                                while (true)
                                {
                                    if (libraryAutomation.IsEnableElements(RashetBudElementName.WinUtoch, null, true) != null)
                                    {
                                        libraryAutomation.ClickElements(RashetBudElementName.WinUtoch, null, true);
                                        break;
                                    }
                                }
                                kbkOnKbk.StatusError = "#50D413";
                                kbkOnKbk.Conclusion = "Уточнение проведено успешно!!!";
                                addObjectPl.AddModelKbkOnKbk(kbkOnKbk);
                            }
                            else
                            {
                                //Выход из уточнения
                                PublicGlobalFunction.WindowElementClick(libraryAutomation, RashetBudElementName.ButtonNotUtoch);
                                while (true)
                                {
                                    if (libraryAutomation.IsEnableElements(RashetBudElementName.WinNotUtoch, null, true) != null)
                                    {
                                        libraryAutomation.ClickElements(RashetBudElementName.WinNotUtoch, null, true);
                                        break;
                                    }
                                }
                                kbkOnKbk.StatusError = "#E80A0A";
                                kbkOnKbk.Conclusion = "Не найдено КБК в БД логика не определена!!!";
                                addObjectPl.AddModelKbkOnKbk(kbkOnKbk);
                            }

                            //AutoItX.WinWait(Vedomost1Win.ViesneniePl[0], Vedomost1Win.ViesneniePl[1]);
                            //AutoItX.Send(ButtonConstant.Enter);

                            //while (true)
                            //{
                            //    if (libraryAutomation.IsEnableElements(RashetBudElementName.Utverjdenie) == null) continue;
                            //    libraryAutomation.ClickElements(RashetBudElementName.Utverjdenie);
                            //    break;
                            //}

                            //if ((AutoItX.WinWait(Vedomost1Win.Utoch[0], Vedomost1Win.Utoch[1], 1) == 1) || (AutoItX.WinWait(Vedomost1Win.Utoch2[0], Vedomost1Win.Utoch2[0], 1) == 1))
                            //{
                            //    AutoItX.Sleep(500);
                            //    AutoItX.Send(ButtonConstant.Enter);
                            //}
                            //if (regStart.InnPlatel.Length != 10)
                            //{
                            //    AutoItX.WinWait(Vedomost1Win.IsData[0], Vedomost1Win.IsData[1], 2);
                            //    AutoItX.Sleep(500);
                            //    AutoItX.Send(ButtonConstant.Enter);
                            //}
                            //AutoItX.WinWaitClose("АИС Налог-3 ПРОМ ", "Проведение уточнения");

                            //LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathJournalOk, regStart.RaschDoc + " Подставили КБК: " + regStart.KbkIfns + " вместо " + regStart.Kbk100, "Удалось спарсить");
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
            report.CodeIfns = ReadWindow.Read.Reades.ReadForm(
                AutoItX.WinExists(Migration.PeredachaOrPriem[0], Migration.PeredachaOrPriem[1]) == 1
                    ? Migration.CodeIfnsPeredacha
                    : Migration.CodeIfnsPriem);
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + 180, win.WindowsAis.Y + 75);
            AutoItX.WinWait(WindowsAis3.AisNalog3, Migration.MigrationNp, 2);
            if (!isparse)
            {
                while (true)
                {
                    AutoItX.Sleep(5000);
                    var isEnable = AutoItX.ControlCommand(AutoItX.WinGetHandle(Migration.Button[0]),
                        AutoItX.ControlGetHandle(AutoItX.WinGetHandle(Migration.Button[0]), Migration.Button[2]),
                        "IsEnabled", "");
                    if (isEnable == "1")
                    {
                        AutoItX.ControlClick(Migration.Button[0], Migration.Button[1], Migration.Button[2]);
                        break;
                    }

                    win.ControlGetPos1(WindowsAis3.UltraGridDataMigration[0], WindowsAis3.UltraGridDataMigration[1],
                        WindowsAis3.UltraGridDataMigration[2]);
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 45,
                        win.WindowsAis.Y + win.Y1 + 35);
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
                win.ControlGetPos1(WindowsAis3.UltraGridDataMigration[0], WindowsAis3.UltraGridDataMigration[1],
                    WindowsAis3.UltraGridDataMigration[2]);
                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 90,
                    win.WindowsAis.Y + win.Y1 + 35, 2);
                report.Date = ReadWindow.Read.Reades.ReadCtrlC();
                AutoItX.Send(ButtonConstant.Tab2);
                report.Stage = ReadWindow.Read.Reades.ReadCtrlC();
                AutoItX.Send(ButtonConstant.Tab2);
                report.Problem = ReadWindow.Read.Reades.ReadCtrlC();
                model.ReportMigration[0] = report;
                LibaryXMLAuto.ErrorJurnal.ReportMigration.CreateReportMigration(reportMigration, model);
            }

            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20,
                win.WindowsAis.Y + 160);
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

            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 70,
                win.WindowsAis.Y + win.Y1 + 35);
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
                    LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, idvisual, FaceRosreestr,
                        WindowsAis3.DataNotFound);
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
                        AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 655,
                            win.WindowsAis.Y + win.Y1 + 55);
                        AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 70,
                            win.WindowsAis.Y + win.Y1 + 35);
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

                                AutoItX.MouseClick(ButtonConstant.MouseLeft,
                                    win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                                LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, idvisual,
                                    FaceRosreestr, WindowsAis3.DataNotFound);
                                break;
                            }

                            if (AutoItX.WinExists(WindowsAis3.AisNalog3, IdFace.IdFl) == 1)
                            {
                                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + 330,
                                    win.WindowsAis.Y + 80);
                                AutoItX.Send(ButtonConstant.Down1);
                                AutoItX.Send(ButtonConstant.Enter);
                                AutoItX.WinWait(IdFace.WinInfo[0], IdFace.WinInfo[1]);
                                if (AutoItX.WinExists(IdFace.WinInfo[0], IdFace.WinInfo[1]) == 1)
                                {
                                    AutoItX.Send(ButtonConstant.Enter);
                                    AutoItX.MouseClick(ButtonConstant.MouseLeft,
                                        win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
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
                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 355,
                    win.WindowsAis.Y + win.Y1 + 80);
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
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 45,
                win.WindowsAis.Y + win.Y1 + 80);
            AutoItX.WinWait(WindowsAis3.AisNalog3, NboText.TitelList, 15);
            while (true)
            {
                AutoItX.WinWait(NboText.Protokol[0], NboText.Protokol[1], 2);
                var texthieden = ReadWindow.Read.Reades.HidenTextReturn(WindowsAis3.AisNalog3);
                if (AutoItX.WinExists(NboText.Protokol[0], NboText.Protokol[1]) == 1)
                {
                    AutoItX.Send(ButtonConstant.Enter);
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20,
                        win.WindowsAis.Y + 160);
                    break;
                }

                if (AutoItX.WinExists(NboText.TitleError2[0], NboText.TitleError2[1]) == 1)
                {
                    AutoItX.Send(ButtonConstant.Enter);
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20,
                        win.WindowsAis.Y + 160);
                    break;
                }

                if (texthieden.Contains(NboText.Strfind) || texthieden.Contains(NboText.Strfind2))
                {
                    win.ControlGetPos1(WindowsAis3.WinRequest[0], WindowsAis3.WinRequest[1], WindowsAis3.WinRequest[2]);
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 815,
                        win.WindowsAis.Y + win.Y1 + 80);
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
                            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20,
                                win.WindowsAis.Y + 160);
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
                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 355,
                    win.WindowsAis.Y + win.Y1 + 80);
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
                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 790,
                    win.WindowsAis.Y + win.Y1 + usn.IsOpen);
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
                        LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathjurnalerror, card.Id, Usn,
                            card.DescriptionError);
                        AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20,
                            win.WindowsAis.Y + 160);
                        AutoItX.Sleep(1000);
                        AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20,
                            win.WindowsAis.Y + 160);
                        AutoItX.WinWait(UsnText.UserWork[0], UsnText.UserWork[1], 5);
                        AutoItX.Send(ButtonConstant.Enter);
                        break;
                    }
                    else
                    {
                        AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + 120, win.WindowsAis.Y + 80);
                        AutoItX.WinWaitClose(WindowsAis3.AisNalog3, UsnText.TitleUsn, 15);
                        AutoItX.Sleep(1000);
                        AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 170,
                            win.WindowsAis.Y + win.Y1 + usn.Sender);
                        AutoItX.WinWait(UsnText.VvodVxod[0], UsnText.VvodVxod[1], 15);
                        AutoItX.Send(ButtonConstant.Enter);
                        AutoItX.Sleep(3000);
                        AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 160,
                            win.WindowsAis.Y + win.Y1 + usn.Finish);
                        AutoItX.Sleep(3000);
                        LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathjurnalok, card.Id, "Обработали без ошибок!!!");
                        break;
                    }
                }
            }

            return Status.StatusAis.Status3;
        }

        /// <summary>
        /// Автоматизация считывания данных заявок для ролей
        /// </summary>
        /// <param name="statusButton">Статус для приостановки</param>
        /// <param name="pathJournalOk">Путь к сохранению</param>
        /// <param name="dataPickerSettings">Параметры для автомата</param>
        public void Click15(StatusButtonMethod statusButton, string pathJournalOk,
            DataPickerRuleItModel dataPickerSettings)
        {
            string dates = null;
            UserRules userRule = new UserRules();
            int j = 0;
            LibaryAutomations libraryAutomation = new LibaryAutomations(WindowsAis3.AisNalog3);
            libraryAutomation.FindFirstElement(ItElementName.PanelDocksCountRow);
            libraryAutomation.SetValuePattern(dataPickerSettings.CountRow);
            libraryAutomation.FindFirstElement(ItElementName.PanelDocksDbStart);
            libraryAutomation.SetValuePattern(dataPickerSettings.DateStart.ToString("dd.MM.yyyy"));
            libraryAutomation.FindFirstElement(ItElementName.PanelDocksDbFinish);
            libraryAutomation.SetValuePattern(dataPickerSettings.DateFinish.ToString("dd.MM.yyyy"));
            libraryAutomation.FindFirstElement(PublicElementName.UpdateButton);
            libraryAutomation.InvokePattern(libraryAutomation.FindElement);
            libraryAutomation.IsEnableElements(ItElementName.GridJournal);
            var i = 1;
            while (libraryAutomation.FindFirstElement(string.Format(ItElementName.GridJournalRows, i)) != null)
            {
                i++;
                if (statusButton.Iswork)
                {
                    var listMemo = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindElement);
                    foreach (AutomationElement element in listMemo)
                    {
                        if (element.Current.Name == "Дата")
                        {
                            dates = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(element);
                        }

                        if (element.Current.Name == "Номер")
                        {
                            libraryAutomation.FindFirstElement(PublicElementName.ViewButton);
                            libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                            libraryAutomation.IsEnableElements(ItElementName.HistoryJournal);
                            var historyJournals = libraryAutomation
                                .SelectAutomationColrction(libraryAutomation.FindElement).Cast<AutomationElement>()
                                .Where(elem => elem.Current.Name.Contains("List"));
                            foreach (var history in historyJournals)
                            {
                                var historyRule = libraryAutomation.SelectAutomationColrction(history);
                                if (historyRule.Cast<AutomationElement>()
                                    .Any(elem => elem.Current.Name.Contains("Appointments")))
                                {
                                    userRule.User = new User[1];
                                    userRule.User[0] = new User
                                    {
                                        Dolj = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                            libraryAutomation.FindFirstElement(ItElementName.Doljnost)),
                                        Fio = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                            libraryAutomation.FindFirstElement(ItElementName.Name)),
                                        Otdel = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                            libraryAutomation.FindFirstElement(ItElementName.Department)),
                                        SysName = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                            libraryAutomation.FindFirstElement(ItElementName.Logon)),
                                        Number =
                                            libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(element),
                                        Dates = dates
                                    };
                                    var listHistory = historyRule.Cast<AutomationElement>()
                                        .Where(elem => elem.Current.Name.Contains("Appointments"));
                                    foreach (AutomationElement rule in listHistory)
                                    {
                                        //Формируем заявку поиск пользователя
                                        var allElements = libraryAutomation.SelectAutomationColrction(rule);
                                        foreach (var rules in allElements.Cast<AutomationElement>())
                                        {
                                            if (userRule.User[0].Rule == null)
                                            {
                                                userRule.User[0].Rule = new Rule[listHistory.Count()];
                                            }

                                            if (userRule.User[0].Rule[j] == null)
                                            {
                                                userRule.User[0].Rule[j] = new Rule();
                                            }

                                            //Разбор ролей
                                            var valueless = libraryAutomation
                                                .ParseElementLegacyIAccessiblePatternIdentifiers(rules);
                                            switch (rules.Current.Name)
                                            {
                                                case "Наименование":
                                                    userRule.User[0].Rule[j].Name = valueless;
                                                    break;
                                                case "Тип":
                                                    userRule.User[0].Rule[j].Types = valueless;
                                                    break;
                                                case "Действие":
                                                    userRule.User[0].Rule[j].Pushed = valueless;
                                                    break;
                                                case "Дата начала":
                                                    userRule.User[0].Rule[j].DateStart = valueless;
                                                    break;
                                                case "Дата окончания":
                                                    userRule.User[0].Rule[j].DateFinish = valueless;
                                                    break;
                                                case "Контекст":
                                                    userRule.User[0].Rule[j].Context = valueless;
                                                    break;
                                            }
                                        }

                                        j++;
                                    }
                                }

                                libraryAutomation.FindFirstElement(PublicElementName.BackButton);
                                libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                                break;
                            }

                            j = 0;
                            break;
                        }
                    }

                    LibaryXMLAuto.ErrorJurnal.ReportMigration.CreateFileRule(pathJournalOk, userRule);
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
        /// <param name="pathJournalError">Путь к журналу ошибочных</param>
        /// <param name="pathJournalOk">Путь к журналу отработанных</param>
        public string Click16(string pathJournalError, string pathJournalOk)
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
            while ((elemental = libraryAutomation.IsEnableElements(SettlementDebts.JournalDocuments, null, true)) !=
                   null)
            {
                if (statusButton.Iswork)
                {
                    libraryAutomation.IsEnableElements(SettlementDebts.SumT, elemental);
                    libraryAutomation.FindElement.SetFocus();
                    libraryAutomation.FindFirstElement(PublicElementName.StartBeforeQ);
                    var climbablePoint = libraryAutomation.FindElement.GetClickablePoint();
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, (int) climbablePoint.X, (int) climbablePoint.Y);
                    libraryAutomationCheck.IsEnableElements(SettlementDebts.JournalSum, null, true);
                    var isChecked = false;
                    while (true)
                    {
                        if (isChecked)
                        {
                            if (libraryAutomation.IsEnableElements(SluzZ.WinErrorNalog, null, false, 5) != null)
                            {
                                libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                                libraryAutomation.ClickElements(SettlementDebts.ButtonSettlement);
                            }
                            break;
                        }
                        if (libraryAutomation.IsEnableElements(SettlementDebts.ButtonSettlement) == null) continue;
                        libraryAutomation.ClickElements(SettlementDebts.ButtonSettlement);
                        isChecked = true;
                    }
                    while (true)
                    {
                        if (libraryAutomation.IsEnableElements(SluzZ.WinCloseNalog, null, false, 1) != null)
                        {
                            libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                            break;
                        }

                        if (libraryAutomation.IsEnableElements(SettlementDebts.ButtonSend, null, false, 1) == null) continue;
                        libraryAutomation.ClickElements(SettlementDebts.ButtonSend);
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
        /// <param name="pathJournalOk">Путь сохранения отработанных</param>
        public void Click18(StatusButtonMethod statusButton, string pathJournalOk)
        {
            LibaryAutomations libraryAutomation = new LibaryAutomations(WindowsAis3.AisNalog3);
            AutomationElement elementAuto;
            while ((elementAuto =
                       libraryAutomation.IsEnableElements(RegistrationElementName.JurnalsDocumentsFirstElement, null,
                           true)) != null)
            {
                if (statusButton.Iswork)
                {
                    libraryAutomation.IsEnableElements(RegistrationElementName.Doc, elementAuto);
                    libraryAutomation.FindElement.SetFocus();
                    var id = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                        .FindElement);
                    libraryAutomation.FindFirstElement(RegistrationElementName.IsErrorDocument);
                    var clickPoint = libraryAutomation.FindElement.GetClickablePoint();
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, (int) clickPoint.X, (int) clickPoint.Y);
                    libraryAutomation.IsEnableElements(RegistrationElementName.Qweshions);
                    libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                    libraryAutomation.IsEnableElements(RegistrationElementName.ErrorsCreate);
                    libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                    libraryAutomation.IsEnableElements(RegistrationElementName.ErrorsOk);
                    libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                    libraryAutomation.IsEnableElements(RegistrationElementName.ErrorsCancel);
                    libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                    libraryAutomation.IsEnableElements(RegistrationElementName.Qweshions);
                    libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                    libraryAutomation.IsEnableElements(RegistrationElementName.WinOk);
                    libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                    LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathJournalOk, id,
                        "Отработали Ун входящего без ошибок");
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
        /// <param name="pathJournalOk">Путь к отработанным значениям</param>
        public void Click19(StatusButtonMethod statusButton, string pathJournalOk)
        {
            var libraryAutomation = new LibaryAutomations(WindowsAis3.AisNalog3);
            while (libraryAutomation.IsEnableElements(UregulirovanieElementName.JurnalsUserOperationSpravki) != null)
            {
                if (statusButton.Iswork)
                {
                    var clickRows = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindElement)
                        .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Имя задания"))
                        .GetClickablePoint();
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, (int) clickRows.X, (int) clickRows.Y);
                    libraryAutomation.FindFirstElement(PublicElementName.StartUser);
                    var clickPoint = libraryAutomation.FindElement.GetClickablePoint();
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, (int) clickPoint.X, (int) clickPoint.Y);
                    AutoItX.WinWait("АИС Налог-3 ПРОМ ", "ИНН:");
                    var inn = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation.IsEnableElements(UregulirovanieElementName.InnResh));
                    var fio = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation.IsEnableElements(UregulirovanieElementName.FioResh));
                    var sum = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation.IsEnableElements(UregulirovanieElementName.SummResh));
                    libraryAutomation.IsEnableElements(UregulirovanieElementName.SaveUser);
                    var clickPoint1 = libraryAutomation.FindElement.GetClickablePoint();
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, (int) clickPoint1.X, (int) clickPoint1.Y);
                    while (true)
                    {
                        if (libraryAutomation.IsEnableElements(UregulirovanieElementName.WinOk, null, true, 1) != null)
                        {
                            libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                            break;
                        }

                        if (libraryAutomation.IsEnableElements(UregulirovanieElementName.SendSenderZadoljenost, null,
                                true, 1) != null)
                        {
                            var clickPoint2 = libraryAutomation.FindElement.GetClickablePoint();
                            AutoItX.MouseClick(ButtonConstant.MouseLeft, (int) clickPoint2.X, (int) clickPoint2.Y);
                        }
                    }

                    LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathJournalOk, $"{sum} {inn} {fio}",
                        "Отработали Подписание решения о признании недоимки и задолженности безнадежными к взысканию");
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
        /// <param name="pathJournalOk">Путь к отработанным значениям</param>
        public void Click20(StatusButtonMethod statusButton, string pathJournalOk)
        {
            var libraryAutomation = new LibaryAutomations(WindowsAis3.AisNalog3);

            while (libraryAutomation.IsEnableElements(UregulirovanieElementName.JurnalsUserOperationSpravki) != null)
            {
                if (statusButton.Iswork)
                {
                    var clickRows = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindElement)
                        .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Имя задания"))
                        .GetClickablePoint();
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, (int) clickRows.X, (int) clickRows.Y);
                    libraryAutomation.FindFirstElement(PublicElementName.StartUser);
                    var clickPoint = libraryAutomation.FindElement.GetClickablePoint();
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, (int) clickPoint.X, (int) clickPoint.Y);
                    AutoItX.WinWait("АИС Налог-3 ПРОМ ", "ИНН:");
                    var num = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation.IsEnableElements(UregulirovanieElementName.Number));
                    var inn = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation.IsEnableElements(UregulirovanieElementName.Inn));
                    var fio = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation.IsEnableElements(UregulirovanieElementName.Fio));
                    libraryAutomation.IsEnableElements(UregulirovanieElementName.SaveUser);
                    AutoItX.Sleep(500);
                    var clickPoint1 = libraryAutomation.FindElement.GetClickablePoint();
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, (int) clickPoint1.X, (int) clickPoint1.Y);
                    while (true)
                    {
                        if (libraryAutomation.IsEnableElements(UregulirovanieElementName.SendSender, null, true, 1) !=
                            null)
                        {
                            break;
                        }

                        if (libraryAutomation.IsEnableElements(UregulirovanieElementName.SaveProject, null, true, 1) !=
                            null)
                        {
                            var clickPoint2 = libraryAutomation.FindElement.GetClickablePoint();
                            AutoItX.MouseClick(ButtonConstant.MouseLeft, (int) clickPoint2.X, (int) clickPoint2.Y);
                        }
                    }

                    while (true)
                    {
                        if (libraryAutomation.IsEnableElements(UregulirovanieElementName.WinOkExeptions, null, true,
                                1) != null)
                        {
                            libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                        }

                        if (libraryAutomation.IsEnableElements(UregulirovanieElementName.WinOk, null, true, 1) != null)
                        {
                            libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                            break;
                        }

                        if (libraryAutomation.IsEnableElements(UregulirovanieElementName.SendSender, null, true, 1) !=
                            null)
                        {
                            var clickPoint3 = libraryAutomation.FindElement.GetClickablePoint();
                            AutoItX.MouseClick(ButtonConstant.MouseLeft, (int) clickPoint3.X, (int) clickPoint3.Y);
                        }
                    }

                    LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathJournalOk, $"{num} {inn} {fio}",
                        "Отработали Подписание справки о суммах недоимки");
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
        /// <param name="pathJournalError">Журнал ошибок</param>
        /// <param name="pathJournalOk">Журнал сделанных</param>
        public void Click21(string id, string pathJournalError, string pathJournalOk)
        {
            WindowsAis3 win = new WindowsAis3();
            var libraryAutomation = new LibaryAutomations(WindowsAis3.AisNalog3);
            win.ControlGetPos1(WindowsAis3.WinGrid[0], WindowsAis3.WinGrid[1], WindowsAis3.WinGrid[2]);
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 70,
                win.WindowsAis.Y + win.Y1 + 35);
            AutoItX.ClipPut(id);
            AutoItX.Send(ButtonConstant.Down3);
            AutoItX.Send(ButtonConstant.Right5);
            AutoItX.Send(ButtonConstant.Enter);
            AutoItX.Send(ButtonConstant.CtrlV);
            while (true)
            {
                if (libraryAutomation.ClickElements(RegistrationElementNameVisualBank.UpdateButton, null, false, 1))
                {
                    if (libraryAutomation.IsEnableElements(
                            RegistrationElementNameVisualBank.JurnalsDocumentsFirstElementBank, null, true) != null)
                    {
                        libraryAutomation.FindElement.SetFocus();
                        if (libraryAutomation.ClickElements(RegistrationElementNameVisualBank.Identification, null,
                            false, 5))
                        {
                            while (true)
                            {
                                if (libraryAutomation.ClickElements(RegistrationElementNameVisualBank
                                    .StartIdentification))
                                {
                                    while (true)
                                    {
                                        if (libraryAutomation.IsEnableElements(RegistrationElementNameVisualBank.WinOk,
                                                null, true, 1) != null)
                                        {
                                            libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                                        }

                                        if (libraryAutomation.IsEnableElements(
                                                RegistrationElementNameVisualBank.WinOkEnd, null, true, 1) != null)
                                        {
                                            libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                                            if (libraryAutomation.ClickElements(
                                                RegistrationElementNameVisualBank.Return))
                                            {
                                                break;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathJournalError, id, VisualBank,
                                        "Не удаётся идентифицировать лицо. Лицо не найдено!");
                                    libraryAutomation.ClickElements(RegistrationElementNameVisualBank.ReturnList, null,
                                        false, 10);
                                    if (libraryAutomation.ClickElements(RegistrationElementNameVisualBank.Return, null,
                                        false, 10))
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
                        LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathJournalError, id, VisualBank,
                            "Не найдено значение для идентификации");
                        if (libraryAutomation.ClickElements(RegistrationElementNameVisualBank.Return, null, false, 10))
                        {
                            return;
                        }
                    }
                }
            }

            LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathJournalOk, id, "Отработали идентификацию успешно!");
        }

        /// <summary>
        /// Налоговое администрирование\Урегулирование задолженности\Требования об уплате\Журнал требований об уплате
        /// Проставление информации о вручении +3 дня от подачи
        /// </summary>
        /// <param name="statusButton">Запуск остановка</param>
        /// <param name="pathJournalError">Журнал ошибок</param>
        /// <param name="pathJournalOk">Журнал отработанных</param>
        public void Click22(StatusButtonMethod statusButton, string pathJournalError, string pathJournalOk)
        {
            var libraryAutomation = new LibaryAutomations(WindowsAis3.AisNalog3);
            libraryAutomation.FindFirstElement(Trebovanie.JurnalsTrebovanie);
            var listMemo = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindElement)
                .Cast<AutomationElement>().Where(elem => elem.Current.Name.Contains("select0 row"));
            foreach (var automationElement in listMemo)
            {
                if (statusButton.Iswork)
                {
                    automationElement.SetFocus();
                    var valueDate = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                        .SelectAutomationColrction(automationElement)
                        .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Дата ТУ")));

                    var valueNumber = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Номер ТУ")));

                    var valueInn = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                        .SelectAutomationColrction(automationElement)
                        .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("ИНН")));

                    var valueTypeNp = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Категория НП")));

                    var valueStatusEnd = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Способ вручения")));

                    libraryAutomation.ClickElements(Trebovanie.ListPanel);
                    if (libraryAutomation.ClickElements(Trebovanie.Open, null, false, 5))
                    {
                        while (true)
                        {
                            if (libraryAutomation.IsEnableElements(Trebovanie.Save) != null)
                            {
                                libraryAutomation.ClickElements(Trebovanie.TabIfo, null, false, 10);
                                libraryAutomation.SelectItemCombobox(libraryAutomation.IsEnableElements(Trebovanie.ComboBoxSelect),"Вручено");
                                var dateVAdd = Convert.ToDateTime(valueDate).AddDays(valueTypeNp == "ФЛ" ? 5 : 3);
                                if (dateVAdd.DayOfWeek == DayOfWeek.Saturday)
                                    dateVAdd = dateVAdd.AddDays(2);
                                if (dateVAdd.DayOfWeek == DayOfWeek.Sunday)
                                    dateVAdd = dateVAdd.AddDays(1);
                                while (true)
                                {
                                    if (libraryAutomation.IsEnableElements(Trebovanie.Date) == null) continue;
                                    libraryAutomation.SetValuePattern(dateVAdd.ToString("dd.MM.yy"));
                                    var date = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                        libraryAutomation.FindElement);
                                    if (date != "")
                                    {
                                        break;
                                    }
                                }
                                if (valueStatusEnd != "Направлено письмом" & valueTypeNp == "ФЛ")
                                {
                                    libraryAutomation.SelectItemCombobox(libraryAutomation.IsEnableElements(Trebovanie.ComboboxSend),"Направлено письмом");
                                }
                                if (valueStatusEnd != "По каналам ТКС" & valueTypeNp != "ФЛ")
                                {
                                    libraryAutomation.SelectItemCombobox(libraryAutomation.IsEnableElements(Trebovanie.ComboboxSend),"По каналам ТКС");
                                }
                                while (true)
                                {
                                    if (libraryAutomation.IsEnableElements(Trebovanie.Save) == null) continue;
                                    libraryAutomation.ClickElements(Trebovanie.Save);
                                    break;
                                }
                                while (true)
                                {
                                    if (libraryAutomation.IsEnableElements(Trebovanie.Back) == null) continue;
                                    libraryAutomation.ClickElements(Trebovanie.Back);
                                    break;
                                }
                                LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathJournalOk,
                                    $"Номер ТУ: {valueNumber}; Тип лица:{valueTypeNp} Дата ТУ: {valueDate}; Дата вручения: {dateVAdd}; ИНН Налогоплательщика: {valueInn}",
                                    "Проставили вручение успешно!");
                                break;
                            }
                            if (libraryAutomation.IsEnableElements(Trebovanie.Back) != null)
                            {
                                //Запись лога что сохранили не доступно
                                LibaryXMLAuto.ErrorJurnal.ErrorJurnal.JurnalError(pathJournalError, valueNumber,
                                    LogTreb, "Не активна кнопка сохранить!");
                                libraryAutomation.ClickElements(Trebovanie.Back, null, false, 10);
                                break;
                            }
                        }
                    }
                }

            }
        }

        /// <summary>
        /// Урегулирование задолженности/05.09 Уведомление о необходимости выгрузки документов в ЛК\
        /// 05.09 Сообщения о принятом решении об отказе  подлежащие выгрузке в ЛК
        /// </summary>
        /// <param name="statusButton">Запуск остановка</param>
        /// <param name="pathJournalError">Журнал ошибок</param>
        /// <param name="pathJournalOk">Журнал отработанных</param>
        public void Click23(StatusButtonMethod statusButton, string pathJournalError, string pathJournalOk)
        {
            LibaryAutomations libraryAutomation = new LibaryAutomations(WindowsAis3.AisNalog3);
            LibaryAutomations libraryAutomationCheck = new LibaryAutomations(WindowsAis3.AisNalog3);
            AutomationElement elemental;
            while ((elemental = libraryAutomation.IsEnableElements(RecouncementLk.JurnalsRecouncement, null, true)) !=
                   null)
            {
                if (statusButton.Iswork)
                {
                    var inn = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation.IsEnableElements(RecouncementLk.RowInn, elemental));
                    libraryAutomation.FindElement.SetFocus();
                    libraryAutomation.FindFirstElement(PublicElementName.StartUser);
                    var climbablePoint = libraryAutomation.FindElement.GetClickablePoint();
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, (int) climbablePoint.X, (int) climbablePoint.Y);
                    var isChecked = "";
                    while (true)
                    {
                        if (isChecked == "" || string.IsNullOrWhiteSpace(isChecked))
                        {
                            isChecked = libraryAutomationCheck.ParseElementLegacyIAccessiblePatternIdentifiers(
                                libraryAutomationCheck.IsEnableElements(RecouncementLk.CheckDataLk2));
                            if (isChecked != "") break;
                        }

                        if (libraryAutomation.IsEnableElements(RecouncementLk.CheckStatusLk2) == null) continue;
                        libraryAutomation.ClickElements(RecouncementLk.CheckStatusLk2);
                    }

                    while (true)
                    {
                        if (libraryAutomation.IsEnableElements(RecouncementLk.WinOkEndUser, null, true, 1) != null)
                        {
                            libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                            break;
                        }

                        if (libraryAutomation.IsEnableElements(RecouncementLk.CheckExit, null, true) == null) continue;
                        libraryAutomation.ClickElements(RecouncementLk.CheckExit);
                    }

                    LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathJournalOk,
                        $"ИНН Налогоплательщика: {inn}; Дата вручения: {isChecked}",
                        "Проставили признак отправки в ЛК успешно!");
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
        /// <param name="pathJournalError">Журнал ошибок</param>
        /// <param name="pathJournalOk">Журнал отработанных</param>
        public void Click24(StatusButtonMethod statusButton, string pathJournalError, string pathJournalOk)
        {
            LibaryAutomations libraryAutomation = new LibaryAutomations(WindowsAis3.AisNalog3);
            LibaryAutomations libraryAutomationCheck = new LibaryAutomations(WindowsAis3.AisNalog3);
            while ((libraryAutomation.IsEnableElements(SignatureHeadProperty.JournalSignature, null, true)) != null)
            {
                if (statusButton.Iswork)
                {
                    libraryAutomation.FindFirstElement(PublicElementName.StartUser);
                    var climbablePoint = libraryAutomation.FindElement.GetClickablePoint();
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, (int) climbablePoint.X, (int) climbablePoint.Y);
                    var isChecked = false;
                    while (true)
                    {
                        if (isChecked)
                        {
                            break;
                        }

                        if (libraryAutomation.IsEnableElements(SignatureHeadProperty.ButtonSignatureAll) == null)
                            continue;
                        libraryAutomation.ClickElements(SignatureHeadProperty.ButtonSignatureAll);
                        isChecked = true;
                    }

                    while (true)
                    {
                        if (libraryAutomation.IsEnableElements(SignatureHeadProperty.WinExit, null, true, 1) != null)
                        {
                            libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                            break;
                        }

                        if (libraryAutomation.IsEnableElements(SignatureHeadProperty.EndSignature, null, true) ==
                            null) continue;

                        var listMemo = libraryAutomation
                            .SelectAutomationColrction(
                                libraryAutomationCheck.IsEnableElements(SignatureHeadProperty.JoirnalAllSignature))
                            .Cast<AutomationElement>().Where(elem => elem.Current.Name.Contains("List"));
                        foreach (var data in listMemo)
                        {
                            var valuesInn = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                libraryAutomation
                                    .SelectAutomationColrction(data).Cast<AutomationElement>()
                                    .First(elem => elem.Current.Name.Contains("ИНН")));
                            var valuesAddress = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                libraryAutomation
                                    .SelectAutomationColrction(data).Cast<AutomationElement>()
                                    .First(elem => elem.Current.Name.Contains("Адрес")));
                            var valuesScore = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                libraryAutomation
                                    .SelectAutomationColrction(data).Cast<AutomationElement>()
                                    .First(elem => elem.Current.Name.Contains("Всего")));
                            var valuesFio = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                libraryAutomation
                                    .SelectAutomationColrction(data).Cast<AutomationElement>().First(elem =>
                                        elem.Current.Name.Contains("ФИО налогоплательщика")));

                            LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathJournalOk,
                                $"ИНН Налогоплательщика: {valuesInn}; ФИО НО: {valuesFio} Адрес: {valuesAddress}; Сумма: {valuesScore} ",
                                "Подписали руководителем успешно успешно!");
                        }

                        libraryAutomation.ClickElements(SignatureHeadProperty.EndSignature);
                    }
                }
                else
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Автоматизация Общие задания\Урегулирование задолженности\05.08.09.02.
        /// Взыскание задолженности за счет имущества НП ФЛ.Формирование Служебной записки и Заявлений о взыскании за счет имущества ФЛ\05.08.09.02.02 
        /// Утверждение и подписание Служебных записок\05.08.09.02.02.04. Утверждение Служебной записки
        /// Автомат для утверждения служебной записки
        /// </summary>
        /// <param name="statusButton">Запуск остановка</param>
        /// <param name="pathJournalError">Журнал ошибок</param>
        /// <param name="pathJournalOk">Журнал отработанных</param>
        public void Click25(StatusButtonMethod statusButton, string pathJournalError, string pathJournalOk)
        {
            LibaryAutomations libraryAutomation = new LibaryAutomations(WindowsAis3.AisNalog3);
            LibaryAutomations libraryAutomationCheck = new LibaryAutomations(WindowsAis3.AisNalog3);
            while ((libraryAutomation.IsEnableElements(TextStatementOfficeNote.JournalStatementOffice, null, true)) !=
                   null)
            {
                if (statusButton.Iswork)
                {
                    var isChecked = false;
                    libraryAutomation.FindFirstElement(PublicElementName.StartUser);
                    var climbablePoint = libraryAutomation.FindElement.GetClickablePoint();
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, (int) climbablePoint.X, (int) climbablePoint.Y);
                    while (true)
                    {
                        libraryAutomation.IsEnableElements(TextStatementOfficeNote.IsCheck);
                        libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                        if (libraryAutomation.TogglePattern(libraryAutomation.FindElement) == "On")
                        {
                            break;
                        }
                    }

                    while (true)
                    {
                        if (isChecked)
                        {
                            break;
                        }

                        if (libraryAutomation.IsEnableElements(TextStatementOfficeNote.ButtonIsCheckAll) == null)
                            continue;
                        libraryAutomation.ClickElements(TextStatementOfficeNote.ButtonIsCheckAll);
                        isChecked = true;
                    }

                    while (true)
                    {
                        if (libraryAutomation.IsEnableElements(TextStatementOfficeNote.WinExit, null, true, 1) != null)
                        {
                            libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                            break;
                        }

                        if (libraryAutomation.IsEnableElements(TextStatementOfficeNote.Exit, null, true) == null)
                            continue;
                        var listMemo = libraryAutomation
                            .SelectAutomationColrction(
                                libraryAutomationCheck.IsEnableElements(TextStatementOfficeNote
                                    .JournalAllStatementOffice)).Cast<AutomationElement>()
                            .Where(elem => elem.Current.Name.Contains("List"));
                        foreach (var data in listMemo)
                        {
                            var valuesInn = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                libraryAutomation
                                    .SelectAutomationColrction(data).Cast<AutomationElement>()
                                    .First(elem => elem.Current.Name.Contains("ИНН")));
                            var valuesAddress = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                libraryAutomation
                                    .SelectAutomationColrction(data).Cast<AutomationElement>()
                                    .First(elem => elem.Current.Name.Contains("Адрес")));
                            var valuesScore = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                libraryAutomation
                                    .SelectAutomationColrction(data).Cast<AutomationElement>()
                                    .First(elem => elem.Current.Name.Contains("Всего")));
                            var valuesFio = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                libraryAutomation
                                    .SelectAutomationColrction(data).Cast<AutomationElement>().First(elem =>
                                        elem.Current.Name.Contains("ФИО налогоплательщика")));
                            LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathJournalOk,
                                $"ИНН Налогоплательщика: {valuesInn}; ФИО НО: {valuesFio} Адрес: {valuesAddress}; Сумма: {valuesScore} ",
                                "Утверждение руководителем служебной записки прошло успешно!");
                        }
                        libraryAutomation.ClickElements(TextStatementOfficeNote.Exit);
                    }
                }
                else
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Автоматизация Общие задания\Урегулирование задолженности\05.08.09.02. Взыскание задолженности за счет имущества НП ФЛ. 
        /// Формирование Служебной записки и Заявлений о взыскании за счет имущества ФЛ\
        /// 05.08.09.02.02 Утверждение и подписание Служебных записок\05.08.09.02.02.06. Подписание Служебной записки
        /// </summary>
        /// <param name="statusButton">Запуск остановка</param>
        /// <param name="pathJournalError">Журнал ошибок</param>
        /// <param name="pathJournalOk">Журнал отработанных</param>
        public void Click26(StatusButtonMethod statusButton, string pathJournalError, string pathJournalOk)
        {
            LibaryAutomations libraryAutomation = new LibaryAutomations(WindowsAis3.AisNalog3);
            LibaryAutomations libraryAutomationCheck = new LibaryAutomations(WindowsAis3.AisNalog3);
            while ((libraryAutomation.IsEnableElements(TextSignatureOfficeNote.JournalSignatureOffice, null, true)) != null)
            {
                if (statusButton.Iswork)
                {
                    var isChecked = false;
                    libraryAutomation.FindFirstElement(PublicElementName.StartUser);
                    var climbablePoint = libraryAutomation.FindElement.GetClickablePoint();
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, (int) climbablePoint.X, (int) climbablePoint.Y);
                    while (true)
                    {
                        libraryAutomation.IsEnableElements(TextSignatureOfficeNote.IsCheck);
                        libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                        if (libraryAutomation.TogglePattern(libraryAutomation.FindElement) == "On")
                        {
                            break;
                        }
                    }
                    while (true)
                    {
                        if (isChecked)
                        {
                            break;
                        }
                        if (libraryAutomation.IsEnableElements(TextSignatureOfficeNote.ButtonIsCheckAll) == null)
                            continue;
                        libraryAutomation.ClickElements(TextSignatureOfficeNote.ButtonIsCheckAll);
                        isChecked = true;
                    }
                    while (true)
                    {
                        if (libraryAutomation.IsEnableElements(TextSignatureOfficeNote.WinExit, null, true, 1) != null)
                        {
                            libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                            break;
                        }
                        if (libraryAutomation.IsEnableElements(TextSignatureOfficeNote.Exit, null, true) == null)
                            continue;
                        var listMemo = libraryAutomation
                            .SelectAutomationColrction(
                                libraryAutomationCheck.IsEnableElements(TextSignatureOfficeNote
                                    .JournalAllStatementOffice)).Cast<AutomationElement>()
                            .Where(elem => elem.Current.Name.Contains("List"));
                        foreach (var data in listMemo)
                        {
                            var valuesInn = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                libraryAutomation
                                    .SelectAutomationColrction(data).Cast<AutomationElement>()
                                    .First(elem => elem.Current.Name.Contains("ИНН")));
                            var valuesAddress = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                libraryAutomation
                                    .SelectAutomationColrction(data).Cast<AutomationElement>()
                                    .First(elem => elem.Current.Name.Contains("Адрес")));
                            var valuesScore = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                libraryAutomation
                                    .SelectAutomationColrction(data).Cast<AutomationElement>()
                                    .First(elem => elem.Current.Name.Contains("Всего")));
                            var valuesFio = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                                libraryAutomation
                                    .SelectAutomationColrction(data).Cast<AutomationElement>().First(elem =>
                                        elem.Current.Name.Contains("ФИО налогоплательщика")));
                            LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathJournalOk,
                                $"ИНН Налогоплательщика: {valuesInn}; ФИО НО: {valuesFio} Адрес: {valuesAddress}; Сумма: {valuesScore} ",
                                "Подписание руководителем служебной записки прошло успешно!");
                        }
                        libraryAutomation.ClickElements(TextSignatureOfficeNote.Exit);
                    }
                }
                else
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Автомат для ветки Налоговое администрирование\Контрольная работа (налоговые проверки)\129. Налоговые правонарушения\2. Журнал налоговых правонарушений
        /// </summary>
        /// <param name="statusButton">Кнопка Старт</param>
        /// <param name="pathJournalOk">Журнал</param>
        /// <param name="pathPdfTemp">Путь к Temp</param>
        /// <param name="datePicker">Дата вызова плательщика</param>
        public void Click27(StatusButtonMethod statusButton, string pathJournalOk, string pathPdfTemp, DatePickerAdd datePicker)
        {
            Okp2GlobalFunction globalFunction = new Okp2GlobalFunction();
            LibaryAutomations libraryAutomation = new LibaryAutomations(WindowsAis3.AisNalog3);
            LibaryAutomations libraryAutomationDoc = new LibaryAutomations(WindowsAis3.AisNalog3);
            var rowNumber = 1;
            libraryAutomation.ClickElements(Journal129AndJournal121.UpdateData);
            AutomationElement automationElement;
            while ((automationElement = libraryAutomation.IsEnableElements(string.Concat(Journal129AndJournal121.AllTaxJournal, rowNumber), null, false, 50)) != null)
            {
                var taxFace = new TaxJournal();
                if (statusButton.Iswork)
                {
                    automationElement.SetFocus();
                    AutoItX.Sleep(1000);
                    taxFace.LoginUser = Environment.UserName;
                    taxFace.IdDelo = Convert.ToInt32(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                        .SelectAutomationColrction(automationElement)
                        .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("УН дела"))));
                    taxFace.DateError = Convert.ToDateTime(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Дата обнаружения нарушения"))));
                    taxFace.Inn = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                        .SelectAutomationColrction(automationElement)
                        .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("ИНН")));
                    taxFace.Kpp = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("КПП")));
                    taxFace.NameFace = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Лицо")));
                    taxFace.Fid = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("ФИД НП")));
                    var status = libraryAutomation.SelectAutomationColrction(automationElement).Cast<AutomationElement>().Where(automationElemenst => automationElemenst.Current.Name != "Column Headers").First(elem => elem.Current.Name.Contains(""));
                    var color = libraryAutomation.GetColorPixel(status);
                    taxFace.Color = color;
                    AddObjectDb dbAutomation = null;
                    switch (color)
                    {
                        case "ff":
                            //Реестр всех документов
                            var listDocMemo = libraryAutomationDoc.SelectAutomationColrction(libraryAutomationDoc.FindFirstElement(Journal129AndJournal121.DocAllJournal)).Cast<AutomationElement>().Distinct().Where(elem => elem.Current.Name.Contains("select0 row"));

                            //Желтый акт или Зеленый отбор
                            var isActYellowAndGreen = listDocMemo.FirstOrDefault(doc =>
                                  libraryAutomationDoc.ParseElementLegacyIAccessiblePatternIdentifiers(
                                    libraryAutomationDoc.SelectAutomationColrction(doc).Cast<AutomationElement>()
                                        .First(elem => elem.Current.Name.Contains("КНД"))) == "1160100" &&
                                    libraryAutomationDoc.GetColorPixel(libraryAutomationDoc.SelectAutomationColrction(doc)
                                        .Cast<AutomationElement>()
                                        .Where(automationElemenst => automationElemenst.Current.Name != "Column Headers")
                                        .First(elem => elem.Current.Name.Contains(""))) == "8000" ||
                                    libraryAutomationDoc.GetColorPixel(libraryAutomationDoc.SelectAutomationColrction(doc)
                                        .Cast<AutomationElement>()
                                       .Where(automationElemenst => automationElemenst.Current.Name != "Column Headers")
                                       .First(elem => elem.Current.Name.Contains(""))) == "ffff00"
                                 );

                            //Выбор отсутствует ли извещение
                            var isIzvestia = listDocMemo.FirstOrDefault(doc => libraryAutomationDoc.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomationDoc.SelectAutomationColrction(doc).Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("КНД"))) == "1165213");

                            //Зеленый акт отбор
                            var isActGreen = listDocMemo.FirstOrDefault(doc =>
                                libraryAutomationDoc.ParseElementLegacyIAccessiblePatternIdentifiers(
                                    libraryAutomationDoc.SelectAutomationColrction(doc).Cast<AutomationElement>()
                                        .First(elem => elem.Current.Name.Contains("КНД"))) == "1160100" &&
                                libraryAutomationDoc.GetColorPixel(libraryAutomationDoc.SelectAutomationColrction(doc)
                                    .Cast<AutomationElement>()
                                    .Where(automationElemenst => automationElemenst.Current.Name != "Column Headers")
                                    .First(elem => elem.Current.Name.Contains(""))) == "8000"
                                );

                            //Выбор зеленого извещение
                            var isIzvestiaGreen = listDocMemo.FirstOrDefault(doc =>
                                libraryAutomationDoc.ParseElementLegacyIAccessiblePatternIdentifiers(
                                    libraryAutomationDoc.SelectAutomationColrction(doc).Cast<AutomationElement>()
                                        .First(elem => elem.Current.Name.Contains("КНД"))) == "1165213" &&
                                libraryAutomationDoc.GetColorPixel(libraryAutomationDoc.SelectAutomationColrction(doc)
                                    .Cast<AutomationElement>()
                                    .Where(automationElemenst => automationElemenst.Current.Name != "Column Headers")
                                    .First(elem => elem.Current.Name.Contains(""))) == "8000"
                                );

                            //Есть ли наличие решения
                            var isReshenie = listDocMemo.FirstOrDefault(doc =>
                                 libraryAutomationDoc.ParseElementLegacyIAccessiblePatternIdentifiers(
                                     libraryAutomationDoc.SelectAutomationColrction(doc).Cast<AutomationElement>()
                                         .First(elem => elem.Current.Name.Contains("КНД"))) == "1165022"
                                );

                            //Выставление извещений
                            if (isActYellowAndGreen != null && isIzvestia == null)
                            {
                                //Обработка Отсутствует извещение но есть акт желтый статус
                                libraryAutomation.ClickElements(Journal129AndJournal121.OpenComplex, null, true);
                                PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Izveshenie);
                                PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ButtonSved);
                                while (true)
                                {
                                    if (libraryAutomation.IsEnableElements(Journal129AndJournal121.NumKabinet, null, true) != null)
                                    {
                                        libraryAutomation.FindFirstElement(Journal129AndJournal121.NumKabinet);
                                        libraryAutomation.SetValuePattern("366.2");
                                        libraryAutomation.ClickElements(Journal129AndJournal121.AddButton);
                                        AutoItX.WinWait(Journal129AndJournal121.DateTime);
                                        AutoItX.WinActivate(Journal129AndJournal121.DateTime);
                                        while (true)
                                        {
                                            if (libraryAutomation.IsEnableElements(Journal129AndJournal121.WindowDateTime, null, true) != null)
                                            {
                                                taxFace.DateIzveshenie = datePicker.Date;
                                                libraryAutomation.SetValuePattern(datePicker.Date.ToString("dd.MM.yy"));
                                                libraryAutomation.FindFirstElement(Journal129AndJournal121.WindowHours);
                                                libraryAutomation.SetValuePattern("10");
                                                libraryAutomation.FindFirstElement(Journal129AndJournal121.WindowsOk);
                                                libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                                                break;
                                            }
                                        }
                                        break;
                                    }
                                }
                                while (true)
                                {
                                    if (libraryAutomation.IsEnableElements(Journal129AndJournal121.FaceName, null, true) != null)
                                    {
                                        libraryAutomation.ClickElements(Journal129AndJournal121.FaceName, null, true);
                                        libraryAutomation.SelectItemCombobox(libraryAutomation.IsEnableElements(Journal129AndJournal121.FaceNameSign), "Лобачев А. А.");
                                        PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Save);
                                        PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SignAll);
                                        break;
                                    }
                                }
                                globalFunction.SignAndSendDoc(libraryAutomation);
                                taxFace.IsLk3 = globalFunction.IsLk3;
                                taxFace.IsMail = globalFunction.IsMail;
                                taxFace.IsTks = globalFunction.IsTks;
                                globalFunction.SendJournalClose();
                                taxFace.MessageInfo = "Извещение успешно выставлено!!!";
                                taxFace.TypeDocument = "Извещение";
                                globalFunction.AddFile(ref taxFace, pathPdfTemp);
                                LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathJournalOk, $"Цвет обработки: 9 Ун дела: {taxFace.IdDelo}; Дата обнаружения нарушения: {taxFace.DateError}; ИНН налогоплательщика: {taxFace.Inn}; КПП: {taxFace.Kpp}; Наименование: {taxFace.NameFace}; Фид: {taxFace.Fid}; Дата вручения извещения: {taxFace.DateIzveshenie.Value.ToString("dd.MM.yy")} ТКС: {Convert.ToInt32(taxFace.IsTks)}; Почта: {Convert.ToInt32(taxFace.IsMail)}; ЛК3: {Convert.ToInt32(taxFace.IsLk3)} Путь к файлу длфя печати:{taxFace.FullPath}", taxFace.MessageInfo);
                                dbAutomation = new AddObjectDb();
                                dbAutomation.AddTaxJournal(taxFace);
                            }
                            else
                            {
                                //Выставление решений                            
                                if (isActGreen != null && isIzvestiaGreen != null && isReshenie == null)
                                {
                                    //Обработка присутствует Акт и извещение зеленое
                                    libraryAutomation.ClickElements(Journal129AndJournal121.OpenComplex, null, true);
                                    PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Reshenia);
                                    PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.PublicInfo);
                                    while (true)
                                    {
                                        if (libraryAutomation.IsEnableElements(Journal129AndJournal121.DateReshenia, null, true) != null)
                                        {
                                            taxFace.DateIzveshenie = datePicker.DateResh;
                                            libraryAutomation.SetValuePattern(datePicker.DateResh.ToString("dd.MM.yy"));
                                            while (true)
                                            {
                                                if (libraryAutomation.IsEnableElements(Journal129AndJournal121.ResheniaFaceSignOpen, null, true) != null)
                                                {
                                                    libraryAutomation.ClickElements(Journal129AndJournal121.ResheniaFaceSignOpen, null, true);
                                                    libraryAutomation.SelectItemCombobox(libraryAutomation.IsEnableElements(Journal129AndJournal121.ResheniaFaceSign), "Лобачев А. А.",0);
                                                    PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Save);
                                                    PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SignAll);
                                                    break;
                                                }
                                            }
                                            break;
                                        }
                                    }
                                    globalFunction.SignAndSendDoc(libraryAutomation);
                                    taxFace.IsLk3 = globalFunction.IsLk3;
                                    taxFace.IsMail = globalFunction.IsMail;
                                    taxFace.IsTks = globalFunction.IsTks;
                                    WindowsAis3 win = new WindowsAis3();
                                    AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                                    AutoItX.Sleep(1000);
                                    PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ClosedComplex);
                                    taxFace.MessageInfo = "Решение успешно выставлено!!!";
                                    taxFace.TypeDocument = "Решение";
                                    globalFunction.AddFile(ref taxFace, pathPdfTemp);
                                    LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathJournalOk, $"Цвет обработки: 9 Ун дела: {taxFace.IdDelo}; Дата обнаружения нарушения: {taxFace.DateError}; ИНН налогоплательщика: {taxFace.Inn}; КПП: {taxFace.Kpp}; Наименование: {taxFace.NameFace}; Фид: {taxFace.Fid}; Дата вручения решения: {taxFace.DateIzveshenie.Value.ToString("dd.MM.yy")} ТКС: {Convert.ToInt32(taxFace.IsTks)}; Почта: {Convert.ToInt32(taxFace.IsMail)}; ЛК3: {Convert.ToInt32(taxFace.IsLk3)} Путь к файлу длфя печати:{taxFace.FullPath}", taxFace.MessageInfo);
                                    dbAutomation = new AddObjectDb();
                                    dbAutomation.AddTaxJournal(taxFace);
                                }
                            }
                            break;
                        case "ff0000":
                            libraryAutomation.ClickElements(Journal129AndJournal121.OpenComplex, null, true);
                            PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.EditTask);
                            PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SignAll);
                            globalFunction.SignAndSendDoc(libraryAutomation);
                            taxFace.IsLk3 = globalFunction.IsLk3;
                            taxFace.IsMail = globalFunction.IsMail;
                            taxFace.IsTks = globalFunction.IsTks;
                            globalFunction.SendJournalClose();
                            taxFace.MessageInfo = "Акт успешно выставлен!!!";
                            taxFace.TypeDocument = "Акт";
                            globalFunction.AddFile(ref taxFace, pathPdfTemp);
                            LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathJournalOk, $"Цвет обработки: 12 Ун дела: {taxFace.IdDelo}; Дата обнаружения нарушения: {taxFace.DateError}; ИНН налогоплательщика: {taxFace.Inn}; КПП: {taxFace.Kpp}; Наименование: {taxFace.NameFace}; Фид: {taxFace.Fid}; ТКС: {Convert.ToInt32(taxFace.IsTks)}; Почта: {Convert.ToInt32(taxFace.IsMail)}; ЛК3: {Convert.ToInt32(taxFace.IsLk3)}", taxFace.MessageInfo);
                            dbAutomation = new AddObjectDb();
                            dbAutomation.AddTaxJournal(taxFace);
                            break;
                        default:
                            taxFace.MessageInfo = "Цвет обработки не определен";
                            LibaryXMLAuto.ErrorJurnal.OkJurnal.JurnalOk(pathJournalOk, $"Цвет обработки: {color} Ун дела: {taxFace.IdDelo}; Дата обнаружения нарушения: {taxFace.DateError}; ИНН налогоплательщика: {taxFace.Inn}; КПП: {taxFace.Kpp}; Наименование: {taxFace.NameFace}; Фид: {taxFace.Fid}; ТКС: {Convert.ToInt32(taxFace.IsTks)}; Почта: {Convert.ToInt32(taxFace.IsMail)}; ЛК3: {Convert.ToInt32(taxFace.IsLk3)}", taxFace.MessageInfo);
                            dbAutomation = new AddObjectDb();
                            dbAutomation.AddTaxJournal(taxFace);
                            break;
                    }
                }
                else
                {
                    break;
                }
                rowNumber++;
            }
        }
        /// <summary>
        /// Налоговое администрирование\Контрольная работа (налоговые проверки)\121. Камеральная налоговая проверка\03. Реестр налоговых деклараций (расчетов), сведения о КНП (все)
        /// </summary>
        /// <param name="statusButton">Кнопка Старт</param>
        /// <param name="pathPdfTemp">Путь к Temp</param>
        /// <param name="datePicker">Дата вызова плательщика</param>
        public void Click28(StatusButtonMethod statusButton, string pathPdfTemp, DatePickerAdd datePicker)
        {
            Okp2GlobalFunction globalFunction = new Okp2GlobalFunction();
            LibaryAutomations libraryAutomation = new LibaryAutomations(WindowsAis3.AisNalog3);
            LibaryAutomations libraryAutomationDoc = new LibaryAutomations(WindowsAis3.AisNalog3);
            var rowNumber = 1;
            libraryAutomation.ClickElements(Journal129AndJournal121.UpdateData121);
            AutomationElement automationElement;
            while ((automationElement =libraryAutomation.IsEnableElements(string.Concat(Journal129AndJournal121.AllTaxJournal121, rowNumber), null,true, 50)) != null)
            {
                var journal = new TaxJournal121();
                if (statusButton.Iswork)
                {
                    automationElement.SetFocus();
                    AutoItX.Sleep(1000);
                    journal.LoginUser = Environment.UserName;
                    journal.RegNumDeclaration = Convert.ToInt32(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                        .SelectAutomationColrction(automationElement)
                        .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Рег. номер декларации (расчета)"))));
                    journal.Period = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                         .SelectAutomationColrction(automationElement)
                         .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Отчетный период")));
                    journal.God = Convert.ToInt32(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                         .SelectAutomationColrction(automationElement)
                         .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Отчетный год"))));
                    journal.Fid = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                        .SelectAutomationColrction(automationElement)
                        .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("ФИД НП")));
                    journal.NameFace = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                        .SelectAutomationColrction(automationElement)
                        .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Налогоплательщик")));
                   journal.Inn = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                         .SelectAutomationColrction(automationElement)
                         .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("ИНН")));
                    journal.IdComplex = Convert.ToInt32(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                         .SelectAutomationColrction(automationElement)
                         .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("УН комплекса"))));
                    journal.DateStartCheck = Convert.ToDateTime(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                         .SelectAutomationColrction(automationElement)
                         .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Дата начала проверки"))));
                    journal.DateFinishCheck = Convert.ToDateTime(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                         .SelectAutomationColrction(automationElement)
                         .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Срок проверки по регламенту"))));
                    journal.DateStartDeclaration = Convert.ToDateTime(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                         .SelectAutomationColrction(automationElement)
                         .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Дата представления декларации"))));
                    journal.DateFinishDeclaration = Convert.ToDateTime(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                         .SelectAutomationColrction(automationElement)
                         .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Срок  представления декларации"))));
                    var status = libraryAutomation.SelectAutomationColrction(automationElement).Cast<AutomationElement>().Where(automationElemenst => automationElemenst.Current.Name == "").ToList();

                    journal.GlobalColor = libraryAutomationDoc.GetColorPixel(status[1]);
                    journal.GlobalProcessColor = libraryAutomationDoc.GetColorPixel(status[2]);
                    //Поиск и нажатие на Исходящие документы
                    var panel = libraryAutomation.SelectAutomationColrction(libraryAutomation.IsEnableElements(Journal129AndJournal121.PanelDoc)).Cast<AutomationElement>().ToArray(); ;
                    if(libraryAutomation.IsEnableElements(Journal129AndJournal121.IshDoc, panel[1], false, 1) != null)
                    {
                        libraryAutomation.ClickElements(Journal129AndJournal121.IshDoc, panel[1], false, 1);
                    }
                    var listDocMemo = libraryAutomation.SelectAutomationColrction(libraryAutomation.FindFirstElement(Journal129AndJournal121.JournalIsh, panel[1])).Cast<AutomationElement>().Distinct().Where(elem => elem.Current.Name.Contains("select0 row")).ToArray();
                    
                    //Если нету выставляем Акт
                    if (!listDocMemo.Any())
                    {
                        journal.ColorDoc = null;
                        if(journal.GlobalProcessColor == "ffffff")
                        {
                            PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.StartKnp);
                        }
                        else
                        {
                            PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.OpenKnp);
                        }
                        while (true)
                        {
                            if (libraryAutomation.IsEnableElements(Journal129AndJournal121.ClosedKnp,null,false,10) != null){
                                libraryAutomation.ClickElements(Journal129AndJournal121.ClosedKnp, null, true);
                                AutoItX.WinWait(Journal129AndJournal121.EditWindows);
                                AutoItX.WinActivate(Journal129AndJournal121.EditWindows);
                                LibaryAutomations libraryAutomationSign = new LibaryAutomations(Journal129AndJournal121.EditWindows);
                                while (true)
                                {
                                    if (libraryAutomationSign.IsEnableElements(Journal129AndJournal121.DateFinish, null, true) != null)
                                    {
                                        libraryAutomationSign.FindFirstElement(Journal129AndJournal121.DateFinish);
                                        libraryAutomationSign.SelectItemCombobox(libraryAutomationSign.IsEnableElements(Journal129AndJournal121.ComboBoxError), "Выявлены нарушения");
                                        PublicGlobalFunction.WindowElementClick(libraryAutomationSign, Journal129AndJournal121.OkEdit);
                                        PublicGlobalFunction.WindowElementClick(libraryAutomationSign, Journal129AndJournal121.WarningOk);
                                        AutoItX.Sleep(1000);
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                        PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.AktNo);
                        PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Established);
                        libraryAutomation.FindFirstElement(Journal129AndJournal121.EstablishedNote);
                        libraryAutomation.SetValuePattern(string.Format(Journal129AndJournal121.Template, journal.Period, journal.God, journal.DateFinishDeclaration?.ToString("dd.MM.yyyy"), journal.DateStartDeclaration?.ToString("dd.MM.yyyy")));
                        PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SaveAktNo);
                        PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SignAktNo);
                        globalFunction.SignAndSendDoc(libraryAutomation);
                        journal.IsLk3 = globalFunction.IsLk3;
                        journal.IsMail = globalFunction.IsMail;
                        journal.IsTks = globalFunction.IsTks;
                        globalFunction.SendJournalClose();
                        journal.MessageInfo = "Акт успешно выставлен!!!";
                        journal.TypeDocument = "Акт";
                        globalFunction.AddFile(ref journal, pathPdfTemp);
                        var dbAutomation = new AddObjectDb();
                        dbAutomation.AddTaxJournal121(journal);
                    }
                    else
                    {
                        var isAct = listDocMemo.FirstOrDefault(doc =>
                                 libraryAutomationDoc.ParseElementLegacyIAccessiblePatternIdentifiers(
                                    libraryAutomationDoc.SelectAutomationColrction(doc).Cast<AutomationElement>()
                                                 .First(elem => elem.Current.Name.Contains("КНД"))) == "1160098");
                        //Извещения если null то выставляем если 1 то 2
                        var isIzvestia = listDocMemo.Where(doc =>
                                          libraryAutomationDoc.ParseElementLegacyIAccessiblePatternIdentifiers(
                                            libraryAutomationDoc.SelectAutomationColrction(doc).Cast<AutomationElement>()
                                       .First(elem => elem.Current.Name.Contains("КНД"))) == "1160099");

                        if ((isAct != null && isIzvestia == null)||(isIzvestia.Count()<datePicker.CountIzveshenie))
                        {
                            var documentStatus = libraryAutomationDoc.SelectAutomationColrction(isAct).Cast<AutomationElement>().Where(automationElemenst => automationElemenst.Current.Name == "").ToList();
                            journal.ColorDoc = libraryAutomationDoc.GetColorPixel(documentStatus[0]);

                            if (journal.ColorDoc== "ffff00"|| journal.ColorDoc == "8000")
                            {
                                //Выставляем извещение
                                PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.OpenKnp);
                                PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.IzveshenieActNo);
                                PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ButtonSved);
                                while (true)
                                {
                                    if (libraryAutomation.IsEnableElements(Journal129AndJournal121.NumKabinet, null, true) != null)
                                    {
                                        libraryAutomation.FindFirstElement(Journal129AndJournal121.NumKabinet);
                                        libraryAutomation.SetValuePattern("366.2");
                                        libraryAutomation.ClickElements(Journal129AndJournal121.AddButton);
                                        AutoItX.WinWait(Journal129AndJournal121.DateTime);
                                        AutoItX.WinActivate(Journal129AndJournal121.DateTime);
                                        while (true)
                                        {
                                            if (libraryAutomation.IsEnableElements(Journal129AndJournal121.WindowDateTime, null, true) != null)
                                            {
                                                journal.DateIzveshenie = datePicker.Date;
                                                libraryAutomation.SetValuePattern(datePicker.Date.ToString("dd.MM.yy"));
                                                libraryAutomation.FindFirstElement(Journal129AndJournal121.WindowHours);
                                                libraryAutomation.SetValuePattern("10");
                                                libraryAutomation.FindFirstElement(Journal129AndJournal121.WindowsOk);
                                                libraryAutomation.InvokePattern(libraryAutomation.FindElement);
                                                break;
                                            }
                                        }
                                        break;
                                    }
                                }
                                while (true)
                                {
                                    if (libraryAutomation.IsEnableElements(Journal129AndJournal121.FaceName, null, true) != null)
                                    {
                                        libraryAutomation.ClickElements(Journal129AndJournal121.FaceName, null, true);
                                        libraryAutomation.SelectItemCombobox(libraryAutomation.IsEnableElements(Journal129AndJournal121.FaceNameSign), "Лобачев А. А.",0);
                                        PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Save);
                                        PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SignAll);
                                        break;
                                    }
                                }
                                //Документ сохранить
                                globalFunction.SignAndSendDoc(libraryAutomation);
                                journal.IsLk3 = globalFunction.IsLk3;
                                journal.IsMail = globalFunction.IsMail;
                                journal.IsTks = globalFunction.IsTks;
                                globalFunction.SendJournalClose();
                                journal.MessageInfo = "Извещение успешно выставлено!!!";
                                journal.TypeDocument = "Извещение";
                                globalFunction.AddFile(ref journal, pathPdfTemp);
                                var dbAutomation = new AddObjectDb();
                                dbAutomation.AddTaxJournal121(journal);
                            }
                        }
                        else
                        {
                            var isGreanAll = isIzvestia.Any(x => libraryAutomationDoc.GetColorPixel(libraryAutomationDoc.SelectAutomationColrction(x).Cast<AutomationElement>().Where(automationElemenst => automationElemenst.Current.Name == "").ToList()[1]) != "8000");
                           // var colorIzv = libraryAutomationDoc.GetColorPixel(libraryAutomationDoc.SelectAutomationColrction().Cast<AutomationElement>().Where(automationElemenst => automationElemenst.Current.Name == "").ToList()[1]);
                            var colorAct = libraryAutomationDoc.GetColorPixel(libraryAutomationDoc.SelectAutomationColrction(isAct).Cast<AutomationElement>().Where(automationElemenst => automationElemenst.Current.Name == "").ToList()[1]);
                            ////Если блок синий и акт и извещение зеленые
                            if (journal.GlobalColor == "ff" && colorAct == "8000" && !isGreanAll)
                            {
                                journal.ColorDoc = colorAct;
                                //Выставляем Решение
                                PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.OpenKnp);
                                PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ReshNo);
                                while (true)
                                {
                                    if (libraryAutomation.IsEnableElements(Journal129AndJournal121.FaceNameGr14, null, true) != null)
                                    {
                                        libraryAutomation.ClickElements(Journal129AndJournal121.FaceNameGr14, null, true);
                                        libraryAutomation.SelectItemCombobox(libraryAutomation.IsEnableElements(Journal129AndJournal121.FaceNameSignGr14), "Лобачев А. А.",0);
                                        PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.Save);
                                        PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.SignAll);
                                        break;
                                    }
                                }
                                //Документ сохранить
                                globalFunction.SignAndSendDoc(libraryAutomation);
                                journal.IsLk3 = globalFunction.IsLk3;
                                journal.IsMail = globalFunction.IsMail;
                                journal.IsTks = globalFunction.IsTks;
                                WindowsAis3 win = new WindowsAis3();
                                AutoItX.Sleep(1000);
                                AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WindowsAis.Width - 20, win.WindowsAis.Y + 160);
                                PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.ClosedComplex121);
                                journal.MessageInfo = "Решение успешно выставлено!!!";
                                journal.TypeDocument = "Решение";
                                globalFunction.AddFile(ref journal, pathPdfTemp);
                                var dbAutomation = new AddObjectDb();
                                dbAutomation.AddTaxJournal121(journal);
                            }
                        }
                    }
                }
                else
                {
                    break;
                }
                rowNumber++;
            }
        }

        /// <summary>
        /// Parse данных для докладной записки по параметрам
        /// </summary>
        /// <param name="statusButton">Статус кнопка</param>
        /// <param name="srvToLoad">Модель с сервера</param>
        /// <param name="serviceGetOrPost">Запросы на сервер</param>
        /// <param name="pathTemp">Путь сохранения Temp</param>
        /// <param name="pathSaveBank">Путь сохранения выписок из банка</param>
        public void Click29(StatusButtonMethod statusButton, List<SrvToLoad> srvToLoad,string serviceGetOrPost, string pathTemp,string pathSaveBank)
        {
            var function = new PreCheckFunction();
            LibaryAutomations libraryAutomation = new LibaryAutomations(WindowsAis3.AisNalog3);
            libraryAutomation.IsExpandOpen(PreCheckElementName.TreeInnExpand1);
            libraryAutomation.IsExpandOpen(PreCheckElementName.TreeInnExpand2);
            libraryAutomation.IsExpandOpen(PreCheckElementName.TreeInnExpand3);
            libraryAutomation.IsExpandOpen(PreCheckElementName.TreeInnExpand4);
            libraryAutomation.IsExpandOpen(PreCheckElementName.TreeInnExpand5);
            libraryAutomation.IsExpandOpen(PreCheckElementName.TreeInnExpand6);
            libraryAutomation.IsExpandOpen(PreCheckElementName.TreeInnExpand7);
            libraryAutomation.IsExpandOpen(PreCheckElementName.TreeInnExpand8);
            libraryAutomation.IsExpandOpen(PreCheckElementName.TreeInnExpand9);
            libraryAutomation.IsExpandOpen(PreCheckElementName.TreeInnExpand10);
            libraryAutomation.IsExpandOpen(PreCheckElementName.TreeInnExpand11);
            libraryAutomation.IsExpandOpen(PreCheckElementName.TreeInnExpand12);
            libraryAutomation.IsExpandOpen(PreCheckElementName.TreeInnExpand13);
            libraryAutomation.IsExpandOpen(PreCheckElementName.TreeInnExpand14);
            libraryAutomation.IsExpandOpen(PreCheckElementName.TreeInnExpand15);
            foreach (var model in srvToLoad)
            {
                if (statusButton.Iswork)
                {
                    var sw = model.Tree.Split('\\').Last();
                    if (model.N134!=null)
                    {
                        switch (sw)
                        {
                            case "1.01. Идентификационные характеристики организации":
                                function.ParseDataBase(statusButton, libraryAutomation, model, PreCheckElementName.TreeNoUl, PreCheckElementName.GridJournal, string.Concat(PreCheckElementName.TreeInnDataArea, 7),  PreCheckElementName.UpdateIdentUl, PreCheckElementName.FiltersGrid, serviceGetOrPost);
                                break;
                            case "1.03. Сведения об учете организации в НО":
                                function.ParseDataBase(statusButton,libraryAutomation, model, PreCheckElementName.TreeInnKey, PreCheckElementName.GridJournal, string.Concat(PreCheckElementName.TreeInnDataArea,3), PreCheckElementName.Update, PreCheckElementName.FiltersGrid, serviceGetOrPost,true);
                                break;
                            case "1.12. Сведения о филиалах, представительствах, иных обособленных подразделениях":
                                function.ParseDataBase(statusButton, libraryAutomation, model, PreCheckElementName.DataFil, PreCheckElementName.GridJournal, string.Concat(PreCheckElementName.TreeInnDataArea, 2), PreCheckElementName.UpdateHistoryFil, PreCheckElementName.FiltersGrid, serviceGetOrPost);
                                break;
                            case "1.18. Сведения об объектах собственности российской организации – имущество":
                                function.ParseDataBase(statusButton, libraryAutomation, model, PreCheckElementName.UlIm, PreCheckElementName.GridJournalIm, string.Concat(PreCheckElementName.DataAreaImFull, 5), PreCheckElementName.UpdateDataUlIm, PreCheckElementName.FiltersIm, serviceGetOrPost);
                                break;
                            case "1.19. Сведения об объектах собственности российской организации – земля":
                                function.ParseDataBase(statusButton, libraryAutomation, model, PreCheckElementName.UlZm, PreCheckElementName.GridJournalIm, string.Concat(PreCheckElementName.DataAreaImFull, 5), PreCheckElementName.UpdateDataUlZm, PreCheckElementName.FiltersIm, serviceGetOrPost);
                                break;
                            case "1.20. Сведения об объектах собственности российской организации – транспорт":
                                function.ParseDataBase(statusButton, libraryAutomation, model, PreCheckElementName.UlTr, PreCheckElementName.GridJournalIm, string.Concat(PreCheckElementName.DataAreaImFull, 6), PreCheckElementName.UpdateDataUlTr, PreCheckElementName.FiltersIm, serviceGetOrPost);
                                break;
                            case "2.02. История изменений сведений об учете организации в НО":
                                function.ParseDataBase(statusButton, libraryAutomation, model, PreCheckElementName.History, PreCheckElementName.GridJournal, string.Concat(PreCheckElementName.TreeInnDataArea, 3), PreCheckElementName.UpdateHistory, PreCheckElementName.FiltersGrid, serviceGetOrPost,true);
                                break;
                            case "Сведения о среднесписочной численности работников":
                                function.ParseDataBase(statusButton, libraryAutomation, model, PreCheckElementName.UlYerFace, PreCheckElementName.GridJournalSvedFace, string.Concat(PreCheckElementName.DataAreaSvedFaceFull, 8), PreCheckElementName.UpdateYerFace, PreCheckElementName.FiltersGridSvedFace, serviceGetOrPost);
                                break;
                            case "01. Картотека счетов РО, ИО, ИП":
                                function.ParseDataBase(statusButton, libraryAutomation, model, PreCheckElementName.CashUl, PreCheckElementName.GridJournalCash, string.Concat(PreCheckElementName.DataAreaCashFull, 3), PreCheckElementName.UpdateCashFace, PreCheckElementName.FiltersCash, serviceGetOrPost);
                                break;
                            case "7. Индивидуальные карточки налогоплательщиков": 
                                function.IndividualCards(statusButton, libraryAutomation, model, PreCheckElementName.CardPpa, PreCheckElementNameIndividualCards.GridJournalCard, string.Concat(PreCheckElementNameIndividualCards.DataAreaCard, 5), PreCheckElementNameIndividualCards.UpdateCashFaceCard, PreCheckElementNameIndividualCards.GridFiltersCard, serviceGetOrPost, pathTemp);
                                break;
                            case "Банковские выписки, справки":
                                function.BankSpr(statusButton, libraryAutomation, model, PreCheckElementName.BankSpravki, serviceGetOrPost, pathSaveBank);
                                break;
                            case "Реестр документов НБО":
                                function.DeclarationIntelligenceUl(statusButton, libraryAutomation, model, PreCheckElementName.Declaration, PreCheckElementName.GridJournalSvedFace, string.Concat(PreCheckElementName.DataAreaSvedFaceFull, 17), PreCheckElementName.UpdateNBO, PreCheckElementName.FiltersGridSvedFace, serviceGetOrPost, pathTemp);
                                break;
                            case "1. Реестр документов НБО":
                                function.DeclarationIntelligenceUl(statusButton, libraryAutomation, model, PreCheckElementName.DeclarationMigration, PreCheckElementName.GridJournalSvedFace, string.Concat(PreCheckElementName.DataAreaSvedFaceFull, 16), PreCheckElementName.UpdateNBO, PreCheckElementName.FiltersGridSvedFace, serviceGetOrPost, pathTemp);
                                break;
                            case "1.18. Сведения об объектах собственности физического лица – имущество":
                                function.ParseDataBase(statusButton, libraryAutomation, model, PreCheckElementName.ImFl, PreCheckElementName.GridJournalIm, string.Concat(PreCheckElementName.DataAreaImFull, 9), PreCheckElementName.UpdateFlIm, PreCheckElementName.FiltersIm, serviceGetOrPost);
                                break;
                            case "1.19. Сведения об объектах собственности физического лица – земля":
                                function.ParseDataBase(statusButton, libraryAutomation, model, PreCheckElementName.ZmFl, PreCheckElementName.GridJournalIm, string.Concat(PreCheckElementName.DataAreaImFull, 9), PreCheckElementName.UpdateFlZm, PreCheckElementName.FiltersIm, serviceGetOrPost);
                                break;
                            case "1.20. Сведения об объектах собственности физического лица – транспорт":
                                function.ParseDataBase(statusButton, libraryAutomation, model, PreCheckElementName.TrFl, PreCheckElementName.GridJournalIm, string.Concat(PreCheckElementName.DataAreaImFull, 10), PreCheckElementName.UpdateFlTr, PreCheckElementName.FiltersIm, serviceGetOrPost);
                                break;
                            case "Поиск ЮЛ":
                                function.FindUlStatement(statusButton, libraryAutomation, model, PreCheckElementName.FindUl, PreCheckFindUl.GridJournalFindUl, string.Concat(PreCheckFindUl.DataAreaFindUl, 6),PreCheckFindUl.UseFilter,PreCheckFindUl.ChangeFilter,serviceGetOrPost,pathTemp);
                                break;
                        }
                    }
                }
                else
                {
                    statusButton.Iswork = false;
                }
            }
        }
        /// <summary>
        /// Подстановка статуса о подтверждении отметки о правонарушении
        /// </summary>
        /// <param name="statusButton">Статус кнопка</param>
        public void Click30(StatusButtonMethod statusButton)
        {
            LibaryAutomations libraryAutomation = new LibaryAutomations(WindowsAis3.AisNalog3);
            var rowNumber = 1;
            libraryAutomation.ClickElements(Journal129AndJournal121.UpdateData);
            AutomationElement automationElement;
            while ((automationElement = libraryAutomation.IsEnableElements(string.Concat(Journal129AndJournal121.AllTaxJournal, rowNumber), null, false, 50)) != null)
            {
                var taxFace129 = new TaxJournal129();
                if (statusButton.Iswork)
                {
                    automationElement.SetFocus();
                    AutoItX.Sleep(1000);
                    taxFace129.LoginUser = Environment.UserName;
                    taxFace129.IdDelo = Convert.ToInt32(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                        .SelectAutomationColrction(automationElement)
                        .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("УН дела"))));
                    taxFace129.DateError = Convert.ToDateTime(libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Дата обнаружения нарушения"))));
                    taxFace129.Inn = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(libraryAutomation
                        .SelectAutomationColrction(automationElement)
                        .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("ИНН")));
                    taxFace129.Kpp = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("КПП")));
                    taxFace129.NameFace = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("Лицо")));
                    taxFace129.Fid = libraryAutomation.ParseElementLegacyIAccessiblePatternIdentifiers(
                        libraryAutomation
                            .SelectAutomationColrction(automationElement)
                            .Cast<AutomationElement>().First(elem => elem.Current.Name.Contains("ФИД НП")));
                    taxFace129.StateColor = $"#{libraryAutomation.GetColorPixel(libraryAutomation.SelectAutomationColrction(automationElement).Cast<AutomationElement>().Where(automationElemenst => automationElemenst.Current.Name != "Column Headers").ToArray()[0])}";
                    taxFace129.StateTaxPayerColor = $"#{libraryAutomation.GetColorPixel(libraryAutomation.SelectAutomationColrction(automationElement).Cast<AutomationElement>().Where(automationElemenst => automationElemenst.Current.Name != "Column Headers").ToArray()[1])}";
                    //Red #ff0000
                    taxFace129.MessageInfo = "Цвет не соответствует не одному атрибуту (Признак ставить не надо)";
                    if (taxFace129.StateColor.Equals("#ff0000"))
                    {
                        if (taxFace129.StateColor.Equals("#ff0000") & taxFace129.StateTaxPayerColor.Equals("#ff0000"))
                        {
                            taxFace129.MessageInfo = "Налогоплательщик снят с учета";
                        }
                        else
                        {
                            taxFace129.MessageInfo = taxFace129.Kpp.Contains("7751") ? "Документы представлены своевременно" : "Организация мигрировала в др. НО";
                        }
                        libraryAutomation.ClickElements(Journal129AndJournal121.ButonState);
                        while (true)
                        {
                            if (libraryAutomation.IsEnableElements(Journal129AndJournal121.WinDialogComment, null, true) != null)
                            {
                                libraryAutomation.SetValuePattern(taxFace129.MessageInfo);
                                PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.WinDialogSave);
                                PublicGlobalFunction.WindowElementClick(libraryAutomation, Journal129AndJournal121.WinOk);
                                break;
                            }
                        }
                    }
                    var dbAutomation = new AddObjectDb();
                    dbAutomation.AddJournal129(taxFace129);
                }
                else
                {
                    break;
                }
                rowNumber++;
            }
        }
        /// <summary>
        /// Функция автоматизации задачи подписания пользовательских заданий
        /// Общие задания\Урегулирование задолженности\05.09 Формирование решения об отказе по заявлению/Подписание руководителем НО
        /// </summary>
        /// <param name="statusButton">Статус кнопка</param>
        public void Click31(StatusButtonMethod statusButton)
        {
            LibaryAutomations libraryAutomation = new LibaryAutomations(WindowsAis3.AisNalog3);
            while ((libraryAutomation.IsEnableElements(TextSignatureOfficeNote.JournalSignatureOffice, null, true)) != null)
            {
                if (statusButton.Iswork)
                {
                    libraryAutomation.FindElement.SetFocus();
                    libraryAutomation.ClickElements(PublicElementName.StartBeforeQ);
                    while (true)
                    {
                        if (libraryAutomation.IsEnableElements(TextSignatureOfficeNote.Sign, null, true) != null)
                        {
                            libraryAutomation.ClickElements(TextSignatureOfficeNote.Sign);
                            break;
                        }
                    }
                    PublicGlobalFunction.WindowElementClick(libraryAutomation, TextSignatureOfficeNote.WinOk);
                    PublicGlobalFunction.WindowElementClick(libraryAutomation, TextSignatureOfficeNote.WinOk1);
                }
                else
                {
                    break;
                }
            }
        }
    }
}
