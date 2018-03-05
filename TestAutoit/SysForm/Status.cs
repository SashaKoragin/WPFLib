using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoIt;
namespace TestAutoit.SysForm
{
   public class Status
   {
        /// <summary>
        /// Считать позицию Общего окна АИС 3
        /// </summary>
       public static Rectangle WindowsAis = AutoItX.WinGetPos("АИС Налог-3 ПРОМ ","");
        /// <summary>
        /// Считать позицию создание заявки на формирование СНУ
        /// </summary>
        public static Rectangle WinRequest = AutoItX.ControlGetPos("АИС Налог-3 ПРОМ ", "","[NAME:CreateRequestImplView]");
        /// <summary>
        /// Grid контроль полей для вычисления
        /// </summary>
        public static Rectangle WinGrid = AutoItX.ControlGetPos("АИС Налог-3 ПРОМ ", "", "[Name:gridConditions]");
   }
}
