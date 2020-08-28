using AutoIt;
using LibraryAIS3Windows.Window;

namespace LibraryAIS3Windows.ButtonsClikcs.SelectQbe.EventReg
{
    public class EventReg
    {
        public delegate void ClickChecbox();

        /// <summary>
        /// Событие проставление галочки 
        /// </summary>
        public event ClickChecbox Check;

        public void InvokeEvent()
        {
            Check?.Invoke();
        }

        /// <summary>
        /// Само событие галочки на земле или имуществе
        /// Налоговое администрирование\ПОН ИЛ\1. ПОН ИЛ (ПЭ). Организации и физические лица, внесенные в ПОН ИЛ\2.01. ФЛ. Актуальное состояние
        /// </summary>
        public void Chekerfid()
        {
            WindowsAis3 win = new WindowsAis3();
            win.ControlGetPos1(WindowsAis3.WinGrid[0], WindowsAis3.WinGrid[1], WindowsAis3.WinGrid[2]);
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 425, win.WindowsAis.Y + win.Y1 + 35);
        }
    }
}
