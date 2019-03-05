using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoIt;
using LibaryAIS3Windows.ButtonsClikcs;
using LibaryAIS3Windows.Mode.RaschetBudg.VedRazd1;
using LibaryAIS3Windows.RegxFull.PublicRegx;
using LibaryAIS3Windows.Window;

namespace LibaryAIS3Windows.RegxFull.RaschetBudg
{
   public class RegxStart
    {
        /// <summary>
        /// Парсим расчетный документ
        /// </summary>
        public string RaschDoc { get; set; }
        /// <summary>
        /// Парсим распределение платежа
        /// </summary>
        public string RaspredPl { get; set; }
        /// <summary>
        /// Сам платеж
        /// </summary>
        public string Platej {  get; set; }
        /// <summary>
        /// КБК не правильный
        /// </summary>
        public string Kbk100 { get; set; }
        /// <summary>
        /// КБК наш где платеж
        /// </summary>
        public string KbkIfns { get; set; }
        /// <summary>
        /// Плательщик
        /// </summary>
        public string Platelsik { get; set; }
        /// <summary>
        /// Инн плательщика банка
        /// </summary>
        public string Inn { get; set; }
        /// <summary>
        /// Кпп плательщика банка
        /// </summary>
        public string Kpp { get; set; }
        /// <summary>
        /// Парсим ТП для определения входа а вкладку уточнение
        /// </summary>
        public string Tp { get; set; }
        /// <summary>
        /// Проверка на заполнение строк платежа
        /// </summary>
        public bool IsNulable { get; set; }
        /// <summary>
        /// Ошибка проверки
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// Возврат результата
        /// </summary>
        /// <param name="paternstring">Патерн поиска</param>
        /// <param name="text">Весь текст на окне любой скрытый и нет</param>
        /// <returns></returns>
        private string IsMathRegx(string paternstring,string text)
        {
            Regex regex = new Regex(paternstring, RegexOptions.Multiline);
            var math = regex.Match(text);
            if (math.Success)
                return math.Value;
            return null;
        }
        /// <summary>
        /// Функция парсинга модели
        /// </summary>
        /// <param name="text">Текст для разбора</param>
        public void Parse(string text)
        {
            try
            {
                var pattern = new FullRegx();
                RaschDoc = IsMathRegx(pattern.RegxRasch, text);
                RaspredPl = IsMathRegx(pattern.RaspredPl, text);
                Platej = IsMathRegx(pattern.Platej, text);
                Platelsik = IsMathRegx(pattern.Platelsik, text);
                Kbk100 = IsMathRegx(pattern.Kbk, RaspredPl);
                KbkIfns = IsMathRegx(pattern.Kbk, Platej);
                Inn = IsMathRegx(pattern.Inn, Platelsik);
                Kpp = IsMathRegx(pattern.Kpp, Platelsik);
                IsNulable = false;
            }
            catch (Exception e)
            {
                Error = "Выход из модели не можем спарсить данные строку!!!";
                IsNulable = true;
            }
        }

        public void UseNalog()
        {
            ParsTp();
            while (true)
            {
                AutoItX.WinActivate(WindowsAis3.AisNalog3);
                AutoItX.ControlClick(WindowsAis3.AisNalog3, VedRazd1.SelectKbk[0], VedRazd1.SelectKbk[1]);
                AutoItX.WinWait(VedRazd1.WinNalog[0], VedRazd1.WinNalog[1], 60);
                if (AutoItX.WinExists(VedRazd1.WinNalog[0], VedRazd1.WinNalog[1]) == 1)
                {
                    WindowsAis3 win = new WindowsAis3();
                    win.ControlGetPos1(WindowsAis3.Nalog[0], WindowsAis3.Nalog[1], WindowsAis3.Nalog[2]);
                    AutoItX.MouseClick(ButtonConstant.MouseLeft, win.X1 +win.WinNalog.X+ 40, win.Y1 + win.WinNalog.Y + 60, 1);
                    AutoItX.Send(KbkIfns);
                    AutoItX.Sleep(1000);
                    AutoItX.Send(ButtonConstant.Tab);
                    AutoItX.Send(ButtonConstant.Tab);
                    AutoItX.ControlClick(VedRazd1.WinNalog[0], VedRazd1.SelectKbkStart[0], VedRazd1.SelectKbkStart[1]);
                    Status();
                    break;
                }
            }
        }


        public void Status()
        {
            string status = "13";
            if (Inn == "ИНН:7707083893" && Kpp== "КПП:526002001")
            {
                status = "15";
            }
            AutoItX.ControlClick(VedRazd1.Status[0], "", VedRazd1.Status[1]);
            AutoItX.Send(status);
        }

        public void ParsTp()
        {
            while(true)
            {
                try
                {
                    var pattern = new FullRegx();
                    var texttp = ReadWindow.Read.Reades.HidenTextReturn(WindowsAis3.AisNalog3);
                    Tp = IsMathRegx(pattern.Tp, texttp);
                    if (!String.IsNullOrWhiteSpace(Tp))
                    {
                        break;
                    }
                }
                catch (Exception)
                {
                    // ignored
                }
            }
        }
    }
}
