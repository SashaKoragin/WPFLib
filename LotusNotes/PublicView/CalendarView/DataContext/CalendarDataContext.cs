using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using ViewModelLib.ViewModelPage.CalendarModel;

namespace LotusNotes.PublicView.CalendarView.DataContext
{
   public class CalendarDataContext : BindableBase
    {
        public CalendarModel Calendar { get; }
        public CalendarDataContext()
        {
            Calendar = new CalendarModel();
        }
    }
}
