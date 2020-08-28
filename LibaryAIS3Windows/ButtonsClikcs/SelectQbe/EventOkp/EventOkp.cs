using AutoIt;
using LibraryAIS3Windows.Window;

namespace LibraryAIS3Windows.ButtonsClikcs.SelectQbe.EventOkp
{
   public class EventOkp
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
        /// </summary>
        public void Checking()
        {
            WindowsAis3 win = new WindowsAis3();
            win.ControlGetPos1(WindowsAis3.WinGrid[0], WindowsAis3.WinGrid[1], WindowsAis3.WinGrid[2]);
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.X1 + 440, win.WindowsAis.Y + win.Y1 + 30);
        }
    }
}
