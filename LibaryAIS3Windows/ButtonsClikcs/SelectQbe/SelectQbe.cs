using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoIt;

namespace LibaryAIS3Windows.ButtonsClikcs.SelectQbe
{
    /// <summary>
    /// Qbe событийная система подписываемся на Qbe
    /// </summary>
    public class SelectQbe
    {

        public delegate void StartQbe();
        public delegate void SelectQbeAdd(string str);

        /// <summary>
        /// Событие проставление галочки
        /// </summary>
        public event StartQbe Start;
        /// <summary>
        /// Событие Проставление параметра С
        /// </summary>
        public event SelectQbeAdd C;
        /// <summary>
        /// Событие Проставление параметра F
        /// </summary>
        public event SelectQbeAdd F;

        /// <summary>
        /// Метод запуска наших событий запуск производится в том случае если 
        /// подписаны на событие
        /// </summary>
        /// <param name="sysC">Параметры C</param>
        /// <param name="sysF">Параметры F</param>
        public void InvokeEvent(string sysC,string sysF)
        {
            Start?.Invoke();
            C?.Invoke(sysC);
            F?.Invoke(sysF);   
        }
        /// <summary>
        /// Само событие галочки
        /// </summary>
        public void QbeZemlyOnImushestvo()
        {
            AutoItX.MouseClick(ButtonConstant.MouseLeft, Window.WindowsAis3.WindowsAis.X + Window.WindowsAis3.WinGrid.X + 390, Window.WindowsAis3.WindowsAis.Y + Window.WindowsAis3.WinGrid.Y + 55, 1);
        }
        /// <summary>
        /// Само событие простановки С
        /// </summary>
        /// <param name="str">Параметры сотсояния C через слеш /</param>
        public void SelectC(string str)
        {
            AutoItX.MouseClick(ButtonConstant.MouseLeft, Window.WindowsAis3.WindowsAis.X + Window.WindowsAis3.WinGrid.X + 70, Window.WindowsAis3.WindowsAis.Y + Window.WindowsAis3.WinGrid.Y + 35, 1);
            AutoItX.ClipPut(str);
            AutoItX.Send(ButtonConstant.Down1);
            AutoItX.Send(ButtonConstant.Right5);
            AutoItX.Send(ButtonConstant.Enter);
            AutoItX.Send(ButtonConstant.CtrlV);
            AutoItX.Send(ButtonConstant.Enter);
        }
        /// <summary>
        /// Само событие простановки F
        /// </summary>
        /// <param name="str">Параметры состояние F через слеш /</param>
        public void SelectF(string str)
        {
            AutoItX.MouseClick(ButtonConstant.MouseLeft, Window.WindowsAis3.WindowsAis.X + Window.WindowsAis3.WinGrid.X + 70, Window.WindowsAis3.WindowsAis.Y + Window.WindowsAis3.WinGrid.Y + 35, 1);
            AutoItX.ClipPut(str);
            AutoItX.Send(ButtonConstant.Down2);
            AutoItX.Send(ButtonConstant.Right5);
            AutoItX.Send(ButtonConstant.Enter);
            AutoItX.Send(ButtonConstant.CtrlV);
            AutoItX.Send(ButtonConstant.Enter);
        }
    }
}
