using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoIt;
using LibaryAIS3Windows.Window;

namespace LibaryAIS3Windows.ButtonsClikcs.SelectQbe.EventOkp
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
            AutoItX.MouseClick(ButtonConstant.MouseLeft, win.WindowsAis.X + win.WinGrid.X + 440, win.WindowsAis.Y + win.WinGrid.Y + 30);
        }
    }
}
