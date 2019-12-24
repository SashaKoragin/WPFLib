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
        /// Инн плательщика по определению
        /// </summary>
        public string InnPlatel { get; set; }
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
        /// Инн плательщика банка
        /// </summary>
        public string Inn { get; set; }
        /// <summary>
        /// Кпп плательщика банка
        /// </summary>
        public string Kpp { get; set; }
        /// <summary>
        /// Октмо по рапределению
        /// </summary>
        public string Oktmo { get; set; }
        /// <summary>
        /// Парсим ТП для определения входа а вкладку уточнение
        /// </summary>
        public string Tp { get; set; }

        /// <summary>
        /// Возврат результата
        /// </summary>
        /// <param name="paternstring">Патерн поиска</param>
        /// <param name="text">Весь текст на окне любой скрытый и нет</param>
        /// <returns></returns>
        public string IsMathRegx(string paternstring,string text)
        {
            Regex regex = new Regex(paternstring, RegexOptions.Multiline);
            var math = regex.Match(text);
            if (math.Success)
                return math.Value;
            return null;
        }
        /// <summary>
        /// Анализ простановки налдогов 
        /// </summary>
        /// <param name="logica">Как будет идти анализ данных</param>
        /// /// <param name="isTp"></param>
        public void UseNalog(int logica, bool isTp)
        {
            ParsTp();
            if (!isTp)
            {
                while (true)
                {
                    AutoItX.WinActivate(WindowsAis3.AisNalog3);
                    AutoItX.ControlClick(WindowsAis3.AisNalog3, VedRazd1.SelectKbk[0], VedRazd1.SelectKbk[1]);
                    AutoItX.WinWait(VedRazd1.WinNalog[0], VedRazd1.WinNalog[1], 60);
                    if (AutoItX.WinExists(VedRazd1.WinNalog[0], VedRazd1.WinNalog[1]) == 1)
                    {

                        while (true)
                        {
                            WindowsAis3 win = new WindowsAis3();
                            win.ControlGetPos1(WindowsAis3.Nalog[0], WindowsAis3.Nalog[1], WindowsAis3.Nalog[2]);
                            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.X1 + win.WinNalog.X + 40,
                                win.Y1 + win.WinNalog.Y + 60, 1);
                            AutoItX.Send(KbkIfns);
                            AutoItX.Sleep(2000);
                            AutoItX.Send(ButtonConstant.Tab);
                            AutoItX.Send(ButtonConstant.Tab);
                            AutoItX.ControlClick(VedRazd1.WinNalog[0], VedRazd1.SelectKbkStart[0],
                                VedRazd1.SelectKbkStart[1]);
                            var kbkparse = ReadWindow.Read.Reades.ReadForm(VedRazd1.Ifns, 1);
                            if (String.Equals(KbkIfns, kbkparse))
                            {
                                break;
                            }
                        }
                        break;
                    }

                }
            }
            Status(logica, isTp);
        }

        /// <summary>
        /// Анализ 100 Иностранцы
        /// </summary>
        /// <param name="logica">Какой анализ делаем</param>
        /// <param name="isTp"></param>
        public void Status(int logica,bool isTp)
        {
            string status = "01";
            switch (logica)
            {
                case 1:
                    status = "13";
                    SendsStatus(IsSberbank(status));
                    break;
                case 2:
                    SendsTp(isTp);
                    break;
                case 3:
                    if (InnPlatel.Length != 12)
                    {
                        SendsStatus(IsSberbank(status));
                        SendsTp(isTp);
                    }
                    else
                    {
                        status = "09";
                        SendsStatus(status);
                        SendsTp(isTp);
                    }
                    break;
                case 4:
                    status = "02";
                    SendsStatus(IsSberbank(status));
                    SendsTp(isTp);
                    break;
            }
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

        /// <summary>
        /// Функция проверки Сбербанка
        /// </summary>
        /// <param name="status">Статус изменится или нет</param>
        /// <returns></returns>
       public string IsSberbank(string status)
       {
            if (Inn == "7707083893" && Kpp == "526002001")
            {
                status = "15";
            }
           return status;
       }
        /// <summary>
        /// Функция простановки статуса
        /// </summary>
        /// <param name="status">Статус</param>
       public void SendsStatus(string status)
       {
            AutoItX.ControlClick(VedRazd1.Status[0], "", VedRazd1.Status[1]);
            AutoItX.Send(status);
       }
        /// <summary>
        /// Постановка ТП в поле
        /// </summary>
        /// <param name="isTp"></param>
       public void SendsTp(bool isTp)
       {
           if (!isTp)
           {
                string tp = "ТП";
                AutoItX.ControlClick(VedRazd1.SelectTp[0], "", VedRazd1.SelectTp[1]);
                AutoItX.Send(tp);
           }
        }
    }
}
