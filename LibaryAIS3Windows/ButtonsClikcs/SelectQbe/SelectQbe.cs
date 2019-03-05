using AutoIt;
using LibaryAIS3Windows.Window;

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
        /// Само событие галочки на земле или имуществе
        /// </summary>
        public void QbeZemlyOnImushestvo()
        {
            WindowsAis3 win = new WindowsAis3();
            win.ControlGetPos1(WindowsAis3.WinGrid[0], WindowsAis3.WinGrid[1], WindowsAis3.WinGrid[2]);
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 400, win.WindowsAis.Y + win.Y1 + 55);
        }

        /// <summary>
        /// Само событие галочки на Транспорте
        /// </summary>
        public void QbeTransport()
        {
            WindowsAis3 win = new WindowsAis3();
            win.ControlGetPos1(WindowsAis3.WinGrid[0], WindowsAis3.WinGrid[1], WindowsAis3.WinGrid[2]);
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 450, win.WindowsAis.Y + win.Y1 + 55);
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 450, win.WindowsAis.Y + win.Y1 + 300);
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 450, win.WindowsAis.Y + win.Y1 + 320);
        }

        /// <summary>
        /// Само событие простановки С
        /// </summary>
        /// <param name="str">Параметры сотсояния C через слеш /</param>
        public void SelectC(string str)
        {
            WindowsAis3 win = new WindowsAis3();
            win.ControlGetPos1(WindowsAis3.WinGrid[0], WindowsAis3.WinGrid[1], WindowsAis3.WinGrid[2]);
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 70, win.WindowsAis.Y + win.Y1 + 35);
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
            WindowsAis3 win = new WindowsAis3();
            win.ControlGetPos1(WindowsAis3.WinGrid[0], WindowsAis3.WinGrid[1], WindowsAis3.WinGrid[2]);
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 70, win.WindowsAis.Y + win.Y1 + 35);
            AutoItX.ClipPut(str);
            AutoItX.Send(ButtonConstant.Down2);
            AutoItX.Send(ButtonConstant.Right5);
            AutoItX.Send(ButtonConstant.Enter);
            AutoItX.Send(ButtonConstant.CtrlV);
            AutoItX.Send(ButtonConstant.Enter);
        }
    }
}
